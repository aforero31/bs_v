
CREATE PROCEDURE [dbo].[PR_SEG_CancelarPolizasPorLlegarMaxIntentoCobro]
/************************************************************************************************************************************************************
REQUERIMIENTO:SD1588485 HU004.1- Generar cobros días hábiles sin recobros.
AUTOR: Jetlhen Yeny Roa Castañeda
EMPRESA: Unión temporal FS-BAC-2013.
FECHA:28/02/2016
OBJETIVO: Generar SP para cancelar la poliza si completa el máximo parametrizado de intento de cobro, validar 
			 tabla ArchivoResultadoCobis y sumar contadores por póliza de la tabla de recobros para saber el número 
			 de intentos de cobro para comparar con parametro de intentos máximo. Si es mayor o igual cancelar póliza 
			 en recobro y en venta.
--------------------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se evitan valores quemados con la creación de la variable @MaximoCobro y se evita el campo SuperoIntentos en la tabla @PolizasSuperanIntento
REQUERIMIENTO: SD1588485 HU004.1- Generar cobros días hábiles sin recobros.
AUTOR: Jetlhen Yeny Roa Castañeda
EMPRESA:Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 22/03/2016
--------------------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se cambia campo id x idParametro en la tabla SEG_Parametro pues generaba error xq estaba id. Wilver Hizo el cambio en parametros
REQUERIMIENTO: SD1588485 HU004.1- Generar cobros días hábiles sin recobros.
AUTOR: Jetlhen Yeny Roa Castañeda
EMPRESA:Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 18/04/2016
--------------------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agregan las variables @InactivarRecobro y @EstadoPoliInacintentCobro para no dejar quemado código.
REQUERIMIENTO: SD1588485 HU004.1- Generar cobros días hábiles sin recobros.
AUTOR: Jetlhen Yeny Roa Castañeda
EMPRESA:Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 23/05/2016
--------------------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se ajusta el calculo de máximo intentos de cobros y se registra la novedad de cancelación de la póliza.
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA:Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 07/07/2016
--------------------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se ajusta el registro de la novedad de pago para almacenar el campo origen de la novedad
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 13/07/2016
*************************************************************************************************************************************************************/
AS
BEGIN
	DECLARE @PolizasSuperanIntento TABLE 
			(
				consecutivoPoliza	VARCHAR	(50),
				contador	INT,
				fechaCobro DATE
			)

	DECLARE @MaximoCobro varchar(84)=ISNULL((SELECT valor FROM [dbo].[SEG_Parametro] WHERE idParametro=1),0),
	@InactivarRecobro BIT=(SELECT 0),
	@EstadoCobroCancelado INT= ISNULL((select codigoEstadoCobro from [dbo].[SEG_EstadoCobro] WHERE UPPER(descripcionEstadoCobro)=UPPER('Cancelado')),0),
	@PolizaCancelada INT=ISNULL((select codigoEstadoPoliza from [dbo].SEG_EstadoPoliza WHERE descripcionEstadoPoliza='Cancelado'),0),
	@codigoTipoNovedadCancelacion INT = 1,
	@idCausalNovedad INT = 0,
	@idTipoNovedad INT = 0
	

	SET @idTipoNovedad = ISNULL((SELECT idTipoNovedad FROM SEG_TipoNovedad WHERE codigoTipoNovedad = @codigoTipoNovedadCancelacion),0)
	SET @idCausalNovedad = ISNULL((SELECT TOP 1 SEG_CausalNovedad.idCausalNovedad FROM SEG_CausalNovedad WHERE idTipoNovedad = @idTipoNovedad AND codigoCausalNovedadNegocio= '03'),0) 


	INSERT INTO @PolizasSuperanIntento(consecutivoPoliza,contador,fechaCobro)
	SELECT consecutivoPoliza, sum(contador)contador, min(fechaUltimoPeriodo)
	FROM [dbo].[SEG_Recobro] (NOLOCK)
	WHERE activo=1	
	GROUP BY consecutivoPoliza
	HAVING SUM(contador)>=@MaximoCobro

	-- Se cancela la póliza en recobro por superar máx de intentos
	UPDATE a
	SET a.activo=@InactivarRecobro,
		a.idEstadoCobro=@EstadoCobroCancelado
	FROM [dbo].[SEG_Recobro] a (NOLOCK)
	INNER JOIN @PolizasSuperanIntento b ON a.consecutivoPoliza=b.consecutivoPoliza

	-- Se cancela la póliza en venta por superar máx de intentos
	UPDATE a
	SET a.codigoEstadoPoliza=@PolizaCancelada
	FROM [dbo].[SEG_Venta] a (NOLOCK)
	INNER JOIN @PolizasSuperanIntento b ON a.consecutivo=b.consecutivoPoliza	

	-- Se registra la novedad de rechazo que cancelo la póliza
	INSERT INTO SEG_DetalleNovedadPoliza
				(idVenta,
				fechaNovedad,
				fechaUltimoPeriodoPago,
				idCausalNovedad)
	SELECT a.idVenta ,getdate(), b.fechaCobro ,@idCausalNovedad
	FROM [dbo].[SEG_Venta] a (NOLOCK)
	INNER JOIN @PolizasSuperanIntento b ON a.consecutivo=b.consecutivoPoliza	
END
