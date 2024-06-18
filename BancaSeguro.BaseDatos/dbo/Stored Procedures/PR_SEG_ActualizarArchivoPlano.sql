
CREATE PROCEDURE [dbo].[PR_SEG_ActualizarArchivoPlano] 
	-- Add the parameters for the stored procedure here
	@idProgramacion int,
	@nombreArchivo varchar(50),
	@descripcionArchivo varchar(200),
	@tipoProgramacionArchivo int,
	@ultimaEjecucion datetime = null,
	@proximaEjecucion datetime = null,
	@rutaDestinoFTP varchar(200),
	@separador char(1),
	@idAseguradora int,
	@codigoFiltro int,
	@criterioFiltro varchar(50),
	@camposConsulta varchar (5000),
	@estado bit,
	@vP_UserName varchar(128) --auditoria
AS
/**************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485-BancaSeguros HU023-Parametrizacion Archivo Plano
AUTOR: Andrés Combariza.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Actualizar informacion para generar el Archivo Plano 
FECHA DE CREACIÓN: 2016-07-19
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Aumentar el tamaño de la columna donde se almacena de la ruta del archivo plano.
REQUERIMIENTO: SD1588485 - QC8881
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 12/09/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES:  XXXXXXXXXXXXXXXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXXXXX
***************************************************************************************************************/
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	declare @ik_TableName varchar(128) = 'SEG_ProgramacionArchivo'
	select * into #ins_SEG_ProgramacionArchivo from SEG_ProgramacionArchivo WHERE idProgramacion = @idProgramacion  -- para auditoria

	UPDATE [dbo].[SEG_ProgramacionArchivo] 
	SET [nombre] = @nombreArchivo
	   ,[descripcion] = @descripcionArchivo
	   ,[tipoProgramacion] = @tipoProgramacionArchivo
	   ,[rutaDestinoFTP] = @rutaDestinoFTP
	   ,[separador] = @separador
	   ,[idAseguradora] = @idAseguradora
	   ,[codigoFiltro] = @codigoFiltro
	   ,[criterioFiltro] = @criterioFiltro
	   ,[camposConsulta] = @camposConsulta
	   ,[estado] = @estado
	WHERE [idProgramacion] = @idProgramacion

	select * into #del_SEG_ProgramacionArchivo from SEG_ProgramacionArchivo WHERE idProgramacion = @idProgramacion  -- para auditoria
	exec PR_SEG_Auditoria @ik_TableName,'U',#del_SEG_ProgramacionArchivo, #ins_SEG_ProgramacionArchivo, @vP_UserName --para auditoria
	drop table #ins_SEG_ProgramacionArchivo --para auditoria
	drop table #del_SEG_ProgramacionArchivo; --para auditoria

END