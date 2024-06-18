CREATE TABLE [dbo].[SEG_CausalNovedad] (
    [idCausalNovedad]                 INT           IDENTITY (1, 1) NOT NULL,
    [nombreNovedad]                   VARCHAR (255) NULL,
    [idTipoNovedad]                   INT           NULL,
    [codigoCausalNovedadNegocio]      VARCHAR (2)   NULL,
    [Fuente]                          VARCHAR (100) NULL,
    [descripcionCausalNovedadNegocio] VARCHAR (255) NULL,
    [activo]                          BIT           NULL,
    CONSTRAINT [PK_SEG_CausalNovedad] PRIMARY KEY CLUSTERED ([idCausalNovedad] ASC),
    CONSTRAINT [FK_SEG_CausalNovedad_SEG_TipoNovedad] FOREIGN KEY ([idTipoNovedad]) REFERENCES [dbo].[SEG_TipoNovedad] ([idTipoNovedad])
);

