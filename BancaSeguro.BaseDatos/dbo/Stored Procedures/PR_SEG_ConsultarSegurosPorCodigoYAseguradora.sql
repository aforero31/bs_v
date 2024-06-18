/**************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU018 - Parametrizacion Prodcuto
AUTOR: INTERGRUPO\wzaldua
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Este procedimiento consultalos seguros por codigo seguro y por codigo aseguradora
FECHA DE CREACIÓN: 02/08/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarSegurosPorCodigoYAseguradora]

	@codigoSeguro INT = NULL ,
	@codigoAseguradora INT = NULL

	AS
    	BEGIN

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

		WHERE	A.codigo = @codigoSeguro AND
				C.idAseguradora = @codigoAseguradora
  	END