//-----------------------------------------------------------------------
// <copyright file="ConsultarVenta.aspx.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSegurosUI.Venta
{
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Services;
    using System.Web.Services;
    using BancaSeguros.Entidades.Venta;
    using BancaSegurosUI.App_Code;

    /// <summary>
    /// class consult sale
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 21/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class ConsultarVenta : System.Web.UI.Page
    {
        /// <summary>
        /// The list policy
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static List<BancaSeguros.Entidades.Venta.ConsultarVenta> lstPolizas;

        /// <summary>
        /// Consult the sale of client.
        /// </summary>
        /// <param name="cliente">The client.</param>
        /// <returns>Entity consult sale</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<BancaSeguros.Entidades.Venta.ConsultarVenta> ConsultarVentaPorCliente(Cliente cliente)
        {
            lstPolizas = AdministradorProxy.ObtenerClienteVenta().ConsultarVentaPorCliente(cliente);
            return lstPolizas;
        }

        /// <summary>
        /// Consult the detail policy of identifier sale.
        /// </summary>
        /// <param name="identificacionVenta">The identifier sale.</param>
        /// <returns>List entity consult</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static BancaSeguros.Entidades.Venta.ConsultarVenta ConsultarDetallePolizaPorIdVenta(int identificacionVenta)
        {
            BancaSeguros.Entidades.Venta.ConsultarVenta detallePoliza = new BancaSeguros.Entidades.Venta.ConsultarVenta();

            if (lstPolizas != null)
            {
                detallePoliza = lstPolizas.Find(x => x.DatosVenta.IdVenta == identificacionVenta);
            }

            return detallePoliza;
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}