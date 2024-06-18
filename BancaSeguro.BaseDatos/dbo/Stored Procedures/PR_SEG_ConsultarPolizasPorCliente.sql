
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarPolizasPorCliente]
@idTipoDeIdentificacion INT = NULL,
@identificacion VARCHAR(16)
AS
/* *************************************************************************************************************************************************
NOMBRE DEL PROGRAMA: [PR_SEG_ConsultarPolizasPorCliente]
DESCRIPCION: Procedimiento que consulta todas la polizas por identificacion y tipo de identificacion
PARAMETROS DE ENTRADA:	identificacion y tipo de identificacion
PARAMETROS DE SALIDA:	No aplica
RESULTADO:	Consulta de datos de la poliza del cliente vendidas sin importar el estado
CODIGOS DE ERROR:	No aplica
CODIGOS DE SATISFACCION:	No aplica
----------------------------------------------------------------------------------------------------------------------------------------------------
REQUERIMIENTO: HU012 - Consultar Venta
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: UT - BAC
FECHA DE CREACIÓN: 09/03/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agrega campo para devolucion del asesor
REQUERIMIENTO: HU010 - ReImpresion Poliza
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: UT - BAC
FECHA DE MODIFICACIÓN: 17/03/2016
-----------------------------------------------------------------------------------------
MODIFICACION: Se adiciona consulta de celular del cliente
REQUERIMIENTO: SD1588485-Registrar venta QC 7912
AUTOR: INTERGRUPO/pmora
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 2016-05-16
-----------------------------------------------------------------------------------------
MODIFICACION: Se ajusta la consulta de la cancelación y último pago de una póliza.
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 2016-08-01
-----------------------------------------------------------------------------------------
MODIFICACION: Se ajusta la consulta de la información de cancelación o anulación de una venta.
REQUERIMIENTO: SD1588485 QC8847
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 14/09/2016
****************************************************************************************************************************************************/


BEGIN
	SELECT	SV.fechaNacimiento,
			SV.ciudadNacimiento,
			SV.nacionalidad,
			SG.nombre AS GeneroCliente,
			SV.direccion,
			SV.ciudadResidencia,
			SV.telefono,
			SV.celular,
			SV.correo,
			CONVERT(VARCHAR(50),SPS.codigo) AS codigoProducto,
			SPS.nombre AS nombreProducto,
			SV.numeroCuenta AS NumeroCuentaCliente,
			SV.primerNombre,
			SV.segundoNombre,
			SV.primerApellido,
			SV.segundoApellido,
			SV.consecutivo,
			SV.idVenta,
			SEP.descripcionEstadoPoliza,
			SV.fechaCreacion,
			SDCP.fechaCancelacion AS fechaCancelacion,--Fecha de Cancelacion de la poliza falta!!!!!!!
			SDCP.novedad  AS novedad,
			SV.nombreSeguro AS nombreSeguro,
			CONVERT(varchar(50),SV.codigoSeguro) + ' - ' + SV.nombreSeguro AS descripcionProducto,
			SV.nombrePlan AS nombrePlan,
			CONVERT(varchar(50),SV.codigoPlan) + ' - ' + SV.nombrePlan AS descripcionPlan,
			SV.nombrePeriodicidad AS Periodicidad,
			SV.valorPoliza AS valor,
			SV.numeroCuenta AS NumeroCuentaCliente,
			dbo.FN_SEG_ObtenerUltimoPago(SV.idVenta) fechaCobroExitoso, -- Fecha del ultimo cobro exitoso falta!!!!!!
			SA.idAsesor,
			SV.codigoSeguro AS idSeguro
	FROM	SEG_Venta SV INNER JOIN 
			SEG_Genero SG ON SG.idGenero = SV.IdGenero INNER JOIN 
			SEG_Productos SPS ON SPS.codigo = SV.codigoTipoCuenta INNER JOIN 
			SEG_Asesor SA ON SA.idAsesor = SV.idAsesor INNER JOIN
			SEG_EstadoPoliza SEP ON SEP.codigoEstadoPoliza = SV.codigoEstadoPoliza 
			LEFT JOIN (SELECT fechaCancelacion,novedad,idVenta FROM (SELECT ROW_NUMBER() OVER (PARTITION BY SDNP.idVenta ORDER BY SDNP.fechaNovedad DESC) AS numFila,  SDNP.fechaNovedad AS fechaCancelacion,
									STN.nombreTipoNovedad + ' - ' + SCN.nombreNovedad  AS novedad, SDNP.idVenta
						FROM SEG_DetalleNovedadPoliza SDNP 
						INNER JOIN SEG_CausalNovedad SCN ON SCN.idCausalNovedad = SDNP.idCausalNovedad 
						INNER JOIN SEG_TipoNovedad STN ON STN.idTipoNovedad = SCN.idTipoNovedad
						WHERE STN.codigoTipoNovedad IN (1,2)) 
						AS VCA WHERE VCA.numFila =1) AS SDCP ON SDCP.idVenta = SV.idVenta
			
	WHERE	SV.idTipoIdentificacion = @idTipoDeIdentificacion AND
			SV.identificacion = @identificacion	
	ORDER BY SV.fechaCreacion DESC
END