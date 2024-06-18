/* *************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: Wilver Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Este procedimiento adiciona un nuevo rol
FECHA DE CREACIÓN: 08/01/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se elimina campo es Autorizador se adcion parametros de salida
REQUERIMIENTO: SD1588485-HU020-AdministrarRol
AUTOR:         Paulo Mora
EMPRESA:	   Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 2016-04-26
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarRol]
(
@nombre varchar(50), 
@activo bit,
@existe bit OUTPUT,
@nuevoId int OUTPUT,
@vP_UserName varchar(128) --para auditoria
)
AS
BEGIN
   SET @existe =  0;
   IF NOT EXISTS(SELECT * FROM SEG_Rol WHERE nombre = @nombre)
	   BEGIN
	   declare @ik_TableName varchar(128) = 'SEG_Rol'
			INSERT INTO SEG_Rol(nombre, activo) VALUES(@nombre, @activo);
			SELECT @nuevoId = SCOPE_IDENTITY();
			
			declare @idRol int = (SELECT IDENT_CURRENT ('SEG_Rol'));
		
			select * into #ins_SEG_Rol from SEG_Rol WHERE idRol = @idRol  -- para auditoria
			select * into #del_SEG_Rol from SEG_Rol WHERE idRol = null  -- para auditoria
			exec PR_SEG_Auditoria @ik_TableName,'I',#ins_SEG_Rol, #del_SEG_Rol, @vP_UserName --para auditoria
			drop table #ins_SEG_Rol --para auditoria
			drop table #del_SEG_Rol; --para auditoria
	   END
   ELSE
		SET @existe = 1;
END

