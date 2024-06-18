CREATE TABLE [dbo].[SEG_Consecutivo] (
    [idConsecutivo]        INT IDENTITY (1, 1) NOT NULL,
    [idAseguradora]        INT NOT NULL,
    [consecutivoActual]    INT NOT NULL,
    [siguienteConsecutivo] INT NULL,
    CONSTRAINT [PK_SEG_Consecutivo] PRIMARY KEY CLUSTERED ([idConsecutivo] ASC)
);

