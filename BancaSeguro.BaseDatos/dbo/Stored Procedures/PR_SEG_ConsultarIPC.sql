
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarIPC] 
AS
/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: BancaSeguros HU019-ParametrizarIPC 
AUTOR: Andrés Combariza.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Actualiza IPC 
FECHA DE CREACIÓN: 2016-05-17
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Retornar el año actual del sistema.
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 13/09/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
****************************************************************************************************************/
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT   ISNULL((SELECT TOP 1 [idIPC] FROM [dbo].[SEG_IncrementoIPC]	ORDER BY idIPC DESC),0) [idIPC]
		,(SELECT TOP 1 [ano] FROM [dbo].[SEG_IncrementoIPC]	ORDER BY idIPC DESC) [ano]
		,(SELECT TOP 1 [ipc]  FROM [dbo].[SEG_IncrementoIPC] ORDER BY idIPC DESC) [ipc]
		,YEAR(GETDATE()) as anoActual

END