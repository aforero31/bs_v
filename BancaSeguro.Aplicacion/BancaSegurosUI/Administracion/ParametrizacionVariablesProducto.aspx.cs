//-----------------------------------------------------------------------
// <copyright file="ParametrizacionVariablesProducto.aspx.cs" company="Unión temporal FS-BAC-2013 ">
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
    using BancaSeguros.Entidades.Seguro;

    /// <summary>
    /// Config Masters class
    /// </summary>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class ParametrizacionVariablesProducto : System.Web.UI.Page
    {

        /// <summary>
        /// Search the insurances por insurer.
        /// </summary>
        /// <param name="idAseguradora">The identifier insurer.</param>
        /// <returns>List insurances</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IList<Seguro> ConsultarSegurosPorAseguradora(int idAseguradora)
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarSegurosPorAseguradora(idAseguradora);
        }

        /// <summary>
        /// Search the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>List of variables</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IList<VariableProducto> ConsultarVariablesProducto(VariableProducto variable)
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarVariablesProducto(variable);
        }


        /// <summary>
        /// Inserts the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Object result</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado InsertarVariableProducto(VariableProducto variable)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                variable.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }

            return AdministradorProxy.ObtenerClienteAdministracion().InsertarVariableProducto(variable);
        }

        
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado ActualizarVariableProducto(VariableProducto variable)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                variable.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }

            return AdministradorProxy.ObtenerClienteAdministracion().ActualizarVariableProducto(variable);
        }

        /// <summary>
        /// Deletes the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado EliminarVariableProducto(VariableProducto variable)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                variable.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }

            return AdministradorProxy.ObtenerClienteAdministracion().EliminarVariableProducto(variable);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}