using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using BAC.EntidadesSeguridad;
using BancaSeguros.Entidades.Catalogo;

namespace BancaSeguros.Repositorio.Catalogo
{
    class RepositorioCatalogo : BancaSeguros.Repositorio.Catalogo.IRepositorioCatalogo
    {
        #region Variables

        private Database db;

        #endregion

        #region Constructor

        public RepositorioCatalogo(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        public List<TipoIdentificacion> ConsultarTipoDeIdentificacion()
        {
            string nombreProcedimiento = Procedimientos.ConsultarTipoIdentificacion;

            List<TipoIdentificacion> listaTipoIdentificacion = new List<TipoIdentificacion>();
            Mapeador mapeador = new Mapeador();
            TipoIdentificacion tipoIdentificacion;
            using (DbCommand cmd = db.GetStoredProcCommand(nombreProcedimiento))
            {
                using (IDataReader reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        tipoIdentificacion = mapeador.DataReaderATipoIdentificacion(reader);
                        listaTipoIdentificacion.Add(tipoIdentificacion);
                    }
                }
            }
            return listaTipoIdentificacion;
        }

        #endregion



    }
}
