
/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-HU009-Parametrizar Variables Venta 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO : Actualiza Maestra 
FECHA DE CREACIÓN: 2016-07-07
---------------------------------------------------------------------------------------------------------------
*************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_ActualizarMaestra] 
	-- Add the parameters for the stored procedure here
	@idMaestra int,
    @activo bit,
	@vP_UserName varchar(128) --para auditoria
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @ik_TableName varchar(128) = 'SEG_Maestra'
	
	select * into #ins_SEG_Maestra from SEG_Maestra WHERE idMaestra = @idMaestra  -- para auditoria
	
	UPDATE SEG_Maestra
	SET activo = @activo
	WHERE 
	idMaestra = @idMaestra
	 
	select * into #del_SEG_Maestra from SEG_Maestra WHERE idMaestra = @idMaestra  -- para auditoria
	
	exec PR_SEG_Auditoria @ik_TableName,'U',#del_SEG_Maestra, #ins_SEG_Maestra, @vP_UserName --para auditoria
	drop table #ins_SEG_Maestra; --para auditoria
	drop table #del_SEG_Maestra; --para auditoria
						
END