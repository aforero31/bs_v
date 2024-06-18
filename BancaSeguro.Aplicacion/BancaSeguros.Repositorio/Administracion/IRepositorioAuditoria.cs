//-----------------------------------------------------------------------
// <copyright file="IRepositorioAuditoria.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Administracion
{
    using System;
    using System.Collections.Generic;
    using BAC.EntidadesSeguridad;
    using BancaSeguros.Entidades.General;

    /// <summary>
    /// Audit repository interface
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 17/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IRepositorioAuditoria
    {
        /// <summary>
        /// Gets the audit.
        /// </summary>
        /// <param name="auditoria">The audit to search.</param>
        /// <returns>List of audits</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IList<Auditoria> ObtenerAuditoria(Auditoria auditoria);
    }
}
