// --------------------------------
// <copyright file="ReImpresionPoliza.aspx.cs" company="InterGrupo S.A.">
//     COPYRIGHT(C) 2016, Intergrupo S.A
// </copyright>
// ---------------------------------
namespace BancaSegurosUI.Venta
{
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
    /// CodeBehind para la reimpresion de la poliza
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 25/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public partial class ReImpresionPoliza : System.Web.UI.Page
    {
        /// <summary>
        /// The LST polizas
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static List<BancaSeguros.Entidades.Venta.ConsultarVenta> listaPolizas;

        /// <summary>
        /// Consulta la venta por cliente.
        /// </summary>
        /// <param name="cliente">Objeto cliente.</param>
        /// <param name="asesor">login asesor.</param>
        /// <returns>Lista ConsultarVenta</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<BancaSeguros.Entidades.Venta.ConsultarVenta> ConsultarVentaPorCliente(Cliente cliente, string asesor)
        {
            var lstPolizasAux = new List<BancaSeguros.Entidades.Venta.ConsultarVenta>();
            listaPolizas = AdministradorProxy.ObtenerClienteVenta().ConsultarVentaPorClienteDiaHabil(cliente);
            if (listaPolizas.First().Resultado.Error)
            {
                listaPolizas.First().Resultado.Mensaje += "<br/><br/>Los parámetros de búsqueda son: <br/><br/>" +
                                                         "Número de identificación: " + cliente.Identificacion + "<br/>" +
                                                         "Tipo de identificación: " + cliente.TipoIdentificacion.IdTipoIdentificacion + "<br/>" +
                                                         "Usuario: " + asesor;
                return listaPolizas;
            }
            else            
                listaPolizas = listaPolizas.FindAll(x => x.DatosVenta.Asesor.IdAsesor.ToLower() == asesor.ToLower());
            

            return listaPolizas;
        }

        /// <summary>
        /// Consulta la poliza reimpresion.
        /// </summary>
        /// <param name="consecutivoPoliza">Consecutivo de la poliza.</param>
        /// <returns>Objeto ResultadoDocumentoPoliza</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static ResultadoDocumentoPoliza ConsultarPolizaReimpresion(string consecutivoPoliza)
        {
            ResultadoDocumentoPoliza resultadoDocumentoPoliza = new ResultadoDocumentoPoliza();
            try
            {
                resultadoDocumentoPoliza = AdministradorProxy.ObtenerClienteVenta().ConsultarPolizaReimpresion(consecutivoPoliza);

                if (resultadoDocumentoPoliza.Resultado.Error)
                {
                    return resultadoDocumentoPoliza;
                }            
            }
            catch (Exception exc)
            {
                resultadoDocumentoPoliza.Resultado = AdministradorProxy.ObtenerClienteGenerico().GuardarError(Int32.Parse(LlavesUI.EventoPlantilla), exc.ToString(), LlavesUI.CatchReimpresion);
            }

            return resultadoDocumentoPoliza;
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}