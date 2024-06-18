/* *************************************************************************************************************
CREACIÓN
REQUERIMIENTO: 
AUTOR: Wilver Zaldúa Espíndola
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Este procedimiento consulta roles existentes por filtro
FECHA DE CREACIÓN: 08/01/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se elimina campo es Autorizador
REQUERIMIENTO: SD1588485-HU020-AdministrarRol
AUTOR:         Paulo Mora
EMPRESA:	   UT - BAC
FECHA DE MODIFICACIÓN: 2016-04-26 
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarRoles]
(
@Nombre varchar(50)=null,  
@Estado bit=0
)
AS
BEGIN
  SELECT IdRol,
         Nombre,
		 Activo 
  FROM SEG_Rol 
  where (Nombre like '' + @Nombre + '%' OR @Nombre IS NULL)  and Activo = isnull(@Estado,Activo)
end

