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
    using BancaSegurosUI.App_Code;
    using BancaSegurosUI.ServicioAdministracion;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.General;

    /// <summary>
    /// Class Insurances management
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 19/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class ParametrizacionAseguradora : System.Web.UI.Page
    {
        /// <summary>
        /// The insurances
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static IList<Aseguradora> aseguradoras;

        /// <summary>
        /// Search the insurances.
        /// </summary>
        /// <param name="aseguradora">The insurance.</param>
        /// <returns>List of insurances</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IList<Aseguradora> ConsultarAseguradoras(Aseguradora aseguradora)
        {
            aseguradoras = AdministradorProxy.ObtenerClienteAdministracion().ConsultarAseguradoras(aseguradora);
            return aseguradoras;
        }

        /// <summary>
        /// Search the insurance by identifier.
        /// </summary>
        /// <param name="idAseguradora">The insurance id.</param>
        /// <returns>The insurance</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Aseguradora ConsultarAseguradoraPorId(int idAseguradora)
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarAseguradoraPorId(idAseguradora);   
        }

        /// <summary>
        /// Inserts the insurance.
        /// </summary>
        /// <param name="aseguradora">The insurance.</param>
        /// <returns>The result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado InsertarAseguradora(Aseguradora aseguradora)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                aseguradora.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }
            return AdministradorProxy.ObtenerClienteAdministracion().InsertarAseguradora(aseguradora); 
        }

        /// <summary>
        /// Update the insurance.
        /// </summary>
        /// <param name="aseguradora">The insurance.</param>
        /// <param name="actualizaConsecutivo">if set to <c>true</c> [update consecutive].</param>
        /// <returns>The result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado ActualizarAseguradora(Aseguradora aseguradora)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                aseguradora.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }
            return AdministradorProxy.ObtenerClienteAdministracion().ActualizarAseguradora(aseguradora);
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}