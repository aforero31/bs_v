//-----------------------------------------------------------------------
// <copyright file="IRepositorioMenu.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Repositorio.Seguridad
{
    using System;
    using System.Collections.Generic;
    using BAC.EntidadesSeguridad;

    /// <summary>
    /// Menu repository interface
    /// </summary>
    public interface IRepositorioMenu
    {
        /// <summary>
        /// Gets the menus.
        /// </summary>
        /// <returns>List of menus</returns>
        List<Menu> ObtenerMenu();

        /// <summary>
        /// Gets the menus by role.
        /// </summary>
        /// <param name="idRol">The identifier role.</param>
        /// <returns>List of menus</returns>
        List<Menu> ObtenerMenuPorRol(int idRol);

        /// <summary>
        /// Search the menus dual approval.
        /// </summary>
        /// <returns>List of menus</returns>
        IList<Menu> ConsultaMenusAprobacionDualPorRol(int idRol);

        /// <summary>
        /// Search the menus required dual approval.
        /// </summary>
        /// <returns>List of menus</returns>
        IList<Menu> ConsultaMenusRequiereDualPorRol(int idRol);
    }
}
