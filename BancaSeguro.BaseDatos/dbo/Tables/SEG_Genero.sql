CREATE TABLE [dbo].[SEG_Genero] (
    [idGenero]     INT          IDENTITY (1, 1) NOT NULL,
    [nombre]       VARCHAR (20) NOT NULL,
    [activo]       BIT          NOT NULL,
    [CodigoCardif] CHAR (2)     NOT NULL,
    CONSTRAINT [PK_SEG_Genero] PRIMARY KEY CLUSTERED ([idGenero] ASC)
);

