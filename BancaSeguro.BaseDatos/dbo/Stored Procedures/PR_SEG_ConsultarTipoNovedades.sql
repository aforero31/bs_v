/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-BancaSeguros  
AUTOR: Andrés Combariza.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Consulta Novedades 
FECHA DE CREACIÓN: 2016-05-24
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarTipoNovedades] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [idTipoNovedad], [codigoTipoNovedad], [nombreTipoNovedad], [activo] FROM [dbo].[SEG_TipoNovedad]

END