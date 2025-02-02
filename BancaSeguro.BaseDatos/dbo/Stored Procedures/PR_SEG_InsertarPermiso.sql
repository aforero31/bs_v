--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.[PR_SEG_InsertarPermiso]') AND type in ('P', 'PC'))
--	exec('DROP PROCEDURE dbo.[PR_SEG_InsertarPermiso]')
--GO
CREATE PROCEDURE [dbo].[PR_SEG_InsertarPermiso]
	-- Add the parameters for the stored procedure here
	@idMenu int,
    @idRol int,
    @activo bit,
	@vP_UserName varchar(128) --para auditoria
AS
/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-Banca Seguros SD1588485 HU020-AdministrarRol 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Inserta Permiso 
FECHA DE CREACIÓN: 2016-04-25
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: 
REQUERIMIENTO: SD4350236
PROPOSITO: Crear Auditoria al eliminar registros de tabla SEG_RolGrupoBAC
AUTOR: Elvia Argenis Mora Forigua
EMPRESA: Intergrupo SAS
FECHA DE MODIFICACIÓN: 2020-04-16
****************************************************************************************************************/

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    declare @ik_TableName varchar(128) = 'SEG_Permisos'
    -- Insert statements for procedure here
	INSERT INTO [dbo].[SEG_Permisos]
           ([idMenu]
           ,[idRol]
           ,[activo])
     VALUES
           (@idMenu
           ,@idRol 
           ,@activo)
      select * into #ins_SEG_Permisos from SEG_Permisos WHERE idMenu = @idMenu and idRol = @idRol  -- para auditoria
	select * into #del_SEG_Permisos from SEG_Permisos WHERE idMenu = null and idRol = Null -- para auditoria
	exec PR_SEG_Auditoria @ik_TableName,'I',#ins_SEG_Permisos, #del_SEG_Permisos, @vP_UserName --para auditoria
	drop table #ins_SEG_Permisos --para auditoria
	drop table #del_SEG_Permisos; --para auditoria 
END


