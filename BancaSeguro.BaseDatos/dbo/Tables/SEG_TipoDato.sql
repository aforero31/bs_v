CREATE TABLE [dbo].[SEG_TipoDato] (
    [idTipoDato] INT          IDENTITY (1, 1) NOT NULL,
    [nombre]     VARCHAR (50) NOT NULL,
    [activo]     BIT          NOT NULL,
    CONSTRAINT [PK_SEG_TipoDato] PRIMARY KEY CLUSTERED ([idTipoDato] ASC)
);

