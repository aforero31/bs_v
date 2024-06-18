/* *************************************************************************************************************************************************
CREACIÓN
REQUERIMIENTO: HU034
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: UT - BAC
OBJETIVO: Selecciona el rol por abreviatura y grupo del directorio activo
FECHA DE CREACIÓN: 03/15/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se eliminar consulta a campo esAutorizador de tabla SEG_Rol
REQUERIMIENTO: SD1588485-HU020
AUTOR: Paulo Mora
EMPRESA: UT - BAC
FECHA DE MODIFICACIÓN: 2016-04-26
**************************************************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarRolPorGrupo]
	@codigoGrupo VARCHAR(10) = NULL,
	@nombreGrupo VARCHAR(50) = NULL

AS
	BEGIN
		SELECT	SR.idRol,
				SR.nombre,
				SR.activo
		FROM	SEG_Rol SR INNER JOIN 
				SEG_RolGrupoBAC SRG ON SRG.idRol = SR.idRol INNER JOIN 
				SEG_GrupoBAC SGB ON SGB.idGrupo = SRG.idGrupo
		WHERE	SGB.codigoGrupo = @codigoGrupo AND
				SGB.nombreGrupo = @nombreGrupo AND
				SR.activo = 1 AND
				SRG.activo = 1 AND 
				SGB.activo = 1
	END