CREATE TABLE [dbo].[SEG_Parentesco] (
    [idParentesco] INT          IDENTITY (1, 1) NOT NULL,
    [nombre]       VARCHAR (20) NOT NULL,
    [activo]       BIT          NOT NULL,
    [Alias]        VARCHAR (2)  NULL,
    CONSTRAINT [PK_SEG_Parentesco] PRIMARY KEY CLUSTERED ([idParentesco] ASC)
);



