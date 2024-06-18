CREATE TABLE [dbo].[SEG_Auditoria] (
    [AuditID]         INT            IDENTITY (1, 1) NOT NULL,
    [Type]            CHAR (1)       NULL,
    [TableName]       VARCHAR (128)  NULL,
    [PrimaryKeyField] VARCHAR (1000) NULL,
    [PrimaryKeyValue] VARCHAR (1000) NULL,
    [FieldName]       VARCHAR (128)  NULL,
    [OldValue]        VARCHAR (1500) NULL,
    [NewValue]        VARCHAR (1500) NULL,
    [UpdateDate]      DATETIME       DEFAULT (getdate()) NULL,
    [UserName]        VARCHAR (128)  NULL
);

