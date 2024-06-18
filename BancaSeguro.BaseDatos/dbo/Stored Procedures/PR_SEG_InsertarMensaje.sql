/****************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485-Banca Seguros Parametrizar Mensajes
DESCRIPCIÒN:   Procedimiento que Inserta en la tabla SEG_Mensaje
AUTOR: Paulo Andrés Mora.
EMPRESA: UT - BAC
FECHA DE CREACIÓN: 2016-06-01
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarMensaje] 
	-- Add the parameters for the stored procedure here
	@Llave			varchar(50),
	@idTipoMensaje	int,
	@idEvento	int,
	@Mensaje		varchar(max),
	@vP_UserName varchar(128), --para auditoria
	@existe			bit OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	declare @ik_TableName varchar(128) = 'SEG_Mensaje'
	SET NOCOUNT ON;
	SET @existe = 0;
	IF NOT EXISTS(SELECT * FROM SEG_Mensaje WHERE Llave = '@Llave')
		BEGIN
			INSERT INTO SEG_Mensaje
				   ([Llave]
				   ,[idEvento]
				   ,[idTipoMensaje]
				   ,[Mensaje])
			 VALUES
				   (@Llave
				   ,@idEvento
				   ,@idTipoMensaje
				   ,@Mensaje)

			declare @idMensaje int = scope_identity()
				select * into #del_SEG_Mensaje from SEG_Mensaje WHERE idMensaje = @idMensaje  -- para auditoria
				select * into #ins_SEG_Mensaje from SEG_Mensaje WHERE idMensaje = null  -- para auditoria
				exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_Mensaje, #ins_SEG_Mensaje, @vP_UserName --para auditoria
				drop table #ins_SEG_Mensaje --para auditoria
				drop table #del_SEG_Mensaje; --para auditoria
		END
    ELSE
		BEGIN
			SET @existe = 1; 
		END 
END