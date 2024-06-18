﻿CREATE TABLE [dbo].[MIG_VentaTemp] (
    [id]                                INT             IDENTITY (1, 1) NOT NULL,
    [idAsesor]                          VARCHAR (50)    NULL,
    [numeroPoliza]                      VARCHAR (50)    NULL,
    [fechaCreacion]                     DATE            NULL,
    [idTipoIdentificacion]              INT             NULL,
    [tipoIdentificacionAsegurado]       VARCHAR (5)     NULL,
    [nombreTipoIdentificacionAsegurado] VARCHAR (50)    NULL,
    [identificacionAsegurado]           VARCHAR (16)    NULL,
    [primerNombre]                      VARCHAR (50)    NULL,
    [segundoNombre]                     VARCHAR (50)    NULL,
    [primerApellido]                    VARCHAR (50)    NULL,
    [segundoApellido]                   VARCHAR (50)    NULL,
    [codigoGenero]                      VARCHAR (2)     NULL,
    [fechaNacimiento]                   DATE            NULL,
    [ciudadNacimiento]                  VARCHAR (50)    NULL,
    [nacionalidad]                      VARCHAR (50)    NULL,
    [idGenero]                          INT             NULL,
    [nombreGenero]                      VARCHAR (50)    NULL,
    [departamentoResidencia]            VARCHAR (50)    NULL,
    [ciudadResidencia]                  VARCHAR (50)    NULL,
    [direccionResidencia]               VARCHAR (200)   NULL,
    [telefono]                          VARCHAR (50)    NULL,
    [correo]                            VARCHAR (100)   NULL,
    [valorPoliza]                       DECIMAL (18, 2) NULL,
    [tipoCuenta]                        INT             NULL,
    [nombreTipoCuenta]                  VARCHAR (50)    NULL,
    [codigoProducto]                    INT             NULL,
    [nombreProducto]                    VARCHAR (50)    NULL,
    [codigoCanalVenta]                  INT             NULL,
    [nombreCanalVenta]                  VARCHAR (50)    NULL,
    [codigoPlan]                        INT             NULL,
    [nombrePlan]                        VARCHAR (50)    NULL,
    [codigoConvenio]                    INT             NULL,
    [periodicidad]                      VARCHAR (50)    NULL,
    [numeroMeses]                       INT             NULL,
    [numeroCuenta]                      VARCHAR (50)    NULL,
    [ultimoIPC]                         INT             NULL,
    [identificacionAseguradora]         VARCHAR (50)    NULL,
    [nombreAseguradora]                 VARCHAR (50)    NULL,
    [codigoOficina]                     INT             NULL,
    [nombreOficina]                     VARCHAR (50)    NULL,
    [ciudadOficina]                     VARCHAR (50)    NULL,
    [identificacionAsesor]              VARCHAR (16)    NULL,
    [nombreAsesor]                      VARCHAR (50)    NULL,
    [altura]                            INT             NULL,
    CONSTRAINT [PK_SEG_VentaTemp] PRIMARY KEY CLUSTERED ([id] ASC)
);
