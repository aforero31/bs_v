/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 03/05/2016
PROPOSITO: Procedimiento para ingresar un nuevo plan
---------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agrega validacion cuando no tiene items la tabla
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 19/08/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ActualizarProductosNoPermitidosPorId]
@tablaProductos TipoProductoNoPermitido READONLY,
@idSeguro INT = NULL,
@vP_UserName VARCHAR(128) = '' 
AS
BEGIN

	WITH ProductosNoPermitidos AS
	(
	SELECT spnp.idSeguro, spnp.codigoProducto, spnp.codigoSubProducto, spnp.codigoCategoria
	FROM dbo.SEG_ProductoNoPermitido spnp
	WHERE spnp.idSeguro = @idSeguro
	)
	MERGE ProductosNoPermitidos AS T
	USING @tablaProductos AS S
	ON (T.idSeguro = S.IdSeguro AND T.codigoProducto = S.CodigoProducto AND T.codigoSubProducto = S.CodigoSubProducto AND T.codigoCategoria = S.CodigoCategoria) 
	WHEN NOT MATCHED BY TARGET 
		THEN INSERT (	idSeguro
						,codigoProducto
						,codigoSubProducto
						,codigoCategoria)
				VALUES	(S.IdSeguro
						,S.CodigoProducto
						,S.CodigoSubProducto
						,S.CodigoCategoria)
	WHEN NOT MATCHED BY SOURCE AND T.idSeguro = @idSeguro
		THEN DELETE 

	OUTPUT $action AS accion , inserted.*, deleted.*;

END