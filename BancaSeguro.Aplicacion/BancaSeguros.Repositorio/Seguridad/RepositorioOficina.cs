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
using BancaSeguros.Repositorio.Configuraciones;

namespace BancaSeguros.Repositorio.Seguridad
{
    public class RepositorioOficina : BancaSeguros.Repositorio.Seguridad.IRepositorioOficina
    {
        #region Variables

        private Database db;

        #endregion 

        #region Constructor

        public RepositorioOficina(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        public Oficina ConsultarOficinaPorCodigo(int idOficina)
        {
            Oficina oficina = new Oficina();
            Mapeador mapeador = new Mapeador();

            DbCommand dataBaseCommand = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarOficinaPorCodigo);

            this.db.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idOficina, DbType.Int32, idOficina);

            using (IDataReader reader = db.ExecuteReader(dataBaseCommand))
            {
                while (reader.Read())
                {
                    oficina = mapeador.DataReaderAOficina(reader);
                }
            }
            return oficina;
        }

        #endregion
    }
}
