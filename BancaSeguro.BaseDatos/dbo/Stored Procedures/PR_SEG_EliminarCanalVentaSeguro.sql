/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para eliminar un canal de venta asociado a un seguro
FECHA DE MODIFICACIÓN: 04/05/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_EliminarCanalVentaSeguro]
(@idSeguro INT
,@idCanalVenta INT)

AS

BEGIN
	DELETE FROM [dbo].[SEG_CanalVentaSeguro]	
	WHERE [idSeguro] = @idSeguro
	  AND [idCanalVenta]= @idCanalVenta
END