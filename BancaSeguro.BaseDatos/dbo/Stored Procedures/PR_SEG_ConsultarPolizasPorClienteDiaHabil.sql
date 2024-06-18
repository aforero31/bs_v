CREATE PROCEDURE [dbo].[PR_SEG_ConsultarPolizasPorClienteDiaHabil]
				@idTipoDeIdentificacion INT = NULL,
				@identificacion VARCHAR(16)
AS
/* *************************************************************************************************************************************************
NOMBRE DEL PROGRAMA: [PR_SEG_ConsultarPolizasPorClienteDiaHabil]
DESCRIPCION: Procedimiento que consulta todas la polizas por identificacion y tipo de identificacion teniendo en cuenta el dia habil
PARAMETROS DE ENTRADA:	identificacion y tipo de identificacion
PARAMETROS DE SALIDA:	No aplica
RESULTADO:	Consulta de datos de la poliza del cliente vendidas sin importar el estado
CODIGOS DE ERROR:	No aplica
CODIGOS DE SATISFACCION:	No aplica
----------------------------------------------------------------------------------------------------------------------------------------------------
REQUERIMIENTO: SD1588485_QC_9584
AUTOR: Paulo Andrés Mora
EMPRESA: UT - BAC
FECHA DE CREACIÓN: 28/11/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACION
REQUERIMIENTO:	SD1588485
AUTOR: Paulo Mora
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO:	Consulta de datos de la poliza del cliente vendidas sin importar el estado
FECHA DE MODIFICACIÓN: 18/01/2017
----------------------------------------------------------------------------------------------------------------------------------------------------
****************************************************************************************************************************************************/


BEGIN

DECLARE @fechaCreacion DATE = NULL
EXEC @fechaCreacion = [dbo].[FN_SEG_ObtenerSiguienteDiaHabil];

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
			AND  Convert(varchar,SV.fechaCreacion,103) = Convert(varchar,@fechaCreacion,103)
	ORDER BY SV.fechaCreacion DESC
END