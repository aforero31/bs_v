CREATE TABLE [dbo].[SEG_ProductoSubProducto] (
    [codigoProducto] INT NOT NULL,
    [idSubProducto]  INT NOT NULL,
    CONSTRAINT [PK_SEG_ProductoSubProducto] PRIMARY KEY CLUSTERED ([codigoProducto] ASC, [idSubProducto] ASC),
    CONSTRAINT [FK_SEG_ProductoSubProducto_SEG_Productos] FOREIGN KEY ([codigoProducto]) REFERENCES [dbo].[SEG_Productos] ([codigo]),
    CONSTRAINT [FK_SEG_ProductoSubProducto_SEG_SubProductos] FOREIGN KEY ([idSubProducto]) REFERENCES [dbo].[SEG_SubProductos] ([idSubProductos])
);

