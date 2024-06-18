/* *************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: Wilver Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Este procedimiento obtiene todas las opciones de menu
FECHA DE CREACIÓN: 08/01/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarMenu]
AS
BEGIN
    SELECT	idMenu,
			Nombre,
			Posicion,
			idPadre,
			Activo,
			URL
	FROM	SEG_Menu
	WHERE	Activo = 1
	ORDER BY	IdPadre,Posicion
END

