//-----------------------------------------------------------------------
// <copyright file="IServicioVenta.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.ServiciosWCF.Venta
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades;

    [ServiceContract]
    public interface IServicioVenta
    {
        #region Cobis

        [OperationContract]
        Cliente ConsultarInformacionCliente(Cliente usuario, string userName);

        [OperationContract]
        Cliente ClienteEstaEnListasInhibitorias(Cliente usuario);

        [OperationContract]
        List<ProductoBancario> ConsultarProductosBancarios(Cliente cliente, string usuario);

        [OperationContract]
        Resultado CreacionRapidaCliente(Cliente cliente, string userName);

        [OperationContract]
        Resultado GenerarDebitoACuentaCliente(RegistrarVenta registrarVenta);

        [OperationContract]
        Resultado GenerarCreditoACuentaAseguradora(RegistrarVenta registrarVenta);

        [OperationContract]
        Cliente ConsultarInformacionClienteActual(Cliente cliente, string usuario, string token);

        #endregion

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
        [OperationContract]
        IEnumerable<Seguro> ConsultarLosSegurosAVender(int idTipoDeIdentificacion, DateTime fechaDeNacimientoCliente, int genero);

        /// <summary>
        /// Get the sure of code y insurance.
        /// </summary>
        /// <param name="codigoSeguro">The code sure.</param>
        /// <param name="codigoAseguradora">The code insurance.</param>
        /// <returns>List entity sure</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        Resultado ConsultarSegurosPorCodigoYAseguradora(int codigoSeguro, int codigoAseguradora);

        [OperationContract]
        IEnumerable<Plan> ConsultarPlanesPorIdSeguro(int idSeguro);

        #endregion

        #region Generar Venta

        [OperationContract]
        ResultadoVentaPoliza GenerarProcesoFinalDeLaVenta(RegistrarVenta registrarVenta);

        /// <summary>
        /// Obtiene el documento venta poliza.
        /// </summary>
        /// <param name="consecutivoPoliza">consecutivo poliza.</param>
        /// <param name="idSeguro">identifier seguro.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 23/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        ResultadoDocumentoPoliza ObtenerDocumentoVentaPoliza(string consecutivoPoliza, int idSeguro);

        /// <summary>
        /// Gets active insurances.
        /// </summary>
        /// <returns>List of active insurances.</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        IList<Aseguradora> ConsultarAseguradorasActivas();

        #endregion

        #region Categoria

        /// <summary>
        /// Gets categories by subproducto identifier.
        /// </summary>
        /// <param name="idSubProducto">The identifier sub producto.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        IList<Categoria> ObtenerCategoriasPorIdSubProducto(int idSubProducto);

        #endregion

        #region Producto
        [OperationContract]
        IEnumerable<ProductoNoPermitido> ConsultarProductosNoPermitidosPorSeguro(int idSeguro);

        [OperationContract]
        IList<SubProducto> ObtenerSubProductosPorCodigoProducto(int codigoProducto);

        [OperationContract]
        IList<Producto> ObtenerProductosBancariosActivos();
        #endregion

        #region Consultar Venta

        [OperationContract]
        List<ConsultarVenta> ConsultarVentaPorCliente(Cliente cliente);

        /// <summary>
        /// Obtiene las polizas vendidas en dia habil
        /// </summary>
        /// <param name="Cliente">Cliente</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\Paulo mora
        /// CreationDate: 28/11/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        List<ConsultarVenta> ConsultarVentaPorClienteDiaHabil(Cliente cliente);

        /// <summary>
        /// Obtiene el documento venta poliza.
        /// </summary>
        /// <param name="consecutivoPoliza">consecutivo poliza.</param>
        /// <param name="idSeguro">identifier seguro.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 23/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        ResultadoDocumentoPoliza ConsultarPolizaReimpresion(string consecutivoPoliza);

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
        [OperationContract]
        Resultado ConsultarVentasCuentasPorCliente(Cliente cliente);

            #endregion
        }
}
