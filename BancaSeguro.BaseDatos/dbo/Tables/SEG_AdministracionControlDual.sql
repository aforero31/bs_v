CREATE TABLE [dbo].[SEG_AdministracionControlDual] (
    [idControlDual] INT IDENTITY (1, 1) NOT NULL,
    [id_Menu]       INT NOT NULL,
    [id_Rol]        INT NOT NULL,
    [Requiere]      BIT NULL,
    [Autoriza]      BIT NULL
);

