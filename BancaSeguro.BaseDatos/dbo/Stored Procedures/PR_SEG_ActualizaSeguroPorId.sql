/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - HU018 Consultar Editar Producto
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para seguro por id
FECHA DE MODIFICACIÓN: 14/06/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ActualizaSeguroPorId]
	@idSeguro INT = NULL
	,@beneficiario BIT
	,@MaximoBeneficiarios INT
	,@codigo VARCHAR(50)
	,@conyuge BIT
	,@edadMinimaConyugue INT
	,@edadMaximaConyugue INT
	,@edadMinimaHombre INT
	,@edadMaximaHombre INT
	,@edadMinimaMujer INT
	,@edadMaximaMujer INT
	,@idCanalVenta INT
	,@nombre VARCHAR(50)	
	,@numeroMaximoSegurosPorCliente INT
	,@numeroMaximoVentaSegurosPorCuentaCliente INT
	,@activo BIT = NULL 
	,@vP_UserName VARCHAR(128) = ''
AS
BEGIN
	DECLARE @ik_TableName VARCHAR(128) = 'SEG_Seguro'
	SELECT * INTO #del_SEG_Seguro FROM dbo.SEG_Seguro ss WHERE ss.idSeguro = @idSeguro

	SET NOCOUNT ON;

	UPDATE dbo.SEG_Seguro
	SET
	    --idSeguro - this column value is auto-generated
	    dbo.SEG_Seguro.nombre = @nombre, -- varchar
	    dbo.SEG_Seguro.descripcion = @nombre, -- varchar
	    dbo.SEG_Seguro.codigo = @codigo, -- varchar
	    dbo.SEG_Seguro.conyuge = @conyuge, -- bit
	    dbo.SEG_Seguro.beneficiario = @beneficiario, -- bit
	    dbo.SEG_Seguro.edadMinimaMujer = @edadMinimaMujer, -- int
	    dbo.SEG_Seguro.edadMaximaMujer = @edadMaximaMujer, -- int
	    dbo.SEG_Seguro.edadMinimaHombre = @edadMinimaHombre, -- int
	    dbo.SEG_Seguro.edadMaximaHombre = @edadMaximaHombre, -- int
	    dbo.SEG_Seguro.activo = @activo, -- bit
	    dbo.SEG_Seguro.edadMinimaConyugue = @edadMinimaConyugue, -- int
	    dbo.SEG_Seguro.edadMaximaConyugue = @edadMaximaConyugue, -- int
	    dbo.SEG_Seguro.idCanalVenta = @idCanalVenta, -- int
	    dbo.SEG_Seguro.MaximoBeneficiarios = @MaximoBeneficiarios, -- int
	    dbo.SEG_Seguro.numeroMaximoSegurosPorCliente = @numeroMaximoSegurosPorCliente, -- int
	    dbo.SEG_Seguro.numeroMaximoVentaSegurosPorCuentaCliente = @numeroMaximoVentaSegurosPorCuentaCliente -- int

	WHERE dbo.SEG_Seguro.idSeguro = @idSeguro

	

	SELECT * INTO #ins_SEG_Seguro FROM dbo.SEG_Seguro ss WHERE ss.idSeguro = @idSeguro
	EXEC PR_SEG_Auditoria @ik_TableName,'U', #ins_SEG_Seguro, #del_SEG_Seguro,  @vP_UserName
	DROP TABLE #del_SEG_Seguro
	DROP TABLE #ins_SEG_Seguro
END