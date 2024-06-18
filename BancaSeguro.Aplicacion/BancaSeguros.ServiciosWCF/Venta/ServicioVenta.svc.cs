//-----------------------------------------------------------------------
// <copyright file="ServicioVenta.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.ServiciosWCF.Venta
{
    using BancaSeguros.Aplicacion.Administracion;
    using BancaSeguros.Aplicacion.Cobis;
    using BancaSeguros.Aplicacion.Venta;
    using BancaSeguros.Entidades;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Repositorio.Venta;
    using Repositorio.Administracion;
    using Repositorio.Log;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.ServiceModel;
    using System.Web;
    using BancaSeguros.Aplicacion.ListasInhibitorias;

    /// <summary>
    /// Sale service Web methods
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 19/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public class ServicioVenta : IServicioVenta
    {
        #region Variables

        private IGestionCobis gestionCobis;
        private IGestionVenta gestionVenta;
        private Repositorio.Venta.IRepositorioSeguro repositorioSeguro;
        private IRepositorioVenta repositorioVenta;
        private Repositorio.Venta.IRepositorioPlan repositorioPlan;
        private IRepositorioProductoNoPermitido repositorioProductoNoPermitido;
        private IRepositorioDocumentoPoliza repositorioDocumentoPoliza;
        private IGestionAseguradora gestionAseguradora;
        private IGestionCategoria gestionCategoria;
        private IGestionProducto gestionProducto;
        private IRepositorioLogCobis repositorioLogCobis;
        private Repositorio.Administracion.IRepositorioAseguradora repositorioAseguradora;
        private IRepositorioCategoria repositorioCategoria;
        private IRepositorioProducto repositorioProducto;
        private IRepositorioLog repositorioLog;
        private IRepositorioMensaje repositorioMensaje;

        private IGestionListaInhibitoria gestionListaInhibitoria;

        #endregion

        #region Constructor

        public ServicioVenta()
        {
            this.repositorioSeguro = new Repositorio.Venta.RepositorioSeguro(Global.nombreConexionTeradata);
            this.repositorioVenta = new RepositorioVenta(Global.nombreConexionTeradata);
            this.repositorioPlan = new Repositorio.Venta.RepositorioPlan(Global.nombreConexionTeradata);
            this.repositorioProductoNoPermitido = new RepositorioProductoNoPermitido(Global.nombreConexionTeradata);
            this.repositorioDocumentoPoliza = new RepositorioDocumentoPoliza(Global.nombreConexionTeradata);
            this.repositorioLogCobis = new RepositorioLogCobis(Global.nombreConexionTeradata);
            this.repositorioAseguradora = new Repositorio.Administracion.RepositorioAseguradora(Global.nombreConexionTeradata);
            this.repositorioCategoria = new RepositorioCategoria(Global.nombreConexionTeradata);
            this.repositorioProducto = new RepositorioProducto(Global.nombreConexionTeradata);
            this.repositorioLog = new RepositorioLog(Global.nombreConexionTeradata);
            this.repositorioMensaje = new RepositorioMensaje(Global.nombreConexionTeradata);
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioMensaje = this.repositorioMensaje;
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioLog = this.repositorioLog;

            this.gestionCobis = new GestionCobis(this.repositorioLogCobis);
            this.gestionVenta = new GestionVenta(this.repositorioSeguro, this.repositorioVenta, this.repositorioPlan, this.repositorioProductoNoPermitido, this.repositorioDocumentoPoliza, this.repositorioLogCobis);
            this.gestionAseguradora = new GestionAseguradora(this.repositorioAseguradora);
            this.gestionCategoria = new GestionCategoria(this.repositorioCategoria);
            this.gestionProducto = new GestionProducto(this.repositorioProducto);

            this.gestionListaInhibitoria = new GestionListaInhibitoria();
        }

        #endregion

        #region Metodos publicos

        #region Cobis

        public Cliente ConsultarInformacionCliente(Cliente cliente, string usuario)
        {          
            return this.gestionCobis.ConsultarInformacionCliente(cliente, usuario);
        }

        public Cliente ConsultarInformacionClienteActual(Cliente cliente, string usuario, string token)
        {
            Cliente clienteResultado = this.gestionCobis.ConsultarInformacionCliente(cliente, usuario);
            if (!clienteResultado.Resultado.Error)
            {
                if (clienteResultado.Identificacion == null)
                    clienteResultado.Identificacion = cliente.Identificacion;
                
                clienteResultado.Resultado = this.gestionListaInhibitoria.ClienteEstaEnListasInhibitoriasActual(cliente, token);
            }
            return clienteResultado;


        }

        public Cliente ClienteEstaEnListasInhibitorias(Cliente cliente)
        {
            return this.gestionCobis.ClienteEstaEnListasInhibitorias(cliente);
        }

        public List<ProductoBancario> ConsultarProductosBancarios(Cliente cliente, string usuario)
        {
            return this.gestionCobis.ConsultarProductosBancarios(cliente, usuario);
        }

        public Resultado CreacionRapidaCliente(Cliente cliente, string usuario)
        {
            return this.gestionCobis.CreacionRapidaCliente(cliente, usuario);
        }

        public Resultado GenerarDebitoACuentaCliente(RegistrarVenta registrarVenta)
        {
            return this.gestionCobis.GenerarDebitoACuentaCliente(registrarVenta);
        }

        public Resultado GenerarCreditoACuentaAseguradora(RegistrarVenta registrarVenta)
        {
            return this.gestionCobis.GenerarCreditoACuentaAseguradora(registrarVenta);
        }

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
        public IEnumerable<Seguro> ConsultarLosSegurosAVender(int idTipoDeIdentificacion, DateTime fechaDeNacimientoCliente, int genero)
        {
            return this.gestionVenta.ConsultarLosSegurosAVender(idTipoDeIdentificacion, fechaDeNacimientoCliente, genero);
        }

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
        public Resultado ConsultarSegurosPorCodigoYAseguradora(int codigoSeguro, int codigoAseguradora)
        {
            return this.gestionVenta.ConsultarSegurosPorCodigoYAseguradora(codigoSeguro, codigoAseguradora);
        }


        public IEnumerable<Plan> ConsultarPlanesPorIdSeguro(int idSeguro)
        {
            return this.gestionVenta.ConsultarPlanesPorIdSeguro(idSeguro);
        }

        #endregion

        #region Aseguradora

        /// <summary>
        /// Consultars the aseguradoras activas.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Aseguradora> ConsultarAseguradorasActivas()
        {
            return this.gestionAseguradora.ConsultarAseguradorasActivas();
        }

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
        public IList<Categoria> ObtenerCategoriasPorIdSubProducto(int idSubProducto)
        {
            return this.gestionCategoria.ObtenerCategoriasPorIdSubProducto(idSubProducto);
        }

        #endregion

        #region Generar Venta

        public ResultadoVentaPoliza GenerarProcesoFinalDeLaVenta(RegistrarVenta registrarVenta)
        {
            return this.gestionVenta.GenerarProcesoFinalDeLaVenta(registrarVenta, gestionCobis);
        }

        /// <summary>
        /// Obtiene el documento de venta de poliza.
        /// </summary>
        /// <param name="consecutivoPoliza">consecutivo poliza.</param>
        /// <param name="idSeguro">identifier seguro.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 23/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>        
        public ResultadoDocumentoPoliza ObtenerDocumentoVentaPoliza(string consecutivoPoliza, int idSeguro)
        {
            var rutaArchivo = HttpContext.Current.Server.MapPath("../ArchivosPDF/");
            ResultadoDocumentoPoliza resultado = this.gestionVenta.ObtenerDocumentoVentaPoliza(consecutivoPoliza, idSeguro, rutaArchivo);
            rutaArchivo = ConfigurationManager.AppSettings.Get("RutaArchivos");
            rutaArchivo = rutaArchivo + consecutivoPoliza + ".pdf";
            //string applicationPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");
            //var context = OperationContext.Current;
            //var urlServer = context.IncomingMessageProperties.Via.AbsoluteUri.Replace(context.IncomingMessageProperties.Via.LocalPath, "/");
            //string url = resultado.RutaArchivo.Substring(applicationPath.Length).Replace('\\', '/').Insert(0, urlServer);
            resultado.RutaArchivo = rutaArchivo;
            return resultado;
        }

        /// <summary>
        /// Insertars the documento plantilla seguro.
        /// </summary>
        /// <param name="documentoPoliza">The documento poliza.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 16/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado InsertarDocumentoPlantillaSeguro(DocumentoPoliza documentoPoliza)
        {
            return this.InsertarDocumentoPlantillaSeguro(documentoPoliza);
        }

        #endregion

        #region Producto

        /// <summary>
        /// gets the products not allowed by insurance.
        /// </summary>
        /// <param name="idSeguro">The identifier insurance.</param>
        /// <returns>List of products not allowed</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 02/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IEnumerable<ProductoNoPermitido> ConsultarProductosNoPermitidosPorSeguro(int idSeguro)
        {
            return this.gestionVenta.ConsultarProductosNoPermitidosPorSeguro(idSeguro);
        }

        /// <summary>
        /// gets the subProductos by codigoProducto.
        /// </summary>
        /// <param name="codigoProducto">The codigoProducto.</param>
        /// <returns>list of SubProducts</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 02/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<SubProducto> ObtenerSubProductosPorCodigoProducto(int codigoProducto)
        {
            return this.gestionProducto.ObtenerSubProductosPorCodigoProducto(codigoProducto);
        }

        /// <summary>
        /// Gets the productos bancarios activos.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 06/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Producto> ObtenerProductosBancariosActivos()
        {
            return this.gestionProducto.ObtenerProductosBancariosActivos();
        }

        #endregion

        #region Consultar Venta

        public List<ConsultarVenta> ConsultarVentaPorCliente(Cliente cliente)
        {
            return this.gestionVenta.ConsultarVentaPorCliente(cliente);
        }

        public List<ConsultarVenta> ConsultarVentaPorClienteDiaHabil(Cliente cliente)
        {
            return this.gestionVenta.ConsultarVentaPorClienteDiaHabil(cliente);
        }

        /// <summary>
        /// Obtiene el documento de venta de poliza.
        /// </summary>
        /// <param name="consecutivoPoliza">consecutivo poliza.</param>
        /// <param name="idSeguro">identifier seguro.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 23/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>        
        public ResultadoDocumentoPoliza ConsultarPolizaReimpresion(string consecutivoPoliza)
        {
            var rutaArchivo = HttpContext.Current.Server.MapPath("../ArchivosPDF/");
            ResultadoDocumentoPoliza resultado = this.gestionVenta.ConsultarPolizaReimpresion(consecutivoPoliza, rutaArchivo);            
            rutaArchivo = ConfigurationManager.AppSettings.Get("RutaArchivos");
            rutaArchivo = rutaArchivo+consecutivoPoliza+".pdf";
            //string applicationPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");
            //var context = OperationContext.Current;
            //var urlServer = context.IncomingMessageProperties.Via.AbsoluteUri.Replace(context.IncomingMessageProperties.Via.LocalPath, "/");
            //string url = resultado.RutaArchivo.Substring(applicationPath.Length).Replace('\\', '/').Insert(0, urlServer);
            resultado.RutaArchivo = rutaArchivo;
            return resultado;
        }

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
        public Resultado ConsultarVentasCuentasPorCliente(Cliente cliente)
        {
            return this.gestionVenta.ConsultarVentasCuentasPorCliente(cliente);
        }

        #endregion

        #endregion
    }
}
