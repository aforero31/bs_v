CREATE TABLE [dbo].[SEG_ProcesoETL] (
    [id]                   INT           IDENTITY (1, 1) NOT NULL,
    [prefijo]              VARCHAR (20)  NOT NULL,
    [fechaProceso]         DATE          NOT NULL,
    [fechaInicioEjecucion] DATETIME      NOT NULL,
    [fechaFinEjecucion]    DATETIME      NULL,
    [archivoCreado]        VARCHAR (50)  NULL,
    [archivoProcesado]     VARCHAR (50)  NULL,
    [estado]               CHAR (3)      NOT NULL,
    [tarea]                VARCHAR (100) NULL,
    [errorTarea]           VARCHAR (150) NULL,
    CONSTRAINT [PK_SEG_ProcesoETL] PRIMARY KEY CLUSTERED ([id] ASC)
);

