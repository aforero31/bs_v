//-----------------------------------------------------------------------
// <copyright file="ParametrizacionIPC.aspx.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------


namespace BancaSegurosUI.Administracion
{
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSegurosUI.App_Code;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Script.Services;
    using System.Web.Services;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// CodeBehind Page Load
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    /// CreationDate: 02/06/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="System.Web.UI.Page" />

    public partial class ParametrizacionMensajes : System.Web.UI.Page
    {
        /// <summary>
        /// Search the Messages.
        /// </summary>
        /// <returns>The Messages</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IList<Mensaje> ConsultarMensajes(Mensaje mensaje)
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarMensajes(mensaje);
        }

        /// <summary>
        /// Save the Messages.
        /// </summary>
        /// <returns>The Messages</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado InsertarMensaje(Mensaje mensaje)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                mensaje.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }
            return AdministradorProxy.ObtenerClienteAdministracion().InsertarMensaje(mensaje);
        }

        /// <summary>
        /// Update the Message.
        /// </summary>
        /// <returns>The Message</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado ActualizarMensaje(Mensaje mensaje)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                mensaje.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }
            return AdministradorProxy.ObtenerClienteAdministracion().ActualizarMensaje(mensaje);
        }

        #region Catalogos

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static DtoCatalogo ConsultarCatalogo(string NombreTabla)
        {
            return AdministradorProxy.ObtenerClienteGenerico().ConsultarCatalogo(NombreTabla);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}