CREATE TABLE [dbo].[SEG_Asesor] (
    [idAsesor]             VARCHAR (50)  NOT NULL,
    [idOficina]            INT           NOT NULL,
    [nombre]               VARCHAR (100) NOT NULL,
    [NumeroIdentificacion] VARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_SEG_Asesor] PRIMARY KEY CLUSTERED ([idAsesor] ASC)
);



