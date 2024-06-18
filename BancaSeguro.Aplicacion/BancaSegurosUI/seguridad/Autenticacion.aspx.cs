//-----------------------------------------------------------------------
// <copyright file="Autenticacion.aspx.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSegurosUI.seguridad
{
    using BAC.EntidadesSeguridad;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSegurosUI.App_Code;
    using System;
    using System.Web.Script.Services;
    using System.Web.Services;
    using System.Web;

    /// <summary>
    /// Autentication behind class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 27/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public partial class Autenticacion : System.Web.UI.Page
    {
        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="usuario">The user.</param>
        /// <returns>AutenticacionUsuario Object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static AutenticacionUsuario AutenticarUsuario(Usuario usuario)
        {
            HttpContext context = HttpContext.Current;
            var autenticacion = AdministradorProxy.ObtenerClienteSeguridad().AutenticarUsuario(usuario);
            context.Session["Usuario"] = autenticacion.Usuario;

            return autenticacion;
        }

        /// <summary>
        /// Gets all catalogs
        /// </summary>
        /// <param name="NombreTabla">The nombre tabla.</param>
        /// <returns>DtoCatalogo object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static DtoCatalogo ConsultarTodosCatalogo(string NombreTabla)
        {
            return AdministradorProxy.ObtenerClienteGenerico().ConsultarCatalogo(NombreTabla);
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}