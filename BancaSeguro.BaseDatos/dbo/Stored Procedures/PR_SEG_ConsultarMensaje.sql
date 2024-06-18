﻿/****************************************************************************************************************
CREACION
REQUERIMIENTO: SD1588485- Banca Seguros Parametrizar Mensajes
DESCRIPCIÒN:   Procedimiento para consultar SEG_Mensaje
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Procedimiento para consultar SEG_Mensaje
FECHA DE MODIFICACIÓN: 01/06/2016
***************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarMensaje] 
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
  INNER JOIN dbo.SEG_Evento se ON se.idEvento = dbo.SEG_Mensaje.idEvento

END