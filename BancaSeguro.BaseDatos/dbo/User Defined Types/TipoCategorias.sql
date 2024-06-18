CREATE TYPE [dbo].[TipoCategorias] AS TABLE (
    [IdCategoria] INT          NOT NULL,
    [Codigo]      VARCHAR (2)  NOT NULL,
    [Nombre]      VARCHAR (80) NOT NULL,
    [Activo]      BIT          NOT NULL,
    [IdProducto]  INT          NULL);

