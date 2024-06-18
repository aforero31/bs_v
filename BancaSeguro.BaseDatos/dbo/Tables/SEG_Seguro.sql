CREATE TABLE [dbo].[SEG_Seguro] (
    [idSeguro]                                 INT           IDENTITY (1, 1) NOT NULL,
    [idAseguradora]                            INT           NOT NULL,
    [idCanalVenta]                             INT           NOT NULL,
    [nombre]                                   VARCHAR (50)  NOT NULL,
    [descripcion]                              VARCHAR (200) NOT NULL,
    [codigo]                                   VARCHAR (50)  NOT NULL,
    [conyuge]                                  BIT           NOT NULL,
    [edadMinimaConyugue]                       INT           NULL,
    [edadMaximaConyugue]                       INT           NULL,
    [beneficiario]                             BIT           NOT NULL,
    [MaximoBeneficiarios]                      INT           NULL,
    [edadMinimaMujer]                          INT           NOT NULL,
    [edadMaximaMujer]                          INT           NOT NULL,
    [edadMinimaHombre]                         INT           NOT NULL,
    [edadMaximaHombre]                         INT           NOT NULL,
    [numeroMaximoSegurosPorCliente]            INT           CONSTRAINT [DF_SEG_Seguro_numeroMaximoSegurosPorCliente] DEFAULT ((0)) NOT NULL,
    [numeroMaximoVentaSegurosPorCuentaCliente] INT           CONSTRAINT [DF_SEG_Seguro_numeroMaximoVentaSegurosPorCuentaCliente] DEFAULT ((0)) NOT NULL,
    [activo]                                   BIT           NOT NULL,
    CONSTRAINT [PK_SEG_SEGURO] PRIMARY KEY CLUSTERED ([idSeguro] ASC),
    CONSTRAINT [FK_SEG_SEGURO_SEG_Aseguradora] FOREIGN KEY ([idAseguradora]) REFERENCES [dbo].[SEG_Aseguradora] ([idAseguradora])
);



