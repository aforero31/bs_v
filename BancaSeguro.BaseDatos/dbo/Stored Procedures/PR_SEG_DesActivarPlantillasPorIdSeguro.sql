
/* *************************************************************************************************************        
CREACION
REQUERIMIENTO: SD1588485 - Seleccion Plantilla
AUTOR: INTERGRUPO/wzaldua	
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE CREACION: 24/08/2016
PROPOSITO: Procedimiento para desactivar todos las plantillas asociadas a un seguro
***************************************************************************************************************/ 
CREATE PROCEDURE [dbo].[PR_SEG_DesActivarPlantillasPorIdSeguro]
	@idSeguro INT
AS

BEGIN
	UPDATE dbo.SEG_DocumentoPoliza
	SET
	    dbo.SEG_DocumentoPoliza.activa = 0 -- bit
	WHERE dbo.SEG_DocumentoPoliza.idSeguro = @idSeguro

END