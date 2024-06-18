/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU009-Parametrizar Variables Venta 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO : Inserta Item Maestra 
FECHA DE CREACIÓN: 2016-07-07
---------------------------------------------------------------------------------------------------------------
*************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_InsertarItemMaestra] 
	-- Add the parameters for the stored procedure here
    @idMaestra int,
    @codigo nvarchar(50),
    @valor varchar(100),
    @activo bit,
	@existe bit OUTPUT,
	@vP_UserName varchar(128) --para auditoria
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SET @existe = 0
    -- Insert statements for procedure here
	IF NOT EXISTS(SELECT * FROM SEG_ItemMaestra WHERE idMaestra = @idMaestra AND codigo = @codigo)
	BEGIN
	declare @ik_TableName varchar(128) = 'SEG_ItemMaestra'
	INSERT INTO SEG_ItemMaestra
           ([idMaestra]
           ,[codigo]
           ,[valor]
           ,[activo])
     VALUES
           (@idMaestra
           ,@codigo
           ,@valor
           ,@activo)
			
		
		select * into #del_SEG_ItemMaestra from SEG_ItemMaestra WHERE idMaestra = @idMaestra AND codigo = @codigo  -- para auditoria
		select * into #ins_SEG_ItemMaestra from SEG_ItemMaestra WHERE idMaestra = null  -- para auditoria
		exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_ItemMaestra, #ins_SEG_ItemMaestra, @vP_UserName --para auditoria
		drop table #ins_SEG_ItemMaestra; --para auditoria
		drop table #del_SEG_ItemMaestra; --para auditoria				
	END
	ELSE
	SET @existe = 1
END