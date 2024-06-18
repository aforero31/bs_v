/*---------------------------------------------------------------------------------------------------------------
CREACIÓN
REQUERIMIENTO: SD1588485 - HU018 Parametrizacion Mensajes
AUTOR: INTERGRUPO\wzaldua
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Procedimiento que consultas las ventas vigentes por un cliente y las cuentas utilizadas en las ventas
FECHA DE MODIFICACIÓN: 18/07/2016
---------------------------------------------------------------------------------------------------------------
MODIFICACION
REQUERIMIENTO: SD1811974 - HU018 Parametrizacion Mensajes
AUTOR: INTERGRUPO\Enrique Rivera
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Se ajusta procedimiento para recibir el codigo del seguro
FECHA DE MODIFICACIÓN: 19/12/2016
---------------------------------------------------------------------------------------------------------------
MODIFICACION
REQUERIMIENTO: SD181197
AUTOR: INTERGRUPO\César Blandón
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Se ajusta procedimiento para que obtenga tipo de cuenta y numero de cuenta por cliente
FECHA DE MODIFICACIÓN: 30/03/2017
---------------------------------------------------------------------------------------------------------------
MODIFICACION
REQUERIMIENTO: SD3054594
AUTOR: INTERGRUPO\César Blandón
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Se ajusta procedimiento para que consulte también las polizas en estado pendiente po cobrar.
FECHA DE MODIFICACIÓN: 25/09/2017
---------------------------------------------------------------------------------------------------------------*/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarVentasCuentasPorCliente] 
	@idTipoDeIdentificacion INT,-- = 1,
	@identificacion VARCHAR(16),-- = '474134'
	@codigoSeguro INT-- = '474134'
AS
BEGIN
SELECT sv.codigoTipoCuenta,sv.numeroCuenta 
	FROM	dbo.SEG_Venta sv
	WHERE	sv.idTipoIdentificacion = @idTipoDeIdentificacion AND
			sv.identificacion = @identificacion AND
			sv.codigoSeguro = @codigoSeguro AND
			sv.codigoEstadoPoliza IN (1,3)
END