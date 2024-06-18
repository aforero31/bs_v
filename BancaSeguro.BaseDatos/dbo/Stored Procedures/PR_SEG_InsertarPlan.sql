/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 03/05/2016
PROPOSITO: Procedimiento para ingresar un nuevo plan
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarPlan]
(@idSeguro INT,
 @idPeriodicidad INT,
 @valor DECIMAL(18,2),
 @nombre VARCHAR(50),
 @descripcion VARCHAR(200),
 @valorIva DECIMAL(18,2),
 @valorSinIva DECIMAL(18,2),
 @codigoPlan INT,
 @codigoConvenio INT,
 @activo BIT,
 @vP_UserName VARCHAR(128))

AS

BEGIN
	INSERT INTO [dbo].[SEG_Plan]  ([idSeguro]
								  ,[idPeriodicidad]
								  ,[valor]
								  ,[nombre]
								  ,[descripcion]
								  ,[valorIva]
								  ,[valorSinIva]
								  ,[codigo]
								  ,dbo.SEG_Plan.codigoConvenio
								  ,dbo.SEG_Plan.activo)
	VALUES	(@idSeguro
			,@idPeriodicidad
			,@valor
			,@nombre
			,@descripcion
			,@valorIva
			,@valorSinIva
			,@codigoPlan
			,@codigoConvenio
			,@activo)	

	declare @ik_TableName varchar(128) = 'SEG_Plan'
	declare @Plan int = scope_identity()
	select * into #del_SEG_Plan from SEG_Plan  WHERE idPlan = @Plan
	select * into #ins_SEG_Plan from SEG_Plan  WHERE @Plan = null
	exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_Plan, #ins_SEG_Plan, @vP_UserName
	drop table #ins_SEG_Plan
	drop table #del_SEG_Plan 
END