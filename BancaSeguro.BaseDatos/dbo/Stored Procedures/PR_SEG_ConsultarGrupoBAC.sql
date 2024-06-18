/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-Banca Seguros HU020-AdministrarRol 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Consulta Aseguradora
FECHA DE CREACIÓN: 2016-04-27
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarGrupoBAC] 
	-- Add the parameters for the stored procedure here
	@nombre varchar(50),
	@codigo varchar(10),
	@activo BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [idGrupo]
      ,[nombreGrupo]
      ,[codigoGrupo]
      ,[activo]
    FROM SEG_GrupoBAC
    WHERE (nombreGrupo like '' + @nombre + '%' OR @nombre IS NULL) AND
          (codigoGrupo = @codigo OR @codigo IS NULL) AND
          (activo = @activo  OR @activo IS NULL)
     
END