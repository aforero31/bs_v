/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-Banca Seguros HU015-ParametrizarAseguradora 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Consulta Aseguradora
FECHA DE CREACIÓN: 2016-04-14
---------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se realizan cambios se quita 
REQUERIMIENTO: SD1588485 - HU018 Consultar Editar Producto
AUTOR: INTERGRUPO\WZALDUA
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE CREACIÓN: 15/07/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarAseguradoras]
	-- Add the parameters for the stored procedure here
	@nombre varchar(50),
	@codigo varchar(50),
	@idTipoIdentificacion int,
	@identificacion varchar(50),
	@activo BIT
	  
AS
BEGIN

	SELECT sa.idAseguradora
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
  WHERE 
  (sa.nombre like '' + @nombre + '%' OR @nombre IS NULL) AND
  (sa.codigoSuperintendencia = @codigo OR @codigo IS NULL) AND
  (sa.idTipoIdentificacion = @idTipoIdentificacion OR @idTipoIdentificacion IS NULL) AND
  (sa.identificacion = @identificacion OR @identificacion IS NULL) AND
  (sa.activo = @activo OR @activo IS NULL)
END