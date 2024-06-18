//-----------------------------------------------------------------------
// <copyright file="GestionAuditoria.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Repositorio.Administracion;

    /// <summary>
    /// Audit Management class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 17/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionAuditoria" />
    public class GestionAuditoria : IGestionAuditoria
    {
        #region Variables

        /// <summary>
        /// The audit repository
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioAuditoria repositorioAuditoria;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionAuditoria"/> class.
        /// </summary>
        /// <param name="interfazRepositorioAuditoria">The audit repository interface.</param>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public GestionAuditoria(IRepositorioAuditoria interfazRepositorioAuditoria)
        {
            this.repositorioAuditoria = interfazRepositorioAuditoria;
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Search the audits.
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
        public IList<Auditoria> ObtenerAuditorias(Auditoria auditoria)
        {
            return this.repositorioAuditoria.ObtenerAuditoria(auditoria);
        }
        #endregion
    }
}
