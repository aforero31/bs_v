/*****************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Consulta los productos bancarios
FECHA DE MODIFICACIÓN: 06/05/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
*****************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarProductosBancariosActivos]
AS

BEGIN
	SELECT  idProductos,
			codigo,
			nombre,
			activo,
			CodigoCardif
	FROM [dbo].[SEG_Productos]
	WHERE activo = 1
END