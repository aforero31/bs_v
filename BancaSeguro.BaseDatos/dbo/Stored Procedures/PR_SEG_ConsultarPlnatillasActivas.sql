/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU018 Parametrizacion Plantilla
AUTOR: Wilver Guillermo Zaldua Espindola
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Consulta todas las plantillas activas
FECHA DE CREACIÓN: 08/07/2016
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarPlnatillasActivas] 
AS
BEGIN
	SELECT	sdp.[idSeguro]
		  ,NULL AS plantilla
		  ,[idDocumentoPoliza]
		  ,[versionDocumento]
		  ,[fechaCreacion]
		  ,[usuarioCreacion]
		  ,[activa]
		  ,ss.codigo + ' - ' + ss.nombre + ' - ' + sdp.nombreArchivo AS nombreArchivo
		  ,[camposPlantilla]
		  ,[eliminado]
		  ,NULL as datosPolizaXML 
	FROM	dbo.SEG_DocumentoPoliza sdp INNER JOIN 
	dbo.SEG_Seguro ss ON ss.idSeguro = sdp.idSeguro
	WHERE	sdp.activa = 1
END