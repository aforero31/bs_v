/* *************************************************************************************************************
CREACIÓN
REQUERIMIENTO: 
AUTOR: Wilver Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Este procedimiento modifica un rol existente
FECHA DE CREACIÓN: 08/01/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se elimina campo es Autorizador
REQUERIMIENTO: SD1588485-HU020-AdministrarRol
AUTOR:         Paulo Mora
EMPRESA:	   Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 2016-04-26
---------------------------------------------------------------------------------------------------------------
REQUERIMIENTO: Banca Seguros Log de Transacciones 
AUTOR: Paulo Mora.
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE CREACIÓN: 2016-06-20
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ActualizarRol]
(
@idRol int,
@nombre varchar(50), 
@activo bit,
@vP_UserName varchar(128) --
)
AS
BEGIN
	declare @ik_TableName varchar(128) = 'SEG_Rol';
	select * into #ins_SEG_Rol from SEG_Rol WHERE idRol=@idRol; 
	UPDATE	SEG_Rol 
	SET		nombre = @Nombre, 
			activo=@activo 
	WHERE	idRol=@idRol; 
	select * into #del_SEG_Rol from SEG_Rol WHERE idRol=@idRol;   -- para auditoria
	exec PR_SEG_Auditoria @ik_TableName,'U',#del_SEG_Rol, #ins_SEG_Rol, @vP_UserName --para auditoria
	drop table #ins_SEG_Rol; --para auditoria
	drop table #del_SEG_Rol; --para auditoria 
End

