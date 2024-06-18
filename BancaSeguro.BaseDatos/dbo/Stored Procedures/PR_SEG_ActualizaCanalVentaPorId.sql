/***************************************************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU016 Parametrizar Canal de Venta
AUTOR: Wilver Guillero Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013.
FECHA CREACIÓN: 13/04/2016
OBJETIVO: Este procedimiento actualiza un canal de venta por su id
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se modifica para guardar el log en la tabla de auditoria
AUTOR: Andres Combariza
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 03/05/2016
***************************************************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ActualizaCanalVentaPorId]
	@idCanalVenta INT,
	@codigo INT,
	@nombre VARCHAR(50),
	@activo BIT,
	@vP_UserName varchar(128)

AS
BEGIN
	declare @ik_TableName varchar(128) = 'SEG_CanalVenta'
	select * into #ins_SEG_CanalVenta from SEG_CanalVenta WHERE codigo = @codigo  -- para auditoria  
	UPDATE SEG_CanalVenta
	SET
	    --idCanalVenta - this column value is auto-generated
	    codigo = @codigo, -- int
	    nombre = @nombre, -- varchar
	    activo = @activo -- bit
	WHERE 
		idCanalVenta = @idCanalVenta
	select * into #del_SEG_CanalVenta from SEG_CanalVenta WHERE codigo = @codigo  -- para auditoria
	exec PR_SEG_Auditoria @ik_TableName,'U',#del_SEG_CanalVenta, #ins_SEG_CanalVenta, @vP_UserName --para auditoria
	drop table #ins_SEG_CanalVenta --para auditoria
	drop table #del_SEG_CanalVenta --para auditoria

END