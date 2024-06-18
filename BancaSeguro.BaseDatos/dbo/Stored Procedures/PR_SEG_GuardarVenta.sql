
CREATE PROCEDURE [dbo].[PR_SEG_GuardarVenta]

		    @idPlan    [int],
			@idAsesor   [varchar](50),
			@idOficina	[int],
            @consecutivo    [varchar](50),
            @idTipoIdentificacion    [int],
            @identificacion    [varchar](50),
            @primerNombre    [varchar](50),
            @segundoNombre    [varchar](50),
            @primerApellido    [varchar](50),
            @segundoApellido    [varchar](50),
            @fechaNacimiento    [datetime],
            @ciudadNacimiento    [varchar](50),
            @nacionalidad    [varchar](50),
            @idgenero  int,
            @direccion    [varchar](200),
            @ciudadResidencia    [varchar](50),
            @telefono [varchar](50),
            @celular [varchar](50),
            @correo [varchar](100),
			@valorPoliza decimal(18,2),
			@codigoTipoCuenta  int,
			@numeroCuenta [varchar](50),
			@actividadEconomica [varchar](50),			
			@departamentoResidencia [varchar](50),
			@codigoDANE [varchar](50)

AS
/* **************************************************************************************************************************************************
CREACIÓN
REQUERIMIENTO:
AUTOR: Fernando Fernandez P.
EMPRESA: Unión temporal FS-BAC-2013.
FECHA CREACIÓN: 12/01/2016
OBJETIVO: Este procedimiento crea una nueva venta
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agrega parametro idAsesor
REQUERIMIENTO: 
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 20/01/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agrega parametro valorPoliza por defecto 0 ya que no estaba en el alcanse del HU
REQUERIMIENTO: HU001
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 19/02/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agrega parametro @valorPoliza, @codigoTipoCuenta, @numeroCuenta
REQUERIMIENTO: HU001
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 23/02/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agrega el campo UltimoIPC a la tabla de venta como bandera para el incremento del IPC
REQUERIMIENTO: HU011 Incremento IPC
AUTOR: Jetlhen Yeny Roa Castañeda
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 22/03/2016
-----------------------------------------------------------------------------------------
MODIFICACION Se adiciona guardar celular
REQUERIMIENTO: SD1588485-Registrar venta QC 7912
AUTOR: INTERGRUPO/pmora
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 2016-05-16
-----------------------------------------------------------------------------------------
MODIFICACION Se adicionan nuevos campos de la venta
REQUERIMIENTO: SD1588485-Registrar venta
AUTOR: Enrique Rivera
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 2016-06-07
-----------------------------------------------------------------------------------------
MODIFICACION Se adicionan insercion en SEG_DetalleNovedadPoliza
REQUERIMIENTO: SD1588485-Registrar venta
AUTOR: Paulo Andres Mora
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 2016-07-18
-----------------------------------------------------------------------------------------
MODIFICACION Se adicionan insercion del codigo DANE
REQUERIMIENTO: SD1588485-Registrar venta
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 27/07/2016
-----------------------------------------------------------------------------------------
MODIFICACION Se adicionan select para ciudad de oficina
REQUERIMIENTO: SD1588485 - Registrar venta
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 29/07/2016
-----------------------------------------------------------------------------------------
MODIFICACION Se elimina el registro del primer cobro en la venta y la altura se almacena en 0
REQUERIMIENTO: SD1588485-Registrar venta
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 28/07/2016
-----------------------------------------------------------------------------------------
MODIFICACIONES: Se establece la altura el 1 cuando se crea la venta.
REQUERIMIENTO: SD1588485 QC8811
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 15/09/2016
-----------------------------------------------------------------------------------------
MODIFICACION: Se llama a la función FN_SEG_ObtenerSiguienteDiaHabil para ingresar el día hábil siguiente al de la creación de la póliza.
REQUERIMIENTO: SD1588485
AUTOR: Nelson Hernando Pardo Peláez
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 19/10/2016
-----------------------------------------------------------------------------------------
MODIFICACION: Se adicioan la hora en la fecha de registro de la venta
REQUERIMIENTO: SD1588485
AUTOR: Nelson Hernando Pardo Peláez
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 14/12/2016
***************************************************************************************************************************************************/

BEGIN
DECLARE @codigoTipoNovedadPago INT = 3,
        @idCausalNovedad INT = 0,
        @idTipoNovedad INT = 0,
        @idVenta INT,
		@fechaCreacion DATE = NULL
		
EXEC @fechaCreacion = [dbo].[FN_SEG_ObtenerSiguienteDiaHabil]

