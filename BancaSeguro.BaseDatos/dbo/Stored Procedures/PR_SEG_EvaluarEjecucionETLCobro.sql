
CREATE PROCEDURE [dbo].[PR_SEG_EvaluarEjecucionETLCobro]
AS
/*************************************************************************************************************************************************
REQUERIMIENTO:HU004.1- Generar cobros días hábiles sin recobros.
AUTOR: Jetlhen Roa
EMPRESA: Unión temporal FS-BAC-2013.
FECHA CREACIÓN: 23/02/2016
OBJETIVO:Evalúa si el día de hoy es hábil o no, según la tabla de días hábiles (calendario) 
			dbo.SEG_DiaHabil
			Nota: esta tabla no es la del Bco.
			Mensaje que retorna una palabra (Si/No)
			- El mensaje es Si cuando hoy es un día hábil.
			- Si es un día no hábil el mensaje es Noy.
---------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES:Se le indica que si la tabla [SEG_FechaEjecucionETL] no tiene dato le dejé la fecha de ayer y se suprime
				el uso de la variable @mensaje		
REQUERIMIENTO:
AUTOR:
FECHA DE MODIFICACION:25/02/2016
---------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES:Evaluar que la tabla de SEG_ArchivoResultadoCobis tenga datos es decir, que COBIS dejo archivo en la mañana
y que ahorita en la noche si puede funcionar la ETL de cobro.
REQUERIMIENTO:HU004.1- Generar cobros días hábiles sin recobros.
AUTOR:Jetlhen Yeny Roa Castañeda
FECHA DE MODIFICACION:29/02/2016
---------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Ajustar el nombre de la nueva tabla para el manejo de la ejecución de la ETL SEG_FechaEjecucionETL.
REQUERIMIENTO: SD1588485-HU004.1- Generar cobros días hábiles sin recobros.
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 01/06/2016
---------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Ajustar el proceso para que evalue los siguientes escenarios en la validación de la Ejecución de 
la ETL y control del proceso: 
		1. Si es un día hábil
		2. Si hay una respuesta COBIS pendiente de un cabro anterior
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 28/07/2016
****************************************************************************************************************************************************/
BEGIN
	SET NOCOUNT ON;

	DECLARE @fechaProceso date,
			@prefijoETL CHAR(3) = 'COB',
			@estadoProceso CHAR(3) = 'PRO',
			@estadoPendiente CHAR(3) = 'PEN',
			@estadoCancelado CHAR(3) = 'CAN',
			@idProceso BIGINT = 0,
			@tarea VARCHAR(100) = 'Inicio ejecución'

	BEGIN TRY
		SET @fechaProceso=convert(date,getdate())	
		--Validar día hábil
		IF EXISTS (SELECT FECHA FROM dbo.SEG_DiaHabil a WHERE fecha=@fechaProceso)
		BEGIN				
			--Registro inicio proceso
			INSERT INTO SEG_ProcesoETL(prefijo,fechaProceso,fechaInicioEjecucion,tarea,estado)
			VALUES (@prefijoETL,@fechaProceso,GETDATE(),@tarea,'')
			SET @idProceso = SCOPE_IDENTITY()

			--Evaluar si es la primera ejecución
			IF EXISTS (SELECT 1 FROM dbo.SEG_FechaEjecucionETL a WHERE prefijo = 'COB' AND FechaEjecucionETL IS NULL)
			BEGIN
				UPDATE [dbo].SEG_FechaEjecucionETL SET FechaEjecucionETL = GETDATE()-1 where prefijo = 'COB' 
			END
			ELSE
			BEGIN
				IF EXISTS (SELECT 1 FROM SEG_ProcesoETL WHERE prefijo = @prefijoETL AND estado IN ( @estadoPendiente,@estadoProceso))
				BEGIN

					UPDATE SEG_ProcesoETL SET	errorTarea = CASE WHEN estado = @estadoPendiente THEN 'Proceso de cobro anterior pendiente de respuesta de COBIS'
																  ELSE 'Hay un proceso de cobro en ejecución' END,
												estado = @estadoCancelado
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