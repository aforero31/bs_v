/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-BancaSeguros HU022-ParametrizarCausalNovedad 
AUTOR: Andrés Combariza.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Consulta Novedades 
FECHA DE CREACIÓN: 2016-05-26
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarCausalNovedad] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT [idCausalNovedad]
	--	  ,[nombreNovedad]
	--	  ,[idTipoNovedad]
	--	  ,[codigoCausalNovedadNegocio]
	--	  ,[activo]
	--FROM [dbo].[SEG_CausalNovedad]

	SELECT CN.idCausalNovedad
		  ,CN.nombreNovedad
		  ,CN.idTipoNovedad
		  ,TN.nombreTipoNovedad
		  ,CN.codigoCausalNovedadNegocio
		  ,CN.activo
	FROM [dbo].[SEG_CausalNovedad] CN
	INNER JOIN [dbo].[SEG_TipoNovedad] TN
	ON TN.idTipoNovedad = CN.idTipoNovedad

END