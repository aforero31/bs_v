CREATE TABLE [dbo].[SEG_EstadoCobro] (
    [Id]                     INT           IDENTITY (1, 1) NOT NULL,
    [codigoEstadoCobro]      INT           NOT NULL,
    [descripcionEstadoCobro] VARCHAR (200) NULL,
    CONSTRAINT [PK_SEG_EstadoCobro] PRIMARY KEY CLUSTERED ([codigoEstadoCobro] ASC)
);



