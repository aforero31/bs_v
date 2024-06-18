CREATE TABLE [dbo].[SEG_SubProductosCategorias] (
    [idCategoria]    INT NOT NULL,
    [idSubProductos] INT NOT NULL,
    CONSTRAINT [PK_SubProductosCategorias] PRIMARY KEY CLUSTERED ([idCategoria] ASC, [idSubProductos] ASC),
    CONSTRAINT [FK_SubProductosCategorias_SEG_Categorias] FOREIGN KEY ([idCategoria]) REFERENCES [dbo].[SEG_Categorias] ([idCategoria]),
    CONSTRAINT [FK_SubProductosCategorias_SEG_SubProductos] FOREIGN KEY ([idSubProductos]) REFERENCES [dbo].[SEG_SubProductos] ([idSubProductos])
);

