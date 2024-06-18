/*****************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Consulta las periodicidades activos
FECHA DE MODIFICACIÓN: 06/05/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
*****************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarPeriodicidadActivos]
AS

BEGIN
	SELECT  idPeriodicidad, 
			nombre, 
			activo, 
			numeroMesesPeriodicidad 
	FROM [dbo].[SEG_Periodicidad]
	WHERE activo = 1
END