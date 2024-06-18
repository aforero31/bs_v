
CREATE FUNCTION [dbo].[FN_SEG_ObtenerBeneficiariosArchivoEmisiones] (@idVenta INT)
/*****************************************************************************************************************
CREACIÓN
REQUERIMIENTO:		Sprint 2/HU007
AUTOR:				Carlos Piza
EMPRESA:			Unión temporal FS-BAC-2013.
OBJETIVO:			Convierte la información de los beneficiarios en una cadena para el envio de emisiones.
FECHA DE CREACIÓN:	29/02/2016
-------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se eliminan espacios en blanco y se deja en mayúscula los datos de texto.
REQUERIMIENTO: Sprint 3/HU007
AUTOR: Jetlhen Roa Castañeda.
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 16/05/2016
*****************************************************************************************************************/
RETURNS VARCHAR(1500)
AS

BEGIN 

DECLARE @columnas VARCHAR(MAX)
DECLARE @CantidadRegistrosExistentes INT
DECLARE @CantidadRegistrosExigidos INT
DECLARE @BeneficiariosTabla TABLE( identificacion		VARCHAR(20)
								  ,nombres				VARCHAR(50)
								  ,apellidos			VARCHAR(50)
								  ,porcentaje			VARCHAR(4))

SET @CantidadRegistrosExigidos = 6

INSERT INTO @BeneficiariosTabla
SELECT  RTRIM(LTRIM(identificacion)) 	
	   ,UPPER(RTRIM(LTRIM(nombres)))
	   ,UPPER(RTRIM(LTRIM(apellidos)))
	   ,porcentaje	   
FROM SEG_Beneficiario
WHERE idVenta = @idVenta

SELECT @CantidadRegistrosExistentes = count(identificacion)
FROM @BeneficiariosTabla

IF @CantidadRegistrosExigidos > @CantidadRegistrosExistentes
BEGIN
	WHILE @CantidadRegistrosExigidos > @CantidadRegistrosExistentes
		BEGIN
		INSERT INTO @BeneficiariosTabla(identificacion,nombres,apellidos,porcentaje) VALUES ('','','','')
		SET @CantidadRegistrosExistentes += 1
	END
END

SET @columnas = '' 

SELECT @columnas =  COALESCE(@columnas + CAST(identificacion AS VARCHAR)+';'+ Nombre  +';'+ Porcentaje + ';','')
FROM (SELECT identificacion, LTRIM(RTRIM(nombres))+ ' ' +LTRIM(RTRIM(apellidos)) AS Nombre, CONVERT(VARCHAR(4) , porcentaje) AS Porcentaje FROM @BeneficiariosTabla) AS DTM 

IF LEN(@columnas) > 0
SET @columnas = LEFT(@columnas,LEN(@columnas)-1)

RETURN @columnas
END