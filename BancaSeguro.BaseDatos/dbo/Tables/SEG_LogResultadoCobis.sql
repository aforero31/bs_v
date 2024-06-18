CREATE TABLE [dbo].[SEG_LogResultadoCobis] (
    [id]                 INT             IDENTITY (1, 1) NOT NULL,
    [fechaProceso]       VARCHAR (50)    NULL,
    [codigoProducto]     VARCHAR (50)    NULL,
    [numeroCuenta]       VARCHAR (50)    NULL,
    [valorRecaudo]       DECIMAL (18, 2) NULL,
    [codigoConvenio]     INT             NULL,
    [referencia]         VARCHAR (50)    NULL,
    [error]              VARCHAR (50)    NULL,
    [nombreArchivoCOBIS] VARCHAR (50)    NULL,
    [fechaArchivo]       DATETIME        NULL,
    CONSTRAINT [PK_SEG_LogResultadoCobis] PRIMARY KEY CLUSTERED ([id] ASC)
);

