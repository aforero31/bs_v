CREATE TABLE [dbo].[SEG_DetalleNovedadPoliza] (
    [id]                     INT      IDENTITY (1, 1) NOT NULL,
    [idVenta]                INT      NOT NULL,
    [fechaNovedad]           DATETIME NOT NULL,
    [fechaUltimoPeriodoPago] DATE     NULL,
    [idCausalNovedad]        INT      NOT NULL,
    CONSTRAINT [PK_SEG_DetalleCancelacionPoliza] PRIMARY KEY CLUSTERED ([id] ASC)
);

