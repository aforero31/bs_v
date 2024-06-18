/* *************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: Andres Combariza
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Este procedimiento obtiene todas las opciones de menu para llenar combo en administracion de control dual
FECHA DE CREACIÓN: 10/06/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarMenuParaControlDual]
AS
BEGIN
    SELECT	SM.idMenu,
			Nombre
	FROM	SEG_Menu SM 
	WHERE	SM.controlDual = 1 
	
END