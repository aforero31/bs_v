/**************************************************************************************************************
CREACION
REQUERIMIENTO:	SD1588485
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Este procedimiento guarda un asesor si no existe
FECHA DE CREACION: 01/02/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES:  Procedimiento se encuentra sin insercion de numero de identificacion del asesor respecto al SP que se encontraba en desarrollo
				Se agrega la insercion para el numero de identificacion del asesor
REQUERIMIENTO: BUG 1224
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 27/04/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se quita parametro idtipoidentificacion ya que no se utilizaba 
REQUERIMIENTO: SD1588485-Refinamiento BUG 1224
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 27/04/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: se modifica la logica para evitar error de collaction servidor Base de datps
REQUERIMIENTO: SD1588485
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 05/12/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_GuardarAsesor]
	@idAsesor VARCHAR(50) = NULL,
	@identificacion VARCHAR(20) = NULL,
	@idOficina INT = NULL,
	@nombre VARCHAR(100) = NULL

AS
BEGIN
	DECLARE @CidAsesor INT = 0
 	SELECT @CidAsesor = isnull(count(idAsesor),0) FROM SEG_Asesor WHERE idAsesor = @idAsesor
	IF @CidAsesor > 0 
	BEGIN 
		UPDATE SEG_Asesor
		SET NumeroIdentificacion = @identificacion,
		nombre = @nombre,
		idOficina = @idOficina
		WHERE idAsesor = @idAsesor
	END 
	ELSE
	BEGIN 
		INSERT INTO SEG_Asesor (idAsesor, idOficina, nombre, NumeroIdentificacion)
		VALUES(@idAsesor, @idOficina, @nombre, @identificacion)
	END 

END