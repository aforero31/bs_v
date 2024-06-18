//-----------------------------------------------------------------------
// <copyright file="RepositorioVariableVenta.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Repositorio.Administracion
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Repositorio.Configuraciones;
    using BancaSeguros.Repositorio.Venta;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// sale variable repository class
    /// </summary>
    /// <seealso cref="BancaSeguros.Repositorio.Administracion.IRepositorioVariableVenta" />
    public class RepositorioVariableVenta : IRepositorioVariableVenta
    {
        #region Variables

        /// <summary>
        /// Database variable
        /// </summary>
        private Database db;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioVariableVenta"/> class.
        /// </summary>
        /// <param name="nombreConexion">The connection name.</param>
        public RepositorioVariableVenta(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Inserts the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Result object</returns>
        public Resultado InsertarVariableVenta(VariableVenta variable)
        {
            Resultado resultado = new Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_InsertarVariableVenta))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idVenta, DbType.Int32, variable.IdVenta);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idVariableProducto, DbType.Int32, variable.IdVariableProducto);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Valor, DbType.String, variable.Valor);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, variable.Login);

                if (this.db.ExecuteNonQuery(comandoBaseDatos) == 1)
                {
                    resultado.Error = true;
                }
                else
                {
                    resultado.Error = false;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Search the product variables.
        /// </summary>
        /// <param name="variable">The variable to search.</param>
        /// <returns>List of variables</returns>
        public IList<VariableVenta> ConsultarVariablesVenta(VariableVenta variable)
        {
            List<VariableVenta> resultados = new List<VariableVenta>();

            VariableVenta resultadoVariableVenta = null;
            BancaSeguros.Repositorio.Venta.Mapeador mapeador = new BancaSeguros.Repositorio.Venta.Mapeador();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarVariableVenta))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idVariableVenta, DbType.Int32, variable.IdVariableVenta != 0 ? variable.IdVariableVenta : (int?)null);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idVenta, DbType.Int32, variable.IdVenta != 0 ? variable.IdVenta : (int?)null);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idVariableProducto, DbType.Int32, variable.IdVariableProducto != 0 ? variable.IdVariableProducto : (int?)null);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Valor, DbType.Int32, variable.Valor);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Consecutivo, DbType.Int32, variable.ConsecutivoPoliza);
                using (IDataReader reader = this.db.ExecuteReader(comandoBaseDatos))
                {
                    while (reader.Read())
                    {
                        resultados.Add(resultadoVariableVenta = mapeador.DataReaderAVariableVenta(reader));
                    }
                }
            }

            return resultados;
        }

        #endregion
    }
}
