/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 24/08/2016
PROPOSITO: Procedimiento para sincronizar los Subproductos
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_SincronizarSubProductos]
@datos TipoSubProductos READONLY 
AS
BEGIN
	delete from [dbo].[SEG_ProductoSubProducto]
	
	MERGE SEG_SubProductos AS T
	USING @datos AS S
	ON (T.codigo = S.Codigo AND T.IdProducto=S.idProducto) 
	WHEN NOT MATCHED BY TARGET 
		THEN INSERT		(codigo
						,nombre
						,activo
						,IdProducto)
				VALUES	(S.Codigo
						,S.Nombre
						,S.Activo
						,S.idProducto)
	WHEN MATCHED
		THEN UPDATE SET T.codigo = S.Codigo
						,T.nombre = S.Nombre
						,T.activo = S.Activo
	WHEN NOT MATCHED BY SOURCE
		THEN UPDATE SET  T.activo = 0					
	--WHEN NOT MATCHED BY SOURCE
	--	THEN DELETE 

	OUTPUT $action AS accion , inserted.*;--, deleted.*;

	insert into SEG_ProductoSubProducto (codigoProducto,idSubProducto) 	
	select S.IdProducto,S.idSubProductos from SEG_SubProductos AS S 	
END