CREATE TABLE [dbo].[SEG_ArchivoResultadoCobis] (
    [id]             INT             IDENTITY (1, 1) NOT NULL,
    [fechaProceso]   VARCHAR (50)    NULL,
    [codigoProducto] VARCHAR (50)    NULL,
    [numeroCuenta]   VARCHAR (50)    NULL,
    [valorRecaudo]   DECIMAL (18, 2) NULL,
    [codigoConvenio] INT             NULL,
    [referencia]     VARCHAR (50)    NULL,
    [error]          VARCHAR (50)    NULL,
    [activo]         BIT             NULL,
    CONSTRAINT [PK_SEG_ArchivoResultadoCobis] PRIMARY KEY CLUSTERED ([id] ASC)
);



