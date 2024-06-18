
namespace BancaSeguros.Repositorio.Venta
{
    using BancaSeguros.Entidades;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Linq;
    public class RepositorioLogCobis : IRepositorioLogCobis
    {
        private Database dataBase;

        public RepositorioLogCobis(string nombreConexion)
        {
            this.dataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        /// <summary>
        /// Insertar datos en la tabla de LogCobis
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 05/05/2016
        /// ModifiedBy:   
        /// ModifiedDate: 
        /// PropositoCambio: 
        /// ModifiedBy:  
        /// ModifiedDate: 
        /// </remarks>
        /// 
        public Resultado GuardarDatosLogEnTablaLogCobis(LogCobis logCobis)
        {
            Resultado resultado = new Resultado();
            try
            {
                DbCommand dataBaseCommand = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_InsertarLogCobis);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.xmlRequest, DbType.String, logCobis.XmlRequest);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.horaRequest, DbType.String, logCobis.HoraRequest);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.xmlResponse, DbType.String, logCobis.XmlResponse);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.horaResponse, DbType.String, logCobis.HoraResponse);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Login, DbType.String, logCobis.Usuario);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.tipoTransaccion, DbType.String, logCobis.TipoTransaccion);
                this.dataBase.ExecuteNonQuery(dataBaseCommand);
                resultado.Error = false;
            }
            catch(Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ex.Message;
            }
            return resultado;
        }

        /// <summary>
        /// Gets the consecutive to cobis.
        /// </summary>
        /// <returns>Value of consecutive</returns>
        public Int64 ObtenerConsecutivoCobis()
        {
            Int64 consecutivo = 0;

            using (DbCommand comandoBaseDatos = this.dataBase.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ObtenerConsecutivoCobis))
            {
                using (IDataReader reader = this.dataBase.ExecuteReader(comandoBaseDatos))
                {
                    while (reader.Read())
                    {
                        consecutivo = reader.IsDBNull(reader.GetOrdinal(Campos.siguienteConsecutivo)) ? 0 : (Int64)reader[Campos.siguienteConsecutivo];
                    }
                }
            }

            return consecutivo;
        }
    }
}
