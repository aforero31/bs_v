/***************************************************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: Paulo Mora
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Busca el consecutivo
FECHA DE CREACIÓN: 2016-06-20
***************************************************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ObtenerConsecutivoCobis]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @siguienteConsecutivo BIGINT;

    BEGIN TRANSACTION 
	UPDATE SEG_ConsecutivoCobis
	SET @siguienteConsecutivo = consecutivo = consecutivo +1;

	COMMIT TRANSACTION
	SELECT @siguienteConsecutivo AS siguienteConsecutivo;
END