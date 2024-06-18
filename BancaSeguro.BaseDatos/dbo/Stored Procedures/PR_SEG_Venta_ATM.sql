

CREATE PROCEDURE [dbo].[PR_SEG_Venta_ATM]
AS
/*************************************************************************************************************************************
CREACIÓN
REQUERIMIENTO:		SD4992318
AUTOR:				Paulo Mora
EMPRESA:			SoftwareOne
OBJETIVO:			Consulta la informacion de las Ventas Atm Seguros del día
FECHA DE CREACIÓN:	06/07/2023
-------------------------------------------------------------------------------------------------------------------------------------
*************************************************************************************************************************************/
BEGIN
	DECLARE @FechaUltimaEjecucion DATETIME 
	SET @FechaUltimaEjecucion = (SELECT FechaEjecucionETL FROM [dbo].[SEG_FechaEjecucionETL] where Prefijo = 'EMI' )

	SELECT  
      RTRIM(LTRIM([Codigo_Producto_Bancario]))
      +';'+RTRIM(LTRIM([Numero_Transaccion]))
      +';'+RTRIM(LTRIM([Hora_Transaccion]))
      +';'+RTRIM(LTRIM([Tipo_Documento_Asegurado]))
      +';'+RTRIM(LTRIM([Numero_Documento_Asegurado]))
      +';'+RTRIM(LTRIM([Nombre_Asegurado]))
      +';'+RTRIM(LTRIM([Fecha_Nacimiento]))
      +';'+RTRIM(LTRIM([Ciudad_Retiro]))
      +';'+RTRIM(LTRIM([Direccion_Cajero]))
      +';'+RTRIM(LTRIM([Telefono_1]))
      +';'+RTRIM(LTRIM([Prima_Bruta]))
      +';'+RTRIM(LTRIM([Inicio_Vigencia]))
      +';'+RTRIM(LTRIM([Correo_Electronico]))
      +';'+RTRIM(LTRIM([Pais_Nacimiento_Asegurado]))
      +';'+RTRIM(LTRIM([Pais_Nacionalidad_Asegurado]))
      +';'+RTRIM(LTRIM([Pais_Residencia_Asegurado]))
      +';'+RTRIM(LTRIM([Cod_Producto_Cardift]))
      +';'+RTRIM(LTRIM([Monto_Retiro]))
      +';'+RTRIM(LTRIM([Numero_Cuenta]))
      +';'+RTRIM(LTRIM([Genero]))
      +';'+RTRIM(LTRIM([Hora_Fin_Vigencia]))
	  +';'+RTRIM(LTRIM([Numero_Certificado]))
	  AS Salia
  FROM [dbo].[SEG_Venta_ATM]
  WHERE Fecha BETWEEN @FechaUltimaEjecucion AND GETDATE()
  
END