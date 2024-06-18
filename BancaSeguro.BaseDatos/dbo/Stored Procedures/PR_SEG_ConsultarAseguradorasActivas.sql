/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para consultar las aseguradoras activas
FECHA DE MODIFICACIÓN: 19/04/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarAseguradorasActivas]

AS

BEGIN

	SELECT	 idAseguradora
			,nombre
			,codigoSuperintendencia
			,idTipoIdentificacion
			,identificacion
			,contacto
			,telefono
			,correo
			,activo
			,consecutivoInicial
			,consecutivoActual	  
	FROM SEG_Aseguradora
	WHERE activo = 1

END