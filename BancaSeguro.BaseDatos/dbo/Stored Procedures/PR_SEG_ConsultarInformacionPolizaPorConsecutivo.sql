/*****************************************************************************************
CREACION
REQUERIMIENTO:	SD1588485-Sprint 2 / HU001.6
AUTOR: Carlos Piza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO:		Consulta la informacion que el usuario puede 
				paramtrizar para imprimir los documentos de la poliza 
FECHA DE MODIFICACIÓN: 22/02/2016
-----------------------------------------------------------------------------------------
MODIFICACION: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Se cambia el valor del IVA y el valor 
		   de la poliza sin IVA por el campo correspondiente al plan
FECHA DE MODIFICACIÓN: 03/05/2016
-----------------------------------------------------------------------------------------
MODIFICACION: Se adiciona consulta de celular del cliente
REQUERIMIENTO: Registrar venta QC 7912
AUTOR: INTERGRUPO/pmora
EMPRESA: Unión temporal FS-BAC-2013
-----------------------------------------------------------------------------------------
MODIFICACION: Se adiciona modifica script por campos de tabla venta
REQUERIMIENTO: SD1588485-Registrar venta QC 7912
AUTOR: INTERGRUPO/Enrique Rivera
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 2016-07-15
-----------------------------------------------------------------------------------------
MODIFICACION: Se adiciona campos de asesor y oficina
REQUERIMIENTO: SD1588485-Registrar venta QC 7912
AUTOR: INTERGRUPO/Enrique Rivera
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 2016-07-29
-----------------------------------------------------------------------------------------
MODIFICACION: Se adiciona campos de DepartamenoCliente
REQUERIMIENTO: SD1588485 - Registrar venta QC 8819
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 06/09/2016
-----------------------------------------------------------------------------------------
MODIFICACION: Se cambia al campo fecha creacion
REQUERIMIENTO: SD1588485  
AUTOR: Enrique Rivera
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 28/11/2016
*****************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarInformacionPolizaPorConsecutivo]
(@Consecutivo VARCHAR(50))
AS

BEGIN
	SELECT CONVERT(varchar(10), SEG_Venta.fechaCreacion,112) AS FechaSolicitud
	,SEG_Venta.primerNombre AS PrimerNombreCliente
	,SEG_Venta.segundoNombre AS SegundoNombreCliente
	,SEG_Venta.primerApellido AS PrimerApellidoCliente
	,SEG_Venta.segundoApellido AS SegundoApellidoCliente
	,SEG_Venta.identificacion AS NumeroIdentificacionCliente
	,SEG_TipoIdentificacion.abreviatura AS TipoIdentificacionAbreviadoCliente
	,SEG_TipoIdentificacion.nombre AS TipoIdentificacionDescripcionCliente
	,CONVERT(varchar(10), SEG_Venta.fechaNacimiento,112) AS FechaNacimientoCliente
	,SEG_Venta.ciudadNacimiento AS CiudadNacimientoCliente
	,SEG_Genero.nombre AS GeneroCliente
	,SEG_Venta.direccion AS DireccionCliente
	,SEG_Venta.telefono AS TelefonoCliente
	,SEG_Venta.ciudadResidencia AS CiudadResidenciaCliente
	,SEG_Venta.departamentoResidencia AS DepartamenoCliente
	,SEG_Venta.nacionalidad AS NacionalidadCliente
	,SEG_Venta.actividadEconomicaCliente AS ActividadEconomicaCliente
	,SEG_Venta.celular AS CelularCliente
	,SEG_Productos.nombre AS TipoCuentaCliente
	,SEG_Venta.numeroCuenta AS NumeroCuentaCliente
	,'' AS FechaVencimientoTarjetaCliente
	,SEG_Venta.consecutivo AS ConsecutivoPoliza
	,CONVERT(VARCHAR(18),t2.ValorSinIva) AS ValorPolizaSinIva
	,CONVERT(VARCHAR(18),t2.ValorIva) AS ValorIvaPoliza
	,CONVERT(VARCHAR(30), SEG_Venta.valorPoliza) AS ValorPrimaConIva
	,SEG_Venta.nombrePeriodicidad AS Periodicidad
	,SEG_Venta.nombrePlan AS PlanPoliza
	,SEG_Venta.nombreOficina as NombreOficina
	,SEG_Venta.nombreCiudadOficina as CiudadOficina
	,SEG_Venta.identificacionAsesor as IdentificacionAsesor
	,SEG_Venta.nombreAsesor  as NombreAsesor
	FROM SEG_Venta
	INNER JOIN SEG_TipoIdentificacion
	ON SEG_Venta.idTipoIdentificacion = SEG_TipoIdentificacion.idTipoIdentificacion
	INNER JOIN SEG_Genero
	ON SEG_Venta.IdGenero = SEG_Genero.idGenero
	INNER JOIN SEG_Productos
	ON SEG_Productos.codigo = SEG_Venta.codigoTipoCuenta
	INNER JOIN SEG_Parametro
	ON SEG_Parametro.Descripcion like 'IVA'
	inner join seg_plan t2 on  SEG_Venta.codigoPlan = t2.codigo
    inner join seg_seguro t3 on t2.idSeguro = t3.idSeguro and SEG_Venta.codigoSeguro = t3.codigo
	WHERE consecutivo = @Consecutivo
END
