//-----------------------------------------------------------------------
// <copyright file="RepositorioParametro.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Administracion
{
    using System;
    using System.Data;
    using System.Data.Common;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// Repository parameter
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 18/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Repositorio.Administracion.IRepositorioParametro" />
    public class RepositorioParametro : IRepositorioParametro
    {
        #region Variables

        /// <summary>
        /// variable database
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Database db;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioParametro"/> class.
        /// </summary>
        /// <param name="nombreConexion">The name connection.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public RepositorioParametro(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Save the parameter.
        /// </summary>
        /// <param name="parametro">The parameter.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GuardarParametro(Parametro parametro)
        {
            Resultado resultado = new Resultado();

            DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_GuardarParametro);

            this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.IdTipoDato, DbType.Int32, parametro.IdTipoDato);
            this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Descripcion, DbType.String, parametro.Descripcion);
            this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Valor, DbType.String, parametro.Valor);
            this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, parametro.Activo);
            this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, parametro.Login);

            using (IDataReader reader = this.db.ExecuteReader(comandoBaseDatos))
            {
                if (reader.Read())
                {
                    resultado.Error = false;
                }
                else
                {
                    resultado.Error = true;
                }
            }
            return resultado;
        }

        /// <summary>
        /// Update the parameter of identifier.
        /// </summary>
        /// <param name="parametro">The parameter.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizaParametroPorId(Parametro parametro)
        {
            Resultado resultado = new Resultado();

            DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizaParametroPorId);

            this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.IdParametro, DbType.Int32, parametro.IdParametro);
            this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.IdTipoDato, DbType.Int32, parametro.IdTipoDato);
            this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Descripcion, DbType.String, parametro.Descripcion);
            this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Valor, DbType.String, parametro.Valor);
            this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, parametro.Activo);
            this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, parametro.Login);

            if (this.db.ExecuteNonQuery(comandoBaseDatos) == 1)
            {
                resultado.Error = true;
            }
            else
            {
                resultado.Error = false;
            }
            return resultado;
        }

        #endregion
    }
}
