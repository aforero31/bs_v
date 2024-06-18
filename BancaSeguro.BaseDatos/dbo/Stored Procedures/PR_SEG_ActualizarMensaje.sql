/****************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485-Banca Seguros Parametrizar Mensajes
DESCRIPCIÒN:   Procedimiento que Actualiza un registro en SEG_Mensaje
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Procedimiento que Actualiza un registro en SEG_Mensaje
FECHA DE MODIFICACIÓN: 01/06/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ActualizarMensaje] 
	@idMensaje      int,
	@Llave			varchar(50),
	@idTipoMensaje	int,
	@idEvento	int,
	@Mensaje		varchar(max),
	@existe			bit OUTPUT,
	@vP_UserName varchar(128) --para auditoria
AS
BEGIN
	declare @ik_TableName varchar(128) = 'SEG_Mensaje'
	select * into #del_SEG_Mensaje from SEG_Mensaje WHERE [idMensaje] = @idMensaje
	SET NOCOUNT ON;
	
	SET @existe = 0;
	IF NOT EXISTS(SELECT * FROM SEG_Mensaje WHERE Llave = @Llave and idMensaje <> @idMensaje)
	BEGIN
		UPDATE SEG_Mensaje
		SET Llave = @Llave,
		idTipoMensaje = @idTipoMensaje,
		idEvento  = @idEvento,
		Mensaje       = @Mensaje
		WHERE idMensaje = @idMensaje; 

			  -- para auditoria
		select * into #ins_SEG_Mensaje from SEG_Mensaje WHERE [idMensaje] = @idMensaje  -- para auditoria
		exec PR_SEG_Auditoria @ik_TableName,'U', #ins_SEG_Mensaje, #del_SEG_Mensaje,  @vP_UserName --para auditoria
		drop table #ins_SEG_Mensaje --para auditoria
		drop table #del_SEG_Mensaje; --para auditoria
	END
    ELSE
        SET @existe = 1;  
END