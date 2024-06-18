/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 03/05/2016
PROPOSITO: Sp para insertar un documento asociado a un seguro
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarSeguroTipoIdentificacion]
(@idSeguro INT,
@idTipoIdentificacion INT,
@vP_UserName VARCHAR(128)
 )

AS

BEGIN

	IF NOT EXISTS (SELECT idSeguro 
				   FROM SEG_SeguroTipoIdentificacion 
				   WHERE idSeguro = @idSeguro 
					 AND idTipoIdentificacion = @idTipoIdentificacion)
		BEGIN
			INSERT INTO SEG_SeguroTipoIdentificacion(idSeguro, 
													 idTipoIdentificacion)
			VALUES(@idSeguro,
				   @idTipoIdentificacion)

			declare @ik_TableName varchar(128) = 'SEG_SeguroTipoIdentificacion'
			declare @SeguroTipoIdentificacion int = 0
			select * into #del_SEG_SeguroTipoIdentificacion from SEG_SeguroTipoIdentificacion  WHERE dbo.SEG_SeguroTipoIdentificacion.idSeguro = @idSeguro AND dbo.SEG_SeguroTipoIdentificacion.idTipoIdentificacion = @idTipoIdentificacion
			select * into #ins_SEG_SeguroTipoIdentificacion from SEG_SeguroTipoIdentificacion  WHERE 0 = null
			exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_SeguroTipoIdentificacion, #ins_SEG_SeguroTipoIdentificacion, @vP_UserName
			drop table #ins_SEG_SeguroTipoIdentificacion 
			drop table #del_SEG_SeguroTipoIdentificacion 
		END
END