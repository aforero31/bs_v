/* *************************************************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-HU020-AdministrarRol
AUTOR: Paulo Andres Mora
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Selecciona los grupos por el Rol
FECHA DE CREACIÓN: 2016-04-27
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
**************************************************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarGrupoPorRol]
	@idRol int
AS
	BEGIN
		SELECT	SGB.IdGRupo,
		        SGB.nombreGrupo,
		        SGB.codigoGrupo,
		        SGB.activo
		FROM	SEG_Rol SR INNER JOIN 
				SEG_RolGrupoBAC SRG ON SRG.idRol = SR.idRol INNER JOIN 
				SEG_GrupoBAC SGB ON SGB.idGrupo = SRG.idGrupo
		WHERE	SR.idRol = @idRol
				
	END