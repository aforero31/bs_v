//-----------------------------------------------------------------------
// <copyright file="IRepositorioMaestra.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Repositorio.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;

    /// <summary>
    /// Master repository interface
    /// </summary>
    public interface IRepositorioMaestra
    {
        /// <summary>
        /// Inserts the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        Resultado InsertarMaestra(Maestra maestra);

        /// <summary>
        /// Update the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        Resultado ActualizarMaestra(Maestra maestra);

        /// <summary>
        /// Search the masters.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>List of masters</returns>
        IList<Maestra> ConsultarMaestras(Maestra maestra);


        /// <summary>
        /// Search the master by name.
        /// </summary>
        /// <param name="maestra">The master name.</param>
        /// <returns>List of masters</returns>
        Maestra ConsultarMaestraPorNombre(string nombreMaestra);

        /// <summary>
        /// Deletes the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        Resultado EliminarMaestra(Maestra maestra);
    }
}
