/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para insertar un producto no permitido por seguro
FECHA DE MODIFICACIÓN: 03/05/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarProductoNoPermitido]
(@idSeguro INT
,@codigoProducto VARCHAR(50)
,@codigoSubProducto VARCHAR(50)
,@codigoCategoria VARCHAR(50)
,@vP_UserName VARCHAR(128))

AS

BEGIN
	INSERT INTO [dbo].[SEG_ProductoNoPermitido]  ([idSeguro]
												 ,[codigoProducto]
												 ,[codigoSubProducto]
												 ,[codigoCategoria])
	VALUES  (@idSeguro
			,@codigoProducto
			,@codigoSubProducto
			,@codigoCategoria)

	declare @ik_TableName varchar(128) = 'SEG_ProductoNoPermitido'
	declare @Producto int = 1
	select * into #del_SEG_ProductoNoPermitido from SEG_ProductoNoPermitido  WHERE dbo.SEG_ProductoNoPermitido.idSeguro = @idSeguro AND dbo.SEG_ProductoNoPermitido.codigoProducto = @codigoProducto AND dbo.SEG_ProductoNoPermitido.codigoSubProducto = @codigoSubProducto AND dbo.SEG_ProductoNoPermitido.codigoCategoria = @codigoCategoria
	select * into #ins_SEG_ProductoNoPermitido from SEG_ProductoNoPermitido  WHERE @Producto = null
	exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_ProductoNoPermitido, #ins_SEG_ProductoNoPermitido, @vP_UserName
	drop table #ins_SEG_ProductoNoPermitido 
	drop table #del_SEG_ProductoNoPermitido 
END