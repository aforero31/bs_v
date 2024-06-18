/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para eliminar un documento asociado a un seguro
FECHA DE MODIFICACIÓN: 03/05/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_EliminarSeguroTipoIdentificacion]
(@idSeguro INT,
 @idTipoIdentificacion INT)

AS

BEGIN
	IF EXISTS (SELECT idSeguro 
				   FROM SEG_SeguroTipoIdentificacion 
				   WHERE idSeguro = @idSeguro 
					 AND idTipoIdentificacion = @idTipoIdentificacion)
		BEGIN
			DELETE FROM SEG_SeguroTipoIdentificacion
			WHERE idSeguro = @idSeguro
			  AND idTipoIdentificacion = @idTipoIdentificacion
		END
END