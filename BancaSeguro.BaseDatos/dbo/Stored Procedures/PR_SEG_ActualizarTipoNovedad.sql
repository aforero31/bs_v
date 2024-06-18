/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-BancaSeguros HU027-ParametrizarNovedad
AUTOR: Andrés Combariza.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Actualiza Novedad 
FECHA DE CREACIÓN: 2016-05-23
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ActualizarTipoNovedad] 
	-- Add the parameters for the stored procedure here
	@idTipoNovedad int,
	@codTipoNovedad int,
    @nombreTipoNovedad varchar(50),
	@estadoTipoNovedad bit,
	@vP_UserName varchar(128) --para auditoria
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	declare @ik_TableName varchar(128) = 'SEG_TipoNovedad'
	select * into #del_SEG_TipoNovedad from SEG_TipoNovedad WHERE [codigoTipoNovedad] = @codTipoNovedad
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	UPDATE [dbo].[SEG_TipoNovedad]
	SET [nombreTipoNovedad] = @nombreTipoNovedad,
		[activo] = @estadoTipoNovedad,
	    [codigoTipoNovedad] = @codTipoNovedad
	where [idTipoNovedad] = @idTipoNovedad


			  -- para auditoria
		select * into #ins_SEG_TipoNovedad from SEG_TipoNovedad WHERE [codigoTipoNovedad] = @codTipoNovedad  -- para auditoria
		exec PR_SEG_Auditoria @ik_TableName,'U',#ins_SEG_TipoNovedad, #del_SEG_TipoNovedad,  @vP_UserName --para auditoria
		drop table #ins_SEG_TipoNovedad --para auditoria
		drop table #del_SEG_TipoNovedad; --para auditoria
END