/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 Sprint 2/HU001.6 CrearVenta - Imprimir Poliza
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Sp para consultar el o los documentos de un seguro
FECHA DE MODIFICACIÓN: 09/02/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarDocumentoPlantillaPoliza]
(@idSeguro INT)

AS

BEGIN

	SELECT [idSeguro]
		  ,[plantilla]
		  ,[idDocumentoPoliza]
		  ,[versionDocumento]
		  ,[fechaCreacion]
		  ,[usuarioCreacion]
		  ,[activa]
		  ,[nombreArchivo]
		  ,[camposPlantilla]
		  ,[eliminado]
		  ,NULL as datosPolizaXML 
	FROM SEG_DocumentoPoliza
	WHERE idSeguro = @idSeguro
	AND activa = 1

END