/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 24/08/2016
PROPOSITO: Procedimiento para sincronizar las Categorias
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_SincronizarCategorias]
@datos TipoCategorias READONLY 
AS
BEGIN
	Delete from SEG_SubProductosCategorias

	MERGE SEG_Categorias AS T
	USING @datos AS S
	ON (T.codigo = S.Codigo AND T.idProducto=S.IdProducto) 
	WHEN NOT MATCHED BY TARGET 
		THEN INSERT		(codigo
						,nombre
						,activo
						,idProducto)
				VALUES	(S.Codigo
						,S.Nombre
						,S.Activo
						,S.IdProducto)
	WHEN MATCHED
		THEN UPDATE SET T.codigo = S.Codigo
						,T.nombre = S.Nombre
						,T.activo = S.Activo
						,T.idProducto = S.IdProducto
	WHEN NOT MATCHED BY SOURCE
		THEN UPDATE SET  T.activo = 0	
	--WHEN NOT MATCHED BY SOURCE
	--	THEN DELETE 

	OUTPUT $action AS accion , inserted.*;--, deleted.*;

	
	insert into SEG_SubProductosCategorias (idCategoria,idSubProductos)
	select t3.idCategoria,t2.idSubProducto from SEG_SubProductos t1
	inner join SEG_ProductoSubProducto t2 on t1.idSubProductos = t2.idSubProducto
	inner join SEG_Categorias t3 on t3.IdProducto = t2.codigoProducto
	where t2.codigoProducto in (3,4)
END