CREATE TABLE [dbo].[MIG_BeneficiarioError] (
    [id]                 INT            NOT NULL,
    [numeroPoliza]       VARCHAR (50)   NULL,
    [parentesco]         VARCHAR (20)   NULL,
    [tipoIdentificacion] VARCHAR (5)    NULL,
    [identificacion]     VARCHAR (16)   NULL,
    [nombres]            VARCHAR (50)   NULL,
    [apellidos]          VARCHAR (50)   NULL,
    [participacion]      VARCHAR (10)   NULL,
    [mensajeError]       VARCHAR (8000) NULL
);

