CREATE TABLE [dbo].[SEG_AprobacionDual] (
    [idAprobacionDual] INT           IDENTITY (1, 1) NOT NULL,
    [idMenu]           INT           NOT NULL,
    [estado]           CHAR (1)      NOT NULL,
    [accion]           VARCHAR (15)  NOT NULL,
    [usuarioEnvia]     VARCHAR (50)  NOT NULL,
    [usuarioAprueba]   VARCHAR (50)  NULL,
    [fechaSolicitud]   DATETIME      NOT NULL,
    [fechaAprobacion]  DATETIME      NULL,
    [nombreObjeto]     VARCHAR (50)  NOT NULL,
    [datosObjeto]      VARCHAR (MAX) NOT NULL,
    [descripcion]      VARCHAR (500) NULL,
    CONSTRAINT [PK_SEG_AprobacionDual] PRIMARY KEY CLUSTERED ([idAprobacionDual] ASC)
);




GO


