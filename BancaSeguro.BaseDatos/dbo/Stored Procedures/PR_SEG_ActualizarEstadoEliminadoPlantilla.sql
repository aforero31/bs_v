/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-Sprint 3/HU032
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Sp para actualizar el estado eliminado de una plantilla
FECHA DE MODIFICACIÓN: 14/03/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ActualizarEstadoEliminadoPlantilla]
(@idDocumentoPoliza INT,
 @Eliminado BIT)

AS

BEGIN
	
	UPDATE SEG_DocumentoPoliza
	SET eliminado = @Eliminado
	WHERE idDocumentoPoliza = @idDocumentoPoliza

END