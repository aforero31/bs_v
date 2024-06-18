//-----------------------------------------------------------------------
// <copyright file="IRepositorioVariableVenta.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Repositorio.Venta
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Venta;

    /// <summary>
    /// Sale variable repository interface
    /// </summary>
    public interface IRepositorioVariableVenta
    {
        /// <summary>
        /// Inserts the variable sale.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Result object</returns>
        Resultado InsertarVariableVenta(VariableVenta variable);

        /// <summary>
        /// Search the variables sale.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>List of variables</returns>
        IList<VariableVenta> ConsultarVariablesVenta(VariableVenta variable);
    }
}
