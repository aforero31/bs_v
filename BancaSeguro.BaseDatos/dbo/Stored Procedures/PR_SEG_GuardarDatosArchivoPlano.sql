
CREATE PROCEDURE [dbo].[PR_SEG_GuardarDatosArchivoPlano]
	@nombreArchivo varchar(50),
	@descripcionArchivo varchar(200),
	@tipoProgramacionArchivo int,
	@fechaInicioArchivo date,
	@fechaFinArchivo date,
	@programacion varchar(max),
	@ultimaEjecucion datetime = null,
	@proximaEjecucion datetime = null,
	@rutaDestinoFTP varchar(200),
	@separador char(1),
	@idAseguradora int,
	@codigoFiltro int,
	@criterioFiltro varchar(50),
	@camposConsulta varchar (5000),
	@estado bit,
	@vP_UserName varchar(128) --para auditoria
AS
/**************************************************************************************************************
CREACION
REQUERIMIENTO:	SD1588485
AUTOR: Andrés Combariza Ibarra
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Este procedimiento guarda los datos de la parametrizacion para la generación de archivos planos
FECHA DE CREACION: 15/07/2016
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
	declare @ik_TableName varchar(128) = 'SEG_ProgramacionArchivo'
	INSERT INTO [dbo].[SEG_ProgramacionArchivo]
	( 
		[nombre]
	   ,[descripcion]	
	   ,[tipoProgramacion]
	   ,[fechaInicio]
	   ,[fechaFin]
	   ,[programacion]
	   ,[ultimaEjecucion]
	   ,[proximaEjecucion]
	   ,[rutaDestinoFTP]
	   ,[separador]
	   ,[idAseguradora]
	   ,[codigoFiltro]
	   ,[criterioFiltro]
	   ,[camposConsulta]
	   ,[estado]
	)
	VALUES
	(
		@nombreArchivo
	   ,@descripcionArchivo
	   ,@tipoProgramacionArchivo
	   ,@fechaInicioArchivo
	   ,@fechaFinArchivo
	   ,@programacion
	   ,@ultimaEjecucion
	   ,@proximaEjecucion
	   ,@rutaDestinoFTP
	   ,@separador
	   ,@idAseguradora
	   ,@codigoFiltro
	   ,@criterioFiltro
	   ,@camposConsulta
	   ,@estado
	)

	declare @idProgramacion int = (SELECT IDENT_CURRENT ('SEG_ProgramacionArchivo'));
	
	select * into #del_SEG_ProgramacionArchivo from SEG_ProgramacionArchivo WHERE idProgramacion = @idProgramacion  -- para auditoria
	select * into #ins_SEG_ProgramacionArchivo from SEG_ProgramacionArchivo WHERE idProgramacion = null  -- para auditoria
	exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_ProgramacionArchivo, #ins_SEG_ProgramacionArchivo, @vP_UserName --para auditoria
	drop table #ins_SEG_ProgramacionArchivo --para auditoria
	drop table #del_SEG_ProgramacionArchivo; --para auditoria
END