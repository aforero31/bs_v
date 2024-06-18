
CREATE VIEW [dbo].[VW_SEG_Polizas]
AS
SELECT        RTRIM(LTRIM(CONVERT(VARCHAR(30), dbo.SEG_Venta.consecutivo))) AS NUMERO_SOLICITUD, CONVERT(VARCHAR(8), dbo.SEG_Venta.fechaCreacion, 112) 
                         AS INICIO_VIGENCIA, CONVERT(VARCHAR(8), DATEADD(YEAR, 1, dbo.SEG_Venta.fechaCreacion), 112) AS FIN_VIGENCIA, CONVERT(VARCHAR(8), GETDATE(), 112) 
                         AS FECHA_PROCESO, RTRIM(LTRIM(CONVERT(VARCHAR(2), dbo.SEG_TipoIdentificacion.CodigoCardif))) AS TIPO_IDENTIFICACION_ASEGURADO, 
                         UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.nombreIdentificacion, '')))) AS NOMBRE_IDENTIFICACION_ASEGURADO, CONVERT(VARCHAR(20), 
                         dbo.SEG_Venta.identificacion) AS IDENTIFICACION_ASEGURADO, UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.nombreGenero, '')))) AS GENERO_ASEGURADO, 
                         UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.primerApellido, '')))) AS PRIMER_APELLIDO_ASEGURADO, 
                         UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.segundoApellido, '')))) AS SEGUNDO_APELLIDO_ASEGURADO, 
                         UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.primerNombre, '')))) AS PRIMER_NOMBRE_ASEGURADO, 
                         UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.segundoNombre, '')))) AS SEGUNDO_NOMBRE_ASEGURADO, CONVERT(VARCHAR(8), 
                         ISNULL(dbo.SEG_Venta.fechaNacimiento, ''), 112) AS FECHA_NACIMIENTO_ASEGURADO, UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.ciudadNacimiento, '')))) 
                         AS CIUDAD_NACIMIENTO_ASEGURADO, UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.departamentoResidencia, '')))) 
                         AS DEPARTAMENTO_RESIDENCIA_ASEGURADO, UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.ciudadResidencia, '')))) AS CIUDAD_RESIDENCIA_ASEGURADO, 
                         UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.direccion, '')))) AS DIRECCION_ASEGURADO, RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.telefono, ''))) 
                         AS TELEFONO_ASEGURADO, RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.celular, ''))) AS CELULAR_ASEGURADO, UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.correo, 
                         '')))) AS CORREO_ASEGURADO, RTRIM(LTRIM(ISNULL(seg.codigoSuperintendencia, ''))) AS CODIGO_SUPER_ASEGURADORA, 
                         RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.identificacionAseguradora, ''))) AS IDENTIFICACION_ASEGURADORA, 
                         UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.nombreAseguradora, '')))) AS NOMBRE_ASEGURADORA, RTRIM(LTRIM(CONVERT(VARCHAR(30), 
                         dbo.SEG_Venta.valorPoliza))) AS VALOR_POLIZA, RTRIM(LTRIM(CONVERT(VARCHAR(30), dbo.SEG_Venta.codigoPlan))) AS CODIGO_PLAN, 
                         UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.nombrePlan, '')))) AS NOMBRE_PLAN, RTRIM(LTRIM(CONVERT(VARCHAR(30), dbo.SEG_Venta.codigoSeguro))) 
                         AS CODIGO_PRODUCTO, UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.nombreSeguro, '')))) AS NOMBRE_PRODUCTO, RTRIM(LTRIM(CONVERT(VARCHAR(4), 
                         dbo.SEG_Venta.codigoTipoCuenta))) AS CODIGO_TIPO_CUENTA, UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.nombreTipoCuenta, '')))) AS NOMBRE_TIPO_CUENTA, 
                         RTRIM(LTRIM(dbo.SEG_Venta.numeroCuenta)) AS NUMERO_CUENTA, RTRIM(LTRIM(CONVERT(VARCHAR(30), dbo.SEG_Venta.codigoCanalVenta))) AS CANAL_VENTA, 
                         UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.nombreCanalVenta, '')))) AS NOMBRE_CANAL_VENTA, RTRIM(LTRIM(CONVERT(VARCHAR(30), 
                         dbo.SEG_Venta.codigoConvenio))) AS CONVENIO, UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.nombrePeriodicidad, '')))) AS PERIODICIDAD, 
                         RTRIM(LTRIM(CONVERT(VARCHAR(4), dbo.SEG_Venta.numMesesPeriodicidad))) AS MESES_PERIODICIDAD, 
                         RTRIM(LTRIM(ISNULL(SEG_TipoIdentificacionConyuge.CodigoCardif, ''))) AS CODIGO_IDENTIFICACION_SEGUNDO_ASEGURADO, 
                         RTRIM(LTRIM(ISNULL(SEG_TipoIdentificacionConyuge.nombre, ''))) AS TIPO_IDENTIFICACION_SEGUNDO_ASEGURADO, 
                         RTRIM(LTRIM(ISNULL(dbo.SEG_Conyuge.identificacion, ''))) AS IDENTIFICACION_SEGUNDO_ASEGURADO, 
                         UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Conyuge.primerApellido, '')))) AS PRIMER_APELLIDO_SEGUNDO_ASEGURADO, 
                         UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Conyuge.segundoApellido, '')))) AS SEGUNDO_APELLIDO_SEGUNDO_ASEGURADO, 
                         UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Conyuge.primerNombre, '')))) AS PRIMER_NOMBRE_SEGUNDO_ASEGURADO, 
                         UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Conyuge.segundoNombre, '')))) AS SEGUNDO_NOMBRE_SEGUNDO_ASEGURADO, 
                         UPPER(RTRIM(LTRIM(ISNULL(SEG_GeneroConyuge.nombre, '')))) AS GENERO_SEGUNDO_ASEGURADO, CONVERT(VARCHAR(8), 
                         ISNULL(dbo.SEG_Conyuge.fechaNacimiento, ''), 112) AS FECHA_NACIMIENTO_SEGUNDO_ASEGURADO, RTRIM(LTRIM(CONVERT(VARCHAR(30), 
                         dbo.SEG_Venta.idOficina))) AS CODIGO_OFICINA, UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.nombreCiudadOficina, '')))) AS CIUDAD_OFICINA, 
                         UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.nombreOficina, '')))) AS NOMBRE_OFICINA, RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.idAsesor, ''))) AS CODIGO_ASESOR, 
                         RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.identificacionAsesor, ''))) AS IDENTIFICACION_ASESOR, UPPER(RTRIM(LTRIM(ISNULL(dbo.SEG_Venta.nombreAsesor, '')))) 
                         AS NOMBRE_ASESOR, UPPER(RTRIM(LTRIM(ISNULL(estPol.descripcionEstadoPoliza, '')))) AS ESTADO_POLIZA, RTRIM(LTRIM(CONVERT(VARCHAR(4), 
                         dbo.SEG_Venta.altura))) AS ALTURA, dbo.SEG_Venta.altura AS filtroAltura, dbo.SEG_Venta.codigoEstadoPoliza AS filtroEstado, 
                         seg.idAseguradora AS filtroAseguradora, dbo.SEG_Venta.idVenta AS filtroVenta
FROM            dbo.SEG_Venta INNER JOIN
                         dbo.SEG_TipoIdentificacion ON dbo.SEG_TipoIdentificacion.idTipoIdentificacion = dbo.SEG_Venta.idTipoIdentificacion LEFT OUTER JOIN
                         dbo.SEG_Conyuge ON dbo.SEG_Conyuge.idVenta = dbo.SEG_Venta.idVenta LEFT OUTER JOIN
                         dbo.SEG_TipoIdentificacion AS SEG_TipoIdentificacionConyuge ON 
                         SEG_TipoIdentificacionConyuge.idTipoIdentificacion = dbo.SEG_Conyuge.IdTipoIdentificacion LEFT OUTER JOIN
                         dbo.SEG_Genero AS SEG_GeneroConyuge ON SEG_GeneroConyuge.idGenero = ISNULL(dbo.SEG_Conyuge.IdGenero, 0) INNER JOIN
                         dbo.SEG_Aseguradora AS seg ON seg.identificacion = dbo.SEG_Venta.identificacionAseguradora INNER JOIN
                         dbo.SEG_EstadoPoliza AS estPol ON dbo.SEG_Venta.codigoEstadoPoliza = estPol.codigoEstadoPoliza