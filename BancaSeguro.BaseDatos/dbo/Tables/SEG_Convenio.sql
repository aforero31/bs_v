CREATE TABLE [dbo].[SEG_Convenio] (
    [id]             INT          IDENTITY (1, 1) NOT NULL,
    [codigoConvenio] INT          NOT NULL,
    [nombreConvenio] VARCHAR (50) NULL,
    [idAseguradora]  INT          NULL,
    [Activo]         BIT          CONSTRAINT [DF_SEG_Convenio_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_SEG_Convenio] PRIMARY KEY CLUSTERED ([codigoConvenio] ASC),
    CONSTRAINT [FK_SEG_Convenio_SEG_Aseguradora] FOREIGN KEY ([idAseguradora]) REFERENCES [dbo].[SEG_Aseguradora] ([idAseguradora])
);



