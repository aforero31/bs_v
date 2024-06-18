/***************************************************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU016 Parametrizar Canal de Venta
AUTOR: Wilver Guillero Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013.
OBJETIVO: Este procedimiento inserta un nuevo canal de venta y devuelve una bandera si existe no lo inserta
FECHA CREACIÓN: 13/04/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se modifica para guardar el log en la tabla de auditoria
REQUERIMIENTO: SD1588485
AUTOR: Andrés Combariza
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 19/05/2016
****************************************************************************************************************************************************
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_GuardarCanalVenta]
	@codigo INT,
	@nombre VARCHAR(50),
	@activo BIT,
	@vP_UserName varchar(128) --para auditoria

AS
BEGIN
	declare @ik_TableName varchar(128) = 'SEG_CanalVenta'
	CREATE TABLE #CanalVenta
	(
		codigo INT,
		nombre VARCHAR(50),
		activo BIT
	) 

	INSERT INTO #CanalVenta VALUES(@codigo, @nombre, @activo)

	MERGE SEG_CanalVenta AS T
	USING #CanalVenta AS S
	ON (T.codigo = S.codigo) 
	WHEN NOT MATCHED BY TARGET 
		THEN INSERT(codigo, nombre, activo) VALUES(S.codigo, S.nombre, S.activo)
	OUTPUT $action AS accion , inserted.*;

	DROP TABLE #CanalVenta

	declare @idCanalVenta int = scope_identity()
		select * into #del_SEG_CanalVenta from SEG_CanalVenta WHERE idCanalVenta = @idCanalVenta  -- para auditoria
		select * into #ins_SEG_CanalVenta from SEG_CanalVenta WHERE idCanalVenta = null  -- para auditoria
		exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_CanalVenta, #ins_SEG_CanalVenta, @vP_UserName --para auditoria
		drop table #ins_SEG_CanalVenta --para auditoria
		drop table #del_SEG_CanalVenta; --para auditoria

END