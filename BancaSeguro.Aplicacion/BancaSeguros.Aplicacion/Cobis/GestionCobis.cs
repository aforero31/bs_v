//-----------------------------------------------------------------------
// <copyright file="GestionCobis.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Cobis
{
    using BancaSeguros.Aplicacion.Configuraciones;
    using BancaSeguros.Aplicacion.ListasInhibitorias;
    using BancaSeguros.Aplicacion.ServicioCobisConvenio;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Repositorio.Venta;
    using Repositorio.Log;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.ServiceModel;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Management class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 29/06/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Aplicacion.Cobis.IGestionCobis" />
    public class GestionCobis : IGestionCobis
    {
        #region Variables

        /// <summary>
        /// User name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string userName;

        /// <summary>
        /// Contexto transaccional cliente
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private ServicioCobisCliente.ContextoTransaccional contextoTransaccionalCliente;

        /// <summary>
        /// Identidad persona cliente
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private ServicioCobisCliente.IdentidadPersona identidadPersonaCliente;

        /// <summary>
        /// Arreglo Cliente
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private ServicioCobisCliente.Cliente[] cliente;

        /// <summary>
        /// Contexto respuesta cliente
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private ServicioCobisCliente.ContextoRespuesta contextoRespuestaCliente;

        /// <summary>
        /// Repositorio log
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioLogCobis repositorioLogCobis;

        private string Request { get; set; }
        private string Response { get; set; }
        private string TipoTransaccion { get; set; }
        private string HoraRequest { get; set; }
        private string usuario { get; set; }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GestionCobis"/>
        /// </summary>
        /// <param name="repositorioLog">The repositorio log.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public GestionCobis(IRepositorioLogCobis repositorioLogCobis)
        {
            this.repositorioLogCobis = repositorioLogCobis;
            Request = string.Empty;
            Response = string.Empty;
            TipoTransaccion = string.Empty;
        }

        #endregion Constructor

        #region Metodos Publicos Cobis

        /// <summary>
        /// Consulta la informacion del cliente.
        /// </summary>
        /// <param name="cliente">Objeto cliente.</param>
        /// <param name="usuario">login usuario.</param>
        /// <returns>Objeto cliente</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Cliente ConsultarInformacionCliente(Cliente cliente, string usuario)
        {
            var datosLog = new LogCobis();
            userName = usuario;
            Cliente clienteDevuelto = new Cliente();
            clienteDevuelto.Resultado = new Resultado();
            this.contextoTransaccionalCliente = this.VariablesContextoTransaccional();
            this.identidadPersonaCliente = this.VariablesIdentidadPersona(cliente);
            try
            {
                clienteDevuelto = this.COBISConsultarInformacionCliente(userName, cliente.TipoCliente);
                //// Llamar nuevo ConsultaListaInhibitoria
                //if (!clienteDevuelto.Resultado.Error)
                //{
                //    if (clienteDevuelto.Identificacion == null)
                //        clienteDevuelto.Identificacion = cliente.Identificacion;

                //    string token = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Token.ToString();
                //    clienteDevuelto = GestionListaInhibitoria.ClienteEstaEnListasInhibitoriasActual(clienteDevuelto, token);
                //}
            }
            catch (FaultException<ServicioCobisCliente.ContextoRespuesta> e)
            {
                datosLog.HoraRequest = HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.XmlRequest = Request;
                datosLog.XmlResponse = Response;
                datosLog.TipoTransaccion = TipoTransaccion;
                datosLog.HoraResponse = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.Usuario = usuario;
                this.repositorioLogCobis.GuardarDatosLogEnTablaLogCobis(datosLog);
                clienteDevuelto.Resultado = this.BuscarErrorAPresentar(e);
            }
            catch (Exception ex)
            {
                datosLog.HoraRequest = HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.XmlRequest = Request;
                datosLog.XmlResponse = Mensajes.ErrorConvenio + ex.Message;
                datosLog.TipoTransaccion = TipoTransaccion;
                datosLog.HoraResponse = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.Usuario = usuario;
                this.repositorioLogCobis.GuardarDatosLogEnTablaLogCobis(datosLog);
                var controlError = LlavesAplicacion.COBIS_ExepcionCIC;
                clienteDevuelto = new Cliente();
                clienteDevuelto.Resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarCliente), ex, controlError);
            }
            return clienteDevuelto;
        }

        /// <summary>
        /// Consulta si el cliente esta en listas inhibitorias.
        /// </summary>
        /// <param name="cliente">Objeto Cliente.</param>
        /// <returns>Objeto cliente</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Cliente ClienteEstaEnListasInhibitorias(Cliente cliente)
        {
            Resultado resultado = new Resultado();
            var datosLog = new LogCobis(); ;
            ServicioCobisListasInhibitorias.ContextoTransaccional contextoTransaccional = new ServicioCobisListasInhibitorias.ContextoTransaccional();
            contextoTransaccional.identificadorTransaccional = ConfigurationManager.AppSettings.Get(Parametros.IdentificadorTransaccional);
            contextoTransaccional.codCanalOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoCanalOriginador);
            contextoTransaccional.codFuncionalidadOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoProcesoOriginador);
            contextoTransaccional.codProcesoOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoFuncionalidadOriginador);
            contextoTransaccional.ipConsumidor = ConfigurationManager.AppSettings.Get(Parametros.ipConsumidor);
            contextoTransaccional.fecTransaccion = DateTime.Now;
            ServicioCobisListasInhibitorias.FiltroInhibitoria filtroInhibitoria = new ServicioCobisListasInhibitorias.FiltroInhibitoria();

            try
            {
                filtroInhibitoria.valNumeroDocumento = cliente.Identificacion;
                resultado = this.COBISConsultarListasInhibitorias(contextoTransaccional, filtroInhibitoria);
                cliente.Resultado = resultado;
            }
            catch (FaultException<ServicioCobisListasInhibitorias.ContextoRespuesta> faultException)
            {
                datosLog.HoraRequest = HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.XmlRequest = Request;
                datosLog.XmlResponse = Response;
                datosLog.TipoTransaccion = TipoTransaccion;
                datosLog.HoraResponse = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.Usuario = userName;
                this.repositorioLogCobis.GuardarDatosLogEnTablaLogCobis(datosLog);
                cliente.Resultado = this.BuscarErrorAPresentar(faultException);
            }
            catch (Exception ex)
            {
                datosLog.HoraRequest = HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.XmlRequest = Request;
                datosLog.XmlResponse = Mensajes.ErrorConvenio + ex;
                datosLog.TipoTransaccion = TipoTransaccion;
                datosLog.HoraResponse = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.Usuario = userName;
                this.repositorioLogCobis.GuardarDatosLogEnTablaLogCobis(datosLog);
                var controlError = LlavesAplicacion.COBIS_ExepcionCELI;
                cliente = new Cliente();
                cliente.Resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarCliente), ex, controlError);
            }

            return cliente;
        }

        /// <summary>
        /// Consulta los productos bancarios.
        /// </summary>
        /// <param name="cliente">Objeto cliente.</param>
        /// <param name="usuario">login usuario.</param>
        /// <returns>Lista de ProductoBancario</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<ProductoBancario> ConsultarProductosBancarios(Cliente cliente, string usuario)
        {
            var datosLog = new LogCobis();
            ServicioCobisCuentaAhorros.ContextoTransaccional contextoTransaccionalAhorros = new ServicioCobisCuentaAhorros.ContextoTransaccional();
            contextoTransaccionalAhorros.codCanalOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoCanalOriginador);
            contextoTransaccionalAhorros.identificadorTransaccional = ConfigurationManager.AppSettings.Get(Parametros.IdentificadorTransaccional);
            contextoTransaccionalAhorros.codProcesoOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoProcesoOriginador);
            contextoTransaccionalAhorros.codFuncionalidadOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoFuncionalidadOriginador);
            contextoTransaccionalAhorros.ipConsumidor = ConfigurationManager.AppSettings.Get(Parametros.ipConsumidor);
            contextoTransaccionalAhorros.fecTransaccion = DateTime.Now;
            ServicioCobisCuentaAhorros.Paginacion paginacionAhorros = this.LlenarEntidadPaginacionAhorros();
            ServicioCobisCuentaAhorros.IdentidadPersona identidadPersonaAhorros = new ServicioCobisCuentaAhorros.IdentidadPersona();
            identidadPersonaAhorros.codTipoIdentidadPersona = cliente.TipoIdentificacion.Abreviatura;
            identidadPersonaAhorros.valIdentidadPersona = cliente.Identificacion;
            ServicioCobisCuentaAhorros.ProductoResumen productoResumenAhorros = new ServicioCobisCuentaAhorros.ProductoResumen();
            productoResumenAhorros.codTipoProducto = Parametros.CobisTipoCuentaAhorros;
            productoResumenAhorros.codEstado = Parametros.CobisEstadoCuentas;
            ServicioCobisCuentaCorriente.ContextoTransaccional contextoTransaccionalCorriente = new ServicioCobisCuentaCorriente.ContextoTransaccional();
            contextoTransaccionalCorriente.codCanalOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoCanalOriginador);
            contextoTransaccionalCorriente.identificadorTransaccional = ConfigurationManager.AppSettings.Get(Parametros.IdentificadorTransaccional);
            contextoTransaccionalCorriente.codProcesoOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoProcesoOriginador);
            contextoTransaccionalCorriente.codFuncionalidadOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoFuncionalidadOriginador);
            contextoTransaccionalCorriente.ipConsumidor = ConfigurationManager.AppSettings.Get(Parametros.ipConsumidor);
            contextoTransaccionalCorriente.fecTransaccion = DateTime.Now;
            ServicioCobisCuentaCorriente.Paginacion paginacionCorriente = this.LlenarEntidadPaginacionCorriente();
            ServicioCobisCuentaCorriente.IdentidadPersona identidadPersonaCorriente = new ServicioCobisCuentaCorriente.IdentidadPersona();
            identidadPersonaCorriente.codTipoIdentidadPersona = cliente.TipoIdentificacion.Abreviatura;
            identidadPersonaCorriente.valIdentidadPersona = cliente.Identificacion;
            ServicioCobisCuentaCorriente.ProductoResumen productoResumenCorriente = new ServicioCobisCuentaCorriente.ProductoResumen();
            productoResumenCorriente.codTipoProducto = Parametros.NumeroTres;
            productoResumenCorriente.codEstado = Parametros.EstadoActivoCobis;
            ServicioCobisCuentaCorriente.CuentaCorriente[] arrayCuentaCorriente;
            ServicioCobisCuentaAhorros.Cuenta[] arraycuentaAhorros;
            List<ProductoBancario> lstproductoBancario = new List<ProductoBancario>();
            ProductoBancario productoBancario = new ProductoBancario();
            productoBancario.Resultado = new Resultado();
            userName = usuario;
            try
            {
                arrayCuentaCorriente = this.COBISConsultarCuentasDeCorrientes(contextoTransaccionalCorriente, paginacionCorriente, identidadPersonaCorriente, productoResumenCorriente, usuario);
                arraycuentaAhorros = this.COBISConsultarCuentasDeAhorros(contextoTransaccionalAhorros, paginacionAhorros, identidadPersonaAhorros, productoResumenAhorros, usuario);
                lstproductoBancario = this.SeleccionarCuentasAMostrar(arraycuentaAhorros, arrayCuentaCorriente);
            }
            catch (FaultException<ServicioCobisCuentaAhorros.ContextoRespuesta> faultException)
            {
                datosLog.HoraRequest = HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.XmlRequest = Request;
                datosLog.XmlResponse = Response;
                datosLog.TipoTransaccion = TipoTransaccion;
                datosLog.HoraResponse = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.Usuario = usuario;
                this.repositorioLogCobis.GuardarDatosLogEnTablaLogCobis(datosLog);
                productoBancario.Resultado = this.BuscarErrorAPresentar(faultException);
                lstproductoBancario.Add(productoBancario);
            }
            catch (FaultException<ServicioCobisCuentaCorriente.ContextoRespuesta> faultException)
            {
                datosLog.HoraRequest = HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.XmlRequest = Request;
                datosLog.XmlResponse = Response;
                datosLog.TipoTransaccion = TipoTransaccion;
                datosLog.HoraResponse = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.Usuario = usuario;
                this.repositorioLogCobis.GuardarDatosLogEnTablaLogCobis(datosLog);
                productoBancario.Resultado = this.BuscarErrorAPresentar(faultException);
                lstproductoBancario.Add(productoBancario);
            }
            catch (Exception ex)
            {
                datosLog.HoraRequest = HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.XmlRequest = Request;
                datosLog.XmlResponse = Mensajes.ErrorConvenio + ex;
                datosLog.TipoTransaccion = TipoTransaccion;
                datosLog.HoraResponse = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.Usuario = usuario;
                this.repositorioLogCobis.GuardarDatosLogEnTablaLogCobis(datosLog);
                var controlError = LlavesAplicacion.COBIS_ExepcionCPB;
                productoBancario.Resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarProductosBancarios), ex, controlError);
                lstproductoBancario.Add(productoBancario);
            }

            return lstproductoBancario;
        }

        /// <summary>
        /// Creacion rapida de cliente.
        /// </summary>
        /// <param name="cliente">Objeto cliente.</param>
        /// <param name="usuario">login usuario.</param>
        /// <returns>Objeto ManejoExcepcion</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado CreacionRapidaCliente(Cliente cliente, string usuario)
        {
            Resultado resultado = new Resultado();
            ServicioCobisCliente.Cliente clienteAEnviar;
            var datosLog = new LogCobis();
            ServicioCobisCliente.ContextoTransaccional contextoAenviar = new ServicioCobisCliente.ContextoTransaccional();
            contextoAenviar.codCanalOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoCanalOriginador);
            contextoAenviar.identificadorTransaccional = ConfigurationManager.AppSettings.Get(Parametros.IdentificadorTransaccional);
            contextoAenviar.codProcesoOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoProcesoOriginador);
            contextoAenviar.codFuncionalidadOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoFuncionalidadOriginador);
            contextoAenviar.ipConsumidor = ConfigurationManager.AppSettings.Get(Parametros.ipConsumidor);
            contextoAenviar.fecTransaccion = DateTime.Now;
            clienteAEnviar = this.LlenarInformacionAEnviarClienteNuevo(cliente);

            if (clienteAEnviar == null)
            {
                var controlError = LlavesAplicacion.COBIS_CreacionClienteEntidadVacia;
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaCrearConyuge), controlError);
                resultado.Error = true;
                return resultado;
            }

            try
            {
                MessageInspectorBehavior cb = new MessageInspectorBehavior();
                TipoTransaccion = Parametros.CreacionRapidaCliente;
                HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
                using (ServicioCobisCliente.SrvAplCobisClienteClient clienteServicio = new ServicioCobisCliente.SrvAplCobisClienteClient())
                {
                    clienteServicio.Endpoint.Behaviors.Add(cb);
                    cb.OnMessageInspected += (src, e) =>
                    {
                        if (e.MessageInspectionType == eMessageInspectionType.Request) Request = e.Message;
                        else Response = e.Message;
                    };

                    this.contextoRespuestaCliente = clienteServicio.OpCrearCliente(contextoAenviar, clienteAEnviar);
                    if (this.contextoRespuestaCliente.codTipoRespuesta == Parametros.CobisRespuestaSatisfactoria)
                        resultado.Error = false;
                    else
                    {
                        if (this.contextoRespuestaCliente.detalleRespuesta.Count() > 0)
                        {
                            foreach (var item in this.contextoRespuestaCliente.detalleRespuesta)
                            {
                                resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaCrearConyuge), item.codTipoDetalleRespuesta);
                                resultado.Error = true;
                            }
                        }
                        else
                        {
                            var controlError = LlavesAplicacion.COBIS_SinDetalleMensaje;
                            resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaCrearConyuge), controlError);
                            resultado.Error = true;
                        }
                    }
                    LogCobis();
                }
            }
            catch (FaultException<ServicioCobisCliente.ContextoRespuesta> faultException)
            {
                datosLog.HoraRequest = HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.XmlRequest = Request;
                datosLog.XmlResponse = Response;
                datosLog.TipoTransaccion = TipoTransaccion;
                datosLog.HoraResponse = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.Usuario = usuario;
                this.repositorioLogCobis.GuardarDatosLogEnTablaLogCobis(datosLog);
                resultado = this.BuscarErrorAPresentar(faultException);
            }
            catch (Exception ex)
            {
                datosLog.HoraRequest = HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.XmlRequest = Request;
                datosLog.XmlResponse = Mensajes.ErrorConvenio + ex;
                datosLog.TipoTransaccion = TipoTransaccion;
                datosLog.HoraResponse = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.Usuario = usuario;
                this.repositorioLogCobis.GuardarDatosLogEnTablaLogCobis(datosLog);
                var controlError = LlavesAplicacion.COBIS_ExepcionCRC;
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoRegistrarVentaCrearConyuge), ex, controlError);
            }
            return resultado;
        }

        /// <summary>
        /// Generar the debito a cuenta cliente.
        /// </summary>
        /// <param name="registrarVenta">The registrar venta.</param>
        /// <returns>Objeto ManejoExcepcion</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GenerarDebitoACuentaCliente(RegistrarVenta registrarVenta)
        {
            Resultado resultado = new Resultado();
            string methodName = Parametros.MetodoOpRealizarNotaDebito;
            string rutaServicioTransaccion = ConfigurationManager.AppSettings.Get(Parametros.RutaServicioTransaccion);
            LogCobis datosLog = new LogCobis();

            if (rutaServicioTransaccion == null)
            {
                return new Resultado() { Error = true, Mensaje = Mensajes.ErrorNoConfiguradoRutaServicioTransaccion };
            }

            datosLog.HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
            WebRequest webRequest = WebRequest.Create(rutaServicioTransaccion);
            HttpWebRequest httpRequest = (HttpWebRequest)webRequest;
            httpRequest.Method = Parametros.POST;
            httpRequest.ContentType = string.Format(XML_RequestCobis.ContentType, methodName);
            httpRequest.Headers.Add(string.Format(XML_RequestCobis.SOAPAction, methodName));
            httpRequest.ProtocolVersion = HttpVersion.Version11;
            httpRequest.Credentials = CredentialCache.DefaultCredentials;
            Stream requestStream = httpRequest.GetRequestStream();
            StreamWriter streamWriter = new StreamWriter(requestStream, Encoding.ASCII);
            StringBuilder soapRequest = new StringBuilder(XML_RequestCobis.SoapEnvelope);
            soapRequest.Append(XML_RequestCobis.SoapHeader);
            soapRequest.Append(XML_RequestCobis.SoapBody);
            soapRequest.Append(XML_RequestCobis.SerOpRealizarNotaDebitoSolicitud);
            soapRequest.Append(XML_RequestCobis.DtoContextoTransaccional);
            soapRequest.Append(string.Format(XML_RequestCobis.DtoIdentificadorTransaccional, ConfigurationManager.AppSettings.Get(Parametros.IdentificadorTransaccional)));
            soapRequest.Append(string.Format(XML_RequestCobis.DtoFecTransaccion, DateTime.Now));
            soapRequest.Append(string.Format(XML_RequestCobis.DtoCodCanalOriginador, ConfigurationManager.AppSettings.Get(Parametros.CodigoCanalOriginador)));
            soapRequest.Append(string.Format(XML_RequestCobis.DtoCodProcesoOriginador, ConfigurationManager.AppSettings.Get(Parametros.CodigoProcesoOriginador)));
            soapRequest.Append(string.Format(XML_RequestCobis.DtoCodFuncionalidadOriginador, ConfigurationManager.AppSettings.Get(Parametros.CodigoFuncionalidadOriginador)));
            soapRequest.Append(string.Format(XML_RequestCobis.DtoIpConsumidor, ConfigurationManager.AppSettings.Get(Parametros.ipConsumidor)));
            soapRequest.Append(XML_RequestCobis.DtoContextoTransaccionalCierre);
            soapRequest.Append(XML_RequestCobis.DtoTransaccion);
            soapRequest.Append(string.Format(XML_RequestCobis.DtoCodCausalTransaccion, Parametros.CobisCodigoCausalTransaccion));
            Int64 numeroAprobacionExterno;
            numeroAprobacionExterno = this.repositorioLogCobis.ObtenerConsecutivoCobis();
            soapRequest.Append(string.Format(XML_RequestCobis.DtoValNumAprobacionExterno, numeroAprobacionExterno.ToString()));
            soapRequest.Append(string.Format(XML_RequestCobis.DtoValMonto, registrarVenta.ProductoBancario.Saldo));
            soapRequest.Append(XML_RequestCobis.DtoTransaccionCierre);
            soapRequest.Append(XML_RequestCobis.DtoidentidadPersona);
            soapRequest.Append(string.Format(XML_RequestCobis.DtoCodTipoIdentidadPersona, registrarVenta.Cliente.TipoIdentificacion.Abreviatura));
            soapRequest.Append(string.Format(XML_RequestCobis.DtoValIdentidadPersona, registrarVenta.Cliente.Identificacion));
            soapRequest.Append(XML_RequestCobis.DtoidentidadPersonaCierre);
            soapRequest.Append(XML_RequestCobis.DtoCuenta);
            soapRequest.Append(string.Format(XML_RequestCobis.DtoValNumeroProducto, registrarVenta.ProductoBancario.NumeroCuenta));
            soapRequest.Append(string.Format(XML_RequestCobis.DtoCodTipoProducto, registrarVenta.ProductoBancario.CodigoProducto));
            soapRequest.Append(XML_RequestCobis.DtoCuentaCIerre);
            soapRequest.Append(XML_RequestCobis.SerOpRealizarNotaDebitoSolicitudCierre);
            soapRequest.Append(XML_RequestCobis.SoapBodyCierre);
            soapRequest.Append(XML_RequestCobis.SoapEnvelopeCerrar);
            streamWriter.Write(soapRequest.ToString());
            streamWriter.Close();
            datosLog.XmlRequest = soapRequest.ToString();
            try
            {
                HttpWebResponse wr = (HttpWebResponse)httpRequest.GetResponse();
                StreamReader srd = new StreamReader(wr.GetResponseStream());
                string resulXmlFromWebService = srd.ReadToEnd();
                ServicioCobisTransaccion.ContextoRespuesta co = this.XmltoContextoRespuesta(resulXmlFromWebService, "ns2");
                ServicioCobisTransaccion.Transaccion tr = this.XmltoTransaccionRespuesta(resulXmlFromWebService);

                if (co.codTipoRespuesta == Parametros.CobisRespuestaSatisfactoria)
                {
                    resultado.Error = false;
                }
                else
                {
                    resultado.Error = true;

                    if (co.detalleRespuesta != null && co.detalleRespuesta.Count() > 0)
                    {
                        foreach (var item in co.detalleRespuesta)
                        {
                            Exception exc = new Exception(item.valDescripcionDetalleRespuesta);

                            Resultado re = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoRegistrarVentaGuardar), exc, item.codTipoDetalleRespuesta);
                        }
                    }
                    else
                    {
                        var controlError = LlavesAplicacion.COBIS_SinDetalleMensaje;
                        resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaGuardar), controlError);
                        resultado.Error = true;
                    }
                }

                var responseSerializado = resulXmlFromWebService;
                datosLog.XmlResponse = responseSerializado.ToString();
                datosLog.TipoTransaccion = Parametros.GenerarDebitoACuentaCliente;
                datosLog.Usuario = userName;
                datosLog.HoraResponse = DateTime.Now.ToString(Parametros.Formatohhmmss);
                this.repositorioLogCobis.GuardarDatosLogEnTablaLogCobis(datosLog);
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string error = reader.ReadToEnd();
                    ServicioCobisTransaccion.ContextoRespuesta co = this.XmltoContextoRespuesta(error, "ns5");

                    if (co.detalleRespuesta != null && co.detalleRespuesta.Count() > 0)
                    {
                        foreach (var item in co.detalleRespuesta)
                        {
                            resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaGuardar), item.codTipoDetalleRespuesta);
                            resultado.Error = true;
                        }
                    }
                    else
                    {
                        var controlError = LlavesAplicacion.COBIS_SinDetalleMensaje;
                        resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaGuardar), controlError);
                        resultado.Error = true;
                    }
                }
            }
            catch (Exception ex)
            {
                datosLog.HoraRequest = HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.XmlRequest = Request;
                datosLog.XmlResponse = Mensajes.ErrorConvenio + ex;
                datosLog.TipoTransaccion = TipoTransaccion;
                datosLog.HoraResponse = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.Usuario = usuario;
                this.repositorioLogCobis.GuardarDatosLogEnTablaLogCobis(datosLog);
                var controlError = LlavesAplicacion.COBIS_ExepcionGD;
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoRegistrarVentaGuardar), ex, controlError);
            }

            return resultado;
        }

        /// <summary>
        /// Genera el credito a cuenta aseguradora.
        /// </summary>
        /// <param name="registrarVenta">Objeto RegistrarVenta.</param>
        /// <returns>Objeto ManejoExcepcion</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GenerarCreditoACuentaAseguradora(RegistrarVenta registrarVenta)
        {
            Resultado resultado = new Resultado();
            string tipoIdentificacion = ConfigurationManager.AppSettings.Get(Parametros.CreditoAseguradoraTipoIdentificacion);
            string identificacion = ConfigurationManager.AppSettings.Get(Parametros.CreditoAseguradoraIdentificacion);
            string numeroCuenta = ConfigurationManager.AppSettings.Get(Parametros.CreditoAseguradoraNumeroCuenta);
            string codigoProducto = ConfigurationManager.AppSettings.Get(Parametros.CreditoAseguradoraCodigoProducto);
            string methodName = Parametros.OpRealizarNotaCredito;
            string rutaServicioTransaccion = ConfigurationManager.AppSettings.Get(Parametros.RutaServicioTransaccion);
            LogCobis datosLog = new LogCobis();

            if (tipoIdentificacion == string.Empty || identificacion == string.Empty || numeroCuenta == string.Empty || codigoProducto == string.Empty)
            {
                resultado.Error = false;
                return resultado;
            }

            datosLog.HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
            WebRequest webRequest = WebRequest.Create(rutaServicioTransaccion);
            HttpWebRequest httpRequest = (HttpWebRequest)webRequest;
            httpRequest.Method = Parametros.POST;
            httpRequest.ContentType = string.Format(XML_RequestCobis.ContentType, methodName);
            httpRequest.Headers.Add(string.Format(XML_RequestCobis.SOAPAction, methodName));
            httpRequest.ProtocolVersion = HttpVersion.Version11;
            httpRequest.Credentials = CredentialCache.DefaultCredentials;
            Stream requestStream = httpRequest.GetRequestStream();
            StreamWriter streamWriter = new StreamWriter(requestStream, Encoding.ASCII);
            StringBuilder soapRequest = new StringBuilder(XML_RequestCobis.SoapEnvelope);
            soapRequest.Append(XML_RequestCobis.SoapHeader);
            soapRequest.Append(XML_RequestCobis.SoapBody);
            soapRequest.Append(XML_RequestCobis.SerOpRealizarNotaCreditoSolicitud);
            soapRequest.Append(XML_RequestCobis.DtoContextoTransaccional);
            soapRequest.Append(string.Format(XML_RequestCobis.DtoIdentificadorTransaccional, ConfigurationManager.AppSettings.Get(Parametros.IdentificadorTransaccional)));
            soapRequest.Append(string.Format(XML_RequestCobis.DtoFecTransaccion, DateTime.Now));
            soapRequest.Append(string.Format(XML_RequestCobis.DtoCodCanalOriginador, ConfigurationManager.AppSettings.Get(Parametros.CodigoCanalOriginador)));
            soapRequest.Append(string.Format(XML_RequestCobis.DtoCodProcesoOriginador, ConfigurationManager.AppSettings.Get(Parametros.CodigoProcesoOriginador)));
            soapRequest.Append(string.Format(XML_RequestCobis.DtoCodFuncionalidadOriginador, ConfigurationManager.AppSettings.Get(Parametros.CodigoFuncionalidadOriginador)));
            soapRequest.Append(string.Format(XML_RequestCobis.DtoIpConsumidor, ConfigurationManager.AppSettings.Get(Parametros.ipConsumidor)));
            soapRequest.Append(XML_RequestCobis.DtoContextoTransaccionalCierre);
            soapRequest.Append(XML_RequestCobis.DtoTransaccion);
            soapRequest.Append(string.Format(XML_RequestCobis.DtoCodCausalTransaccion, Parametros.CobisCodigoCausalTransaccion));
            Int64 numeroAprobacionExterno;
            numeroAprobacionExterno = this.repositorioLogCobis.ObtenerConsecutivoCobis();
            soapRequest.Append(string.Format(XML_RequestCobis.DtoValNumAprobacionExterno, numeroAprobacionExterno.ToString()));
            soapRequest.Append(string.Format(XML_RequestCobis.DtoValMonto, registrarVenta.ProductoBancario.Saldo));
            soapRequest.Append(XML_RequestCobis.DtoTransaccionCierre);
            soapRequest.Append(XML_RequestCobis.DtoidentidadPersona);
            soapRequest.Append(string.Format(XML_RequestCobis.DtoCodTipoIdentidadPersona, tipoIdentificacion));
            soapRequest.Append(string.Format(XML_RequestCobis.DtoValIdentidadPersona, identificacion));
            soapRequest.Append(XML_RequestCobis.DtoidentidadPersonaCierre);
            soapRequest.Append(XML_RequestCobis.DtoCuenta);
            soapRequest.Append(string.Format(XML_RequestCobis.DtoValNumeroProducto, numeroCuenta));
            soapRequest.Append(string.Format(XML_RequestCobis.DtoCodTipoProducto, codigoProducto));
            soapRequest.Append(XML_RequestCobis.DtoCuentaCIerre);
            soapRequest.Append(XML_RequestCobis.SerOpRealizarNotaCreditoSolicitudCierre);
            soapRequest.Append(XML_RequestCobis.SoapBodyCierre);
            soapRequest.Append(XML_RequestCobis.SoapEnvelopeCerrar);
            streamWriter.Write(soapRequest.ToString());
            streamWriter.Close();
            datosLog.XmlRequest = soapRequest.ToString();

            try
            {
                HttpWebResponse wr = (HttpWebResponse)httpRequest.GetResponse();
                StreamReader srd = new StreamReader(wr.GetResponseStream());
                string resulXmlFromWebService = srd.ReadToEnd();
                ServicioCobisTransaccion.ContextoRespuesta co = this.XmltoContextoRespuesta(resulXmlFromWebService, "ns2");
                ServicioCobisTransaccion.Transaccion tr = this.XmltoTransaccionRespuesta(resulXmlFromWebService);

                if (co.codTipoRespuesta == Parametros.CobisRespuestaSatisfactoria)
                {
                    resultado.Error = false;
                }
                else
                {
                    resultado.Error = true;

                    if (co.detalleRespuesta != null && co.detalleRespuesta.Count() > 0)
                    {
                        foreach (var item in co.detalleRespuesta)
                        {
                            resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaGuardar), item.codTipoDetalleRespuesta);
                            resultado.Error = true;
                        }
                    }
                    else
                    {
                        var controlError = LlavesAplicacion.COBIS_SinDetalleMensaje;
                        resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaGuardar), controlError);
                        resultado.Error = true;
                    }
                }

                datosLog.TipoTransaccion = Parametros.GenerarCreditoACuentaAseguradora;
                var responseSerializado = resulXmlFromWebService;
                datosLog.XmlResponse = responseSerializado.ToString();
                datosLog.Usuario = userName;
                datosLog.HoraResponse = DateTime.Now.ToString(Parametros.Formatohhmmss);
                this.repositorioLogCobis.GuardarDatosLogEnTablaLogCobis(datosLog);
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string error = reader.ReadToEnd();
                    ServicioCobisTransaccion.ContextoRespuesta co = this.XmltoContextoRespuesta(error, "ns5");
                    resultado.Error = true;

                    if (co.detalleRespuesta != null && co.detalleRespuesta.Count() > 0)
                    {
                        foreach (var item in co.detalleRespuesta)
                        {
                            resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaGuardar), item.codTipoDetalleRespuesta);
                            resultado.Error = true;
                        }
                    }
                    else
                    {
                        var controlError = LlavesAplicacion.COBIS_SinDetalleMensaje;
                        resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaGuardar), controlError);
                        resultado.Error = true;
                    }
                }
            }
            catch (Exception ex)
            {
                datosLog.HoraRequest = HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.XmlRequest = Request;
                datosLog.XmlResponse = Mensajes.ErrorConvenio + ex;
                datosLog.TipoTransaccion = TipoTransaccion;
                datosLog.HoraResponse = DateTime.Now.ToString(Parametros.Formatohhmmss);
                datosLog.Usuario = usuario;
                this.repositorioLogCobis.GuardarDatosLogEnTablaLogCobis(datosLog);
                var controlError = LlavesAplicacion.COBIS_ExepcionGC;
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoRegistrarVentaGuardar), ex, controlError);
            }

            return resultado;
        }

        /// <summary>
        /// Generar Recaudo
        /// </summary>
        /// <param name="cliente">The client.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\Enrique Rivera
        /// CreationDate: 19/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GenerarRecaudoACliente(RegistrarVenta registrarVenta, ref LogCobis datosLog, string consecutivoVenta)
        {
            Resultado resultado = new Resultado();

            ServicioCobisConvenio.ContextoTransaccional contextoTransaccional = this.VariablesContextoTransaccionalConvenio(consecutivoVenta);
            ServicioCobisConvenio.Recaudo recaudo = this.LlenarEntidadRecaudo(registrarVenta);
            ServicioCobisConvenio.Transaccion transaccion = new ServicioCobisConvenio.Transaccion();
            transaccion.valMonto = registrarVenta.ProductoBancario.Saldo;
            transaccion.valMontoSpecified = true;
            ServicioCobisConvenio.Convenio convenio = new ServicioCobisConvenio.Convenio();
            convenio.codConvenio = registrarVenta.CodigoConvenio.ToString();
            ServicioCobisConvenio.ContextoRespuesta contextoRespuesta = new ServicioCobisConvenio.ContextoRespuesta();

            BancaSeguros.Aplicacion.ServicioCobisConvenio.OpRealizarRecaudoRequest requestRecaudo = new BancaSeguros.Aplicacion.ServicioCobisConvenio.OpRealizarRecaudoRequest();
            requestRecaudo.contextoTransaccional = contextoTransaccional;
            requestRecaudo.transaccion = transaccion;
            requestRecaudo.recaudo = recaudo;
            requestRecaudo.convenio = convenio;
            TipoTransaccion = Parametros.GenerarRecaudo;
            HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
            MessageInspectorBehavior cb = new MessageInspectorBehavior();

            datosLog.HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);

            try
            {
                using (ServicioCobisConvenio.SrvAplCobisConvenioClient servicio = new ServicioCobisConvenio.SrvAplCobisConvenioClient())
                {
                    servicio.Endpoint.Behaviors.Add(cb);
                    cb.OnMessageInspected += (src, e) =>
                    {
                        if (e.MessageInspectionType == eMessageInspectionType.Request) Request = e.Message;
                        else Response = e.Message;
                    };
                    contextoRespuesta = servicio.OpRealizarRecaudo(contextoTransaccional, ref transaccion, ref recaudo, convenio);
                    //throw new Exception("Test Exception");
                }
            }
            // Error del banco
            catch (FaultException<ServicioCobisConvenio.ContextoRespuesta> faultException)
            {
                resultado = this.BuscarErrorAPresentar(faultException);
            }
            // Error de aplicacion
            catch (Exception ex)
            {
                resultado.Mensaje = "Error Cobis - 000";
                resultado.Error = true;
                resultado.Ex = ex.Message;
            }
            finally
            {
                datosLog = LLenarRequestResponse(resultado, registrarVenta.Asesor.IdAsesor);
            }

            return resultado;
        }

        /// <summary>
        /// LLenarRequestResponse.
        /// </summary>
        /// <param name="mensaje">The client.</param>
        /// <returns>Entity LogCobis</returns>
        /// <remarks>
        /// Author: INTERGRUPO\Cesar blandon
        /// CreationDate: 06/03/2017
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private LogCobis LLenarRequestResponse(Resultado resultado, string usuario)
        {
            var logDatos = new LogCobis
            {
                HoraRequest = HoraRequest,
                XmlRequest = Request,
                XmlResponse = resultado.Ex != string.Empty ? Mensajes.ErrorConvenio + " : " + resultado.Ex : Response,
                TipoTransaccion = TipoTransaccion,
                HoraResponse = DateTime.Now.ToString(Parametros.Formatohhmmss),
                Usuario = usuario
            };

            return logDatos;
        }

        #endregion Metodos Publicos Cobis

        #region Metodos Privados

        /// <summary>
        /// Busca el error a presentar.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns>Objeto Cliente</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado BuscarErrorAPresentar(FaultException<ServicioCobisConvenio.ContextoRespuesta> faultException)
        {
            Resultado resultado = new Resultado();

            if (faultException.Detail.detalleRespuesta != null && faultException.Detail.detalleRespuesta.Count() > 0)
            {
                foreach (var item in faultException.Detail.detalleRespuesta)
                {
                    resultado.Mensaje = "Error Cobis - " + item.codTipoDetalleRespuesta;
                    resultado.Error = true;
                    break;
                }
            }
            else
            {
                var controlError = LlavesAplicacion.COBIS_SinDetalleMensaje;
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarCliente), faultException, controlError);
            }

            return resultado;
        }

        private Recaudo LlenarEntidadRecaudo(RegistrarVenta registrarVenta)
        {
            Recaudo recaudo = new Recaudo();

            if (registrarVenta.ProductoBancario.CodigoProducto == Parametros.CodigoProductoAhorro)
            {
                recaudo.codFormaPago = ConfigurationManager.AppSettings.Get(Parametros.CodigoFormaPagoAHO);
            }
            else if (registrarVenta.ProductoBancario.CodigoProducto == Parametros.CodigoProductoCorriente)
            {
                recaudo.codFormaPago = ConfigurationManager.AppSettings.Get(Parametros.CodigoFormaPagoCTE);
            }

            recaudo.valReferencia1 = registrarVenta.Cliente.Identificacion;
            recaudo.codCanalRecaudo = ConfigurationManager.AppSettings.Get(Parametros.CodigoCanalRecaudo);
            recaudo.identidadPersona = new ServicioCobisConvenio.IdentidadPersona();
            recaudo.identidadPersona.codTipoIdentidadPersona = registrarVenta.Cliente.TipoIdentificacion.Abreviatura;
            recaudo.identidadPersona.valIdentidadPersona = registrarVenta.Cliente.Identificacion;
            recaudo.cuenta = new ServicioCobisConvenio.Cuenta();
            recaudo.cuenta.valNumeroProducto = registrarVenta.ProductoBancario.NumeroCuenta;

            if (registrarVenta.ProductoBancario.CodigoProducto == Parametros.CodigoProductoAhorro)
            {
                recaudo.cuenta.codTipoProducto = ConfigurationManager.AppSettings.Get(Parametros.CodigoTipoProductoAHO);
            }
            else if (registrarVenta.ProductoBancario.CodigoProducto == Parametros.CodigoProductoCorriente)
            {
                recaudo.cuenta.codTipoProducto = ConfigurationManager.AppSettings.Get(Parametros.CodigoTipoProductoCTE);
            }

            recaudo.oficina = new ServicioCobisConvenio.Oficina();
            recaudo.oficina.codOficina = registrarVenta.Asesor.Oficina.IdOficina.ToString();

            return recaudo;
        }

        /// <summary>
        /// Asigna valores a las variables de contexto transaccional.
        /// </summary>
        /// <returns>Objeto ContextoTransaccional</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private ServicioCobisCliente.ContextoTransaccional VariablesContextoTransaccional()
        {
            ServicioCobisCliente.ContextoTransaccional contextoTransaccional = new ServicioCobisCliente.ContextoTransaccional();
            contextoTransaccional.identificadorTransaccional = ConfigurationManager.AppSettings.Get(Parametros.IdentificadorTransaccional);
            contextoTransaccional.codCanalOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoCanalOriginador);
            contextoTransaccional.codProcesoOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoProcesoOriginador);
            contextoTransaccional.codFuncionalidadOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoFuncionalidadOriginador);
            contextoTransaccional.ipConsumidor = ConfigurationManager.AppSettings.Get(Parametros.ipConsumidor);
            contextoTransaccional.fecTransaccion = DateTime.Now;

            return contextoTransaccional;
        }

        /// <summary>
        /// Asigna valores a las variables de contexto transaccional.
        /// </summary>
        /// <returns>Objeto ContextoTransaccional</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private ServicioCobisConvenio.ContextoTransaccional VariablesContextoTransaccionalConvenio(string consecutivoVenta)
        {
            ServicioCobisConvenio.ContextoTransaccional contextoTransaccional = new ServicioCobisConvenio.ContextoTransaccional();
            contextoTransaccional.identificadorTransaccional = consecutivoVenta;
            contextoTransaccional.codCanalOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoCanalOriginador);
            contextoTransaccional.codProcesoOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoProcesoOriginador);
            contextoTransaccional.codFuncionalidadOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoFuncionalidadOriginador);
            contextoTransaccional.ipConsumidor = ConfigurationManager.AppSettings.Get(Parametros.ipConsumidor);
            contextoTransaccional.fecTransaccion = DateTime.Now;

            return contextoTransaccional;
        }

        /// <summary>
        /// Variableses the identidad persona.
        /// </summary>
        /// <param name="cliente">Objeto Cliente.</param>
        /// <returns>Objeto IdentidadPersona</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private ServicioCobisCliente.IdentidadPersona VariablesIdentidadPersona(Cliente cliente)
        {
            this.identidadPersonaCliente = new ServicioCobisCliente.IdentidadPersona();
            this.identidadPersonaCliente.codTipoIdentidadPersona = cliente.TipoIdentificacion.Abreviatura;
            this.identidadPersonaCliente.valIdentidadPersona = cliente.Identificacion;

            return this.identidadPersonaCliente;
        }

        /// <summary>
        /// Consulta la informacion de una cliente en COBIS.
        /// </summary>
        /// <param name="usuario">usuario login.</param>
        /// <returns>Objeto cliente</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Cliente COBISConsultarInformacionCliente(string usuario, int TipoCliente)
        {
            Cliente clienteDevuelto = new Cliente();
            MessageInspectorBehavior cb = new MessageInspectorBehavior();
            TipoTransaccion = Parametros.COBISConsultarInformacionCliente;
            HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
            using (ServicioCobisCliente.SrvAplCobisClienteClient obj = new ServicioCobisCliente.SrvAplCobisClienteClient())
            {
                obj.Endpoint.Behaviors.Add(cb);
                cb.OnMessageInspected += (src, e) =>
                {
                    if (e.MessageInspectionType == eMessageInspectionType.Request) Request = e.Message;
                    else Response = e.Message;
                };
                this.contextoRespuestaCliente = obj.OpBuscarPorIdCliente(this.contextoTransaccionalCliente, this.identidadPersonaCliente, out this.cliente);
                LogCobis();
                if (this.contextoRespuestaCliente != null)
                    clienteDevuelto = new Mapeador().MapearClienteCobisAClienteBanca(this.cliente, TipoCliente);
            }
            return clienteDevuelto;
        }

        /// <summary>
        /// Busca el error a presentar.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns>Objeto Cliente</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado BuscarErrorAPresentar(FaultException<ServicioCobisCliente.ContextoRespuesta> faultException)
        {
            Resultado resultado = new Resultado();

            if (faultException.Detail.detalleRespuesta != null && faultException.Detail.detalleRespuesta.Count() > 0)
            {
                foreach (var item in faultException.Detail.detalleRespuesta)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarCliente), item.codTipoDetalleRespuesta);
                    resultado.Error = true;
                }
            }
            else
            {
                var controlError = LlavesAplicacion.COBIS_SinDetalleMensaje;
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarCliente), faultException, controlError);
            }

            return resultado;
        }

        private Resultado BuscarErrorAPresentar(FaultException<ServicioCobisListasInhibitorias.ContextoRespuesta> faultException)
        {
            Resultado resultado = new Resultado();

            if (faultException.Detail.detalleRespuesta != null && faultException.Detail.detalleRespuesta.Count() > 0)
            {
                foreach (var item in faultException.Detail.detalleRespuesta)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarCliente), item.codTipoDetalleRespuesta);
                    resultado.Error = true;
                }
            }
            else
            {
                var controlError = LlavesAplicacion.COBIS_SinDetalleMensaje;
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarCliente), faultException, controlError);
            }

            return resultado;
        }

        private Resultado BuscarErrorAPresentar(FaultException<ServicioCobisCuentaCorriente.ContextoRespuesta> faultException)
        {
            Resultado resultado = new Resultado();

            if (faultException.Detail.detalleRespuesta != null && faultException.Detail.detalleRespuesta.Count() > 0)
            {
                foreach (var item in faultException.Detail.detalleRespuesta)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarProductosBancarios), item.codTipoDetalleRespuesta);
                    resultado.Error = true;
                }
            }
            else
            {
                var controlError = LlavesAplicacion.COBIS_SinDetalleMensaje;
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarProductosBancarios), faultException, controlError);
            }

            return resultado;
        }

        private Resultado BuscarErrorAPresentar(FaultException<ServicioCobisCuentaAhorros.ContextoRespuesta> faultException)
        {
            Resultado resultado = new Resultado();

            if (faultException.Detail.detalleRespuesta != null && faultException.Detail.detalleRespuesta.Count() > 0)
            {
                foreach (var item in faultException.Detail.detalleRespuesta)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarProductosBancarios), item.codTipoDetalleRespuesta);
                    resultado.Error = true;
                }
            }
            else
            {
                var controlError = LlavesAplicacion.COBIS_SinDetalleMensaje;
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarProductosBancarios), faultException, controlError);
            }

            return resultado;
        }

        /// <summary>
        /// Seleccionars the cuentas a mostrar.
        /// </summary>
        /// <param name="arraycuentaAhorros">The arraycuenta ahorros.</param>
        /// <param name="arrayCuentaCorriente">The array cuenta corriente.</param>
        /// <returns>Lista de ProductoBancario</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private List<ProductoBancario> SeleccionarCuentasAMostrar(ServicioCobisCuentaAhorros.Cuenta[] arraycuentaAhorros, ServicioCobisCuentaCorriente.CuentaCorriente[] arrayCuentaCorriente)
        {
            ProductoBancario productoBancario;
            List<ProductoBancario> lstProductoBancario = new List<ProductoBancario>();

            if (arraycuentaAhorros != null)
            {
                foreach (var item in arraycuentaAhorros)
                {
                    productoBancario = new ProductoBancario();
                    productoBancario.IdProductoBancario = int.Parse(item.codTipoProducto);
                    productoBancario.NumeroCuenta = item.valNumeroProducto.Trim();
                    productoBancario.NombreProducto = item.valTipoProducto;
                    productoBancario.Saldo = item.valSaldoTotal;
                    productoBancario.SaldoFormatoMoneda = string.Format("{0:C}", item.valSaldoTotal);
                    productoBancario.Descripcion = item.valTipoProducto + " " + item.valSubTipoProducto + " " + item.valCategoria;
                    productoBancario.CodigoProducto = item.codTipoProducto;
                    productoBancario.CodigoSubProducto = item.codSubTipoProducto;
                    productoBancario.CodigoCategoria = item.codCategoria;
                    lstProductoBancario.Add(productoBancario);
                }
            }

            if (arrayCuentaCorriente != null)
            {
                foreach (var item in arrayCuentaCorriente)
                {
                    productoBancario = new ProductoBancario();
                    productoBancario.IdProductoBancario = int.Parse(item.codTipoProducto);
                    productoBancario.NumeroCuenta = item.valNumeroProducto.Trim();
                    productoBancario.NombreProducto = item.valTipoProducto;
                    productoBancario.Saldo = item.valSaldoTotal;
                    productoBancario.SaldoFormatoMoneda = string.Format("{0:C}", item.valSaldoTotal);
                    productoBancario.Descripcion = item.valTipoProducto + " " + item.valSubTipoProducto + " " + item.valCategoria;
                    productoBancario.CodigoProducto = item.codTipoProducto;
                    productoBancario.CodigoSubProducto = item.codSubTipoProducto;
                    productoBancario.CodigoCategoria = item.codCategoria;
                    lstProductoBancario.Add(productoBancario);
                }
            }

            return lstProductoBancario;
        }

        /// <summary>
        /// Consulta cuentas de corrientes.
        /// </summary>
        /// <param name="contextoTransaccionalCorriente">Contexto transaccional corriente.</param>
        /// <param name="paginacionCorriente">Paginacion corriente.</param>
        /// <param name="identidadPersonaCorriente">Identidad persona corriente.</param>
        /// <param name="productoResumenCorriente">Producto resumen corriente.</param>
        /// <param name="usuario">Usuario login.</param>
        /// <returns>Arreglo de cuentas corrientes</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private ServicioCobisCuentaCorriente.CuentaCorriente[] COBISConsultarCuentasDeCorrientes(ServicioCobisCuentaCorriente.ContextoTransaccional contextoTransaccionalCorriente, ServicioCobisCuentaCorriente.Paginacion paginacionCorriente, ServicioCobisCuentaCorriente.IdentidadPersona identidadPersonaCorriente, ServicioCobisCuentaCorriente.ProductoResumen productoResumenCorriente, string usuario)
        {
            ServicioCobisCuentaCorriente.CuentaCorriente[] arrayCuentaCorriente;
            ServicioCobisCuentaCorriente.ContextoRespuesta contextoRespuesta;
            MessageInspectorBehavior cb = new MessageInspectorBehavior();
            LogCobis datosLog = new LogCobis();
            HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
            TipoTransaccion = "ConsultaCuentaCorriente";
            using (ServicioCobisCuentaCorriente.SrvAplCobisCuentaCorrienteClient servicioCorriente = new ServicioCobisCuentaCorriente.SrvAplCobisCuentaCorrienteClient())
            {
                servicioCorriente.Endpoint.Behaviors.Add(cb);
                cb.OnMessageInspected += (src, e) =>
                {
                    if (e.MessageInspectionType == eMessageInspectionType.Request) Request = e.Message;
                    else Response = e.Message;
                };
                contextoRespuesta = servicioCorriente.OpBuscarCuentaCorriente(contextoTransaccionalCorriente, paginacionCorriente, identidadPersonaCorriente, productoResumenCorriente, out arrayCuentaCorriente);
                LogCobis();
            }
            return arrayCuentaCorriente;
        }

        /// <summary>
        /// Consulta las cuentas de ahorros.
        /// </summary>
        /// <param name="contextoTransaccional">Contexto transaccional.</param>
        /// <param name="paginacion">Objeto Paginacion.</param>
        /// <param name="identidadPersona">Identidad persona.</param>
        /// <param name="productoResumen">Producto resumen.</param>
        /// <param name="usuario">Usuario login.</param>
        /// <returns>Arreglo de cuentas encontradas</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private ServicioCobisCuentaAhorros.Cuenta[] COBISConsultarCuentasDeAhorros(ServicioCobisCuentaAhorros.ContextoTransaccional contextoTransaccional, ServicioCobisCuentaAhorros.Paginacion paginacion, ServicioCobisCuentaAhorros.IdentidadPersona identidadPersona, ServicioCobisCuentaAhorros.ProductoResumen productoResumen, string usuario)
        {
            ServicioCobisCuentaAhorros.Cuenta[] arraycuenta = new ServicioCobisCuentaAhorros.Cuenta[1];
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings.Get("IsDummie")))
            {
                ServicioCobisCuentaAhorros.ContextoRespuesta contextoRespuesta;
                MessageInspectorBehavior cb = new MessageInspectorBehavior();
                TipoTransaccion = "ConsultaCuentaAhorro";
                HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);
                using (ServicioCobisCuentaAhorros.SrvAplCobisCuentaAhorrosClient cuentaAhorros = new ServicioCobisCuentaAhorros.SrvAplCobisCuentaAhorrosClient())
                {
                    cuentaAhorros.Endpoint.Behaviors.Add(cb);
                    cb.OnMessageInspected += (src, e) =>
                    {
                        if (e.MessageInspectionType == eMessageInspectionType.Request) Request = e.Message;
                        else Response = e.Message;
                    };
                    contextoRespuesta = cuentaAhorros.OpBuscarCuentaAhorros(contextoTransaccional, paginacion, identidadPersona, productoResumen, out arraycuenta);
                    LogCobis();
                }
            }
            else
            {
                ServicioCobisCuentaAhorros.Cuenta cadummie = new ServicioCobisCuentaAhorros.Cuenta();
                cadummie.codTipoProducto = "4";
                cadummie.valNumeroProducto = "445070009211";
                cadummie.valTipoProducto = "CUENTAS AHORROS";
                cadummie.valSaldoTotal = 3825630.66;
                cadummie.codTipoProducto = "4";
                cadummie.codSubTipoProducto = "3";
                cadummie.codCategoria = "N";
                arraycuenta[0] = cadummie;
            }
            return arraycuenta;
        }

        /// <summary>
        /// Consulta las listas inhibitorias.
        /// </summary>
        /// <param name="contextoTransaccional">Contexto transaccional.</param>
        /// <param name="filtroInhibitoria">Filtro inhibitoria.</param>
        /// <returns>Resultado booleano de la operacion</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado COBISConsultarListasInhibitorias(ServicioCobisListasInhibitorias.ContextoTransaccional contextoTransaccional, ServicioCobisListasInhibitorias.FiltroInhibitoria filtroInhibitoria)
        {
            ServicioCobisListasInhibitorias.Inhibitoria[] arrayInhibitoria;
            ServicioCobisListasInhibitorias.ContextoRespuesta contextoRespuesta;
            Resultado resultado = new Resultado();
            LogCobis datosLog = new LogCobis();
            MessageInspectorBehavior cb = new MessageInspectorBehavior();
            TipoTransaccion = "ConsultalistaInhibitoria";
            HoraRequest = DateTime.Now.ToString(Parametros.Formatohhmmss);

            using (ServicioCobisListasInhibitorias.SrvAplCobisListasInhibitoriasClient serListas = new ServicioCobisListasInhibitorias.SrvAplCobisListasInhibitoriasClient())
            {
                serListas.Endpoint.Behaviors.Add(cb);
                cb.OnMessageInspected += (src, e) =>
                {
                    if (e.MessageInspectionType == eMessageInspectionType.Request) Request = e.Message;
                    else Response = e.Message;
                };
                contextoRespuesta = serListas.OpBuscarListasInhibitoriasOperacionB(contextoTransaccional, filtroInhibitoria, out arrayInhibitoria);
                LogCobis();
            }

            if (contextoRespuesta != null)
            {
                if (arrayInhibitoria != null && arrayInhibitoria.Count() > 0)
                {
                    var controlError = LlavesAplicacion.ClienteEnListasInhibitorias;
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarCliente), controlError);
                    resultado.Error = true;
                }
                else
                    resultado.Error = false;
            }
            return resultado;
        }

        /// <summary>
        /// Llenar la informacion a enviar cliente nuevo.
        /// </summary>
        /// <param name="cliente">Cliente de cliente nuevo.</param>
        /// <returns>Objeto Cliente</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private ServicioCobisCliente.Cliente LlenarInformacionAEnviarClienteNuevo(Cliente cliente)
        {
            ServicioCobisCliente.Cliente clienteAEnviar = new ServicioCobisCliente.Cliente();
            clienteAEnviar.persona = new ServicioCobisCliente.Persona();
            clienteAEnviar.persona.codTipoPersona = "P";
            clienteAEnviar.persona.identidadPersona = new ServicioCobisCliente.IdentidadPersona();
            clienteAEnviar.persona.identidadPersona.codTipoIdentidadPersona = cliente.TipoIdentificacion.Abreviatura;
            clienteAEnviar.persona.identidadPersona.valIdentidadPersona = cliente.Identificacion;
            clienteAEnviar.persona.personaNatural = new ServicioCobisCliente.PersonaNatural();
            clienteAEnviar.persona.personaNatural.valPrimerNombre = cliente.PrimerNombre + " " + cliente.SegundoNombre;
            clienteAEnviar.persona.personaNatural.valPrimerApellido = cliente.PrimerApellido;
            clienteAEnviar.persona.personaNatural.valSegundoApellido = cliente.SegundoApellido;
            clienteAEnviar.persona.personaNatural.fecNacimiento = cliente.FechaNacimiento;
            clienteAEnviar.persona.personaNatural.fecNacimientoSpecified = true;
            clienteAEnviar.persona.personaNatural.codSexo = cliente.Genero.Substring(0, 1);
            clienteAEnviar.oficina = new ServicioCobisCliente.Oficina();
            clienteAEnviar.oficina.codOficina = "0070";
            clienteAEnviar.oficina.municipio = new ServicioCobisCliente.Municipio();
            //clienteAEnviar.oficina.municipio.codMunicipio = 5001;
            clienteAEnviar.oficina.municipio.codMunicipioSpecified = true;
            clienteAEnviar.oficina.municipio.departamento = new ServicioCobisCliente.Departamento();
            //clienteAEnviar.oficina.municipio.departamento.codDepartamento = 5;
            clienteAEnviar.oficina.municipio.departamento.codDepartamentoSpecified = true;
            clienteAEnviar.oficina.municipio.departamento.pais = new ServicioCobisCliente.Pais();
            //clienteAEnviar.oficina.municipio.departamento.pais.codPais = 1;
            clienteAEnviar.oficina.municipio.departamento.pais.codPaisSpecified = true;

            return clienteAEnviar;
        }

        /// <summary>
        /// Convierte un xml a contexto respuesta.
        /// </summary>
        /// <param name="resulXmlFromWebService">Xml obtenido del web service.</param>
        /// <param name="n">The n.</param>
        /// <returns>Objeto contexto respuesta</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private ServicioCobisTransaccion.ContextoRespuesta XmltoContextoRespuesta(string resulXmlFromWebService, string n)
        {
            XmlDocument xmlDocumento = new XmlDocument();
            xmlDocumento.LoadXml(resulXmlFromWebService);
            XmlElement root = xmlDocumento.DocumentElement;
            string tag;

            if (n == "ns2")
            {
                tag = n + ":contextoRespuesta";
            }
            else
            {
                tag = n + ":ContextoRespuesta";
            }

            XmlNodeList nodesContextoRespuesta = root.GetElementsByTagName(tag);
            XmlNodeList nodesDetalleRespuesta = root.GetElementsByTagName("ns2:detalleRespuesta");

            ServicioCobisTransaccion.ContextoRespuesta contextoRespuesta = new ServicioCobisTransaccion.ContextoRespuesta();
            ServicioCobisTransaccion.DetalleRespuesta[] listaDetalle = new ServicioCobisTransaccion.DetalleRespuesta[nodesDetalleRespuesta.Count];

            foreach (XmlNode childrenNode in nodesContextoRespuesta)
            {
                for (int i = 0; i < childrenNode.ChildNodes.Count; i++)
                {
                    switch (childrenNode.ChildNodes[i].LocalName)
                    {
                        case "identificadorTransaccion":
                            contextoRespuesta.identificadorTransaccion = childrenNode.ChildNodes[i].InnerText;
                            break;

                        case "fecTransaccion":
                            contextoRespuesta.fecTransaccion = Convert.ToDateTime(childrenNode.ChildNodes[i].InnerText);
                            break;

                        case "codTipoRespuesta":
                            contextoRespuesta.codTipoRespuesta = childrenNode.ChildNodes[i].InnerText;
                            break;

                        case "valDescripcionRespuesta":
                            contextoRespuesta.valDescripcionRespuesta = childrenNode.ChildNodes[i].InnerText;
                            break;
                    }
                }
            }

            for (int i = 0; i < nodesDetalleRespuesta.Count; i++)
            {
                listaDetalle[i] = new ServicioCobisTransaccion.DetalleRespuesta();
                listaDetalle[i].codTipoDetalleRespuesta = nodesDetalleRespuesta[i].ChildNodes[0].InnerText;
                listaDetalle[i].valDescripcionDetalleRespuesta = nodesDetalleRespuesta[i].ChildNodes[1].InnerText;
            }

            contextoRespuesta.detalleRespuesta = listaDetalle;

            return contextoRespuesta;
        }

        /// <summary>
        /// Convierte un Objeto xml a un objeto transaccion.
        /// </summary>
        /// <param name="resulXmlFromWebService">The resul XML from web service.</param>
        /// <returns>Objeto Transaccion</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private ServicioCobisTransaccion.Transaccion XmltoTransaccionRespuesta(string resulXmlFromWebService)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(resulXmlFromWebService);
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList nodestransaccion = root.GetElementsByTagName("ns2:transaccion");
            ////XmlNodeList nodes = root.GetElementsByTagName("contextoRespuesta");

            ServicioCobisTransaccion.Transaccion transaccion = new ServicioCobisTransaccion.Transaccion();
            foreach (XmlNode childrenNode in nodestransaccion)
            {
                for (int i = 0; i < childrenNode.ChildNodes.Count; i++)
                {
                    switch (childrenNode.ChildNodes[i].LocalName)
                    {
                        case "codCausalTransaccion":
                            transaccion.codCausalTransaccion = childrenNode.ChildNodes[i].InnerText; ////"codCausalTransaccion"
                            break;

                        case "valComision":
                            transaccion.valComision = Convert.ToDouble(childrenNode.ChildNodes[i].InnerText); ////"valComision"
                            break;

                        case "fecAplicacion":
                            transaccion.fecAplicacion = Convert.ToDateTime(childrenNode.ChildNodes[i].InnerText); ////"fecAplicacion"
                            break;

                        case "valMonto":
                            transaccion.valMonto = Convert.ToDouble(childrenNode.ChildNodes[i].InnerText); ////"valNumAprobacionCore"
                            break;

                        case "valNumAprobacionExterno":
                            transaccion.valNumAprobacionExterno = Convert.ToDouble(childrenNode.ChildNodes[i].InnerText); ////"valNumAprobacionExterno"
                            break;
                    }
                }
            }

            return transaccion;
        }

        /// <summary>
        /// Llena la entidad paginacion ahorros.
        /// </summary>
        /// <returns>Objeto paginacion</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private ServicioCobisCuentaAhorros.Paginacion LlenarEntidadPaginacionAhorros()
        {
            ServicioCobisCuentaAhorros.Paginacion paginacionAhorros = new ServicioCobisCuentaAhorros.Paginacion();
            paginacionAhorros.valOrdenacion = true;
            paginacionAhorros.valOrdenacionSpecified = true;
            return paginacionAhorros;
        }

        /// <summary>
        /// Llenars the entidad paginacion corriente.
        /// </summary>
        /// <returns>Objeto paginacion</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private ServicioCobisCuentaCorriente.Paginacion LlenarEntidadPaginacionCorriente()
        {
            ServicioCobisCuentaCorriente.Paginacion paginacionCorriente = new ServicioCobisCuentaCorriente.Paginacion();
            paginacionCorriente.valOrdenacion = true;
            return paginacionCorriente;
        }

        /// <summary>
        /// Serializa a XML un objeto.
        /// </summary>
        /// <param name="parametro">Parametro object.</param>
        /// <returns>Objeto StringWriter</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private StringWriter SerializaXml(object parametro)
        {
            XmlSerializer serializaXml = new XmlSerializer(parametro.GetType());
            StringWriter strWriterReq = new StringWriter();
            serializaXml.Serialize(strWriterReq, parametro);
            strWriterReq.Close();
            return strWriterReq;
        }

        /// <summary>
        /// LogCobis
        ///<returns>Vacio</returns>
        /// <remarks>
        /// Author: UT2013\Enrique Rivera
        /// CreationDate: 15/12/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// </summary>
        private void LogCobis()
        {
            LogCobis datosLog = new LogCobis();
            datosLog.TipoTransaccion = TipoTransaccion;
            datosLog.XmlRequest = Request;
            datosLog.XmlResponse = Response;
            datosLog.Usuario = userName;
            datosLog.HoraRequest = HoraRequest;
            datosLog.HoraResponse = DateTime.Now.ToString(Parametros.Formatohhmmss);
            this.repositorioLogCobis.GuardarDatosLogEnTablaLogCobis(datosLog);
        }

        #endregion Metodos Privados
    }
}