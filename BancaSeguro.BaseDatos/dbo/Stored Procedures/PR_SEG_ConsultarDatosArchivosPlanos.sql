/**************************************************************************************************************
CREACION
REQUERIMIENTO:	SD1588485
AUTOR: Andrés Combariza Ibarra
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Este procedimiento consulta los datos de la parametrizacion de la generación de archivos planos
FECHA DE CREACION: 18/07/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES:  XXXXXXXXXXXXXXXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarDatosArchivosPlanos] AS
BEGIN
	SELECT [idProgramacion]
		  ,[nombre]
		  ,[descripcion]
		  ,[tipoProgramacion]
		  ,[fechaInicio]
		  ,[fechaFin]
		  ,[programacion]
		  ,[ultimaEjecucion]
		  ,[proximaEjecucion]
		  ,[rutaDestinoFTP]
		  ,[separador]
		  ,[idAseguradora]
		  ,[codigoFiltro]
		  ,[criterioFiltro]
		  ,[camposConsulta]
		  ,[estado]
	FROM [dbo].[SEG_ProgramacionArchivo]
	
	
END



--select * from [dbo].[SEG_ProgramacionArchivo]