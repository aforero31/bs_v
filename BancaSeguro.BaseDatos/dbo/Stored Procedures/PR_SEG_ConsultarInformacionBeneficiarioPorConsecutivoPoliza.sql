/*****************************************************************************************
CREACIÓN
REQUERIMIENTO:	SD1588485
AUTOR: Carlos Piza
EMPRESA: Unión temporal FS-BAC-2013
PROPOSITO: Consulta la informacion de los beneficiarios de una poliza - Sprint 2 / HU001.6
FECHA DE MODIFICACIÓN: 22/02/2016
----------------------------------------------------------------------------------------------------------------
MODIFICACIONES: XXXXXXXXXXXXXXX
REQUERIMIENTO: XXXXXXXXXXXXXXXXX
AUTOR: XXXXXXXXXXXXXXXX
EMPRESA: Unión temporal FS-BAC-2013
FECHA DE MODIFICACIÓN: XXXXXXXXXXXX
*****************************************************************************************/

CREATE PROCEDURE [dbo].[PR_SEG_ConsultarInformacionBeneficiarioPorConsecutivoPoliza]

(@Consecutivo VARCHAR(50))

AS

	/************DATOS DEL LOS BENEFICIARIOS DE LA POLIZA************/

	SELECT	 RTRIM(LTRIM(SEG_Beneficiario.nombres)) + ' ' + RTRIM(LTRIM(SEG_Beneficiario.apellidos)) AS NombreCompletoBeneficiario

			,RTRIM(LTRIM(SEG_Beneficiario.nombres)) AS NombreBeneficiario

			,RTRIM(LTRIM(SEG_Beneficiario.apellidos)) AS ApellidoBeneficiario

			,RTRIM(LTRIM(SEG_TipoIdentificacion.abreviatura)) +' '+ RTRIM(LTRIM(CONVERT(varchar(15), SEG_Beneficiario.identificacion))) AS TipoNumeroIdentificacionBeneficiario

			,SEG_TipoIdentificacion.abreviatura AS TipoIdentificacionAbreviaturaBeneficiario

			,SEG_Beneficiario.identificacion AS NumeroIdentificacionBeneficiario

			,CONVERT(varchar(5), SEG_Beneficiario.porcentaje) AS PorcentajeParticipacion

	FROM SEG_Venta

	INNER JOIN SEG_Beneficiario

	ON SEG_Venta.idVenta = SEG_Beneficiario.idVenta

	INNER JOIN SEG_TipoIdentificacion

	ON SEG_TipoIdentificacion.idTipoIdentificacion = SEG_Beneficiario.idTipoIdentificacion

	WHERE SEG_Venta.consecutivo = @Consecutivo
