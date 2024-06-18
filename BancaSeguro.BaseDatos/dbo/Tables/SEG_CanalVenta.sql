CREATE TABLE [dbo].[SEG_CanalVenta] (
    [idCanalVenta] INT          IDENTITY (1, 1) NOT NULL,
    [codigo]       INT          NOT NULL,
    [nombre]       VARCHAR (50) NOT NULL,
    [activo]       BIT          NOT NULL,
    CONSTRAINT [PK_SEG_CanalVenta] PRIMARY KEY CLUSTERED ([idCanalVenta] ASC)
);

