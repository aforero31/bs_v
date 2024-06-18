/*****************************************************************************************
CREACIÓN
REQUERIMIENTO:	SD1588485-Sprint 2 / HU001.6
AUTOR: Carlos Piza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO:	Consulta la informacion del conyuge de una poliza
FECHA DE MODIFICACIÓN: 22/02/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
*****************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarInformacionConyugePorConsecutivoPoliza]
(@Consecutivo VARCHAR(50))
AS
BEGIN
	/************DATOS DEL CONYUGE DE LA POLIZA************/
	SELECT SEG_Conyuge.primerNombre AS PrimerNombreConyuge
	,SEG_Conyuge.segundoNombre AS SegundoNombreConyuge
	,SEG_Conyuge.primerApellido AS PrimerApellidoConyuge
	,SEG_Conyuge.segundoApellido AS SegundoApellidoConyuge
	,SEG_TipoIdentificacion.abreviatura AS TipoIdentificacionAbreviatura
	,SEG_Conyuge.identificacion AS NumeroIdentificacionConyuge
	,CONVERT(varchar(10), SEG_Conyuge.fechaNacimiento,112) AS FechaNacimientoConyuge
	,'' AS CiudadNacimientoConyuge
	,SEG_Genero.nombre AS GeneroConyuge
	,'' AS DireccionConyuge
	,'' AS CiudadResidenciaConyuge
	,'' AS TelefonoConyuge
	FROM SEG_Venta
	INNER JOIN SEG_Conyuge 
	ON SEG_Venta.idVenta = SEG_Conyuge.idVenta
	INNER JOIN SEG_TipoIdentificacion
	ON SEG_Conyuge.idTipoIdentificacion = SEG_TipoIdentificacion.idTipoIdentificacion
	INNER JOIN SEG_Genero
	ON SEG_Conyuge.IdGenero = SEG_Genero.idGenero
	WHERE consecutivo = @Consecutivo
END