/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU018 Consultar Editar Producto
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para consultar un seguro por id
FECHA DE CREACIÓN: 17/06/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarSeguroPorId]
	@idSeguro INT
AS
BEGIN
	 SELECT
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
				A.idCanalVenta,
				C.activo AS activoAseguradora,
				A.activo
				
        FROM	SEG_Seguro A INNER JOIN 
				SEG_Aseguradora C ON C.idAseguradora = A.idAseguradora 

		WHERE	A.idSeguro = @idSeguro
END