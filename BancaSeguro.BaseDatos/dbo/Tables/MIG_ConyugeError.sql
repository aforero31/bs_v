CREATE TABLE [dbo].[MIG_ConyugeError] (
    [id]                 INT            NOT NULL,
    [numeroPoliza]       VARCHAR (50)   NULL,
    [tipoIdentificacion] VARCHAR (5)    NULL,
    [identificacion]     VARCHAR (16)   NULL,
    [primerNombre]       VARCHAR (50)   NULL,
    [segundoNombre]      VARCHAR (50)   NULL,
    [primerApellido]     VARCHAR (50)   NULL,
    [segundoApellido]    VARCHAR (50)   NULL,
    [fechaNacimiento]    VARCHAR (10)   NULL,
    [genero]             VARCHAR (2)    NULL,
    [mensajeError]       VARCHAR (8000) NULL
);

