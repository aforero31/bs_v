/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU009-Parametrizar Variables Venta 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO : Elimina Item Maestra 
FECHA DE CREACIÓN: 2016-07-07
---------------------------------------------------------------------------------------------------------------
*************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_EliminarItemMaestra] 
	-- Add the parameters for the stored procedure here
    @idMaestra int,
    @codigo nvarchar(50),
	@existe bit OUTPUT,
	@vP_UserName varchar(128) --para auditoria
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SET @existe = 0
    -- Insert statements for procedure here
	IF NOT EXISTS
	(
		SELECT VV.* FROM SEG_VariableVenta VV
		INNER JOIN SEG_VariableProducto VP ON VV.idVariableProducto = VV.idVariableProducto
		INNER JOIN SEG_ItemMaestra IM ON VP.idMaestra = IM.idMaestra AND VV.valor = IM.codigo
		WHERE 
		IM.idMaestra = @idMaestra AND  
		IM.codigo = @codigo
	)
	BEGIN
		
	declare @ik_TableName varchar(128) = 'SEG_ItemMaestra'
	select * into #ins_SEG_ItemMaestra from SEG_ItemMaestra WHERE idMaestra = @idMaestra AND codigo = @codigo
	
	DELETE FROM SEG_ItemMaestra WHERE idMaestra = @idMaestra AND codigo = @codigo
			
		  -- para auditoria
	select * into #del_SEG_ItemMaestra from SEG_ItemMaestra WHERE idMaestra = @idMaestra AND codigo = @codigo  -- para auditoria
	exec PR_SEG_Auditoria @ik_TableName,'D',#del_SEG_ItemMaestra, #ins_SEG_ItemMaestra, @vP_UserName --para auditoria
	drop table #ins_SEG_ItemMaestra; --para auditoria
	drop table #del_SEG_ItemMaestra; --para auditoria				
	END
	ELSE
	SET @existe = 1
END