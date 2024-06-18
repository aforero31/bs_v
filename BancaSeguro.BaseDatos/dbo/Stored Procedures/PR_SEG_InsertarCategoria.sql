/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para insertar un nuevo sub - producto
FECHA DE MODIFICACIÓN: 18/04/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarCategoria]
(@codigo VARCHAR(2)
,@nombre VARCHAR(80)
,@activo BIT)

AS

BEGIN


INSERT INTO [dbo].[SEG_Categorias] (codigo, 
									nombre, 
									activo)
							VALUES (@codigo,
									@nombre,
									@activo)
END