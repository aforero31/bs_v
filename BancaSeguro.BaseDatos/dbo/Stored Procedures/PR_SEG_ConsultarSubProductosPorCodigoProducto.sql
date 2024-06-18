/*****************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para consultar los sub productos de un subproducto
FECHA DE MODIFICACIÓN: 19/04/2016
*****************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarSubProductosPorCodigoProducto]
(@CodigoProducto INT)

AS

BEGIN

	SELECT	   SEG_SubProductos.idSubProductos
			  ,SEG_SubProductos.codigo
			  ,SEG_SubProductos.nombre
			  ,SEG_SubProductos.activo
	FROM SEG_SubProductos
	INNER JOIN SEG_ProductoSubProducto
	ON idSubProducto = idSubProductos
	WHERE SEG_SubProductos.activo = 1
	AND codigoProducto = @CodigoProducto

END