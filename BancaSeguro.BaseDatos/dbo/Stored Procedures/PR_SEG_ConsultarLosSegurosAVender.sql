/**************************************************************************************************************
CREACIÓN
REQUERIMIENTO: 
AUTOR: Fernando Fernandez P.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Este procedimiento consulta SEG_SeguroTipoIdentificacion activos existentes
FECHA DE CREACIÓN: 12/01/2016
---------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agregan parametros para filtro de seguro
REQUERIMIENTO:
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 19/01/2016
---------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agregan los campos EdadMinimaConyugue y EdadMaximaConyugue
REQUERIMIENTO: Refinamiento Sprint 1 / Sprint 2
AUTOR: INTERGRUPO\CPIZA
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 09/02/2016
---------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agregan INNER JOIN a Aseguradora y campos en el Select
REQUERIMIENTO: Refinamiento Sprint 1 / Sprint 2
AUTOR: Wilver Guillermo Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 09/02/2016
---------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agrega para la consulta el campo MaximoBeneficiarios
REQUERIMIENTO: SD1588485 - Deuda
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 10/06/2016
---------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se agrega INNER JOIN para que traiga los seguros parametrizados completamente
REQUERIMIENTO: SD1588485 - Deuda
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 30/06/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarLosSegurosAVender]

--DECLARE
--	@idTipoDeIdentificacion INT = 1 ,
--	@fechaDeNacimientoCliente DATETIME = '1990-09-09', --25 AÑOS
--	@genero VARCHAR(1) = 'M'

	@idTipoDeIdentificacion INT = NULL ,
	@fechaDeNacimientoCliente DATETIME = NULL,
	@genero INT = NULL

	AS
    	BEGIN

		DECLARE
		@anos int

		SET @anos = (SELECT (cast(datediff(dd,@fechaDeNacimientoCliente,GETDATE()) / 365.25 as int)))

        SELECT DISTINCT
				A.idSeguro,
				A.nombre,
				descripcion,
				codigo,
				conyuge,
				beneficiario,
				MaximoBeneficiarios,
				edadMinimaMujer,
				edadMaximaMujer,
				edadMinimaHombre,
				edadMaximaHombre,
				EdadMinimaConyugue,
				EdadMaximaConyugue,
				A.numeroMaximoSegurosPorCliente,
				A.numeroMaximoVentaSegurosPorCuentaCliente,
				C.idAseguradora,
				C.nombre AS nombreAseguradora,
				C.codigoSuperintendencia,
				C.activo AS activoAseguradora,
				A.activo
				
        FROM	SEG_Seguro A INNER JOIN 
				SEG_SeguroTipoIdentificacion B ON A.idSeguro = B.idSeguro INNER JOIN	
				SEG_Aseguradora C ON C.idAseguradora = A.idAseguradora INNER JOIN
				dbo.SEG_DocumentoPoliza sdp ON sdp.idSeguro = A.idSeguro
				
		WHERE	A.activo = 1 AND 
				sdp.activa = 1 AND
				B.idTipoIdentificacion = isnull(@idTipoDeIdentificacion,B.idTipoIdentificacion) AND
				A.edadMinimaMujer <= (CASE @genero WHEN 1 THEN @anos ELSE A.edadMinimaMujer END) AND
				A.edadMaximaMujer >= (CASE @genero WHEN 1 THEN @anos ELSE A.edadMaximaMujer END) AND
				A.edadMinimaHombre <= (CASE @genero WHEN 2 THEN @anos ELSE A.edadMinimaHombre END) AND
				A.edadMaximaHombre >= (CASE @genero WHEN 2 THEN @anos ELSE A.edadMaximaHombre END)
  	END