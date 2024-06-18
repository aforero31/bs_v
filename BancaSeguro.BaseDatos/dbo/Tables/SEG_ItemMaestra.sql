CREATE TABLE [dbo].[SEG_ItemMaestra] (
    [idMaestra] INT           NOT NULL,
    [codigo]    NVARCHAR (50) NOT NULL,
    [valor]     VARCHAR (100) NOT NULL,
    [activo]    BIT           NOT NULL,
    CONSTRAINT [PK_SEG_ItemMaestra] PRIMARY KEY CLUSTERED ([idMaestra] ASC, [codigo] ASC),
    CONSTRAINT [FK_SEG_ItemMaestra_SEG_Maestra] FOREIGN KEY ([idMaestra]) REFERENCES [dbo].[SEG_Maestra] ([idMaestra])
);

