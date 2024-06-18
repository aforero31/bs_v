CREATE TABLE [dbo].[SEG_LogErrores] (
    [IdError] BIGINT        IDENTITY (1, 1) NOT NULL,
    [Error]   VARCHAR (MAX) NOT NULL,
    [Fecha]   DATETIME      NULL,
    CONSTRAINT [PK_SEG_LogErrores] PRIMARY KEY CLUSTERED ([IdError] ASC)
);

