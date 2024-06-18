CREATE TABLE [dbo].[MIG_BeneficiarioTemp] (
    [id]                   INT          IDENTITY (1, 1) NOT NULL,
    [numeroPoliza]         VARCHAR (50) NULL,
    [parentesco]           VARCHAR (20) NULL,
    [tipoIdentificacion]   VARCHAR (5)  NULL,
    [identificacion]       VARCHAR (16) NULL,
    [nombres]              VARCHAR (50) NULL,
    [apellidos]            VARCHAR (50) NULL,
    [participacion]        INT          NULL,
    [idTipoIdentificacion] INT          NULL,
    [idParentesco]         INT          NULL,
    CONSTRAINT [PK_SEG_BeneficiarioTemp] PRIMARY KEY CLUSTERED ([id] ASC)
);

