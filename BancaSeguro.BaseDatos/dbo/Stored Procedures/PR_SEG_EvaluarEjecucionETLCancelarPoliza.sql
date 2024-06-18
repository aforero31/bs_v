
CREATE PROCEDURE [dbo].[PR_SEG_EvaluarEjecucionETLCancelarPoliza]

/* *********************************************************************************************************************************************
MODIFICACIONES:Evalúa si el día de hoy es hábil o no, según la tabla de días hábiles (calendario) dbo.SEG_DiaHabil y si hay dato en SEG_IncrementoIPC
			para el año en curso
			Nota: esta tabla no es la del Bco.
			Mensaje que retorna una palabra (Si/No)
			- El mensaje es Si cuando hoy es un día hábil.
			- Si es un día no hábil el mensaje es Noy.
REQUERIMIENTO: HU006-RecibirArchivoCancelacionPolizas
AUTOR: Jetlhen Yeny Roa Castañeda
EMPRESA: UT - BAC
FECHA DE MODIFICACIÓN: 23/03/2016
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Ajustar el nombre de la nueva tabla para el manejo de la ejecución de la ETL SEG_FechaEjecucionETL.
REQUERIMIENTO: HU006-RecibirArchivoCancelacionPolizas
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 01/06/2016
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Modificar la evaluación de la ejecución de la ETL.
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 05/08/2016
**********************************************************************************************************************************************/
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @fechaProceso date,
			@prefijoETL CHAR(3) = 'CAN',
			@estadoProceso CHAR(3) = 'PRO',
			@estadoCancelado CHAR(3) = 'CAN',
			@idProceso BIGINT = 0,
			@tarea VARCHAR(100) = 'Inicio ejecución'
	BEGIN TRY
		SET @fechaProceso=convert(date,getdate())	
		IF EXISTS (SELECT FECHA FROM dbo.SEG_DiaHabil a WHERE fecha=@fechaProceso)
		BEGIN	
			--Registro inicio proceso
			INSERT INTO SEG_ProcesoETL(prefijo,fechaProceso,fechaInicioEjecucion,tarea,estado)
			VALUES (@prefijoETL,@fechaProceso,GETDATE(),@tarea,'')
			SET @idProceso = SCOPE_IDENTITY()

			--Evaluar si es la primera ejecución
			IF EXISTS (SELECT 1 FROM dbo.SEG_FechaEjecucionETL a WHERE prefijo = 'COB' AND FechaEjecucionETL IS NULL)
			BEGIN
				UPDATE [dbo].SEG_FechaEjecucionETL SET FechaEjecucionETL = GETDATE()-1 where prefijo = @prefijoETL 
			END
			ELSE
			BEGIN
				IF EXISTS (SELECT 1 FROM SEG_ProcesoETL WHERE prefijo = @prefijoETL AND estado = @estadoProceso)
				BEGIN

					UPDATE SEG_ProcesoETL SET errorTarea =  'Hay un proceso de cancelación en ejecución', estado = @estadoCancelado
					WHERE id = @idProceso
					SET @idProceso = 0
				END
				ELSE
				BEGIN
					UPDATE SEG_ProcesoETL SET estado = @estadoProceso WHERE id = @idProceso
				END
			END 	
		END
		RETURN @idProceso
	END TRY
	BEGIN CATCH
		IF @idProceso > 0
		BEGIN		
			UPDATE SEG_ProcesoETL SET errorTarea = 'BD: '+ ERROR_MESSAGE(), estado = @estadoCancelado
			WHERE id = @idProceso
		END
		RETURN 0
	END CATCH
END