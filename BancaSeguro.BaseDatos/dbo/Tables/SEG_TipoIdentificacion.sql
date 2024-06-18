CREATE TABLE [dbo].[SEG_TipoIdentificacion] (
    [idTipoIdentificacion] INT          IDENTITY (1, 1) NOT NULL,
    [abreviatura]          VARCHAR (5)  NOT NULL,
    [nombre]               VARCHAR (50) NOT NULL,
    [tipoPersona]          VARCHAR (1)  NOT NULL,
    [activo]               BIT          NOT NULL,
    [CodigoCardif]         CHAR (2)     NOT NULL,
    CONSTRAINT [PK_SEG_TipoIdentificacion] PRIMARY KEY CLUSTERED ([idTipoIdentificacion] ASC)
);

