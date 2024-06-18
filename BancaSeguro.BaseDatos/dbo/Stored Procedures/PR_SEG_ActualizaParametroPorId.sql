/***************************************************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU014 Parametrizacion General
AUTOR: Wilver Guillero Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013.
OBJETIVO: Este procedimiento actualiza un Parametro por su id
FECHA CREACIÓN: 18/04/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se modifica para guardar el log en la tabla de auditoria
REQUERIMIENTO: SD1588485 - HU014 Parametrizacion General
AUTOR: Andrés Combariza 
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 04/05/2016
***************************************************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ActualizaParametroPorId]
	@idParametro INT,
	@idTipoDato INT,
	@valor VARCHAR(50),
	@descripcion VARCHAR(50),
	@activo BIT,
	@vP_UserName varchar(128) --Auditoria

AS
BEGIN
	declare @ik_TableName varchar(128) = 'SEG_Parametro'
	select * into #ins_SEG_Parametro from SEG_Parametro WHERE idParametro = @idParametro  -- para auditoria 
	UPDATE dbo.SEG_Parametro
	SET
		--idParametro - this column value is auto-generated
		idTipoDato = @idTipoDato, -- int
		valor = @valor, -- varchar
		descripcion = @descripcion, -- varchar
		fechaModificacion = GETDATE(), -- datetime
		activo = @activo -- bit
	WHERE idParametro = @idParametro

	select * into #del_SEG_Parametro from SEG_Parametro WHERE idParametro = @idParametro  -- para auditoria
	exec PR_SEG_Auditoria @ik_TableName,'U',#del_SEG_Parametro, #ins_SEG_Parametro, @vP_UserName --para auditoria
	drop table #ins_SEG_Parametro --para auditoria
	drop table #del_SEG_Parametro --para auditoria

END