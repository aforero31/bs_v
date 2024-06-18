CREATE TABLE [dbo].[SEG_Mensaje] (
    [idMensaje]     INT           IDENTITY (1, 1) NOT NULL,
    [Llave]         VARCHAR (50)  NOT NULL,
    [idEvento]      INT           NOT NULL,
    [idTipoMensaje] INT           NOT NULL,
    [Mensaje]       VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_SEG_Mensaje] PRIMARY KEY CLUSTERED ([idMensaje] ASC),
    CONSTRAINT [uc_MensajeLlave] UNIQUE NONCLUSTERED ([Llave] ASC)
);

