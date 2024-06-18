/* *************************************************************************************************************
NOMBRE DEL PROGRAMA: [PR_SEG_ConsultarMenuAprobacionDual]
DESCRIPCION: Consulta los menus con control dual
PARAMETROS DE ENTRADA:
	@idRol     id del Rol
PARAMETROS DE SALIDA:
	No Aplica
RESULTADO:
	No aplica
CODIGOS DE ERROR:
	Se levantan las excepciones propias.
CODIGOS DE SATISFACCION:
	No aplica
----------------------------------------------------------------------------------------------------------------
REQUERIMIENTO: SD1588485 - HU0025 - Aprobacion Control Dual por Rol
DESCRIPCIÓN: Consulta los menus con control dual por Rol
AUTOR: Paulo Andrés Mora.
EMPRESA: UT - BAC
FECHA DE CREACIÓN: 2016-06-16
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarMenuAprobacionDualPorRol]
@idRol int
AS
BEGIN
    SELECT DISTINCT	
			M.idMenu,
			M.Nombre,
			M.Posicion,
			M.idPadre,
			M.Activo,
			M.URL
	FROM	SEG_Menu M INNER JOIN
			SEG_AdministracionControlDual ACD 
			ON ACD.id_Menu = M.idMenu AND ACD.Autoriza = 1 INNER JOIN
			SEG_Permisos P 
			ON ACD.id_Menu = P.idMenu AND ACD.id_Rol = P.idRol AND P.activo = 1
	WHERE	M.Activo = 1
	        and ACD.id_Rol =  @idRol
	ORDER BY	M.IdPadre,M.Posicion
END