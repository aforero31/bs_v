

CREATE PROCEDURE [dbo].[PR_InsertarLogGeneral]
(
    @tipo VARCHAR(15),
    @excepcion VARCHAR(3000),
    @metodo VARCHAR(150)
)
AS
SET NOCOUNT ON;
DECLARE @s_Error VARCHAR(500)

BEGIN TRY
	DECLARE @fechaActual DATETIME = GETDATE()
    INSERT INTO dbo.LogGeneral(tipo, excepcion, metodo, fechaExcepcion)
    VALUES(@tipo, @excepcion, @metodo, @fechaActual)
END TRY
BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

    SELECT   
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  

    RAISERROR (@ErrorMessage,   
                @ErrorSeverity,  
                @ErrorState
                ); 
END CATCH