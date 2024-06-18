/***************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485
AUTOR: INTERGRUPO/cpiza
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 03/05/2016
PROPOSITO: Procedimiento para ingresar un nuevo plan
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ActualizarSeguroTipoIdentiPorId]
@tablaSeguroTipoI TipoSeguroTipoIdentificacion READONLY ,
@vP_UserName VARCHAR(128) = ''
AS
BEGIN

	WITH SeguroTipoIdentificacio AS
	(
	SELECT sti.idSeguro, sti.idTipoIdentificacion
	FROM SEG_SeguroTipoIdentificacion sti
	WHERE sti.idSeguro = (SELECT TOP(1) IdSeguro FROM @tablaSeguroTipoI)
	)
	MERGE SeguroTipoIdentificacio AS T
	USING @tablaSeguroTipoI AS S
	ON (T.idSeguro = S.IdSeguro AND T.idTipoIdentificacion = S.IdTipoIdentificacion) 
	WHEN NOT MATCHED BY TARGET 
		THEN INSERT (idSeguro
					,idTipoIdentificacion)
			VALUES  (S.IdSeguro
					,S.IdTipoIdentificacion)
	WHEN NOT MATCHED BY SOURCE 
		THEN DELETE

	OUTPUT $action AS accion , inserted.*, deleted.*;

END