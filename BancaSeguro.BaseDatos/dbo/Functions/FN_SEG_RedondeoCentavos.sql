CREATE FUNCTION [dbo].[FN_SEG_RedondeoCentavos] (@ValorPoliza decimal(18,2))
RETURNS decimal(18,2)
AS
BEGIN

/* ****************************************************************************************************************************************************
CREACION
REQUERIMIENTO:	SD1588485
AUTOR:  Jetlhen Roa
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Una vez ejecutado el incremento se debe redondear (solo para centavos) a la unidad más cercana por arriba o por abajo. 
Ejemplo: 
 - Si al realizar el incremento del valor de la prima que antes tenia una valor de 10000 y ahora es de 10500.6 el valor a cobrar debe ser de 10501.
 - Si al realizar el incremento del valor de la prima que antes tenia una valor de 10000 y ahora es de 10500.5  el valor a cobrar debe ser de 10500.
FECHA DE CREACION:23/03/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Según el review del día 30 de Marzo el redondeo se va aplicar así:
				(10500.9)-->10501.00
				(10500.8)-->10501.00
				(10500.7)-->10501.00
				(10500.6)-->10501.00
				(10500.5)-->10501.00

				(10500.4)-->10500.00
				(10500.3)-->10500.00
				(10500.2)-->10500.00
				(10500.1)-->10500.00
				(10500.0)-->10500.00
				La función se prueba así: SELECT dbo.FN_SEG_RedondeoCentavos2 (1067045.19) ;
REQUERIMIENTO: 
AUTOR: Jetlhen Roa
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 04/04/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agrego la variable @aux porque estaba tomando el dato con hexadecimal en la parte de floor cuando la condición es @posdespunto <=4
REQUERIMIENTO: SD1588485 - HU011
AUTOR:Jetlhen Roa
EMPRESA:Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 19/04/2016
***************************************************************************************************************************************************/

DECLARE @valorPolizaVarchar varchar (120)=(SELECT CONVERT(varchar(10),@ValorPoliza))
SET @valorPolizaVarchar=replace(@valorPolizaVarchar,',','.')

DECLARE @aux AS DECIMAL(18,2)

--Se obtiene el dato de la siguiente posición después del punto con patindex
DECLARE @posdespunto varchar(1)=(select substring(@valorPolizaVarchar,patindex('%.%', @valorPolizaVarchar)+1,1))

--Se evalúa el dato de la siguiente posición después del punto para mirar que tipo de redondeo se hace

IF (@posdespunto >4)

BEGIN
	SET @valorPolizaVarchar=(select ceiling(@valorPolizaVarchar))--redondea hacia arriba el argumento 
END

IF (@posdespunto <=4)

BEGIN
	SET @aux = floor(convert(decimal(18,2),@valorPolizaVarchar))--redondea hacia abajo el argumento
	SET @valorPolizaVarchar= CONVERT(VARCHAR(12),@aux) 
END

RETURN CAST (@valorPolizaVarchar as decimal (18,2));

END