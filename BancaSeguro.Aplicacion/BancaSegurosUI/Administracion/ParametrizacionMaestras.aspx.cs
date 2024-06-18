//-----------------------------------------------------------------------
// <copyright file="ParametrizacionAseguradora.aspx.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSegurosUI.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Services;
    using System.Web.Services;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSegurosUI.App_Code;

    /// <summary>
    /// Config Masters class
    /// </summary>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class ParametrizacionMaestras : System.Web.UI.Page
    {
        /// <summary>
        /// Search the masters.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>List of masters</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IList<Maestra> ConsultarMaestras(Maestra maestra)
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarMaestras(maestra);
        }

        /// <summary>
        /// Inserts the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado InsertarMaestra(Maestra maestra)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                maestra.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
                foreach (ItemMaestra item in maestra.Items)
                {
                    item.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
                }
            }

            return AdministradorProxy.ObtenerClienteAdministracion().InsertarMaestra(maestra);
        }

        /// <summary>
        /// Update the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado ActualizarMaestra(Maestra maestra)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                maestra.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
                foreach (ItemMaestra item in maestra.Items)
                {
                    item.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
                }
            }

            return AdministradorProxy.ObtenerClienteAdministracion().ActualizarMaestra(maestra);
        }

        /// <summary>
        /// Deletes the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado EliminarMaestra(Maestra maestra)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                maestra.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }

            return AdministradorProxy.ObtenerClienteAdministracion().EliminarMaestra(maestra);
        }

        /// <summary>
        /// Search the master items.
        /// </summary>
        /// <param name="maestra">The master item.</param>
        /// <returns>List of master items</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IList<ItemMaestra> ConsultarItemsMaestra(ItemMaestra itemMaestra)
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarItemsMaestra(itemMaestra);
        }

        /// <summary>
        /// Inserts the master item.
        /// </summary>
        /// <param name="maestra">The master item.</param>
        /// <returns>Result object</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado InsertarItemMaestra(ItemMaestra itemMaestra)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                itemMaestra.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }

            return AdministradorProxy.ObtenerClienteAdministracion().InsertarItemMaestra(itemMaestra);
        }

        /// <summary>
        /// Update the master item.
        /// </summary>
        /// <param name="maestra">The master item.</param>
        /// <returns>Result object</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado ActualizarItemMaestra(ItemMaestra itemMaestra)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                itemMaestra.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }

            return AdministradorProxy.ObtenerClienteAdministracion().ActualizarItemMaestra(itemMaestra);
        }

        /// <summary>
        /// Delete the master item.
        /// </summary>
        /// <param name="maestra">The master item.</param>
        /// <returns>Result object</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado EliminarItemMaestra(ItemMaestra itemMaestra)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                itemMaestra.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }

            return AdministradorProxy.ObtenerClienteAdministracion().EliminarItemMaestra(itemMaestra);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}