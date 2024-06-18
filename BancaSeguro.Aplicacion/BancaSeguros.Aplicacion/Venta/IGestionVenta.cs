//-----------------------------------------------------------------------
// <copyright file="IGestionVenta.cs" company="UT">
//     Copyright (c) UT. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Venta
{
    using System;
    using System.Collections.Generic;
    using BancaSeguros.Aplicacion.Cobis;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;
    using Entidades.General;

    /// <summary>
    /// Interface Management sale
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 26/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionVenta
    {
        #region Seguro

        /// <summary>
        /// Get los sure a sale.
        /// </summary>
        /// <param name="idTipoDeIdentificacion">identification number.</param>
        /// <param name="fechaDeNacimientoCliente">date client.</param>
        /// <param name="genero">gender.</param>
        /// <returns>
        /// List Entity sure
        /// </returns>
        /// <remarks>
        /// Author: Wilver Guillermo Zaldua
        /// CreationDate: 09/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IEnumerable<Seguro> ConsultarLosSegurosAVender(int idTipoDeIdentificacion, DateTime fechaDeNacimientoCliente, int genero);

        /// <summary>
        /// Get the sure of code y insurance.
        /// </summary>
        /// <param name="codigoSeguro">The code sure.</param>
        /// <param name="codigoAseguradora">The code insurance.</param>
        /// <returns>entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado ConsultarSegurosPorCodigoYAseguradora(int codigoSeguro, int codigoAseguradora);

        #endregion

        #region Generar Venta

        /// <summary>
        /// Generar el proceso final de la venta.
        /// </summary>
        /// <param name="registrarVenta">The registrar venta.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 24/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        ResultadoVentaPoliza GenerarProcesoFinalDeLaVenta(RegistrarVenta registrarVenta, IGestionCobis gestionCobis);

        ResultadoDocumentoPoliza ObtenerDocumentoVentaPoliza(string consecutivoPoliza, int idSeguro, string rutaArchivo);

        #endregion

        #region Plan

        IEnumerable<Plan> ConsultarPlanesPorIdSeguro(int idSeguro);

        #endregion

        #region Productos

        IEnumerable<ProductoNoPermitido> ConsultarProductosNoPermitidosPorSeguro(int idSeguro);

        #endregion

        #region Consultar Venta

        List<ConsultarVenta> ConsultarVentaPorCliente(Cliente cliente);

        List<ConsultarVenta> ConsultarVentaPorClienteDiaHabil(Cliente cliente);

        ResultadoDocumentoPoliza ConsultarPolizaReimpresion(string consecutivoPoliza, string rutaArchivo);

        /// <summary>
        /// Get the sale account of client.
        /// </summary>
        /// <param name="cliente">The client.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado ConsultarVentasCuentasPorCliente(Cliente cliente);

        #endregion
    }
}
