CREATE TABLE [dbo].[SEG_LogArchivoSalidaCancelacionPolizas] (
    [codigoProducto]          NVARCHAR (50) NULL,
    [numeroCertificadoSeguro] VARCHAR (50)  NULL,
    [fechaNovedad]            NVARCHAR (50) NULL,
    [causalNovedad]           NVARCHAR (50) NULL,
    [tipoNovedad]             NVARCHAR (50) NULL,
    [ResultadoProcesamiento]  VARCHAR (100) NULL,
    [nombreArchivoEntrada]    VARCHAR (50)  NULL,
    [nombreArchivoSalida]     VARCHAR (50)  NULL,
    [fechaProceso]            DATETIME      NULL
);

