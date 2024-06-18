CREATE TABLE [dbo].[SEG_IncrementoIPC] (
    [idIPC] INT            IDENTITY (1, 1) NOT NULL,
    [ano]   INT            NULL,
    [ipc]   DECIMAL (9, 2) NULL,
    CONSTRAINT [PK_SEG_IncrementoIPC] PRIMARY KEY CLUSTERED ([idIPC] ASC)
);



