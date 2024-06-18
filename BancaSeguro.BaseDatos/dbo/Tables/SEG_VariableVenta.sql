CREATE TABLE [dbo].[SEG_VariableVenta] (
    [idVariableVenta]    INT           IDENTITY (1, 1) NOT NULL,
    [idVenta]            INT           NOT NULL,
    [idVariableProducto] INT           NOT NULL,
    [valor]              VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_SEG_VariableVenta] PRIMARY KEY CLUSTERED ([idVariableVenta] ASC),
    CONSTRAINT [FK_SEG_VariableVenta_SEG_VariableProducto] FOREIGN KEY ([idVariableProducto]) REFERENCES [dbo].[SEG_VariableProducto] ([idVariableProducto]),
    CONSTRAINT [FK_SEG_VariableVenta_SEG_Venta] FOREIGN KEY ([idVenta]) REFERENCES [dbo].[SEG_Venta] ([idVenta])
);

