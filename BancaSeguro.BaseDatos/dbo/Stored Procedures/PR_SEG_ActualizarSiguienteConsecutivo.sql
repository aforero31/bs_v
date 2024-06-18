CREATE PROCEDURE [dbo].[PR_SEG_ActualizarSiguienteConsecutivo]
(
@idPlan    INT,
@identificacion VARCHAR(16),
@Consecutivo VARCHAR(50)
)
AS
/*--------------------------------------------------------------------------------------------------
CREACION 
REQUERIMIENTO: SD3398731 
PROPOSITO: Se añade campo en el order by para que tenga en cuanta el mayor valor
AUTOR: Enrique Rivera
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN: 18/05/2018
--------------------------------------------------------------------------------------------------*/
BEGIN
	DECLARE @siguienteConsecutivo INT
	DECLARE @IdAseguradora INT
	DECLARE @CodSeguro INT
	DECLARE @NroPolizaGenerada VARCHAR(50)
		
	SELECT @siguienteConsecutivo = t1.consecutivoActual+1,
	@IdAseguradora = t1.IdAseguradora,
	@CodSeguro = t2.codigo
	FROM SEG_Aseguradora t1
	INNER JOIN SEG_Seguro t2 ON t1.IdAseguradora = t2.IdAseguradora
	INNER JOIN SEG_Plan t3 ON t2.idSeguro  = t3.idSeguro
	WHERE t3.idPlan = @idPlan		
				
	SELECT @NroPolizaGenerada =  RTRIM(CAST(@CodSeguro AS VARCHAR(MAX)))  +    
			RTRIM(CAST(@identificacion AS VARCHAR(MAX))) +
			RTRIM(CAST(@siguienteConsecutivo AS VARCHAR(MAX))) 
				 
    
	IF (@NroPolizaGenerada = @Consecutivo)
	BEGIN 	
		UPDATE SEG_Aseguradora
		SET consecutivoActual = @siguienteConsecutivo
		WHERE IdAseguradora = @IdAseguradora
	END      	
END