CREATE PROCEDURE [dbo].[PR_SEG_ConsultarArchivosProgramados]
AS
/***************************************************************************************************************************************************
NOMBRE DEL PROGRAMA: [PR_SEG_ConsultarArchivosProgramados]
DESCRIPCION: Consultar las programaciones de archivos que están activos y pendientes de ejecutar
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
SELECT [idProgramacion]
      ,[fechaInicio]	
      ,CONVERT(varchar(4000), [programacion])
	  ,ISNULL(CAST([proximaEjecucion] AS DATE),CAST('1990-01-01' AS DATE)) AS 'proximaEjecución'
	  ,CASE WHEN codigoFiltro = 1 THEN CONCAT(nombre,'_','polizas_') 
			WHEN codigoFiltro = 2 THEN CONCAT(nombre,'_','cobros_') 
			WHEN codigoFiltro = 3 THEN CONCAT(nombre,'_','cancelaciones_') 
		ELSE ''
		END as 'nombreArchivo'
		,rutaDestinoFTP 'rutaFTP'
	FROM [SEG_ProgramacionArchivo]
	WHERE estado = 1 AND 
	((ISNULL([ultimaEjecucion],CAST('1990-01-01' AS DATE)) < CAST(proximaEjecucion AS DATE)) OR  ISNULL(proximaEjecucion,CAST('1990-01-01' AS DATE)) < CAST(GETDATE() AS DATE))
END