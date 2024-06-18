/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 29/03/2016
PROPOSITO: Inserta la plantilla por seguro
---------------------------------------------------------------------------------------------------------------
MODIFICACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 21/04/2016
PROPOSITO: Ajuste en la contabilizacion de la version del documento
***************************************************************************************************************
MODIFICACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/Enrique Rivera
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 19/05/2016
PROPOSITO: Se ajusta contador y auditoria

***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarPlantillaSeguro]
(@idSeguro INT
,@plantilla VARBINARY(MAX)
,@versionDocumento VARCHAR(10)
,@fechaCreacion DATETIME
,@usuarioCreacion VARCHAR(20)
,@activa BIT
,@nombreArchivo VARCHAR(100)
,@camposPlantilla VARCHAR(MAX)
,@eliminado BIT
,@usuario varchar(50))
AS

DECLARE @VersionPlantilla AS DECIMAL(18,2)

BEGIN

	SELECT @VersionPlantilla = ISNULL(MAX(CONVERT(DECIMAL(18,2), ISNULL(versionDocumento,0))),0) 
	FROM SEG_DocumentoPoliza
	WHERE idSeguro = @idSeguro

	IF @activa = 1
		BEGIN
			UPDATE SEG_DocumentoPoliza
			SET activa = 0
			WHERE idSeguro = @idSeguro

			SET @VersionPlantilla = CONVERT(VARCHAR(3),(CONVERT(DECIMAL(18,0), @VersionPlantilla) + 1)) + '.0'
			
		END
	ELSE	
		BEGIN	
			SELECT @VersionPlantilla = ISNULL(MAX(CONVERT(DECIMAL(18,2), ISNULL(versionDocumento,0))),0) 
			FROM SEG_DocumentoPoliza
			WHERE 
			FLOOR(convert(decimal(18,2),versionDocumento)) = FLOOR(@versionDocumento)
			and idSeguro = @idSeguro
				
			SET @VersionPlantilla =Str(@VersionPlantilla + 0.01,18,2) 						
		END
		
	INSERT INTO SEG_DocumentoPoliza(idSeguro, 
									plantilla, 
									versionDocumento, 
									fechaCreacion, 
									usuarioCreacion, 
									activa, 
									nombreArchivo, 
									camposPlantilla, 
									eliminado)
	VALUES(	@idSeguro,
			@plantilla,
			@VersionPlantilla,
			@fechaCreacion,
			@usuarioCreacion,
			@activa,
			@nombreArchivo,
			@camposPlantilla,
			@eliminado)
		
  declare @ik_TableName varchar(128) = 'SEG_DocumentoPoliza',
		    @i_CodEjecucion int
					
	set @i_CodEjecucion = scope_identity()
	select * into #ins_SEG_DocumentoPoliza from SEG_DocumentoPoliza WHERE idDocumentoPoliza = @i_CodEjecucion  
	select * into #del_SEG_DocumentoPoliza from SEG_DocumentoPoliza WHERE idDocumentoPoliza = null  
	exec PR_SEG_Auditoria @ik_TableName,'I',#ins_SEG_DocumentoPoliza, #del_SEG_DocumentoPoliza, @usuario 
	drop table #ins_SEG_DocumentoPoliza
	drop table #del_SEG_DocumentoPoliza
END