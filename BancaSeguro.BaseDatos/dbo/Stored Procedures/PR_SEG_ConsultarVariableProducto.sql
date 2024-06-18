/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU009-Parametrizar Variables Venta 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO : Consulta Variable Producto 
FECHA DE CREACIÓN: 2016-07-06
---------------------------------------------------------------------------------------------------------------
*************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_ConsultarVariableProducto] 
	-- Add the parameters for the stored procedure here
	@idVariableProducto int = NULL,
	@idSeguro int,
    @nombreCampo varchar(50)= NULL,
    @idTipoDato int= NULL,
    @longitud int= NULL,
    @idMaestra int= NULL,
    @orden int = NULL,
    @estado bit= NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
	   [idVariableProducto]
      ,[idSeguro]
      ,[nombreCampo]
      ,[idTipoDato]
      ,[longitud]
      ,[idMaestra]
      ,[orden]
      ,[estado]
    FROM SEG_VariableProducto
    WHERE 
    (idVariableProducto = @idVariableProducto OR @idVariableProducto IS NULL) AND
    (idSeguro = @idSeguro OR @idSeguro IS NULL) AND
    (NombreCampo = @nombreCampo OR @nombreCampo IS NULL) AND
    (idTipoDato = @idTipoDato OR @idTipoDato IS NULL) AND
    (longitud =  @longitud OR @longitud IS NULL) AND
    (idMaestra = @idMaestra OR @idMaestra IS NULL) AND
    (orden = @orden OR @orden IS NULL) AND
    (estado = @estado OR @estado IS NULL)
END