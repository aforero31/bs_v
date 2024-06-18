//-----------------------------------------------------------------------
// <copyright file="ServicioControlDual.svc.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.ServiciosWCF.ControlDual
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BAC.Seguridad.Seguridad;
    using BancaSeguros.Aplicacion.Administracion;
    using BancaSeguros.Entidades.Administracion;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Repositorio.Administracion;
    using BancaSeguros.Repositorio.Seguridad;
    using BancaSeguros.Repositorio.Venta;
    using Newtonsoft.Json;
    using BancaSeguros.Repositorio;
    using BancaSeguros.Aplicacion;
    using Repositorio.Log;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioControlDual" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioControlDual.svc or ServicioControlDual.svc.cs at the Solution Explorer and start debugging.

    /// <summary>
    /// Control Dual Service class
    /// </summary>
    /// <seealso cref="BancaSeguros.ServiciosWCF.ControlDual.IServicioControlDual" />
    public class ServicioControlDual : IServicioControlDual
    {
        #region Variables

        #region Repositorios

        /// <summary>
        /// The dual approval repository
        /// </summary>
        private IRepositorioAprobacionDual repositorioAprobacionDual;

        /// <summary>
        /// The roles repository
        /// </summary>
        private IRepositorioRol repositorioRol;

        /// <summary>
        /// The repository users
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioOficina repositorioOficina;

        /// <summary>
        /// The repository menu
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioMenu repositorioMenu;

        /// <summary>
        /// The repository permission
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioPermiso repositorioPermiso;

        /// <summary>
        /// The repository group bank
        /// </summary>
        private IRepositorioGrupoBAC repositorioGrupoBAC;

        /// <summary>
        /// The repository control dual
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioAdmonControlDual repositorioAdmonControlDual;

        /// <summary>
        /// The repository document policy
        /// </summary>
        private IRepositorioDocumentoPoliza repositorioDocumentoPoliza;

        /// <summary>
        /// The repository Channel sale
        /// </summary>
        private IRepositorioCanalVenta repositorioCanalVenta;

        /// <summary>
        /// The repository parameter
        /// </summary>
        private IRepositorioParametro repositorioParametro;

        /// <summary>
        /// The insurance repository
        /// </summary>
        private IRepositorioAseguradora repositorioAseguradora;

        /// <summary>
        /// The consumer's price index repository
        /// </summary>
        private IRepositorioIPC repositorioIPC;

        /// <summary>
        /// The novelty repository
        /// </summary>
        private IRepositorioNovedad repositorioNovedad;

        /// <summary>
        /// The repository secure
        /// </summary>
        private Repositorio.Administracion.IRepositorioSeguro repositorioSeguro;

        /// <summary>
        /// The repository plan
        /// </summary>
        private Repositorio.Administracion.IRepositorioPlan repositorioPlan;

        /// <summary>
        /// The repository product not access
        /// </summary>
        private IRepositorioProductoNoPermitido repositorioProductoNoPermitido;

        /// <summary>
        /// The repository type identification secure
        /// </summary>
        private IRepositorioTipoIdentificacionSeguro repositorioTipoIdentificacionSeguro;

        /// <summary>
        /// The repository Causal Novelty
        /// </summary>
        private IRepositorioCausalNovedad repositorioCausalNovedad;

        /// <summary>
        /// The interface message repository
        /// </summary>
        private IRepositorioMensaje repositorioMensaje;

        /// <summary>
        /// The generic repository
        /// </summary>
        private IRepositorioGenerico repositorioGenerico;

        /// <summary>
        /// The repository log
        /// </summary>
        private IRepositorioLog repositorioLog;

        /// <summary>
        /// The master repository
        /// </summary>
        private IRepositorioMaestra repositorioMaestra;

        /// <summary>
        /// The repository item master
        /// </summary>
        private IRepositorioItemMaestra repositorioItemMaestra;

        /// <summary>
        /// The product variable repository
        /// </summary>
        private IRepositorioVariableProducto repositorioVariableProducto;

        #endregion

        #region Negocio

        /// <summary>
        /// The administration manage
        /// </summary>
        private IGestionAdministracion gestionAdministracion;

        /// <summary>
        /// The security manage
        /// </summary>
        private IGestionSeguridad gestionSeguridad;

        /// <summary>
        /// The dual approval manage
        /// </summary>
        private IGestionAprobacionDual gestionAprobacionDual;

        /// <summary>
        /// The insurance manage
        /// </summary>
        private IGestionAseguradora gestionAseguradora;

        /// <summary>
        /// The consumer's price index manage
        /// </summary>
        private IGestionIPC gestionIPC;

        /// <summary>
        /// The novelty manage
        /// </summary>
        private IGestionNovedad gestionNovedad;

        /// <summary>
        /// The insurance manage
        /// </summary>
        private IGestionSeguro gestionSeguro;

        /// <summary>
        /// The Causal Novelty manage
        /// </summary>
        private IGestionCausalNovedad gestionCausalNovedad;

        /// <summary>
        /// The message manage
        /// </summary>
        private IGestionMensaje gestionMensaje;

        /// <summary>
        /// The generic manage
        /// </summary>
        private IGestionGenerico gestionGenerico;

        /// <summary>
        /// The master management
        /// </summary>
        private IGestionMaestra gestionMaestra;

        /// <summary>
        /// The master item management
        /// </summary>
        private IGestionItemMaestra gestionItemMaestra;

        /// <summary>
        /// The product variable management
        /// </summary>
        private IGestionVariableProducto gestionVariableProducto;

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicioControlDual"/> class.
        /// </summary>
        public ServicioControlDual()
        {
            this.repositorioAprobacionDual = new RepositorioAprobacionDual(Global.nombreConexionTeradata);
            this.repositorioRol = new RepositorioRol(Global.nombreConexionTeradata);
            this.repositorioOficina = new RepositorioOficina(Global.nombreConexionTeradata);
            this.repositorioMenu = new RepositorioMenu(Global.nombreConexionTeradata);
            this.repositorioPermiso = new RepositorioPermiso(Global.nombreConexionTeradata);
            this.repositorioGrupoBAC = new RepositorioGrupoBAC(Global.nombreConexionTeradata);
            this.repositorioAdmonControlDual = new RepositorioAdmonControlDual(Global.nombreConexionTeradata);
            this.repositorioDocumentoPoliza = new RepositorioDocumentoPoliza(Global.nombreConexionTeradata);
            this.repositorioCanalVenta = new RepositorioCanalVenta(Global.nombreConexionTeradata);
            this.repositorioParametro = new RepositorioParametro(Global.nombreConexionTeradata);
            this.repositorioAseguradora = new RepositorioAseguradora(Global.nombreConexionTeradata);
            this.repositorioIPC = new RepositorioIPC(Global.nombreConexionTeradata);
            this.repositorioNovedad = new RepositorioNovedad(Global.nombreConexionTeradata);
            this.repositorioSeguro = new Repositorio.Administracion.RepositorioSeguro(Global.nombreConexionTeradata);
            this.repositorioPlan = new Repositorio.Administracion.RepositorioPlan(Global.nombreConexionTeradata);
            this.repositorioProductoNoPermitido = new RepositorioProductoNoPermitido(Global.nombreConexionTeradata);
            this.repositorioTipoIdentificacionSeguro = new RepositorioTipoIdentificacionSeguro(Global.nombreConexionTeradata);
            this.repositorioCausalNovedad = new RepositorioCausalNovedad(Global.nombreConexionTeradata);
            this.repositorioMensaje = new RepositorioMensaje(Global.nombreConexionTeradata);
            this.repositorioGenerico = new RepositorioGenerico(Global.nombreConexionTeradata);
            this.repositorioLog = new RepositorioLog(Global.nombreConexionTeradata);
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioMensaje = this.repositorioMensaje;
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioLog = this.repositorioLog;
            this.repositorioMaestra = new RepositorioMaestra(Global.nombreConexionTeradata);
            this.repositorioItemMaestra = new RepositorioItemMaestra(Global.nombreConexionTeradata);
            this.repositorioVariableProducto = new RepositorioVariableProducto(Global.nombreConexionTeradata);

            this.gestionAprobacionDual = new GestionAprobacionDual(this.repositorioAprobacionDual);

            this.gestionAdministracion = new GestionAdministracion(
                                                                    this.repositorioDocumentoPoliza,
                                                                    this.repositorioCanalVenta,
                                                                    this.repositorioParametro);

            this.gestionSeguridad = new GestionSeguridad(
                                                         this.repositorioRol,
                                                         this.repositorioOficina,
                                                         this.repositorioMenu,
                                                         this.repositorioPermiso,
                                                         this.repositorioGrupoBAC,
                                                         this.repositorioAdmonControlDual);

            this.gestionAseguradora = new GestionAseguradora(this.repositorioAseguradora);

            this.gestionIPC = new GestionIPC(this.repositorioIPC);

            this.gestionNovedad = new GestionNovedad(this.repositorioNovedad);

            this.gestionSeguro = new GestionSeguro(
                                                   this.repositorioSeguro,
                                                   this.repositorioPlan,
                                                   this.repositorioProductoNoPermitido,
                                                   this.repositorioCanalVenta,
                                                   this.repositorioTipoIdentificacionSeguro,
                                                   this.repositorioDocumentoPoliza);

            this.gestionCausalNovedad = new GestionCausalNovedad(this.repositorioCausalNovedad);

            this.gestionMensaje = new GestionMensaje(this.repositorioMensaje);

            this.gestionGenerico = new GestionGenerico(this.repositorioGenerico);
            this.gestionMaestra = new GestionMaestra(this.repositorioMaestra);
            this.gestionItemMaestra = new GestionItemMaestra(this.repositorioItemMaestra);
            this.gestionVariableProducto = new GestionVariableProducto(this.repositorioVariableProducto, this.repositorioMaestra, this.repositorioItemMaestra);
        }

        #endregion

        /// <summary>
        /// Inserts the effective record.
        /// </summary>
        /// <param name="idAprobacionDual">The identifier dual approval.</param>
        /// <returns>Result object</returns>
        public Resultado InsertarRegistroEfectivo(int idAprobacionDual, string usuarioAprueba)
        {
            Resultado resultado = new Resultado();

            try
            {
                AprobacionDual registroAprobacion = this.gestionAprobacionDual.ConsultarAprobacionesControlDualPorId(idAprobacionDual);

                if (registroAprobacion != null)
                {
                    switch (registroAprobacion.NombreObjeto)
                    {
                        case "Rol":
                            {
                                BAC.EntidadesSeguridad.Rol rol = JsonConvert.DeserializeObject<BAC.EntidadesSeguridad.Rol>(registroAprobacion.DatosObjeto);
                                if (rol != null)
                                {
                                    rol.Login = usuarioAprueba;
                                    resultado = this.gestionSeguridad.InsertarRol(rol);
                                }
                            }

                            break;

                        case "DocumentoPoliza":
                            {
                                DocumentoPoliza documento = JsonConvert.DeserializeObject<DocumentoPoliza>(registroAprobacion.DatosObjeto);
                                if (documento != null)
                                {
                                    resultado = this.repositorioDocumentoPoliza.InsertarDocumentoPlantillaSeguro(documento);
                                }
                            }

                            break;

                        case "CanalVenta":
                            {
                                CanalVenta canal = JsonConvert.DeserializeObject<CanalVenta>(registroAprobacion.DatosObjeto);
                                if (canal != null)
                                {
                                    canal.Login = usuarioAprueba;
                                    resultado = this.gestionAdministracion.GuardarCanalVenta(canal);
                                }
                            }

                            break;

                        case "Parametro":
                            {
                                Parametro parametro = JsonConvert.DeserializeObject<Parametro>(registroAprobacion.DatosObjeto);
                                if (parametro != null)
                                {
                                    parametro.Login = usuarioAprueba;
                                    resultado = this.gestionAdministracion.GuardarParametro(parametro);
                                }
                            }

                            break;

                        case "Aseguradora":
                            {
                                Aseguradora aseguradora = JsonConvert.DeserializeObject<Aseguradora>(registroAprobacion.DatosObjeto);
                                if (aseguradora != null)
                                {
                                    aseguradora.Login = usuarioAprueba;
                                    resultado = this.gestionAseguradora.InsertarAseguradora(aseguradora);
                                }
                            }

                            break;

                        case "IPC":
                            {
                                IPC ipc = JsonConvert.DeserializeObject<IPC>(registroAprobacion.DatosObjeto);
                                if (ipc != null)
                                {
                                    ipc.Login = usuarioAprueba;
                                    resultado = this.gestionIPC.GuardarIPC(ipc);
                                }
                            }

                            break;

                        case "Novedad":
                            {
                                Novedad novedad = JsonConvert.DeserializeObject<Novedad>(registroAprobacion.DatosObjeto);
                                if (novedad != null)
                                {
                                    novedad.Login = usuarioAprueba;
                                    resultado = this.gestionNovedad.InsertarNovedad(novedad);
                                }
                            }

                            break;

                        case "ParametrizacionSeguro":
                            {
                                ParametrizacionSeguro seguro = JsonConvert.DeserializeObject<ParametrizacionSeguro>(registroAprobacion.DatosObjeto);
                                if (seguro != null)
                                {
                                    seguro.Login = usuarioAprueba;
                                    resultado = this.gestionSeguro.GuardarSeguro(seguro);
                                }
                            }

                            break;

                        case "CausalNovedad":
                            {
                                CausalNovedad causalNovedad = JsonConvert.DeserializeObject<CausalNovedad>(registroAprobacion.DatosObjeto);
                                if (causalNovedad != null)
                                {
                                    causalNovedad.Login = usuarioAprueba;
                                    resultado = this.gestionCausalNovedad.InsertarCausalNovedad(causalNovedad);
                                }
                            }

                            break;

                        case "Mensaje":
                            {
                                Mensaje mensaje = JsonConvert.DeserializeObject<Mensaje>(registroAprobacion.DatosObjeto);
                                if (mensaje != null)
                                {
                                    mensaje.Login = usuarioAprueba;
                                    resultado = this.gestionMensaje.InsertarMensaje(mensaje);
                                }
                            }

                            break;

                        case "Maestra":
                            {
                                Maestra maestra = JsonConvert.DeserializeObject<Maestra>(registroAprobacion.DatosObjeto);
                                if (maestra != null)
                                {
                                    maestra.Login = usuarioAprueba;
                                    resultado = this.gestionMaestra.InsertarMaestra(maestra);
                                }
                            }

                            break;

                        case "ItemMaestra":
                            {
                                ItemMaestra itemMaestra = JsonConvert.DeserializeObject<ItemMaestra>(registroAprobacion.DatosObjeto);
                                if (itemMaestra != null)
                                {
                                    itemMaestra.Login = usuarioAprueba;
                                    resultado = this.gestionItemMaestra.InsertarItemMaestra(itemMaestra);
                                }
                            }

                            break;

                        case "VariableProducto":
                            {
                                VariableProducto variableProducto = JsonConvert.DeserializeObject<VariableProducto>(registroAprobacion.DatosObjeto);
                                if (variableProducto != null)
                                {
                                    variableProducto.Login = usuarioAprueba;
                                    resultado = this.gestionVariableProducto.InsertarVariableProducto(variableProducto);
                                }
                            }

                            break;

                        default:
                            {
                                resultado.Error = true;
                                resultado.Mensaje = "Sin implementación de registro efectivo.";
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ex.Message;
            }

            return resultado;
        }

        /// <summary>
        /// Update the effective record.
        /// </summary>
        /// <param name="idAprobacionDual">The identifier dual approval.</param>
        /// <returns>Result object</returns>
        public Resultado ActualizarRegistroEfectivo(int idAprobacionDual, string usuarioAprueba)
        {
            Resultado resultado = new Resultado();

            try
            {
                AprobacionDual registroAprobacion = this.gestionAprobacionDual.ConsultarAprobacionesControlDualPorId(idAprobacionDual);

                if (registroAprobacion != null)
                {
                    switch (registroAprobacion.NombreObjeto)
                    {
                        case "Rol":
                            {
                                BAC.EntidadesSeguridad.Rol rol = JsonConvert.DeserializeObject<BAC.EntidadesSeguridad.Rol>(registroAprobacion.DatosObjeto);
                                if (rol != null)
                                {
                                    rol.Login = usuarioAprueba;
                                    resultado = this.gestionSeguridad.ActualizarRol(rol);
                                }
                            }

                            break;

                        case "CanalVenta":
                            {
                                CanalVenta canal = JsonConvert.DeserializeObject<CanalVenta>(registroAprobacion.DatosObjeto);
                                if (canal != null)
                                {
                                    canal.Login = usuarioAprueba;
                                    resultado = this.gestionAdministracion.ActualizaCanalVentaPorId(canal);
                                }
                            }

                            break;

                        case "Parametro":
                            {
                                Parametro parametro = JsonConvert.DeserializeObject<Parametro>(registroAprobacion.DatosObjeto);
                                if (parametro != null)
                                {
                                    parametro.Login = usuarioAprueba;
                                    resultado = this.gestionAdministracion.ActualizaParametroPorId(parametro);
                                }
                            }

                            break;

                        case "Aseguradora":
                            {
                                Aseguradora aseguradora = JsonConvert.DeserializeObject<Aseguradora>(registroAprobacion.DatosObjeto);
                                if (aseguradora != null)
                                {
                                    aseguradora.Login = usuarioAprueba;
                                    resultado = this.gestionAseguradora.ActualizarAseguradora(aseguradora);
                                }
                            }

                            break;

                        case "Novedad":
                            {
                                Novedad novedad = JsonConvert.DeserializeObject<Novedad>(registroAprobacion.DatosObjeto);
                                if (novedad != null)
                                {
                                    novedad.Login = usuarioAprueba;
                                    resultado = this.gestionNovedad.ActualizarNovedad(novedad);
                                }
                            }

                            break;

                        case "ParametrizacionSeguro":
                            {
                                ParametrizacionSeguro parametrizacionSeguro = JsonConvert.DeserializeObject<ParametrizacionSeguro>(registroAprobacion.DatosObjeto);
                                if (parametrizacionSeguro != null)
                                {
                                    parametrizacionSeguro.Login = usuarioAprueba;
                                    resultado = this.gestionSeguro.ActualizarSeguroPorId(parametrizacionSeguro);
                                }
                            }

                            break;

                        case "CausalNovedad":
                            {
                                CausalNovedad causalNovedad = JsonConvert.DeserializeObject<CausalNovedad>(registroAprobacion.DatosObjeto);
                                if (causalNovedad != null)
                                {
                                    causalNovedad.Login = usuarioAprueba;
                                    resultado = this.gestionCausalNovedad.ActualizarCausalNovedad(causalNovedad);
                                }
                            }

                            break;

                        case "Mensaje":
                            {
                                Mensaje mensaje = JsonConvert.DeserializeObject<Mensaje>(registroAprobacion.DatosObjeto);
                                if (mensaje != null)
                                {
                                    mensaje.Login = usuarioAprueba;
                                    resultado = this.gestionMensaje.ActualizarMensaje(mensaje);
                                }
                            }

                            break;

                        case "Maestra":
                            {
                                Maestra maestra = JsonConvert.DeserializeObject<Maestra>(registroAprobacion.DatosObjeto);
                                if (maestra != null)
                                {
                                    maestra.Login = usuarioAprueba;
                                    resultado = this.gestionMaestra.ActualizarMaestra(maestra);
                                }
                            }

                            break;

                        case "ItemMaestra":
                            {
                                ItemMaestra itemMaestra = JsonConvert.DeserializeObject<ItemMaestra>(registroAprobacion.DatosObjeto);
                                if (itemMaestra != null)
                                {
                                    itemMaestra.Login = usuarioAprueba;
                                    resultado = this.gestionItemMaestra.ActualizarItemMaestra(itemMaestra);
                                }
                            }

                            break;

                        case "VariableProducto":
                            {
                                VariableProducto variableProducto = JsonConvert.DeserializeObject<VariableProducto>(registroAprobacion.DatosObjeto);
                                if (variableProducto != null)
                                {
                                    variableProducto.Login = usuarioAprueba;
                                    resultado = this.gestionVariableProducto.ActualizarVariableProducto(variableProducto);
                                }
                            }

                            break;

                        default:
                            {
                                resultado.Error = true;
                                resultado.Mensaje = "Sin implementación de registro efectivo.";
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ex.Message;
            }

            return resultado;
        }

        /// <summary>
        /// Activate the effective record.
        /// </summary>
        /// <param name="idAprobacionDual">The identifier dual approval.</param>
        /// <returns>Result object</returns>
        public Resultado ActivarRegistroEfectivo(int idAprobacionDual)
        {
            Resultado resultado = new Resultado();
            try
            {
                AprobacionDual registroAprobacion = this.gestionAprobacionDual.ConsultarAprobacionesControlDualPorId(idAprobacionDual);

                if (registroAprobacion != null)
                {
                    switch (registroAprobacion.NombreObjeto)
                    {
                        case "DocumentoPoliza":
                            {
                                DocumentoPoliza documento = JsonConvert.DeserializeObject<DocumentoPoliza>(registroAprobacion.DatosObjeto);
                                if (documento != null)
                                {
                                    resultado = this.gestionAdministracion.ActivarEstadoPlantilla(documento.IdDocumentoPoliza);
                                }
                            }

                            break;

                        default:
                            {
                                resultado.Error = true;
                                resultado.Mensaje = "Sin implementación de registro efectivo.";
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ex.Message;
            }

            return resultado;
        }

        /// <summary>
        /// Delete the effective record.
        /// </summary>
        /// <param name="idAprobacionDual">The identifier dual approval.</param>
        /// <returns>Result object</returns>
        public Resultado EliminarRegistroEfectivo(int idAprobacionDual, string usuarioAprueba)
        {
            Resultado resultado = new Resultado();
            try
            {
                AprobacionDual registroAprobacion = this.gestionAprobacionDual.ConsultarAprobacionesControlDualPorId(idAprobacionDual);

                if (registroAprobacion != null)
                {
                    switch (registroAprobacion.NombreObjeto)
                    {
                        case "DocumentoPoliza":
                            {
                                DocumentoPoliza documento = JsonConvert.DeserializeObject<DocumentoPoliza>(registroAprobacion.DatosObjeto);
                                if (documento != null)
                                {
                                    resultado = this.gestionAdministracion.EliminarPlantilla(documento.IdDocumentoPoliza);
                                }
                            }

                            break;

                        case "Maestra":
                            {
                                Maestra maestra = JsonConvert.DeserializeObject<Maestra>(registroAprobacion.DatosObjeto);
                                if (maestra != null)
                                {
                                    maestra.Login = usuarioAprueba;
                                    resultado = this.gestionMaestra.EliminarMaestra(maestra);
                                }
                            }

                            break;

                        case "ItemMaestra":
                            {
                                ItemMaestra itemMaestra = JsonConvert.DeserializeObject<ItemMaestra>(registroAprobacion.DatosObjeto);
                                if (itemMaestra != null)
                                {
                                    itemMaestra.Login = usuarioAprueba;
                                    resultado = this.gestionItemMaestra.EliminarItemMaestra(itemMaestra);
                                }
                            }

                            break;

                        case "VariableProducto":
                            {
                                VariableProducto variableProducto = JsonConvert.DeserializeObject<VariableProducto>(registroAprobacion.DatosObjeto);
                                if (variableProducto != null)
                                {
                                    variableProducto.Login = usuarioAprueba;
                                    resultado = this.gestionVariableProducto.EliminarVariableProducto(variableProducto);
                                }
                            }

                            break;

                        default:
                            {
                                resultado.Error = true;
                                resultado.Mensaje = "Sin implementación de registro efectivo.";
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ex.Message;
            }

            return resultado;
        }

        /// <summary>
        /// Search the dual control approval by identifier.
        /// </summary>
        /// <param name="idAprobacionDual">The identifier dual control approval.</param>
        /// <returns>Dual approval</returns>
        public AprobacionDual ConsultarRegistroControlDualPorId(int idAprobacionDual)
        {
            AprobacionDual registroAprobacion = new AprobacionDual();
            try
            {
                registroAprobacion = this.repositorioAprobacionDual.ConsultarAprobacionesControlDualPorId(idAprobacionDual);
                if (registroAprobacion != null)
                {
                    if (registroAprobacion.Accion == EnumAccionDual.Actualizar && registroAprobacion.Estado == EnumEstadoDual.PorAprobar)
                    {
                        this.CargarDatosObjetoActual(ref registroAprobacion);
                    }
                }
                else
                {
                    registroAprobacion = new AprobacionDual();
                    registroAprobacion.Resultado = new Resultado();
                    registroAprobacion.Resultado.Mensaje = "Entidad no encontrada";
                }
            }
            catch (Exception ex)
            {
                registroAprobacion.Resultado.Error = true;
                registroAprobacion.Resultado.Mensaje = ex.Message;
            }

            return registroAprobacion;
        }

        /// <summary>
        /// Load the the actual data object.
        /// </summary>
        /// <param name="registroAprobacion">The approval record.</param>
        private void CargarDatosObjetoActual(ref AprobacionDual registroAprobacion)
        {
            switch (registroAprobacion.NombreObjeto)
            {
                case "Rol":
                    {
                        BAC.EntidadesSeguridad.Rol rol = JsonConvert.DeserializeObject<BAC.EntidadesSeguridad.Rol>(registroAprobacion.DatosObjeto);
                        if (rol != null)
                        {
                            IList<BAC.EntidadesSeguridad.Rol> roles = this.gestionSeguridad.ObtenerRolesCompletos(null, null);
                            if (roles != null)
                            {
                                var rolActual = (from x in roles where x.IdRol == rol.IdRol select x).FirstOrDefault();
                                if (rolActual != null)
                                {
                                    registroAprobacion.DatosObjetoActual = JsonConvert.SerializeObject(rolActual);
                                }
                            }
                        }
                    }

                    break;

                case "CanalVenta":
                    {
                        CanalVenta canal = JsonConvert.DeserializeObject<CanalVenta>(registroAprobacion.DatosObjeto);
                        if (canal != null)
                        {
                            IList<CanalVenta> canales = this.gestionSeguro.ObtenerCanalesVentaActivos();
                            if (canales != null)
                            {
                                var canalActual = (from x in canales where x.IdCanalVenta == canal.IdCanalVenta select x).FirstOrDefault();
                                if (canalActual != null)
                                {
                                    registroAprobacion.DatosObjetoActual = JsonConvert.SerializeObject(canalActual);
                                }
                            }
                        }
                    }

                    break;

                case "Parametro":
                    {
                        Parametro parametro = JsonConvert.DeserializeObject<Parametro>(registroAprobacion.DatosObjeto);
                        if (parametro != null)
                        {
                            DtoCatalogo dt = this.gestionGenerico.ConsultarCatalogo(EnumCatalogo.Parametro);
                            List<Parametro> parametros = dt.ListParametro;
                            if (parametros != null)
                            {
                                if (parametros.Count > 0)
                                {
                                    var parametroActual = (from x in parametros where x.IdParametro == parametro.IdParametro select x).FirstOrDefault();
                                    if (parametroActual != null)
                                    {
                                        registroAprobacion.DatosObjetoActual = JsonConvert.SerializeObject(parametroActual);
                                    }
                                }
                            }
                        }
                    }

                    break;

                case "Aseguradora":
                    {
                        Aseguradora aseguradora = JsonConvert.DeserializeObject<Aseguradora>(registroAprobacion.DatosObjeto);
                        if (aseguradora != null)
                        {
                            Aseguradora aseguradoraActual = this.gestionAseguradora.ConsultarAseguradoraPorId(aseguradora.IdAseguradora);
                            if (aseguradoraActual != null)
                            {
                                registroAprobacion.DatosObjetoActual = JsonConvert.SerializeObject(aseguradoraActual);
                            }
                        }
                    }

                    break;

                case "Novedad":
                    {
                        Novedad novedad = JsonConvert.DeserializeObject<Novedad>(registroAprobacion.DatosObjeto);
                        if (novedad != null)
                        {
                            DtoCatalogo dt = this.gestionGenerico.ConsultarCatalogo(EnumCatalogo.TablaNovedad);
                            List<Novedad> novedades = dt.ListTablaNovedad;
                            if (novedades != null)
                            {
                                if (novedades.Count > 0)
                                {
                                    var novedadActual = (from x in novedades where x.IdTipoNovedad == novedad.IdTipoNovedad select x).FirstOrDefault();
                                    if (novedadActual != null)
                                    {
                                        registroAprobacion.DatosObjetoActual = JsonConvert.SerializeObject(novedadActual);
                                    }
                                }
                            }
                        }
                    }

                    break;

                case "ParametrizacionSeguro":
                    {
                        ParametrizacionSeguro parametrizacionSeguro = JsonConvert.DeserializeObject<ParametrizacionSeguro>(registroAprobacion.DatosObjeto);
                        if (parametrizacionSeguro != null)
                        {
                            ParametrizacionSeguro parametrizacionSeguroActual = this.gestionSeguro.ConsultarInformacionSeguroPorId(parametrizacionSeguro.Seguro.IdSeguro);
                            if (parametrizacionSeguroActual != null)
                            {
                                registroAprobacion.DatosObjetoActual = JsonConvert.SerializeObject(parametrizacionSeguroActual);
                            }
                        }
                    }

                    break;

                case "CausalNovedad":
                    {
                        CausalNovedad causalNovedad = JsonConvert.DeserializeObject<CausalNovedad>(registroAprobacion.DatosObjeto);
                        if (causalNovedad != null)
                        {

                            IList<CausalNovedad> causalesNovedades = this.repositorioCausalNovedad.ConsultarCausalNovedad();
                            if (causalesNovedades != null)
                            {
                                if (causalesNovedades.Count > 0)
                                {
                                    var causalNovedadActual = (from x in causalesNovedades where x.IdCausalNovedad == causalNovedad.IdCausalNovedad select x).FirstOrDefault();
                                    if (causalNovedadActual != null)
                                    {
                                        registroAprobacion.DatosObjetoActual = JsonConvert.SerializeObject(causalNovedadActual);
                                    }
                                }
                            }
                        }
                    }

                    break;

                case "Mensaje":
                    {
                        Mensaje mensaje = JsonConvert.DeserializeObject<Mensaje>(registroAprobacion.DatosObjeto);
                        if (mensaje != null)
                        {
                            IList<Mensaje> mensajes = this.repositorioMensaje.ConsultarMensajes();
                            if (mensajes != null)
                            {
                                if (mensajes.Count > 0)
                                {
                                    var mensajeActual = (from x in mensajes where x.IdMensaje == mensaje.IdMensaje select x).FirstOrDefault();
                                    if (mensajeActual != null)
                                    {
                                        registroAprobacion.DatosObjetoActual = JsonConvert.SerializeObject(mensajeActual);
                                    }
                                }
                            }
                        }
                    }

                    break;

                case "Maestra":
                    {
                        Maestra maestra = JsonConvert.DeserializeObject<Maestra>(registroAprobacion.DatosObjeto);

                        if (maestra != null)
                        {
                            Maestra maestrabuscar = new Maestra();
                            maestrabuscar.IdMaestra = maestra.IdMaestra;
                            IList<Maestra> maestras = this.repositorioMaestra.ConsultarMaestras(maestrabuscar);
                            if (maestras != null)
                            {
                                if (maestras.Count > 0)
                                {
                                    var maestraActual =  (from x in maestras where x.IdMaestra == maestra.IdMaestra select x).FirstOrDefault();
                                    if (maestraActual != null)
                                    {
                                        registroAprobacion.DatosObjetoActual = JsonConvert.SerializeObject(maestraActual);
                                    }
                                }
                            }
                        }
                    }

                    break;

                case "ItemMaestra":
                    {
                        ItemMaestra itemMaestra = JsonConvert.DeserializeObject<ItemMaestra>(registroAprobacion.DatosObjeto);
                        if (itemMaestra != null)
                        {
                            ItemMaestra itemBusqueda = new ItemMaestra();
                            itemBusqueda.IdMaestra = itemMaestra.IdMaestra;
                            IList<ItemMaestra> items = this.repositorioItemMaestra.ConsultarItemsMaestra(itemBusqueda);
                            if (items != null)
                            {
                                if (items.Count > 0)
                                {
                                    var itemActual = (from x in items where x.Codigo == itemMaestra.Codigo select x).FirstOrDefault();
                                    if (itemActual != null)
                                    {
                                        registroAprobacion.DatosObjetoActual = JsonConvert.SerializeObject(itemActual);
                                    }
                                }
                            }
                        }
                    }

                    break;

                case "VariableProducto":
                    {
                        VariableProducto variableProducto = JsonConvert.DeserializeObject<VariableProducto>(registroAprobacion.DatosObjeto);
                        if (variableProducto != null)
                        {
                            VariableProducto variableBusqueda = new VariableProducto();
                            variableBusqueda.IdVariableProducto = variableProducto.IdVariableProducto;
                            IList<VariableProducto> variables = this.repositorioVariableProducto.ConsultarVariablesProducto(variableBusqueda);
                            if (variables != null && variables.Count > 0)
                            {
                                var variableActual = (from x in variables where x.IdVariableProducto == variableProducto.IdVariableProducto select x).FirstOrDefault();
                                if (variableActual != null)
                                {
                                    registroAprobacion.DatosObjetoActual = JsonConvert.SerializeObject(variableActual);
                                }
                            }
                        }
                    }

                    break;

                default:
                    {
                        registroAprobacion.Resultado = new Resultado();
                        registroAprobacion.Resultado.Error = true;
                        registroAprobacion.Resultado.Mensaje = "Sin implementación de registro efectivo.";
                    }

                    break;
            }
        }
    }
}
