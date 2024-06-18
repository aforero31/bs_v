CREATE TABLE [dbo].[MIG_EjecucionMigracion] (
    [id]                       INT           IDENTITY (1, 1) NOT NULL,
    [nombreArchivo]            VARCHAR (50)  NOT NULL,
    [fechaInicioEjecucion]     DATETIME      NULL,
    [totalRegistros]           INT           NULL,
    [estado]                   INT           NULL,
    [fechaFinEjecucion]        DATETIME      NULL,
    [mensajeError]             VARCHAR (200) NULL,
    [totalRegistosErroneos]    INT           NULL,
    [totalRegistrosTemporales] INT           NULL
);

