CREATE TABLE [dbo].[SEG_TipoNovedad] (
    [idTipoNovedad]     INT          IDENTITY (1, 1) NOT NULL,
    [codigoTipoNovedad] INT          NOT NULL,
    [nombreTipoNovedad] VARCHAR (50) NOT NULL,
    [activo]            BIT          NOT NULL,
    CONSTRAINT [PK_SEG_TipoNovedad] PRIMARY KEY CLUSTERED ([idTipoNovedad] ASC)
);

