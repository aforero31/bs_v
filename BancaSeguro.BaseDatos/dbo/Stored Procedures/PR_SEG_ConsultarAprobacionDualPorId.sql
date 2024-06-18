/****************************************************************************************************************
NOMBRE DEL PROGRAMA: [PR_SEG_ConsultarAprobacionDualPorId]
DESCRIPCION: Consulta el registro de aprobacion dual por id
PARAMETROS DE ENTRADA:
	@idAprobacionDual				id aprobacion dual 
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
DESCRIPCIÓN: Consulta el registro de aprobacion dual por id 
AUTOR: Paulo Andrés Mora.
EMPRESA: UT - BAC
FECHA DE CREACIÓN: 2016-06-14
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarAprobacionDualPorId] 
	-- Add the parameters for the stored procedure here
	@idAprobacionDual int
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
		 A.idMenu =  M.idMenu
    WHERE
    idAprobacionDual= @idAprobacionDual 
END