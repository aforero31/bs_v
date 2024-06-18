using BancaSeguros.Aplicacion.Configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.IO;
using System.Xml;

namespace BancaSeguros.Aplicacion.Cobis
{
    public class GestionTransaccion : IGestionTransaccion
    {
        public bool ConsultarDiaHabil(DateTime dia)
        {
            bool esDiaHabil = false;

            try
            {
                string fecha = this.ConcatenarFechaAEnviar(dia);
                string methodName = "OpValidarDiaTransaccionSolicitud";
                string rutaServicioTransaccion = ConfigurationManager.AppSettings.Get(Parametros.RutaServicioTransaccion);

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
                soapRequest.Append("<ser:opValidarDiaTransaccionSolicitud>");
                soapRequest.Append(XML_RequestCobis.DtoContextoTransaccional);
                soapRequest.Append(string.Format(XML_RequestCobis.DtoIdentificadorTransaccional, "145778147"));
                soapRequest.Append(string.Format(XML_RequestCobis.DtoFecTransaccion, DateTime.Now));
                soapRequest.Append(string.Format(XML_RequestCobis.DtoCodCanalOriginador, "1"));
                soapRequest.Append(string.Format(XML_RequestCobis.DtoCodProcesoOriginador, "ConsultarDiaHabil"));
                soapRequest.Append(string.Format(XML_RequestCobis.DtoCodFuncionalidadOriginador, "ConsultarDiaHabil"));
                soapRequest.Append(string.Format(XML_RequestCobis.DtoIpConsumidor, "192.168.16.15"));
                soapRequest.Append(XML_RequestCobis.DtoContextoTransaccionalCierre);
                soapRequest.Append("<dto:diaTransaccion>");
                soapRequest.Append("<dto:fechaActual>" + fecha + "</dto:fechaActual>");
                soapRequest.Append("<dto:fecProximoDiaHabil></dto:fecProximoDiaHabil>");
                soapRequest.Append("<dto:fecAnteriorDiaHabil/>");
                soapRequest.Append("<dto:codEsHabil/>");
                soapRequest.Append("</dto:diaTransaccion>");
                soapRequest.Append("</ser:opValidarDiaTransaccionSolicitud>");
                soapRequest.Append(XML_RequestCobis.SoapBodyCierre);
                soapRequest.Append(XML_RequestCobis.SoapEnvelopeCerrar);
                streamWriter.Write(soapRequest.ToString());
                streamWriter.Close();

                HttpWebResponse wr = (HttpWebResponse)httpRequest.GetResponse();
                StreamReader srd = new StreamReader(wr.GetResponseStream());
                string resulXmlFromWebService = srd.ReadToEnd();
                ServicioCobisTransaccion.ContextoRespuesta contextoRespuesta = this.XmltoContextoRespuesta(resulXmlFromWebService, "ns2");


                ServicioCobisTransaccion.DiaTransaccion diaTransaccion = this.XmltoDiaTransaccion(resulXmlFromWebService, "ns2");

                if (contextoRespuesta.codTipoRespuesta == "0" && diaTransaccion.codEsHabil == 1)
                {
                    esDiaHabil = true;
                }
                else
                {
                    esDiaHabil = false;
                }

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
                        throw new Exception("Error en Cobis - " + co.detalleRespuesta[0].codTipoDetalleRespuesta + " - " + co.detalleRespuesta[0].valDescripcionDetalleRespuesta);
                    }
                    else
                    {
                        throw new Exception("Error en Cobis - " + co.codTipoRespuesta + " - " + co.valDescripcionRespuesta);
                    }
                }
            }

            return esDiaHabil;
        }

        public bool ConsultarDiaHabilNormal(DateTime dia)
        {
            bool esDiaHabil = false;

            ServicioCobisTransaccion.ContextoTransaccional contextoTransaccional = new ServicioCobisTransaccion.ContextoTransaccional();
            contextoTransaccional.identificadorTransaccional = "145778147";
            contextoTransaccional.fecTransaccion = DateTime.Now;
            contextoTransaccional.codCanalOriginador = "1";
            contextoTransaccional.codProcesoOriginador = "ConsultarDiaHabil";
            contextoTransaccional.codFuncionalidadOriginador = "ConsultarDiaHabil";
            contextoTransaccional.ipConsumidor = "192.168.16.15";

            ServicioCobisTransaccion.DiaTransaccion diaTransaccion = new ServicioCobisTransaccion.DiaTransaccion();
            diaTransaccion.codEsHabilSpecified = false;
            diaTransaccion.fecAnteriorDiaHabilSpecified = false;
            diaTransaccion.fecProximoDiaHabilSpecified = false;
            diaTransaccion.fechaActual = dia;
            diaTransaccion.fechaActualSpecified = false;

            using (ServicioCobisTransaccion.SrvAplCobisTransaccionClient cliente = new ServicioCobisTransaccion.SrvAplCobisTransaccionClient())
            {
                cliente.OpValidarDiaTransaccion(contextoTransaccional, ref diaTransaccion);
            }

            return esDiaHabil;
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
        private ServicioCobisTransaccion.DiaTransaccion XmltoDiaTransaccion(string resulXmlFromWebService, string n)
        {
            XmlDocument xmlDocumento = new XmlDocument();
            xmlDocumento.LoadXml(resulXmlFromWebService);
            XmlElement root = xmlDocumento.DocumentElement;
            string tag = string.Empty;

            if (n == "ns2")
            {
                tag = n + ":diaTransaccion";
            }

            XmlNodeList nodesDiaTransaccion = root.GetElementsByTagName(tag);


            ServicioCobisTransaccion.DiaTransaccion diaTransaccion = new ServicioCobisTransaccion.DiaTransaccion();

            foreach (XmlNode childrenNode in nodesDiaTransaccion)
            {
                for (int i = 0; i < childrenNode.ChildNodes.Count; i++)
                {
                    switch (childrenNode.ChildNodes[i].LocalName)
                    {
                        case "fechaActual":
                            diaTransaccion.fechaActual = Convert.ToDateTime(childrenNode.ChildNodes[i].InnerText);
                            break;
                        case "fecProximoDiaHabil":
                            diaTransaccion.fecProximoDiaHabil = Convert.ToDateTime(childrenNode.ChildNodes[i].InnerText);
                            break;
                        case "fecAnteriorDiaHabil":
                            diaTransaccion.fecAnteriorDiaHabil = Convert.ToDateTime(childrenNode.ChildNodes[i].InnerText);
                            break;
                        case "codEsHabil":
                            diaTransaccion.codEsHabil = int.Parse(childrenNode.ChildNodes[i].InnerText);
                            break;
                    }
                }
            }

            return diaTransaccion;
        }

        private string ConcatenarFechaAEnviar(DateTime dia)
        {
            string mesC = string.Empty;
            string diaC = string.Empty;

            if (dia.Month.ToString().Length == 1)
            {
                mesC = dia.Month.ToString().PadLeft(2, '0');
            }
            else
            {
                mesC = dia.Month.ToString();
            }

            if (dia.Day.ToString().Length == 1)
            {
                diaC = dia.Day.ToString().PadLeft(2, '0');
            }
            else
            {
                diaC = dia.Day.ToString();
            }

            string fecha = dia.Year + "-" + mesC + "-" + diaC;

            return fecha;
        }
    }
}