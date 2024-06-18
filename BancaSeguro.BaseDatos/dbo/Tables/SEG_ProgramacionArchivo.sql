CREATE TABLE [dbo].[SEG_ProgramacionArchivo] (
    [idProgramacion]   INT            IDENTITY (1, 1) NOT NULL,
    [nombre]           VARCHAR (50)   NOT NULL,
    [descripcion]      VARCHAR (200)  NULL,
    [tipoProgramacion] INT            NOT NULL,
    [fechaInicio]      DATETIME       NOT NULL,
    [fechaFin]         DATETIME       NULL,
    [programacion]     XML            NOT NULL,
    [ultimaEjecucion]  DATETIME       NULL,
    [proximaEjecucion] DATETIME       NULL,
    [rutaDestinoFTP]   VARCHAR (200)  NOT NULL,
    [separador]        CHAR (1)       NOT NULL,
    [idAseguradora]    INT            NOT NULL,
    [codigoFiltro]     TINYINT        NOT NULL,
    [criterioFiltro]   VARCHAR (50)   NOT NULL,
    [camposConsulta]   VARCHAR (5000) NOT NULL,
    [estado]           BIT            NOT NULL,
    CONSTRAINT [PK_SEG_PragramacionArchivo] PRIMARY KEY CLUSTERED ([idProgramacion] ASC)
);

