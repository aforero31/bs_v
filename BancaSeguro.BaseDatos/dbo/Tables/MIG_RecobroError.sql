CREATE TABLE [dbo].[MIG_RecobroError] (
    [id]           INT            NOT NULL,
    [numeroPoliza] VARCHAR (50)   NULL,
    [fechaCobro]   VARCHAR (10)   NULL,
    [intentos]     VARCHAR (10)   NULL,
    [mensajeError] VARCHAR (4000) NULL
);

