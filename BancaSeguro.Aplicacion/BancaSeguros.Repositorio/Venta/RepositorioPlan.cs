
namespace BancaSeguros.Repositorio.Venta
{
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioPlan : IRepositorioPlan
    {

        #region Variables

        private Database dataBase;

        #endregion

        #region Constructor

        public RepositorioPlan(string nombreConexion)
        {
            this.dataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion


        #region Metodos Publicos

        public IEnumerable<Plan> ConsultarPlanesPorIdSeguro(int idSeguro)
        {
            List<Plan> listaPlanes = new List<Plan>();
            Mapeador mapeador = new Mapeador();
            Plan plan = new Plan();
            using (DbCommand dbCommand = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarPlanesPorIdSeguro))
            {
                dataBase.AddInParameter(dbCommand, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, idSeguro);
                using (IDataReader reader = dataBase.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        plan = mapeador.DataReaderAPlan(reader);
                        listaPlanes.Add(plan);
                    }
                }
            }
            return listaPlanes;
        }

        #endregion
    }
}
