CREATE TABLE [dbo].[SEG_ProductoNoPermitido] (
    [idSeguro]          INT          NOT NULL,
    [codigoProducto]    VARCHAR (50) NOT NULL,
    [codigoSubProducto] VARCHAR (50) NOT NULL,
    [codigoCategoria]   VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SEG_ProductoNoPermitido] PRIMARY KEY CLUSTERED ([idSeguro] ASC, [codigoProducto] ASC, [codigoSubProducto] ASC, [codigoCategoria] ASC),
    CONSTRAINT [FK_SEG_ProductoNoPermitido_SEG_Seguro] FOREIGN KEY ([idSeguro]) REFERENCES [dbo].[SEG_Seguro] ([idSeguro])
);

