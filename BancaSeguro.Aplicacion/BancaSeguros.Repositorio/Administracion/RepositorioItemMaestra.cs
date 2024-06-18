//-----------------------------------------------------------------------
// <copyright file="RepositorioItemMaestra.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Repositorio.Administracion
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// Item Master repository
    /// </summary>
    /// <seealso cref="BancaSeguros.Repositorio.Administracion.IRepositorioItemMaestra" />
    public class RepositorioItemMaestra : IRepositorioItemMaestra
    {
        #region Variables

        /// <summary>
        /// Database variable
        /// </summary>
        private Database db;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioItemMaestra"/> class.
        /// </summary>
        /// <param name="nombreConexion">The connection name.</param>
        public RepositorioItemMaestra(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Inserts the master item.
        /// </summary>
        /// <param name="itemMaestra">The master item.</param>
        /// <returns>Result object</returns>
        public Resultado InsertarItemMaestra(ItemMaestra itemMaestra)
        {
            Resultado resultado = new Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_InsertarItemMaestra))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMaestra, DbType.Int32, itemMaestra.IdMaestra);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Codigo, DbType.String, itemMaestra.Codigo);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Valor, DbType.String, itemMaestra.Valor);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, itemMaestra.Activo.HasValue ? itemMaestra.Activo.Value : false);
                this.db.AddOutParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.existe, DbType.Int32, 1);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, itemMaestra.Login);

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
        /// Update the item master.
        /// </summary>
        /// <param name="itemMaestra">The item master.</param>
        /// <returns>Result object</returns>
        public Resultado ActualizarItemMaestra(ItemMaestra itemMaestra)
        {
            Resultado resultado = new Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizarItemMaestra))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMaestra, DbType.Int32, itemMaestra.IdMaestra);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Codigo, DbType.String, itemMaestra.Codigo);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Valor, DbType.String, itemMaestra.Valor);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, itemMaestra.Activo.HasValue ? itemMaestra.Activo.Value : false);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, itemMaestra.Login);

                this.db.ExecuteNonQuery(comandoBaseDatos);
            }

            return resultado;
        }

        /// <summary>
        /// Search the master items.
        /// </summary>
        /// <param name="itemMaestra">The master item.</param>
        /// <returns>List of item masters</returns>
        public IList<ItemMaestra> ConsultarItemsMaestra(ItemMaestra itemMaestra)
        {
            List<ItemMaestra> resultados = new List<ItemMaestra>();

            ItemMaestra resultadoItemMaestra = null;
            Mapeador mapeador = new Mapeador();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarItemMaestra))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMaestra, DbType.Int32, itemMaestra.IdMaestra != 0 ? itemMaestra.IdMaestra : (int?)null);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Codigo, DbType.String, itemMaestra.Codigo);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Valor, DbType.String, itemMaestra.Valor);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, itemMaestra.Activo.HasValue ? itemMaestra.Activo.Value : (bool?)null);
                
                using (IDataReader reader = this.db.ExecuteReader(comandoBaseDatos))
                {
                    while (reader.Read())
                    {
                        resultados.Add(resultadoItemMaestra = mapeador.DataReaderAItemMaestra(reader));
                    }
                }
            }

            return resultados;
        }

        /// <summary>
        /// Deletes the item master.
        /// </summary>
        /// <param name="itemMaestra">The master item.</param>
        /// <returns>Result object</returns>
        public Resultado EliminarItemMaestra(ItemMaestra itemMaestra)
        {
            Resultado resultado = new Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_EliminarItemMaestra))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMaestra, DbType.Int32, itemMaestra.IdMaestra);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Codigo, DbType.String, itemMaestra.Codigo);
                this.db.AddOutParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.existe, DbType.Int32, 1);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, itemMaestra.Login);

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
