using BancaSeguros.Entidades.Catalogo;
using BancaSeguros.Entidades.General;
using BancaSeguros.Entidades.Planos;
using BancaSeguros.Entidades.Seguro;
using BancaSegurosUI.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancaSegurosUI.Administracion
{
    public partial class ParametrizacionPlanos : System.Web.UI.Page
    {
        /// <summary>
        /// The insurances
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static List<Aseguradora> aseguradoras;

        /// <summary>
        /// Search the insurances.
        /// </summary>
        /// <param name="aseguradora">The insurance.</param>
        /// <returns>List of insurances</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<Aseguradora> ConsultarAseguradoras()
        {
            aseguradoras = AdministradorProxy.ObtenerClienteAdministracion().ConsultarAseguradorasActivas();
            return aseguradoras;
        }

        /// <summary>
        /// Search the name of Columns Poliza.
        /// </summary>
        /// <param name="aseguradora">The name of Columns Poliza.</param>
        /// <returns>List of name of Columns Poliza</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<CamposPoliza> ConsultarPolizas(int opcion)
        {
            List<CamposPoliza> camposPoliza = new List<CamposPoliza>();
            camposPoliza = AdministradorProxy.ObtenerClienteAdministracion().ConsultarPolizas(opcion);
            return camposPoliza;
        }

        /// <summary>
        /// Search the name of Columns Cobros.
        /// </summary>
        /// <param name="aseguradora">The name of Columns Cobros.</param>
        /// <returns>List of name of Columns Cobros</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<CamposCobros> ConsultarCobros(int opcion)
        {
            List<CamposCobros> camposCobros = new List<CamposCobros>();
            camposCobros = AdministradorProxy.ObtenerClienteAdministracion().ConsultarCobros(opcion);
            return camposCobros;
        }

        /// <summary>
        /// Search the name of Columns Cancel.
        /// </summary>
        /// <param name="aseguradora">The name of Columns Cancel.</param>
        /// <returns>List of name of Columns Cancel</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<CamposCancelaciones> ConsultarCancelaciones(int opcion)
        {
            List<CamposCancelaciones> camposCancel = new List<CamposCancelaciones>();
            camposCancel = AdministradorProxy.ObtenerClienteAdministracion().ConsultarCancelaciones(opcion);
            return camposCancel;
        }

        /// <summary>
        /// Search the filters of Cancelation
        /// </summary>
        /// <param name="aseguradora">The the filters of Cancelation.</param>
        /// <returns>List of the filters of Cancelation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<CamposCancelaciones> ConsultarFiltrosCancelaciones()
        {
            List<CamposCancelaciones> filtrosCancel = new List<CamposCancelaciones>();
            filtrosCancel = AdministradorProxy.ObtenerClienteAdministracion().ConsultarFiltrosCancelaciones();
            return filtrosCancel;
        }

        /// <summary>
        /// Insert the data of File
        /// </summary>
        /// <param name="aseguradora">The the filters of Cancelation.</param>
        /// <returns>List of the filters of Cancelation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 15/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado GuardarDatosArchivoPlano(ArchivoPlano datosArchivo)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
               datosArchivo.Usuario = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }
            Resultado guardarDatos = new Resultado();
            guardarDatos = AdministradorProxy.ObtenerClienteAdministracion().GuardarDatosArchivoPlano(datosArchivo);
            return guardarDatos;
        }

        /// <summary>
        /// Search the data for fill the Grid
        /// </summary>
        /// <param name="novedad">the data for fill the Grid</param>
        /// <returns>data</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 18/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]

        public static List<ArchivoPlano> ConsultarDatosGrilla()
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarDatosGrilla();
        }


        /// <summary>
        /// Update the data of File
        /// </summary>
        /// <param name="aseguradora">The the filters of Cancelation.</param>
        /// <returns>List of the filters of Cancelation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 19/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado ActualizarDatosArchivoPlano(ArchivoPlano datosArchivo)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                datosArchivo.Usuario = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }
            return AdministradorProxy.ObtenerClienteAdministracion().ActualizarDatosArchivoPlano(datosArchivo);
        }

        /// <summary>
        /// Delete the data of File
        /// </summary>
        /// <param name="aseguradora">The the filters of Cancelation.</param>
        /// <returns>List of the filters of Cancelation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 19/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado EliminarDatosArchivoPlano(int idProgramacion)
        {
            string Usuario = string.Empty;
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                Usuario = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }
            return AdministradorProxy.ObtenerClienteAdministracion().EliminarDatosArchivoPlano(idProgramacion, Usuario);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}