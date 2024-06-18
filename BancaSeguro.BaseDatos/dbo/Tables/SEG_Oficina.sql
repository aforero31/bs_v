CREATE TABLE [dbo].[SEG_Oficina] (
    [idOficina] INT          NOT NULL,
    [nombre]    VARCHAR (50) NOT NULL,
    [ciudad]    VARCHAR (50) NOT NULL,
    [activo]    BIT          NOT NULL,
    CONSTRAINT [PK_SEG_Oficina] PRIMARY KEY CLUSTERED ([idOficina] ASC)
);



