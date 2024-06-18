CREATE TABLE [dbo].[SEG_Productos] (
    [idProductos]  INT          IDENTITY (1, 1) NOT NULL,
    [codigo]       INT          NOT NULL,
    [nombre]       VARCHAR (50) NOT NULL,
    [activo]       BIT          NOT NULL,
    [CodigoCardif] CHAR (2)     NOT NULL,
    CONSTRAINT [PK_SEG_Productos] PRIMARY KEY CLUSTERED ([codigo] ASC)
);

