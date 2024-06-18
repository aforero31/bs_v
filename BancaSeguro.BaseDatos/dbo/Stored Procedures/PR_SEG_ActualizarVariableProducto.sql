/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-HU009-Parametrizar Variables Venta 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO : Actualiza Variable Producto 
FECHA DE CREACIÓN: 2016-07-06
---------------------------------------------------------------------------------------------------------------
*************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_ActualizarVariableProducto] 
	-- Add the parameters for the stored procedure here
	@idVariableProducto int,
    @nombreCampo varchar(50),
    @estado bit,
	@existe bit OUTPUT,
	@vP_UserName varchar(128) --para auditoria
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SET @existe = 0
    -- Insert statements for procedure here
	IF NOT EXISTS(SELECT * FROM SEG_VariableProducto WHERE idVariableProducto <> @idVariableProducto AND nombreCampo = @nombreCampo)
	BEGIN
	declare @ik_TableName varchar(128) = 'SEG_VariableProducto'
	
	select * into #ins_SEG_VariableProducto from SEG_VariableProducto WHERE idVariableProducto = @idVariableProducto  -- para auditoria
	
	UPDATE SEG_VariableProducto
	SET nombreCampo = @nombreCampo
	,estado = @estado 
	WHERE 
	idVariableProducto = @idVariableProducto
	 
	select * into #del_SEG_VariableProducto from SEG_VariableProducto WHERE idVariableProducto = @idVariableProducto  -- para auditoria
	
	exec PR_SEG_Auditoria @ik_TableName,'U',#del_SEG_VariableProducto, #ins_SEG_VariableProducto, @vP_UserName --para auditoria
	drop table #ins_SEG_VariableProducto --para auditoria
	drop table #del_SEG_VariableProducto; --para auditoria
						
	END
	ELSE
	SET @existe = 1
END