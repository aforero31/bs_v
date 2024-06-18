CREATE TABLE [dbo].[SEG_Plan] (
    [idPlan]         INT             IDENTITY (1, 1) NOT NULL,
    [idSeguro]       INT             NOT NULL,
    [idPeriodicidad] INT             NOT NULL,
    [codigo]         INT             NOT NULL,
    [codigoConvenio] INT             NOT NULL,
    [nombre]         VARCHAR (50)    NOT NULL,
    [descripcion]    VARCHAR (200)   NOT NULL,
    [valor]          DECIMAL (18, 2) NOT NULL,
    [valorIva]       DECIMAL (18, 2) CONSTRAINT [DF_SEG_Plan_ValorIva] DEFAULT ((0)) NOT NULL,
    [valorSinIva]    DECIMAL (18, 2) CONSTRAINT [DF_SEG_Plan_ValorSinIva] DEFAULT ((0)) NOT NULL,
    [activo]         BIT             NOT NULL,
    CONSTRAINT [PK_SEG_Plan] PRIMARY KEY CLUSTERED ([idPlan] ASC),
    CONSTRAINT [FK_SEG_Plan_SEG_Periodicidad] FOREIGN KEY ([idPeriodicidad]) REFERENCES [dbo].[SEG_Periodicidad] ([idPeriodicidad]),
    CONSTRAINT [FK_SEG_Plan_SEG_SEGURO] FOREIGN KEY ([idSeguro]) REFERENCES [dbo].[SEG_Seguro] ([idSeguro])
);



