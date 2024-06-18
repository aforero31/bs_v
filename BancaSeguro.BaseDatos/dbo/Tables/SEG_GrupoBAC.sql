CREATE TABLE [dbo].[SEG_GrupoBAC] (
    [idGrupo]     INT          IDENTITY (1, 1) NOT NULL,
    [nombreGrupo] VARCHAR (50) NOT NULL,
    [codigoGrupo] VARCHAR (10) NOT NULL,
    [activo]      BIT          NOT NULL,
    CONSTRAINT [PK_SEG_GrupoBAC] PRIMARY KEY CLUSTERED ([idGrupo] ASC)
);

