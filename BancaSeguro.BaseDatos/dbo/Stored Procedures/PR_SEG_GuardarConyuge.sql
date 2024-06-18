/* *************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-Banca Seguros
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Este procedimiento guarda un conyuge
FECHA DE CREACIÓN: 01/02/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_GuardarConyuge]

	 @idVenta INT = NULL,
     @idTipoIdentificacion INT = NULL,
     @identificacion VARCHAR(16) = NULL,
     @primerNombre VARCHAR(50) = NULL,
     @segundoNombre VARCHAR(50) = NULL,
     @primerApellido VARCHAR(50) = NULL,
     @segundoApellido VARCHAR(50) = NULL,
     @fechaNacimiento DATETIME = NULL,
     @idgenero int = NUL

AS
BEGIN
 INSERT INTO dbo.SEG_Conyuge
 (
     idVenta,
     idTipoIdentificacion,
     identificacion,
     primerNombre,
     segundoNombre,
     primerApellido,
     segundoApellido,
     fechaNacimiento,
     idgenero
 )
 VALUES
 (
     @idVenta,
     @idTipoIdentificacion,
     @identificacion,
     @primerNombre,
     @segundoNombre,
     @primerApellido,
     @segundoApellido,
     @fechaNacimiento,
     @idgenero
 )
END