CREATE PROCEDURE [dbo].[PR_SEG_GuardarLogResultadoCobis] @idProceso INT
AS
/*************************************************************************************************************************************************
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA CREACIÓN: 04/08/2016
OBJETIVO: Almacenar el log de los archivos de resultados Cobis procesados por el sistema.
---------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES:
REQUERIMIENTO:
AUTOR:
FECHA DE MODIFICACION:
****************************************************************************************************************************************************/
BEGIN
	SET NOCOUNT ON;
	DECLARE @fechaProceso datetime = GETDATE()
	DECLARE @nombreArchivo VARCHAR(50) = ''
	BEGIN TRY
		SELECT @nombreArchivo = archivoProcesado FROM SEG_ProcesoETL WHERE ID = @idProceso
		
		DELETE [SEG_LogResultadoCobis] WHERE [nombreArchivoCOBIS] = @nombreArchivo

		INSERT INTO [dbo].[SEG_LogResultadoCobis]
				   ([fechaProceso]
				   ,[codigoProducto]
				   ,[numeroCuenta]
				   ,[valorRecaudo]
				   ,[codigoConvenio]
				   ,[referencia]
				   ,[error]
				   ,[nombreArchivoCOBIS]
				   ,[fechaArchivo])

			SELECT [fechaProceso]
				  ,[codigoProducto]
				  ,[numeroCuenta]
				  ,[valorRecaudo]
				  ,[codigoConvenio]
				  ,[referencia]
				  ,[error]
				  ,@nombreArchivo
				  ,@fechaProceso
			FROM [SEG_ArchivoResultadoCobis]
	END TRY
	BEGIN CATCH
			UPDATE SEG_ProcesoETL SET	tarea = 'Guardar log', 
										errorTarea = 'BD: '+ ERROR_MESSAGE()
			WHERE id = @idProceso
	END CATCH
END