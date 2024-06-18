CREATE TABLE [dbo].[SEG_Venta_ATM] (
    [Numero_Certificado]          CHAR (30)  NOT NULL,
    [Codigo_Producto_Bancario]    CHAR (4)   NULL,
    [Numero_Transaccion]          CHAR (6)   NULL,
    [Hora_Transaccion]            CHAR (6)   NULL,
    [Tipo_Documento_Asegurado]    CHAR (1)   NULL,
    [Numero_Documento_Asegurado]  CHAR (20)  NULL,
    [Nombre_Asegurado]            CHAR (120) NULL,
    [Fecha_Nacimiento]            CHAR (8)   NULL,
    [Ciudad_Retiro]               CHAR (5)   NULL,
    [Direccion_Cajero]            CHAR (50)  NULL,
    [Telefono_1]                  CHAR (15)  NULL,
    [Prima_Bruta]                 CHAR (12)  NULL,
    [Inicio_Vigencia]             CHAR (8)   NULL,
    [Correo_Electronico]          CHAR (120) NULL,
    [Pais_Nacimiento_Asegurado]   CHAR (120) NULL,
    [Pais_Nacionalidad_Asegurado] CHAR (120) NULL,
    [Pais_Residencia_Asegurado]   CHAR (120) NULL,
    [Cod_Producto_Cardift]        CHAR (4)   NULL,
    [Monto_Retiro]                CHAR (7)   NULL,
    [Numero_Cuenta]               CHAR (12)  NULL,
    [Genero]                      CHAR (1)   NULL,
    [Hora_Fin_Vigencia]           CHAR (6)   NULL,
    [Fecha]                       DATETIME   DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_SEG_Venta_ATM_1] PRIMARY KEY CLUSTERED ([Numero_Certificado] ASC)
);



