/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU009-Parametrizar Variables Venta 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO : Consulta Item Maestra 
FECHA DE CREACIÓN: 2016-07-07
---------------------------------------------------------------------------------------------------------------
*************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarItemMaestra] 
	-- Add the parameters for the stored procedure here
	@idMaestra int,
	@codigo nvarchar(50),
    @valor varchar(100),
    @activo bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
	   [idMaestra]
      ,[codigo]
      ,[valor]
      ,[activo]
    FROM SEG_ItemMaestra
    WHERE 
    (idMaestra = @idMaestra OR @idMaestra IS NULL) AND
    (codigo = @codigo OR @codigo IS NULL) AND
    (valor = @valor OR @valor IS NULL) AND
    (activo = @activo OR @activo IS NULL)
END