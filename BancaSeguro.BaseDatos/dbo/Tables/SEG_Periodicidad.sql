CREATE TABLE [dbo].[SEG_Periodicidad] (
    [idPeriodicidad]          INT          IDENTITY (1, 1) NOT NULL,
    [nombre]                  VARCHAR (50) NOT NULL,
    [activo]                  BIT          NOT NULL,
    [numeroMesesPeriodicidad] INT          NOT NULL,
    CONSTRAINT [PK_SEG_Periodicidad] PRIMARY KEY CLUSTERED ([idPeriodicidad] ASC)
);



