
CREATE PROCEDURE [dbo].[PR_SEG_BuscarPolizasVigentes]  
AS  
/*-------------------------------------------------------------------------  
REQUERIMIENTO: HU004.1- Generar cobros días hábiles sin recobros.  
AUTOR: Jetlhen Yeny Roa Castañeda  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE CREACIÓN: 24/02/2016  
OBJETIVO: Este procedimiento:  
   - Obtiene la fecha ultimo periodo cobrado  
   - Obtiene los meses de la periodicidad por póliza  
   - Suma los meses de la periodicidad al último periodo cobrado  
   - Compara la fecha actual con el siguiente periodo a cobrar y traer las anteriores o iguales  
   - La póliza debe estar vigente  
   Campos a retornar  
   CampoSecuencia  
   - IdVenta  
   - Prima (Con el Ipc calculado)  
   - fecha de cobro  
   - cta_banco_origen  
    - producto_origen  
   - IdOficina  
   - Consecutivo (venta)  
   - CodigoConvenio (por definir)  
   - Insertar registros en la tabla detalle pagos con el tipo de cobro: "COBRO"  
NOTAS:  
- Se deben devolver los campos con el formato calculado que se definió para el archivo.  
- Se deben devolver los campos default del archivo.  
- OJO se debe tener en cuenta los pagos de los días 31 del mes pues no en todos los casos el mes siguiente tiene 31 días.  
RESULTADO: Genera la tabla de detalle pagos y SEG_ArchivoCobro (archivo de cobro)  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Se le indica que si la tabla [SEG_FechaEjecucionETLCobro] no tiene dato le dejé la fecha de ayer como medida  
    preventiva por si se prueba sólo este SP, pero realmente en la ETL la ejecución de este SP depende  
    si en el SP: PR_SEG_EvaluarEjecucionETL el mensaje es 'Si'  
REQUERIMIENTO: HU004.1- Generar cobros días hábiles sin recobros.  
AUTOR: Jetlhen Yeny Roa Castañeda  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 25/02/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Se observo que estaba cobrando las Polizas el mismo día que las vende  
REQUERIMIENTO: HU004.1- Generar cobros días hábiles sin recobros.  
AUTOR: Wilver Zaldua - Jetlhen Yeny Roa Castañeda  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 26/02/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Se incluyen los recobros pendientes para que se vayan en el archivo de cobro  
REQUERIMIENTO: HU004.1- Generar cobros días hábiles sin recobros.  
AUTOR: Jetlhen Yeny Roa Castañeda  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 27/02/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Se toma los meses de periodicidad de la tabla SEG_Venta.  
REQUERIMIENTO: SD1588485  
AUTOR: Iraida Montoya  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 06/07/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Ajuste en el formato de la fecha.  
REQUERIMIENTO: SD1588485  
AUTOR: Iraida Montoya  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 12/07/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Se incluyen las constantes del archivo de cobro como variables, como la variable @DiaEjecucion depende de la fecha de ejecución y   
    si no tiene dato esta última variable se inicializa @DiaEjecucion con el número de día que tiene la fecha de ayer. El valor del IPC se  
    deja como variable, codigoEstadoCobro se deja como variable inicializada en 3  
REQUERIMIENTO: HU004.1- Generar cobros días hábiles sin recobros.  
AUTOR: Jetlhen Yeny Roa Castañeda  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 28/02/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Según la reunión con el banco en el archivo de cobro se deben presentar primero los recobros, por lo tanto la modificación del día  
    2016-02-27 se pone después del while de los días de cobro.  
REQUERIMIENTO: HU004.1- Generar cobros días hábiles sin recobros.  
AUTOR: Jetlhen Yeny Roa Castañeda  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 07/03/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Se establece que el valor de la póliza debe ser tomado de venta y no del plan pues de esta última el usuario puede estarlo modificando  
    de acuerdo a las necesidades del negocio  
REQUERIMIENTO: HU004.1- Generar cobros días hábiles sin recobros.  
AUTOR: Jetlhen Yeny Roa Castañeda  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 09/03/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Se agrega cursor para manejo de IPC  
REQUERIMIENTO: HU004.1- Generar cobros días hábiles sin recobros.  
AUTOR: Jetlhen Yeny Roa Castañeda  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 17/03/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Se crean los pasos para manejo transaccional  
REQUERIMIENTO: HU004.1- Generar cobros días hábiles sin recobros.  
AUTOR: Jetlhen Yeny Roa Castañeda  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 20/03/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Se reemplaza el cursor que maneja el IPC por las tablas temporales: @PolizasMensuales, se implementa manejo de transacciones y se  
    guarda el log del incremento dbo.SEG_LogIncrementoIPC  
REQUERIMIENTO: HU004.1- Generar cobros días hábiles sin recobros.  
AUTOR: Jetlhen Yeny Roa Castañeda  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 22/03/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Se establece que el valor de la póliza debe ir redondeado  
REQUERIMIENTO: HU004.1- Generar cobros días hábiles sin recobros.  
AUTOR: Jetlhen Yeny Roa Castañeda  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 23/03/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Se inserta información en el log del SP por medio del llamado al SP: PR_SEG_LogControlErrores y se incluyen las siguientes validaciones   
    al while de días de cobro:  
    - CONVERT(DATE, @FechaUltimaEjecucion )!= CONVERT(DATE, GETDATE())  
    - CONVERT(DATE, @FechaUltimaEjecucion) < CONVERT(DATE, GETDATE())  
REQUERIMIENTO: HU004.1- Generar cobros días hábiles sin recobros.  
AUTOR: Jetlhen Yeny Roa Castañeda  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 26/03/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Se agrega la condición que debe hacer incremento de IPC y mandar a cobro lo que recobro deja como "pendiente por cobrar"  
REQUERIMIENTO: HU004.1- Generar cobros días hábiles sin recobros.  
AUTOR: Wilver Zaldua - Jetlhen Yeny Roa Castañeda   
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 08/04/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Se deja este procedimiento sólo para cobro  
REQUERIMIENTO: HU004.1- Generar cobros días hábiles sin recobros.  
AUTOR: Jetlhen Yeny Roa Castañeda   
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 27/04/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: No se dejan los campos quemados desde @tipoNovedad hasta @posicion y @codigoEstadoCobro, se hace que tome el dato desde la tabla de parametros  
REQUERIMIENTO: HU004.1- Generar cobros días hábiles sin recobros.Además se quitan los campos nombreArchivo y fechaProcesoArchivo  
AUTOR: Jetlhen Yeny Roa Castañeda   
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 10/05/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: - Ajustar el nombre de la nueva tabla para el manejo de la ejecución de la ETL SEG_FechaEjecucionETL.  
    - Se realizo un CAST a la fecha de creación de la poliza para que en los filtros no tome las horas sino  
    solo la fecha.  
REQUERIMIENTO: HU004.1- Generar cobros días hábiles sin recobros.  
AUTOR: Iraida Montoya  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 01/06/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Se toma los meses de periodicidad de la tabla SEG_Venta y formato de fechas.  
REQUERIMIENTO: SD1588485  
AUTOR: Iraida Montoya  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 08/07/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Ajuste en el formato de la fecha.  
REQUERIMIENTO: SD1588485  
AUTOR: Iraida Montoya  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 12/07/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACIONES: Se elimina el borrar y crear tabla de SEG_ArchivoCobro  
REQUERIMIENTO: SD1588485  
AUTOR: Iraida Montoya  
EMPRESA: Unión temporal FS-BAC-2013.  
FECHA DE MODIFICACIÓN: 01/08/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACION: Se cambia el parámetro de envío a la función FN_SEG_GeneraMontoEfectivo, del id de la póliza, al valor del cobro  
REQUERIMIENTO: SD1588485  
AUTOR: Nelson Hernando Pardo Peláez  
EMPRESA: Unión temporal FS-BAC-2013  
FECHA DE MODIFICACIÓN: 21/10/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACION: Se añade parametro en ordery by que genera el secuencial  
REQUERIMIENTO: SD1588485  
AUTOR: iraida Montoya  
EMPRESA: Unión temporal FS-BAC-2013  
FECHA DE MODIFICACIÓN: 28/11/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACION: Se modifica para separar consulta mensuales de Anauales  
REQUERIMIENTO: SD1588485  
AUTOR: iraida Montoya  
EMPRESA: Unión temporal FS-BAC-2013  
FECHA DE MODIFICACIÓN: 21/12/2016  
----------------------------------------------------------------------------------------------------------------------------------------------------  
MODIFICACION: Se actualiza la forma en que se calcula los dias a cobrar, para tener meses  
REQUERIMIENTO: SD1588485  
AUTOR: Enrique Rivera  
EMPRESA: Unión temporal FS-BAC-2013  
FECHA DE MODIFICACIÓN: 26/12/2016  
-------------------------------------------------------------------------  
MODIFICACION  
REQUERIMIENTO: SD3260346  
PROPOSITO: Se agrega condicional en el filtro de recobros para que valide que la poliza se encuentre activa.  
AUTOR: Enrique Rivera  
EMPRESA: Unión temporal FS-BAC-2013  
FECHA DE MODIFICACIÓN: 27/11/2017  
-------------------------------------------------------------------------  
MODIFICACION  
REQUERIMIENTO: Contigencia exclusión de cobros a cuentas de abono ingreso solidario   
PROPOSITO: Exclusion de polizas relacionadas a las cuentas eximidas
AUTOR: Paulo Mora  
EMPRESA: IG SERVICES S.A.S
FECHA DE MODIFICACIÓN: 17/04/2020  
-------------------------------------------------------------------------  
MODIFICACION  
REQUERIMIENTO: SD4289524   
PROPOSITO: Exclusion de polizas relacionadas a las cuentas eximidas
AUTOR: Paulo Mora  
EMPRESA: IG SERVICES S.A.S
FECHA DE MODIFICACIÓN: 17/04/2020  
-------------------------------------------------------------------------  
MODIFICACION  
REQUERIMIENTO: SD4509595   
PROPOSITO: Se elimina exclusion de cuentas eximidas y se cobros cuotas del periodo
		   de ingreso solidario
AUTOR: Marlon  Arcon  
EMPRESA: IG SERVICES S.A.S
FECHA DE MODIFICACIÓN: 09/03/2021  
-------------------------------------------------------------------------  
MODIFICACION  
REQUERIMIENTO: SD5033294    
PROPOSITO: Se corrige seleccion de cobros de ingreso solidario adicionando cruce
		   por consecutivo de poliza
AUTOR: Paulo Mora  
EMPRESA: IG SERVICES S.A.S
FECHA DE MODIFICACIÓN: 01/02/2022  
----------------------------------------------------------------------------------------------------------------------------------------------------*/  
  
