CREATE TABLE [dbo].[SEG_Aplicacion] (
    [IdUsuario] INT           IDENTITY (1, 1) NOT NULL,
    [Login]     VARCHAR (100) NULL,
    [Nombre]    VARCHAR (100) NULL,
    [Password]  VARCHAR (250) NULL,
    CONSTRAINT [PK_ATM_User] PRIMARY KEY CLUSTERED ([IdUsuario] ASC)
);

