
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarEmisionesDia]
AS
/*************************************************************************************************************************************
CREACIÓN
REQUERIMIENTO:		Sprint 2/HU007
AUTOR:				Carlos Piza
EMPRESA:			Unión temporal FS-BAC-2013.
OBJETIVO:			Consulta la informacion de las emisiones del día
FECHA DE CREACIÓN:	29/02/2016
-------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: -Se modifica la forma de extraer los campos: NumeroSolicitud,Canal_Venta_Seguro,Celular_Asegurado,
				Email_Asegurado,Cel_Segundo_Asegurado,Email_Segundo_Asegurado
				-Se establece que los siguientes campos deben estar en mayúsculas:Primer_Apellido_Asegurado,
				Segundo_Apellido_Asegurado,Primer_Nombre_Asegurado,Segundo_Nombre_Asegurado,Sexo_Asegurado,
				Primer_Apellido_Resp_Pago,Segundo_Apellido_Resp_Pago,Nombres_Resp_Pago,Primer_Apellido_Segundo_Asegurado,
				Segundo_Apellido_Segundo_Asegurado,Primer_Nombre_Segundo_Asegurado,Segundo_Nombre_Segundo_Asegurado,
				SexoSegundoAsegurado
				-Se escribe el comentario de lo que hace la FN_SEG_ObtenerBeneficiariosArchivoEmisiones
				-Se establece que el tamaño máximo del campo direccion es 50 y debe estar en mayúscula
				-Se le quitan espacios en blanco al campo: idAsesor
				-Se establece que el campo Prima_Total no debe tener punto.
REQUERIMIENTO: Sprint 3/HU007
AUTOR: Jetlhen Roa Castañeda.
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 16/05/2016
-------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: - Se dejo el canal venta un valor fijo a la espera del valor correcto a colocar según el area usuaria.
REQUERIMIENTO: Sprint 5/HU007
AUTOR: Iraida Montoya.
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 31/05/2016
-------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Remover la relación con el plan desde la venta y se agrega el código DANE.
REQUERIMIENTO: Sprint 5/HU007
AUTOR: Iraida Montoya.
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 27/05/2016
-------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Ajustar la información del conyuge.
REQUERIMIENTO: SD1588485 QC8819
AUTOR: Iraida Montoya.
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 07/09/2016
-------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se calculan los días de consulta de acuerdo a la ultima ejecución y dias hábiles.
REQUERIMIENTO: SD1588485 QC8947
AUTOR: Iraida Montoya.
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 19/09/2016
-------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se realiza ajuste en el campo NumeroSolicitud ya que debe concordar con el consecutivo
REQUERIMIENTO: SD1588485 QC8947
AUTOR: Enrique Rivera.
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 03/11/2016
-------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se modifican las columnas Inicio_Vigencia Fin_Vigencia a Fecha Actual
REQUERIMIENTO: SD1588485 9139
AUTOR: Enrique Rivera.
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 21/11/2016
-------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se eliminan los espacios en los campo telefono y celular 
REQUERIMIENTO: SD1588485 
AUTOR: Iraida Montoya.
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 14/12/2016
*************************************************************************************************************************************/
BEGIN
	DECLARE @FechaUltimaEjecucion DATETIME 
	SET @FechaUltimaEjecucion = (SELECT FechaEjecucionETL FROM [dbo].[SEG_FechaEjecucionETL] where Prefijo = 'EMI' )

	IF  CONVERT(DATE, @FechaUltimaEjecucion ) < CONVERT(DATE, GETDATE())
	BEGIN
		SET @FechaUltimaEjecucion = DATEADD(DAY,1,@FechaUltimaEjecucion)
	END
	SELECT 
		REPLACE(RTRIM(LTRIM(SEG_Venta.consecutivo)),(CONVERT(VARCHAR(4), SEG_Venta.codigoSeguro) + CONVERT(VARCHAR(20), SEG_Venta.identificacion)),'') +';'+--NumeroSolicitud,
		CONVERT(VARCHAR(4), SEG_Venta.codigoSeguro)	+';'+--Cod_Producto,
		CONVERT(VARCHAR(8), GETDATE(),112)+';'+--Inicio_Vigencia,
		--CONVERT(VARCHAR(8), SEG_Venta.fechaCreacion,112)+';'+--Inicio_Vigencia,
		CONVERT(VARCHAR(8), DATEADD(YEAR,1,GETDATE()),112)+';'+--Fin_Vigencia,
		--CONVERT(VARCHAR(8), DATEADD(YEAR,1,SEG_Venta.fechaCreacion),112)+';'+--Fin_Vigencia,
		CONVERT(VARCHAR(8), GETDATE(),112)	+';'+--Fecha_Proceso,
		'1'	+';'+--Tipo_Movimiento,	
		RTRIM(LTRIM(CONVERT(VARCHAR(4),SEG_Venta.codigoPlan))) +';'+--Plan_Cardif,
		RTRIM(LTRIM(CONVERT(VARCHAR(2), SEG_TipoIdentificacion.CodigoCardif)))	+';'+--Tipo_Id_Asegurado,
		CONVERT(VARCHAR(20), SEG_Venta.identificacion)+';'+--Id_Asegurado,
		--RTRIM(LTRIM(ISNULL(SEG_Venta.primerApellido,'')))	+';'+
		UPPER(RTRIM(LTRIM(ISNULL(SEG_Venta.primerApellido,''))))+';'+--Primer_Apellido_Asegurado,	
		--RTRIM(LTRIM(ISNULL(SEG_Venta.segundoApellido,'')))	+';'+
		UPPER(RTRIM(LTRIM(ISNULL(SEG_Venta.segundoApellido,''))))+';'+--Segundo_Apellido_Asegurado,	
		--RTRIM(LTRIM(ISNULL(SEG_Venta.primerNombre,'')))	+';'+
		UPPER(RTRIM(LTRIM(ISNULL(SEG_Venta.primerNombre,''))))+';'+--Primer_Nombre_Asegurado,
		--RTRIM(LTRIM(ISNULL(SEG_Venta.segundoApellido,'')))	+';'+
		UPPER(RTRIM(LTRIM(ISNULL(SEG_Venta.segundoNombre,''))))+';'+--Segundo_Nombre_Asegurado
		--RTRIM(LTRIM(ISNULL(SEG_Genero.CodigoCardif,'')))	+';'+
		UPPER(RTRIM(LTRIM(ISNULL(SEG_Genero.CodigoCardif,''))))+';'+--Sexo_Asegurado,
		CONVERT(VARCHAR(8), ISNULL(SEG_Venta.fechaNacimiento,''),112) +';'+--Fecha_Nacimiento_Asegurado,			
		REPLACE(RTRIM(LTRIM(ISNULL(SEG_Venta.telefono,''))),' ','')+';'+--Tel_Asegurado,
		--RTRIM(LTRIM(ISNULL(SEG_Venta.direccion,'')))	+';'+
		SUBSTRING(UPPER(RTRIM(LTRIM(ISNULL(SEG_Venta.direccion,'')))),1,50)+';'+ --Direccion_Asegurado,	
		--OJO QUE PIDEN: el código DANE de la ciudad de la dirección del titular de la cuenta registrado en la base de datos de clientes
		--RTRIM(LTRIM(ISNULL(SEG_Venta.ciudadResidencia,'')))	+';'+
		UPPER(RTRIM(LTRIM(ISNULL(SEG_Venta.codigoDANE,''))))+';'+ --Ciudad_Asegurado,
		--SEG_Venta.idAsesor	+';'+
		RTRIM(LTRIM(SEG_Venta.idAsesor)) +';'+--Usuario,
		''	+';'+--Tipo_Prima,
		--CONVERT(VARCHAR(20),ISNULL(SEG_Plan.valor,0))	+';'+
		SUBSTRING(CONVERT(varchar(20),valorPoliza),1,CHARINDEX ( '.' ,valorPoliza,1)-1) +';'+--Prima_Total,
		''	+';'+--Valor_Asegurado,
		RTRIM(LTRIM(SEG_Productos.CodigoCardif))	+';'+--Codigo_Producto_Bancario,
		RTRIM(LTRIM(ISNULL(SEG_Venta.numeroCuenta,'')))	+';'+--Numero_Producto_Bancario,
		''	+';'+--Franquicia_Tarjeta_Credito,
		''	+';'+--Cuotas,
		''	+';'+--Fecha_Vencimiento_Tarjeta,
		''	+';'+--Plazo_Crédito,
		'1'	+';'+
		--RTRIM(LTRIM(seg_canalventa.codigo)) +';'+-- Canal_Venta_Seguro, 
		SEG_Venta.idAsesor	+';'+--Código_Asesor,
		SUBSTRING(CONVERT(VARCHAR(8), SEG_Venta.fechaCreacion,112),1,6)	+';'+--Fecha_Contable,
		RTRIM(LTRIM(SEG_Venta.idOficina))	+';'+--Sucursal,
		--''	+';'+--Celular_Asegurado,
		REPLACE(RTRIM(LTRIM(ISNULL(SEG_Venta.celular,''))),' ','')+';'+--Celular_Asegurado,		
		--''	+';'+--Email_Asegurado,
		RTRIM(LTRIM(ISNULL(SEG_Venta.correo,'')))+';'+--Email_Asegurado,
		RTRIM(LTRIM(SEG_Asesor.NumeroIdentificacion))	+';'+--Documento_Asesor,
		RTRIM(LTRIM(SEG_Asesor.nombre))	+';'+--Nombre_Asesor,
		''	+';'+--Tipo_Transaccion,
		''	+';'+--Valor_Crédito,
		''	+';'+--Valor_Cuota_Crédito,
		RTRIM(LTRIM(SEG_TipoIdentificacion.CodigoCardif))+';'+--Tipo_Id_Responsable_Pago,
		RTRIM(LTRIM(SEG_Venta.identificacion))	+';'+--Id_Responsable_Pago,
		''	+';'+--Zona,
		--RTRIM(LTRIM(ISNULL(SEG_Venta.primerApellido,'')))	+';'+
		UPPER(RTRIM(LTRIM(ISNULL(SEG_Venta.primerApellido,''))))+';'+ --Primer_Apellido_Resp_Pago,
		--RTRIM(LTRIM(ISNULL(SEG_Venta.segundoApellido,'')))	+';'+--Segundo_Apellido_Resp_Pago,
		UPPER(RTRIM(LTRIM(ISNULL(SEG_Venta.segundoApellido,''))))+';'+ --Segundo_Apellido_Resp_Pago,
		--RTRIM(LTRIM(ISNULL(SEG_Venta.primerNombre,''))) + ' ' + RTRIM(LTRIM(ISNULL(SEG_Venta.segundoNombre,'')))	+';'+
		UPPER(RTRIM(LTRIM(ISNULL(SEG_Venta.primerNombre,''))) + ' ' + RTRIM(LTRIM(ISNULL(SEG_Venta.segundoNombre,''))))+';'+ --Nombres_Resp_Pago,
		--La siguiente Fx lista los campos:Documento_Beneficiario_1,	Nombre_Beneficiario_1,Porcentaje_Beneficiario_1,
		--Documento_Beneficiario_2, Nombre_Beneficiario_2, Porcentaje_Beneficiario_2, Documento_Beneficiario_3,Nombre_Beneficiario_3,
		--Porcentaje_Beneficiario_3, Documento_Beneficiario_4, Nombre_Beneficiario_4, Porcentaje_Beneficiario_4, Documento_Beneficiario_5,
		--Nombre_Beneficiario_5,Porcentaje_Beneficiario_5,Documento_Beneficiario_6,Nombre_Beneficiario_6,Porcentaje_Beneficiario_6
		RTRIM(LTRIM(dbo.FN_SEG_ObtenerBeneficiariosArchivoEmisiones(SEG_Venta.idVenta)))	+';'+
		RTRIM(LTRIM(ISNULL(SEG_TipoIdentificacionConyuge.CodigoCardif,'')))	+';'+--Tipo_Id_Segundo_Asegurado,
		RTRIM(LTRIM(ISNULL(SEG_Conyuge.identificacion,'')))	+';'+--Id_Segundo_Asegurado,
		--RTRIM(LTRIM(ISNULL(SEG_Conyuge.primerApellido,'')))	+';'+
		UPPER(RTRIM(LTRIM(ISNULL(SEG_Conyuge.primerApellido,''))))+';'+	--Primer_Apellido_Segundo_Asegurado,
		--RTRIM(LTRIM(ISNULL(SEG_Conyuge.segundoApellido,'')))	+';'+
		UPPER(RTRIM(LTRIM(ISNULL(SEG_Conyuge.segundoApellido,''))))+';'+--Segundo_Apellido_Segundo_Asegurado,
		--RTRIM(LTRIM(ISNULL(SEG_Conyuge.primerNombre,'')))	+';'+
		UPPER(RTRIM(LTRIM(ISNULL(SEG_Conyuge.primerNombre,''))))+';'+--Primer_Nombre_Segundo_Asegurado,
		--RTRIM(LTRIM(ISNULL(SEG_Conyuge.segundoNombre,'')))	+';'+
		UPPER(RTRIM(LTRIM(ISNULL(SEG_Conyuge.segundoNombre,''))))+';'+--Segundo_Nombre_Segundo_Asegurado,
		--RTRIM(LTRIM(ISNULL(SEG_GeneroConyuge.CodigoCardif,'')))	+';'+
		UPPER(RTRIM(LTRIM(ISNULL(SEG_GeneroConyuge.CodigoCardif,''))))+';'+--SexoSegundoAsegurado,
		ISNULL(CONVERT(VARCHAR(8), SEG_Conyuge.fechaNacimiento,112),'')+';'+--Fecha_Nacimiento_Segundo_Asegurado,
		CASE WHEN ISNULL(SEG_Conyuge.idVenta, 0) = 0 THEN '' ELSE REPLACE(RTRIM(LTRIM(ISNULL(SEG_Venta.telefono,''))),' ','') END +';'+--Telefono_Segundo_Asegurado,
		CASE WHEN ISNULL(SEG_Conyuge.idVenta, 0) = 0 THEN '' ELSE SUBSTRING(UPPER(RTRIM(LTRIM(ISNULL(SEG_Venta.direccion,'')))),1,50) END +';'+ --Direccion_Segundo_Asegurado,
		CASE WHEN ISNULL(SEG_Conyuge.idVenta, 0) = 0 THEN '' ELSE UPPER(RTRIM(LTRIM(ISNULL(SEG_Venta.codigoDANE,'')))) END +';'+--Ciudad_Segundo_Asegurado,
		CASE WHEN ISNULL(SEG_Conyuge.idVenta, 0) = 0 THEN '' ELSE REPLACE(RTRIM(LTRIM(SEG_Venta.celular)), ' ','') END +';'+--Cel_Segundo_Asegurado,
		CASE WHEN ISNULL(SEG_Conyuge.idVenta, 0) = 0 THEN '' ELSE RTRIM(LTRIM(ISNULL(SEG_Venta.correo,''))) END +';'+--Email_Segundo_Asegurado,
		RTRIM(LTRIM(SEG_Venta.consecutivo)) as Salida -- NumeroDeCertificado
	FROM SEG_Venta
	INNER JOIN SEG_TipoIdentificacion									ON SEG_TipoIdentificacion.idTipoIdentificacion = SEG_Venta.idTipoIdentificacion
	LEFT JOIN SEG_Genero												ON SEG_Genero.idGenero = ISNULL(SEG_Venta.IdGenero,0)
	INNER JOIN SEG_Productos											ON SEG_Productos.codigo = SEG_VENTA.codigoTipoCuenta
	INNER JOIN SEG_Asesor												ON SEG_Asesor.idAsesor = SEG_Venta.idAsesor
	LEFT JOIN SEG_Conyuge												ON SEG_Conyuge.idVenta = SEG_Venta.idVenta
	LEFT JOIN SEG_TipoIdentificacion AS SEG_TipoIdentificacionConyuge	ON SEG_TipoIdentificacionConyuge.idTipoIdentificacion = SEG_Conyuge.idTipoIdentificacion
	LEFT JOIN SEG_Genero AS SEG_GeneroConyuge							ON SEG_GeneroConyuge.idGenero = ISNULL(SEG_Conyuge.IdGenero, 0)
	WHERE CAST(SEG_Venta.fechaCreacion AS DATE) BETWEEN CAST(@FechaUltimaEjecucion AS DATE) AND CAST(GETDATE() AS DATE)
END