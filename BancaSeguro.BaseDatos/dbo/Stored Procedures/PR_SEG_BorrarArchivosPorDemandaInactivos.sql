CREATE PROCEDURE [dbo].[PR_SEG_BorrarArchivosPorDemandaInactivos]
AS
/***************************************************************************************************************************************************
NOMBRE DEL PROGRAMA: [PR_SEG_BorrarArchivosPorDemandaInactivos]
DESCRIPCION: Borra los archivos por demanda donde su fecha de ejecución sea igual al dia del sistema y su estdo sea
			 inactivo
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE CREACIÓN: 18/07/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: 
REQUERIMIENTO: 
AUTOR: 
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN:
**************************************************************************************************************/
BEGIN
	DELETE SEG_ProgramacionArchivo WHERE estado = 0 AND idProgramacion = 1 AND CAST(fechaInicio AS DATE) = CAST(GETDATE() AS DATE) AND ISNULL([ultimaEjecucion],CAST('1990-01-01' AS DATE)) < CAST(GETDATE() AS DATE)
END