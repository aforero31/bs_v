/****************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485-HU0024 - Administracion Control Dual
DESCRIPCIÓN: Consulta los registros de administracion de control dual por IdMenu 
AUTOR: Andrés Combariza
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE CREACIÓN: 2016-06-15
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarAdmonControlDualIdMenu] 
	@idMenu int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	
		SELECT	 t1.idRol
				,t3.nombre
				,t2.id_Menu
				,t2.idControlDual
				,t2.Requiere
				,t2.Autoriza
		FROM [SEG_Permisos] t1
		LEFT JOIN  SEG_AdministracionControlDual t2 on t1.idRol = t2.id_Rol and  t2.id_Menu = @idMenu
		INNER JOIN SEG_Rol t3 on t1.idRol = t3.idRol
		WHERE t1.idMenu = @idMenu	
		AND t1.activo = 1 
		AND t3.activo = 1
	
END