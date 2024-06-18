/**************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: Fernando Fernandez P.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Este procedimiento Consulta SEG_Plan Por el Id Seguro
FECHA DE CREACIÓN: 25/01/2016
---------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se adiciona campo idCodigoPlan en la consulta
REQUERIMIENTO: SD1588485 - Banca Seguros Visualizar Codigo Plan
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE CREACIÓN: 01/06/2016
---------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se adiciona campo valoriva y valor sin iva
REQUERIMIENTO: SD1588485 - HU018 Consultar Editar Producto
AUTOR: INTERGRUPO\WZALDUA
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE CREACIÓN: 24/06/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarPlanesPorIdSeguro]
	@idSeguro    [int] 
AS
	BEGIN

        	SELECT
				T1.idPlan,
				T1.idSeguro,
				T1.idPeriodicidad,
				T2.nombre As nombrePeriodicidad,
				T1.valor,
				T1.ValorIva,
				T1.ValorSinIva,
				T1.nombre As nombrePlan,
				T1.descripcion,
				T1.codigo AS codigoPlan,
				T1.codigoConvenio,
				T1.activo
        	FROM  SEG_Plan T1
				  INNER JOIN SEG_periodicidad T2 ON T1.idPeriodicidad = T2.idPeriodicidad
        	WHERE idSeguro = @idSeguro
        	
	END