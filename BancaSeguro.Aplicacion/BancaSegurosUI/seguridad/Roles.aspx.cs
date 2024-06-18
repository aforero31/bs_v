//-----------------------------------------------------------------------
// <copyright file="Roles.aspx.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSegurosUI.seguridad
{
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Services;
    using System.Web.Services;
    using BAC.EntidadesSeguridad;
    using BancaSegurosUI.App_Code;
    
    /// <summary>
    /// Roles Class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 28/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class Roles : System.Web.UI.Page
    {  
        /// <summary>
        /// Inserts the role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static BancaSeguros.Entidades.General.Resultado InsertarRol(Rol rol)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                rol.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }
            return AdministradorProxy.ObtenerClienteSeguridad().InsertarRol(rol);  
        }

        /// <summary>
        /// Update the role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static BancaSeguros.Entidades.General.Resultado ActualizarRol(Rol rol)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                rol.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }
            return AdministradorProxy.ObtenerClienteSeguridad().ActualizarRol(rol);
        }

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <param name="nombre">The name.</param>
        /// <param name="estado">The state.</param>
        /// <returns>List of Roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<Rol> ObtenerRoles(string nombre, string estado)
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ObtenerRoles(nombre, estado);
        }

        /// <summary>
        /// Gets the groups.
        /// </summary>
        /// <param name="grupo">The group.</param>
        /// <returns>List of groups</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IList<GrupoBAC> ObtenerGruposBAC(GrupoBAC grupo)
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ConsultarGruposBAC(grupo);
        }

        /// <summary>
        /// Gets the groups by role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>List of groups</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IList<GrupoBAC> ObtenerGruposPorRol(Rol rol)
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ConsultarGrupoPorRol(rol);
        }

        /// <summary>
        /// Gets the menu functions.
        /// </summary>
        /// <returns>Lists of Menu</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IList<Menu> ObtenerFuncionesMenu()
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ObtenerFuncionesMenu();
        }

        /// <summary>
        /// Gets the functions menu by role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>List Menu</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IList<Menu> ObtenerFuncionesMenuPorRol(Rol rol)
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ObtenerFuncionesMenuPorRol(rol);
        }

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <param name="nombre">The name.</param>
        /// <param name="estado">The state.</param>
        /// <returns>List of Roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<Rol> ObtenerRolesCompletos(string nombre, string estado)
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ObtenerRolesCompletos(nombre, estado);
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}