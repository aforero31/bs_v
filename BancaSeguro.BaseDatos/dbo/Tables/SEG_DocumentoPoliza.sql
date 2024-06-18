CREATE TABLE [dbo].[SEG_DocumentoPoliza] (
    [idDocumentoPoliza] INT             IDENTITY (1, 1) NOT NULL,
    [idSeguro]          INT             NOT NULL,
    [plantilla]         VARBINARY (MAX) NOT NULL,
    [versionDocumento]  VARCHAR (10)    NOT NULL,
    [fechaCreacion]     DATETIME        NOT NULL,
    [usuarioCreacion]   VARCHAR (20)    NOT NULL,
    [nombreArchivo]     VARCHAR (100)   NOT NULL,
    [camposPlantilla]   VARCHAR (MAX)   NOT NULL,
    [activa]            BIT             NOT NULL,
    [eliminado]         BIT             NOT NULL,
    CONSTRAINT [PK_SEG_DocumentoPoliza] PRIMARY KEY CLUSTERED ([idDocumentoPoliza] ASC),
    CONSTRAINT [FK__SEG_Docum__idSeg__2DB1C7EE] FOREIGN KEY ([idSeguro]) REFERENCES [dbo].[SEG_Seguro] ([idSeguro])
);



