
CREATE PROCEDURE [dbo].[PR_SEG_GenerarArchivoAseguradora]
AS
/*--------------------------------------------------------------------------------------------------
REQUERIMIENTO:SD1588485 - HU008
AUTOR: Jetlhen Roa.
EMPRESA: Unión temporal FS-BAC-2013.
FECHA CREACIÓN: 11/04/2016
OBJETIVO: Script que permite crear la tabla de paso SEG_ArchivoAseguradora y en la cuál se almacena el
		  archivo que se envía a la aseguradora con las pólizas pagadas y canceladas del día anterior.
----------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se consulta la altura de la tabla SEG_Venta
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 06/07/2016
----------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se ajusta la consulta de la novedad de acuerdo a la nueva estructura
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 13/07/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se establece el estado anulado en la venta cuando es una anulación
REQUERIMIENTO: SD1588485 QC8847
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 14/09/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se ajusta el monto del cobro efectivo
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 28/10/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se ajusta el calculo de la altura.
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 17/11/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se ajusta el calculo de la altura.
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 26/11/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se añade parametro fecha recaudo para el calculo de la altura.
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 28/11/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se cambia la fecha ultimo periodo pago por fecha Novedad
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 20/12/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se reversa ajuste de fecha de cancelacion para que en ves de novedad sea el ultimo periodo pago
REQUERIMIENTO: SD1588485
AUTOR: Enrique Rivera
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 29/12/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACION 
REQUERIMIENTO: SD3325276 
PROPOSITO: Se añade campo en el order by para que tenga en cuanta el mayor valor
AUTOR: Enrique Rivera
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 24/01/2018
----------------------------------------------------------------------------------------------------------------------------------------------------*/
BEGIN

