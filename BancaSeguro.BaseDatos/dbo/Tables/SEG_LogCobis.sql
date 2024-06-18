CREATE TABLE [dbo].[SEG_LogCobis] (
    [Consecutivo]      INT            IDENTITY (1, 1) NOT NULL,
    [XML_Request]      NVARCHAR (MAX) NOT NULL,
    [Hora_Request]     VARCHAR (20)   NULL,
    [XML_Response]     NVARCHAR (MAX) NOT NULL,
    [Hora_Response]    VARCHAR (20)   NULL,
    [Usuario]          VARCHAR (50)   NULL,
    [Tipo_Transaccion] VARCHAR (50)   NULL,
    [Fecha]            DATETIME       NULL,
    CONSTRAINT [PK_ConsecutivoCB] PRIMARY KEY NONCLUSTERED ([Consecutivo] ASC)
);

