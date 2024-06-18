CREATE TABLE [dbo].[MIG_RegistroControlArchivo] (
    [id]             INT             IDENTITY (1, 1) NOT NULL,
    [nombreArchivo]  VARCHAR (50)    NOT NULL,
    [nombreControl]  VARCHAR (50)    NOT NULL,
    [numeroControl]  INT             NOT NULL,
    [columna]        INT             NULL,
    [valorReportado] DECIMAL (18, 2) NULL,
    [valorCalculado] DECIMAL (18, 2) NULL,
    [cumplio]        BIT             NULL
);

