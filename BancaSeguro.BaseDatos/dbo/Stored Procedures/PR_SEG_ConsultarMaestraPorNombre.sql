/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 -HU009-Parametrizar Variables Venta 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO : Consulta Maestra por nombre
FECHA DE CREACIÓN: 2016-07-12
---------------------------------------------------------------------------------------------------------------
*************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_ConsultarMaestraPorNombre] 
	-- Add the parameters for the stored procedure here
    @nombre varchar(50)
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
    nombre = @nombre;
END