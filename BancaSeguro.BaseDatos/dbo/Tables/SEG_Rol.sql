CREATE TABLE [dbo].[SEG_Rol] (
    [idRol]  INT          IDENTITY (1, 1) NOT NULL,
    [nombre] VARCHAR (50) NOT NULL,
    [activo] BIT          NOT NULL,
    CONSTRAINT [pk_PersonID] PRIMARY KEY CLUSTERED ([idRol] ASC)
);



