CREATE TYPE [dbo].[TipoSubProductos] AS TABLE (
    [idSubProductos] INT          NOT NULL,
    [codigo]         INT          NULL,
    [nombre]         VARCHAR (60) NOT NULL,
    [activo]         BIT          NOT NULL,
    [idProducto]     INT          NULL);

