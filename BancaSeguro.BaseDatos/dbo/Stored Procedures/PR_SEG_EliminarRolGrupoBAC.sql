--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.[PR_SEG_EliminarRolGrupoBAC]') AND type in ('P', 'PC'))
--	exec('DROP PROCEDURE dbo.[PR_SEG_EliminarRolGrupoBAC]')
--GO
CREATE PROCEDURE [dbo].[PR_SEG_EliminarRolGrupoBAC]
	-- Add the parameters for the stored procedure here
	@idRol int,
	@idGrupo int,
	@vP_UserName varchar(128) --para auditoria
AS
/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-HU020-AdministrarRol
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Inserta relacion Rol GrupoBAC 
FECHA DE CREACIÓN: 2016-04-27
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: 
REQUERIMIENTO: SD4350236
PROPOSITO: Crear Auditoria al eliminar registros de tabla SEG_RolGrupoBAC
AUTOR: Elvia Argenis Mora Forigua
EMPRESA: Intergrupo SAS
FECHA DE MODIFICACIÓN: 2020-04-30
****************************************************************************************************************/
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Insert statements for procedure here
	declare @ik_TableName varchar(128) = 'SEG_RolGrupoBAC'

	select * into #del_SEG_RolGrupoBAC from SEG_RolGrupoBAC 
	WHERE(idRol = @idRol) AND
	      (idGrupo = @idGrupo OR @idGrupo IS NULL) -- para auditoria
	
	DELETE FROM dbo.SEG_RolGrupoBAC
	WHERE (idRol = @idRol) AND
	      (idGrupo = @idGrupo OR @idGrupo IS NULL)
		  				     
	select * into #ins_SEG_RolGrupoBAC from SEG_RolGrupoBAC WHERE idRol = null AND idGrupo = null -- para auditoria
	exec PR_SEG_Auditoria @ik_TableName,'D',#ins_SEG_RolGrupoBAC, #del_SEG_RolGrupoBAC, @vP_UserName --para auditoria
	drop table #ins_SEG_RolGrupoBAC --para auditoria
	drop table #del_SEG_RolGrupoBAC; --para auditoria    
END
