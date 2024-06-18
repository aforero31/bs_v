/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para actualizar el estado activa de una plantilla
FECHA DE MODIFICACIÓN: 29/03/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ActualizarEstadoActivoPlantilla]
(@idDocumentoPoliza INT,
 @Activa BIT)

AS

DECLARE @IdSeguro INT

BEGIN

	SELECT @IdSeguro = idSeguro
	FROM SEG_DocumentoPoliza
	WHERE idDocumentoPoliza = @idDocumentoPoliza
	
	UPDATE SEG_DocumentoPoliza
	SET activa = 0
	where idSeguro = @IdSeguro

	UPDATE SEG_DocumentoPoliza
	SET activa = @Activa
	WHERE idDocumentoPoliza = @idDocumentoPoliza

END