//-----------------------------------------------------------------------
// <copyright file="ParametrizacionProducto.aspx.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSegurosUI.Administracion
{
    using BancaSeguros.Entidades.Administracion;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;
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
    /// Code behind 
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 05/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public partial class ParametrizacionProducto : System.Web.UI.Page
    {
        /// <summary>
        /// Called when [agreement of insurance].
        /// </summary>
        /// <param name="idAseguradora">The identifier insurance.</param>
        /// <returns>List Entity agreement</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<Convenio> ObtenerConveniosPorAseguradora(int idAseguradora)
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarConveniosPorIdAseguradora(idAseguradora).ToList();
        }

        /// <summary>
        /// Get channel sale
        /// </summary>
        /// <returns>Entity channel sale</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<CanalVenta> ObtenerCanalesVenta()
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ObtenerCanalesVentaActivos();
        }

        /// <summary>
        /// Get insurance
        /// </summary>
        /// <returns>Entity list insurance</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<Aseguradora> ObtenerAseguradoras()
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarAseguradoras(new Aseguradora(){Activo = true});
        }

        /// <summary>
        /// Called when [periodicity].
        /// </summary>
        /// <returns>Entity list periodicity</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 06/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<Periodicidad> ObtenerPeriodicidad()
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ObtenerPeriodicidadesActivas();
        }

        /// <summary>
        /// Obteners the productos.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 06/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<Producto> ObtenerProductos()
        {
            return AdministradorProxy.ObtenerClienteVenta().ObtenerProductosBancariosActivos();
        }

        /// <summary>
        /// gets the subproductos by producto.
        /// </summary>
        /// <param name="codigoProducto">The codigo producto.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 06/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<SubProducto> ObtenerSubProductosPorProducto(int codigoProducto)
        {
            return AdministradorProxy.ObtenerClienteVenta().ObtenerSubProductosPorCodigoProducto(codigoProducto);        
        }
        
        /// <summary>
        /// gets the subproductos by producto.
        /// </summary>
        /// <param name="codigoProducto">The codigo producto.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 06/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<Categoria> ObtenerCategoriasPorSubProductos(int idSubProducto)
        {
            return AdministradorProxy.ObtenerClienteVenta().ObtenerCategoriasPorIdSubProducto(idSubProducto);
        }

        /// <summary>
        /// Saves a insurance
        /// </summary>
        /// <param name="parametrizacionSeguro"></param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado InsertarSeguro(ParametrizacionSeguro parametrizacionSeguro)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                parametrizacionSeguro.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }

            return AdministradorProxy.ObtenerClienteAdministracion().GuardarSeguro(parametrizacionSeguro);
        }

        /// <summary>
        /// Get all sure
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<Seguro> ConsultarTodosLosSeguros()
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarTodosLosSeguros();
        }

        /// <summary>
        /// get the sure of parameters.
        /// </summary>
        /// <param name="nombreProducto">The name sure.</param>
        /// <param name="codigoProducto">The code sure.</param>
        /// <param name="nombreAseguradora">The name insurance.</param>
        /// <returns>List entity sure</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 06/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<Seguro> ConsultarSegurosPorParametros(string nombreProducto, int codigoProducto, string nombreAseguradora)
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarSegurosPorParametros(nombreProducto, codigoProducto, nombreAseguradora);
        }

        
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<DocumentoPoliza> ConsultarPlantillasActivas()
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarPlantillasActivas();
        }

        /// <summary>
        /// Update Sure of identifier
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado ActualizarSeguroPorId(ParametrizacionSeguro parametrizacionSeguro)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                parametrizacionSeguro.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }

            return AdministradorProxy.ObtenerClienteAdministracion().ActualizarSeguroPorId(parametrizacionSeguro);
        }

        /// <summary>
        /// Get all sure of identifier
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static ParametrizacionSeguro ConsultarInformacionSeguroPorId(int idSeguro)
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarInformacionSeguroPorId(idSeguro);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado ConsultarSegurosPorCodigoYAseguradora(int codigoSeguro, int codigoAseguradora)
        {
            return AdministradorProxy.ObtenerClienteVenta().ConsultarSegurosPorCodigoYAseguradora(codigoSeguro, codigoAseguradora);
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}