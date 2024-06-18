/***************************************************************************************************************
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para consultar Informacion para la Reimpresion
FECHA DE MODIFICACIÓN: 09/02/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agregan campos de informacion de la plantilla
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 12/04/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarInformacionReimpresion]
	@Consecutivo VARCHAR(50)
AS

BEGIN
	SELECT	datosPolizaXML,
			SI.idDocumentoPoliza,
			NULL AS IdSeguro,
			SDP.plantilla AS Plantilla,
			camposPlantilla,
			SDP.nombreArchivo,
			SDP.versionDocumento
	FROM	SEG_ImpresionesPoliza  SI INNER JOIN 
			SEG_DocumentoPoliza SDP ON SDP.idDocumentoPoliza = SI.idDocumentoPoliza
	WHERE	consecutivoPoliza = @Consecutivo
END