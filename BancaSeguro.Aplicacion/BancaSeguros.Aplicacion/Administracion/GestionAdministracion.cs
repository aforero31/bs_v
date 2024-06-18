//-----------------------------------------------------------------------
// <copyright file="GestionAdministracion.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using BancaSeguros.Aplicacion.Configuraciones;
    using BancaSeguros.Entidades.Administracion;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Infraestructura.ManejoDocumentos;
    using BancaSeguros.Repositorio.Administracion;
    using BancaSeguros.Repositorio.Venta;

    /// <summary>
    /// Interface Management Administration
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 13/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionAdministracion" />
    public class GestionAdministracion : IGestionAdministracion
    {
        #region Variables

        /// <summary>
        /// The repository document policy
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioDocumentoPoliza repositorioDocumentoPoliza;

        /// <summary>
        /// The repository Channel sale
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioCanalVenta repositorioCanalVenta;

        /// <summary>
        /// The repository parameter
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioParametro repositorioParametro;

        /*private IGestionGenerico gestionGenerico;
        private BancaSeguros.Repositorio.IRepositorioGenerico repositorioGenerico;*/
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionAdministracion"/> class.
        /// </summary>
        /// <param name="interfazRepositorioDocumentoPoliza">The interface repository document policy.</param>
        /// <param name="interfazRepositorioCanalVenta">The interface repository  channel sale.</param>
        /// <param name="interfazRepositorioParametro">The interface repository  parameter.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public GestionAdministracion(IRepositorioDocumentoPoliza interfazRepositorioDocumentoPoliza, IRepositorioCanalVenta interfazRepositorioCanalVenta, IRepositorioParametro interfazRepositorioParametro)
        {
            this.repositorioDocumentoPoliza = interfazRepositorioDocumentoPoliza;
            this.repositorioCanalVenta = interfazRepositorioCanalVenta;
            this.repositorioParametro = interfazRepositorioParametro;
        }

        #endregion

        #region Metodos Publicos

        #region Parametrizacion Documento Poliza

        /// <summary>
        /// Preview template policy.
        /// </summary>
        /// <param name="entradaPrevisualizacionDocumentoPoliza">Entry Preview template policy.</param>
        /// <returns>Entity result document policy</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 22/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ResultadoDocumentoPoliza PrevisualizarPlantilla(EntradaPrevisualizacionDocumentoPoliza entradaPrevisualizacionDocumentoPoliza)
        {
            ResultadoDocumentoPoliza resultado = new ResultadoDocumentoPoliza();
            XElement plantillaXml;

            try
            {
                resultado.Resultado = new Resultado();
                plantillaXml = XElement.Parse(entradaPrevisualizacionDocumentoPoliza.DatosXML);
                plantillaXml = this.AjustarDatosSegunParametrizacion(plantillaXml, entradaPrevisualizacionDocumentoPoliza.Campos);
                resultado.ArchivoPolizaPdf = PreviewDocumentoPlantilla.GenerarDocumento(plantillaXml, entradaPrevisualizacionDocumentoPoliza.Plantilla.ToArray(), entradaPrevisualizacionDocumentoPoliza.RutaArchivo);
            }
            catch (Exception exc)
            {
                resultado.Resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoParametrizacionPlantilla), exc, LlavesAplicacion.CatchPrevisualizarPlantilla);
            }

            return resultado;
        }

        /// <summary>
        /// Inserts the document template sure.
        /// </summary>
        /// <param name="documentoPoliza">The document policy.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 09/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado InsertarDocumentoPlantillaSeguro(DocumentoPoliza documentoPoliza)
        {
            Resultado resultado = new Resultado();
            try
            {
                /*string versionSiguiente = string.Empty;
                if (!string.IsNullOrEmpty(documentoPoliza.VersionDocumento))
                    documentoPoliza.VersionDocumento = string.Format(Parametros.VersionDocumento, documentoPoliza.VersionDocumento.Split('.')[0], 1 + int.Parse(documentoPoliza.VersionDocumento.Split('.')[1].ToString()));
                else
                    documentoPoliza.VersionDocumento = string.Format(Parametros.VersionDocumento, "1", "0");*/

                resultado = this.repositorioDocumentoPoliza.InsertarDocumentoPlantillaSeguro(documentoPoliza);
            }
            catch (Exception exc)
            {
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoParametrizacionPlantilla), exc, LlavesAplicacion.CatchGenerarPlantilla);
            }
            return resultado;
        }

        /// <summary>
        /// get the templates of identifier sure.
        /// </summary>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <returns>List Entity Document policy</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 22/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<DocumentoPoliza> ObtenerPlantillasPorIdSeguro(int idSeguro)
        {
            return this.repositorioDocumentoPoliza.ObtenerPlantillasPorIdSeguro(idSeguro);
        }

        /// <summary>
        /// Delete the template.
        /// </summary>
        /// <param name="idDocumentoPlantilla">The identifier document template.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 23/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado EliminarPlantilla(int idDocumentoPlantilla)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioDocumentoPoliza.EliminarPlantilla(idDocumentoPlantilla);
            }
            catch (Exception exc)
            {
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoParametrizacionPlantilla), exc, LlavesAplicacion.CatchEliminarPlantilla);
            }

            return resultado;
        }

        /// <summary>
        /// Get the document policy of identifier document policy.
        /// </summary>
        /// <param name="idDocumentoPoliza">The identifier document policy.</param>
        /// <returns>Entity document policy</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 29/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DocumentoPoliza ObtenerDocumentoPolizaPorIdDocumentoPoliza(int idDocumentoPoliza)
        {
            return this.repositorioDocumentoPoliza.ObtenerDocumentoPolizaPorIdDocumentoPoliza(idDocumentoPoliza);
        }

        /// <summary>
        /// Active the estate template.
        /// </summary>
        /// <param name="idDocumentoPlantilla">The identifier document template.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 23/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActivarEstadoPlantilla(int idDocumentoPlantilla)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioDocumentoPoliza.ActivarEstadoPlantilla(idDocumentoPlantilla);
                if (!resultado.Error)
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoParametrizacionPlantilla), LlavesAplicacion.PlantillaActivada);
            }
            catch (Exception exc)
            {
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoParametrizacionPlantilla), exc, LlavesAplicacion.CatchEliminarPlantilla);
            }
            return resultado;
        }

        #endregion

        #region Parametrizacion Canal Venta

        /// <summary>
        /// Save the Channel sale.
        /// </summary>
        /// <param name="canalVenta">The Channel sale.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GuardarCanalVenta(CanalVenta canalVenta)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioCanalVenta.GuardarCanalVenta(canalVenta);

                if (resultado.Error)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoParametrizacionCanalVenta), LlavesAplicacion.CanalVentaExisteInsertar); 
                    resultado.Error = true;
                }
                else if (!resultado.Error)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoParametrizacionCanalVenta), LlavesAplicacion.CanalVentaGuardado); 
                    resultado.Error = false;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoParametrizacionCanalVenta), ex, LlavesAplicacion.CatchCanalVentaInsertar).Mensaje;  
            }
            return resultado;
        }

        /// <summary>
        /// Update the channel sale of identifier.
        /// </summary>
        /// <param name="canalVenta">The channel sale.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizaCanalVentaPorId(CanalVenta canalVenta)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioCanalVenta.ActualizaCanalVentaPorId(canalVenta);
                if (resultado.Error)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoParametrizarCanalVentaActualizar), LlavesAplicacion.CanalVentaNoActualizado);
                    resultado.Error = true;

                }
                else if (!resultado.Error)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoParametrizarCanalVentaActualizar), LlavesAplicacion.CanalVentaActualizado);
                    resultado.Error = false;
                }

            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoParametrizarCanalVentaActualizar), ex, LlavesAplicacion.CatchCanalVentaActualizar).Mensaje;
            }
            return resultado;
        }

        #endregion

        #region Parametrizacion General

        /// <summary>
        /// Save the parameter.
        /// </summary>
        /// <param name="parametro">The parameter.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GuardarParametro(Parametro parametro)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioParametro.GuardarParametro(parametro);

                if (resultado.Error)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoParametrizacionGeneral), LlavesAplicacion.ParametroExisteInsertar); 
                    resultado.Error = true;
                }
                else if (!resultado.Error)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoParametrizacionGeneral), LlavesAplicacion.ParametroGuardadoInsertar); 
                    resultado.Error = false;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoParametrizacionGeneral), ex, LlavesAplicacion.CatchParametroInsertar).Mensaje;
            }
            return resultado;
        }

        /// <summary>
        /// Update the parameter of identifier.
        /// </summary>
        /// <param name="parametro">The parameter.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizaParametroPorId(Parametro parametro)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioParametro.ActualizaParametroPorId(parametro);
                if (!resultado.Error)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoActualizarParametro), LlavesAplicacion.ParametroActualizado);
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoActualizarParametro), ex, LlavesAplicacion.CatchParametroActualizar).Mensaje;
            }

            return resultado;
        }

        #endregion

        #endregion

        #region Metodos Privados

        /// <summary>
        /// Sets the date by parameterization.
        /// </summary>
        /// <param name="datosPoliza">date policy.</param>
        /// <param name="camposConfigurados">fields configured.</param>
        /// <returns>Element x</returns>
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
                    this.AjustarDatosSegunParametrizacion(elemento, camposConfigurados);
                }
            }

            return resultado;
        }

        #endregion
    }
}
