CREATE TABLE [dbo].[MIG_RecobroTemp] (
    [id]           INT          IDENTITY (1, 1) NOT NULL,
    [numeroPoliza] VARCHAR (50) NULL,
    [fechaCobro]   DATE         NULL,
    [intentos]     INT          NULL,
    CONSTRAINT [PK_SEG_RecobroTemp] PRIMARY KEY CLUSTERED ([id] ASC)
);

