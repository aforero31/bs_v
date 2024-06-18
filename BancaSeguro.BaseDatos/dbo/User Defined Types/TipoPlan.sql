CREATE TYPE [dbo].[TipoPlan] AS TABLE (
    [IdPlan]         INT             NULL,
    [IdSeguro]       INT             NULL,
    [CodigoPlan]     INT             NULL,
    [Valor]          DECIMAL (18, 2) NULL,
    [NombrePlan]     VARCHAR (50)    NULL,
    [Descripcion]    VARCHAR (200)   NULL,
    [ValorIVA]       DECIMAL (18, 2) NULL,
    [ValorSinIVA]    DECIMAL (18, 2) NULL,
    [IdPeriodicidad] INT             NULL,
    [Activo]         BIT             NULL,
    [CodigoConvenio] INT             NULL);

