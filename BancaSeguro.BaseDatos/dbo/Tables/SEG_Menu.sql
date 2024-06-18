CREATE TABLE [dbo].[SEG_Menu] (
    [idMenu]      INT           IDENTITY (1, 1) NOT NULL,
    [idPadre]     INT           NOT NULL,
    [nombre]      VARCHAR (50)  NOT NULL,
    [posicion]    INT           NOT NULL,
    [URL]         VARCHAR (100) NOT NULL,
    [activo]      BIT           NOT NULL,
    [controlDual] BIT           NULL,
    CONSTRAINT [PK_SEG_Menu] PRIMARY KEY CLUSTERED ([idMenu] ASC)
);



