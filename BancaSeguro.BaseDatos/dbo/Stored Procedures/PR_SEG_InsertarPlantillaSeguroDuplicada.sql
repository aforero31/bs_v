/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485 - HU018 - Parametrizacion Producto
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 11/07/2016
PROPOSITO: Inserta la plantilla por seguro duplicada existente
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se quita envio de usuario para solucion inmediata
REQUERIMIENTO: 
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 17/08/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarPlantillaSeguroDuplicada]
@idSeguro INT,
@idDocumentoPoliza INT,
@vP_UserName VARCHAR(128)

AS
BEGIN
	INSERT dbo.SEG_DocumentoPoliza
	(
	    idSeguro,
	    plantilla,
	    versionDocumento,
	    fechaCreacion,
	    usuarioCreacion,
	    activa,
	    nombreArchivo,
	    camposPlantilla,
	    eliminado
	)
	SELECT 
			@idSeguro AS idSeguro,
			sdp.plantilla,
			'1.0' AS versionDocumento,
			GETDATE() AS fechaCreacion,
			' ' AS usuarioCreacion,
			1 AS activa,
			sdp.nombreArchivo,
			sdp.camposPlantilla,
			0 AS eliminado

	FROM	dbo.SEG_DocumentoPoliza sdp 
	WHERE	sdp.idDocumentoPoliza = @idDocumentoPoliza

	declare @ik_TableName varchar(128) = 'SEG_DocumentoPoliza'
	declare @DocumentoPoliza int = scope_identity()
	select * into #del_SEG_DocumentoPoliza from SEG_DocumentoPoliza  WHERE idDocumentoPoliza = @DocumentoPoliza
	select * into #ins_SEG_DocumentoPoliza from SEG_DocumentoPoliza  WHERE @DocumentoPoliza = null
	exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_DocumentoPoliza, #ins_SEG_DocumentoPoliza, @vP_UserName
	drop table #ins_SEG_DocumentoPoliza 
	drop table #del_SEG_DocumentoPoliza 
END