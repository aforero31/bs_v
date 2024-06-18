/****************************************************************************************************************
NOMBRE DEL PROGRAMA: [PR_SEG_ConsultarAprobacionDual]
DESCRIPCION: Consulta los registros de aprobacion dual
PARAMETROS DE ENTRADA:
    @idAprobacionDual   id Aprobacion
	@idMenu				id de Menu 
    @estado				estado del registro
    @fechaInicial		fecha inicial solicitud
    @fechaFinal 		fecha final solicitud
PARAMETROS DE SALIDA:
	No Aplica
RESULTADO:
	No aplica
CODIGOS DE ERROR:
	Se levantan las excepciones propias.
CODIGOS DE SATISFACCION:
	No aplica
---------------------------------------------------------------------------------------------------------------
REQUERIMIENTO: SD1588485-HU0025 - Aprobacion Control Dual
DESCRIPCIÓN: Consulta los registros de aprobacion dual 
AUTOR: Paulo Andrés Mora.
EMPRESA: UT - BAC
FECHA DE CREACIÓN: 2016-06-13
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarAprobacionDual] 
	-- Add the parameters for the stored procedure here
	@idAprobacionDual int,
	@idMenu int,
    @estado char(1) = NULL,
    @fechaInicial datetime,
    @fechaFinal datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  A.idAprobacionDual
           ,A.idMenu
           ,M.nombre
           ,A.estado
           ,A.accion
           ,A.usuarioEnvia
           ,A.usuarioAprueba
           ,A.fechaSolicitud
           ,A.fechaAprobacion
           ,A.nombreObjeto
           ,A.datosObjeto
           ,A.descripcion
    FROM SEG_AprobacionDual A INNER JOIN 
         SEG_Menu M ON
         A.idMenu = M.idMenu AND M.Activo = 1 INNER JOIN
         (SELECT DISTINCT id_Menu  FROM SEG_AdministracionControlDual WHERE Requiere = 1) ACD ON
         ACD.id_Menu = A.idMenu 
    WHERE
    (A.idAprobacionDual = @idAprobacionDual OR @idAprobacionDual IS NULL) AND
    (A.idMenu = @idMenu OR @idMenu IS NULL) AND
    (A.estado = @estado OR @estado IS NULL) AND
    (A.fechaSolicitud >= @fechaInicial OR  @fechaInicial IS NULL) AND
    (A.fechaSolicitud < DATEADD(DAY,1,@fechaFinal) OR  @fechaFinal IS NULL)
END