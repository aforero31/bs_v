CREATE VIEW [dbo].[VW_SEG_Recobros]
AS
SELECT        RTRIM(LTRIM(ISNULL(VEN.consecutivo, ''))) AS NUMERO_POLIZA, FORMAT(VEN.fechaCreacion, 'yyyyMMdd') AS FECHA_CREACION, 
                         UPPER(RTRIM(LTRIM(ISNULL(VEN.nacionalidad, '')))) AS NACIONALIDAD, UPPER(RTRIM(LTRIM(ISNULL(VEN.nombreIdentificacion, '')))) 
                         AS NOMBRE_TIPO_IDENTIFICACION, RTRIM(LTRIM(ISNULL(VEN.identificacion, ''))) AS NUMERO_IDENTIFICACION, 
                         UPPER(RTRIM(LTRIM(ISNULL(VEN.nombreGenero, '')))) AS GENERO, UPPER(RTRIM(LTRIM(ISNULL(VEN.primerNombre, '')))) AS PRIMER_NOMBRE, 
                         UPPER(RTRIM(LTRIM(ISNULL(VEN.segundoNombre, '')))) AS SEGUNDO_NOMBRE, UPPER(RTRIM(LTRIM(ISNULL(VEN.primerApellido, '')))) AS PRIMER_APELLIDO, 
                         UPPER(RTRIM(LTRIM(ISNULL(VEN.segundoApellido, '')))) AS SEGUNDO_APELLIDO, ISNULL(FORMAT(VEN.fechaNacimiento, 'yyyyMMdd'), '') AS FECHA_NACIMIENTO,
                          UPPER(RTRIM(LTRIM(ISNULL(VEN.ciudadNacimiento, '')))) AS CIUDAD_NACIMIENTO, UPPER(RTRIM(LTRIM(ISNULL(VEN.departamentoResidencia, '')))) 
                         AS DEPARTAMENTO_RESIDENCIA, UPPER(RTRIM(LTRIM(ISNULL(VEN.ciudadResidencia, '')))) AS CIUDAD_RESIDENCIA, 
                         UPPER(RTRIM(LTRIM(ISNULL(VEN.direccion, '')))) AS DIRECCION, RTRIM(LTRIM(ISNULL(VEN.telefono, ''))) AS TELEFONO, RTRIM(LTRIM(ISNULL(VEN.celular, ''))) 
                         AS CELULAR, UPPER(RTRIM(LTRIM(ISNULL(VEN.correo, '')))) AS CORREO, RTRIM(LTRIM(ISNULL(seg.codigoSuperintendencia, ''))) 
                         AS CODIGO_SUPER_ASEGURADORA, RTRIM(LTRIM(ISNULL(VEN.identificacionAseguradora, ''))) AS IDENTIFICACION_ASEGURADORA, 
                         UPPER(RTRIM(LTRIM(ISNULL(VEN.nombreAseguradora, '')))) AS NOMBRE_ASEGURADORA, RTRIM(LTRIM(ISNULL(CONVERT(VARCHAR(30), VEN.valorPoliza), ''))) 
                         AS VALOR_POLIZA, RTRIM(LTRIM(ISNULL(CONVERT(VARCHAR(30), VEN.codigoPlan), ''))) AS CODIGO_PLAN, UPPER(RTRIM(LTRIM(ISNULL(VEN.nombrePlan, '')))) 
                         AS NOMBRE_PLAN, RTRIM(LTRIM(ISNULL(CONVERT(VARCHAR(30), VEN.codigoSeguro), ''))) AS CODIGO_PRODUCTO, 
                         UPPER(RTRIM(LTRIM(ISNULL(VEN.nombreSeguro, '')))) AS NOMBRE_PRODUCTO, RTRIM(LTRIM(ISNULL(CONVERT(VARCHAR(4), VEN.codigoTipoCuenta), ''))) 
                         AS CODIGO_TIPO_CUENTA, UPPER(RTRIM(LTRIM(ISNULL(VEN.nombreTipoCuenta, '')))) AS NOMBRE_TIPO_CUENTA, RTRIM(LTRIM(ISNULL(VEN.numeroCuenta, ''))) 
                         AS NUMERO_CUENTA, RTRIM(LTRIM(ISNULL(CONVERT(VARCHAR(30), VEN.codigoCanalVenta), ''))) AS CANAL_VENTA, 
                         UPPER(RTRIM(LTRIM(ISNULL(VEN.nombreCanalVenta, '')))) AS NOMBRE_CANAL_VENTA, RTRIM(LTRIM(ISNULL(CONVERT(VARCHAR(30), VEN.codigoConvenio), ''))) 
                         AS CONVENIO, UPPER(RTRIM(LTRIM(ISNULL(VEN.nombrePeriodicidad, '')))) AS PERIODICIDAD, RTRIM(LTRIM(ISNULL(CONVERT(VARCHAR(2), 
                         VEN.numMesesPeriodicidad), ''))) AS MESE_PERIODICIDAD, RTRIM(LTRIM(ISNULL(CONVERT(VARCHAR(30), VEN.idOficina), ''))) AS CODIGO_OFICINA, 
                         UPPER(RTRIM(LTRIM(ISNULL(VEN.nombreCiudadOficina, '')))) AS CIUDAD_OFICINA, UPPER(RTRIM(LTRIM(ISNULL(VEN.nombreOficina, '')))) AS NOMBRE_OFICINA, 
                         RTRIM(LTRIM(ISNULL(VEN.idAsesor, ''))) AS CODIGO_ASESOR, RTRIM(LTRIM(ISNULL(VEN.identificacionAsesor, ''))) AS IDENTIFICACION_ASESOR, 
                         UPPER(RTRIM(LTRIM(ISNULL(VEN.nombreAsesor, '')))) AS NOMBRE_ASESOR, UPPER(RTRIM(LTRIM(ISNULL(estPol.descripcionEstadoPoliza, '')))) 
                         AS ESTADO_POLIZA, '0' AS CODIGO_TIPO_NOVEDAD, '' AS NOMBRE_TIPO_NOVEDAD, '' AS CAUSAL_NOVEDAD, '' AS FECHA_NOVEDAD, 
                         FORMAT(REC.fechaUltimoPeriodo, 'yyyyMMdd') AS FECHA_COBRO, REC.contador AS INTENTOS_COBRO, NULL AS ALTURA, '0' AS filtoTipoNovedad, 
                         '0' AS filtroCausal, CAST(REC.fechaUltimoPeriodo AS DATE) AS filtroFecha, seg.idAseguradora AS filtroAseguradora, 2 AS filtroCobro
FROM            dbo.SEG_Recobro AS REC INNER JOIN
                         dbo.SEG_Venta AS VEN ON REC.consecutivoPoliza = VEN.consecutivo INNER JOIN
                         dbo.SEG_EstadoPoliza AS estPol ON VEN.codigoEstadoPoliza = estPol.codigoEstadoPoliza INNER JOIN
                         dbo.SEG_Aseguradora AS seg ON seg.identificacion = VEN.identificacionAseguradora
WHERE        (REC.activo = 1)