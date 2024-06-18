/****************************************************************************************************************
CREACIÓN
REQUERIMIENTO:SD1588485-Banca Seguros HU015-ParametrizarAseguradora 
AUTOR: Paulo Andrés Mora.
EMPRESA: Unión temporal FS-BAC-2013
OBJETIVO: Actualiza Aseguradora 
FECHA DE CREACIÓN: 2016-04-14
---------------------------------------------------------------------------------------------------------------
MODIFICACION
REQUERIMIENTO: SD1588485- Banca Seguros Log de Transacciones 
AUTOR: Andrés Combariza.
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE CREACIÓN: 2016-05-13
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ActualizarAseguradora] 
	-- Add the parameters for the stored procedure here
	@idAseguradora int,
	@nombre varchar(50),
    @codigo varchar(50),
    @idTipoIdentificacion int,
    @identificacion varchar(50),
    @contacto varchar(50),
    @telefono varchar(50),
    @correo varchar(100),
    @consecutivoInicial int,
    @consecutivoActual int,
    @activo bit,
    @actualizaConsecutivo bit,
    @existe bit OUTPUT,
	@vP_UserName varchar(128) --
AS
BEGIN
    SET @existe = 0;
    IF EXISTS(SELECT * FROM SEG_Aseguradora WHERE codigoSuperintendencia =  @codigo AND idAseguradora <> @idAseguradora)
      SET @existe = 1;
    ELSE
    BEGIN
	declare @ik_TableName varchar(128) = 'SEG_Aseguradora'
	select * into #ins_SEG_Aseguradora from SEG_Aseguradora WHERE idAseguradora = @idAseguradora  -- para auditoria
	IF @actualizaConsecutivo = 0 
	BEGIN
		UPDATE SEG_Aseguradora
		SET nombre = @nombre
			   ,codigoSuperintendencia = @codigo
			   ,idTipoIdentificacion = @idTipoIdentificacion
			   ,identificacion = @identificacion
			   ,contacto = @contacto
			   ,telefono = @telefono
			   ,correo = @correo
			   ,activo = @activo
		 WHERE idAseguradora = @idAseguradora

		select * into #del_SEG_Aseguradora1 from SEG_Aseguradora WHERE idAseguradora = @idAseguradora  -- para auditoria
		exec PR_SEG_Auditoria @ik_TableName,'U',#del_SEG_Aseguradora1, #ins_SEG_Aseguradora, @vP_UserName --para auditoria
		drop table #ins_SEG_Aseguradora --para auditoria
		drop table #del_SEG_Aseguradora1; --para auditoria
	END
    ELSE
	 BEGIN
		UPDATE SEG_Aseguradora
		SET nombre = @nombre
			   ,codigoSuperintendencia = @codigo
			   ,idTipoIdentificacion = @idTipoIdentificacion
			   ,identificacion = @identificacion
			   ,contacto = @contacto
			   ,telefono = @telefono
			   ,correo = @correo
			   ,consecutivoInicial = @consecutivoInicial
			   ,consecutivoActual = @consecutivoActual
			   ,activo = @activo
		 WHERE idAseguradora = @idAseguradora;

		select * into #del_SEG_Aseguradora from SEG_Aseguradora WHERE idAseguradora = @idAseguradora  -- para auditoria
		exec PR_SEG_Auditoria @ik_TableName,'U',#del_SEG_Aseguradora, #ins_SEG_Aseguradora, @vP_UserName --para auditoria
		drop table #ins_SEG_Aseguradora --para auditoria
		drop table #del_SEG_Aseguradora; --para auditoria
    END 
	END
     
END