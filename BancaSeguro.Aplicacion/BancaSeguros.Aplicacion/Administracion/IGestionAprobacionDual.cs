//-----------------------------------------------------------------------
// <copyright file="IGestionAprobacionDual.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Aplicacion.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.Administracion;
    
    /// <summary>
    /// Dual approval manage interface
    /// </summary>
    public interface IGestionAprobacionDual
    {
        /// <summary>
        /// Inserts the approval dual.
        /// </summary>
        /// <param name="aprobacion">The approval.</param>
        /// <returns>Result object</returns>
        BancaSeguros.Entidades.General.Resultado InsertarAprobacionDual(AprobacionDual aprobacion);

        /// <summary>
        /// Search the dual approvals.
        /// </summary>
        /// <param name="aprobacion">The approval to search.</param>
        /// <returns>List of approvals</returns>
        IList<AprobacionDual> ConsultarAprobacionesControlDual(AprobacionDual aprobacion);

        /// <summary>
        /// Update the approval dual.
        /// </summary>
        /// <param name="aprobacion">The approval.</param>
        /// <returns>Result object</returns>
        BancaSeguros.Entidades.General.Resultado ActualizarAprobacionDual(AprobacionDual aprobacion);

        /// <summary>
        /// Search the dual control approval by identifier.
        /// </summary>
        /// <param name="idAprobacionDual">The identifier dual control approval.</param>
        /// <returns>Dual approval</returns>
        AprobacionDual ConsultarAprobacionesControlDualPorId(int idAprobacionDual);
    }
}
