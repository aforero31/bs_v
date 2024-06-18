
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarDatosArchivoPlano] (@idprogramacion INT)
/**************************************************************************************************************
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE CREACIÓN: 18/07/2016
OBJETIVO: Ejecuta la consulta de los datos d euna archivo plano programado
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIÓN
REQUERIMIENTO: SD3055584
DESCRIPCION: Se adiciona columna altura en el plano de cancelaciones
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE CREACIÓN: 19/07/2017
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES:
REQUERIMIENTO:
AUTOR:
EMPRESA:
FECHA DE MODIFICACIÓN:
**************************************************************************************************************************************************/
AS
BEGIN TRY
	SET NOCOUNT ON;
	--VARIABLES PROGRAMACION
	DECLARE @sql VARCHAR(MAX) = ''
	DECLARE @programacionUnaVez INT = 1,
		@programacionDiaria INT = 2,
		@programacionSemanal INT = 3,
		@programacionMensual INT = 4,
		@programacion INT = 0

	--VARIABLES FILTRO
	DECLARE @filtroPoliza INT = 1,
			@filtroCobro INT = 2,
			@filtroCancelacion INT = 3,
			@filtro INT = 0

	----VARIABLE CRITERIO FILTRO POLIZAS
	DECLARE @criterioFiltro VARCHAR(50) = '',
			@criterioPolizaVigente CHAR(1) = 1,
			@criterioPolizaCancelada CHAR(1) = 2,
			@criterioPolizaEmision CHAR(1) = 3

	-- VARIABLES ESTADO COBROS - DETALLE NOVEDAD
	DECLARE @criterioCobroExitoso INT = 1,
			@criterioCobroPendiente INT = 2

	----VARIABLES CAMPOS CONSULTA
	DECLARE @camposConsulta VARCHAR(5000) = '',
			@camposSinBeneficiarios VARCHAR(5000) = 'CONCAT(',
			@camposBeneficiarios VARCHAR(5000)= '',
			@camposVaciosBeneficiarios VARCHAR(5000)= '',
			@separador CHAR(1) = '',
			@totalBeneficiarios INT = 7

	-- VARIABLE CONSULTA
	DECLARE @vistaConsulta VARCHAR(50),
			@whereConsulta VARCHAR(500) = '',
			@whereAseguradora VARCHAR(50),
			@fechaInicio DATE,
			@fechaFin DATE,
			@vistaPolizas VARCHAR(50) = 'VW_SEG_Polizas',
			@vistaReCobros VARCHAR(50) = 'VW_SEG_Recobros',
			@vistaDetalles VARCHAR(50) = 'VW_SEG_DetalleNovPoliza',
			@aseguradora INT = 0

	-- VARIABLES ESTADO POLIZA
	DECLARE @polizaVigente INT = 1,
			@polizaPendientePago INT = 3,
			@polizaCancelada INT = 2


	SELECT	@programacion = tipoProgramacion,
			@filtro = codigoFiltro,
			@criterioFiltro = criterioFiltro,
			@camposConsulta = camposConsulta,
			@aseguradora = idAseguradora,
			@separador = separador,
			@fechaInicio = fechaInicio,
			@fechaFin = fechaFin
	FROM SEG_ProgramacionArchivo WHERE idProgramacion = @idprogramacion


	-- Se extraen las columnas que no son de beneficiario
	SELECT @camposSinBeneficiarios =  COALESCE(@camposSinBeneficiarios + columna + @separador,'')
	FROM [dbo].FN_SEG_ObtenerColumnasConsulta(@camposConsulta, ',') where columna not like ('%_BENEFICIARIO')

	IF LEN(@camposSinBeneficiarios) > 0
		SET @camposSinBeneficiarios = LEFT(@camposSinBeneficiarios,LEN(@camposSinBeneficiarios)-1)

	-- Se extraen las columnas que son de beneficiario
	SELECT @camposBeneficiarios =  COALESCE(@camposBeneficiarios + columna + @separador,''), 
		   @camposVaciosBeneficiarios =  COALESCE(@camposVaciosBeneficiarios + '' + @separador,'')
	FROM [dbo].FN_SEG_ObtenerColumnasConsulta(@camposConsulta, ',') where columna like ('%_BENEFICIARIO')

	IF LEN(@camposBeneficiarios) > 0
		SET @camposBeneficiarios = LEFT(@camposBeneficiarios,LEN(@camposBeneficiarios)-1)

	IF LEN(@camposVaciosBeneficiarios) > 0
		SET @camposVaciosBeneficiarios = LEFT(@camposVaciosBeneficiarios,LEN(@camposVaciosBeneficiarios)-1)

	SET @camposSinBeneficiarios = REPLACE(@camposSinBeneficiarios,@separador,','''+@separador+''','); 
	SET @camposSinBeneficiarios = REPLACE(@camposSinBeneficiarios,'DIRECCION_ASEGURADO','REPLACE(DIRECCION_ASEGURADO,'''+@separador+''','''')')

	IF @programacion = @programacionUnaVez OR @programacion = @programacionDiaria OR  @programacion = @programacionSemanal OR @programacion = @programacionMensual
	BEGIN
		SET @whereAseguradora = ' AND filtroAseguradora = ' + CAST(@aseguradora AS VARCHAR(10))
		IF @aseguradora = 0
		BEGIN
			SET @whereAseguradora = ''
		END
		
		IF @filtro = @filtroPoliza -- Consultar Pólizas - Emisiones
		BEGIN	
			SET @vistaConsulta = @vistaPolizas
			IF CHARINDEX(@criterioPolizaVigente,@criterioFiltro) > 0 -- VIGENTES
			BEGIN		
				SET @whereConsulta = '(filtroEstado IN(' + CAST(@polizaVigente AS CHAR(1)) + ','+ CAST(@polizaPendientePago AS CHAR(1))+'))'			
			END
			ELSE
			BEGIN
				IF CHARINDEX(@criterioPolizaEmision,@criterioFiltro) > 0 -- EMISIONES
				BEGIN
					IF LEN(@whereConsulta) = 0
					BEGIN
						SET @whereConsulta = '(filtroAltura = 1 AND filtroEstado = ' + CAST(@polizaVigente AS VARCHAR(10))+')'
					END
					ELSE
					BEGIN
						SET @whereConsulta = @whereConsulta + ' OR ' + '(filtroAltura = 1 AND filtroEstado = ' + CAST(@polizaVigente AS VARCHAR(10))+')'
					END
				END		
			END
		
			IF CHARINDEX(@criterioPolizaCancelada,@criterioFiltro) > 0 -- CANCELADA
			BEGIN	
				IF LEN(@whereConsulta) = 0
				BEGIN
					SET @whereConsulta = '(filtroEstado = ' + CAST(@polizaCancelada AS CHAR(1))+')'
				END
				ELSE
				BEGIN
					SET @whereConsulta = @whereConsulta + ' OR ' + '(filtroEstado = ' + CAST(@polizaCancelada AS CHAR(1))+')'
				END			
			END
			SET @whereConsulta = @whereConsulta + @whereAseguradora
			IF LEN(@camposBeneficiarios)>0
			BEGIN			
				SET @sql = 'SELECT '+ @camposSinBeneficiarios +  ','''+@separador+''','
				SET @sql += '[dbo].[FN_SEG_ObtenerBeneficiarios]([filtroVenta],'''+@camposBeneficiarios+''','''+@camposVaciosBeneficiarios+''','''+@separador+''','+CAST(@totalBeneficiarios AS VARCHAR(3))+'))'
				SET @sql += ' FROM ' + @vistaConsulta + ' WHERE ' + @whereConsulta
			END
			ELSE 
			BEGIN	
				SET @sql = 'SELECT '+ @camposSinBeneficiarios + ','''') FROM ' + @vistaConsulta + ' WHERE ' + @whereConsulta
			END
		END
		ELSE
		BEGIN
			IF @filtro = @filtroCobro
			BEGIN
				SET @sql = 'SELECT CAMPOS FROM ('
				SET @sql += 'SELECT UNO.CAMPOS, [filtroCobro],[NUMERO_POLIZA],[filtroFecha],[filtroAseguradora]  FROM (SELECT '+REPLACE(@camposSinBeneficiarios,'ALTURA','ALTURACALCULADA')+','''') AS ''CAMPOS'',[NUMERO_POLIZA],[filtroCobro],[filtroFecha],[filtroAseguradora] FROM VW_SEG_DetalleNovPoliza) AS UNO '
				SET @sql += ' UNION ALL '
				SET @sql += 'SELECT UNO.CAMPOS, [filtroCobro],[NUMERO_POLIZA],[filtroFecha],[filtroAseguradora]  FROM (SELECT '+@camposSinBeneficiarios+','''') AS ''CAMPOS'',[NUMERO_POLIZA],[filtroCobro],[filtroFecha],[filtroAseguradora] FROM VW_SEG_Recobros) AS UNO ) AS DOS '
				SET @sql += 'WHERE (filtroFecha BETWEEN '''+FORMAT(@fechaInicio,'yyyy-MM-dd')+''' AND '''+FORMAT(@fechaFin,'yyyy-MM-dd')+''') AND filtroCobro IN ('+@criterioFiltro+')' + @whereAseguradora
				SET @sql += ' ORDER BY [NUMERO_POLIZA],[filtroFecha]  DESC'
			END
			ELSE
			BEGIN
				IF @filtro = @filtroCancelacion
				BEGIN
					SET @sql = 'SELECT '+REPLACE(@camposSinBeneficiarios,'ALTURA','ALTURAREAL')+','''') FROM VW_SEG_DetalleNovPoliza '
					SET @sql += 'WHERE [filtroCobro] = 0 AND filtroCausal IN ('+@criterioFiltro+') AND filtroFecha BETWEEN '''+FORMAT(@fechaInicio,'yyyy-MM-dd')+''' AND '''+FORMAT(@fechaFin,'yyyy-MM-dd')+'''' + @whereAseguradora
				
				END
				ELSE
				BEGIN
					RETURN 0
				END
			END
		END
	END
	ELSE
	BEGIN
		RETURN 0
	END

	TRUNCATE TABLE SEG_ArchivoPlano

	INSERT INTO  SEG_ArchivoPlano (filaDatos)
	EXEC (@sql)	

	RETURN 1
END TRY
BEGIN CATCH
	RETURN 0
END CATCH