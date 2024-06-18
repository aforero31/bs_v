CREATE TABLE [dbo].[SEG_Conyuge] (
    [idVenta]              INT          NOT NULL,
    [IdTipoIdentificacion] INT          NOT NULL,
    [identificacion]       VARCHAR (16) NOT NULL,
    [primerNombre]         VARCHAR (50) NOT NULL,
    [segundoNombre]        VARCHAR (50) NULL,
    [primerApellido]       VARCHAR (50) NOT NULL,
    [segundoApellido]      VARCHAR (50) NULL,
    [fechaNacimiento]      DATETIME     NOT NULL,
    [IdGenero]             INT          NOT NULL,
    CONSTRAINT [PK_SEG_Conyuge_1] PRIMARY KEY CLUSTERED ([idVenta] ASC),
    CONSTRAINT [FK_SEG_Conyuge_SEG_Genero] FOREIGN KEY ([IdGenero]) REFERENCES [dbo].[SEG_Genero] ([idGenero]),
    CONSTRAINT [FK_SEG_Conyuge_SEG_TipoIdentificacion] FOREIGN KEY ([IdTipoIdentificacion]) REFERENCES [dbo].[SEG_TipoIdentificacion] ([idTipoIdentificacion]),
    CONSTRAINT [FK_SEG_Conyuge_SEG_Venta] FOREIGN KEY ([idVenta]) REFERENCES [dbo].[SEG_Venta] ([idVenta])
);



