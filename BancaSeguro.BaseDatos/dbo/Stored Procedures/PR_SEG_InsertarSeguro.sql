/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485 - HU018 - Parametrizacion Producto
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Sp para insertar un seguro
FECHA DE MODIFICACIÓN: 19/04/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES:
REQUERIMIENTO: SD1588485 - HU018 - Parametrizacion Producto
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Se agrega un select que devuelve el ID recien ingresado
		   Se agrega el campo numeroMaximoVentaSegurosPorCuentaCliente
FECHA DE MODIFICACIÓN: 03/05/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES:
REQUERIMIENTO: SD1588485 - HU018 - Parametrizacion Producto
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Se agrega idCanalVenta
FECHA DE MODIFICACIÓN: 15/07/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarSeguro]
(@idAseguradora INT
,@nombre VARCHAR(50)
,@descripcion VARCHAR(200)
,@codigo VARCHAR(50)
,@conyuge BIT
,@beneficiario BIT
,@edadMinimaMujer INT
,@edadMaximaMujer INT
,@edadMinimaHombre INT
,@edadMaximaHombre INT
,@activo BIT
,@edadMinimaConyugue INT
,@edadMaximaConyugue INT
,@idCanalVenta INT
,@MaximoBeneficiarios INT
,@numeroMaximoSegurosPorCliente INT
,@numeroMaximoVentaSegurosPorCuentaCliente INT
,@vP_UserName VARCHAR(128))

AS

BEGIN
	INSERT INTO [dbo].[SEG_Seguro]  ([idAseguradora]
									,[nombre]
									,[descripcion]
									,[codigo]
									,[conyuge]
									,[beneficiario]
									,[edadMinimaMujer]
									,[edadMaximaMujer]
									,[edadMinimaHombre]
									,[edadMaximaHombre]
									,[activo]
									,[edadMinimaConyugue]
									,[edadMaximaConyugue]
									,[idCanalVenta]
									,[MaximoBeneficiarios]
									,[numeroMaximoSegurosPorCliente]
									,[numeroMaximoVentaSegurosPorCuentaCliente])
	VALUES  (@idAseguradora
			,@nombre
			,@descripcion
			,@codigo
			,@conyuge
			,@beneficiario
			,@edadMinimaMujer
			,@edadMaximaMujer
			,@edadMinimaHombre
			,@edadMaximaHombre
			,@activo
			,@edadMinimaConyugue
			,@edadMaximaConyugue
			,@idCanalVenta
			,@MaximoBeneficiarios
			,@numeroMaximoSegurosPorCliente
			,@numeroMaximoVentaSegurosPorCuentaCliente)

	SELECT SCOPE_IDENTITY() AS idSeguro

	declare @ik_TableName varchar(128) = 'SEG_Seguro'
	declare @Seguro int = scope_identity()
	select * into #del_SEG_Seguro from SEG_Seguro  WHERE idSeguro = @Seguro
	select * into #ins_SEG_Seguro from SEG_Seguro  WHERE @Seguro = null
	exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_Seguro, #ins_SEG_Seguro, @vP_UserName
	drop table #ins_SEG_Seguro 
	drop table #del_SEG_Seguro 
END