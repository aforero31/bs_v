/***************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485 - Parametrizar Mensajes
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Procedimiento para consultar SEG_Mensaje
FECHA DE MODIFICACIÓN: 01/06/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarMensajePorId] 
(
	@idEvento int = null,
	@Llave varchar(50) = null
)
AS
BEGIN
	
	SELECT 
	   [idMensaje]
      ,[Llave]
	  ,se.idEvento
	  ,se.Eventos
      ,[idTipoMensaje]
      ,[Mensaje]
  FROM SEG_Mensaje WITH(NOLOCK) 
  INNER JOIN dbo.SEG_Evento se WITH(NOLOCK) ON se.idEvento = dbo.SEG_Mensaje.idEvento
  WHERE 
    (@idEvento IS NULL OR se.idEvento = @idEvento)
	AND (@Llave IS NULL OR Llave = @Llave)

END