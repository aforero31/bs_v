


CREATE PROCEDURE [dbo].[PR_SEG_IncrementoIPC] 
/**************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: Jetlhen Roa
EMPRESA: Unión temporal FS-BAC-2013.
FECHA CREACIÓN:  27/04/2016
OBJETIVO: Generar Incremento de IPC
-----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se elimina el registro del log de IPC ya que se tiene la tabla de auditoria y paramtrización del
				mes de incremento de IPC.
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 14/06/2016
-----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se toma los meses de periodicidad de la tabla SEG_Venta.
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 06/07/2016
-----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se ajusta el cálculo de las pólizas mensuales que cumplan más de 12 meses de vigencia.
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 22/07/2016
-----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se realiza la validación del que el IPC se encuentre paraemtrizado al año en curso.
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 29/07/2016
-----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se ajusta validación de polizas anuales para contar un año a partir del ultimo incremnto ipc
                y aplicar el ipc siguiente al ultimo aplicado
REQUERIMIENTO:  SD5086093
AUTOR: Paulo Mora
EMPRESA: Softwareone.
FECHA DE MODIFICACIÓN: 01/08/2022
***************************************************************************************************************/	
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		DECLARE @DiasCobro TABLE(NumeroDia INT)
		DECLARE @Siguiente INT = 1
		DECLARE @FechaUltimaEjecucion DATETIME = (SELECT FechaEjecucionETL FROM [dbo].[SEG_FechaEjecucionETL] where Prefijo = 'COB')
		DECLARE @FechaHoy DATETIME =(SELECT GETDATE())
		DECLARE @DiaEjecucion INT = isnull(DATEPART(DAY,@FechaUltimaEjecucion),DATEPART(DAY,getdate()-1))
		DECLARE @DiaEjecucionHoy INT = DATEPART(DAY,@FechaHoy)
		DECLARE @NUMMES INT=(select DATEPART(MONTH,@FechaHoy))
		DECLARE @MesIncremento INT = (SELECT [valor] FROM [SEG_Parametro] WHERE [idParametro] = 53)
		DECLARE @anoActual INT = YEAR(GETDATE())
		DECLARE @valorIPC DECIMAL(9,2) = ISNULL((SELECT ipc FROM SEG_IncrementoIPC WHERE ano = @anoActual),0)
		DECLARE @estadoProceso CHAR(3) = 'PRO', @estadoCancelado CHAR(3) = 'CAN'
		
		IF @MesIncremento IS NULL
		BEGIN
			SET @MesIncremento = 1
		END
	
		DECLARE @PolizasConIncrementoIPC TABLE
						(idVenta int,
						fechaCreacion datetime,
						valorAnterior decimal(18,2),
						valorActual decimal(18,2),
						IPC_Anterior int,
						IPC_Actual int)

		DECLARE @DAYSYEAR INT = 365
		DECLARE @FechaEjecucion DATETIME = @FechaUltimaEjecucion
		DECLARE @fechasCobro TABLE (dia INT, mes INT, anio INT)
		DECLARE @SiguienteAnuales INT = 1

		--CICLO QUE DETERMINA DIAS DE COBRO

		IF CONVERT(DATE, @FechaUltimaEjecucion) < CONVERT(DATE, @FechaHoy)
		BEGIN
			
			WHILE @SiguienteAnuales = 1
			BEGIN

				SET @FechaEjecucion = DATEADD(DAY, 1, @FechaEjecucion)

		 		INSERT INTO @fechasCobro VALUES(DATEPART(DAY, @FechaEjecucion), DATEPART(MONTH, @FechaEjecucion), DATEPART(YEAR, @FechaEjecucion))
				IF CAST(@FechaEjecucion AS DATE) = CAST(@FechaHoy AS DATE)	
				BEGIN		
					SET @SiguienteAnuales = 0	
				END	
			END
					
			IF @NUMMES = @MesIncremento --SI ES MES DE INCREMENTO IPC PARAMETRIZADO
			BEGIN

				WHILE @Siguiente = 1
				BEGIN
					SET @DiaEjecucion += 1
					IF @DiaEjecucion = 32
					BEGIN
						SET @DiaEjecucion = 1
					END 

		 			INSERT INTO @DiasCobro VALUES(@DiaEjecucion)
					IF @DiaEjecucion = @DiaEjecucionHoy	
					BEGIN		
						SET @Siguiente = 0	
					END		
				END
				
				INSERT INTO @PolizasConIncrementoIPC
				SELECT DISTINCT vent.idVenta, vent.fechaCreacion,vent.valorPoliza AS valorAnterior,(valorPoliza + (valorPoliza* (@valorIPC/100))) AS valorActual ,vent.ultimoIPC AS IPC_Anterior, @anoActual AS IPC_Actual
				FROM dbo.SEG_Venta vent (NOLOCK)			
				WHERE codigoEstadoPoliza in (1,3)
				AND DATEPART(DAY,vent.fechaCreacion) IN (SELECT NumeroDia FROM @DiasCobro)
				AND DATEDIFF(MONTH, CAST(vent.fechaCreacion AS DATE), CAST(@FechaHoy AS DATE)) >= 12
				AND vent.ultimoIPC <= datepart(year,@FechaHoy)-1						
				AND vent.numMesesPeriodicidad <> 12	
			END		
							
			INSERT INTO @PolizasConIncrementoIPC
				SELECT DISTINCT vent.idVenta, vent.fechaCreacion,vent.valorPoliza AS valorAnterior,(vent.valorPoliza + (vent.valorPoliza* (vent.valorIPC/100))) AS valorActual ,vent.ultimoIPC AS IPC_Anterior, vent.anioIPC AS IPC_Actual
				FROM
				(SELECT X.idVenta, X.fechaCreacion, X.valorPoliza, X.ultimoIPC,  FC.anio AS anioIPC, ISNULL((SELECT ipc FROM SEG_IncrementoIPC WHERE ano = FC.anio),0) AS valorIPC
				 FROM
			    (SELECT idVenta, fechaCreacion,valorPoliza,ultimoIPC 
				FROM dbo.SEG_Venta  (NOLOCK)			
				WHERE codigoEstadoPoliza in (1,3)
				AND numMesesPeriodicidad = 12) AS X
				INNER JOIN @fechasCobro FC
				ON (X.ultimoIPC + 1) = FC.anio
				AND DATEPART(MONTH,X.fechaCreacion) = FC.mes
				AND DATEPART(DAY, X.fechaCreacion) = FC.dia) AS vent


			UPDATE @PolizasConIncrementoIPC
				set valorActual=dbo.FN_SEG_RedondeoCentavos (valorActual)

			UPDATE a 
			SET a.valorPoliza = b.valorActual,
				a.UltimoIPC =  b.IPC_Actual	
			FROM dbo.SEG_Venta a (NOLOCK)
			INNER JOIN @PolizasConIncrementoIPC b On a.idVenta=b.idVenta
		END
		RETURN 1
	END TRY
	BEGIN CATCH
		UPDATE SEG_ProcesoETL SET estado = @estadoCancelado ,errorTarea = 'BD: '+ ERROR_MESSAGE() WHERE estado = @estadoProceso and prefijo = 'COB'
		RETURN 0
	END CATCH
END