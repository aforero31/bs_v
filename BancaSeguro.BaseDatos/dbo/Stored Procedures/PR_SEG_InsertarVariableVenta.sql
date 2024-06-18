/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 HU009-Parametrizar Variables Venta 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO : Inserta Variable Venta 
FECHA DE CREACIÓN: 2016-07-06
---------------------------------------------------------------------------------------------------------------
*************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_InsertarVariableVenta] 
	-- Add the parameters for the stored procedure here
	@idVenta int,
    @idVariableProducto int,
    @valor varchar(MAX),
	@vP_UserName varchar(128) --para auditoria
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @ik_TableName varchar(128) = 'SEG_VariableVenta';
	
	INSERT INTO SEG_VariableVenta
           ([idVenta]
           ,[idVariableProducto]
           ,[valor])
     VALUES
           (@idVenta
           ,@idVariableProducto
           ,@valor);
			
		declare @idVariableVenta int = (SELECT IDENT_CURRENT ('SEG_VariableVenta'));
		
		select * into #del_SEG_VariableVenta from SEG_VariableVenta WHERE idVariableVenta = @idVariableVenta  -- para auditoria
		select * into #ins_SEG_VariableVenta from SEG_VariableVenta WHERE idVariableVenta = null  -- para auditoria
		exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_VariableVenta, #ins_SEG_VariableVenta, @vP_UserName --para auditoria
		drop table #ins_SEG_VariableVenta; --para auditoria
		drop table #del_SEG_VariableVenta; --para auditoria
END