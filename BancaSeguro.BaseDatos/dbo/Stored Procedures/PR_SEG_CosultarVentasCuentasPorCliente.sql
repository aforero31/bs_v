/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU018 Parametrizacion Mensajes
AUTOR: INTERGRUPO\wzaldua
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Procedimiento que consultas las ventas vigentes por un cliente y las cuentas utilizadas en las ventas
FECHA DE MODIFICACIÓN: 18/07/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_CosultarVentasCuentasPorCliente] 
	@codigoTipoCuenta INT,-- = 4,
	@numeroCuenta VARCHAR(50),-- = '445070009211',
	@idTipoDeIdentificacion INT,-- = 1,
	@identificacion VARCHAR(16)-- = '474134'
AS
BEGIN
DECLARE
@ventasMismaCuenta int,
@cuentasCliente int

SET @ventasMismaCuenta = (
	SELECT	COUNT(sv.idVenta) AS ventasMismaCuenta
	FROM	dbo.SEG_Venta sv
	WHERE	sv.codigoTipoCuenta = @codigoTipoCuenta AND
			sv.numeroCuenta = @numeroCuenta AND 
			sv.idTipoIdentificacion = @idTipoDeIdentificacion AND
			sv.identificacion = @identificacion AND
			sv.codigoEstadoPoliza = 1)

SET @cuentasCliente = (
	SELECT COUNT(ventasPorCuentas) AS cuentasCliente FROM 
	(
	SELECT	COUNT(sv.idVenta) AS ventasPorCuentas
	FROM	dbo.SEG_Venta sv
	WHERE	sv.idTipoIdentificacion = @idTipoDeIdentificacion AND
			sv.identificacion = @identificacion AND
			sv.codigoEstadoPoliza = 1
	GROUP BY sv.numeroCuenta, sv.codigoTipoCuenta
	)
	AS cuentasCliente)

IF NOT EXISTS (SELECT TOP(1) sv.idVenta FROM dbo.SEG_Venta sv WHERE sv.codigoEstadoPoliza = 1 AND sv.codigoTipoCuenta = @codigoTipoCuenta AND sv.numeroCuenta = @numeroCuenta)
BEGIN 
	SET @cuentasCliente = @cuentasCliente + 1;
END

	SELECT @ventasMismaCuenta, @cuentasCliente

END