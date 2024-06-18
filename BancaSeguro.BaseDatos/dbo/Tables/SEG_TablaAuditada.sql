CREATE TABLE [dbo].[SEG_TablaAuditada] (
    [idTabla] INT          IDENTITY (1, 1) NOT NULL,
    [nombre]  VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SEG_TablaAuditada] PRIMARY KEY CLUSTERED ([idTabla] ASC)
);

