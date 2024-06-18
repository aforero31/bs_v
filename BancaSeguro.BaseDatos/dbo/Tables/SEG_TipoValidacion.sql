CREATE TABLE [dbo].[SEG_TipoValidacion] (
    [idTipoValidacion] INT           IDENTITY (1, 1) NOT NULL,
    [idTipoDato]       INT           NOT NULL,
    [propiedad]        VARCHAR (50)  NOT NULL,
    [valor]            VARCHAR (255) NOT NULL,
    [descripcion]      VARCHAR (255) NULL,
    CONSTRAINT [PK_SEG_TipoValidacion] PRIMARY KEY CLUSTERED ([idTipoValidacion] ASC),
    CONSTRAINT [FK_SEG_TipoValidacion_SEG_TipoDato] FOREIGN KEY ([idTipoDato]) REFERENCES [dbo].[SEG_TipoDato] ([idTipoDato])
);

