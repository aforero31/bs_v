/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU018 Consultar Editar Producto
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para consultar los tipos de identificacion por id seguro
FECHA DE MODIFICACIÓN: 17/06/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarTiposIdentificacionPorIdSeguro]
	@idSeguro INT
AS
BEGIN
	SELECT  ssti.idTipoIdentificacion,
			sti.nombre

	FROM	dbo.SEG_SeguroTipoIdentificacion ssti INNER JOIN 
			dbo.SEG_TipoIdentificacion sti ON sti.idTipoIdentificacion = ssti.idTipoIdentificacion

	WHERE ssti.idSeguro = @idSeguro

END