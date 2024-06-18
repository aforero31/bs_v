/**************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: Fernando Fernandez P.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Este procedimiento modifica SEG_Beneficiario existente
FECHA DE CREACIÓN: 12/01/20162016
---------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
***************************************************************************************************************/

		CREATE PROCEDURE [dbo].[PR_SEG_CrearBeneficiario]
        (
            @idBeneficiario [int],
            @idVenta [int] ,
            @idParentesco [int] ,
            @idTipoIdentificacion [int] ,
            @identificacion [int] ,
            @nombres [varchar](50) ,
            @apellidos [varchar](50) ,
            @porcentaje [int] 

	) AS BEGIN

		INSERT INTO SEG_Beneficiario (
		           idVenta,
                   idParentesco,
                   idTipoIdentificacion,
                   identificacion,
                   nombres,
                   apellidos,
                   porcentaje

        	) VALUES (
                  @idVenta,
                  @idParentesco,
                  @idTipoIdentificacion,
                  @identificacion,
                  @nombres,
                  @apellidos,
                  @porcentaje
		)

	END

