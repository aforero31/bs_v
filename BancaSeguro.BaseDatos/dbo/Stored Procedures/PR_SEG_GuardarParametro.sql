/* **************************************************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU014 Parametrizacin General
AUTOR: Wilver Guillero Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013.
OBJETIVO: Este procedimiento inserta un nuevo parametro general y devuelve una bandera si existe no lo inserta
FECHA CREACIÓN: 18/04/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se modifica para guardar el log en la tabla de auditoria
REQUERIMIENTO: 
AUTOR: Andrés Combariza
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 19/05/2016
****************************************************************************************************************************************************
MODIFICACIONES: Se agrega el campo Visible
REQUERIMIENTO: Pendientes BancaSeguros Octubre 2016 - SD1588485
AUTOR: Nelson Hernando Pardo Peláez
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 13/10/2016
****************************************************************************************************************************************************
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_GuardarParametro]
	@idTipoDato INT = NULL,
	@valor VARCHAR(50) = NULL,
	@descripcion VARCHAR(50) = NULL,
	@activo BIT = NULL,
	@vP_UserName varchar(128) --para auditoria
AS
BEGIN
declare @ik_TableName varchar(128) = 'SEG_Parametro'
	CREATE TABLE #Parametro
	(
		idTipoDato INT,
		valor VARCHAR(50),
		descripcion VARCHAR(50),
		activo BIT,
		visible BIT
	) 

	INSERT INTO  #Parametro VALUES(@idTipoDato, @valor, @descripcion, @activo, 1)

	MERGE SEG_Parametro AS T
	USING #Parametro AS S
	ON (T.valor = S.valor AND T.descripcion = S.descripcion) 
	WHEN NOT MATCHED BY TARGET 
		THEN INSERT(idTipoDato, valor, descripcion, fechaModificacion, activo, visible) VALUES(S.idTipoDato, S.valor, S.descripcion, GETDATE(), S.activo, 1)
	OUTPUT $action AS accion , inserted.*;

	DROP TABLE #Parametro

	declare @idParametro int = scope_identity()
		select * into #del_SEG_Parametro from SEG_Parametro WHERE idParametro = @idParametro  -- para auditoria
		select * into #ins_SEG_Parametro from SEG_Parametro WHERE idParametro = null  -- para auditoria
		exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_Parametro, #ins_SEG_Parametro, @vP_UserName --para auditoria
		drop table #ins_SEG_Parametro --para auditoria
		drop table #del_SEG_Parametro; --para auditoria
END