
/****************************************************************************************************************
REQUERIMIENTO: SD4992318 - Consultar Usuario
DESCRIPCIÓN: SD4992318 Entrega archivo de emisión Cardif venta seguro fradude ATM desde Bancaseguros .v3(estimado IG) (003).docx
AUTOR: Paulo Andrés Mora.
EMPRESA: UT - BAC
FECHA DE CREACIÓN: 2016-06-16
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_Aplicacion_Consultar_User] 
	@IdUsuario int = NULL,
	@Login VARCHAR(100) = NULL,
	@Nombre VARCHAR(100) = NULL,
	@Password VARCHAR(250) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT 
	   [IdUsuario]
      ,[Login]
      ,[Nombre]
      ,[Password]
  FROM [dbo].[SEG_Aplicacion]
  where
  ISNULL(@IdUsuario , [IdUsuario]) = [IdUsuario]
  AND ISNULL(@Login , [Login]) = [Login]
  AND ISNULL(@Nombre , [Nombre]) = [Nombre]
  AND ISNULL(@Password , [Password]) = [Password]
END