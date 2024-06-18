using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace BancaSeguros.Repositorio
{
    public static class SingletonDatabase
    {
        #region Variables

        private static DatabaseProviderFactory factory;
        private static Database baseDatos;

        #endregion

        #region Metodos

        public static Database ObtenerDataBase(string nombreCadenaConexion)
        {
            if (baseDatos == null)
            {
                factory = new DatabaseProviderFactory();                
                baseDatos = factory.Create("CONEXION_BANCASEGURO");
            }
                
            return baseDatos;
        }

        #endregion
    }
}
