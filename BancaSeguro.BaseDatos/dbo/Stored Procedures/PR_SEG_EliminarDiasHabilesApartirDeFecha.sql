/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU DIA HABIL
AUTOR: INTERGRUPO/wzaldua	
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para eliminar las fechas desde una ingresada
FECHA DE CREACIÓN: 16/08/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_EliminarDiasHabilesApartirDeFecha]
@fecha DATE
AS

BEGIN
	DELETE FROM SEG_DiaHabil
	WHERE Fecha >= @fecha                                       
END