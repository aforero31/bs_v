
CREATE FUNCTION [dbo].[FN_SEG_ObtenerPeriodoCobro] (@fechaVenta DATE)
RETURNS DATE
AS

/*-------------------------------------------------------------------------
NOMBRE DEL PROGRAMA: FN_SEG_ObtenerPeriodoCobro
DESCRIPCION: A partir de la fecha de venta obtener el periodo de cobro a la fecha
PARAMETROS DE ENTRADA:
                @fechaVenta DATE
PARAMETROS DE SALIDA: 
                Fecha periodo de cobro
RESULTADO:        
                N/A
CODIGOS DE ERROR:
                N/A
-------------------------------------------------------------------------
CREACION
REQUERIMIENTO: SDXXXX
PROPOSITO: Permite obtener el periodo de cobro de una poliza
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE CREACIÓN: 2017-04-06
-------------------------------------------------------------------------
MODIFICACION
REQUERIMIENTO: 
PROPOSITO
AUTOR: 
EMPRESA: 
FECHA DE MODIFICACION: 
-------------------------------------------------------------------------*/
BEGIN
	
	DECLARE @fechaEjecucion DATE = CAST(GETDATE() AS DATE)	
	DECLARE @numeroMeses INT = ISNULL((SELECT CASE WHEN DATEPART(DAY, @fechaVenta) > DATEPART(DAY, @fechaEjecucion)   
											THEN DATEDIFF(MONTH, @fechaVenta, @fechaEjecucion) - 1
											ELSE DATEDIFF(MONTH, @fechaVenta, @fechaEjecucion) END),0)
	
	RETURN CAST((DATEADD(M, @numeroMeses,@fechaVenta)) AS DATE)
END