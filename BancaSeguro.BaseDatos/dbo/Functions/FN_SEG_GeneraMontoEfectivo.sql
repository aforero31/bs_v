
CREATE FUNCTION [dbo].[FN_SEG_GeneraMontoEfectivo] (@valor DECIMAL(18,2))
RETURNS VARCHAR(44)
/* **************************************************************************************************************************************************
CREACION
REQUERIMIENTO:	SD1588485
AUTOR: Jetlhen Roa
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Para generar el archivo de cobro el Bco. solicita que el dato montoEfectivo se tome del valorPoliza y que se complete con ceros (0)
		  hasta completar 15 dígitos
FECHA DE CREACION: 13/03/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACION: Se cambia el parámetro de @id (ID de la venta) a @valor para que tome directamente el valor del cobro y no el de la póliza
REQUERIMIENTO: SD1588485
AUTOR: Nelson Hernando Pardo Peláez
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 21/10/2016
***************************************************************************************************************************************************/
AS
BEGIN

DECLARE @longitud int
DECLARE @montoEfectivo varchar(44)

--Revisa cuál es la longitud del campo valorPoliza 
SET @longitud=(SELECT LEN(SUBSTRING(CONVERT(VARCHAR,@valor),1,CHARINDEX('.', @valor)-1)))
				--FROM [dbo].[SEG_Venta]
				--WHERE dbo.SEG_Venta.idVenta=@id)

--Completa con ceros a la izquierda del campo valorPoliza hasta que su longitud sea 15 y este va a ser el dato en montoEfectivo para el archivo de cobro
SET @montoEfectivo=(SELECT CASE WHEN @longitud=1  THEN '00000000000000'+CONVERT(VARCHAR,@valor)
								WHEN @longitud=2  THEN '0000000000000'+CONVERT(VARCHAR,@valor)
								WHEN @longitud=3  THEN '000000000000'+CONVERT(VARCHAR,@valor)
								WHEN @longitud=4  THEN '00000000000'+CONVERT(VARCHAR,@valor)
								WHEN @longitud=5  THEN '0000000000'+CONVERT(VARCHAR,@valor)
								WHEN @longitud=6  THEN '000000000'+CONVERT(VARCHAR,@valor)
								WHEN @longitud=7  THEN '00000000'+CONVERT(VARCHAR,@valor)
								WHEN @longitud=8  THEN '0000000'+CONVERT(VARCHAR,@valor)
								WHEN @longitud=9  THEN '000000'+CONVERT(VARCHAR,@valor)
								WHEN @longitud=10 THEN '00000'+CONVERT(VARCHAR,@valor)
								WHEN @longitud=11 THEN '0000'+CONVERT(VARCHAR,@valor)
								WHEN @longitud=12 THEN '000'+CONVERT(VARCHAR,@valor)
								WHEN @longitud=13 THEN '00'+CONVERT(VARCHAR,@valor)
								WHEN @longitud=14 THEN '0'+CONVERT(VARCHAR,@valor)
								WHEN @longitud=15 THEN SUBSTRING(CONVERT(VARCHAR,@valor),1,CHARINDEX('.', @valor)-1)
							END)
--FROM [dbo].[SEG_Venta] (NOLOCK)
--WHERE dbo.SEG_Venta.idVenta=@id)

RETURN @montoEfectivo;

END