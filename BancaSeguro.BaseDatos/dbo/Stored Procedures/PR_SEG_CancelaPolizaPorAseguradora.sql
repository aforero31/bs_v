

CREATE PROCEDURE [dbo].[PR_SEG_CancelaPolizaPorAseguradora]
AS
BEGIN

/* **************************************************************************************************************************************************
REQUERIMIENTO: SD1588485 - HU006 RecibirArchivoCancelacionPolizas
AUTOR: Jetlhen Roa.
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE CREACIÓN: 10/03/2016
OBJETIVO: Revisa la tabla en la que se carga el archivo de cancelación de polizas que envía la aseguradora 
		 (BANCASEGUROS.dbo.Seg_ArchivoEntradaCancelaPoliza) y verifica si están vigentes para cancelarlas e informar en el mismo archivo de salida
		  Sino encuentra las pólizas que vienen en el archivo en la tabla de venta debe notificarlo en el archivo de salida
		  Si la póliza ya estaba cancelada también debe notificarlo en el archivo de salida.
		  --Debe validar que el númerocertificadoseguro coincida con el número de la póliza que esta en la tabla SEG_venta vs SEG_ArchivoCancelacionPolizas, 
		  --validando 1o que se encuentre vigente y luego se debe actualizar el estado a cancelada la póliza tanto en la tabla de venta como en la de recobro.  
		  -- Si coinciden debe dejar el campo codigoestadopoliza en 2 segun la tabla select * from [dbo].[SEG_EstadoPoliza]
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: se agregan las variables @codigoEstadoPolizaCancelado y @cancelacionPorArchivoAseguradora al script
REQUERIMIENTO: SD1588485 - HU006 RecibirArchivoCancelacionPolizas
AUTOR: Jetlhen Roa.
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 10/05/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Ajuste en los llamados a las tablas omitiendo el nombre de la base de datos.
REQUERIMIENTO: SD1588485 - HU006 RecibirArchivoCancelacionPolizas
AUTOR: Jetlhen Roa.
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 16/06/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Ajuste en la consulta del tipo de novedad cancelación.
REQUERIMIENTO: SD1588485
AUTOR: Iraida MOntoya.
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 07/07/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se registra la novedad de cancelación de la póliza 
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 14/07/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se establece el estado anulado en la venta cuando es una anulación
REQUERIMIENTO: SD1588485 QC8847
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 14/09/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se modifica la consulta de inserción en la tab @archivoEntrada incluyendo
                INNER JOIN con la SEG_TipoNovedad debido a que el codigo de causal numero 13
                esta presente para dos tipos de novedades una de cancelaciíon y otra de pagos
                se filtra unicamente para cancelacion y anulación
REQUERIMIENTO: SD3975509 
AUTOR: Paulo Mora
EMPRESA: Unión temporal IG SERVICES.
FECHA DE MODIFICACIÓN: 13/09/2019
**************************************************************************************************************************************************/
DECLARE @archivoEntrada TABLE
	(
		codigoproducto VARCHAR(100),
		numeroCertificado VARCHAR(50),		
		fechaNovedad DATE,
		causalNovedad VARCHAR(50),
		tipoNovedad VARCHAR(50),
		idCausalNovedad INT,
		resultado VARCHAR(100),
		idventa INT
	)

DECLARE @codigoTipoNovedadCancelacion INT = 1,
		@codigoTipoNovedadAnulacion INT = 2,
		@idTipoNovedadCancelacion INT,
		@idTipoNovedadAnulacion INT,
		@EstadoCancelado INT =ISNULL((SELECT codigoEstadoPoliza FROM dbo.SEG_EstadoPoliza sep WHERE descripcionEstadoPoliza='Cancelado'),0),
		@EstadoAnulado INT =ISNULL((SELECT codigoEstadoPoliza FROM dbo.SEG_EstadoPoliza sep WHERE descripcionEstadoPoliza='Anulado'),0),
		@EstadoCobroCancelado INT=ISNULL((SELECT codigoEstadoCobro FROM [dbo].[SEG_EstadoCobro] WHERE descripcionEstadoCobro='Cancelado'),0),
		@EstadoCobroAnulado INT=ISNULL((SELECT codigoEstadoCobro FROM [dbo].[SEG_EstadoCobro] WHERE descripcionEstadoCobro='Anulado'),0)

