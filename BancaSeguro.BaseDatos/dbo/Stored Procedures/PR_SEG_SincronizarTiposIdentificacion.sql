/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/wzaldua
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 24/08/2016
PROPOSITO: Procedimiento para sincronizar los Tipos de identificacion
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_SincronizarTiposIdentificacion]

@datos TipoIdentificacion READONLY
 
AS

BEGIN

	MERGE SEG_TipoIdentificacion AS T
	USING @datos AS S
	ON (T.abreviatura = S.Abreviatura) 
	WHEN NOT MATCHED BY TARGET 
		THEN INSERT		(abreviatura
						,nombre
						,tipoPersona
						,activo
						,CodigoCardif)
				VALUES	(S.Abreviatura
						,S.Nombre
						,S.TipoPersona
						,S.Activo
						,S.CodigoCardif)
	WHEN MATCHED
		THEN UPDATE SET T.abreviatura = S.Abreviatura
						,T.nombre = S.Nombre
						,T.tipoPersona = S.TipoPersona
						,T.activo = S.Activo
						,T.CodigoCardif = S.CodigoCardif
	WHEN NOT MATCHED BY SOURCE
			THEN UPDATE SET T.activo = 0
	--WHEN NOT MATCHED BY SOURCE
		--THEN DELETE 

	OUTPUT $action AS accion , inserted.*;--, deleted.*;
END