CREATE TYPE [dbo].[TipoParentesco] AS TABLE (
    [idParentesco] INT          NOT NULL,
    [nombre]       VARCHAR (20) NOT NULL,
    [activo]       BIT          NOT NULL,
    [Alias]        VARCHAR (2)  NULL);

