
CREATE FUNCTION [dbo].[FN_SEG_ObtenerColumnasConsulta] 
( 
    @camposConsulta NVARCHAR(MAX), 
    @delimiter CHAR(1)
) 
RETURNS @output TABLE(columna NVARCHAR(MAX))
/***************************************************************************************************************************************************
NOMBRE DEL PROGRAMA: [FN_SEG_ObtenerColumnasConsulta]
DESCRIPCION: Retorna en una tabla las columnas seleccionadas para generar el archivo plano
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE CREACIÓN: 14/07/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: 
REQUERIMIENTO: 
AUTOR: 
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN:
**************************************************************************************************************/
BEGIN 

	DECLARE @start INT, @end INT
    SELECT @start = 1, @end = CHARINDEX(@delimiter, @camposConsulta) 
    WHILE @start < LEN(@camposConsulta) + 1 BEGIN 
        IF @end = 0  
            SET @end = LEN(@camposConsulta) + 1

		INSERT INTO @output (columna)  
        VALUES(SUBSTRING(@camposConsulta, @start, @end - @start)) 

        SET @start = @end + 1 
        SET @end = CHARINDEX(@delimiter, @camposConsulta, @start)       
    END 	
    RETURN
END