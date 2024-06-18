/****************************************************************************************************************
NOMBRE DEL PROGRAMA: [PR_SEG_ConsultarAuditoria]
DESCRIPCION: Consulta Auditoria 
PARAMETROS DE ENTRADA:
	@tipo				tipo de actualizacion
    @nombreTabla		nombre de tabla
    @campoLlave			nombre de campo llave
    @valorLlave			valor campo llave
    @campo				nombre campo de tabla
    @valorAnterior		valor anterior campo
    @nuevoValor         valor nuevo campo
    @fechaInicial       fecha inicial
    @fechaFinal			fecha final
    @usuario			usuario
PARAMETROS DE SALIDA:
	No Aplica
RESULTADO:
	No aplica
CODIGOS DE ERROR:
	Se levantan las excepciones propias.
CODIGOS DE SATISFACCION:
	No aplica
---------------------------------------------------------------------------------------------------------------
REQUERIMIENTO: Banca Seguros Consultar Log 
AUTOR: Paulo Andrés Mora.
EMPRESA: UT - BAC
FECHA DE CREACIÓN: 2016-05-17
****************************************************************************************************************/
CREATE PROCEDURE [dbo].[PR_SEG_ConsultarAuditoria] 
	-- Add the parameters for the stored procedure here
	@tipo				CHAR(1) = NULL,
    @nombreTabla		VARCHAR(120) = NULL,
    @campoLlave			VARCHAR(1000) = NULL,
    @valorLlave			VARCHAR(1000) = NULL,
    @campo				VARCHAR(128) = NULL,
    @valorAnterior		VARCHAR(1000)= NULL,
    @nuevoValor         VARCHAR(1000)= NULL,
    @fechaInicial       datetime = NULL,
    @fechaFinal			datetime = NULL,
    @usuario			varchar(128) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [AuditID]
      ,[Type]
      ,[TableName]
      ,[PrimaryKeyField]
      ,[PrimaryKeyValue]
      ,[FieldName]
      ,[OldValue]
      ,[NewValue]
      ,[UpdateDate]
      ,[UserName]
  FROM SEG_Auditoria
  WHERE (Type = @tipo OR @tipo IS NULL)
  AND   (TableName = @nombreTabla OR @nombreTabla IS NULL)
  AND   (PrimaryKeyField = @campoLlave OR @campoLlave IS NULL)
  AND	(PrimaryKeyValue = @valorLlave OR @valorLlave IS NULL)
  AND   (FieldName = @campo OR @campo IS NULL)
  AND	(OldValue = @valorAnterior OR @valorAnterior IS NULL)
  AND	(NewValue = @nuevoValor OR @nuevoValor IS NULL)
  AND   (UpdateDate >= @fechaInicial OR  @fechaInicial IS NULL)
  AND   (UpdateDate < DATEADD(DAY,1,@fechaFinal) OR  @fechaFinal IS NULL)
  AND   (UserName = @usuario OR @usuario IS NULL)
  
END