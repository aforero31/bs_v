/* *************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: Wilver Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Este procedimiento obtiene todas las opciones de menu por un rol
FECHA DE CREACIÓN: 08/01/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarMenuPorRol]
	@idRol INT = NULL
AS
BEGIN
    SELECT	SM.idMenu,
			Nombre,
			Posicion,
			idPadre,
			SM.Activo,
			URL
	FROM	SEG_Menu SM INNER JOIN 
			SEG_Permisos SP ON SP.idMenu = SM.idMenu
	WHERE	SM.Activo = 1 AND
			SP.idRol = @idRol
	ORDER BY	SM.IdMenu,IdPadre,Posicion
END