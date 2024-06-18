/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-BancaSeguros HU022-ParametrizarCausalNovedad
AUTOR: Andrés Combariza.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Actualizar Causal Novedad 
FECHA DE CREACIÓN: 2016-05-26
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ActualizarCausalNovedad] 
	-- Add the parameters for the stored procedure here
	@idCausalNovedad int,
	@idTipoNovedad int,
	@codCausalNovedad int,
    @nombreCausalNovedad varchar(50),
	@estadoCausalNovedad bit,
	@vP_UserName varchar(128) --para auditoria
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	declare @ik_TableName varchar(128) = 'SEG_CausalNovedad'
	select * into #del_SEG_CausalNovedad from SEG_CausalNovedad WHERE [idCausalNovedad] = @idCausalNovedad
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	UPDATE [dbo].[SEG_CausalNovedad]
	SET [nombreNovedad] = @nombreCausalNovedad,
		[idTipoNovedad] = @idTipoNovedad,
		[codigoCausalNovedadNegocio] = @codCausalNovedad,
		[Fuente] = NULL,
		[descripcionCausalNovedadNegocio] = NULL,
		[activo] = @estadoCausalNovedad
	WHERE [idCausalNovedad] = @idCausalNovedad


			  -- para auditoria
		select * into #ins_SEG_CausalNovedad from SEG_CausalNovedad WHERE [idCausalNovedad] = @idCausalNovedad  -- para auditoria
		exec PR_SEG_Auditoria @ik_TableName,'U', #ins_SEG_CausalNovedad, #del_SEG_CausalNovedad,  @vP_UserName --para auditoria
		drop table #ins_SEG_CausalNovedad --para auditoria
		drop table #del_SEG_CausalNovedad; --para auditoria
END