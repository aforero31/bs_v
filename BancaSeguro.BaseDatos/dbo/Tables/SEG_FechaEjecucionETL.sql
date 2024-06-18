CREATE TABLE [dbo].[SEG_FechaEjecucionETL] (
    [Id]                INT          IDENTITY (1, 1) NOT NULL,
    [FechaEjecucionETL] DATETIME     NULL,
    [Prefijo]           VARCHAR (3)  NOT NULL,
    [Nombre]            VARCHAR (50) NOT NULL
);



