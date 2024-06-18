
/****************************************************************************************************************
NOMBRE DEL PROGRAMA: [PR_SEG_ActualizarAprobacionDual]
DESCRIPCION: Inserta un registro de aprobacion dual
PARAMETROS DE ENTRADA:
	@idAprobacionDual		id de aprobacion dual
    @estado					estado 
    @usuarioAprueba			usuario aprueba
    @fechaAprobacion		fecha aprobacion
    @descripcion			descripcion
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
DESCRIPCIÓN: Actualiza un registro de aprobacion de control dual 
AUTOR: Paulo Andrés Mora.
EMPRESA: UT - BAC
FECHA DE CREACIÓN: 2016-06-14
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ActualizarAprobacionDual] 
	-- Add the parameters for the stored procedure here
	@idAprobacionDual int,
    @estado char(1),
    @usuarioAprueba varchar(50),
    @fechaAprobacion datetime,
    @descripcion varchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE SEG_AprobacionDual
   SET [estado] = @estado
      ,[usuarioAprueba] = @usuarioAprueba
      ,[fechaAprobacion] = @fechaAprobacion
      ,[descripcion] = @descripcion
 WHERE idAprobacionDual = @idAprobacionDual
END