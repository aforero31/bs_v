CREATE PROCEDURE [dbo].[PR_MIG_VerificarDuplicados] @nombreTabla  [varchar](50) 
AS
/*-------------------------------------------------------------------------
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE CREACIÓN: 31/08/2016
OBJETIVO: 
-------------------------------------------------------------------------
MODIFICACION
REQUERIMIENTO: SD1859616
PROPOSITO: Se incluye la verificación de la venta y recobro en las tablas 
		   SEG_Venta y SEG_Recobro para evitar duplicados
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACION : 2017-07-25
-------------------------------------------------------------------------
MODIFICACIONES:
REQUERIMIENTO:
AUTOR:
EMPRESA:
FECHA DE MODIFICACIÓN:
-------------------------------------------------------------------------*/
BEGIN
	BEGIN TRY
		BEGIN TRAN
		SET NOCOUNT ON;
		DECLARE @totalRegistros INT = 0		
			IF @nombreTabla = 'SEG_Venta'
			BEGIN
				SET @totalRegistros = ISNULL((SELECT COUNT(1) FROM [MIG_VentaError]),0)
				IF @totalRegistros = 0
				BEGIN
					INSERT INTO [dbo].[MIG_VentaError]
					   ([id]
					   ,[numeroPoliza]
					   ,[fechaCreacion]
					   ,[tipoIdentificacionAsegurado]
					   ,[identificacionAsegurado]
					   ,[primerNombre]
					   ,[SegundoNombre]
					   ,[primerApellido]
					   ,[segundoApellido]
					   ,[codigoGenero]
					   ,[fechaNacimiento]
					   ,[ciudadNacimiento]
					   ,[departamentoResidencia]
					   ,[ciudadResidencia]
					   ,[direccionResidencia]
					   ,[telefono]
					   ,[correo]
					   ,[valorPoliza]
					   ,[tipoCuenta]
					   ,[codigoProducto]
					   ,[codigoPlan]
					   ,[codigoConvenio]
					   ,[periodicidad]
					   ,[numeroCuenta]
					   ,[codigoOficina]
					   ,[nombreOficina]
					   ,[identificacionAsesor]
					   ,[nombreAsesor]
					   ,[altura]
					   ,[mensajeError])
					   SELECT 
						 duplicados.[id]
						,duplicados.[numeroPoliza]
						,duplicados.[fechaCreacion]
						,duplicados.[tipoIdentificacionAsegurado]
						,duplicados.[identificacionAsegurado]
						,duplicados.[primerNombre]
						,duplicados.[SegundoNombre]
						,duplicados.[primerApellido]
						,duplicados.[segundoApellido]
						,duplicados.[codigoGenero]
						,duplicados.[fechaNacimiento]
						,duplicados.[ciudadNacimiento]
						,duplicados.[departamentoResidencia]
						,duplicados.[ciudadResidencia]
						,duplicados.[direccionResidencia]
						,duplicados.[telefono]
						,duplicados.[correo]
						,duplicados.[valorPoliza]
						,duplicados.[tipoCuenta]
						,duplicados.[codigoProducto]
						,duplicados.[codigoPlan]
						,duplicados.[codigoConvenio]
						,duplicados.[periodicidad]
						,duplicados.[numeroCuenta]
						,duplicados.[codigoOficina]
						,duplicados.[nombreOficina]
						,duplicados.[identificacionAsesor]
						,duplicados.[nombreAsesor]
						,duplicados.[altura]
						,duplicados.mensajeError
						FROM (	
							SELECT venTem.[id]
							,venTem.[numeroPoliza]
							,FORMAT(venTem.[fechaCreacion], 'yyyyMMdd') AS [fechaCreacion]
							,venTem.[tipoIdentificacionAsegurado]
							,venTem.[identificacionAsegurado]
							,venTem.[primerNombre]
							,venTem.[SegundoNombre]
							,venTem.[primerApellido]
							,venTem.[segundoApellido]
							,venTem.[codigoGenero]
							,FORMAT(venTem.[fechaNacimiento], 'yyyyMMdd') AS [fechaNacimiento]
							,venTem.[ciudadNacimiento]
							,venTem.[departamentoResidencia]
							,venTem.[ciudadResidencia]
							,venTem.[direccionResidencia]
							,venTem.[telefono]
							,venTem.[correo]
							,venTem.[valorPoliza]
							,venTem.[tipoCuenta]
							,venTem.[codigoProducto]
							,venTem.[codigoPlan]
							,venTem.[codigoConvenio]
							,venTem.[periodicidad]
							,venTem.[numeroCuenta]
							,venTem.[codigoOficina]
							,venTem.[nombreOficina]
							,venTem.[identificacionAsesor]
							,venTem.[nombreAsesor]
							,venTem.[altura]
							,'***Numero de poliza duplicada' AS mensajeError
							FROM MIG_VentaTemp venTem
							INNER JOIN (SELECT numeroPoliza FROM MIG_VentaTemp GROUP BY numeroPoliza HAVING COUNT(numeroPoliza) > 1) AS dup 
							ON dup.numeroPoliza = venTem.numeroPoliza
							UNION ALL
							SELECT venTem.[id]
							,venTem.[numeroPoliza]
							,FORMAT(venTem.[fechaCreacion], 'yyyyMMdd') AS [fechaCreacion]
							,venTem.[tipoIdentificacionAsegurado]
							,venTem.[identificacionAsegurado]
							,venTem.[primerNombre]
							,venTem.[SegundoNombre]
							,venTem.[primerApellido]
							,venTem.[segundoApellido]
							,venTem.[codigoGenero]
							,FORMAT(venTem.[fechaNacimiento], 'yyyyMMdd') AS [fechaNacimiento]
							,venTem.[ciudadNacimiento]
							,venTem.[departamentoResidencia]
							,venTem.[ciudadResidencia]
							,venTem.[direccionResidencia]
							,venTem.[telefono]
							,venTem.[correo]
							,venTem.[valorPoliza]
							,venTem.[tipoCuenta]
							,venTem.[codigoProducto]
							,venTem.[codigoPlan]
							,venTem.[codigoConvenio]
							,venTem.[periodicidad]
							,venTem.[numeroCuenta]
							,venTem.[codigoOficina]
							,venTem.[nombreOficina]
							,venTem.[identificacionAsesor]
							,venTem.[nombreAsesor]
							,venTem.[altura]
							,'***Numero de poliza ya existe en el sistema' AS mensajeError
							FROM MIG_VentaTemp venTem INNER JOIN dbo.SEG_Venta sv
							ON sv.consecutivo = venTem.numeroPoliza
					  ) AS duplicados	
					  ORDER BY duplicados.id				  
					  DELETE MIG_VentaTemp FROM MIG_VentaTemp venTem
					  INNER JOIN 
					  (
							SELECT venTem.[numeroPoliza]
							FROM MIG_VentaTemp venTem
							INNER JOIN (SELECT numeroPoliza FROM MIG_VentaTemp GROUP BY numeroPoliza HAVING COUNT(numeroPoliza) > 1) AS dup 
							ON dup.numeroPoliza = venTem.numeroPoliza
							UNION ALL
							SELECT venTem.[numeroPoliza]
							FROM MIG_VentaTemp venTem INNER JOIN dbo.SEG_Venta sv
							ON sv.consecutivo = venTem.numeroPoliza
					  ) AS dup 
					  ON dup.numeroPoliza = venTem.numeroPoliza
					SET @totalRegistros = ISNULL((SELECT COUNT(1) FROM [MIG_VentaError]),0)
				END
			END

			IF @nombreTabla = 'SEG_Recobro'
			BEGIN
				SET @totalRegistros = ISNULL((SELECT COUNT(1) FROM [MIG_RecobroError]),0)
				IF @totalRegistros = 0
				BEGIN
					INSERT INTO MIG_RecobroError (id,numeroPoliza,fechaCobro,intentos ,mensajeError)
					SELECT recTem.id, recTem.numeroPoliza, FORMAT(recTem.fechaCobro,'yyyyMMdd'), recTem.intentos, '***Recobro duplicado' FROM MIG_RecobroTemp recTem
					INNER JOIN (
					SELECT numeroPoliza, fechaCobro FROM MIG_RecobroTemp
					GROUP BY numeroPoliza, fechaCobro
					HAVING COUNT(numeroPoliza) > 1) as dup ON dup.numeroPoliza = recTem.numeroPoliza AND DUP.fechaCobro = recTem.fechaCobro
					
					DELETE MIG_RecobroTemp 
					FROM MIG_RecobroTemp recTem INNER JOIN (
					SELECT numeroPoliza, fechaCobro FROM MIG_RecobroTemp
					GROUP BY numeroPoliza, fechaCobro
					HAVING COUNT(numeroPoliza) > 1) as dup ON dup.numeroPoliza = recTem.numeroPoliza AND DUP.fechaCobro = recTem.fechaCobro

					SET @totalRegistros = ISNULL((SELECT COUNT(1) FROM [MIG_RecobroError]),0)

				END
			END

			IF @nombreTabla = 'SEG_Conyugue'
			BEGIN
				SET @totalRegistros = ISNULL((SELECT COUNT(1) FROM [MIG_ConyugeError]),0)
				IF @totalRegistros = 0
				BEGIN
					INSERT INTO [dbo].[MIG_ConyugeError]
				   ([id]
				   ,[numeroPoliza]
				   ,[tipoIdentificacion]
				   ,[identificacion]
				   ,[primerNombre]
				   ,[segundoNombre]
				   ,[primerApellido]
				   ,[segundoApellido]
				   ,[fechaNacimiento]
				   ,[genero]
				   ,[mensajeError])
				   SELECT	conTem.id
							,conTem.numeroPoliza 
							,conTem.tipoIdentificacion
							,conTem.identificacion
							,conTem.primerNombre
							,conTem.segundoNombre
							,conTem.primerApellido
							,conTem.segundoApellido 
							,FORMAT(conTem.fechaNacimiento,'yyyyMMdd')
							,conTem.genero
							,'***Poliza con mas de un conyuge asociado'  
					FROM MIG_ConyugeTemp conTem 
					INNER JOIN (
					SELECT numeroPoliza FROM MIG_ConyugeTemp
					GROUP BY numeroPoliza
					HAVING COUNT(numeroPoliza) > 1) as dup ON dup.numeroPoliza = conTem.numeroPoliza 


					DELETE MIG_ConyugeTemp 
					FROM MIG_ConyugeTemp conTem 
					INNER JOIN (
					SELECT numeroPoliza FROM MIG_ConyugeTemp
					GROUP BY numeroPoliza
					HAVING COUNT(numeroPoliza) > 1) as dup ON dup.numeroPoliza = conTem.numeroPoliza 
					SET @totalRegistros = ISNULL((SELECT COUNT(1) FROM [MIG_ConyugeError]),0)

				END
			END
		COMMIT TRAN
		RETURN @totalRegistros
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
	END CATCH
END