/****************************************************************************************************************
NOMBRE DEL PROGRAMA: [PR_SEG_InsertarAprobacionDual]
DESCRIPCION: Inserta un registro de aprobacion dual
PARAMETROS DE ENTRADA:
	@idMenu				id de Menu 
    @estado				estado del registro
    @accion				accion realizada
    @usuarioEnvia		usuario envio
    @fechaSolicitud		fecha solicitud
    @nombreObjeto		nombre objeto modificado
    @datosObjeto		datos del objeto
PARAMETROS DE SALIDA:
	No Aplica
RESULTADO:
	No aplica
CODIGOS DE ERROR:
	Se levantan las excepciones propias.
CODIGOS DE SATISFACCION:
	No aplica
---------------------------------------------------------------------------------------------------------------
REQUERIMIENTO: SD1588485 - HU0025 - Aprobacion Control Dual
DESCRIPCIÓN: Inserta un registro de aprobacion de control dual 
AUTOR: Paulo Andrés Mora.
EMPRESA: UT - BAC
FECHA DE CREACIÓN: 2016-06-13
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_InsertarAprobacionDual] 
	-- Add the parameters for the stored procedure here
	@idMenu int,
    @estado char(1),
    @accion varchar(15),
    @usuarioEnvia varchar(50),
    @fechaSolicitud datetime,
    @nombreObjeto varchar(50),
    @datosObjeto varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [BANCASEGUROS].[dbo].[SEG_AprobacionDual]
           ([idMenu]
           ,[estado]
           ,[accion]
           ,[usuarioEnvia]
           ,[fechaSolicitud]
           ,[nombreObjeto]
           ,[datosObjeto])
     VALUES
           (@idMenu
           ,@estado
           ,@accion
           ,@usuarioEnvia
           ,@fechaSolicitud
           ,@nombreObjeto
           ,@datosObjeto)
END