/**************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Este procedimiento Consulta Oficinas Por el Id Oficina
FECHA DE CREACIÓN: 09/02/2016
---------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_ConsultarOficinaPorCodigo]

@idOficina INT

AS
	BEGIN

		SELECT	idOficina,
				nombre,
				activo
		
		FROM	SEG_Oficina

		WHERE	activo = 1
				AND idOficina = @idOficina

	END