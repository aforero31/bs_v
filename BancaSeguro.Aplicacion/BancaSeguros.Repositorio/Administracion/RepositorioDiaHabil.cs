

namespace BancaSeguros.Repositorio.Administracion
{
    using System;
    using System.Data;
    using System.Data.Common;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System.Collections.Generic;

    public class RepositorioDiaHabil : IRepositorioDiaHabil
    {
        #region Variables

        /// <summary>
        /// The variable database
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 16/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Database dataBase;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioDiaHabil"/> class.
        /// </summary>
        /// <param name="nombreConexion">The name conection.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 16/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public RepositorioDiaHabil(string nombreConexion)
        {
            this.dataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Métodos Públicos

        public Resultado EliminarDiasHabilesApartirDeFecha(DateTime fecha)
        {
            Resultado resultado = new Resultado();

            DbCommand comandoBaseDatos = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_EliminarDiasHabilesApartirDeFecha);

            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.fecha, DbType.Date, fecha);

            this.dataBase.ExecuteNonQuery(comandoBaseDatos);

            return resultado;
        }

        public Resultado InsertarDiaHabil(DateTime fecha)
        {
            Resultado resultado = new Resultado();

            DbCommand comandoBaseDatos = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_InsertarDiaHabil);

            this.dataBase.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.fecha, DbType.Date, fecha);

            this.dataBase.ExecuteNonQuery(comandoBaseDatos);

            return resultado;
        }

        #endregion
    }
}
