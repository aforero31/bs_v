//-----------------------------------------------------------------------
// <copyright file="ServicioAdministracion.svc.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.ServiciosWCF.Administracion
{
    using System.Collections.Generic;
    using System.Web;
    using System.Linq;
    using BancaSeguros.Aplicacion.Administracion;
    using BancaSeguros.Aplicacion.Venta;
    using BancaSeguros.Entidades.Administracion;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Repositorio.Administracion;
    using BancaSeguros.Repositorio.Venta;
    using Repositorio.Log;
    using BancaSeguros.Entidades.Planos;

    /// <summary>
    /// Class Service Management Administration
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 13/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionAseguradora" />
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionConvenios" />
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionTipoIdentificacionSeguro" />
    /// <seealso cref="BancaSeguros.Aplicacion.Venta.IGestionProductoNoPermitido" />
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionSeguro" />
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionPeriodicidad" />
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionAuditoria" />
    /// <seealso cref="BancaSeguros.ServiciosWCF.Administracion.IServicioAdministracion" />
    public class ServicioAdministracion : IServicioAdministracion,
        IGestionAseguradora,
        IGestionConvenios,
        IGestionTipoIdentificacionSeguro,
        IGestionProductoNoPermitido,
        IGestionSeguro,
        IGestionPeriodicidad,
        IGestionAuditoria,
        IGestionParametrizacionPlanos
    {
        #region Variables
        /// <summary>
        /// The parameterization template
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionAdministracion gestionAdministracion;

        /// <summary>
        /// The insurance management
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionAseguradora gestionAseguradora;

        /// <summary>
        /// The conventions management
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 02/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionConvenios gestionConvenios;

        /// <summary>
        /// The management id type insurance
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionTipoIdentificacionSeguro gestionTipoIdentificacionSeguro;

        /// <summary>
        /// The product not allowed management
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 04/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionProductoNoPermitido gestionProductoNoPermitido;

        /// <summary>
        /// The insurance management
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionSeguro gestionSeguro;

        /// <summary>
        /// The periodicity management
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 06/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionPeriodicidad gestionPeriodicidad;

        /// <summary>
        /// The audit management
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionAuditoria gestionAuditoria;

        /// <summary>
        /// The management
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionIPC gestionIPC;

        /// <summary>
        /// The management
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionNovedad gestionNovedad;

        /// <summary>
        /// The management
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionCausalNovedad gestionCausalNovedad;

        /// <summary>
        /// The management
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionMensaje gestionMensaje;

        /// <summary>
        /// The management
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionParametrizacionPlanos gestionParametrizacionPlanos;

        /// <summary>
        /// The dual approval manage
        /// </summary>
        private IGestionAprobacionDual gestionAprobacionDual;

        /// <summary>
        /// The product variable management
        /// </summary>
        private IGestionVariableProducto gestionVariableProducto;

        /// <summary>
        /// The master management
        /// </summary>
        private IGestionMaestra gestionMaestra;

        /// <summary>
        /// The master item management
        /// </summary>
        private IGestionItemMaestra gestionItemMaestra;

        /// <summary>
        /// The management document policy
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 08/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionDocumentoPoliza gestionDocumentoPoliza;

        /// <summary>
        /// The repository document policy
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioDocumentoPoliza repositorioDocumentoPoliza;

        /// <summary>
        /// The repository channel sale
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioCanalVenta repositorioCanalVenta;

        /// <summary>
        /// The repository parameter
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioParametro repositorioParametro;

        /// <summary>
        /// The repository insurance
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioAseguradora repositorioAseguradora;


        /// <summary>
        /// The repository type identification sure
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioTipoIdentificacionSeguro repositorioTipoIdentificacionSeguro;

        /// <summary>
        /// The repository product not access
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioProductoNoPermitido repositorioProductoNoPermitido;

        /// <summary>
        /// The repository periodicity
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioPeriodicidad repositorioPeriodicidad;

        /// <summary>
        /// The repository sure
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Repositorio.Administracion.IRepositorioSeguro repositorioSeguro;

        /// <summary>
        /// The repository plan
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Repositorio.Administracion.IRepositorioPlan repositorioPlan;

        /// <summary>
        /// The repository audit
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioAuditoria repositorioAuditoria;

        /// <summary>
        /// The repository
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioIPC repositorioIPC;

        /// <summary>
        /// The repository
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioNovedad repositorioNovedad;

        /// <summary>
        /// The repository
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioCausalNovedad repositorioCausalNovedad;

        /// <summary>
        /// The repository
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioMensaje repositorioMensaje;

        /// <summary>
        /// The repository
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioParametrizacionPlanos repositorioParametrizacionPlanos;

        /// <summary>
        /// The group repository
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioAprobacionDual repositorioAprobacionDual;

        /// <summary>
        /// The repository log
        /// </summary>
        private IRepositorioLog repositorioLog;

        /// <summary>
        /// The product variable repository
        /// </summary>
        private IRepositorioVariableProducto repositorioVariableProducto;

        /// <summary>
        /// The master repository
        /// </summary>
        private IRepositorioMaestra repositorioMaestra;

        /// <summary>
        /// The master item repository
        /// </summary>
        private IRepositorioItemMaestra repositorioItemMaestra;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicioAdministracion"/> class.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ServicioAdministracion()
        {
            this.repositorioDocumentoPoliza = new RepositorioDocumentoPoliza(Global.nombreConexionTeradata);
            this.repositorioCanalVenta = new RepositorioCanalVenta(Global.nombreConexionTeradata);
            this.repositorioParametro = new RepositorioParametro(Global.nombreConexionTeradata);
            this.repositorioAseguradora = new RepositorioAseguradora(Global.nombreConexionTeradata);
            this.repositorioTipoIdentificacionSeguro = new RepositorioTipoIdentificacionSeguro(Global.nombreConexionTeradata);
            this.repositorioProductoNoPermitido = new RepositorioProductoNoPermitido(Global.nombreConexionTeradata);
            this.repositorioPeriodicidad = new RepositorioPeriodicidad(Global.nombreConexionTeradata);
            this.repositorioSeguro = new Repositorio.Administracion.RepositorioSeguro(Global.nombreConexionTeradata);
            this.repositorioPlan = new Repositorio.Administracion.RepositorioPlan(Global.nombreConexionTeradata);
            this.repositorioAuditoria = new RepositorioAuditoria(Global.nombreConexionTeradata);
            this.repositorioIPC = new RepositorioIPC(Global.nombreConexionTeradata);
            this.repositorioNovedad = new RepositorioNovedad(Global.nombreConexionTeradata);
            this.repositorioCausalNovedad = new RepositorioCausalNovedad(Global.nombreConexionTeradata);
            this.repositorioMensaje = new RepositorioMensaje(Global.nombreConexionTeradata);
            this.repositorioAprobacionDual = new RepositorioAprobacionDual(Global.nombreConexionTeradata);
            this.repositorioLog = new RepositorioLog(Global.nombreConexionTeradata);
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioMensaje = this.repositorioMensaje;
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioLog = this.repositorioLog;
            this.repositorioVariableProducto = new RepositorioVariableProducto(Global.nombreConexionTeradata);
            this.repositorioMaestra = new RepositorioMaestra(Global.nombreConexionTeradata);
            this.repositorioItemMaestra = new RepositorioItemMaestra(Global.nombreConexionTeradata);
            this.repositorioParametrizacionPlanos = new RepositorioParametrizacionPlanos(Global.nombreConexionTeradata);

            this.gestionAdministracion = new GestionAdministracion(this.repositorioDocumentoPoliza, this.repositorioCanalVenta, this.repositorioParametro);
            this.gestionAseguradora = new GestionAseguradora(this.repositorioAseguradora);
            this.gestionTipoIdentificacionSeguro = new GestionTipoIdentificacionSeguro(this.repositorioTipoIdentificacionSeguro);
            this.gestionProductoNoPermitido = new GestionProductoNoPermitido(this.repositorioProductoNoPermitido);
            this.gestionPeriodicidad = new GestionPeriodicidad(this.repositorioPeriodicidad);
            this.gestionSeguro = new GestionSeguro(this.repositorioSeguro, this.repositorioPlan, this.repositorioProductoNoPermitido, this.repositorioCanalVenta, this.repositorioTipoIdentificacionSeguro, this.repositorioDocumentoPoliza);
            this.gestionAuditoria = new GestionAuditoria(this.repositorioAuditoria);
            this.gestionIPC = new GestionIPC(this.repositorioIPC);
            this.gestionNovedad = new GestionNovedad(this.repositorioNovedad);
            this.gestionCausalNovedad = new GestionCausalNovedad(this.repositorioCausalNovedad);
            this.gestionMensaje = new GestionMensaje(this.repositorioMensaje);
            this.gestionAprobacionDual = new GestionAprobacionDual(this.repositorioAprobacionDual);
            this.gestionVariableProducto = new GestionVariableProducto(this.repositorioVariableProducto, this.repositorioMaestra, this.repositorioItemMaestra);
            this.gestionMaestra = new GestionMaestra(this.repositorioMaestra);
            this.gestionItemMaestra = new GestionItemMaestra(this.repositorioItemMaestra);
            this.gestionDocumentoPoliza = new GestionDocumentoPoliza(this.repositorioDocumentoPoliza);
            this.gestionParametrizacionPlanos = new GestionParametrizacionPlanos(this.repositorioParametrizacionPlanos);
            this.gestionConvenios = new GestionConvenios(this.repositorioAseguradora);
        }

        #endregion

        #region Metodos Publicos

        #region Parametrizacion Documento Poliza

        /// <summary>
        /// Preview the template.
        /// </summary>
        /// <param name="entradaPrevisualizacionDocumentoPoliza">The entry preview document policy.</param>
        /// <returns>Entity Result document policy</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ResultadoDocumentoPoliza PrevisualizarPlantilla(EntradaPrevisualizacionDocumentoPoliza entradaPrevisualizacionDocumentoPoliza)
        {
            entradaPrevisualizacionDocumentoPoliza.RutaArchivo = HttpContext.Current.Server.MapPath("../ArchivosPDF/");
            return this.gestionAdministracion.PrevisualizarPlantilla(entradaPrevisualizacionDocumentoPoliza);
        }

        /// <summary>
        /// Insert the document template sure.
        /// </summary>
        /// <param name="documentoPoliza">The document policy.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado InsertarDocumentoPlantillaSeguro(DocumentoPoliza documentoPoliza)
        {
            return this.gestionAdministracion.InsertarDocumentoPlantillaSeguro(documentoPoliza);
        }

        /// <summary>
        /// Get the templates of identifier sure.
        /// </summary>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <returns>List Entity document policy</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<DocumentoPoliza> ObtenerPlantillasPorIdSeguro(int idSeguro)
        {
            return this.gestionAdministracion.ObtenerPlantillasPorIdSeguro(idSeguro);
        }

        /// <summary>
        /// Delete the template.
        /// </summary>
        /// <param name="idDocumentoPlantilla">The identifier document template.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado EliminarPlantilla(int idDocumentoPlantilla)
        {
            return this.gestionAdministracion.EliminarPlantilla(idDocumentoPlantilla);
        }

        /// <summary>
        /// Active the estate template.
        /// </summary>
        /// <param name="idDocumentoPlantilla">The identifier document template.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActivarEstadoPlantilla(int idDocumentoPlantilla)
        {
            return this.gestionAdministracion.ActivarEstadoPlantilla(idDocumentoPlantilla);
        }

        /// <summary>
        /// Get the document policy of identifier document policy.
        /// </summary>
        /// <param name="idDocumentoPoliza">The identifier document policy.</param>
        /// <returns>Entity document policy</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DocumentoPoliza ObtenerDocumentoPolizaPorIdDocumentoPoliza(int idDocumentoPoliza)
        {
            return this.gestionAdministracion.ObtenerDocumentoPolizaPorIdDocumentoPoliza(idDocumentoPoliza);
        }

        /// <summary>
        /// gets the list template active.
        /// </summary>
        /// <returns>list entity</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 08/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<DocumentoPoliza> ConsultarPlantillasActivas()
        {
            return this.gestionDocumentoPoliza.ConsultarPlantillasActivas();
        }

        #endregion

        #region Parametrizacion Canal Venta

        /// <summary>
        /// Save the channel sale.
        /// </summary>
        /// <param name="canalVenta">The channel sale.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GuardarCanalVenta(CanalVenta canalVenta)
        {
            return this.gestionAdministracion.GuardarCanalVenta(canalVenta);
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
            return this.gestionAdministracion.ActualizaCanalVentaPorId(canalVenta);
        }

        #endregion

        #region Parametrizacion Aseguradora

        /// <summary>
        /// Search insurance.
        /// </summary>
        /// <param name="aseguradora">The insurance to search.</param>
        /// <returns>List of insurances</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Aseguradora> ConsultarAseguradoras(Aseguradora aseguradora)
        {
            return this.gestionAseguradora.ConsultarAseguradoras(aseguradora);
        }

        /// <summary>
        /// gets actives insurances.
        /// </summary>
        /// <returns>
        /// list of actives insurances
        /// </returns>
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

        /// <summary>
        /// Search Insurance by identifier.
        /// </summary>
        /// <param name="idAseguradora">The identifier.</param>
        /// <returns>Entity Insurance</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Aseguradora ConsultarAseguradoraPorId(int idAseguradora)
        {
            return this.gestionAseguradora.ConsultarAseguradoraPorId(idAseguradora);
        }

        /// <summary>
        /// Inserts the Insurance.
        /// </summary>
        /// <param name="aseguradora">The Insurance</param>
        /// <returns>Result operation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado InsertarAseguradora(Aseguradora aseguradora)
        {
            return this.gestionAseguradora.InsertarAseguradora(aseguradora);
        }

        /// <summary>
        /// Update Insurance.
        /// </summary>
        /// <param name="aseguradora">The insurance.</param>
        /// <param name="actualizaConsecutivo">if set to <c>true</c> [update consecutive].</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarAseguradora(Aseguradora aseguradora)
        {
            return this.gestionAseguradora.ActualizarAseguradora(aseguradora);
        }

        #endregion

        #region Convenio

       
        public List<Convenio> ConsultarConveniosPorIdAseguradora(int idAseguradora)
        {
            return this.gestionConvenios.ConsultarConveniosPorIdAseguradora(idAseguradora);
        }

        #endregion

        #region Tipo identificacion - Seguro

        /// <summary>
        /// Saves the Document type by insurance.
        /// </summary>
        /// <param name="idSeguro">The identifier insurance.</param>
        /// <param name="idTipoIdentificacion">The identifier document type.</param>
        /// <returns>result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GuardarTipoDocumentoSeguro(int idSeguro, int idTipoIdentificacion)
        {
            return this.gestionTipoIdentificacionSeguro.GuardarTipoDocumentoSeguro(idSeguro, idTipoIdentificacion);
        }

        /// <summary>
        /// Deletes the documentType by insurance.
        /// </summary>
        /// <param name="idSeguro">The identifier insurance.</param>
        /// <param name="idTipoIdentificacion">The identifier document type.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado EliminarTipoDocumentoSeguro(int idSeguro, int idTipoIdentificacion)
        {
            return this.gestionTipoIdentificacionSeguro.EliminarTipoDocumentoSeguro(idSeguro, idTipoIdentificacion);
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
            return this.gestionAdministracion.GuardarParametro(parametro);
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
            return this.gestionAdministracion.ActualizaParametroPorId(parametro);
        }

        #endregion

        #region Producto no permitido

        /// <summary>
        /// Gets the not allowed products by insurance.
        /// </summary>
        /// <param name="idSeguro">The identifier insurance.</param>
        /// <returns>
        /// not allowed products list
        /// </returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 04/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IEnumerable<ProductoNoPermitido> ConsultarProductosNoPermitidosPorSeguro(int idSeguro)
        {
            return this.gestionProductoNoPermitido.ConsultarProductosNoPermitidosPorSeguro(idSeguro);
        }

        /// <summary>
        /// Saves the not allowed product.
        /// </summary>
        /// <param name="productoNoPermitido">The  not allowed product.</param>
        /// <returns>
        /// Result Object
        /// </returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 04/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GuardarProductoNoPermitido(ProductoNoPermitido productoNoPermitido)
        {
            return this.gestionProductoNoPermitido.GuardarProductoNoPermitido(productoNoPermitido);
        }

        /// <summary>
        /// Deletes the not allowed product.
        /// </summary>
        /// <param name="productoNoPermitido">The not allowed product.</param>
        /// <returns>
        /// Result Object
        /// </returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 04/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado EliminarProductoNoPermitido(ProductoNoPermitido productoNoPermitido)
        {
            return this.gestionProductoNoPermitido.EliminarProductoNoPermitido(productoNoPermitido);
        }
        #endregion

        #region Seguro

        /// <summary>
        /// Saves the insurance.
        /// </summary>
        /// <param name="parametrizacionSeguro">The insurance config.</param>
        /// <returns>result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GuardarSeguro(ParametrizacionSeguro parametrizacionSeguro)
        {
            return this.gestionSeguro.GuardarSeguro(parametrizacionSeguro);
        }

        /// <summary>
        /// Gets the sale active channels.
        /// </summary>
        /// <returns>
        /// List of sale channels
        /// </returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<CanalVenta> ObtenerCanalesVentaActivos()
        {
            return this.gestionSeguro.ObtenerCanalesVentaActivos();
        }

        /// <summary>
        /// gets the active periodicities.
        /// </summary>
        /// <returns>List of periodicities</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 06/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Periodicidad> ObtenerPeriodicidadesActivas()
        {
            return this.gestionPeriodicidad.ObtenerPeriodicidadesActivas();
        }

        /// <summary>
        /// Get all the sure.
        /// </summary>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Seguro> ConsultarTodosLosSeguros()
        {
            return this.gestionSeguro.ConsultarTodosLosSeguros();
        }

        /// <summary>
        /// Update the sure of identifier.
        /// </summary>
        /// <param name="seguro">The sure.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarSeguroPorId(ParametrizacionSeguro parametrizacionSeguro)
        {
            return this.gestionSeguro.ActualizarSeguroPorId(parametrizacionSeguro);
        }

        /// <summary>
        /// Get sure
        /// </summary>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <returns>Entity Sure</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 16/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ParametrizacionSeguro ConsultarInformacionSeguroPorId(int idSeguro)
        {
            return this.gestionSeguro.ConsultarInformacionSeguroPorId(idSeguro);
        }

        /// <summary>
        /// get the sure of parameters.
        /// </summary>
        /// <param name="nombreProducto">The name sure.</param>
        /// <param name="codigoProducto">The code sure.</param>
        /// <param name="nombreAseguradora">The name insurance.</param>
        /// <returns>List entity sure</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 06/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Seguro> ConsultarSegurosPorParametros(string nombreProducto, int codigoProducto, string nombreAseguradora)
        {
            return this.gestionSeguro.ConsultarSegurosPorParametros(nombreProducto, codigoProducto, nombreAseguradora);
        }


        /// <summary>
        /// Search the insurances by carrier.
        /// </summary>
        /// <param name="idAseguradora">The identifier insurance carrier.</param>
        /// <returns>List insurances</returns>
        public List<Seguro> ConsultarSegurosPorAseguradora(int idAseguradora)
        {
            return this.gestionSeguro.ConsultarSegurosPorAseguradora(idAseguradora); 
        }

        #endregion

        #region Auditoria

        /// <summary>
        /// Search the audits.
        /// </summary>
        /// <param name="auditoria">The audit to search.</param>
        /// <returns>List of audits</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Auditoria> ObtenerAuditorias(Auditoria auditoria)
        {
            return this.gestionAuditoria.ObtenerAuditorias(auditoria);
        }

        #endregion

        #region Parametrizacion IPC

        /// <summary>
        /// Save the IPC.
        /// </summary>
        /// <param name="ipc">The IPC.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GuardarIPC(IPC ipc)
        {
            return this.gestionIPC.GuardarIPC(ipc);
        }

        /// <summary>
        /// Update the IPC.
        /// </summary>
        /// <param name="ipc">The IPC.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizaIPC(IPC ipc)
        {
            return this.gestionIPC.ActualizaIPC(ipc);
        }

        /// <summary>
        /// Obtain the IPC.
        /// </summary>
        /// <returns>
        /// result object
        /// </returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy: INTERGRUPO\WZALDUA
        /// ModifiedDate:19/05/2016
        /// </remarks>
        public IPC ConsultarIPC()
        {
            return this.gestionIPC.ConsultarIPC();
        }

        #endregion

        #region Parametrizacion Novedad
        /// <summary>
        /// Save the Novelty.
        /// </summary>
        /// <param name="ipc">The Novelty.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado InsertarNovedad(Novedad novedad)
        {
            return this.gestionNovedad.InsertarNovedad(novedad);
        }

        /// <summary>
        /// Update the Novelty.
        /// </summary>
        /// <param name="ipc">The Novelty.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarNovedad(Novedad novedad)
        {
            return this.gestionNovedad.ActualizarNovedad(novedad);
        }

        /// <summary>
        /// Obtain the Novelty.
        /// </summary>
        /// <returns>
        /// result object
        /// </returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 24/05/2016
        /// ModifiedBy: 
        /// ModifiedDate:
        /// </remarks>
        public IList<Novedad> ConsultarNovedades(Novedad novedad)
        {
            return this.gestionNovedad.ConsultarNovedades(novedad);
        }
        #endregion

        #region Parametrizacion Causal Novedad
        /// <summary>
        /// Save the Causal Novelty.
        /// </summary>
        /// <param name="ipc">The Causal Novelty.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado InsertarCausalNovedad(CausalNovedad causalNovedad)
        {
            return this.gestionCausalNovedad.InsertarCausalNovedad(causalNovedad);
        }

        /// <summary>
        /// Update the Causal Novelty.
        /// </summary>
        /// <param name="ipc">The Causal Novelty.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarCausalNovedad(CausalNovedad causalNovedad)
        {
            return this.gestionCausalNovedad.ActualizarCausalNovedad(causalNovedad);
        }

        /// <summary>
        /// Obtain the Causal Novelty.
        /// </summary>
        /// <returns>
        /// result object
        /// </returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy: 
        /// ModifiedDate:
        /// </remarks>
        public IList<CausalNovedad> ConsultarCausalNovedad()
        {
            return this.repositorioCausalNovedad.ConsultarCausalNovedad();
        }
        #endregion

        #region Parametrizacion Mensaje
        /// <summary>
        /// Save the Message.
        /// </summary>
        /// <param name="mensaje">The Message.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado InsertarMensaje(Mensaje mensaje)
        {
            return this.gestionMensaje.InsertarMensaje(mensaje);
        }

        /// <summary>
        /// Update the Message.
        /// </summary>
        /// <param name="mensaje">The Message.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarMensaje(Mensaje mensaje)
        {
            return this.gestionMensaje.ActualizarMensaje(mensaje);
        }

        /// <summary>
        /// Search messages.
        /// </summary>
        /// <param name="mensaje">The message to search.</param>
        /// <returns>List of messages</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 02/06/2016   
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Mensaje> ConsultarMensajes(Mensaje mensaje)
        {
            return this.gestionMensaje.ConsultarMensajes(mensaje);
        }

        #endregion

        #region Aprobacion Dual

        /// <summary>
        /// Inserts the approval dual.
        /// </summary>
        /// <param name="aprobacion">The approval.</param>
        /// <returns>Result object</returns>
        public BancaSeguros.Entidades.General.Resultado InsertarAprobacionDual(AprobacionDual aprobacion)
        {
            return this.gestionAprobacionDual.InsertarAprobacionDual(aprobacion);
        }

        /// <summary>
        /// Search the dual approvals.
        /// </summary>
        /// <param name="aprobacion">The approval to search.</param>
        /// <returns>List of approvals</returns>
        public IList<AprobacionDual> ConsultarAprobacionesControlDual(AprobacionDual aprobacion)
        {
            return this.gestionAprobacionDual.ConsultarAprobacionesControlDual(aprobacion);
        }

        /// <summary>
        /// Update the approval dual.
        /// </summary>
        /// <param name="aprobacion">The approval.</param>
        /// <returns>Result object</returns>
        public BancaSeguros.Entidades.General.Resultado ActualizarAprobacionDual(AprobacionDual aprobacion)
        {
            return this.gestionAprobacionDual.ActualizarAprobacionDual(aprobacion);
        }

        /// <summary>
        /// Search the dual control approval by identifier.
        /// </summary>
        /// <param name="idAprobacionDual">The identifier dual control approval.</param>
        /// <returns>Dual approval</returns>
        public AprobacionDual ConsultarAprobacionesControlDualPorId(int idAprobacionDual)
        {
            return this.gestionAprobacionDual.ConsultarAprobacionesControlDualPorId(idAprobacionDual);
        }

        #endregion

        #region Variables Producto

        /// <summary>
        /// Inserts the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Result object</returns>
        public Resultado InsertarVariableProducto(VariableProducto variable)
        {
            return this.gestionVariableProducto.InsertarVariableProducto(variable);
        }

        /// <summary>
        /// Update the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Result object</returns>
        public Resultado ActualizarVariableProducto(VariableProducto variable)
        {
            return this.gestionVariableProducto.ActualizarVariableProducto(variable);
        }

        /// <summary>
        /// Search the product variables.
        /// </summary>
        /// <param name="variable">The variable to search.</param>
        /// <returns>List of variables</returns>
        public IList<VariableProducto> ConsultarVariablesProducto(VariableProducto variable)
        {
            return this.gestionVariableProducto.ConsultarVariablesProducto(variable);
        }

        /// <summary>
        /// Search the active product variables .
        /// </summary>
        /// <param name="variable">The variable to search.</param>
        /// <returns>List of active variables</returns>
        public IList<VariableProducto> ConsultarVariablesProductoActivas(VariableProducto variable)
        {
            return this.gestionVariableProducto.ConsultarVariablesProductoActivas(variable);
        }

        /// <summary>
        /// Deletes the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Result object</returns>
        public Resultado EliminarVariableProducto(VariableProducto variable)
        {
            return this.gestionVariableProducto.EliminarVariableProducto(variable);
        }

        #endregion

        #region Maestra

        /// <summary>
        /// Inserts the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        public Resultado InsertarMaestra(Maestra maestra)
        {
            Resultado resultado = this.gestionMaestra.InsertarMaestra(maestra);
            if (!resultado.Error)
            {
                Maestra maestraInsertada = this.gestionMaestra.ConsultarMaestraPorNombre(maestra.Nombre);
                if (maestraInsertada != null)
                {
                    if (maestra.Items != null)
                    {
                        Resultado resultadoItem = new Resultado();
                        foreach (ItemMaestra item in maestra.Items)
                        {
                            item.IdMaestra = maestraInsertada.IdMaestra;
                            resultadoItem = this.gestionItemMaestra.InsertarItemMaestra(item);
                            if (resultadoItem.Error)
                            {
                                resultado = resultadoItem;
                                break;
                            }
                        }
                    }
                }
            }

            return resultado;
        }

        /// <summary>
        /// Update the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        public Resultado ActualizarMaestra(Maestra maestra)
        {
            return this.gestionMaestra.ActualizarMaestra(maestra);
        }

        /// <summary>
        /// Search the masters.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>List of masters</returns>
        public IList<Maestra> ConsultarMaestras(Maestra maestra)
        {
            return this.gestionMaestra.ConsultarMaestras(maestra);
        }

        /// <summary>
        /// Deletes the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        public Resultado EliminarMaestra(Maestra maestra)
        {
            return this.gestionMaestra.EliminarMaestra(maestra);
        }

        #endregion

        #region Item Maestra

        /// <summary>
        /// Inserts the master item.
        /// </summary>
        /// <param name="itemMaestra">The master item.</param>
        /// <returns>Result object</returns>
        public Resultado InsertarItemMaestra(ItemMaestra itemMaestra)
        {
            return this.gestionItemMaestra.InsertarItemMaestra(itemMaestra);
        }

        /// <summary>
        /// Update the item master.
        /// </summary>
        /// <param name="itemMaestra">The item master.</param>
        /// <returns>Result object</returns>
        public Resultado ActualizarItemMaestra(ItemMaestra itemMaestra)
        {
            return this.gestionItemMaestra.ActualizarItemMaestra(itemMaestra);
        }

        /// <summary>
        /// Search the master items.
        /// </summary>
        /// <param name="itemMaestra">The master item.</param>
        /// <returns>List of item masters</returns>
        public IList<ItemMaestra> ConsultarItemsMaestra(ItemMaestra itemMaestra)
        {
            return this.gestionItemMaestra.ConsultarItemsMaestra(itemMaestra);
        }

        /// <summary>
        /// Deletes the master item.
        /// </summary>
        /// <param name="itemMaestra">The master item.</param>
        /// <returns>Result object</returns>
        public Resultado EliminarItemMaestra(ItemMaestra itemMaestra)
        {
            return this.gestionItemMaestra.EliminarItemMaestra(itemMaestra);
        }

        #endregion

        #region Parametrizacion Planos
        /// <summary>
        /// Search name of columns Poliza.
        /// </summary>
        /// <param name="mensaje">The name of columns Poliza</param>
        /// <returns>List of name of columns Poliza</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 12/07/2016   
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<CamposPoliza> ConsultarPolizas(int opcion)
        {
            return this.gestionParametrizacionPlanos.ConsultarPolizas(opcion);
        }

        /// <summary>
        /// Search name of columns Cobros.
        /// </summary>
        /// <param name="mensaje">The name of columns Poliza</param>
        /// <returns>List of name of columns Poliza</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/07/2016   
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<CamposCobros> ConsultarCobros(int opcion)
        {
            return this.gestionParametrizacionPlanos.ConsultarCobros(opcion);
        }

        /// <summary>
        /// Search name of columns Cancel.
        /// </summary>
        /// <param name="mensaje">The name of columns Poliza</param>
        /// <returns>List of name of columns Poliza</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/07/2016   
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<CamposCancelaciones> ConsultarCancelaciones(int opcion)
        {
            return this.gestionParametrizacionPlanos.ConsultarCancelaciones(opcion);
        }

        /// <summary>
        /// Search filters of Cancelation.
        /// </summary>
        /// <param name="mensaje">The filters of Cancelation</param>
        /// <returns>List of filters of Cancelation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/07/2016   
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<CamposCancelaciones> ConsultarFiltrosCancelaciones()
        {
            return this.gestionParametrizacionPlanos.ConsultarFiltrosCancelaciones();
        }

        /// <summary>
        /// Inserts data for Generate the File.
        /// </summary>
        /// <param name="mensaje">Inserts data for Generate the File</param>
        /// <returns>Resultado</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 15/07/2016   
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GuardarDatosArchivoPlano(ArchivoPlano datosArchivo)
        {
            return this.gestionParametrizacionPlanos.GuardarDatosArchivoPlano(datosArchivo);
        }

        /// <summary>
        /// Search the data for fill the Grid
        /// </summary>
        /// <param name="novedad">the data for fill the Grid</param>
        /// <returns>data</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 18/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<ArchivoPlano> ConsultarDatosGrilla()
        {
            return this.gestionParametrizacionPlanos.ConsultarDatosGrilla();
        }


        /// <summary>
        /// Update data for Generate the File.
        /// </summary>
        /// <param name="mensaje">Inserts data for Generate the File</param>
        /// <returns>Resultado</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 19/07/2016   
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarDatosArchivoPlano(ArchivoPlano datosArchivo)
        {
            return this.gestionParametrizacionPlanos.ActualizarDatosArchivoPlano(datosArchivo);
        }


        /// <summary>
        /// Delete data for Generate the File.
        /// </summary>
        /// <param name="mensaje">Inserts data for Generate the File</param>
        /// <returns>Resultado</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 19/07/2016   
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado EliminarDatosArchivoPlano(int idProgramacion, string usuario)
        {
            return this.gestionParametrizacionPlanos.EliminarDatosArchivoPlano(idProgramacion, usuario);
        }

        #endregion

        #endregion
    }
}