/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-BancaSeguros HU022-ParametrizarCausalNovedad
AUTOR: Andrés Combariza.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Inserta Causal Novedad 
FECHA DE CREACIÓN: 2016-05-26
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarCausalNovedad] 
	-- Add the parameters for the stored procedure here
	@idTipoNovedad int,
	@codCausalNovedad varchar(2),
    @nombreCausalNovedad varchar(50),
	@estadoCausalNovedad bit,
	@vP_UserName varchar(128), --para auditoria
	@existe bit OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	declare @ik_TableName varchar(128) = 'SEG_CausalNovedad'
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	IF NOT EXISTS(SELECT * FROM SEG_CausalNovedad WHERE nombreNovedad =  @nombreCausalNovedad AND idTipoNovedad = @idTipoNovedad AND codigoCausalNovedadNegocio = @codCausalNovedad )
	BEGIN

		SET @existe = 0

		INSERT INTO [dbo].[SEG_CausalNovedad]
			   ([nombreNovedad]
			   ,[idTipoNovedad]
			   ,[codigoCausalNovedadNegocio]
			   ,[Fuente]
			   ,[descripcionCausalNovedadNegocio]
			   ,[activo])
		 VALUES
			   (@nombreCausalNovedad
			   ,@idTipoNovedad
			   ,@codCausalNovedad
			   ,NULL
			   ,NULL
			   ,@estadoCausalNovedad)

		

		declare @idCausalNovedad int = scope_identity()
			select * into #del_SEG_CausalNovedad from SEG_CausalNovedad WHERE idCausalNovedad = @idCausalNovedad  -- para auditoria
			select * into #ins_SEG_CausalNovedad from SEG_CausalNovedad WHERE idCausalNovedad = null  -- para auditoria
			exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_CausalNovedad, #ins_SEG_CausalNovedad, @vP_UserName --para auditoria
			drop table #ins_SEG_CausalNovedad --para auditoria
			drop table #del_SEG_CausalNovedad; --para auditoria
	END
	ELSE
	SET @existe = 1
END