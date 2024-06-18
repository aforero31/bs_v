CREATE TABLE [dbo].[SEG_Parametro] (
    [idParametro]       INT          IDENTITY (1, 1) NOT NULL,
    [idTipoDato]        INT          NOT NULL,
    [valor]             VARCHAR (84) NOT NULL,
    [descripcion]       VARCHAR (84) NULL,
    [fechaModificacion] DATETIME     NULL,
    [activo]            BIT          NOT NULL,
    [visible]           BIT          NOT NULL,
    CONSTRAINT [PK_SEG_Parametro] PRIMARY KEY CLUSTERED ([idParametro] ASC),
    CONSTRAINT [FK_SEG_Parametro_SEG_TipoDato] FOREIGN KEY ([idTipoDato]) REFERENCES [dbo].[SEG_TipoDato] ([idTipoDato])
);



