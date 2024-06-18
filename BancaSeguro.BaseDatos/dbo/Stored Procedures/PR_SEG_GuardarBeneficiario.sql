/* *************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-Banca Seguros
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Este procedimiento guarda un asesor si no existe
FECHA DE CREACIÓN: 01/02/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se realiza modificación a la variable @identificacion a tipo varchar ya que en la aplicacion estaba como INT
REQUERIMIENTO: SD1811974
AUTOR: César Augusto Blandón Montero
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 08/03/2017
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_GuardarBeneficiario]
		@idVenta INT = NULL,
	    @idParentesco INT = NULL,
	    @idTipoIdentificacion INT = NULL,
	    @identificacion VARCHAR(16) = NULL,
	    @nombres VARCHAR(50)= NULL,
	    @apellidos VARCHAR(50)= NULL,
	    @porcentaje INT = NULL

AS
BEGIN
	INSERT INTO dbo.SEG_Beneficiario
	(
	    idVenta,
	    idParentesco,
	    idTipoIdentificacion,
	    identificacion,
	    nombres,
	    apellidos,
	    porcentaje
	)
	VALUES
	(
	    @idVenta,
	    @idParentesco,
	    @idTipoIdentificacion,
	    @identificacion,
	    @nombres,
	    @apellidos,
	    @porcentaje
	)
END