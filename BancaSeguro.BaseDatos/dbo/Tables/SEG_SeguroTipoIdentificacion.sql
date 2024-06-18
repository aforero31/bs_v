CREATE TABLE [dbo].[SEG_SeguroTipoIdentificacion] (
    [idSeguro]             INT NOT NULL,
    [idTipoIdentificacion] INT NOT NULL,
    CONSTRAINT [PK_SEG_SeguroTipoIdentificacion] PRIMARY KEY CLUSTERED ([idSeguro] ASC, [idTipoIdentificacion] ASC),
    CONSTRAINT [FK_SEG_SeguroTipoIdentificacion_SEG_SEGURO] FOREIGN KEY ([idSeguro]) REFERENCES [dbo].[SEG_Seguro] ([idSeguro]),
    CONSTRAINT [FK_SEG_SeguroTipoIdentificacion_SEG_TipoIdentificacion] FOREIGN KEY ([idTipoIdentificacion]) REFERENCES [dbo].[SEG_TipoIdentificacion] ([idTipoIdentificacion])
);

