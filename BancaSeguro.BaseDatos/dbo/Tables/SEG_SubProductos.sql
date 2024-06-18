CREATE TABLE [dbo].[SEG_SubProductos] (
    [idSubProductos] INT          IDENTITY (1, 1) NOT NULL,
    [codigo]         INT          NULL,
    [nombre]         VARCHAR (60) NOT NULL,
    [activo]         BIT          NOT NULL,
    [IdProducto]     INT          NULL,
    CONSTRAINT [PK_SEG_SubProductos] PRIMARY KEY CLUSTERED ([idSubProductos] ASC)
);



