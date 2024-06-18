//-----------------------------------------------------------------------
// <copyright file="IGestionSeguridad.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BAC.Seguridad.Seguridad
{
    using System;
    using System.Collections.Generic;
    using BAC.EntidadesSeguridad;

    /// <summary>
    /// Interface Security Manage
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 26/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionSeguridad
    {
        #region Rol

        /// <summary>
        /// Inserts the role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        BancaSeguros.Entidades.General.Resultado InsertarRol(Rol rol);

        /// <summary>
        /// Update the role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>Result Object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        BancaSeguros.Entidades.General.Resultado ActualizarRol(Rol rol);

        /// <summary>
        /// Get the roles.
        /// </summary>
        /// <param name="nombre">The name.</param>
        /// <param name="estado">The estate.</param>
        /// <returns>List of Roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<BAC.EntidadesSeguridad.Rol> ObtenerRoles(string nombre, string estado);

        /// <summary>
        /// Get the complete roles.
        /// </summary>
        /// <param name="nombre">The name.</param>
        /// <param name="estado">The state.</param>
        /// <returns>List of Roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 11/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IList<Rol> ObtenerRolesCompletos(string nombre, string estado);

        

        #endregion

        #region Permisos

        /// <summary>
        /// Add the permission.
        /// </summary>
        /// <param name="permiso">The permission.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        BancaSeguros.Entidades.General.Resultado AsignarPermiso(Permisos permiso);

        /// <summary>
        /// Deletes the permissions.
        /// </summary>
        /// <param name="permiso">The permission.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        BancaSeguros.Entidades.General.Resultado EliminarPermiso(Permisos permiso);

        #endregion        

        #region Menu

        /// <summary>
        /// Get the menu.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<Menu> ObtenerMenu();

        /// <summary>
        /// Get the menu by role.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns>List menus</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<Menu> ObtenerMenuPorRol(List<Rol> roles);

        /// <summary>
        /// Get the menu functions.
        /// </summary>
        /// <returns>List of menu functions</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IList<Menu> ObtenerFuncionesMenu();

        /// <summary>
        /// Get the menu functions by role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>List of menu functions</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IList<Menu> ObtenerFuncionesMenuPorRol(Rol rol);

        /// <summary>
        /// Search the menus dual approval.
        /// </summary>
        /// <returns>List of menus</returns>
        IList<Menu> ConsultaMenusAprobacionDualPorRol(int idRol);

        /// <summary>
        /// Gets the menus approval dual by roles.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        IList<Menu> ConsultarMenusAprobacionDualPorRoles(List<Rol> roles);

        /// <summary>
        /// Search the menus required dual approval.
        /// </summary>
        /// <returns>List of menus</returns>
        IList<Menu> ConsultaMenusRequiereDualPorRol(int idRol);

        /// <summary>
        /// Gets the menus required approval dual by roles.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        IList<Menu> ConsultarMenusRequiereDualPorRoles(List<Rol> roles); 

        #endregion

        #region Administracion Control Dual
        /// <summary>
        /// Get the items of menu.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<Menu> ConsultarMenuControlDual();

        /// <summary>
        /// Get the roles.
        /// </summary>
        /// <returns>List of Roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>

        List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> ConsultarAdmonControlDual();

        /// <summary>
        /// Get the roles.
        /// </summary>
        /// <returns>List of Roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 15/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> ConsultarAdmonControlDualIdMenu(int idMenu);

        /// <summary>
        /// Insert the registry of Control Dual.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        BancaSeguros.Entidades.General.Resultado InsertarAdmonControlDual(List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> controlDual);

        /// <summary>
        /// Update the registry of Control Dual.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 15/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        BancaSeguros.Entidades.General.Resultado ActualizarAdmonControlDual(List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> controlDual);

        /// <summary>
        /// Required the autorizacion dual.
        /// </summary>
        /// <param name="rolesUsuario">The roles user.</param>
        /// <param name="idMenu">The identifier menu.</param>
        /// <returns>if the dual approval is requiered value</returns>
        bool RequiereAutorizacionDual(List<Rol> rolesUsuario, int idMenu);

        /// <summary>
        /// Validate the authorizer dual.
        /// </summary>
        /// <param name="rolesUsuario">The roles user.</param>
        /// <param name="idMenu">The identifier menu.</param>
        /// <returns>if the authorizer dual is valid</returns>
        bool ValidarAutorizadorDual(List<Rol> rolesUsuario);

        #endregion
    }
}
