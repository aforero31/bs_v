
CREATE PROCEDURE [dbo].[PR_INSERT_VentaAtm] 
	-- Add the parameters for the stored procedure here
	@Numero_Certificado char(30),
	@Codigo_Producto_Bancario char(4) ,
	@Numero_Transaccion char(6) ,
	@Hora_Transaccion char(6) ,
	@Tipo_Documento_Asegurado char(1) ,
	@Numero_Documento_Asegurado char(20) ,
	@Nombre_Asegurado char(120) ,
	@Fecha_Nacimiento char(8) ,
	@Ciudad_Retiro char(5) ,
	@Direccion_Cajero char(50) ,
	@Telefono_1 char(15) ,
	@Prima_Bruta char(12) ,
	@Inicio_Vigencia char(8) ,
	@Correo_Electronico char(120) ,
	@Pais_Nacimiento_Asegurado char(120) ,
	@Pais_Nacionalidad_Asegurado char(120) ,
	@Pais_Residencia_Asegurado char(120) ,
	@Cod_Producto_Cardift char(4) ,
	@Monto_Retiro char(7) ,
	@Numero_Cuenta char(11) ,
	@Genero char(1) ,
	@Hora_Fin_Vigencia char(6) 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[SEG_Venta_ATM]
           ([Codigo_Producto_Bancario]
           ,[Numero_Transaccion]
           ,[Hora_Transaccion]
           ,[Tipo_Documento_Asegurado]
           ,[Numero_Documento_Asegurado]
           ,[Nombre_Asegurado]
           ,[Fecha_Nacimiento]
           ,[Ciudad_Retiro]
           ,[Direccion_Cajero]
           ,[Telefono_1]
           ,[Prima_Bruta]
           ,[Inicio_Vigencia]
           ,[Correo_Electronico]
           ,[Pais_Nacimiento_Asegurado]
           ,[Pais_Nacionalidad_Asegurado]
           ,[Pais_Residencia_Asegurado]
           ,[Cod_Producto_Cardift]
           ,[Monto_Retiro]
           ,[Numero_Cuenta]
           ,[Genero]
           ,[Hora_Fin_Vigencia]
           ,[Numero_Certificado]
		   ,[Fecha])
     VALUES
           (@Codigo_Producto_Bancario
           ,@Numero_Transaccion
           ,@Hora_Transaccion
           ,@Tipo_Documento_Asegurado
           ,@Numero_Documento_Asegurado
           ,@Nombre_Asegurado
           ,@Fecha_Nacimiento
           ,@Ciudad_Retiro
           ,@Direccion_Cajero
           ,@Telefono_1
           ,@Prima_Bruta
           ,@Inicio_Vigencia
           ,@Correo_Electronico
           ,@Pais_Nacimiento_Asegurado
           ,@Pais_Nacionalidad_Asegurado
           ,@Pais_Residencia_Asegurado
           ,@Cod_Producto_Cardift
           ,@Monto_Retiro
           ,@Numero_Cuenta
           ,@Genero
           ,@Hora_Fin_Vigencia
           ,@Numero_Certificado
		   ,GETDATE())
		   SELECT @Numero_Certificado AS id

END