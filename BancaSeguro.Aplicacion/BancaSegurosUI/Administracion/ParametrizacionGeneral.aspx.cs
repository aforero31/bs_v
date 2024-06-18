//-----------------------------------------------------------------------
// <copyright file="ParametrizacionGeneral.aspx.cs" company="Unión temporal FS-BAC-2013 ">
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
    /// Code Behind
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 18/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class ParametrizacionGeneral : System.Web.UI.Page
    {
        /// <summary>
        /// Consult the type data.
        /// </summary>
        /// <returns>List Entity Type Data</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<TipoDato> ConsultarTipoDato()
        {
            DtoCatalogo dt = new DtoCatalogo();
            string nombreTablaCanalVenta = EnumCatalogo.TipoDato;

            dt = AdministradorProxy.ObtenerClienteGenerico().ConsultarCatalogo(nombreTablaCanalVenta);
            return dt.ListTipoDato;
        }

        /// <summary>
        /// Consult the all parameters.
        /// </summary>
        /// <returns>List Entity Parameter</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<Parametro> ConsultarTodoLosParamteros()
        {
            DtoCatalogo dt = new DtoCatalogo();
            string nombreTablaCanalVenta = EnumCatalogo.Parametro;

            dt = AdministradorProxy.ObtenerClienteGenerico().ConsultarCatalogo(nombreTablaCanalVenta);
            return dt.ListParametro;
        }

        /// <summary>
        /// Consult the all validations.
        /// </summary>
        /// <returns>List Entity Type Validation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<TipoValidacion> ConsultarTodasLasValidaciones()
        {
            DtoCatalogo dt = new DtoCatalogo();
            string nombreTablaCanalVenta = EnumCatalogo.TipoValidacion;

            dt = AdministradorProxy.ObtenerClienteGenerico().ConsultarCatalogo(nombreTablaCanalVenta);
            return dt.ListTipoValidacion;
        }

        /// <summary>
        /// Update the parameter of identifier.
        /// </summary>
        /// <param name="parametro">The parameter.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado ActualizaParametroPorId(Parametro parametro)
        {
            parametro.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            return AdministradorProxy.ObtenerClienteAdministracion().ActualizaParametroPorId(parametro);
        }

        /// <summary>
        /// Save the parameter.
        /// </summary>
        /// <param name="parametro">The parameter.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado GuardarParametro(Parametro parametro)
        {
            parametro.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            return AdministradorProxy.ObtenerClienteAdministracion().GuardarParametro(parametro);
        }
       
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}