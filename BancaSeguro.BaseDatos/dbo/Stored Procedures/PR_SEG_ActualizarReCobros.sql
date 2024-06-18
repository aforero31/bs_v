
CREATE PROCEDURE [dbo].[PR_SEG_ActualizarReCobros]
AS
/*----------------------------------------------------------------------------------------------------------------------------------------------------
NOMBRE DEL PROGRAMA: [PR_SEG_ActualizarReCobros]
DESCRIPCION: Procedimiento que verifica desde el archivo de resultados COBIS contra los cobros enviados del dia anterior si es el caso donde actualiza 
la tabla de recobros con sus respectivos contadores, activo, estado. Ademas actualiza de la tabla venta el ultimo periodo cobrado. - HU005- Generar recobros
REQUERIMIENTO: SD1588485
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE CREACIÓN: 27/02/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agregan condiciones que la poliza se encuentra pagada(1) o pendiente de pago(3) para realizar los cambios a la misma, se agrega 
query para la actualizacion de la poliza cuando este pagada y aya un recobro
REQUERIMIENTO: Refinamiento Sprint 2
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 04/03/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agrega validación de días hábiles y se incluyo manejo transaccional.
REQUERIMIENTO: SD1588485
AUTOR: Jetlhen Yeny Roa Castañeda
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 22/03/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se inserta en la tabla SEG_DetalleNovedadPoliza los pagos
REQUERIMIENTO: SD1588485
AUTOR: Jetlhen Yeny Roa Castañeda
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 23/03/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se evita revisar por el valorpoliza y evaluar día hábil
REQUERIMIENTO: SD1588485
AUTOR: Jetlhen Yeny Roa Castañeda
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 28/03/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agrega al código que valide el campo activo de la tabla SEG_ArchivoResultadoCobis y si es 1 los tenga en cuenta para el recobro.
REQUERIMIENTO: SD1588485 - HU005-Recibir archivosResultadoCobis
AUTOR: Luis Andrés Combariza Ibarra - Jetlhen Yeny Roa Castañeda
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 21/04/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agrega top 1 a la consulta de SEG_Recobro
REQUERIMIENTO: SD1588485
AUTOR: Wilver Guillermo Zaldúa Espíndola - Luis Andrés Combariza - Jetlhen Yeny Roa Castañeda
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 28/04/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se ajusta el SP para que registre la fecha del último periodo de pago en la tabla SEG_DetalleNovedadPoliza y lógica del proceso
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 15/06/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se aumenta el contador de la altura cuando un cobro exitoso para la venta en la tabla SEG_Venta
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 06/07/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se ajusta el registro de la novedad de pago para almacenar el campo origen de la novedad
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 13/07/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se modifica la fecha en que se registra la novedad de pago exitoso
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 03/08/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se modifica el orden en que se lee el archivo de resultado COBIS
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 22/09/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se busca el ultimo real periodo de cobro activo
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 28/11/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se optimizó el proceso de recobros para mejorar los tiempos de procesamiento
REQUERIMIENTO: SD1807985
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 09/12/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se optimizó el proceso de recobros para mejorar los tiempos de procesamiento
REQUERIMIENTO: SD1807985
AUTOR: César Blandón
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 11/05/2017
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se busca el idRecobro mínimo de la fecha mínima y el idRecobro máximo de la fecha máxima 
para generar correctamente el periodo de cobro.
REQUERIMIENTO: SD3100402
AUTOR: César Blandón
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 14/08/2017
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se elimina la consulta a la tabla seg_temporal ya que existe en pruebas y no en produccion
REQUERIMIENTO: SD3100402
AUTOR: César Blandón
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 25/09/2017
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se ajusta select de recobros para que tenga en cuenta el consecutivo con el fin de evitar el error de subquery follows =, !=, <, <= , >, >= 
REQUERIMIENTO: SD3100402
AUTOR: Enrique Rivera
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 07/11/2017
----------------------------------------------------------------------------------------------------------------------------------------------------*/
BEGIN
DECLARE
	@consecutivoPoliza VARCHAR(50), 
	@numeroCuenta VARCHAR(50), 
	@codigoProducto INT,
	@valorPoliza DECIMAL(18,2),
	@consecutivo INT ,
	@convenio INT,
	@contador INT = 1,	
	@contadorProceso INT = 0,	
	@PendientePago INT =3,	
	@EstadoVigentePoliza int=1,--SELECT * FROM [dbo].[SEG_EstadoPoliza]
	@idVenta INT,
	@periodoCobro DATE,
	@polizaControl VARCHAR(50)='0',
	@incrementarCobros BIT,
	@totalCobros INT = 0,
	@totalRecobros INT = 0,
	@idMinRecobro INT = 0,
	@idMaxRecobro INT = 0,
	@peridoCobroMin DATE,
	@peridoCobroMax DATE,
	@activoResultado BIT,
	@codigoTipoNovedadPago INT = 3,
	@idCausalNovedad INT = 0,
	@idTipoNovedad INT = 0,
	@fechaUltimoCobro DATETIME,
	@fechaMinimaRecobro DATETIME,
	@fechaMaximaRecobro DATETIME

	BEGIN TRANSACTION 
		BEGIN TRY
			BEGIN 
				DECLARE @resultadoCobisOrdenado TABLE
				(
					id	INT IDENTITY(1,1),
					fechaProceso VARCHAR(50),	
					codigoProducto VARCHAR(50),
					numeroCuenta VARCHAR(50),
					valorRecaudo DECIMAL(18,2),
					codigoConvenio INT,
					referencia VARCHAR(50),
					error VARCHAR(50),
					activo BIT
				)

				INSERT INTO @resultadoCobisOrdenado 
				SELECT fechaProceso,codigoProducto,numeroCuenta,valorRecaudo,codigoConvenio,referencia,error, activo FROM SEG_ArchivoResultadoCobis ORDER BY referencia,valorRecaudo
				
				TRUNCATE TABLE SEG_ArchivoResultadoCobis

				INSERT INTO SEG_ArchivoResultadoCobis 
				SELECT fechaProceso,codigoProducto,numeroCuenta,valorRecaudo,codigoConvenio,referencia,error, activo FROM @resultadoCobisOrdenado ORDER BY id
				
				SET @idTipoNovedad = ISNULL((SELECT idTipoNovedad FROM SEG_TipoNovedad WHERE codigoTipoNovedad = @codigoTipoNovedadPago),0)
				SET @idCausalNovedad = ISNULL((SELECT TOP 1 SEG_CausalNovedad.idCausalNovedad FROM SEG_CausalNovedad WHERE idTipoNovedad = @idTipoNovedad),0) 
				SET @fechaUltimoCobro = ISNULL((SELECT fechaEjecucionETL FROM SEG_FechaEjecucionETL WHERE Prefijo = 'COB'),GETDATE())
				DECLARE cur CURSOR FOR	
					SELECT	referencia1 AS consecutivoPoliza, 
							ctaBancoOrigen AS numeroCuenta, 
							productoOrigen AS codigoProducto,
							CONVERT(DECIMAL(18,2),montoEfectivo) AS valorPoliza,
							secuencial AS consecutivo,
							convenio,
							periodoCobro
					FROM	SEG_ArchivoCobro  (NOLOCK)
					ORDER BY secuencial
					
				OPEN cur
				FETCH NEXT FROM cur INTO @consecutivoPoliza,@numeroCuenta,@codigoProducto,@valorPoliza,@consecutivo,@convenio, @periodoCobro
				WHILE @@FETCH_STATUS = 0 
				BEGIN	
					

					IF @polizaControl <> @consecutivoPoliza
					BEGIN
						SET @polizaControl = @consecutivoPoliza
						SET @incrementarCobros = 0
					END
					
					
					SELECT @totalCobros = ISNULL(COUNT(1),0), @peridoCobroMax = MAX(periodoCobro) FROM SEG_ArchivoCobro (NOLOCK) WHERE referencia1 = @polizaControl					
					SELECT @fechaMinimaRecobro = (SELECT MIN(fechaUltimoPeriodo) FROM SEG_Recobro WHERE consecutivoPoliza = @polizaControl AND activo = 1)
					SELECT @fechaMaximaRecobro = (SELECT MAX(fechaUltimoPeriodo) FROM SEG_Recobro WHERE consecutivoPoliza = @polizaControl AND activo = 1)
					
					SELECT @totalRecobros = ISNULL(COUNT(1),0), 
					@idMinRecobro = (SELECT idRecobro FROM SEG_Recobro WHERE fechaUltimoPeriodo=@fechaMinimaRecobro AND consecutivoPoliza = @polizaControl), 
					@idMaxRecobro = (SELECT idRecobro FROM SEG_Recobro WHERE fechaUltimoPeriodo=@fechaMaximaRecobro AND consecutivoPoliza = @polizaControl),
					@peridoCobroMin = MIN(fechaUltimoPeriodo) 					
					FROM SEG_Recobro (NOLOCK) WHERE consecutivoPoliza = @polizaControl AND activo = 1
					SELECT @idVenta = sv.idVenta , @valorPoliza = sv.valorPoliza FROM dbo.SEG_Venta sv (NOLOCK) WHERE	@polizaControl = consecutivo	
							
					IF EXISTS(SELECT id FROM SEG_ArchivoResultadoCobis SAR (NOLOCK)	
								WHERE SAR.referencia = @consecutivoPoliza AND SAR.id = @contador) 
					BEGIN
						SELECT @activoResultado = SAR.activo FROM SEG_ArchivoResultadoCobis SAR (NOLOCK)	
								WHERE SAR.referencia = @consecutivoPoliza AND SAR.id = @contador					
						
						IF @activoResultado = 1 						
						BEGIN
							IF @totalCobros = @totalRecobros  -- Se aumenta el contador del recobre más reciente
							BEGIN
								IF @incrementarCobros = 0 --Se veifica que el aumento sea una vez cuando hay más de 1 recobro pendiente
								BEGIN
									UPDATE SEG_Recobro 									
									SET contador+= 1		
									FROM SEG_Recobro (NOLOCK)					
									WHERE idRecobro = @idMaxRecobro
									SET @incrementarCobros = 1
								END
							END
							ELSE --No existe un recobro apra el perido actual, se crea un nuevo recobro																																					BEGIN
							BEGIN
								INSERT SEG_Recobro
								(
									idEstadoCobro,
									codigoProducto,
									numeroCuenta,
									valorRecaudo,
									codigoConvenio,
									consecutivoPoliza,
									fechaUltimoPeriodo,
									contador,
									activo,
									seModifico
								)
								VALUES
								(
									@PendientePago, -- idEstadoCobro - int
									@codigoProducto, -- codigoProducto - int
									@numeroCuenta, -- numeroCuenta - varchar
									@valorPoliza, -- valorRecaudo - decimal
									@convenio, -- codigoConvenio - int
									@consecutivoPoliza, -- consecutivoPoliza - varchar
									@peridoCobroMax, --periodo de cobro
									1, -- contador - int
									1, -- activo - bit
									1 -- seModifico - bit
								)
								SET @incrementarCobros = 1
							END				
							-- Actualizar venta a pendiente de pago
							UPDATE SEG_Venta SET codigoEstadoPoliza = @PendientePago
							FROM SEG_Venta (NOLOCK)
							WHERE idVenta = @idVenta AND codigoEstadoPoliza IN (1,3)	
						END
						SET @contador += 1
					END
					ELSE
					BEGIN	
						IF @totalCobros >= @totalRecobros AND @totalRecobros > 0
						BEGIN						
							UPDATE SEG_Recobro SET activo = 0
							FROM SEG_Recobro (NOLOCK)
							WHERE idRecobro = @idMinRecobro

							UPDATE SEG_Venta SET codigoEstadoPoliza = @PendientePago
							FROM SEG_Venta (NOLOCK)
							WHERE idVenta = @idVenta AND codigoEstadoPoliza IN (1,3)
							
							SET @totalRecobros -= 1		
						END
						IF @totalRecobros = 0
						BEGIN						
							SET @peridoCobroMin = @periodoCobro
							UPDATE SEG_Venta SET codigoEstadoPoliza = @EstadoVigentePoliza
							FROM SEG_Venta (NOLOCK)
							WHERE idVenta = @idVenta AND codigoEstadoPoliza IN (1,3)	
						END	
						-- Se registra el pago
						INSERT INTO SEG_DetalleNovedadPoliza
						(
							idVenta,
							fechaNovedad,
							fechaUltimoPeriodoPago,
							idCausalNovedad
						)						

						VALUES
						(
							@idVenta,
							@fechaUltimoCobro,
							@peridoCobroMin,
							@idCausalNovedad								
						)

						UPDATE SEG_Venta SET altura += 1
						FROM SEG_Venta (NOLOCK)
						WHERE idVenta = @idVenta

					END
					FETCH NEXT FROM cur INTO @consecutivoPoliza,@numeroCuenta,@codigoProducto,@valorPoliza,@consecutivo,@convenio,@periodoCobro
				END
				CLOSE cur
				DEALLOCATE cur
				COMMIT TRANSACTION   
			END            
		END TRY
		BEGIN CATCH		
			DECLARE @ErrorMessage NVARCHAR(4000);
			DECLARE @ErrorSeverity INT;
			DECLARE @ErrorState INT;
			SET @ErrorMessage = ERROR_MESSAGE();
			ROLLBACK TRANSACTION 
			RAISERROR (@ErrorMessage,
				   @ErrorSeverity,
				   @ErrorState 
				   );       
		END CATCH;
END
