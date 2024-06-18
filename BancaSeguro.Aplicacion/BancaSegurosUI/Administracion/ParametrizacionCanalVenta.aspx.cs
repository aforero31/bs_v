//-----------------------------------------------------------------------
// <copyright file="ParametrizacionCanalVenta.aspx.cs" company="Unión temporal FS-BAC-2013 ">
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
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 12/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class ParametrizacionCanalVenta : System.Web.UI.Page
    {
        /// <summary>
        /// Consults the all channel sale.
        /// </summary>
        /// <returns>List entity</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<CanalVenta> ConsultarTodoLosCanalesVenta()
        {
            DtoCatalogo dt = new DtoCatalogo();
            string nombreTablaCanalVenta = EnumCatalogo.CanalVenta;

            dt = AdministradorProxy.ObtenerClienteGenerico().ConsultarCatalogo(nombreTablaCanalVenta);
            return dt.ListCanalVenta;
        }

        /// <summary>
        /// Save the channel sale.
        /// </summary>
        /// <param name="canalVenta">The channel sale.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado GuardarCanalVenta(CanalVenta canalVenta)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                canalVenta.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }
            return AdministradorProxy.ObtenerClienteAdministracion().GuardarCanalVenta(canalVenta);
        }

        /// <summary>
        /// Update the channel sale of identifier.
        /// </summary>
        /// <param name="canalVenta">The channel sale.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado ActualizaCanalVentaPorId(CanalVenta canalVenta)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                canalVenta.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }
            return AdministradorProxy.ObtenerClienteAdministracion().ActualizaCanalVentaPorId(canalVenta);
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}