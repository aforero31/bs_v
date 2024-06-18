/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU009-Parametrizar Variables Venta 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO : Consulta Maestra 
FECHA DE CREACIÓN: 2016-07-06
---------------------------------------------------------------------------------------------------------------
*************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_ConsultarMaestra] 
	-- Add the parameters for the stored procedure here
	@idMaestra int,
    @nombre varchar(50),
    @activo bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
	   [idMaestra]
      ,[nombre]
      ,[activo]
    FROM SEG_Maestra
    WHERE 
    (idMaestra = @idMaestra OR @idMaestra IS NULL) AND
    (nombre like '' + @nombre + '%' OR @nombre IS NULL) AND
    (activo = @activo OR @activo IS NULL) 
END