/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485 HU023-Parametrizacion Archivo Plano
AUTOR: Andrés Combariza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para eliminar un registro de la tabla SEG_ProgramacionArchivo
FECHA DE MODIFICACIÓN: 19/07/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_EliminarDatosArchivoPlano]
	@idProgramacion INT,
	@vP_UserName varchar(128) --para auditoria
AS

BEGIN
	declare @ik_TableNameVP varchar(128) = 'SEG_ProgramacionArchivo'
	select * into #ins_SEG_ProgramacionArchivo from SEG_ProgramacionArchivo WHERE idProgramacion = @idProgramacion

	DELETE FROM [dbo].[SEG_ProgramacionArchivo]	
	WHERE [idProgramacion] = @idProgramacion

	select * into #del_SEG_ProgramacionArchivo from SEG_ProgramacionArchivo WHERE idProgramacion = @idProgramacion  -- para auditoria
	exec PR_SEG_Auditoria @ik_TableNameVP,'D',#del_SEG_ProgramacionArchivo, #ins_SEG_ProgramacionArchivo, @vP_UserName --para auditoria
	drop table #ins_SEG_ProgramacionArchivo; --para auditoria
	drop table #del_SEG_ProgramacionArchivo; --para auditoria	
END