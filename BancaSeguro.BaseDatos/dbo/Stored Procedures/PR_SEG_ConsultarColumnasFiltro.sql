CREATE PROCEDURE [dbo].[PR_SEG_ConsultarColumnasFiltro]
@opcion INT = 0
AS
/***************************************************************************************************************************************************
NOMBRE DEL PROGRAMA: [PR_SEG_ConsultarColumnasFiltro]
DESCRIPCION: Consulta las columnas para proghramar el archivo plano (filtros)
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE CREACIÓN: 14/07/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIÓN
REQUERIMIENTO: SD3055584
DESCRIPCION: Se adiciona columna altura en el plano de cancelaciones
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE CREACIÓN: 19/07/2017
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: 
REQUERIMIENTO: 
AUTOR: 
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN:
**************************************************************************************************************/
BEGIN
	IF @opcion = 1 -- Pólizas
	BEGIN
		SELECT COLUMN_NAME as CAMPOS FROM information_schema.columns WHERE table_name = 'VW_SEG_Polizas'
		AND COLUMN_NAME NOT LIKE ('filtro%')
		AND COLUMN_NAME NOT LIKE ('BENEFICIARIOS%')
		UNION ALL
		SELECT 'TIPO_IDENTIFICACION_BENEFICIARIO'
		UNION ALL
		SELECT 'NOMBRE_IDENTIFICACION_BENEFICIARIO'
		UNION ALL
		SELECT 'IDENTIFICACION_BENEFICIARIO'
		UNION ALL
		SELECT 'NOMBRES_BENEFICIARIO'
		UNION ALL
		SELECT 'APELLIDOS_BENEFICIARIO'
		UNION ALL
		SELECT 'PARENTESCO_BENEFICIARIO'
		UNION ALL
		SELECT 'PARTICIPACION_BENEFICIARIO'
							
	END

	IF @opcion = 2 -- Cobros
	BEGIN
		SELECT CASE COLUMN_NAME WHEN 'ALTURACALCULADA' THEN 'ALTURA'
				ELSE COLUMN_NAME END AS CAMPOS FROM information_schema.columns WHERE table_name = 'VW_SEG_DetalleNovPoliza'
		AND COLUMN_NAME NOT LIKE ('filtro%')
		AND COLUMN_NAME NOT LIKE ('ALTURAREAL')
	END

	IF @opcion = 3 -- Cancelaciones y anulaciones
	BEGIN
		SELECT CASE COLUMN_NAME WHEN 'ALTURAREAL' THEN 'ALTURA'
				ELSE COLUMN_NAME END AS CAMPOS FROM information_schema.columns WHERE table_name = 'VW_SEG_DetalleNovPoliza'
		AND COLUMN_NAME NOT LIKE ('filtro%')
		AND COLUMN_NAME NOT LIKE ('PERIODO_COBRO')
		AND COLUMN_NAME NOT LIKE ('INTENTOS_COBRO')
		AND COLUMN_NAME NOT LIKE ('ALTURACALCULADA')

	END
	
END