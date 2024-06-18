/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE CREACION: 19/07/2016
PROPOSITO: Procedimiento para actualiza un plan si no esta activo
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ActualizarPlantilla]
	@idSeguro INT,
	@idDocumentoPoliza INT,
	@vP_UserName varchar(128) --para auditoria
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM dbo.SEG_DocumentoPoliza sdp WHERE sdp.idDocumentoPoliza = @idDocumentoPoliza AND sdp.activa = 1 AND sdp.idSeguro = @idSeguro)
	BEGIN
		UPDATE dbo.SEG_DocumentoPoliza
		SET
			dbo.SEG_DocumentoPoliza.activa = 0 -- bit
		WHERE dbo.SEG_DocumentoPoliza.idSeguro = @idSeguro

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
				(SELECT CONVERT(varchar,(MAX(CONVERT(decimal, sdp.versionDocumento) + 1))) + '.0' AS versionDocumento FROM dbo.SEG_DocumentoPoliza sdp WHERE sdp.idSeguro = @idSeguro) AS versionDocumento,
				GETDATE() AS fechaCreacion,
				sdp.usuarioCreacion,
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
END