
CREATE PROCEDURE [dbo].[PR_SEG_GuardarLogArchivoCancelacion] @idProceso INT
AS
/*************************************************************************************************************************************************
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA CREACIÓN: 05/08/2016
OBJETIVO: Almacenar el log de los archivos de cancelacion procesado por el sistema.
---------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES:
REQUERIMIENTO:
AUTOR:
FECHA DE MODIFICACION:
****************************************************************************************************************************************************/
BEGIN
	SET NOCOUNT ON;
	DECLARE @fechaProceso datetime = GETDATE()
	DECLARE @nombreArchivoCreado VARCHAR(50) = '',@nombreArchivoProcesado VARCHAR(50) = ''
	BEGIN TRY
		SELECT @nombreArchivoCreado = archivoCreado, @nombreArchivoProcesado = archivoProcesado FROM SEG_ProcesoETL WHERE ID = @idProceso
		DELETE SEG_LogArchivoSalidaCancelacionPolizas WHERE [nombreArchivoEntrada] = @nombreArchivoProcesado and [nombreArchivoSalida] = @nombreArchivoCreado
		INSERT INTO SEG_LogArchivoSalidaCancelacionPolizas
			SELECT	[codigoProducto]
					,[numeroCertificadoSeguro]
					,[fechaNovedad]
					,[causalNovedad]
					,[tipoNovedad]
					,[ResultadoProcesamiento]
					,@nombreArchivoProcesado
					,@nombreArchivoCreado
					,GETDATE()
			FROM [SEG_ArchivoSalidaCancelacionPolizas]
	END TRY
	BEGIN CATCH
			UPDATE SEG_ProcesoETL SET	tarea = 'Guardar log', 
										errorTarea = 'BD: '+ ERROR_MESSAGE()
			WHERE id = @idProceso
	END CATCH
END