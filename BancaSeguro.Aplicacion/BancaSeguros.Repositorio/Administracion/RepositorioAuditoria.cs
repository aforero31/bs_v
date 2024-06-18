//-----------------------------------------------------------------------
// <copyright file="RepositorioAuditoria.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Administracion
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// Audit repository class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 17/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="IRepositorioAuditoria" />
    public class RepositorioAuditoria : IRepositorioAuditoria
    {
        #region Variables

        /// <summary>
        /// variable database
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Database db;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioAuditoria"/> class.
        /// </summary>
        /// <param name="nombreConexion">The name connection</param>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public RepositorioAuditoria(string nombreConexion)
        {
            this.db = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Gets the audit.
        /// </summary>
        /// <param name="auditoria">The audit to search.</param>
        /// <returns>
        /// List of audits
        /// </returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Auditoria> ObtenerAuditoria(Auditoria auditoria)
        {
            List<Auditoria> listaAuditoria = new List<Auditoria>();
            Mapeador mapeador = new Mapeador();
            Auditoria auditoriaItem;
            using (DbCommand cmd = this.db.GetStoredProcCommand(Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarAuditoria))
            {
                this.db.AddInParameter(cmd, ParametrosEntradaProcedimientos.tipo, DbType.String, string.IsNullOrEmpty(auditoria.Tipo) ? null : auditoria.Tipo);
                this.db.AddInParameter(cmd, ParametrosEntradaProcedimientos.nombreTabla, DbType.String, string.IsNullOrEmpty(auditoria.NombreTabla) ? null : auditoria.NombreTabla);
                this.db.AddInParameter(cmd, ParametrosEntradaProcedimientos.campoLlave, DbType.String, string.IsNullOrEmpty(auditoria.CampoLlave) ? null : auditoria.CampoLlave);
                this.db.AddInParameter(cmd, ParametrosEntradaProcedimientos.valorLlave, DbType.String, string.IsNullOrEmpty(auditoria.ValorLlave) ? null : auditoria.ValorLlave);
                this.db.AddInParameter(cmd, ParametrosEntradaProcedimientos.campo, DbType.String, string.IsNullOrEmpty(auditoria.Campo) ? null : auditoria.Campo);
                this.db.AddInParameter(cmd, ParametrosEntradaProcedimientos.valorAnterior, DbType.String, string.IsNullOrEmpty(auditoria.ValorAnterior) ? null : auditoria.ValorAnterior);
                this.db.AddInParameter(cmd, ParametrosEntradaProcedimientos.nuevoValor, DbType.String, string.IsNullOrEmpty(auditoria.NuevoValor) ? null : auditoria.NuevoValor);
                this.db.AddInParameter(cmd, ParametrosEntradaProcedimientos.fechaInicial, DbType.DateTime, auditoria.FechaIniActualizacion);
                this.db.AddInParameter(cmd, ParametrosEntradaProcedimientos.fechaFinal, DbType.DateTime, auditoria.FechaFinActualizacion);
                this.db.AddInParameter(cmd, ParametrosEntradaProcedimientos.usuario, DbType.String, string.IsNullOrEmpty(auditoria.Usuario) ? null : auditoria.Usuario);

                using (IDataReader reader = this.db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        auditoriaItem = mapeador.DataReaderAuditoria(reader);
                        listaAuditoria.Add(auditoriaItem);
                    }
                }
            }

            return listaAuditoria;
        }

        #endregion
    }
}
