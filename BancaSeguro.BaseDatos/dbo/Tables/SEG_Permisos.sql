CREATE TABLE [dbo].[SEG_Permisos] (
    [idMenu] INT NOT NULL,
    [idRol]  INT NOT NULL,
    [activo] BIT NULL,
    CONSTRAINT [PK_SEG_Permisos] PRIMARY KEY CLUSTERED ([idMenu] ASC, [idRol] ASC),
    CONSTRAINT [FK_SEG_Permisos_SEG_Menu] FOREIGN KEY ([idMenu]) REFERENCES [dbo].[SEG_Menu] ([idMenu]),
    CONSTRAINT [FK_SEG_Permisos_SEG_Rol] FOREIGN KEY ([idRol]) REFERENCES [dbo].[SEG_Rol] ([idRol])
);



