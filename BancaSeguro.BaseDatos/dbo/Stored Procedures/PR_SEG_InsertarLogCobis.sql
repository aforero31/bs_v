/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-Banca Seguros 
AUTOR: Andrés Combariza
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Inserta Datos en la tabla de LogCobis 
FECHA DE CREACIÓN: 2016-05-05
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarLogCobis] 
	-- Add the parameters for the stored procedure here
	@xmlRequest nvarchar(max),
    @horaRequest varchar(20),				
    @xmlResponse nvarchar(max),
    @horaResponse varchar(20),				
    @vP_UserName varchar(50),
    @tipoTrans varchar(50)
    --@fecha datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[SEG_LogCobis]
	([XML_Request]
	,[Hora_Request]
	,[XML_Response]
	,[Hora_Response]
	,[Usuario]
	,[Tipo_Transaccion]
	,[Fecha])
	VALUES
	(@xmlRequest
	,@horaRequest
	,@xmlResponse
	,@horaResponse
	,@vP_UserName
	,@tipoTrans
	,getdate()
	)
END