CREATE PROCEDURE [dbo].[PR_SEG_RechazarRegistrosPendienteAprobacion]
AS
/***************************************************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - Sprint /HU036
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Rechaza los registros pendiente de aprobación cuando han superado el máximo de dias permitidos en estado pendiente de aprobación.
FECHA DE MODIFICACIÓN: 30/06/2016
**************************************************************************************************************/
BEGIN
	DECLARE @numDiasSinGestion INT = 0,
			@idParametro INT = 56,
			@mensajeRechazo VARCHAR(500) = 'Registro rechado por superar el máximo de dias pendiente para su aprobación',
			@estadoRegistro CHAR(1) = 'R', 
			@usuarioRechaza VARCHAR(50) = 'Sistema',
			@fechaRechazo DATETIME = GETDATE()
	SELECT @numDiasSinGestion = CAST(valor AS int) FROM SEG_Parametro WHERE idParametro = @idParametro
	IF @numDiasSinGestion > 0
	BEGIN
		UPDATE [SEG_AprobacionDual] 
		SET estado = @estadoRegistro, 
			usuarioAprueba = @usuarioRechaza,
			descripcion = @mensajeRechazo,
			fechaAprobacion = @fechaRechazo
		WHERE idAprobacionDual IN (	SELECT [idAprobacionDual] FROM [SEG_AprobacionDual] 
									WHERE DATEADD(D,@numDiasSinGestion,CAST([fechaSolicitud] AS DATE)) <= CAST(GETDATE() AS DATE) AND estado = 'P')
		
	END
END