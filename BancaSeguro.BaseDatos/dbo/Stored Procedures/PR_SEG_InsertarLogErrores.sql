/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU030 - Parametrización de Mensajes
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Inserta Errores capturados en la aplicacion
FECHA DE MODIFICACIÓN: 01/06/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarLogErrores] 
	@Error varchar(max)
AS
BEGIN
	DECLARE @ID AS BIGINT

	INSERT INTO [dbo].[SEG_LogErrores]
	([Error]
	,[Fecha])
	VALUES
	(@Error
	,GETDATE())
	
	SET @ID = SCOPE_IDENTITY()
	SELECT @ID 
END