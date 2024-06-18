/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU009-Parametrizar Variables Venta 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO : Inserta Variable Producto 
FECHA DE CREACIÓN: 2016-07-06
---------------------------------------------------------------------------------------------------------------
*************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_InsertarVariableProducto] 
	-- Add the parameters for the stored procedure here
	@idSeguro int,
    @nombreCampo varchar(50),
    @idTipoDato int,
    @longitud int,
    @idMaestra int,
    @orden int,
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
	IF NOT EXISTS(SELECT * FROM SEG_VariableProducto WHERE idSeguro = @idSeguro AND nombreCampo = @nombreCampo)
	BEGIN
	declare @ik_TableName varchar(128) = 'SEG_VariableProducto'
	INSERT INTO SEG_VariableProducto
           ([idSeguro]
           ,[nombreCampo]
           ,[idTipoDato]
           ,[longitud]
           ,[idMaestra]
           ,[orden]
           ,[estado])
     VALUES
           (@idSeguro
           ,@nombreCampo
           ,@idTipoDato
           ,@longitud
           ,@idMaestra
           ,@orden
           ,@estado)
			
		declare @idVariableProducto int = (SELECT IDENT_CURRENT ('SEG_VariableProducto'));
		
		select * into #del_SEG_VariableProducto from SEG_VariableProducto WHERE idVariableProducto = @idVariableProducto  -- para auditoria
		select * into #ins_SEG_VariableProducto from SEG_VariableProducto WHERE idVariableProducto = null  -- para auditoria
		exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_VariableProducto, #ins_SEG_VariableProducto, @vP_UserName --para auditoria
		drop table #ins_SEG_VariableProducto --para auditoria
		drop table #del_SEG_VariableProducto; --para auditoria

						
	END
	ELSE
	SET @existe = 1
END