/*--------------------------------------------------------------------------
CREACIÓN
REQUERIMIENTO: SD4289524 
PROPOSITO: Creación de tabla SEG_CuentaEximidaCobro
AUTOR: Paulo Mora
EMPRESA: INTERGRUPO S.A.S.
FECHA DE CREACIÓN: 17/04/2020
----------------------------------------------------------------------------*/
CREATE TABLE [dbo].[SEG_CuentaEximidaCobro] (
    [codigoTipoCuenta] INT          NOT NULL,
    [numeroCuenta]     VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SEG_CuentaEximidaCobro] PRIMARY KEY CLUSTERED ([codigoTipoCuenta] ASC, [numeroCuenta] ASC)
);