BEGIN  
 SET NOCOUNT ON;  
 DECLARE @DiasCobro TABLE(NumeroDia INT,MesDia VARCHAR(5))  
 DECLARE @Siguiente INT = 1  
 DECLARE @FechaUltimaEjecucion DATETIME = (SELECT FechaEjecucionETL FROM [dbo].[SEG_FechaEjecucionETL] WHERE Prefijo = 'COB' )  
 DECLARE @FechaHoy DATETIME =(SELECT GETDATE())  
 DECLARE @tipoNovedad VARCHAR(1)=(SELECT valor FROM seg_parametro WHERE idParametro=7)  
 DECLARE @tipoTransaccion INT=(SELECT valor FROM seg_parametro WHERE idParametro=8)  
 DECLARE @usuario VARCHAR(4)=(SELECT valor FROM seg_parametro WHERE idParametro=9)  
 DECLARE @ctaBancoDestino VARCHAR(1)=(SELECT valor FROM seg_parametro WHERE idParametro=10)  
 DECLARE @productoDestino VARCHAR(1)=(SELECT valor FROM seg_parametro WHERE idParametro=11)  
 DECLARE @nroControl VARCHAR(1)=(SELECT valor FROM seg_parametro WHERE idParametro=12)  
 DECLARE @correccion VARCHAR(1)=(SELECT valor FROM seg_parametro WHERE idParametro=13)  
 DECLARE @moneda INT=(SELECT valor FROM seg_parametro WHERE idParametro=14)  
 DECLARE @cheque INT=(SELECT valor FROM seg_parametro WHERE idParametro=15)  
 DECLARE @desprendible VARCHAR (1) = (SELECT valor FROM seg_parametro WHERE idParametro=16)  
 DECLARE @tipoCheque VARCHAR(1)=(SELECT valor FROM seg_parametro WHERE idParametro=17)  
 DECLARE @banco VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=18)  
 DECLARE @cuentaGirada VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=19)  
 DECLARE @endoso VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=20)  
 DECLARE @montoLocal VARCHAR (18)=(SELECT valor FROM seg_parametro WHERE idParametro=21)  
 DECLARE @montoPropio VARCHAR (18)=(SELECT valor FROM seg_parametro WHERE idParametro=22)  
 DECLARE @montoRemCobro VARCHAR (18)=(SELECT valor FROM seg_parametro WHERE idParametro=23)  
 DECLARE @montoRemNeg VARCHAR (18)=(SELECT valor FROM seg_parametro WHERE idParametro=24)  
 DECLARE @montoIVA VARCHAR (18)=(SELECT valor FROM seg_parametro WHERE idParametro=25)  
 DECLARE @montoComision VARCHAR (18)=(SELECT valor FROM seg_parametro WHERE idParametro=26)  
 DECLARE @referencia2 INT=(SELECT valor FROM seg_parametro WHERE idParametro=27)  
 DECLARE @referencia3 INT=(SELECT valor FROM seg_parametro WHERE idParametro=28)  
 DECLARE @referencia4 INT=(SELECT valor FROM seg_parametro WHERE idParametro=29)  
 DECLARE @referencia5 INT=(SELECT valor FROM seg_parametro WHERE idParametro=30)  
 DECLARE @causa VARCHAR (3)=(SELECT valor FROM seg_parametro WHERE idParametro=31)  
 DECLARE @causal VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=32)  
 DECLARE @depto VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=33)  
 DECLARE @comentario VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=34)  
 DECLARE @tarjetaCred VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=35)  
 DECLARE @establecimiento VARCHAR (10)=(SELECT valor FROM seg_parametro WHERE idParametro=36)  
 DECLARE @tsFechaEfectiva VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=37)  
 DECLARE @identificacion VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=38)  
 DECLARE @claseImpuesto VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=39)  
 DECLARE @tipoVarios VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=40)  
 DECLARE @tipoPersona VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=41)  
 DECLARE @sticker VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=42)  
 DECLARE @administracion VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=43)  
 DECLARE @formaPago VARCHAR (3)=(SELECT valor FROM seg_parametro WHERE idParametro=44)  
 DECLARE @institucion VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=45)  
 DECLARE @cajaOrigen VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=46)  
 DECLARE @cajaDestino VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=47)  
 DECLARE @usuarioOrigen VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=48)  
 DECLARE @numControlRech VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=49)  
 DECLARE @codError VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=50)  
 DECLARE @descError VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=51)  
 DECLARE @posicion VARCHAR (1)=(SELECT valor FROM seg_parametro WHERE idParametro=52)  
 DECLARE @IPC DECIMAL(18,2) =(SELECT ((0*100)/100))  
 DECLARE @codigoEstadoCobro INT=(SELECT codigoEstadoCobro FROM seg_estadocobro WHERE descripcionEstadoCobro='Pendiente por cobro')  
 DECLARE @contadorIntentoCobro INT=(SELECT 0)  
 DECLARE @EsdiaHabil BIT=(SELECT 0)  
 DECLARE @DiaEjecucion INT = isnull(DATEPART(DAY,@FechaUltimaEjecucion),DATEPART(DAY,getdate()-1))--24  
 DECLARE @DiaEjecucionHoy INT = DATEPART(DAY,@FechaHoy)--25  
 DECLARE @estadoProceso CHAR(3) = 'PRO', @estadoCancelado CHAR(3) = 'CAN'  
 DECLARE @MesUltimaEjecucionETL INT = DATEPART(MONTH,@FechaUltimaEjecucion)  
 DECLARE @DiaEjecucionControl INT = @DiaEjecucion   
 DECLARE @MesUltimaEjecucionETLVarchar VARCHAR(2)   
 DECLARE @DiaEjecucionVarchar VARCHAR(2)
 /* INICIA TRANSACCION*/   
    BEGIN TRANSACTION   
 BEGIN TRY            
           DECLARE @PolizasVigentes TABLE -- Tabla temporal para almacenar las pólizas a realizar cobros  
     (  
    idVenta INT,  
    idPlan INT,  
    idOficina INT,  
    consecutivo VARCHAR (50),  
    fechaCreacion DATETIME,  
    valor DECIMAL (18,2),  
    numeroMesesPeriodicidad INT,  
    periodoCobro VARCHAR (10),  
    codigoConvenio INT,  
    productoOrigen INT,  
    numeroCuenta VARCHAR(50)  
   )  
  
   -- Cálculo de los días y meses de cobro  
   IF  CONVERT(DATE, @FechaUltimaEjecucion )!= CONVERT(DATE, GETDATE())  
   BEGIN  
      IF CONVERT(DATE, @FechaUltimaEjecucion) < CONVERT(DATE, GETDATE())  
       BEGIN  
         WHILE @Siguiente = 1  
         BEGIN     
           SET @DiaEjecucion += 1  
           IF @DiaEjecucion =32  
           BEGIN  
            SET @DiaEjecucion = 1  
           END    
  
            IF @DiaEjecucionControl > @DiaEjecucion AND ISDATE(  
                  CONVERT(VARCHAR,DATEPART(YEAR,GETDATE())+  
                  CONVERT(VARCHAR,@MesUltimaEjecucionETL)+  
                  CONVERT(VARCHAR,@DiaEjecucion))  
                  ) = 1  
            BEGIN         
              IF @MesUltimaEjecucionETL = 12  
              BEGIN   
               SET @MesUltimaEjecucionETL = 1  
               SET @DiaEjecucionControl = @DiaEjecucion  
              END          
		      ELSE   
			  BEGIN   
			   SET @MesUltimaEjecucionETL = @MesUltimaEjecucionETL + 1  
			   SET @DiaEjecucionControl = @DiaEjecucion  
			  END          
		    END             
      
		   IF LEN(@DiaEjecucion) = 1  
		   BEGIN           
			SELECT @DiaEjecucionVarchar = '0'+CONVERT(VARCHAR,@DiaEjecucion)  
		   END  
		  ELSE  
		   BEGIN  
			SELECT @DiaEjecucionVarchar = CONVERT(VARCHAR,@DiaEjecucion)  
		   END  
        
		  IF LEN(@MesUltimaEjecucionETL) = 1  
		   BEGIN           
			SELECT @MesUltimaEjecucionETLVarchar = '0'+CONVERT(VARCHAR,@MesUltimaEjecucionETL)  
		   END  
		  ELSE  
		   BEGIN  
			SELECT @MesUltimaEjecucionETLVarchar = CONVERT(VARCHAR,@MesUltimaEjecucionETL)  
		   END  

                            
       INSERT INTO @DiasCobro VALUES  
       (@DiaEjecucion,@MesUltimaEjecucionETLVarchar+'-'+@DiaEjecucionVarchar)  
       IF @DiaEjecucion = @DiaEjecucionHoy   
       BEGIN    
        SET @Siguiente = 0   
        END   
     END  
  
      
     --Busca en la tabla recobros pendientes  
     INSERT INTO @PolizasVigentes (idVenta,idPlan,idOficina,consecutivo,fechaCreacion,valor, numeroMesesPeriodicidad,periodoCobro,codigoConvenio,productoOrigen,numeroCuenta)  
     SELECT vent.idVenta,vent.codigoPlan, vent.idOficina,a.consecutivoPoliza, vent.fechaCreacion, a.valorRecaudo,   
       vent.numMesesPeriodicidad, a.fechaUltimoPeriodo,   
       a.codigoConvenio,  
       a.codigoProducto, a.numeroCuenta  
     FROM [dbo].[SEG_Recobro] a (NOLOCK)  
     INNER JOIN [dbo].[SEG_Venta] vent (NOLOCK) ON a.consecutivoPoliza=vent.consecutivo  
     WHERE a.activo=1  
     AND  vent.codigoEstadoPoliza IN (1,3)    
     
       
     --Busca las pólizas que se debe generar cobro  
     INSERT INTO @PolizasVigentes (idVenta,idPlan,idOficina,consecutivo,fechaCreacion,valor, numeroMesesPeriodicidad,periodoCobro,codigoConvenio,productoOrigen,numeroCuenta)  
     SELECT DISTINCT  
       vent.idVenta, vent.codigoPlan, vent.idOficina, vent.consecutivo, vent.fechaCreacion,vent.valorPoliza,  
       vent.numMesesPeriodicidad,  
       CONCAT(YEAR(GETDATE()),'-' ,RIGHT('0' + RTRIM(MONTH(GETDATE())), 2),'-' ,RIGHT('0' + RTRIM(DAY(GETDATE())), 2)) AS periodoCobro,  
       vent.codigoConvenio,   
       vent.codigoTipoCuenta AS productoOrigen,vent.numeroCuenta  
     FROM [dbo].[SEG_Venta] vent (NOLOCK)  
     WHERE codigoEstadoPoliza in (1,3)--Polizas vigentes y pendientes por cobrar (recobro las deja así)    
     AND DATEPART(DAY,vent.fechaCreacion) in (SELECT NumeroDia FROM @DiasCobro)            
     AND (@FechaHoy>=DATEADD(MONTH, vent.numMesesPeriodicidad, CAST(vent.fechaCreacion AS DATE)))  
     AND vent.numMesesPeriodicidad = 1  
     UNION ALL  
       SELECT DISTINCT  
       vent.idVenta, vent.codigoPlan, vent.idOficina, vent.consecutivo, vent.fechaCreacion,vent.valorPoliza,  
       vent.numMesesPeriodicidad,  
       CONCAT(YEAR(GETDATE()),'-' ,RIGHT('0' + RTRIM(MONTH(GETDATE())), 2),'-' ,RIGHT('0' + RTRIM(DAY(GETDATE())), 2)) AS periodoCobro,  
       vent.codigoConvenio,   
       vent.codigoTipoCuenta AS productoOrigen,vent.numeroCuenta  
     FROM [dbo].[SEG_Venta] vent (NOLOCK) 
     WHERE codigoEstadoPoliza in (1,3)--Polizas vigentes y pendientes por cobrar (recobro las deja así)        
     AND SUBSTRING(CONVERT(VARCHAR,fechaCreacion,110),0,6) in (SELECT MesDia FROM @DiasCobro)  
     AND (@FechaHoy>=DATEADD(MONTH, vent.numMesesPeriodicidad, CAST(vent.fechaCreacion AS DATE)))            
     AND vent.numMesesPeriodicidad = 12 
        
	 
     --Polizas cobro de ingreso  solidario
	 INSERT INTO @PolizasVigentes (idVenta,idPlan,idOficina,consecutivo,fechaCreacion,valor, numeroMesesPeriodicidad,periodoCobro,codigoConvenio,productoOrigen,numeroCuenta)  
     SELECT DISTINCT  
       vent.idVenta, vent.codigoPlan, vent.idOficina, vent.consecutivo, vent.fechaCreacion,co.valorRecaudo,  
       vent.numMesesPeriodicidad,  
       co.fechaPeriodoCobro AS periodoCobro,  
       co.codigoConvenio,   
       vent.codigoTipoCuenta AS productoOrigen,co.numeroCuenta  
     FROM [dbo].[SEG_CobrosPeriodoIngresoSolidario] co  
     INNER JOIN [dbo].[SEG_Venta] vent (NOLOCK)  
     ON co.codigoProducto = vent.codigoTipoCuenta AND co.numeroCuenta = vent.numeroCuenta   
	 AND vent.consecutivo = co.consecutivoPoliza
     WHERE vent.codigoEstadoPoliza in (1,3)--Polizas vigentes y pendientes por cobrar (recobro las deja así)    
     AND vent.numMesesPeriodicidad = 1  AND co.enviado=0 and co.fechadecobro <= @FechaUltimaEjecucion   
     UNION ALL  
       SELECT DISTINCT  
       vent.idVenta, vent.codigoPlan, vent.idOficina, vent.consecutivo, vent.fechaCreacion,co.valorRecaudo,  
       vent.numMesesPeriodicidad,  
       co.fechaPeriodoCobro AS periodoCobro,  
       co.codigoConvenio,   
       vent.codigoTipoCuenta AS productoOrigen,co.numeroCuenta
     FROM [dbo].[SEG_CobrosPeriodoIngresoSolidario] co  
     INNER JOIN [dbo].[SEG_Venta] vent (NOLOCK)
     ON co.codigoProducto = vent.codigoTipoCuenta AND co.numeroCuenta = vent.numeroCuenta   
	 AND vent.consecutivo = co.consecutivoPoliza	 
     WHERE vent.codigoEstadoPoliza in (1,3)--Polizas vigentes y pendientes por cobrar (recobro las deja así)        
     AND vent.numMesesPeriodicidad = 12 AND co.enviado=0 and co.fechadecobro <= @FechaUltimaEjecucion
     
	 
     TRUNCATE TABLE [dbo].[SEG_ArchivoCobro]  
     -- Se inserta en la tabla SEG_ArchivoCobro los cobros del día  
     INSERT INTO [dbo].[SEG_ArchivoCobro]  
     SELECT @tipoNovedad AS tipoNovedad,  
       @tipoTransaccion AS tipoTransaccion,        
       CONCAT(RIGHT('0' + RTRIM(YEAR(GETDATE())), 4),RIGHT('0' + RTRIM(MONTH(GETDATE())), 2),RIGHT('0' + RTRIM(DAY(GETDATE())), 2)) AS fecha,  
       @usuario AS usuario,  numeroCuenta AS ctaBancoOrigen,  productoOrigen,@ctaBancoDestino AS ctaBancoDestino,@productoDestino AS productoDestino,  
       idOficina AS oficina,   
       CONCAT(RIGHT('0' + RTRIM(YEAR(GETDATE())), 4),RIGHT('0' + RTRIM(MONTH(GETDATE())), 2),RIGHT('0' + RTRIM(DAY(GETDATE())), 2),' ',FORMAT(GETDATE(), 'hh:mm:sstt')) AS fechaHora,   
       @nroControl AS nroControl,   
       @correccion AS correccion,   
       @moneda AS moneda,   
       @cheque AS cheque,   
       @desprendible AS desprendible,  
       @tipoCheque AS tipoCheque,   
       @banco AS  banco,@cuentaGirada AS  cuentaGirada,   
       @endoso AS endoso,  
       montoEfectivo= dbo.FN_SEG_GeneraMontoEfectivo(valor) ,  
       @montoLocal AS montoLocal,  
       @montoPropio AS montoPropio,  
       @montoRemCobro AS montoRemCobro,  
       @montoRemNeg AS montoRemNeg,  
       @montoIVA AS montoIVA,  
       @montoComision AS montoComision,         
       consecutivo AS referencia1,  
       @referencia2 AS referencia2,  
       @referencia3 AS referencia3,  
       @referencia4 AS referencia4,  
       @referencia5 AS referencia5,  
       codigoconvenio AS convenio,  
       @causa AS causa,  
       @causal AS causal,  
       @depto AS depto,  
       @comentario AS comentario,  
       @tarjetaCred AS tarjetaCred,  
       @establecimiento AS establecimiento,  
       @tsFechaEfectiva AS tsFechaEfectiva,   
       @identificacion AS identificacion,  
       @claseImpuesto AS claseImpuesto,  
       @tipoVarios AS tipoVarios,  
       @tipoPersona AS tipoPersona,  
       @sticker AS sticker,  
       @administracion AS administracion,  
       @formaPago AS formaPago,  
       @institucion AS institucion,  
       @cajaOrigen AS cajaOrigen,  
       @cajaDestino AS cajaDestino,  
       @usuarioOrigen AS usuarioOrigen,  
       ROW_NUMBER() OVER(ORDER BY consecutivo,periodoCobro ASC) AS secuencial,  
       @numControlRech AS numControlRech,  
       @codError AS codError,  
       @descError AS descError,  
       @posicion AS posicion,  
       periodoCobro   
     FROM @PolizasVigentes ORDER BY consecutivo, periodoCobro ASC   
	 
	 
	 --Actualizar polizas de seguro que ya se cargaron
	 
	 UPDATE  co
	 SET co.enviado = 1
	 FROM [dbo].[SEG_CobrosPeriodoIngresoSolidario] co  
     INNER JOIN [dbo].[SEG_Venta] vent (NOLOCK)  
     ON co.codigoProducto = vent.codigoTipoCuenta AND co.numeroCuenta = vent.numeroCuenta     
     WHERE vent.codigoEstadoPoliza in (1,3)--Polizas vigentes y pendientes por cobrar (recobro las deja así)    
     AND vent.numMesesPeriodicidad = 1  AND co.enviado=0 and co.fechadecobro <= @FechaUltimaEjecucion
	 

	 UPDATE  co
	 SET co.enviado = 1	 
	 FROM [dbo].[SEG_CobrosPeriodoIngresoSolidario] co  
     INNER JOIN [dbo].[SEG_Venta] vent (NOLOCK)
     ON co.codigoProducto = vent.codigoTipoCuenta AND co.numeroCuenta = vent.numeroCuenta      
     WHERE vent.codigoEstadoPoliza in (1,3)--Polizas vigentes y pendientes por cobrar (recobro las deja así)        
     AND vent.numMesesPeriodicidad = 12 AND co.enviado=0 and co.fechadecobro <= @FechaUltimaEjecucion
        
    END   
   END  
	COMMIT TRANSACTION      
   RETURN 1  
  END TRY  
  BEGIN CATCH   
   ROLLBACK TRANSACTION
   UPDATE SEG_ProcesoETL SET estado = @estadoCancelado ,errorTarea = 'BD: '+ ERROR_MESSAGE() WHERE estado = @estadoProceso and prefijo = 'COB'  
   RETURN 0     
  END CATCH;   
 END