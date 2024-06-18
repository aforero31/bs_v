/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU018 Consultar Editar Producto
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para consultar todos los seguros
FECHA DE MODIFICACIÓN: 14/06/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarTodosLosSeguros]
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
				B.idAseguradora,
				B.nombre AS nombreAseguradora,
				B.codigoSuperintendencia,
				A.idCanalVenta,
				B.activo AS activoAseguradora,
				A.activo
				
        FROM	SEG_Seguro A WITH(NOLOCK) INNER JOIN 
				SEG_Aseguradora B WITH(NOLOCK) ON B.idAseguradora = A.idAseguradora 
END