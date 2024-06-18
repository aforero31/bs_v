CREATE TABLE [dbo].[SEG_VariableProducto] (
    [idVariableProducto] INT          IDENTITY (1, 1) NOT NULL,
    [idSeguro]           INT          NOT NULL,
    [nombreCampo]        VARCHAR (50) NOT NULL,
    [idTipoDato]         INT          NOT NULL,
    [longitud]           INT          NOT NULL,
    [idMaestra]          INT          NULL,
    [orden]              INT          NOT NULL,
    [estado]             BIT          NOT NULL,
    CONSTRAINT [PK_SEG_VariableProducto] PRIMARY KEY CLUSTERED ([idVariableProducto] ASC),
    CONSTRAINT [FK_SEG_VariableProducto_SEG_TipoDato] FOREIGN KEY ([idTipoDato]) REFERENCES [dbo].[SEG_TipoDato] ([idTipoDato])
);

