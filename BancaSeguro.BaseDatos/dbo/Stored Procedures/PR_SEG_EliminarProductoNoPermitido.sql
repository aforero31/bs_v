/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para eliminar un producto no permitido por seguro
FECHA DE MODIFICACIÓN: 03/05/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_EliminarProductoNoPermitido]
(@idSeguro INT
,@codigoProducto VARCHAR(50)
,@codigoSubProducto VARCHAR(50)
,@codigoCategoria VARCHAR(50))

AS

BEGIN
	DELETE FROM [dbo].[SEG_ProductoNoPermitido]
	WHERE [idSeguro] = @idSeguro
	  AND [codigoProducto] = @codigoProducto
	  AND [codigoSubProducto] = @codigoSubProducto
	  AND [codigoCategoria] = @codigoCategoria
END