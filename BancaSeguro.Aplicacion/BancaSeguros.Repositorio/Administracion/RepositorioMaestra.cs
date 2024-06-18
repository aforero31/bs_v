//-----------------------------------------------------------------------
// <copyright file="RepositorioMaestra.cs" company="Unión temporal FS-BAC-2013 ">
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
    /// Master repository
    /// </summary>
    /// <seealso cref="BancaSeguros.Repositorio.Administracion.IRepositorioMaestra" />
    public class RepositorioMaestra : IRepositorioMaestra
    {
        #region Variables

        /// <summary>
        /// Database variable
        /// </summary>
        private Database db;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioMaestra"/> class.
        /// </summary>
        /// <param name="nombreConexion">The connection name.</param>
        public RepositorioMaestra(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Inserts the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        public Resultado InsertarMaestra(Maestra maestra)
        {
            Resultado resultado = new Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_InsertarMaestra))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nombre, DbType.String, maestra.Nombre);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, maestra.Activo.HasValue ? maestra.Activo.Value : false);
                this.db.AddOutParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMaestra, DbType.Int32, 1);
                this.db.AddOutParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.existe, DbType.Int32, 1);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, maestra.Login);

                this.db.ExecuteNonQuery(comandoBaseDatos);

                int existe = (int)this.db.GetParameterValue(comandoBaseDatos, ParametrosEntradaProcedimientos.existe);
                if (existe == 1)
                {
                    resultado.Error = true;
                }
                else
                {
                    int idMaestra = (int)this.db.GetParameterValue(comandoBaseDatos, ParametrosEntradaProcedimientos.idMaestra);
                    resultado.Mensaje = idMaestra.ToString(); 
                }
            }

            return resultado;
        }

        /// <summary>
        /// Update the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        public Resultado ActualizarMaestra(Maestra maestra)
        {
            Resultado resultado = new Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizarMaestra))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMaestra, DbType.Int32, maestra.IdMaestra);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, maestra.Activo.HasValue ? maestra.Activo.Value : false);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, maestra.Login);

                this.db.ExecuteNonQuery(comandoBaseDatos);
            }

            return resultado;
        }

        /// <summary>
        /// Search the masters.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>List of masters</returns>
        public IList<Maestra> ConsultarMaestras(Maestra maestra)
        {
            List<Maestra> resultados = new List<Maestra>();

            Maestra resultadoMaestra = null;
            Mapeador mapeador = new Mapeador();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarMaestra))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMaestra, DbType.Int32, maestra.IdMaestra != 0 ? maestra.IdMaestra : (int?)null);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nombre, DbType.String, maestra.Nombre);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, maestra.Activo.HasValue ? maestra.Activo.Value : (bool?)null);
                
                using (IDataReader reader = this.db.ExecuteReader(comandoBaseDatos))
                {
                    while (reader.Read())
                    {
                        resultados.Add(resultadoMaestra = mapeador.DataReaderAMaestra(reader));
                    }
                }
            }

            return resultados;
        }

        /// <summary>
        /// Search the master by name.
        /// </summary>
        /// <param name="maestra">The master name.</param>
        /// <returns>List of masters</returns>
        public Maestra ConsultarMaestraPorNombre(string nombreMaestra)
        {
            Maestra resultadoMaestra = null;
            Mapeador mapeador = new Mapeador();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarMaestraPorNombre))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nombre, DbType.String, nombreMaestra);

                using (IDataReader reader = this.db.ExecuteReader(comandoBaseDatos))
                {
                    while (reader.Read())
                    {
                        resultadoMaestra = mapeador.DataReaderAMaestra(reader);
                    }
                }
            }

            return resultadoMaestra;
        }

        /// <summary>
        /// Deletes the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        public Resultado EliminarMaestra(Maestra maestra)
        {
            Resultado resultado = new Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(Procedimientos.PR_SEG_EliminarMaestra))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMaestra, DbType.Int32, maestra.IdMaestra);
                this.db.AddOutParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.existe, DbType.Int32, 1);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Login, DbType.String, maestra.Login);

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
