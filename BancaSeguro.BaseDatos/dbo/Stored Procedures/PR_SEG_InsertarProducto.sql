/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para insertar un nuevo producto
FECHA DE MODIFICACIÓN: 18/04/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarProducto]
(@codigo INT
,@nombre VARCHAR(50)
,@activo BIT
,@CodigoCardif CHAR(2))

AS

BEGIN


INSERT INTO [dbo].[SEG_Productos] ( codigo, 
									nombre, 
									activo, 
									CodigoCardif)
							VALUES (@codigo,
									@nombre,
									@activo,
									@CodigoCardif)
END