/****************************************************************************************************************
NOMBRE DEL PROGRAMA: [PR_SEG_ConsultarAdmonControlDual]
DESCRIPCION: Consulta la administracion de ControlDual
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
-----------------------------------------------------------------------------------------------------------------
REQUERIMIENTO: SD1588485-HU0024 - Administracion Control Dual
DESCRIPCIÓN: Consulta los registros de administracion de control dual 
AUTOR: Paulo Andrés Mora.
EMPRESA: UT - BAC
FECHA DE CREACIÓN: 2016-06-16
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarAdmonControlDual] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT	 t3.idRol
			,t3.nombre
			,t2.id_Menu
			,t2.idControlDual
			,t2.Requiere
			,t2.Autoriza
	FROM SEG_AdministracionControlDual t2
	INNER JOIN SEG_Rol t3 on t2.id_Rol = t3.idRol
END