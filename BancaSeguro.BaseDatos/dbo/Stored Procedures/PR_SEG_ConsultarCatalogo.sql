/* *************************************************************************************************************        
CREACIÓN
REQUERIMIENTO: 
AUTOR: 
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Consulta las tabla segun parametro de entrada 
FECHA DE CREACIÓN: 23/03/2016
---------------------------------------------------------------------------------------------------------------------------------------------------- 
MODIFICACIONES: Agregar campo visible a la tabla SEG_Parametro
REQUERIMIENTO: Pendientes BancaSeguros Octubre 2016 - SD1588485
AUTOR: Nelson Hernando Pardo Peláez
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 13/10/2016
---------------------------------------------------------------------------------------------------------------------------------------------------- 
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/ 
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarCatalogo]  
(  
 @tblname		VARCHAR(128) 
)  
AS  

BEGIN
DECLARE @sql nvarchar(4000)
SET @sql = 'SELECT * FROM dbo.' + quotename(@tblname)

IF @tblname = 'SEG_Parametro'
BEGIN
	SET @sql = @sql + ' WHERE [visible] = 1 or descripcion = ''Version Aplicacion'''
END

exec sp_executesql  @sql
END
