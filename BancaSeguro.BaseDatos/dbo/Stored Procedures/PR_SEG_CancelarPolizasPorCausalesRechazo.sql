
CREATE PROCEDURE [dbo].[PR_SEG_CancelarPolizasPorCausalesRechazo]
/******************************************************************************************************************************************************
REQUERIMIENTO: HU004.2 - Generar recobros
AUTOR: Jetlhen Yeny Roa Castañeda
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE CREACIÓN: 28/02/2016
OBJETIVO: Procedimiento que verifica desde el archivo de COBIS cuáles son las pólizas que deben ser canceladas por causales, además las inactiva 
		  en recobros, las cancela en venta y las elimina del archivo de resultados de COBIS. Consulta la tabla de SEG_ArchivoResultadoCobis, actualiza 
		  las tablas SEG_Recobro Y SEG_VENTA; finalmente elimina de la tabla  SEG_ArchivoResultadoCobis los registros que cumplieron las características 
		  descritas anteriormente.
-------------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se inserta novedad para la poliza 
REQUERIMIENTO: HU012 - Consultar Venta
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 
-------------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES:Se quita la parte del script en donde se borran los datos de la tabla SEG_ArchivoResultadoCobis si cruzan con la tabla @CancelarPolizas, 
			   ahora lo que se hace es que se inactivan los registros de la tabla SEG_ArchivoResultadoCobis si cruzan con @CancelarPolizas y se dejan 
			   en 0
REQUERIMIENTO: HU004.2 - Generar recobros
AUTOR: Jetlhen Yeny Roa Castañeda
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 21/04/2016
-------------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se ajusta el SP para especifcar los campos a insertar en la tabla SEG_DetalleNovedadPoliza
REQUERIMIENTO: SD1588485-HU004.2 - Generar recobros
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 02/06/2016
-------------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se ajusta el SP para especifcar los campos a insertar en la tabla SEG_DetalleNovedadPoliza
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 02/06/2016
-------------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se ajusta para consultar el tipo de novedad de cancelación y la creación del detalle de novedad de la 
				cancelación
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 07/07/2016
-------------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se ajusta el registro de la novedad de acuerdo a la nueva estructura
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 13/07/2016
******************************************************************************************************************************************************/
AS
BEGIN

	DECLARE @CancelarPolizas TABLE
	(
		referencia	varchar	(50),
		idVenta INT,		
		idCausalNovedad VARCHAR(2)
	)
	DECLARE @codigoTipoNovedadCancelacion INT = 1	,
			@idTipoNovedad INT = 0,
			@EstadoCancelado int =ISNULL((SELECT codigoEstadoPoliza FROM dbo.SEG_EstadoPoliza sep WHERE descripcionEstadoPoliza='Cancelado'),0),
			@EstadoCobroCancelado INT=ISNULL((select codigoEstadoCobro from [dbo].[SEG_EstadoCobro] WHERE descripcionEstadoCobro='Cancelado'),0),
			@inactivarecobro int =0

	SET @idTipoNovedad = ISNULL((SELECT idTipoNovedad FROM SEG_TipoNovedad WHERE codigoTipoNovedad = @codigoTipoNovedadCancelacion),0)


	--Obtener las pólizas canceladas desde el archivo de resultado Cobis
	Insert into @CancelarPolizas
	select distinct a.referencia, C.idVenta, b.idCausalNovedad
	from [dbo].[SEG_ArchivoResultadoCobis] a (NOLOCK)
	Inner Join [dbo].[SEG_CausalNovedad] b (NOLOCK) On Upper(Ltrim(rtrim(a.error)))=Upper(Ltrim(rtrim(b.nombreNovedad)))
	INNER JOIN dbo.SEG_Venta C (NOLOCK) ON A.referencia = C.consecutivo
	Where b.idTipoNovedad = @idTipoNovedad	

	UPDATE REC
	SET REC.activo=@inactivarecobro, 
		REC.idEstadoCobro=@EstadoCobroCancelado
	FROM  [dbo].[SEG_Recobro] REC (NOLOCK)
	INNER JOIN @CancelarPolizas CANPOL ON REC.consecutivoPoliza=CANPOL.Referencia

	--Se cancelan las pólizas en Venta por cancelación desde el archivo de resultado Cobis 

	UPDATE vent
	set vent.codigoEstadoPoliza=@EstadoCancelado
	FROM [dbo].[SEG_Venta] vent (NOLOCK)
	INNER JOIN @CancelarPolizas CANPOL ON vent.consecutivo=CANPOL.Referencia

	--Se Inactivan los registros de cobros no existosos para no ser gestionados en el proceso de recobros
	UPDATE a
	SET A.activo = 0
	FROM [dbo].[SEG_ArchivoResultadoCobis] a
	INNER JOIN @CancelarPolizas CANPOL ON a.referencia=CANPOL.Referencia

	--Se inserta el registro de la novedad de cancelación de la póliza
	INSERT INTO SEG_DetalleNovedadPoliza
				(idVenta,
				fechaNovedad,
				fechaUltimoPeriodoPago,
				idCausalNovedad)
	SELECT idVenta, GETDATE(), NULL ,idCausalNovedad
	FROM @CancelarPolizas
END