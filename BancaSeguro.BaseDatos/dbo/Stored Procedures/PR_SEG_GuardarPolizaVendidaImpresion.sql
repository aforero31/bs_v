/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO:	SD1588485-Sprint 3 / HU010
AUTOR: Wilver Guillermo Zaldua Espindola
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE CREACION: 19/03/2016
PROPOSITO: Guardar Poliza Vendida
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_GuardarPolizaVendidaImpresion]
	@PlantillaXML XML,
	@IdDocumentoPoliza INT,
	@Consecutivo VARCHAR(50)

AS

BEGIN
	INSERT dbo.SEG_ImpresionesPoliza
	(
	    --idImpresionPoliza - this column value is auto-generated
	    datosPolizaXML,
	    idDocumentoPoliza,
	    fechaImpresion,
	    consecutivoPoliza
	)
	VALUES
	(
	    -- idImpresionPoliza - int
	    @PlantillaXML, -- datosPolizaXML - xml
	    @IdDocumentoPoliza, -- idDocumentoPoliza - int
	    GETDATE(), -- fechaImpresion - datetime
	    @Consecutivo -- consecutivoPoliza - varchar
	)
END