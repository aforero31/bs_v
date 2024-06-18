/****************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485 - HU0024 - Administracion Control Dual
DESCRIPCIÓN: Inserta un registro de administracion de control dual 
AUTOR: Andrés Combariza
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE CREACIÓN: 2016-06-14
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarAdmonControlDual] 
	-- Add the parameters for the stored procedure here
	@idMenu int,
	@idRol int,
	@requiere bit,
	@autoriza bit,
	@existe bit output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @existe = 0;
	IF  NOT EXISTS(SELECT * FROM SEG_AdministracionControlDual WHERE id_Menu = @idMenu and id_Rol = @idRol)	
    -- Insert statements for procedure here
		INSERT INTO [BANCASEGUROS].[dbo].[SEG_AdministracionControlDual]
			   ([id_Menu]
			   ,[id_Rol]
			   ,[Requiere]
			   ,[Autoriza])
		 VALUES
			   (@idMenu
			   ,@idRol
			   ,@requiere
			   ,@autoriza)
	ELSE 
	set @existe = 1
END