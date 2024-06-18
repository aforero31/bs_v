
CREATE PROCEDURE [dbo].[PR_MIG_VerificarRegistrosControl] @nombreTabla  [varchar](50)
/**************************************************************************************************************
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE CREACIÓN: 31/08/2016
OBJETIVO: Procedimiento para verficar los registros de control de cada archivo de migración
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
	DECLARE @numeroControl INT=0, @columna INT = 0, @operacion VARCHAR(50)='', @valorReportado1 decimal(18,2) = 0,@valorReportado2 decimal(18,2) = 0, @valorReportado3 decimal(18,2) = 0,@valorCalculado decimal(18,2) = 0, @cumplio BIT, @minID INT = 0 			
	DECLARE @errorRegistros VARCHAR(200) = '', @valoresregControl VARCHAR(50) = ''
	IF @nombreTabla = 'SEG_Venta'
	BEGIN
		SET @minID = (SELECT MIN(id) FROM MIG_VentaCarga)
		SET @valoresregControl = (SELECT columna1 + '|'+ columna2 + '|'+ columna3 + '|' FROM MIG_VentaCarga WHERE id = @minID)
		SELECT @valorReportado1 = CASE WHEN ISNUMERIC(columna1) = 1 THEN CAST(columna1 AS decimal(18,2)) ELSE 0 END
		FROM MIG_VentaCarga WHERE id = @minID

		SELECT @valorReportado2 = CASE WHEN ISNUMERIC(columna2) = 1 THEN CAST(columna2 AS decimal(18,2)) ELSE 0 END
		FROM MIG_VentaCarga WHERE id = @minID		

		SELECT @valorReportado3 = CASE WHEN ISNUMERIC(columna3) = 1 THEN CAST(columna3 AS decimal(18,2)) ELSE 0 END
		FROM MIG_VentaCarga WHERE id = @minID

		--1 registro de control
		SET @valorCalculado = 0
		SET @valorCalculado = (SELECT SUM(CASE WHEN ISNUMERIC(columna17) = 1 THEN CAST(columna17 AS decimal(18,2)) ELSE 0 END) FROM MIG_VentaCarga WHERE id > @minID)
		UPDATE MIG_RegistroControlArchivo SET valorCalculado =  @valorCalculado, valorReportado = @valorReportado1, cumplio = CASE WHEN (@valorCalculado-@valorReportado1) = 0 THEN 1 ELSE 0 END
		WHERE nombreArchivo = 'SEG_Venta' AND numeroControl = 1

		--2 registro de control
		SET @valorCalculado = 0
		SET @valorCalculado = ISNULL((SELECT COUNT(1) FROM MIG_VentaCarga),1)-1
		UPDATE MIG_RegistroControlArchivo SET valorCalculado =  @valorCalculado , valorReportado = @valorReportado2, cumplio = CASE WHEN (@valorCalculado-@valorReportado2) = 0 THEN 1 ELSE 0 END
		WHERE nombreArchivo = 'SEG_Venta' AND numeroControl = 2

		--3 registro de control
		SET @valorCalculado = 0
		SET @valorCalculado = (SELECT SUM(CASE WHEN ISNUMERIC(SUBSTRING([columna23], LEN([columna23])-1, 2)) = 1 THEN CAST(SUBSTRING([columna23], LEN([columna23])-1, 2) AS decimal(18,2)) ELSE 0 END) FROM MIG_VentaCarga WHERE id > @minID)
		UPDATE MIG_RegistroControlArchivo SET valorCalculado =  @valorCalculado, valorReportado = @valorReportado3, cumplio = CASE WHEN (@valorCalculado-@valorReportado3) = 0 THEN 1 ELSE 0 END
		WHERE nombreArchivo = 'SEG_Venta' AND numeroControl = 3		
	END

	IF @nombreTabla = 'SEG_Recobro'
	BEGIN
		SET @minID = (SELECT MIN(id) FROM MIG_RecobroCarga)
		SET @valoresregControl = (SELECT columna1 + '|'+ columna2 + '|' FROM MIG_RecobroCarga WHERE id = @minID)

		SELECT @valorReportado1 = CASE WHEN ISNUMERIC(columna1) = 1 THEN CAST(columna1 AS decimal(18,2)) ELSE 0 END
		FROM MIG_RecobroCarga WHERE id = @minID

		SELECT @valorReportado2 = CASE WHEN ISNUMERIC(columna2) = 1 THEN CAST(columna2 AS decimal(18,2)) ELSE 0 END
		FROM MIG_RecobroCarga WHERE id = @minID		

		SET @valorCalculado = 0
		SET @valorCalculado = (SELECT SUM(CASE WHEN ISNUMERIC(SUBSTRING(columna1, LEN(columna1)-1, 2)) = 1 THEN CAST(SUBSTRING(columna1, LEN(columna1)-1, 2) AS decimal(18,2)) ELSE 0 END) FROM MIG_RecobroCarga WHERE id > @minID)
		UPDATE MIG_RegistroControlArchivo SET valorCalculado =  @valorCalculado, valorReportado = @valorReportado1, cumplio = CASE WHEN (@valorCalculado-@valorReportado1) = 0 THEN 1 ELSE 0 END
		WHERE nombreArchivo = 'SEG_Recobro' AND numeroControl = 1

		SET @valorCalculado = 0
		SET @valorCalculado = ISNULL((SELECT COUNT(1) FROM MIG_RecobroCarga),1)-1
		UPDATE MIG_RegistroControlArchivo SET valorCalculado =  @valorCalculado , valorReportado = @valorReportado2, cumplio = CASE WHEN (@valorCalculado-@valorReportado2) = 0 THEN 1 ELSE 0 END
		WHERE nombreArchivo = 'SEG_Recobro' AND numeroControl = 2
	END

	IF @nombreTabla = 'SEG_Beneficiario'
	BEGIN
		SET @minID = (SELECT MIN(id) FROM MIG_BeneficiarioCarga)
		SET @valoresregControl = (SELECT columna1 + '|'+ columna2 + '|' FROM MIG_BeneficiarioCarga WHERE id = @minID)
		SELECT @valorReportado1 = CASE WHEN ISNUMERIC(columna1) = 1 THEN CAST(columna1 AS decimal(18,2)) ELSE 0 END
		FROM MIG_BeneficiarioCarga WHERE id = @minID

		SELECT @valorReportado2 = CASE WHEN ISNUMERIC(columna2) = 1 THEN CAST(columna2 AS decimal(18,2)) ELSE 0 END
		FROM MIG_BeneficiarioCarga WHERE id = @minID		

		SET @valorCalculado = 0
		SET @valorCalculado = ISNULL((SELECT COUNT(1) FROM MIG_BeneficiarioCarga),1)-1
		UPDATE MIG_RegistroControlArchivo SET valorCalculado =  @valorCalculado , valorReportado = @valorReportado1, cumplio = CASE WHEN (@valorCalculado-@valorReportado1) = 0 THEN 1 ELSE 0 END
		WHERE nombreArchivo = 'SEG_Beneficiario' AND numeroControl = 1

		SET @valorCalculado = 0
		SET @valorCalculado = (SELECT SUM(CASE WHEN ISNUMERIC(SUBSTRING(columna1, LEN(columna1)-1, 2)) = 1 THEN CAST(SUBSTRING(columna1, LEN(columna1)-1, 2) AS decimal(18,2)) ELSE 0 END) FROM MIG_BeneficiarioCarga WHERE id > @minID)
		UPDATE MIG_RegistroControlArchivo SET valorCalculado =  @valorCalculado, valorReportado = @valorReportado2, cumplio = CASE WHEN (@valorCalculado-@valorReportado2) = 0 THEN 1 ELSE 0 END
		WHERE nombreArchivo = 'SEG_Beneficiario' AND numeroControl = 2
	END

	IF @nombreTabla = 'SEG_Conyugue'
	BEGIN
		SET @minID = (SELECT MIN(id) FROM MIG_ConyugeCarga)
		SET @valoresregControl = (SELECT columna1 + '|'+ columna2 + '|' FROM MIG_ConyugeCarga WHERE id = @minID)
		SELECT @valorReportado1 = CASE WHEN ISNUMERIC(columna1) = 1 THEN CAST(columna1 AS decimal(18,2)) ELSE 0 END
		FROM MIG_ConyugeCarga WHERE id = @minID

		SELECT @valorReportado2 = CASE WHEN ISNUMERIC(columna2) = 1 THEN CAST(columna2 AS decimal(18,2)) ELSE 0 END
		FROM MIG_ConyugeCarga WHERE id = @minID		

		SET @valorCalculado = 0
		SET @valorCalculado = (SELECT SUM(CASE WHEN ISNUMERIC(SUBSTRING(columna3, LEN(columna3)-1, 2)) = 1 THEN CAST(SUBSTRING(columna3, LEN(columna3)-1, 2) AS decimal(18,2)) ELSE 0 END) FROM MIG_ConyugeCarga WHERE id > @minID)
		UPDATE MIG_RegistroControlArchivo SET valorCalculado =  @valorCalculado, valorReportado = @valorReportado1, cumplio = CASE WHEN (@valorCalculado-@valorReportado1) = 0 THEN 1 ELSE 0 END
		WHERE nombreArchivo = 'SEG_Conyugue' AND numeroControl = 1

		SET @valorCalculado = 0
		SET @valorCalculado = ISNULL((SELECT COUNT(1) FROM MIG_ConyugeCarga),1)-1
		UPDATE MIG_RegistroControlArchivo SET valorCalculado =  @valorCalculado , valorReportado = @valorReportado2, cumplio = CASE WHEN (@valorCalculado-@valorReportado2) = 0 THEN 1 ELSE 0 END
		WHERE nombreArchivo = 'SEG_Conyugue' AND numeroControl = 2

	END

	IF (SELECT COUNT(1) FROM MIG_RegistroControlArchivo WHERE nombreArchivo = @nombreTabla AND  cumplio = 0) > 0
		BEGIN
			SELECT @errorRegistros =  COALESCE(@errorRegistros + nombreControl + ' no se cumplio|' ,'')
			FROM MIG_RegistroControlArchivo 
			WHERE nombreArchivo = @nombreTabla AND  cumplio = 0
			IF LEN(@errorRegistros) > 0
				SET @errorRegistros = LEFT(@errorRegistros,LEN(@errorRegistros)-1)
			UPDATE MIG_EjecucionMigracion SET mensajeError = @valoresregControl+'***'+@errorRegistros  WHERE nombreArchivo = @nombreTabla
			RETURN 0
		END
		RETURN  1

END