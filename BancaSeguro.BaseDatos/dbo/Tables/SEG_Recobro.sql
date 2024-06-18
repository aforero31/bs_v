CREATE TABLE [dbo].[SEG_Recobro] (
    [idRecobro]          INT             IDENTITY (1, 1) NOT NULL,
    [idEstadoCobro]      INT             NOT NULL,
    [numeroCuenta]       VARCHAR (50)    NOT NULL,
    [codigoProducto]     INT             NOT NULL,
    [valorRecaudo]       DECIMAL (18, 2) NOT NULL,
    [codigoConvenio]     INT             NOT NULL,
    [consecutivoPoliza]  VARCHAR (50)    NOT NULL,
    [fechaUltimoPeriodo] DATE            NOT NULL,
    [contador]           INT             NOT NULL,
    [activo]             BIT             NOT NULL,
    [seModifico]         BIT             NULL,
    CONSTRAINT [PK_SEG_Recobro] PRIMARY KEY CLUSTERED ([idRecobro] ASC)
);



