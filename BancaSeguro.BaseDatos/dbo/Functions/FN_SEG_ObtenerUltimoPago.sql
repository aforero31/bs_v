
CREATE FUNCTION [dbo].[FN_SEG_ObtenerUltimoPago]
(
	@idVenta INT
)
RETURNS DATE
AS
/***************************************************************************************************************************************************
NOMBRE DEL PROGRAMA: [FN_SEG_ObtenerUltimoPago]
DESCRIPCION: Retorna la fecha del último pago realizado a una venta
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE CREACIÓN: 28/07/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: 
REQUERIMIENTO: 
AUTOR: 
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN:
**************************************************************************************************************/
BEGIN
	DECLARE @fechaNovedad DATE = NULL
	SET @fechaNovedad = (SELECT TOP 1 SDNP.fechaNovedad
				FROM SEG_DetalleNovedadPoliza SDNP
				INNER JOIN SEG_CausalNovedad SCN ON SCN.idCausalNovedad = SDNP.idCausalNovedad 
				INNER JOIN SEG_TipoNovedad STN ON STN.idTipoNovedad = SCN.idTipoNovedad
				AND STN.codigoTipoNovedad IN (3) AND SDNP.idVenta = @idVenta
				ORDER BY SDNP.fechaNovedad DESC)
	RETURN @fechaNovedad
END