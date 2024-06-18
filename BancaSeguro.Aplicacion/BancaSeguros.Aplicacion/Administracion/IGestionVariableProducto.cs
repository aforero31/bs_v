//-----------------------------------------------------------------------
// <copyright file="IGestionVariableProducto.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Aplicacion.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    
    /// <summary>
    /// Product Variable Manage interface
    /// </summary>
    public interface IGestionVariableProducto
    {
        /// <summary>
        /// Inserts the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Result object</returns>
        Resultado InsertarVariableProducto(VariableProducto variable);

        /// <summary>
        /// Update the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Result object</returns>
        Resultado ActualizarVariableProducto(VariableProducto variable);

        /// <summary>
        /// Search the product variables.
        /// </summary>
        /// <param name="variable">The variable to search.</param>
        /// <returns>List of variables</returns>
        IList<VariableProducto> ConsultarVariablesProducto(VariableProducto variable);

        /// <summary>
        /// Search the active product variables .
        /// </summary>
        /// <param name="variable">The variable to search.</param>
        /// <returns>List of active variables</returns>
        IList<VariableProducto> ConsultarVariablesProductoActivas(VariableProducto variable);

        /// <summary>
        /// Deletes the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Result object</returns>
        Resultado EliminarVariableProducto(VariableProducto variable);
    }
}
