//-----------------------------------------------------------------------
// <copyright file="GestionToken.cs" company="InterGrupo 2020">
//     Copyright (c) InterGrupo 2020. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using BancaSeguros.Aplicacion.Configuraciones;
using BancaSeguros.Entidades.General;
using BancaSeguros.Entidades.Venta;
using System;
using System.Configuration;

namespace BancaSeguros.Aplicacion.ListasInhibitorias
{
    /// <summary>
    /// Class Gestion de lista inhibitoria
    /// </summary>

    public class GestionListaInhibitoria : IGestionListaInhibitoria
    {
        #region Variables
        #endregion

        #region Constructor

        #endregion

        #region Metodos Publicos


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
        public Resultado ClienteEstaEnListasInhibitoriasActual(Cliente cliente, string token)
        {
            Resultado resultado = new Resultado();
            ContextoTransaccionalAPI contextoTransaccionalAPI = CargarContextoTransaccionalAPI();

            try
            {
                resultado = ConsultarListasInhibitoriasActual(cliente.TipoIdentificacion.Abreviatura, cliente.Identificacion, token, contextoTransaccionalAPI);

            }
            catch (Exception ex)
            {
                var controlError = LlavesAplicacion.ErrorAPILista;
                resultado.Error = true;
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarCliente), ex, controlError);
            }

            return resultado;
        }

        private Resultado ConsultarListasInhibitoriasActual(string tipoIdentificacion, string numeroIdentificacion, string token, ContextoTransaccionalAPI contextoTransaccional)
        {
            Resultado resultado = new Resultado();
            RequestListaInhibitoria dataListaInhibitoria = new RequestListaInhibitoria()
            {
                TipoDocumento = tipoIdentificacion,
                NumeroDocumento = numeroIdentificacion,
                ContextoTransaccional = contextoTransaccional,
                Token = token
            };

            string url = ConfigurationManager.AppSettings.Get("ServicioListaInhibitoria");

            string tipoPersona;
            if (dataListaInhibitoria.TipoDocumento != "N")
            {
                tipoPersona = "PN";
            }
            else
            {
                tipoPersona = "PJ";
            }

            url = url + tipoPersona + "?TipoDocumento=" + dataListaInhibitoria.TipoDocumento + "&NumeroDocumento=" + dataListaInhibitoria.NumeroDocumento;
           
            string respuestaListaInhibitoria = RestListasInhibitorias.GetResponse_GET(url, token, dataListaInhibitoria.ContextoTransaccional);
            ResponseListaInhibitoria responseListaInhibitoria = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseListaInhibitoria>(respuestaListaInhibitoria);
            var controlError = LlavesAplicacion.ErrorAPILista;
            if (responseListaInhibitoria != null)
            {
                if (responseListaInhibitoria.responseCode == "200")
                {
                    if (responseListaInhibitoria.resultData.existeInhibitorias == "Si")
                    {
                        controlError = LlavesAplicacion.ClienteEnListasInhibitorias;
                        resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarCliente), controlError);
                        resultado.Error = true;
                    }
                    else
                    {
                        resultado.Error = false;
                    }
                }
                else
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarCliente), controlError);
                    resultado.Error = true;
                }
            }
            else
            {
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoRegistrarVentaConsultarCliente), controlError);
                resultado.Error = true;
            }

            return resultado;
        }

        private ContextoTransaccionalAPI CargarContextoTransaccionalAPI()
        {
            ContextoTransaccionalAPI contextoTransaccional = new ContextoTransaccionalAPI();
            contextoTransaccional.IdentificadorTransaccional = ConfigurationManager.AppSettings.Get(Parametros.IdentificadorTransaccionalAPI);
            contextoTransaccional.CodCanalOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoCanalOriginadorAPI);
            contextoTransaccional.CodProcesoOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoProcesoOriginadorAPI);
            contextoTransaccional.CodFuncionalidadOriginador = ConfigurationManager.AppSettings.Get(Parametros.CodigoFuncionalidadOriginadorAPI);
            contextoTransaccional.IpConsumidor = ConfigurationManager.AppSettings.Get(Parametros.ipConsumidorAPI);
            contextoTransaccional.FecTransaccion = DateTime.Now.ToString("dd-MM-yyyyTHH:mm");

            return contextoTransaccional;
        }

        #endregion

    }
}
