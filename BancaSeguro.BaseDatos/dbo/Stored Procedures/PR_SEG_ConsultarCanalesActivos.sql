/*****************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Consulta los canales de venta activos
FECHA DE MODIFICACIÓN: 03/05/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
*****************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarCanalesActivos]
AS

BEGIN
	SELECT idCanalVenta, 
		   codigo, 
		   nombre, 
		   activo
	FROM [dbo].[SEG_CanalVenta]
	WHERE activo = 1
END