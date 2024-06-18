CREATE TABLE [dbo].[MIG_ConyugeTemp] (
    [id]                   INT          IDENTITY (1, 1) NOT NULL,
    [numeroPoliza]         VARCHAR (50) NULL,
    [tipoIdentificacion]   VARCHAR (5)  NULL,
    [identificacion]       VARCHAR (16) NULL,
    [primerNombre]         VARCHAR (50) NULL,
    [segundoNombre]        VARCHAR (50) NULL,
    [primerApellido]       VARCHAR (50) NULL,
    [segundoApellido]      VARCHAR (50) NULL,
    [fechaNacimiento]      DATE         NULL,
    [genero]               VARCHAR (2)  NULL,
    [idTipoIdentificacion] INT          NULL,
    [idGenero]             INT          NULL,
    CONSTRAINT [PK_SEG_ConyugeTemp] PRIMARY KEY CLUSTERED ([id] ASC)
);

