CREATE TABLE [dbo].[SEG_RolGrupoBAC] (
    [idRol]   INT NOT NULL,
    [idGrupo] INT NOT NULL,
    [activo]  BIT NOT NULL,
    CONSTRAINT [PK_SEG_RolGrupoBAC] PRIMARY KEY CLUSTERED ([idRol] ASC, [idGrupo] ASC),
    CONSTRAINT [FK_SEG_RolGrupoBAC_SEG_GrupoBAC] FOREIGN KEY ([idGrupo]) REFERENCES [dbo].[SEG_GrupoBAC] ([idGrupo]),
    CONSTRAINT [FK_SEG_RolGrupoBAC_SEG_Rol] FOREIGN KEY ([idRol]) REFERENCES [dbo].[SEG_Rol] ([idRol])
);



