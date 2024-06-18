/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-Sprint 3/HU032
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Sp para consultar las polizas creadas por un documento de poliza
FECHA DE CREACIÓN: 23/03/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ObtenerPolizasCreadasPorIdDocumentoPoliza]
(@idDocumentoPoliza INT)

AS
BEGIN 
	SELECT	idImpresionPoliza, 
			datosPolizaXML, 
			idDocumentoPoliza, 
			fechaImpresion, 
			consecutivoPoliza
	FROM SEG_ImpresionesPoliza
	WHERE idDocumentoPoliza = @idDocumentoPoliza
END