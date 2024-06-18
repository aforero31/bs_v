/****************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485-HU0024 - Administracion Control Dual
DESCRIPCIÓN: Actualiza un registro de administracion de control dual 
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
CREATE PROCEDURE [dbo].[PR_SEG_ActualizarAdmonControlDual] 
	@idControlDual int,
	@idMenu int,
	@idRol int,
	@requiere bit,
	@autoriza bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @control int 

	select  @control = isnull(count([id_Menu]),0)
	from [BANCASEGUROS].[dbo].[SEG_AdministracionControlDual] 
	where  [id_Menu] = @idMenu
	and [id_Rol] = @idRol

	if @control > 0
	BEGIN
    -- Insert statements for procedure here
	UPDATE [BANCASEGUROS].[dbo].[SEG_AdministracionControlDual]
	SET [id_Menu] = @idMenu
	   ,[id_Rol] = @idRol
	   ,[Requiere] = @requiere
	   ,[Autoriza] = @autoriza
	WHERE [idControlDual] = @idControlDual
	END
	ELSE
	BEGIN
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
	 END

END