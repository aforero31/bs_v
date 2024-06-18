CREATE TABLE [dbo].[SEG_ImpresionesPoliza] (
    [idImpresionPoliza] INT          IDENTITY (1, 1) NOT NULL,
    [datosPolizaXML]    XML          NOT NULL,
    [idDocumentoPoliza] INT          NOT NULL,
    [fechaImpresion]    DATETIME     NOT NULL,
    [consecutivoPoliza] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SEG_ImpresionesPoliza] PRIMARY KEY CLUSTERED ([idImpresionPoliza] ASC)
);

