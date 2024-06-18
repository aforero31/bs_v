/**************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Este procedimiento consulta PR_SEG_ConsultarProductosNoPermitidosPorSeguro
FECHA DE CREACIÓN: 17/02/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agregan id de producto subproductos y categorias
REQUERIMIENTO: SD1588485 - HU018 Consultar Editar Producto
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 17/06/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarProductosNoPermitidosPorSeguro]

	@idSeguro INT = NULL 

	AS
    BEGIN
        SELECT	spnp.idSeguro,
				sp.codigo AS codigoProducto,
				sp.idProductos,
				ssp.codigo AS codigoSubproducto,
				ssp.idSubProductos,
				sc.codigo AS codigoCategoria,
				sc.idCategoria
				
        FROM	dbo.SEG_ProductoNoPermitido spnp INNER JOIN 
				dbo.SEG_Productos sp ON sp.codigo = spnp.codigoProducto INNER JOIN 
				dbo.SEG_SubProductos ssp ON ssp.codigo = spnp.codigoSubProducto INNER JOIN 
				dbo.SEG_Categorias sc ON sc.codigo = spnp.codigoCategoria
				
		WHERE	idSeguro = @idSeguro

  	END