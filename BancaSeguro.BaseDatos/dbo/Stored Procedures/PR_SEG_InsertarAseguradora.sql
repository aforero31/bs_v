/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO: Banca Seguros HU015-ParametrizarAseguradora 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO : Inserta Aseguradora 
FECHA DE CREACIÓN: 2016-04-14
---------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se modifica para guardar el log en la tabla de auditoria
REQUERIMIENTO: SD1588485
AUTOR: Andrés Combariza
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 19/05/2016
*************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_InsertarAseguradora] 
	-- Add the parameters for the stored procedure here
	@nombre varchar(50),
    @codigo varchar(50),
    @idTipoIdentificacion int,
    @identificacion varchar(50),
    @contacto varchar(50),
    @telefono varchar(50),
    @correo varchar(100),
    @activo bit,
    @consecutivoInicial int,
    @consecutivoActual int,
	@existe bit OUTPUT,
	@vP_UserName varchar(128) --para auditoria
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SET @existe = 0
    -- Insert statements for procedure here
	IF NOT EXISTS(SELECT * FROM SEG_Aseguradora WHERE codigoSuperintendencia =  @codigo)
	BEGIN
	declare @ik_TableName varchar(128) = 'SEG_Aseguradora'
	INSERT INTO [dbo].[SEG_Aseguradora]
           ([nombre]
           ,[codigoSuperintendencia]
           ,[idTipoIdentificacion]
           ,[identificacion]
           ,[contacto]
           ,[telefono]
           ,[correo]
           ,[activo]
           ,[consecutivoInicial]
           ,[consecutivoActual])
     VALUES
           (@nombre,
			@codigo,
			@idTipoIdentificacion,
			@identificacion,
			@contacto,
			@telefono,
			@correo,
			@activo,
			@consecutivoInicial,
			@consecutivoActual)
			
		declare @idAseguradora int = (SELECT IDENT_CURRENT ('SEG_Aseguradora'));
		
		select * into #del_SEG_Aseguradora from SEG_Aseguradora WHERE idAseguradora = @idAseguradora  -- para auditoria
		select * into #ins_SEG_Aseguradora from SEG_Aseguradora WHERE idAseguradora = null  -- para auditoria
		exec PR_SEG_Auditoria @ik_TableName,'I',#del_SEG_Aseguradora, #ins_SEG_Aseguradora, @vP_UserName --para auditoria
		drop table #ins_SEG_Aseguradora --para auditoria
		drop table #del_SEG_Aseguradora; --para auditoria

						
	END
	ELSE
	SET @existe = 1
END