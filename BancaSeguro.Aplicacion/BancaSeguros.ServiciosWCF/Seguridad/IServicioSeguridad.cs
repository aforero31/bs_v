//-----------------------------------------------------------------------
// <copyright file="IServicioSeguridad.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.ServiciosWCF.Seguridad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using BAC.EntidadesSeguridad;
    using BancaSeguros.Entidades.Venta;

    /// <summary>
    /// Security Service Interface
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 26/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [ServiceContract]
    public interface IServicioSeguridad
    {
        #region Usuario

        /// <summary>
        /// Authenticate the user.
        /// </summary>
        /// <param name="usuario">The user.</param>
        /// <returns>user authentication</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        AutenticacionUsuario AutenticarUsuario(Usuario usuario);

        /// <summary>
        /// Authenticate the user.
        /// </summary>
        /// <param name="usuario">The user.</param>
        /// <returns>user authentication</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        RefreshTokenResultado ObtenerRefreshToken(Usuario usuario);
        #endregion

        #region Asesor

        /// <summary>
        /// Search the adviser.
        /// </summary>
        /// <param name="_asesor">The adviser.</param>
        /// <returns>Adviser object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        Asesor ConsultarAsesor(Asesor asesor);

        #endregion

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
        [OperationContract]
        BancaSeguros.Entidades.General.Resultado InsertarRol(Rol rol);

        /// <summary>
        /// Update the role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        BancaSeguros.Entidades.General.Resultado ActualizarRol(Rol rol);

        /// <summary>
        /// Get the roles.
        /// </summary>
        /// <param name="nombre">The name.</param>
        /// <param name="estado">The state.</param>
        /// <returns>List of Roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        List<Rol> ObtenerRoles(string nombre, string estado);

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
        [OperationContract]
        IList<Rol> ObtenerRolesCompletos(string nombre, string estado);

        #endregion

        #region Menu

        /// <summary>
        /// Gets the menu.
        /// </summary>
        /// <returns>List of menus</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        List<Menu> ObtenerMenu();

        /// <summary>
        /// Gets the menu by role.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns>List of menus</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
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
        [OperationContract]
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
        [OperationContract]
        IList<Menu> ObtenerFuncionesMenuPorRol(Rol rol);

        /// <summary>
        /// Gets the menus approval dual by roles.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        [OperationContract]
        IList<Menu> ConsultarMenusAprobacionDualPorRoles(List<Rol> roles);

        /// <summary>
        /// Gets the menus required approval dual by roles.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        [OperationContract]
        IList<Menu> ConsultarMenusRequiereDualPorRoles(List<Rol> roles); 

        #endregion

        #region Oficina

        /// <summary>
        /// Search the office by code.
        /// </summary>
        /// <param name="idOficina">The identifier office.</param>
        /// <returns>Office object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        Oficina ConsultarOficinaPorCodigo(int idOficina);

        #endregion

        #region Permiso

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
        [OperationContract]
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
        [OperationContract]
        BancaSeguros.Entidades.General.Resultado EliminarPermiso(Permisos permiso);

        #endregion

        #region GrupoBAC

        /// <summary>
        /// Search the groups.
        /// </summary>
        /// <param name="grupo">The group.</param>
        /// <returns>List of groups</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        IList<GrupoBAC> ConsultarGruposBAC(GrupoBAC grupo);

        /// <summary>
        /// Search the group by role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>List of Groups</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        IList<GrupoBAC> ConsultarGrupoPorRol(Rol rol);
        #endregion

        #region Administracion Control Dual
        /// <summary>
        /// Gets the items of menu.
        /// </summary>
        /// <returns>List of menus</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        List<Menu> ConsultarMenuControlDual();

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns>List of roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> ConsultarAdmonControlDual();

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns>List of roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> ConsultarAdmonControlDualIdMenu(int idMenu);

        /// <summary>
        /// insert the registry of Control Dual.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
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
        [OperationContract]
        BancaSeguros.Entidades.General.Resultado ActualizarAdmonControlDual(List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> controlDual);

        /// <summary>
        /// Required the autorizacion dual.
        /// </summary>
        /// <param name="rolesUsuario">The roles user.</param>
        /// <param name="idMenu">The identifier menu.</param>
        /// <returns>if the dual approval is requiered value</returns>
        [OperationContract]
        bool RequiereAutorizacionDual(List<Rol> rolesUsuario, int idMenu);

        /// <summary>
        /// Validate the authorizer dual.
        /// </summary>
        /// <param name="rolesUsuario">The roles user.</param>
        /// <param name="idMenu">The identifier menu.</param>
        /// <returns>if the authorizer dual is valid</returns>
        [OperationContract]
        bool ValidarAutorizadorDual(List<Rol> rolesUsuario);

        #endregion
    }
}
