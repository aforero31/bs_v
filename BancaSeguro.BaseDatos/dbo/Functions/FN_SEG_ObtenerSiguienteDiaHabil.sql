CREATE FUNCTION [dbo].[FN_SEG_ObtenerSiguienteDiaHabil] ()
RETURNS DATE
AS
BEGIN

/* ****************************************************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: Nelson Hernando Pardo Peláez
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE CREACION: 19/10/2016
OBJETIVO: Consulta del día hábil siguiente al de la fecha de creación de una póliza
***************************************************************************************************************************************************/

	DECLARE @fechaInicio DATE = GETDATE()
	DECLARE @fechaRetorno DATE = NULL
	DECLARE @valida INT = 0
	DECLARE @DIA INT = 0
	DECLARE @MES INT = 0
	DECLARE @AÑO INT = 0
	WHILE @valida = 0
	BEGIN	
		DECLARE @fechaString VARCHAR(10) = CONCAT(YEAR(GETDATE()), RIGHT('0' + RTRIM(MONTH(GETDATE())), 2), RIGHT('0' + RTRIM(DAY(GETDATE())), 2))
		
		IF ISDATE(@fechaString) = 1 
		BEGIN
			SET @valida = 1
			SET @fechaRetorno = @fechaString
		END
		ELSE		
		BEGIN
			SET @valida = 0
			SET @fechaInicio = DATEADD(DAY,-1, @fechaInicio)		
		END	
	END

	IF @fechaRetorno IS NOT NULL
	BEGIN
		SET @valida = 0
		WHILE @valida = 0
		BEGIN
			SET @valida = 1
			IF (SELECT ISNULL(COUNT(1),0) FROM SEG_DiaHabil WHERE FECHA = @fechaRetorno) = 0
			BEGIN
				SET @fechaRetorno = DATEADD(DAY, 1, @fechaRetorno)
				SET @valida = 0
			END		
		END
	END

	RETURN @fechaRetorno
END