CREATE VIEW [dbo].[VW_SEG_InformacionBeneficiario]
AS
SELECT        ROW_NUMBER() OVER (ORDER BY ben.identificacion) AS id, RTRIM(LTRIM(tipIde.CodigoCardif)) AS TIPO_IDENTIFICACION_BENEFICIARIO, UPPER(RTRIM(LTRIM(tipIde.nombre))) 
AS NOMBRE_IDENTIFICACION_BENEFICIARIO, RTRIM(LTRIM(ben.identificacion)) AS IDENTIFICACION_BENEFICIARIO, UPPER(RTRIM(LTRIM(ben.nombres))) 
AS NOMBRES_BENEFICIARIO, UPPER(RTRIM(LTRIM(ben.apellidos))) AS APELLIDOS_BENEFICIARIO, UPPER(RTRIM(LTRIM(par.nombre))) AS PARENTESCO_BENEFICIARIO, 
RTRIM(LTRIM(CAST(ben.porcentaje AS VARCHAR(4)))) AS PARTICIPACION_BENEFICIARIO, ben.idVenta
FROM            dbo.SEG_Beneficiario AS ben INNER JOIN
                         dbo.SEG_TipoIdentificacion AS tipIde ON tipIde.idTipoIdentificacion = ben.idTipoIdentificacion INNER JOIN
                         dbo.SEG_Parentesco AS par ON par.idParentesco = ben.idParentesco