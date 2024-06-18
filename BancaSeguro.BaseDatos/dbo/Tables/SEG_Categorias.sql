CREATE TABLE [dbo].[SEG_Categorias] (
    [idCategoria] INT          IDENTITY (1, 1) NOT NULL,
    [codigo]      VARCHAR (2)  NOT NULL,
    [nombre]      VARCHAR (80) NOT NULL,
    [activo]      BIT          NOT NULL,
    [IdProducto]  INT          NULL,
    CONSTRAINT [PK_SEG_Categorias] PRIMARY KEY CLUSTERED ([idCategoria] ASC)
);



