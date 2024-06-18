//-----------------------------------------------------------------------
// <copyright file="GestionVenta.cs" company="UT">
//     Copyright (c) UT. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Venta
{
    using BancaSeguros.Aplicacion.Cobis;
    using BancaSeguros.Aplicacion.Configuraciones;
    using BancaSeguros.Entidades;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Infraestructura.ManejoDocumentos;
    using BancaSeguros.Repositorio.Venta;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Transactions;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    /// <summary>
    /// Clase para la gestion de la venta
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 05/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public class GestionVenta : IGestionVenta
    {
        #region Variables

        /// <summary>
        /// The repository sure
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioSeguro repositorioSeguro;

        /// <summary>
        /// The repository sale
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioVenta repositorioVenta;

        /// <summary>
        /// The repository plan
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioPlan repositorioPlan;

        /// <summary>
        /// The repository product no access
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioProductoNoPermitido repositorioProductoNoPermitido;

        /// <summary>
        /// The repository document policy
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioDocumentoPoliza repositorioDocumentoPoliza;

        /// <summary>
        /// The repository document policy
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\Enrique Rivera
        /// CreationDate: 25/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioLogCobis repositorioLogCobis;

        /// <summary>
        /// The management agreement
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionConvenio gestionConvenio;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionVenta"/> class.
        /// </summary>
        /// <param name="repositorioSeguro">The repository sure.</param>
        /// <param name="repositorioVenta">The repository sale.</param>
        /// <param name="repositorioPlan">The repository plan.</param>
        /// <param name="repositorioProductoNoPermitido">The repository product no access.</param>
        /// <param name="repositorioDocumentoPoliza">The repository document policy.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public GestionVenta(IRepositorioSeguro repositorioSeguro, IRepositorioVenta repositorioVenta, IRepositorioPlan repositorioPlan, IRepositorioProductoNoPermitido repositorioProductoNoPermitido, IRepositorioDocumentoPoliza repositorioDocumentoPoliza, IRepositorioLogCobis repositorioLogCobis)
        {
            this.repositorioSeguro = repositorioSeguro;
            this.repositorioVenta = repositorioVenta;
            this.repositorioPlan = repositorioPlan;
            this.repositorioProductoNoPermitido = repositorioProductoNoPermitido;
            this.repositorioDocumentoPoliza = repositorioDocumentoPoliza;
            this.repositorioLogCobis = repositorioLogCobis;
            this.gestionConvenio = new GestionConvenio();
        }

        #endregion Constructor

        #region Metodos Publicos

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
            return this.repositorioSeguro.ConsultarLosSegurosAVender(idTipoDeIdentificacion, fechaDeNacimientoCliente, genero);
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
            Resultado resultado = new Resultado();
            List<Seguro> seguros = new List<Seguro>();
            seguros = this.repositorioSeguro.ConsultarSegurosPorCodigoYAseguradora(codigoSeguro, codigoAseguradora);

            if (seguros.Count > 0)
            {
                resultado.Error = true;
                resultado.Mensaje = Mensajes.CodigoSeguroExiste;
            }

            return resultado;
        }

        #endregion Seguro

        #region Plan

        /// <summary>
        /// Get the plans of identifier sure.
        /// </summary>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <returns>List Entity plan</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IEnumerable<Plan> ConsultarPlanesPorIdSeguro(int idSeguro)
        {
            List<Plan> planes = new List<Plan>();
            List<Plan> planesDevueltos = new List<Plan>();

            try
            {
                planes = this.repositorioPlan.ConsultarPlanesPorIdSeguro(idSeguro).ToList();
                planesDevueltos = planes.FindAll(x => x.Activo == true);
            }
            catch (Exception)
            {
                planesDevueltos = new List<Plan>();
            }

            return planesDevueltos;
        }

        #endregion Plan

        #region Generar Venta

        /// <summary>
        /// Genera el proceso final de la venta.
        /// </summary>
        /// <param name="registrarVenta">Objeto con la informacion para registrar la venta.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author:
        /// CreationDate: 09/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ResultadoVentaPoliza GenerarProcesoFinalDeLaVenta(RegistrarVenta registrarVenta, IGestionCobis gestionCobis)
        {
            ResultadoVentaPoliza resultadoVentaPoliza = new ResultadoVentaPoliza();
            resultadoVentaPoliza.Resultado = new Resultado();
            string ControlError = string.Empty;
            string consecutivoVenta = string.Empty;
            LogCobis datosLog = new LogCobis();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    if (registrarVenta.Consecutivo == null || registrarVenta.Consecutivo == string.Empty)
                    {
                        registrarVenta.Consecutivo = this.repositorioVenta.ObtenerConsecutivo(registrarVenta);
                    }
                    else
                    {
                        bool ActualizoConsecutivo = this.repositorioVenta.ActualizarSiguienteConsecutivo(registrarVenta);
                    }

                    consecutivoVenta = registrarVenta.Consecutivo;
                    if (registrarVenta.Consecutivo == string.Empty)
                    {
                        ControlError = "RV001";
                        resultadoVentaPoliza.Resultado.Error = true;
                    }

                    if (!resultadoVentaPoliza.Resultado.Error)
                    {
                        resultadoVentaPoliza.Resultado.Error = this.repositorioVenta.GuardarDatosVentaEnTablaAsesor(registrarVenta.Asesor);
                    }

                    if (!resultadoVentaPoliza.Resultado.Error)
                    {
                        registrarVenta.Cliente.IdGenero = ListaGeneroPublica.ObtenerListaGeneros().FirstOrDefault(r => r.Value.ToLower().Equals(registrarVenta.Cliente.Genero.ToLower())).Key;
                        registrarVenta = this.repositorioVenta.GuardarDatosVentaEnTablaVenta(registrarVenta);
                    }
                    else if (ControlError == string.Empty)
                    {
                        ControlError = "RV002";
                        resultadoVentaPoliza.Resultado.Error = true;
                    }

                    if (!resultadoVentaPoliza.Resultado.Error && registrarVenta.IdVenta != 0)
                    {
                        resultadoVentaPoliza.Resultado.Error = !RegistrarVentaBeneficiario(registrarVenta);
                    }
                    else if (ControlError == string.Empty)
                    {
                        ControlError = "RV007";
                        resultadoVentaPoliza.Resultado.Error = true;
                    }

                    if (!resultadoVentaPoliza.Resultado.Error)
                    {
                        if (registrarVenta.Conyuge != null)
                        {
                            registrarVenta.Conyuge.IdVenta = registrarVenta.IdVenta;
                            registrarVenta.Conyuge.IdGenero = ListaGeneroPublica.ObtenerListaGeneros().FirstOrDefault(r => r.Value.ToLower().Equals(registrarVenta.Conyuge.Genero.ToLower())).Key.ToString();
                            resultadoVentaPoliza.Resultado.Error = !this.repositorioVenta.GuardarDatosVentaEnTablaConyugue(registrarVenta.Conyuge);
                        }
                    }
                    else if (ControlError == string.Empty)
                    {
                        ControlError = "RV004";
                        resultadoVentaPoliza.Resultado.Error = true;
                    }

                    if (!resultadoVentaPoliza.Resultado.Error)
                    {
                        resultadoVentaPoliza.Resultado.Error = !RegistrarVariablesVenta(registrarVenta);
                    }
                    else if (ControlError == string.Empty)
                    {
                        ControlError = "RV003";
                        resultadoVentaPoliza.Resultado.Error = true;
                    }

                    if (!resultadoVentaPoliza.Resultado.Error)
                    {
                        resultadoVentaPoliza.Resultado = gestionCobis.GenerarRecaudoACliente(registrarVenta, ref datosLog, consecutivoVenta);

                        if (resultadoVentaPoliza.Resultado.Error)
                        {
                            ControlError = resultadoVentaPoliza.Resultado.Mensaje;
                            resultadoVentaPoliza.Consecutivo = registrarVenta.Consecutivo;
                        }
                    }
                    else if (ControlError == string.Empty)
                    {
                        ControlError = "RV010";
                        resultadoVentaPoliza.Resultado.Error = true;

                    }

                    if (!resultadoVentaPoliza.Resultado.Error)
                    {
                        scope.Complete();
                        ControlError = "RV008";
                    }
                }

                if (resultadoVentaPoliza.Resultado.Error)
                {
                    Exception ex = new Exception("Error en venta de seguro. Variable control:" + ControlError);
                    resultadoVentaPoliza.Resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaGuardar), ControlError);
                    BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoRegistrarVentaGuardar), ex, ControlError);

                    resultadoVentaPoliza.Resultado.Error = true;

                }
                else
                {
                    resultadoVentaPoliza.Resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaGuardar), ControlError);
                    resultadoVentaPoliza.Resultado.Mensaje += registrarVenta.Consecutivo;
                    resultadoVentaPoliza.Consecutivo = registrarVenta.Consecutivo;
                    resultadoVentaPoliza.Resultado.Error = false;
                }

                this.repositorioLogCobis.GuardarDatosLogEnTablaLogCobis(datosLog);
            }
            catch (Exception ex)
            {
                if (datosLog.TipoTransaccion != null)
                    this.repositorioLogCobis.GuardarDatosLogEnTablaLogCobis(datosLog);

                resultadoVentaPoliza.Resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoRegistrarVentaGuardar), ex, ControlError);
                resultadoVentaPoliza.Resultado.Error = true;
            }

            return resultadoVentaPoliza;
        }

        /// <summary>
        /// Obtiene el documento de venta poliza.
        /// </summary>
        /// <param name="idVentaPoliza">idVentaPoliza.</param>
        /// <param name="idSeguro"> idSeguro.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 18/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ResultadoDocumentoPoliza ObtenerDocumentoVentaPoliza(string consecutivoPoliza, int idSeguro, string rutaArchivo)
        {
            ResultadoDocumentoPoliza resultado = new ResultadoDocumentoPoliza();
            resultado.Resultado = new Resultado();
            var controlError = "RV009";

            try
            {
                DocumentoPoliza documento = this.repositorioDocumentoPoliza.ObtenerDocumentoPolizaPorIdSeguro(idSeguro);
                DatosPolizaDocumento datosDocumentoPoliza = new DatosPolizaDocumento();
                StringWriter strWriter = new StringWriter();
                XmlDocument xmlDocumento = new XmlDocument();
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                datosDocumentoPoliza.BeneficiariosPolizaDocumento = this.repositorioDocumentoPoliza.ObtenerInformacionBeneficiariosDocumentoPoliza(consecutivoPoliza).ToList();
                datosDocumentoPoliza.EncabezadoPoliza = this.repositorioDocumentoPoliza.ObtenerInformacionEncabezadoDocumentoPoliza(consecutivoPoliza);
                datosDocumentoPoliza.ConyugePolizaDocumento = this.repositorioDocumentoPoliza.ObtenerInformacionConyugeDocumentoPoliza(consecutivoPoliza);

                XmlSerializer serializadorXml = new XmlSerializer(datosDocumentoPoliza.GetType());
                namespaces.Add(string.Empty, string.Empty);
                serializadorXml.Serialize(strWriter, datosDocumentoPoliza, namespaces);
                strWriter.Close();

                var serializado = strWriter.ToString();
                xmlDocumento.LoadXml(serializado);
                VariableVenta vv = new VariableVenta();
                vv.ConsecutivoPoliza = consecutivoPoliza;
                datosDocumentoPoliza.VariablesPolizaDocumento = this.repositorioDocumentoPoliza.ObtenerInformacionVariableVentaDocumentoPoliza(vv);

                if (datosDocumentoPoliza.VariablesPolizaDocumento.Count > 0)
                {
                    XDocument doc = ToXDocument(xmlDocumento);
                    doc.Root.Add(
                        new XElement("VariablesPolizaDocumento",
                              from c in datosDocumentoPoliza.VariablesPolizaDocumento
                              select
                              new XElement("CampoVariable" + c.Orden.ToString(), c.NombreValor)));

                    xmlDocumento = ToXmlDocument(doc);
                    serializado = "<?xml version='1.0' encoding='utf-16'?>" + AsString(xmlDocumento);
                }

                xmlDocumento.SelectSingleNode(Parametros.DatosPolizaDocumento);
                XElement plantillaXml = XElement.Parse(serializado);
                plantillaXml = AjustarDatosSegunParametrizacion(plantillaXml, documento.CamposPlantilla);
                string NombreDocumento = DocumentoPlantilla.GenerarDocumento(plantillaXml, documento.Plantilla, rutaArchivo);
                if (NombreDocumento != "Error")
                {
                    string archivoPdf = rutaArchivo + consecutivoPoliza + ".pdf";
                    File.Delete(archivoPdf);
                    resultado.RutaArchivo = DocumentoPlantilla.ObtenerRutaConvertWord2PDF(rutaArchivo + NombreDocumento, archivoPdf);
                    File.Delete(rutaArchivo + NombreDocumento);
                    resultado.Resultado = this.repositorioDocumentoPoliza.GuardarPolizaVendidaImpresion(plantillaXml, documento.IdDocumentoPoliza, consecutivoPoliza);
                }
            }
            catch (Exception ex)
            {
                resultado.Resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoRegistrarVentaGuardar), ex, controlError);
            }
            return resultado;
        }

        #endregion Generar Venta

        #region Producto

        /// <summary>
        /// Get the products no access of sure.
        /// </summary>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <returns>List Entity Product</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IEnumerable<ProductoNoPermitido> ConsultarProductosNoPermitidosPorSeguro(int idSeguro)
        {
            return this.repositorioProductoNoPermitido.ConsultarProductosNoPermitidosPorSeguro(idSeguro);
        }

        #endregion Producto

        #region Consultar Venta

        public List<ConsultarVenta> ConsultarVentaPorCliente(Cliente cliente)
        {
            List<ConsultarVenta> listaConsulta = new List<ConsultarVenta>();
            ConsultarVenta consultarVenta = new ConsultarVenta();
            Resultado resultado = new Resultado();
            try
            {
                listaConsulta = this.repositorioVenta.ConsultarVentaPorCliente(cliente);
                if (listaConsulta.Count > 0)
                {
                    resultado.Error = false;
                }
                else
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoConsultarVentaBuscarPolizaCliente), "CV001");
                    consultarVenta.Resultado = resultado;
                    listaConsulta.Add(consultarVenta);
                }
            }
            catch (Exception ex)
            {
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoConsultarVentaBuscarPolizaCliente), ex, "CV002");
                listaConsulta = new List<ConsultarVenta>();
                consultarVenta.Resultado = resultado;
                listaConsulta.Add(consultarVenta);
            }
            return listaConsulta;
        }

        public List<ConsultarVenta> ConsultarVentaPorClienteDiaHabil(Cliente cliente)
        {
            List<ConsultarVenta> listaConsulta = new List<ConsultarVenta>();
            ConsultarVenta consultarVenta = new ConsultarVenta();
            Resultado resultado = new Resultado();
            try
            {
                listaConsulta = this.repositorioVenta.ConsultarVentaPorClienteDiaHabil(cliente);
                if (listaConsulta.Count > 0)
                {
                    resultado.Error = false;
                }
                else
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoConsultarVentaBuscarPolizaCliente), "CV001");
                    resultado.Error = true;
                    consultarVenta.Resultado = resultado;
                    listaConsulta.Add(consultarVenta);
                }
            }
            catch (Exception ex)
            {
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoConsultarVentaBuscarPolizaCliente), ex, "CV002");
                resultado.Error = true;
                listaConsulta = new List<ConsultarVenta>();
                consultarVenta.Resultado = resultado;
                listaConsulta.Add(consultarVenta);
            }
            return listaConsulta;
        }

        /// <summary>
        /// Obtiene el documento de venta poliza.
        /// </summary>
        /// <param name="idVentaPoliza">idVentaPoliza.</param>
        /// <param name="idSeguro"> idSeguro.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 18/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ResultadoDocumentoPoliza ConsultarPolizaReimpresion(string consecutivoPoliza, string rutaArchivo)
        {
            ResultadoDocumentoPoliza resultado = new ResultadoDocumentoPoliza();
            resultado.Resultado = new Resultado();
            var controlError = "RIW003";
            try
            {
                DocumentoPoliza documento = this.repositorioDocumentoPoliza.ConsultarInformacionReimpresion(consecutivoPoliza);

                if (documento.PlantillaXml != null && documento.Plantilla != null)
                {

                    resultado = generaDocumento(documento, consecutivoPoliza, rutaArchivo);

                }
                else
                {
                    int idSeguro = this.repositorioDocumentoPoliza.ConsultarSeguroPorConsecutivoPoliza(consecutivoPoliza);

                    if (idSeguro != 0)
                    {
                        ResultadoDocumentoPoliza resultadoDocumentoPoliza = ObtenerDocumentoVentaPoliza(consecutivoPoliza, idSeguro, rutaArchivo);
                        DocumentoPoliza documento2 = this.repositorioDocumentoPoliza.ConsultarInformacionReimpresion(consecutivoPoliza);               

                        if (documento2.PlantillaXml != null && documento2.Plantilla != null && !resultadoDocumentoPoliza.Resultado.Error)
                        {
                            resultado = generaDocumento(documento2, consecutivoPoliza, rutaArchivo);
                        }
                        else
                        {
                            resultado.Resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoReimpresionPlantilla), controlError);
                            resultado.Resultado.Mensaje = resultado.Resultado.Mensaje + 
                                (!resultadoDocumentoPoliza.Resultado.Error ? " - No hay datos Almacenados, puede volver a intentarlo" : " - Se produjo un error al obtener el documento de venta de poliza, puede volver a intentarlo");                       
                            resultado.Resultado.Error = true;
                        }
                    } else
                    {
                        resultado.Resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoReimpresionPlantilla), controlError);
                        resultado.Resultado.Mensaje = resultado.Resultado.Mensaje + " - No se pudo identificar el id del seguro para el respectivo consecutivo";
                        resultado.Resultado.Error = true;
                    }
                 
                }
            }
            catch (Exception ex)
            {
                resultado.Resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoReimpresionPlantilla), ex, controlError);
            }
            return resultado;
        }


        /// <summary>
        /// Genera documento pdf.
        /// </summary>
        /// <param name="documento">The client.</param>
        /// <param name="consecutivoPoliza">The client.</param>
        /// <param name="rutaArchivo">The client.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CALVAREZP
        /// CreationDate: 2020-09-29
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ResultadoDocumentoPoliza generaDocumento(DocumentoPoliza documento, string consecutivoPoliza, string rutaArchivo)
        {
            string NombreDocumento = DocumentoPlantilla.GenerarDocumento(documento.PlantillaXml, documento.Plantilla, rutaArchivo);
            ResultadoDocumentoPoliza resultado = new ResultadoDocumentoPoliza();
            resultado.Resultado = new Resultado();

            if (NombreDocumento != "Error")
            {
                string archivoPdf = rutaArchivo + consecutivoPoliza + ".pdf";
                File.Delete(archivoPdf);
                resultado.RutaArchivo = DocumentoPlantilla.ObtenerRutaConvertWord2PDF(rutaArchivo + NombreDocumento, archivoPdf);
                File.Delete(rutaArchivo + NombreDocumento);
            }
            else
                resultado.Resultado.Error = true;


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
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioVenta.ConsultarVentasCuentasPorCliente(cliente);

                var filas = resultado.Mensaje.Split('|');

                var emptyList =
                    new List<Tuple<int, string>>().Select(t => new { tipoCuenta = t.Item1, numeroCuenta = t.Item2 })
                        .ToList();

                foreach (var item in filas)
                {
                    if (item.Split('-').Length > 1)
                    {
                        emptyList.Add(new
                        {
                            tipoCuenta = Int32.Parse(item.Split('-')[0]),
                            numeroCuenta = item.Split('-')[1]
                        });
                    }
                }

                int numeroSegurosVendidosPorCuenta = emptyList.Count(n => n.tipoCuenta == int.Parse(cliente.ProductoBancario.CodigoProducto)
                                             && n.numeroCuenta == cliente.ProductoBancario.NumeroCuenta);

                var distintasCuentas = emptyList.GroupBy(test => test.numeroCuenta)
                    .Select(grp => grp.First())
                    .ToList().Count;

                distintasCuentas = (numeroSegurosVendidosPorCuenta == 0 ? distintasCuentas + 1 : distintasCuentas);

                IEnumerable<Seguro> ListaSeguros = ConsultarLosSegurosAVender(cliente.TipoIdentificacion.IdTipoIdentificacion, cliente.FechaNacimiento, cliente.IdGenero);
                var result = ListaSeguros.Where(c => c.Codigo == cliente.CodigoSeguro.ToString()).FirstOrDefault();
                cliente.NumeroMaximoSegurosPorCliente = result.NumeroMaximoSegurosPorCliente;
                cliente.NumeroMaximoVentaSegurosPorCuentaCliente = result.NumeroMaximoVentaSegurosPorCuentaCliente;

                if (distintasCuentas > cliente.NumeroMaximoSegurosPorCliente && cliente.NumeroMaximoSegurosPorCliente != 0)
                {
                    resultado.Mensaje = Mensajes.NumeroCuentas;
                    resultado.Error = true;
                }
                else if (numeroSegurosVendidosPorCuenta + 1 > cliente.NumeroMaximoVentaSegurosPorCuentaCliente && cliente.NumeroMaximoVentaSegurosPorCuentaCliente != 0)
                {
                    resultado.Mensaje = Mensajes.NumeroVentas;
                    resultado.Error = true;
                }
                else
                {
                    resultado.Mensaje = "";
                }
            }
            catch (Exception exc)
            {
                resultado.Mensaje = exc.Message;
                resultado.Error = true;
            }

            return resultado;
        }

        #endregion Consultar Venta

        #endregion Metodos Publicos

        #region Metodos privados

        /// <summary>
        /// Save the sale variable.
        /// </summary>
        /// <param name="registrarVenta">The record sale.</param>
        /// <returns>Value of result</returns>
        private bool RegistrarVariablesVenta(RegistrarVenta registrarVenta)
        {
            bool ventaSatisfactoria = false;

            if (registrarVenta.VariablesVenta != null && registrarVenta.VariablesVenta.Count() > 0)
            {
                foreach (VariableVenta variable in registrarVenta.VariablesVenta)
                {
                    variable.IdVenta = registrarVenta.IdVenta;
                    ventaSatisfactoria = this.repositorioVenta.GuardarVariableVenta(variable);
                    if (ventaSatisfactoria == false)
                    {
                        break;
                    }
                }
            }
            else
            {
                ventaSatisfactoria = true;
            }

            return ventaSatisfactoria;
        }

        private bool RegistrarVentaBeneficiario(RegistrarVenta registrarVenta)
        {
            bool ventaSatisfactoria = false;

            if (registrarVenta.Beneficiario != null && registrarVenta.Beneficiario.Count() > 0)
            {
                foreach (Beneficiario beneficiario in registrarVenta.Beneficiario)
                {
                    beneficiario.IdVenta = registrarVenta.IdVenta;
                    ventaSatisfactoria = this.repositorioVenta.GuardarDatosVentaEnTablaBeneficiario(beneficiario);
                }
            }
            else
            {
                ventaSatisfactoria = true;
            }

            return ventaSatisfactoria;
        }

        /// <summary>
        /// convierte en AsString
        /// </summary>
        /// <param name="XmlDocument">documento a convertir</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\Enrique Rivera
        /// CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string AsString(XmlDocument xmlDoc)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (XmlTextWriter tx = new XmlTextWriter(sw))
                {
                    xmlDoc.WriteTo(tx);
                    string strXmlText = sw.ToString();
                    return strXmlText;
                }
            }
        }

        /// <summary>
        /// convierte en XDocument
        /// </summary>
        /// <param name="XmlDocument">documento a convertir</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\Enrique Rivera
        /// CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private XDocument ToXDocument(XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }

        /// <summary>
        /// convierte en XmlDocumento
        /// </summary>
        /// <param name="XDocument">documento a convertir</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\Enrique Rivera
        /// CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private XmlDocument ToXmlDocument(XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        /// <summary>
        /// Ajusta los datos segun parametrización.
        /// </summary>
        /// <param name="datosPoliza">Datos poliza.</param>
        /// <param name="camposConfigurados">Campos configurados.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 10/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private XElement AjustarDatosSegunParametrizacion(XElement datosPoliza, string camposConfigurados)
        {
            XElement resultado = datosPoliza;
            foreach (var elemento in resultado.Elements().ToArray())
            {
                if (!elemento.HasElements)
                {
                    if (!camposConfigurados.Split(',').Any(campo => campo.Equals(elemento.Name.ToString())))
                    {
                        elemento.Value = string.Empty;
                    }
                }
                else
                {
                    AjustarDatosSegunParametrizacion(elemento, camposConfigurados);
                }
            }
            return resultado;
        }

        #endregion Metodos privados
    }
}