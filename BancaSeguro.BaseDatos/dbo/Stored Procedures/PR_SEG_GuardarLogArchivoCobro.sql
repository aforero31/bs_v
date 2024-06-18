
CREATE PROCEDURE [dbo].[PR_SEG_GuardarLogArchivoCobro] @idProceso INT
AS
/*************************************************************************************************************************************************
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA CREACIÓN: 23/02/2016
OBJETIVO: Almacenar el log de los archivos de cobros generado por el sistema.
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
		SELECT @nombreArchivo = archivoCreado FROM SEG_ProcesoETL WHERE ID = @idProceso
		DELETE SEG_LogArchivoCobro WHERE nombreArchivo = @nombreArchivo
		INSERT INTO SEG_LogArchivoCobro
			SELECT [tipoNovedad]
				  ,[tipoTransaccion]
				  ,[fecha]
				  ,[usuario]
				  ,[ctaBancoOrigen]
				  ,[productoOrigen]
				  ,[ctaBancoDestino]
				  ,[productoDestino]
				  ,[oficina]
				  ,[fechaHora]
				  ,[nroControl]
				  ,[correccion]
				  ,[moneda]
				  ,[cheque]
				  ,[desprendible]
				  ,[tipoCheque]
				  ,[banco]
				  ,[cuentaGirada]
				  ,[endoso]
				  ,[montoEfectivo]
				  ,[montoLocal]
				  ,[montoPropio]
				  ,[montoRemCobro]
				  ,[montoRemNeg]
				  ,[montoIVA]
				  ,[montoComision]
				  ,[referencia1]
				  ,[referencia2]
				  ,[referencia3]
				  ,[referencia4]
				  ,[referencia5]
				  ,[convenio]
				  ,[causa]
				  ,[causal]
				  ,[depto]
				  ,[comentario]
				  ,[tarjetaCred]
				  ,[establecimiento]
				  ,[tsFechaEfectiva]
				  ,[identificacion]
				  ,[claseImpuesto]
				  ,[tipoVarios]
				  ,[tipoPersona]
				  ,[sticker]
				  ,[administracion]
				  ,[formaPago]
				  ,[institucion]
				  ,[cajaOrigen]
				  ,[cajaDestino]
				  ,[usuarioOrigen]
				  ,[secuencial]
				  ,[numControlRech]
				  ,[codError]
				  ,[descError]
				  ,[posicion]
				  ,[periodoCobro]
				  ,@nombreArchivo
				  ,@fechaProceso
			FROM SEG_ArchivoCobro
	END TRY
	BEGIN CATCH
			UPDATE SEG_ProcesoETL SET	tarea = 'Guardar log', 
										errorTarea = 'BD: '+ ERROR_MESSAGE()
			WHERE id = @idProceso
	END CATCH
END