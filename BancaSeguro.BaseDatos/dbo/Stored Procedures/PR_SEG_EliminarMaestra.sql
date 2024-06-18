/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU009-Parametrizar Variables Venta 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO : Elimina Maestra 
FECHA DE CREACIÓN: 2016-07-07
---------------------------------------------------------------------------------------------------------------
*************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_EliminarMaestra] 
	-- Add the parameters for the stored procedure here
    @idMaestra int,
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
		INNER JOIN SEG_Maestra M ON VP.idMaestra = M.idMaestra
		WHERE 
		M.idMaestra = @idMaestra 
	)
	BEGIN
	
	IF EXISTS (SELECT VP.* FROM SEG_VariableProducto VP 
		INNER JOIN SEG_Maestra M ON VP.idMaestra = M.idMaestra
		WHERE M.idMaestra = @idMaestra )
	BEGIN
		declare @ik_TableNameVP varchar(128) = 'SEG_VariableProducto'
		select * into #ins_SEG_VariableProducto from SEG_VariableProducto WHERE idMaestra = @idMaestra
	
		DELETE FROM SEG_VariableProducto WHERE idMaestra = @idMaestra
				
	    -- para auditoria
		select * into #del_SEG_VariableProducto from SEG_VariableProducto WHERE idMaestra = @idMaestra  -- para auditoria
		exec PR_SEG_Auditoria @ik_TableNameVP,'D',#del_SEG_VariableProducto, #ins_SEG_VariableProducto, @vP_UserName --para auditoria
		drop table #ins_SEG_VariableProducto; --para auditoria
		drop table #del_SEG_VariableProducto; --para auditoria	
	END	
		
	declare @ik_TableNameIM varchar(128) = 'SEG_ItemMaestra'
	select * into #ins_SEG_ItemMaestra from SEG_ItemMaestra WHERE idMaestra = @idMaestra 
	
	DELETE FROM SEG_ItemMaestra WHERE idMaestra = @idMaestra; 
			
		  -- para auditoria
	select * into #del_SEG_ItemMaestra from SEG_ItemMaestra WHERE idMaestra = @idMaestra  -- para auditoria
	exec PR_SEG_Auditoria @ik_TableNameIM,'D',#del_SEG_ItemMaestra, #ins_SEG_ItemMaestra, @vP_UserName --para auditoria
	drop table #ins_SEG_ItemMaestra; --para auditoria
	drop table #del_SEG_ItemMaestra; --para auditoria		
		
	declare @ik_TableName varchar(128) = 'SEG_Maestra'
	select * into #ins_SEG_Maestra from SEG_Maestra WHERE idMaestra = @idMaestra 
	
	DELETE FROM SEG_Maestra WHERE idMaestra = @idMaestra; 
			
		  -- para auditoria
	select * into #del_SEG_Maestra from SEG_Maestra WHERE idMaestra = @idMaestra  -- para auditoria
	exec PR_SEG_Auditoria @ik_TableName,'D',#del_SEG_Maestra, #ins_SEG_Maestra, @vP_UserName --para auditoria
	drop table #ins_SEG_Maestra; --para auditoria
	drop table #del_SEG_Maestra; --para auditoria				
	END
	ELSE
		SET @existe = 1
END