//-----------------------------------------------------------------------
// <copyright file="RepositorioVariableProducto.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Repositorio.Administracion
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// Product variable repository class
    /// </summary>
    /// <seealso cref="BancaSeguros.Repositorio.Administracion.IRepositorioVariableProducto" />
    public class RepositorioVariableProducto : IRepositorioVariableProducto
    {
        #region Variables

        /// <summary>
        /// Database variable
        /// </summary>
        private Database db;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioVariableProducto"/> class.
        /// </summary>
        /// <param name="nombreConexion">The connection name.</param>
        public RepositorioVariableProducto(string nombreConexion)
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
        public Resultado InsertarVariableProducto(VariableProducto variable)
        {
            Resultado resultado = new Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_InsertarVariableProducto))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, variable.IdSeguro);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nombreCampo, DbType.String, variable.NombreCampo);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.IdTipoDato, DbType.Int32, variable.IdTipoDato);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.longitud, DbType.Int32, variable.Longitud);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMaestra, DbType.Int32, variable.IdMaestra);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.orden, DbType.Int32, variable.Orden);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.estado, DbType.Boolean, variable.Estado.HasValue ? variable.Estado.Value : false);
                this.db.AddOutParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.existe, DbType.Int32, 1);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, variable.Login);

                this.db.ExecuteNonQuery(comandoBaseDatos);

                int existe = (int)this.db.GetParameterValue(comandoBaseDatos, ParametrosEntradaProcedimientos.existe);
                if (existe == 1)
                {
                    resultado.Error = true;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Update the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Result object</returns>
        public Resultado ActualizarVariableProducto(VariableProducto variable)
        {
            Resultado resultado = new Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizarVariableProducto))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idVariableProducto, DbType.Int32, variable.IdVariableProducto);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nombreCampo, DbType.String, variable.NombreCampo);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.estado, DbType.Boolean, variable.Estado.HasValue ? variable.Estado.Value : false);
                this.db.AddOutParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.existe, DbType.Int32, 1);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, variable.Login);

                this.db.ExecuteNonQuery(comandoBaseDatos);

                int existe = (int)this.db.GetParameterValue(comandoBaseDatos, ParametrosEntradaProcedimientos.existe);
                if (existe == 1)
                {
                    resultado.Error = true;
                }
            }

            return resultado;
        }

        /// <summary>
        /// Search the product variables.
        /// </summary>
        /// <param name="variable">The variable to search.</param>
        /// <returns>List of variables</returns>
        public IList<VariableProducto> ConsultarVariablesProducto(VariableProducto variable)
        {
            List<VariableProducto> resultados = new List<VariableProducto>();

            VariableProducto resultadoVariableProducto = null;
            Mapeador mapeador = new Mapeador();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarVariableProducto))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idVariableProducto, DbType.Int32, variable.IdVariableProducto != 0 ? variable.IdVariableProducto : (int?)null);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, variable.IdSeguro != 0 ? variable.IdSeguro : (int?)null);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nombreCampo, DbType.String, variable.NombreCampo);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.IdTipoDato, DbType.Int32, variable.IdTipoDato != 0 ? variable.IdTipoDato : (int?)null);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.longitud, DbType.Int32, variable.Longitud != 0 ? variable.Longitud : (int?)null);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMaestra, DbType.Int32, variable.IdMaestra != 0 ? variable.IdMaestra : (int?)null);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.orden, DbType.Int32, variable.Orden != 0 ? variable.Orden: (int?)null);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.estado, DbType.Boolean, variable.Estado.HasValue ? variable.Estado.Value : (bool?)null);
                using (IDataReader reader = this.db.ExecuteReader(comandoBaseDatos))
                {
                    while (reader.Read())
                    {
                        resultados.Add(resultadoVariableProducto = mapeador.DataReaderAVariableProducto(reader));
                    }
                }
            }

            return resultados;
        }

        /// <summary>
        /// Deletes the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Result object</returns>
        public Resultado EliminarVariableProducto(VariableProducto variable)
        {
            Resultado resultado = new Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_EliminarVariableProducto))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idVariableProducto, DbType.Int32, variable.IdVariableProducto);
                this.db.AddOutParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.existe, DbType.Int32, 1);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, variable.Login);

                this.db.ExecuteNonQuery(comandoBaseDatos);

                int existe = (int)this.db.GetParameterValue(comandoBaseDatos, ParametrosEntradaProcedimientos.existe);
                if (existe == 1)
                {
                    resultado.Error = true;
                }
            }

            return resultado;
        }

        #endregion
    }
}