SET @idTipoNovedadCancelacion = ISNULL((SELECT idTipoNovedad FROM SEG_TipoNovedad WHERE codigoTipoNovedad = @codigoTipoNovedadCancelacion),0)
SET @idTipoNovedadAnulacion = ISNULL((SELECT idTipoNovedad FROM SEG_TipoNovedad WHERE codigoTipoNovedad = @codigoTipoNovedadAnulacion),0)

INSERT INTO @archivoEntrada
SELECT arcEntCan.codigoProducto,arcEntCan.numeroCertificadoSeguro,CONVERT(DATETIME, arcEntCan.fechaNovedad),arcEntCan.causalNovedad,arcEntCan.tipoNovedad, ISNULL(cauNov.idCausalNovedad,0) idcausalNovedad, 
	   CASE 
			WHEN ven.idVenta IS NULL THEN 'La poliza no se encuentra creada en el sistema'
			WHEN cauNov.idCausalNovedad IS NULL THEN 'Causal de novedad no registrada en el sistema'
			WHEN ven.codigoEstadoPoliza = 2 THEN  'La poliza ya estaba cancelada en el sistema'
			WHEN ven.codigoEstadoPoliza <> 2 THEN  'La poliza fue cancelada'
			ELSE '' END resultado,
		CASE 
			WHEN ven.idVenta IS NULL THEN 0
			WHEN cauNov.idCausalNovedad IS NULL THEN 0
			WHEN ven.codigoEstadoPoliza = 2 THEN  0
			ELSE ven.idVenta END idventa  
FROM SEG_ArchivoEntradaCancelaPoliza arcEntCan
LEFT JOIN SEG_CausalNovedad cauNov ON cauNov.codigoCausalNovedadNegocio = arcEntCan.causalNovedad
INNER JOIN SEG_TipoNovedad tipNov ON tipNov.idTipoNovedad = cauNov.idTipoNovedad AND tipNov.codigoTipoNovedad = arcEntCan.tipoNovedad
and tipNov.codigoTipoNovedad IN (@codigoTipoNovedadCancelacion,@codigoTipoNovedadAnulacion)
LEFT JOIN SEG_Venta ven ON ven.consecutivo = arcEntCan.numeroCertificadoSeguro

-- cancelar la poliza y sus cobros pendientes

UPDATE vent
SET vent.codigoEstadoPoliza = CASE WHEN tipoNovedad = @codigoTipoNovedadCancelacion THEN @EstadoCancelado ELSE @EstadoAnulado END
FROM SEG_Venta vent 
INNER JOIN @archivoEntrada pm ON vent.idVenta=pm.idVenta

--Se cancelan los recobros de las pólizas canceladas en la taba Seg_Recobro

UPDATE sr
SET sr.activo=0,
	sr.idEstadoCobro= CASE WHEN tipoNovedad = @codigoTipoNovedadCancelacion THEN @EstadoCobroCancelado ELSE @EstadoCobroAnulado END 
FROM SEG_Recobro sr  
INNER JOIN @archivoEntrada pm ON sr.consecutivoPoliza=pm.numeroCertificado
WHERE PM.idventa > 0

--Se registra la novedad de cancelación

INSERT INTO SEG_DetalleNovedadPoliza
			(
				idVenta,
				fechaNovedad,
				fechaUltimoPeriodoPago,
				idCausalNovedad
			)			
SELECT pm.idventa,pm.fechaNovedad,NULL,pm.idCausalNovedad FROM @archivoEntrada pm
where pm.idventa > 0

--Se inserta para generar el archivo de salida

TRUNCATE TABLE SEG_ArchivoSalidaCancelacionPolizas

INSERT INTO SEG_ArchivoSalidaCancelacionPolizas(codigoProducto,numeroCertificadoSeguro,fechaNovedad,causalNovedad,tipoNovedad,ResultadoProcesamiento)
SELECT pol.codigoproducto,pol.numeroCertificado, FORMAT(pol.fechaNovedad, 'yyyyMMdd'), pol.causalNovedad, pol.tipoNovedad, pol.resultado
FROM @archivoEntrada pol 
END