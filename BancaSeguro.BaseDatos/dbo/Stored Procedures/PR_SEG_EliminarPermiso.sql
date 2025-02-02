--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.[PR_SEG_EliminarPermiso]') AND type in ('P', 'PC'))
--	exec('DROP PROCEDURE dbo.[PR_SEG_EliminarPermiso]')
--GO
CREATE PROCEDURE [dbo].[PR_SEG_EliminarPermiso]
	-- Add the parameters for the stored procedure here
	@idMenu int,
    @idRol int,
	@vP_UserName varchar(128) --para auditoria
AS
/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-Banca Seguros SD1588485 HU020-AdministrarRol 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Elimina Permiso 
FECHA DE CREACIÓN: 2016-04-25
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: 
REQUERIMIENTO: SD4350236
PROPOSITO: Crear Auditoria al eliminar registros de tabla SEG_Permisos
AUTOR: Elvia Argenis Mora Forigua
EMPRESA: Intergrupo SAS
FECHA DE MODIFICACIÓN: 2020-04-30
****************************************************************************************************************/
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	declare @ik_TableName varchar(128) = 'SEG_Permisos'

	select * into #del_SEG_Rol from SEG_Permisos 
	WHERE (idRol = @idRol) AND
    (idMenu = @idMenu OR @idMenu IS NULL)  -- para auditoria
    DELETE FROM dbo.SEG_Permisos 
    WHERE 
    (idRol = @idRol) AND
    (idMenu = @idMenu OR @idMenu IS NULL);
	select * into #ins_SEG_Rol from SEG_Permisos WHERE idRol = null AND idMenu =  null -- para auditoria
	exec PR_SEG_Auditoria @ik_TableName,'D',#ins_SEG_Rol, #del_SEG_Rol, @vP_UserName --para auditoria
	drop table #ins_SEG_Rol --para auditoria
	drop table #del_SEG_Rol; --para auditoria 
END



