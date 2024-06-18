CREATE TYPE [dbo].[TipoPeriodicidad] AS TABLE (
    [idPeriodicidad]          INT          NOT NULL,
    [nombre]                  VARCHAR (50) NOT NULL,
    [activo]                  BIT          NOT NULL,
    [numeroMesesPeriodicidad] INT          NOT NULL);

