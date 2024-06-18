/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU009-Parametrizar Variables Venta 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO : Consulta Variable Venta 
FECHA DE CREACIÓN: 2016-07-06
---------------------------------------------------------------------------------------------------------------
*************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_ConsultarVariableVenta] 
	-- Add the parameters for the stored procedure here
	@idVariableVenta int,
	@idVenta int,
    @idVariableProducto int,
    @valor varchar(200),
    @Consecutivo varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
	   VV.idVariableVenta
      ,VV.idVenta
      ,VV.idVariableProducto
      ,VP.orden
      ,VV.valor
      ,CASE WHEN VP.idMaestra IS NOT NULL THEN
       cast(1 as bit)
      ELSE
       cast(0 as bit)
       END AS valorMaestra
      ,CASE WHEN VP.idMaestra IS NOT NULL THEN
      (SELECT valor from SEG_ItemMaestra WHERE idMaestra = VP.idMaestra AND codigo= VV.valor)
      ELSE
       VV.valor 
       END AS nombre
    FROM SEG_VariableVenta	VV INNER JOIN 
         SEG_VariableProducto VP ON VV.idVariableProducto = VP.idVariableProducto INNER JOIN
         SEG_Venta V ON VV.idVenta = V.idVenta 
    WHERE 
    (VV.idVariableVenta = @idVariableVenta OR @idVariableVenta IS NULL) AND
    (VV.idVenta = @idVenta OR @idVenta IS NULL) AND
    (VV.idVariableProducto = @idVariableProducto OR @idVariableProducto IS NULL) AND
    (VV.valor = @valor OR @valor IS NULL) AND
    (V.consecutivo = @Consecutivo OR @Consecutivo IS NULL)
END