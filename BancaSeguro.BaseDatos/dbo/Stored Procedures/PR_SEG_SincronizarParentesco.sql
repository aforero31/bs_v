/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 24/08/2016
PROPOSITO: Procedimiento para sincronizar los parentescos
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_SincronizarParentesco]
@datos TipoParentesco READONLY 
AS
BEGIN

	MERGE SEG_Parentesco AS T
	USING @datos AS S
	ON (T.Alias = S.Alias) 
	WHEN NOT MATCHED BY TARGET 
		THEN INSERT		(nombre
						,activo
						,Alias)
				VALUES	(S.Nombre
						,S.Activo
						,S.Alias)
	WHEN MATCHED
		THEN UPDATE SET T.nombre = S.Nombre
						,T.activo = S.Activo
						,T.Alias = S.Alias
	WHEN NOT MATCHED BY SOURCE
		THEN UPDATE SET T.activo = 0
	--WHEN NOT MATCHED BY SOURCE
	--	THEN DELETE 

	OUTPUT $action AS accion , inserted.*;--, deleted.*;
END