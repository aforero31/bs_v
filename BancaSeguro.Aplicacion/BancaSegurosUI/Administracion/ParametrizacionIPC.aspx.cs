//-----------------------------------------------------------------------
// <copyright file="ParametrizacionIPC.aspx.cs" company="Unión temporal FS-BAC-2013 ">
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
    using BancaSegurosUI.App_Code;
    using BancaSeguros.Entidades.General;

    /// <summary>
    /// CodeBehind Page Load
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    /// CreationDate: 18/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class ParametrizacionIPC : System.Web.UI.Page
    {
        /// <summary>
        /// Save the IPC.
        /// </summary>
        /// <returns>The IPC</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado GuardarIPC(IPC ipc)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                ipc.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }
            return AdministradorProxy.ObtenerClienteIPC().GuardarIPC(ipc);
        }

        /// <summary>
        /// Update the IPC.
        /// </summary>
        /// <returns>The IPC</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado ActualizaIPC(IPC ipc)
        {
            return AdministradorProxy.ObtenerClienteIPC().ActualizaIPC(ipc);
        }
        /// <summary>
        /// Obtain the IPC.
        /// </summary>
        /// <returns>The IPC</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IPC ConsultarIPC()
        {
            return AdministradorProxy.ObtenerClienteIPC().ConsultarIPC();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}