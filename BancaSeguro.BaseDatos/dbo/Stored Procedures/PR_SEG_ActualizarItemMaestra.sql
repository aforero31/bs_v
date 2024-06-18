/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-HU009-Parametrizar Variables Venta 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO : Actualiza Item Maestra 
FECHA DE CREACIÓN: 2016-07-07
*************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_ActualizarItemMaestra] 
	-- Add the parameters for the stored procedure here
	@idMaestra int,
	@codigo nvarchar(50),
	@valor varchar(50),
    @activo bit,
	@vP_UserName varchar(128) --para auditoria
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ik_TableName varchar(128) = 'SEG_ItemMaestra'
	
	select * into #ins_SEG_ItemMaestra from SEG_ItemMaestra WHERE idMaestra = @idMaestra AND codigo = @codigo;  -- para auditoria
	
	UPDATE SEG_ItemMaestra
	SET 
	valor = @valor,
	activo = @activo
	WHERE 
	idMaestra = @idMaestra AND
	codigo = @codigo;
	 
	select * into #del_SEG_ItemMaestra from SEG_ItemMaestra WHERE idMaestra = @idMaestra AND codigo = @codigo;  -- para auditoria
	
	exec PR_SEG_Auditoria @ik_TableName,'U',#del_SEG_ItemMaestra, #ins_SEG_ItemMaestra, @vP_UserName --para auditoria
	drop table #ins_SEG_ItemMaestra; --para auditoria
	drop table #del_SEG_ItemMaestra; --para auditoria
						
END