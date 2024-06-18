/**************************************************************************************************************
CREACIÓN
REQUERIMIENTO: SD1588485
AUTOR: Fernando Fernandez P.
EMPRESA:  Unión temporal FS-BAC-2013
OBJETIVO: Este procedimiento Construye el consecutivo de la poliza
FECHA DE CREACIÓN: 12/01/2016
---------------------------------------------------------------------------------------------------------------
MODIFICACIONES: Se trae consecutivos de tabla Aseguradora
REQUERIMIENTO: SD1588485-HU015-ParametrizarAseguradora
AUTOR: Paulo Mora
EMPRESA:  Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: 2016-04-18
***************************************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_ConstruirNroPoliza]
        (
		@idPlan    [int],
		@identificacion varchar(16)
        ) AS
	BEGIN

		DECLARE @siguienteConsecutivo int
		DECLARE @IdAseguradora int
		declare @CodSeguro int
		
		select @siguienteConsecutivo = t1.consecutivoActual + 1,
		@IdAseguradora = t1.IdAseguradora,
		@CodSeguro = t2.codigo
		FROM SEG_Aseguradora t1
		inner join SEG_Seguro t2 on t1.IdAseguradora = t2.IdAseguradora
		inner join Seg_Plan t3 on t2.idSeguro  = t3.idSeguro
		where t3.idPlan = @idPlan		
				
		update SEG_Aseguradora
		set consecutivoActual = @siguienteConsecutivo
		where IdAseguradora = @IdAseguradora
		
		SELECT  RTRIM(CAST(@CodSeguro AS VARCHAR(MAX)))  +    
				RTRIM(CAST(@identificacion AS VARCHAR(MAX))) +
				RTRIM(CAST(@siguienteConsecutivo AS VARCHAR(MAX))) 
				 AS NroPolizaGenerada
     
      	
	END