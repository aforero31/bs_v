/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 03/05/2016
PROPOSITO: Procedimiento para ingresar un nuevo plan
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ActualizarPlanesPorId]

@tablaPlan TipoPlan READONLY,
@vP_UserName VARCHAR(128) = ''
 
AS

BEGIN
	DECLARE @ik_TableName VARCHAR(128) = 'SEG_Plan'
	SELECT * INTO #del_SEG_Plan FROM SEG_Plan ss WHERE ss.idPlan IN (SELECT idPlan FROM @tablaPlan)
	SELECT TOP 1 * INTO #ins_SEG_Plan FROM SEG_Plan ss
	DELETE FROM #ins_SEG_Plan
	SET IDENTITY_INSERT #ins_SEG_Plan ON 
	INSERT INTO #ins_SEG_Plan
	(
	    idPlan,
	    idSeguro,
	    idPeriodicidad,
	    codigo,
	    codigoConvenio,
	    nombre,
	    descripcion,
	    valor,
	    valorIva,
	    valorSinIva,
	    activo
	)
	SELECT 
	S.idPlan
	,S.IdSeguro
	,S.IdPeriodicidad
	,S.CodigoPlan
	,S.CodigoConvenio
	,S.NombrePlan
	,S.Descripcion
	,S.Valor
	,S.ValorIVA
	,S.ValorSinIVA
	,S.Activo

	FROM @tablaPlan S

	EXEC PR_SEG_Auditoria @ik_TableName,'U', #ins_SEG_Plan, #del_SEG_Plan,  @vP_UserName 
	DROP TABLE #del_SEG_Plan
	DROP TABLE #ins_SEG_Plan

	--SELECT * INTO #del1_SEG_Plan FROM @tablaPlan WHERE idPlan = 0
	--select * into #ins1_SEG_Plan from @tablaPlan WHERE idPlan = null  -- para auditoria
	--EXEC PR_SEG_Auditoria @ik_TableName,'I', #ins1_SEG_Plan, #del1_SEG_Plan,  @vP_UserName
	--drop table #ins1_SEG_Plan --para auditoria
	--drop table #del1_SEG_Plan; --para auditoria


	MERGE SEG_Plan AS T
	USING @tablaPlan AS S
	ON (T.idPlan = S.idPlan) 
	WHEN NOT MATCHED BY TARGET 
		THEN INSERT (	idSeguro
						,idPeriodicidad
						,valor
						,nombre
						,descripcion
						,valorIva
						,valorSinIva
						,codigo
						,codigoConvenio
						,activo)
				VALUES	(S.IdSeguro
						,S.IdPeriodicidad
						,S.Valor
						,S.NombrePlan
						,S.Descripcion
						,S.ValorIVA
						,S.ValorSinIVA
						,S.CodigoPlan
						,S.CodigoConvenio
						,S.Activo)
	WHEN MATCHED
		THEN UPDATE SET T.idPeriodicidad = S.IdPeriodicidad
						,T.valor = S.Valor
						,T.nombre = S.NombrePlan
						,T.descripcion = S.Descripcion
						,T.valorIva = S.ValorIVA
						,T.valorSinIva = S.ValorSinIVA
						,T.codigo = S.CodigoPlan
						,T.codigoConvenio = S.CodigoConvenio
						,T.activo = S.Activo
	--WHEN NOT MATCHED BY SOURCE
	--	THEN DELETE 

	OUTPUT $action AS accion , inserted.*, deleted.*;

END