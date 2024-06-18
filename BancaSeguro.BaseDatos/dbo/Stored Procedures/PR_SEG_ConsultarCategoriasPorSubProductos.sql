/*****************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para consultar las categorias por sub-Productos
FECHA DE MODIFICACIÓN: 19/04/2016
*****************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarCategoriasPorSubProductos]
(@idSubProducto INT)
AS
BEGIN
	SELECT	SEG_Categorias.idCategoria,
			SEG_Categorias.codigo,
			SEG_Categorias.nombre,
			SEG_Categorias.activo
	FROM [dbo].[SEG_Categorias]
	INNER JOIN SEG_SubProductosCategorias
	ON SEG_Categorias.idCategoria = SEG_SubProductosCategorias.idCategoria
	WHERE SEG_Categorias.activo = 1
	AND idSubProductos = @idSubProducto
END