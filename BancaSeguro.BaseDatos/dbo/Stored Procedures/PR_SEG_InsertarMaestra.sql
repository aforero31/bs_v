/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU009-Parametrizar Variables Venta 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO : Inserta Maestra 
FECHA DE CREACIÓN: 2016-07-07
---------------------------------------------------------------------------------------------------------------
*************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_InsertarMaestra] 
	-- Add the parameters for the stored procedure here
    @nombre varchar(50),
    @activo bit,
	@existe bit OUTPUT,
	@idMaestra int OUTPUT,
	@vP_UserName varchar(128) --para auditoria
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SET @existe = 0
    -- Insert statements for procedure here
	IF NOT EXISTS(SELECT * FROM SEG_Maestra WHERE nombre = @nombre)
	BEGIN
	declare @ik_TableName varchar(128) = 'SEG_Maestra'
	INSERT INTO SEG_Maestra
            ([nombre]
           ,[activo])
     VALUES
           (@nombre
           ,@activo)
			
		SET @idMaestra = (SELECT IDENT_CURRENT ('SEG_Maestra'));
		
		select * into #del_SEG_Maestra from SEG_Maestra WHERE idMaestra = @idMaestra  -- para auditoria
		select * into #ins_SEG_Maestra from SEG_Maestra WHERE idMaestra = null  -- para auditoria
		exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_Maestra, #ins_SEG_Maestra, @vP_UserName --para auditoria
		drop table #ins_SEG_Maestra; --para auditoria
		drop table #del_SEG_Maestra; --para auditoria

						
	END
	ELSE
	SET @existe = 1
END