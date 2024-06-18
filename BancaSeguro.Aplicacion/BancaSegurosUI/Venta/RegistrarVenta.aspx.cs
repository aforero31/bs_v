//-----------------------------------------------------------------------
// <copyright file="RegistrarVenta.aspx.cs" company="UT">
//     Copyright (c) UT. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSegurosUI.Venta
{
    using BAC.EntidadesSeguridad;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;
    using BancaSegurosUI.App_Code;
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Script.Services;
    using System.Web.Services;

    /// <summary>
    /// Class Register sale
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 10/06/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class RegistrarVenta : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region Catalogos

        /// <summary>
        /// Get the catalog.
        /// </summary>
        /// <param name="NombreTabla">The name table.</param>
        /// <returns>Entity class catalog</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static DtoCatalogo ConsultarCatalogo(string NombreTabla)
        {
            return AdministradorProxy.ObtenerClienteGenerico().ConsultarCatalogo(NombreTabla);
        }

        #endregion Catalogos

        #region Eventos

        /// <summary>
        /// search the client.
        /// </summary>
        /// <param name="cliente">The client.</param>
        /// <returns>Entity client</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Cliente BuscarCliente(Cliente cliente)
        {
            string usuario = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            string token = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Token.ToString();
            return AdministradorProxy.ObtenerClienteVenta().ConsultarInformacionClienteActual(cliente, usuario, token);
        }

        /// <summary>
        /// get the sure of sale.
        /// </summary>
        /// <param name="idTipoDeIdentificacion">The identifier type of identification.</param>
        /// <param name="fechaDeNacimientoCliente">The date birth client.</param>
        /// <param name="genero">The gender.</param>
        /// <returns>Entity List sure</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<Seguro> ConsultarLosSegurosAVender(int idTipoDeIdentificacion, DateTime fechaDeNacimientoCliente, int genero)
        {
            return AdministradorProxy.ObtenerClienteVenta().ConsultarLosSegurosAVender(idTipoDeIdentificacion, fechaDeNacimientoCliente, genero);
        }

        /// <summary>
        /// Get the plan of identifier sure.
        /// </summary>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <returns>Entity list plan</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<Plan> ConsultarPlanesPorIdSeguro(int idSeguro)
        {
            return AdministradorProxy.ObtenerClienteVenta().ConsultarPlanesPorIdSeguro(idSeguro);
        }

        /// <summary>
        /// Get the products banking.
        /// </summary>
        /// <param name="cliente">The client.</param>
        /// <returns>Entity list products banking</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<ProductoBancario> ConsultarProductosBancarios(Cliente cliente)
        {
            string usuario = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            return AdministradorProxy.ObtenerClienteVenta().ConsultarProductosBancarios(cliente, usuario);
        }

        /// <summary>
        /// Get the data adviser.
        /// </summary>
        /// <param name="asesor">The adviser.</param>
        /// <returns>Entity adviser</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Asesor ConsultarDatosAsesor(Asesor asesor)
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ConsultarAsesor(asesor);
        }

        /// <summary>
        /// Get the office of code.
        /// </summary>
        /// <param name="idOficina">The identifier office.</param>
        /// <returns>Entity office</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static BAC.EntidadesSeguridad.Oficina ConsultarOficinaPorCodigo(int idOficina)
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ConsultarOficinaPorCodigo(idOficina);
        }

        /// <summary>
        /// Create the fast client.
        /// </summary>
        /// <param name="cliente">The client.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static BancaSeguros.Entidades.General.Resultado CreacionRapidaCliente(BancaSeguros.Entidades.Venta.Cliente cliente)
        {
            string usuario = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            return AdministradorProxy.ObtenerClienteVenta().CreacionRapidaCliente(cliente, usuario);
        }

        /// <summary>
        /// Generate the process end of the sale.
        /// </summary>
        /// <param name="registrarVenta">To register sale.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static ResultadoVentaPoliza GenerarProcesoFinalDeLaVenta(BancaSeguros.Entidades.Venta.RegistrarVenta registrarVenta)
        {
            //Reemplazo sin caracter de escape
            registrarVenta.Cliente.DepartamentoResidencia = registrarVenta.Cliente.DepartamentoResidencia.Replace("<FONT STYLE='VERTICAL-ALIGN: INHERIT;'><FONT STYLE", "");
            registrarVenta.Cliente.DepartamentoResidencia = registrarVenta.Cliente.DepartamentoResidencia.Replace("<fontstyle='vertical-align:inherit;'><fontstyle", "");
            
            registrarVenta.Cliente.Celular = registrarVenta.Cliente.Celular.Replace("<FONT STYLE='VERTICAL-ALIGN: INHERIT;'><FONT STYLE", "");
            registrarVenta.Cliente.Celular = registrarVenta.Cliente.Celular.Replace("<fontstyle='vertical-align:inherit;'><fontstyle", "");

            registrarVenta.Cliente.CodigoDANE = registrarVenta.Cliente.CodigoDANE.Replace("<FONT STYLE='VERTICAL-ALIGN: INHERIT;'><FONT STYLE", "");
            registrarVenta.Cliente.CodigoDANE = registrarVenta.Cliente.CodigoDANE.Replace("<fontstyle='vertical-align:inherit;'><fontstyle", "");

            registrarVenta.Cliente.ActividadEconomica = registrarVenta.Cliente.ActividadEconomica.Replace("<FONT STYLE='VERTICAL-ALIGN: INHERIT;'><FONT STYLE", "");
            registrarVenta.Cliente.ActividadEconomica = registrarVenta.Cliente.ActividadEconomica.Replace("<fontstyle='vertical-align:inherit;'><fontstyle", "");

            //Reemplazo con caracter de escape
            registrarVenta.Cliente.DepartamentoResidencia = registrarVenta.Cliente.DepartamentoResidencia.Replace("<FONT STYLE=\"VERTICAL-ALIGN: INHERIT;\"><FONT STYLE", "");
            registrarVenta.Cliente.DepartamentoResidencia = registrarVenta.Cliente.DepartamentoResidencia.Replace("<fontstyle=\"vertical-align:inherit;\"><fontstyle", "");

            registrarVenta.Cliente.Celular = registrarVenta.Cliente.Celular.Replace("<FONT STYLE=\"VERTICAL-ALIGN: INHERIT;\"><FONT STYLE", "");
            registrarVenta.Cliente.Celular = registrarVenta.Cliente.Celular.Replace("<fontstyle=\"vertical-align:inherit;\"><fontstyle", "");

            registrarVenta.Cliente.CodigoDANE = registrarVenta.Cliente.CodigoDANE.Replace("<FONT STYLE=\"VERTICAL-ALIGN: INHERIT;\"><FONT STYLE", "");
            registrarVenta.Cliente.CodigoDANE = registrarVenta.Cliente.CodigoDANE.Replace("<fontstyle=\"vertical-align:inherit;\"><fontstyle", "");

            registrarVenta.Cliente.ActividadEconomica = registrarVenta.Cliente.ActividadEconomica.Replace("<FONT STYLE=\"VERTICAL-ALIGN: INHERIT;\"><FONT STYLE", "");
            registrarVenta.Cliente.ActividadEconomica = registrarVenta.Cliente.ActividadEconomica.Replace("<fontstyle=\"vertical-align:inherit;\"><fontstyle", "");

            
            string usuario = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();

            return AdministradorProxy.ObtenerClienteVenta().GenerarProcesoFinalDeLaVenta(registrarVenta);
        }

        /// <summary>
        /// Get the product not allowed of sure.
        /// </summary>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <returns>Entity list product not allowed</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IEnumerable<ProductoNoPermitido> ConsultarProductosNoPermitidosPorSeguro(int idSeguro)
        {
            return AdministradorProxy.ObtenerClienteVenta().ConsultarProductosNoPermitidosPorSeguro(idSeguro);
        }

        /// <summary>
        /// Get the document sale policy.
        /// </summary>
        /// <param name="consecutivoPoliza">The consecutive policy.</param>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static ResultadoDocumentoPoliza ObtenerDocumentoVentaPoliza(string consecutivoPoliza, int idSeguro)
        {
            ResultadoDocumentoPoliza resultadoDocumentoPoliza = new ResultadoDocumentoPoliza();
            try
            {
                resultadoDocumentoPoliza = AdministradorProxy.ObtenerClienteVenta().ObtenerDocumentoVentaPoliza(consecutivoPoliza, idSeguro);
                if (resultadoDocumentoPoliza.Resultado.Error)
                {
                    return resultadoDocumentoPoliza;
                }
            }
            catch (Exception ex)
            {
                resultadoDocumentoPoliza.Resultado = new BancaSeguros.Entidades.General.Resultado() { Error = true, Mensaje = ex.Message };
                //Guardar en Base de datos el Error
            }

            return resultadoDocumentoPoliza;
        }

        /// <summary>
        /// Search the variables active product.
        /// </summary>
        /// <param name="idSeguro">The identifier seguro.</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IList<VariableProducto> ConsultarVariablesActivasProducto(int idSeguro)
        {
            VariableProducto variableBusqueda = new VariableProducto();
            variableBusqueda.IdSeguro = idSeguro;
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarVariablesProductoActivas(variableBusqueda);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static BancaSeguros.Entidades.General.Resultado ConsultarVentasCuentasPorCliente(Cliente cliente)
        {
            return AdministradorProxy.ObtenerClienteVenta().ConsultarVentasCuentasPorCliente(cliente);
        }

        #endregion Eventos
    }
}