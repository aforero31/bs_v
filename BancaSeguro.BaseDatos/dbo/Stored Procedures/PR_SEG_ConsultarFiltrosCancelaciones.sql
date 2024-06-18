/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - BancaSeguros HU023-ParametrizacionArchivosPlanos 
AUTOR: Andrés Combariza.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Consulta Novedades 
FECHA DE CREACIÓN: 2016-07-13
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarFiltrosCancelaciones] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [nombreNovedad] as CAMPOS, [idCausalNovedad]
	FROM [BANCASEGUROS].[dbo].[SEG_CausalNovedad]
	where [idTipoNovedad] IN (1,2) and [activo] = 1

END