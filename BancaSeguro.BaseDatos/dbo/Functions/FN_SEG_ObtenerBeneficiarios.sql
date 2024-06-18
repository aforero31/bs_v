
CREATE FUNCTION [dbo].[FN_SEG_ObtenerBeneficiarios] (@idVenta INT,@columnasBeneficiarios VARCHAR(500),@columnasVacias VARCHAR(500),@separador CHAR(1),@cantidadBeneficiarios INT)
RETURNS VARCHAR(5000)
AS
/***************************************************************************************************************************************************
NOMBRE DEL PROGRAMA: [FN_SEG_ObtenerBeneficiarios]
DESCRIPCION: Retorna la información de los beneficiarios de una póliza
REQUERIMIENTO: SD1588485
AUTOR: Iraida Montoya
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE CREACIÓN: 14/07/2016
----------------------------------------------------------------------------------------------------------------------------------------------------
MODIFICACIONES: 
REQUERIMIENTO: 
AUTOR: 
EMPRESA: Unión temporal FS-BAC-2013.
FECHA DE MODIFICACIÓN:
**************************************************************************************************************/
BEGIN 
	DECLARE @cantidadRegistrosExistentes INT = 0, @infoBeneficiarios VARCHAR(MAX) = ''		
	SELECT @cantidadRegistrosExistentes = count(id) FROM VW_SEG_InformacionBeneficiario where [idVenta] = @idVenta

	DECLARE @BeneficiariosTabla TABLE( nombreColumna VARCHAR(100)
								  ,valor			 VARCHAR(100)
								  ,idVenta			 INT
								  ,id				 INT
								  ,posicion			 INT )

	INSERT INTO @BeneficiariosTabla
	SELECT nombreColumna, valor, idVenta, id, posicion
	FROM (SELECT [TIPO_IDENTIFICACION_BENEFICIARIO] as valor,1 as 'posicion'  ,'TIPO_IDENTIFICACION_BENEFICIARIO' as nombreColumna, idVenta as idVenta, id 
			  FROM VW_SEG_InformacionBeneficiario
			UNION
			SELECT [NOMBRE_IDENTIFICACION_BENEFICIARIO] as valor,2 as 'posicion'  ,'NOMBRE_IDENTIFICACION_BENEFICIARIO' as nombreColumna, idVenta as idVenta,id
			  FROM VW_SEG_InformacionBeneficiario
				UNION
			SELECT [IDENTIFICACION_BENEFICIARIO] as valor,3 as 'posicion'  ,'IDENTIFICACION_BENEFICIARIO' as nombreColumna, idVenta as idVenta,id
			  FROM VW_SEG_InformacionBeneficiario
				UNION
			SELECT [NOMBRES_BENEFICIARIO] as valor,4 as 'posicion'  ,'NOMBRES_BENEFICIARIO' as nombreColumna, idVenta as idVenta,id
			  FROM VW_SEG_InformacionBeneficiario
				UNION
			SELECT APELLIDOS_BENEFICIARIO as valor,5 as 'posicion'  ,'APELLIDOS_BENEFICIARIO' as nombreColumna, idVenta as idVenta,id
			  FROM VW_SEG_InformacionBeneficiario
				UNION
			SELECT [PARENTESCO_BENEFICIARIO] as valor,6 as 'posicion'  ,'PARENTESCO_BENEFICIARIO' as nombreColumna, idVenta as idVenta,id
			  FROM VW_SEG_InformacionBeneficiario
				UNION
			SELECT [PARTICIPACION_BENEFICIARIO] as valor,7 as 'posicion'  ,'PARTICIPACION_BENEFICIARIO' as Type, idVenta as idVenta,id
			  FROM VW_SEG_InformacionBeneficiario
		   ) AS datos
		where idVenta = @idVenta
	  GROUP BY idVenta, id, posicion, nombreColumna,valor        
	  order by   posicion,id

	SELECT @infoBeneficiarios =  COALESCE(@infoBeneficiarios + valor + @separador ,'')
	FROM @BeneficiariosTabla 
	where nombreColumna in (@columnasBeneficiarios)
	order by idVenta, id, posicion 

	IF @cantidadBeneficiarios > @cantidadRegistrosExistentes
	BEGIN
		WHILE @cantidadBeneficiarios > @cantidadRegistrosExistentes
		BEGIN
			SET @infoBeneficiarios = @infoBeneficiarios + @columnasVacias + @separador	
			SET @cantidadRegistrosExistentes += 1
		END
	END

	IF LEN(@infoBeneficiarios) > 0
	SET @infoBeneficiarios = LEFT(@infoBeneficiarios,LEN(@infoBeneficiarios)-1)


RETURN @infoBeneficiarios
END