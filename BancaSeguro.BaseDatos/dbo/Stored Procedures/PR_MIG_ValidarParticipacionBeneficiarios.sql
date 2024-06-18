
CREATE PROCEDURE [dbo].[PR_MIG_ValidarParticipacionBeneficiarios] 
/**************************************************************************************************************
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE CREACIÓN: 31/08/2016
OBJETIVO: Procedmiento para verificar que la participación del total de beneficiarios por póliza no supere el 100% 
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES:
REQUERIMIENTO:
AUTOR:
EMPRESA:
FECHA DE MODIFICACIÓN:
**************************************************************************************************************************************************/
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @totalRegistros INT = 0	
	SET @totalRegistros = ISNULL((SELECT COUNT(1) FROM MIG_BeneficiarioError),0)

	IF @totalRegistros = 0
	BEGIN
		INSERT INTO MIG_BeneficiarioError([id],[numeroPoliza],[parentesco],[tipoIdentificacion],[identificacion],[nombres],[apellidos],[participacion],[mensajeError])
		SELECT							  [id],[numeroPoliza],[parentesco],[tipoIdentificacion],[identificacion],[nombres],[apellidos],CAST([participacion] AS nvarchar(10)),'***La participacion de los beneficiarios no corresponde al 100 por ciento de la poliza' from MIG_BeneficiarioTemp where numeroPoliza in (select numeroPoliza from MIG_BeneficiarioTemp
		GROUP BY numeroPoliza
		HAVING  SUM(participacion) > 100)

		DELETE MIG_BeneficiarioTemp WHERE numeroPoliza IN (select numeroPoliza from MIG_BeneficiarioTemp
		GROUP BY numeroPoliza
		HAVING  SUM(participacion) > 100)

		SET @totalRegistros = ISNULL((SELECT COUNT(1) FROM MIG_BeneficiarioError),0)
	END
	RETURN @totalRegistros
END