DECLARE @HOY DATE=convert(date,getdate())
DECLARE	@habilAnterior DATE
DECLARE @codigoTipoNovedadCancelacion INT = 1
DECLARE @codigoTipoNovedadAnulacion INT = 2
DECLARE @codigoTipoNovedadPago INT = 3 
DECLARE @idNovedadCancelacion int =ISNULL((SELECT DISTINCT idtiponovedad FROM [dbo].SEG_TipoNovedad WHERE codigoTipoNovedad = @codigoTipoNovedadCancelacion),0)
DECLARE @idNovedadAnulacion INT = ISNULL((SELECT idTipoNovedad FROM SEG_TipoNovedad WHERE codigoTipoNovedad = @codigoTipoNovedadAnulacion),0)
DECLARE @idNovedadPago int = ISNULL((SELECT DISTINCT idtiponovedad FROM [dbo].SEG_TipoNovedad WHERE codigoTipoNovedad = @codigoTipoNovedadPago),0)

	
	
	--Creación de tablas temporales
	DECLARE @BaseCanceladas TABLE
	(
	idVenta	int,	
	idTipoNovedad INT,
	fechaNovedad	datetime,
	codigoCausalNovedadNegocio varchar(2)
	)

	DECLARE @BasePagadas TABLE
	(
	idVenta	int,
	idTipoNovedad INT,
	fechaRecaudo	datetime,
	valorRecaudo	decimal	(18,2),
	codigoCausalNovedadNegocio varchar(2)
	)
	DECLARE @BaseCanceladasFinal TABLE
	(
	tipodeMovimiento	int,
	codigoProducto	varchar	(50),
	numeroCertificado	varchar	(50),
	numeroCuenta	varchar	(50),
	valorRecaudo	decimal	(18,2),
	fechaNovedad	varchar	(37),
	Altura	varchar	(3),
	codigoNovedad	varchar	(2)
	)

	DECLARE @BasePagadasFinal TABLE
	(
	tipodeMovimiento	int,
	codigoProducto	varchar	(50),
	numeroCertificado	varchar	(50),
	numeroCuenta	varchar	(50),
	valorRecaudo	decimal	(18,2),
	fechaNovedad	varchar	(37),
	Altura	varchar	(3),
	codigoNovedad	varchar	(2)
	)

	--Valida que hoy sea un día hábil
	IF EXISTS(SELECT * FROM [dbo].[SEG_DiaHabil] WHERE dbo.SEG_DiaHabil.Fecha=@HOY)
	BEGIN

			SELECT @habilAnterior = MAX(Fecha) FROM [dbo].[SEG_DiaHabil] WHERE dbo.SEG_DiaHabil.Fecha < @HOY
			
			--Obtener las pólizas cancelas por intentos de cobro(rechazo) y por archivo de resultado Cobis y Cancelación
			INSERT INTO @BaseCanceladas (idVenta,idTipoNovedad,fechaNovedad,codigoCausalNovedadNegocio)
			SELECT DET.idVenta,CAU.idTipoNovedad,CASE WHEN DET.fechaUltimoPeriodoPago IS NULL THEN DET.fechaNovedad ELSE DET.fechaUltimoPeriodoPago END,CAU.codigoCausalNovedadNegocio
			FROM SEG_DetalleNovedadPoliza DET (NOLOCK)		
			INNER JOIN SEG_CausalNovedad CAU (NOLOCK) ON CAU.idCausalNovedad = DET.idCausalNovedad
			WHERE CONVERT(DATE,DET.fechaNovedad)=@habilAnterior
			AND CAU.idTipoNovedad IN ( @idNovedadCancelacion, @idNovedadAnulacion)
				
			--Almacena en la tabla las pólizas que fueron canceladas ayer y arma casi tabla final				
			INSERT INTO @BaseCanceladasFinal (tipodeMovimiento, codigoProducto, numeroCertificado,numeroCuenta,valorRecaudo,fechaNovedad,Altura,codigoNovedad)
			SELECT tipodeMovimiento = 2, VENT.codigoSeguro AS codigoProducto, vent.consecutivo AS numeroCertificado, vent.numeroCuenta, vent.valorPoliza AS valorRecaudo,
									CONCAT(RIGHT('0' + RTRIM(DAY(fechaNovedad)), 2),RIGHT('0' + RTRIM(MONTH(fechaNovedad)), 2),RIGHT('0' + RTRIM(YEAR(fechaNovedad)), 4)) AS fechaNovedad,									
									 '' AS Altura,
									 a.codigoCausalNovedadNegocio AS codigoNovedad
			FROM SEG_VENTA VENT
			INNER JOIN @BaseCanceladas A		ON VENT.idVenta=A.idVenta

			--Almacena en la tabla las pólizas que fueron pagadas ayer
			INSERT INTO @BasePagadas (idVenta,idTipoNovedad,fechaRecaudo,valorRecaudo,codigoCausalNovedadNegocio)
			SELECT DET.idVenta,CAU.idTipoNovedad
			,DET.fechaNovedad			
			,CASE WHEN SR.idRecobro IS NULL THEN VENT.valorPoliza ELSE SR.valorRecaudo END
			,''
			FROM SEG_DetalleNovedadPoliza DET (NOLOCK)		
			INNER JOIN SEG_CausalNovedad CAU (NOLOCK) ON CAU.idCausalNovedad = DET.idCausalNovedad	
			INNER JOIN SEG_VENTA VENT ON VENT.idVenta = DET.idVenta
			LEFT JOIN SEG_Recobro SR (NOLOCK) ON SR.consecutivoPoliza = VENT.consecutivo AND SR.fechaUltimoPeriodo = DET.fechaUltimoPeriodoPago	
			WHERE CONVERT(DATE,fechaNovedad)=@habilAnterior
			AND CAU.idTipoNovedad = @idNovedadPago			
				

			--Almacena en la tabla las pólizas que fueron pagadas ayer y arma casi tabla final	
			INSERT INTO @BasePagadasFinal (tipodeMovimiento,codigoProducto,numeroCertificado,numeroCuenta,valorRecaudo,fechaNovedad,Altura,codigoNovedad)
			SELECT tipodeMovimiento=CASE WHEN vent.numMesesPeriodicidad = 1 THEN 1										
										 WHEN vent.numMesesPeriodicidad=12 THEN 3
										 ELSE 0
									END , vent.codigoSeguro AS codigoProducto, vent.consecutivo AS numeroCertificado, vent.numeroCuenta, A.valorRecaudo AS valorRecaudo,
									CONCAT(RIGHT('0' + RTRIM(DAY(fechaRecaudo)), 2),RIGHT('0' + RTRIM(MONTH(fechaRecaudo)), 2),RIGHT('0' + RTRIM(YEAR(fechaRecaudo)), 4))  fechaRecaudo,
									(altura + 1)  -  ROW_NUMBER() OVER(PARTITION BY vent.idVenta ORDER BY vent.idVenta,a.fechaRecaudo,a.valorRecaudo desc) as altura,
									a.codigoCausalNovedadNegocio AS codigoNovedad
			FROM SEG_VENTA VENT
			INNER JOIN @BasePagadas A ON VENT.idVenta=A.idVenta
			order by numeroCertificado, altura asc
		

		-- VERIFICA LA EXISTENCIA DE LA TABLA SEG_ArchivoAseguradora
				IF EXISTS (SELECT * FROM sysobjects WHERE name='SEG_ArchivoAseguradora' and xtype='U')
					BEGIN
	      			DROP TABLE SEG_ArchivoAseguradora
				END	

			--Arma la tabla final de ArchivoAseguradora
			SELECT DISTINCT tipodeMovimiento,codigoProducto,numeroCertificado,numeroCuenta,valorRecaudo,fechaNovedad,Altura,codigoNovedad
			INTO 
			SEG_ArchivoAseguradora
			FROM @BaseCanceladasFinal
			UNION ALL
			SELECT tipodeMovimiento,codigoProducto,numeroCertificado,numeroCuenta,valorRecaudo,fechaNovedad,Altura,codigoNovedad
			FROM @BasePagadasFinal 
			order by numeroCertificado,fechaNovedad
	END
END