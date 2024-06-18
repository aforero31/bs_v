/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU DIA HABIL
AUTOR: INTERGRUPO/wzaldua	
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para insertar un dia habil
FECHA DE CREACIÓN: 16/08/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarDiaHabil]
@fecha DATE
AS

BEGIN

	INSERT dbo.SEG_DiaHabil
	(
		--Id - this column value is auto-generated
		Fecha
	)
	VALUES
	(
		-- Id - int
		@fecha -- Fecha - date
	)
                                    
END