/********************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU006
AUTOR: Jetlhen Roa
EMPRESA: Unión temporal FS-BAC-2013.
OBJETIVO: Procedimiento que almacena información en la tabla SEG_LogControlProcedimiento
FECHA CREACIÓN: 26/03/2016
----------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
********************************************************************************************************************/

CREATE PROCEDURE  [dbo].[PR_SEG_LogControlErrores] 
@nombreProcedimiento varchar(100), 
@nombreControl varchar(200), 
@mensaje varchar(400)
AS
BEGIN

	    INSERT INTO [dbo].[SEG_LogControlProcedimiento] (nombreProcedimiento, nombreControl, mensaje)
		VALUES (@nombreProcedimiento, @nombreControl, @mensaje);
END