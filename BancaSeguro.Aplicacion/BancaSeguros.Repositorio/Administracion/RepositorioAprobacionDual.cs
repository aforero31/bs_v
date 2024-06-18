//-----------------------------------------------------------------------
// <copyright file="RepositorioAprobacionDual.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Repositorio.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using BancaSeguros.Entidades.Administracion;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// Dual approval repository class
    /// </summary>
    public class RepositorioAprobacionDual : IRepositorioAprobacionDual
    {
        #region Variables

        /// <summary>
        /// variable database
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Database db;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioAprobacionDual"/> class.
        /// </summary>
        /// <param name="nombreConexion">The name connection.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public RepositorioAprobacionDual(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Inserts the approval dual.
        /// </summary>
        /// <param name="aprobacion">The approval.</param>
        /// <returns>Result object</returns>
        public BancaSeguros.Entidades.General.Resultado InsertarAprobacionDual(AprobacionDual aprobacion)
        {
            BancaSeguros.Entidades.General.Resultado resultado = new BancaSeguros.Entidades.General.Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_InsertarAprobacionDual))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMenu, DbType.Int32, aprobacion.IdMenu);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.estado, DbType.String, aprobacion.Estado);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.accion, DbType.String, aprobacion.Accion);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.usuarioEnvia, DbType.String, aprobacion.UsuarioEnvia);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.fechaSolicitud, DbType.DateTime, DateTime.Now);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.nombreObjeto, DbType.String, aprobacion.NombreObjeto);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.datosObjeto, DbType.String, aprobacion.DatosObjeto);

                this.db.ExecuteNonQuery(comandoBaseDatos);
            }
            return resultado;
        }

        /// <summary>
        /// Search the dual approvals.
        /// </summary>
        /// <param name="aprobacion">The approval to search.</param>
        /// <returns>List of approvals</returns>
        public IList<AprobacionDual> ConsultarAprobacionesControlDual(AprobacionDual aprobacion)
        {
            List<AprobacionDual> resultados = new List<AprobacionDual>();
            AprobacionDual resultadoAprobacion = null;
            Repositorio.Administracion.Mapeador mapeador = new Repositorio.Administracion.Mapeador();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarAprobacionDual))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idAprobacionDual, DbType.Int32, aprobacion.IdAprobacionDual == 0 ? (int?)null : aprobacion.IdAprobacionDual);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idMenu, DbType.Int32, aprobacion.IdMenu == 0 ? (int?)null : aprobacion.IdMenu);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.estado, DbType.String, string.IsNullOrEmpty(aprobacion.Estado) ? null : aprobacion.Estado);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.fechaInicial, DbType.DateTime, aprobacion.FechaSolicitudInicial);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.fechaFinal, DbType.DateTime, aprobacion.FechaSolicitudFinal);
                using (IDataReader reader = this.db.ExecuteReader(comandoBaseDatos))
                {
                    while (reader.Read())
                    {
                        resultados.Add(resultadoAprobacion = mapeador.DataReaderAprobacionDual(reader));
                    }
                }
            }

            return resultados;
        }

        /// <summary>
        /// Update the approval dual.
        /// </summary>
        /// <param name="aprobacion">The approval.</param>
        /// <returns>Result object</returns>
        public BancaSeguros.Entidades.General.Resultado ActualizarAprobacionDual(AprobacionDual aprobacion)
        {
            BancaSeguros.Entidades.General.Resultado resultado = new BancaSeguros.Entidades.General.Resultado();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ActualizarAprobacionDual))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idAprobacionDual, DbType.Int32, aprobacion.IdAprobacionDual);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.estado, DbType.String, aprobacion.Estado);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.usuarioAprueba, DbType.String, aprobacion.UsuarioAprueba);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.fechaAprobacion, DbType.DateTime, DateTime.Now);
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.Descripcion, DbType.String, aprobacion.Descripcion);

                this.db.ExecuteNonQuery(comandoBaseDatos);
            }

            return resultado;
        }

        /// <summary>
        /// Search the dual control approval by identifier.
        /// </summary>
        /// <param name="idAprobacionDual">The identifier dual control approval.</param>
        /// <returns>Dual approval</returns>
        public AprobacionDual ConsultarAprobacionesControlDualPorId(int idAprobacionDual)
        {
            AprobacionDual resultadoAprobacion = null;
            Repositorio.Administracion.Mapeador mapeador = new Repositorio.Administracion.Mapeador();

            using (DbCommand comandoBaseDatos = this.db.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarAprobacionDualPorId))
            {
                this.db.AddInParameter(comandoBaseDatos, ParametrosEntradaProcedimientos.idAprobacionDual, DbType.Int32, idAprobacionDual);
                using (IDataReader reader = this.db.ExecuteReader(comandoBaseDatos))
                {
                    while (reader.Read())
                    {
                        resultadoAprobacion = mapeador.DataReaderAprobacionDual(reader);
                    }
                }
            }

            return resultadoAprobacion;
        }

        #endregion
    }
}