INSERT INTO dbo.SEG_Venta 
(	 
	idAsesor, 
	idOficina, 
	consecutivo, 
	fechaCreacion, 
	idTipoIdentificacion, 
	identificacion, 
	primerNombre, 
	segundoNombre, 
	primerApellido, 
	segundoApellido, 
	fechaNacimiento, 
	ciudadNacimiento, 
	nacionalidad, 
	IdGenero, 
	direccion, 
	ciudadResidencia, 
	telefono, 
	celular, 
	correo, 
	razonSocial, 
	fechaCreacionEmpresa, 
	representanteLegal, 
	actividadEconomicaCliente, 
	codigoEstadoPoliza, 
	valorPoliza, 
	codigoTipoCuenta, 
	numeroCuenta, 
	ultimoIPC, 
	identificacionAseguradora, 
	nombreAseguradora, 
	codigoSeguro, 
	nombreSeguro, 
	codigoPlan, 
	nombrePlan, 
	codigoConvenio, 
	nombrePeriodicidad, 
	numMesesPeriodicidad, 
	codigoCanalVenta, 
	nombreCanalVenta, 
	nombreOficina, 
	nombreCiudadOficina, 
	nombreAsesor, 
	identificacionAsesor, 
	nombreIdentificacion, 
	nombreGenero, 
	nombreTipoCuenta, 
	departamentoResidencia, 
	codigoDANE,
	altura)
SELECT  
   	@idAsesor,
	@idOficina,
	@consecutivo,
	CONVERT(DATETIME, CONVERT(CHAR(8), @fechaCreacion, 112) + ' ' + CONVERT(VARCHAR(8),GETDATE(),108)),		
	@idTipoIdentificacion,
	@identificacion,
	@primerNombre,
	@segundoNombre,
	@primerApellido,
	@segundoApellido,
	@fechaNacimiento,
	@ciudadNacimiento,
	@nacionalidad,	
	@idgenero,
	@direccion,
	@ciudadResidencia,
	@telefono,
	@celular,
	@correo,
	NULL,
	NULL,
	NULL,
	@actividadEconomica,
	1,	
	@valorPoliza,
	@codigoTipoCuenta,
	@numeroCuenta,
	YEAR(GETDATE()),
	t4.Identificacion AS 'NroAseguradora' 		
	,t4.Nombre AS 'NombreAseguradora'	
	,t3.codigo AS 'Codigo Seguro'	
	,t3.nombre AS 'Nombre Seguro'
	,t2.codigo AS 'Codigo Plan'	
	,t2.nombre AS 'Nombre Plan'	
	,t2.codigoConvenio AS 'codigoConvenio*'
	,t5.nombre AS 'Nombre Periodicidad'	
	,t5.numeroMesesPeriodicidad AS 'Numero Meses'	
	, t6.codigo AS 'Codigo Canal Venta'	
	, t6.nombre AS 'Nombre Canal Venta'	
	,(SELECT t7.nombre FROM SEG_Oficina t7 WHERE t7.idOficina = @idOficina) AS 'Nombre Oficina'	
	,(SELECT t7.ciudad FROM SEG_Oficina t7 WHERE t7.idOficina = @idOficina) AS 'Ciudad Oficina'
	,(SELECT t8.nombre FROM SEG_Asesor t8 WHERE t8.idAsesor = @idAsesor) AS 'Nombre Asesor'	
	,(SELECT t8.NumeroIdentificacion FROM SEG_Asesor t8 WHERE t8.idAsesor = @idAsesor)	AS 'Numero Asesor' 	
	,(SELECT t9.nombre FROM SEG_TipoIdentificacion t9 WHERE t9.idTipoIdentificacion = @idTipoIdentificacion)    AS 'Nombre Tipod Doc'            	
	,(SELECT t10.nombre FROM SEG_Genero t10 WHERE t10.idGenero = @idGenero) AS 'Nombre Genero'	
	,(SELECT t11.nombre FROM SEG_Productos t11 WHERE t11.codigo = @codigoTipoCuenta) AS 'Nombre Cuenta'	
	,@departamentoResidencia AS 'DepartamentoResidencia'   
	,@codigoDANE 
	,1 'Altura'
FROM SEG_Plan t2	
INNER JOIN SEG_Seguro t3 ON t2.idSeguro = t3.idSeguro	
INNER JOIN SEG_Aseguradora t4 ON t3.idAseguradora  = t4.idAseguradora	
INNER JOIN SEG_Periodicidad t5 ON t2.idPeriodicidad = t5.idPeriodicidad	
INNER JOIN SEG_CanalVenta t6 ON t6.idCanalVenta = t3.idCanalVenta  	
WHERE t2.idPlan = @idPlan

SET @idVenta = scope_identity() 
SELECT @idVenta AS idVenta
END