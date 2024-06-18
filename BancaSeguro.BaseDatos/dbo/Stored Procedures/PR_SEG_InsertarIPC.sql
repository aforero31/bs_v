/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-BancaSeguros HU019-ParametrizarIPC 
AUTOR: Andrés Combariza.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Inserta IPC 
FECHA DE CREACIÓN: 2016-05-17
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarIPC] 
	-- Add the parameters for the stored procedure here
	@añoIPC int,
    @valorIPC decimal(18,2),
	@vP_UserName varchar(128) --para auditoria
	--@existe bit OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	declare @ik_TableName varchar(128) = 'SEG_IncrementoIPC'
	SET NOCOUNT ON;

	--SET @existe = 0
    -- Insert statements for procedure here
	IF NOT EXISTS(SELECT * FROM SEG_IncrementoIPC WHERE ano =  @añoIPC)
	INSERT INTO [dbo].[SEG_IncrementoIPC]
           ([ano]
		   ,[ipc])
     VALUES
           (@añoIPC
		   ,@valorIPC)

	declare @idIPC int = scope_identity()
		select * into #del_SEG_IncrementoIPC from SEG_IncrementoIPC WHERE idIPC = @idIPC  -- para auditoria
		select * into #ins_SEG_IncrementoIPC from SEG_IncrementoIPC WHERE idIPC = null  -- para auditoria
		exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_IncrementoIPC, #ins_SEG_IncrementoIPC, @vP_UserName --para auditoria
		drop table #ins_SEG_IncrementoIPC --para auditoria
		drop table #del_SEG_IncrementoIPC; --para auditoria
	--ELSE
	--SET @existe = 1

END