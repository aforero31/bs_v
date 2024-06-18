CREATE TYPE [dbo].[TipoIdentificacion] AS TABLE (
    [IdTipoIdentificacion] INT          NOT NULL,
    [Abreviatura]          VARCHAR (5)  NOT NULL,
    [Nombre]               VARCHAR (50) NOT NULL,
    [TipoPersona]          VARCHAR (1)  NOT NULL,
    [Activo]               BIT          NOT NULL,
    [CodigoCardif]         CHAR (2)     NOT NULL);

