/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-Sprint 3/HU001.6 CrearVenta - Imprimir Poliza
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Sp para consultar las plantillas por idSeguro
FECHA DE MODIFICACIÓN: 09/02/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarPlantillaPorIdSeguro]
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
	FROM SEG_DocumentoPoliza
	WHERE [idSeguro] = @idSeguro
	AND eliminado = 0

END