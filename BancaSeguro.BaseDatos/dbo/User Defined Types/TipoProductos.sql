CREATE TYPE [dbo].[TipoProductos] AS TABLE (
    [IdProductos]  INT          NOT NULL,
    [Codigo]       INT          NOT NULL,
    [Nombre]       VARCHAR (50) NOT NULL,
    [Activo]       BIT          NOT NULL,
    [CodigoCardif] CHAR (2)     NOT NULL);

