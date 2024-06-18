//-----------------------------------------------------------------------
// <copyright file="AprobarControlDual.aspx.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSegurosUI.seguridad
{
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Services;
    using System.Web.Services;
    using BancaSeguros.Entidades.Administracion;
    using BancaSegurosUI.App_Code;
using BAC.EntidadesSeguridad;
    using BancaSeguros.Entidades.General;

    /// <summary>
    /// Dual Control Approval class
    /// </summary>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class AprobarControlDual : System.Web.UI.Page
    {
        /// <summary>
        /// Search the dual approvals.
        /// </summary>
        /// <param name="aprobacion">The approval to search.</param>
        /// <returns>List of approvals</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IList<AprobacionDual> ConsultarAprobacionesControlDual(AprobacionDual aprobacion)
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarAprobacionesControlDual(aprobacion);
        }

        /// <summary>
        /// Update the approval dual.
        /// </summary>
        /// <param name="aprobacion">The approval.</param>
        /// <returns>Result object</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static BancaSeguros.Entidades.General.Resultado ActualizarAprobacionDual(AprobacionDual aprobacion)
        {
            BancaSeguros.Entidades.General.Resultado resultado = new BancaSeguros.Entidades.General.Resultado();
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                aprobacion.UsuarioAprueba = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }

            if (aprobacion.Estado == EnumEstadoDual.Aprobada)
            {
                switch (aprobacion.Accion)
                {
                    case EnumAccionDual.Insertar:
                        {
                            resultado = AdministradorProxy.ObtenerClienteControlDual().InsertarRegistroEfectivo(aprobacion.IdAprobacionDual, aprobacion.UsuarioAprueba);
                        }

                        break;

                    case EnumAccionDual.Actualizar:
                        {
                            resultado = AdministradorProxy.ObtenerClienteControlDual().ActualizarRegistroEfectivo(aprobacion.IdAprobacionDual, aprobacion.UsuarioAprueba);
                        }

                        break;

                    case EnumAccionDual.Activar:
                        {
                            resultado = AdministradorProxy.ObtenerClienteControlDual().ActivarRegistroEfectivo(aprobacion.IdAprobacionDual);
                        }

                        break;

                    case EnumAccionDual.Eliminar:
                        {
                            resultado = AdministradorProxy.ObtenerClienteControlDual().EliminarRegistroEfectivo(aprobacion.IdAprobacionDual, aprobacion.UsuarioAprueba);
                        }

                        break;
                }

                if (resultado.Error == false)
                {
                    resultado = AdministradorProxy.ObtenerClienteAdministracion().ActualizarAprobacionDual(aprobacion);
                }
            }
            else
            {
                resultado = AdministradorProxy.ObtenerClienteAdministracion().ActualizarAprobacionDual(aprobacion);
            }

            return resultado;
        }

        /// <summary>
        /// Search the dual control approval by identifier.
        /// </summary>
        /// <param name="idAprobacionDual">The identifier dual control approval.</param>
        /// <returns>Dual approval</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static AprobacionDual ConsultarAprobacionesControlDualPorId(int idAprobacionDual)
        {
            //return AdministradorProxy.ObtenerClienteAdministracion().ConsultarAprobacionesControlDualPorId(idAprobacionDual);
            return AdministradorProxy.ObtenerClienteControlDual().ConsultarRegistroControlDualPorId(idAprobacionDual);
        }

        /// <summary>
        /// Search the dual approval menus.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IList<Menu> ConsultarMenusAprobacionDual(List<Rol> roles)
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ConsultarMenusAprobacionDualPorRoles(roles);
        }

        /// <summary>
        /// Search the dual approval menus.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IList<Menu> ConsultarMenusRequiereAprobacionDual(List<Rol> roles)
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ConsultarMenusRequiereDualPorRoles(roles);
        }

        /// <summary>
        /// Required the dual authorization value.
        /// </summary>
        /// <param name="rolesUsuario">The user roles.</param>
        /// <param name="idMenu">The identifier menu.</param>
        /// <returns>Value of dual authorization </returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static bool RequiereAutorizacionDual(List<Rol> rolesUsuario, int idMenu)
        {
            return AdministradorProxy.ObtenerClienteSeguridad().RequiereAutorizacionDual(rolesUsuario, idMenu);
        }

        /// <summary>
        /// Inserts the approval dual.
        /// </summary>
        /// <param name="aprobacion">The approval.</param>
        /// <returns>Result object</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static BancaSeguros.Entidades.General.Resultado InsertarAprobacionDual(AprobacionDual aprobacion)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                aprobacion.UsuarioEnvia = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }

            return AdministradorProxy.ObtenerClienteAdministracion().InsertarAprobacionDual(aprobacion);
        }

        /// <summary>
        /// Validate the dual authorization value.
        /// </summary>
        /// <param name="rolesUsuario">The user roles.</param>
        /// <param name="idMenu">The identifier menu.</param>
        /// <returns>Value of dual authorizer </returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static bool ValidarAutorizadorDual(List<Rol> rolesUsuario)
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ValidarAutorizadorDual(rolesUsuario);
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}