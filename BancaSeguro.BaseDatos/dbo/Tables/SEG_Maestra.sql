CREATE TABLE [dbo].[SEG_Maestra] (
    [idMaestra] INT          IDENTITY (1, 1) NOT NULL,
    [nombre]    VARCHAR (50) NOT NULL,
    [activo]    BIT          NOT NULL,
    CONSTRAINT [PK_SEG_Maestra] PRIMARY KEY CLUSTERED ([idMaestra] ASC)
);

