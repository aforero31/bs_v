/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-Banca Seguros HU015-ParametrizarAseguradora 
AUTOR: Paulo Andrés Mora.
EMPRESA: UT - BAC
OBJETIVO: Consulta Aseguradora Por Id 
FECHA DE CREACIÓN: 2016-04-14
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarAseguradoraPorId]
	-- Add the parameters for the stored procedure here
	@idAseguradora int 
AS
BEGIN
	SELECT	sa.idAseguradora
			,sa.nombre
			,sa.codigoSuperintendencia
			,sa.idTipoIdentificacion
			,sti.abreviatura
			,sa.identificacion
			,sa.contacto
			,sa.telefono
			,sa.correo
			,sa.activo
			,sa.consecutivoInicial
			,sa.consecutivoActual

  FROM	dbo.SEG_Aseguradora sa WITH(NOLOCK) INNER JOIN 
		dbo.SEG_TipoIdentificacion sti WITH(NOLOCK) ON sti.idTipoIdentificacion = sa.idTipoIdentificacion
  WHERE idAseguradora = @idAseguradora
END