/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-BancaSeguros HU027-ParametrizarNovedad
AUTOR: Andrés Combariza.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Inserta Novedad 
FECHA DE CREACIÓN: 2016-05-23
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarTipoNovedad] 
	-- Add the parameters for the stored procedure here
	@codTipoNovedad int,
    @nombreTipoNovedad varchar(50),
	@estadoTipoNovedad bit,
	@vP_UserName varchar(128), --para auditoria
	@existe bit OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	declare @ik_TableName varchar(128) = 'SEG_TipoNovedad'
	SET NOCOUNT ON;
	SET @existe = 0
    -- Insert statements for procedure here
	IF NOT EXISTS(select * from [dbo].[SEG_TipoNovedad] where nombreTipoNovedad like '%' + @nombreTipoNovedad + '%' OR codigoTipoNovedad = @codTipoNovedad)
	BEGIN
	INSERT INTO [dbo].[SEG_TipoNovedad]
           ([codigoTipoNovedad]
		   ,[nombreTipoNovedad]
		   ,[activo])
     VALUES
           (@codTipoNovedad
		   ,@nombreTipoNovedad
		   ,@estadoTipoNovedad)

	declare @idTipoNovedad int = scope_identity()
		select * into #del_SEG_TipoNovedad from SEG_TipoNovedad WHERE idTipoNovedad = @idTipoNovedad  -- para auditoria
		select * into #ins_SEG_TipoNovedad from SEG_TipoNovedad WHERE idTipoNovedad = null  -- para auditoria
		exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_TipoNovedad, #ins_SEG_TipoNovedad, @vP_UserName --para auditoria
		drop table #ins_SEG_TipoNovedad --para auditoria
		drop table #del_SEG_TipoNovedad; --para auditoria
	END
	ELSE
	SET @existe = 1
END