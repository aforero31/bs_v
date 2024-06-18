CREATE TABLE [dbo].[LogGeneral] (
    [idLog]          INT            IDENTITY (1, 1) NOT NULL,
    [tipo]           VARCHAR (15)   NOT NULL,
    [excepcion]      VARCHAR (3000) NOT NULL,
    [metodo]         VARCHAR (150)  NULL,
    [fechaExcepcion] DATETIME       NOT NULL,
    CONSTRAINT [PK_LogGeneral] PRIMARY KEY CLUSTERED ([idLog] ASC)
);

