CREATE TABLE [dbo].[SEG_Aseguradora] (
    [idAseguradora]          INT           IDENTITY (1, 1) NOT NULL,
    [nombre]                 VARCHAR (50)  NOT NULL,
    [codigoSuperintendencia] VARCHAR (50)  NULL,
    [idTipoIdentificacion]   INT           NOT NULL,
    [identificacion]         VARCHAR (50)  NOT NULL,
    [contacto]               VARCHAR (50)  NOT NULL,
    [telefono]               VARCHAR (50)  NOT NULL,
    [correo]                 VARCHAR (100) NOT NULL,
    [activo]                 BIT           NOT NULL,
    [consecutivoInicial]     INT           NOT NULL,
    [consecutivoActual]      INT           NOT NULL,
    CONSTRAINT [PK_SEG_Aseguradora] PRIMARY KEY CLUSTERED ([idAseguradora] ASC),
    CONSTRAINT [FK_SEG_Aseguradora_SEG_TipoIdentificacion] FOREIGN KEY ([idTipoIdentificacion]) REFERENCES [dbo].[SEG_TipoIdentificacion] ([idTipoIdentificacion])
);



