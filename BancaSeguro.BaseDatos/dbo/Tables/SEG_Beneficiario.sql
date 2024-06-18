CREATE TABLE [dbo].[SEG_Beneficiario] (
    [idBeneficiario]       INT          IDENTITY (1, 1) NOT NULL,
    [idVenta]              INT          NOT NULL,
    [idParentesco]         INT          NOT NULL,
    [idTipoIdentificacion] INT          NOT NULL,
    [identificacion]       VARCHAR (16) NULL,
    [nombres]              VARCHAR (50) NOT NULL,
    [apellidos]            VARCHAR (50) NOT NULL,
    [porcentaje]           INT          NOT NULL,
    CONSTRAINT [PK_SEG_Beneficiario] PRIMARY KEY CLUSTERED ([idBeneficiario] ASC),
    CONSTRAINT [FK_SEG_Beneficiario_SEG_Parentesco] FOREIGN KEY ([idParentesco]) REFERENCES [dbo].[SEG_Parentesco] ([idParentesco]),
    CONSTRAINT [FK_SEG_Beneficiario_SEG_TipoIdentificacion] FOREIGN KEY ([idTipoIdentificacion]) REFERENCES [dbo].[SEG_TipoIdentificacion] ([idTipoIdentificacion]),
    CONSTRAINT [FK_SEG_Beneficiario_SEG_Venta] FOREIGN KEY ([idVenta]) REFERENCES [dbo].[SEG_Venta] ([idVenta])
);



