//-----------------------------------------------------------------------
// <copyright file="IServicioAdministracion.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.ServiciosWCF.Administracion
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using BancaSeguros.Entidades;
    using BancaSeguros.Entidades.Administracion;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Entidades.Planos;

    /// <summary>
    /// Interface Management Administration
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 13/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [ServiceContract]
    public interface IServicioAdministracion
    {
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
        [OperationContract]
        ResultadoDocumentoPoliza PrevisualizarPlantilla(EntradaPrevisualizacionDocumentoPoliza entradaPrevisualizacionDocumentoPoliza);

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
        [OperationContract]
        Resultado InsertarDocumentoPlantillaSeguro(DocumentoPoliza documentoPoliza);

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
        [OperationContract]
        List<DocumentoPoliza> ObtenerPlantillasPorIdSeguro(int idSeguro);

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
        [OperationContract]
        Resultado EliminarPlantilla(int idDocumentoPlantilla);

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
        [OperationContract]
        Resultado ActivarEstadoPlantilla(int idDocumentoPlantilla);

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
        [OperationContract]
        DocumentoPoliza ObtenerDocumentoPolizaPorIdDocumentoPoliza(int idDocumentoPoliza);

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
        [OperationContract]
        List<DocumentoPoliza> ConsultarPlantillasActivas();

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
        [OperationContract]
        Resultado GuardarCanalVenta(CanalVenta canalVenta);

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
        [OperationContract]
        Resultado ActualizaCanalVentaPorId(CanalVenta canalVenta);

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
        [OperationContract]
        IList<Aseguradora> ConsultarAseguradoras(Aseguradora aseguradora);

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
        [OperationContract]
        Aseguradora ConsultarAseguradoraPorId(int idAseguradora);

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
        [OperationContract]
        Resultado InsertarAseguradora(Aseguradora aseguradora);

        /// <summary>
        /// Update Insurance.
        /// </summary>
        /// <param name="aseguradora">The insurance.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        Resultado ActualizarAseguradora(Aseguradora aseguradora);

        #endregion

        #region Convenio

        /// <summary>
        /// Gets the actives conventions by id insurance
        /// </summary>
        /// <param name="idAseguradora">The identifier insurance.</param>
        /// <returns>List of conventions</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 02/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        List<Convenio> ConsultarConveniosPorIdAseguradora(int idAseguradora);
        #endregion

        #region Tipo identificacion - Seguro

        /// <summary>
        /// Saves the documentType by insurance.
        /// </summary>
        /// <param name="idSeguro">The identifier insurance.</param>
        /// <param name="idTipoIdentificacion">The identifier identification type.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        Resultado GuardarTipoDocumentoSeguro(int idSeguro, int idTipoIdentificacion);

        /// <summary>
        /// Deletes the documentType by insurance.
        /// </summary>
        /// <param name="idSeguro">The identifier insurance.</param>
        /// <param name="idTipoIdentificacion">The identifier identification type.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        Resultado EliminarTipoDocumentoSeguro(int idSeguro, int idTipoIdentificacion);
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
        [OperationContract]
        Resultado GuardarParametro(Parametro parametro);

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
        [OperationContract]
        Resultado ActualizaParametroPorId(Parametro parametro);
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
        [OperationContract]        
        Resultado GuardarSeguro(ParametrizacionSeguro parametrizacionSeguro);
        
        /// <summary>
        /// Gets the active sale channels.
        /// </summary>
        /// <returns>List of sale channels</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        IList<CanalVenta> ObtenerCanalesVentaActivos();
        
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
        [OperationContract]
        IList<Periodicidad> ObtenerPeriodicidadesActivas();

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
        [OperationContract]  
        List<Seguro> ConsultarTodosLosSeguros();

        /// <summary>
        /// Update the sure por identifier.
        /// </summary>
        /// <param name="parametrizacionSeguro">The parameterization sure.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]  
        Resultado ActualizarSeguroPorId(ParametrizacionSeguro parametrizacionSeguro);

        /// <summary>
        /// Get the sure of identifier.
        /// </summary>
        /// <returns>Entity list sure</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        ParametrizacionSeguro ConsultarInformacionSeguroPorId(int idSeguro);

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
        [OperationContract]
        List<Seguro> ConsultarSegurosPorParametros(string nombreProducto, int codigoProducto, string nombreAseguradora);

        /// <summary>
        /// Search the insurances by carrier.
        /// </summary>
        /// <param name="idAseguradora">The identifier insurance carrier.</param>
        /// <returns>List insurances</returns>
        [OperationContract]
        List<Seguro> ConsultarSegurosPorAseguradora(int idAseguradora);

        #endregion

        #region Parametrizacion IPC
        /// <summary>
        /// Saves the IPC.
        /// </summary>
        /// <param name="parametrizacionSeguro">The parametrizacion IPC.</param>
        /// <returns>resultado object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        Resultado GuardarIPC(IPC ipc);

        /// <summary>
        /// Update the IPC.
        /// </summary>
        /// <param name="parametrizacionSeguro">The parametrizacion IPC.</param>
        /// <returns>resultado object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        Resultado ActualizaIPC(IPC ipc);

        /// <summary>
        /// Obtain the IPC.
        /// </summary>
        /// <param name="parametrizacionSeguro">The parametrizacion IPC.</param>
        /// <returns>resultado object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        IPC ConsultarIPC();


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
        [OperationContract]
        IList<Auditoria> ObtenerAuditorias(Auditoria auditoria);

        #endregion

        #region Parametrizacion Novedad
        /// <summary>
        /// Save the Novelty
        /// </summary>
        /// <param name="canalVenta">The Novelty.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        Resultado InsertarNovedad(Novedad novedad);

        /// <summary>
        /// Update the Novelty
        /// </summary>
        /// <param name="canalVenta">The Novelty.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        Resultado ActualizarNovedad(Novedad novedad);

        /// <summary>
        /// Obtain the Novelty
        /// </summary>
        /// <param name="canalVenta">The Novelty.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        IList<Novedad> ConsultarNovedades(Novedad novedad);

        #endregion

        #region Parametrizacion Causal Novedad

        /// <summary>
        /// Save the Causal Novelty
        /// </summary>
        /// <param name="canalVenta">The Novelty.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        Resultado InsertarCausalNovedad(CausalNovedad causalNovedad);

        /// <summary>
        /// Update the Causal Novelty
        /// </summary>
        /// <param name="causalNovelty">The Causal Novelty.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        Resultado ActualizarCausalNovedad(CausalNovedad causalNovedad);

        /// <summary>
        /// Obtain the Causal Novelty
        /// </summary>
        /// <param name="">The Causal Novelty.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        IList<CausalNovedad> ConsultarCausalNovedad();



        #endregion

        #region Parametrizacion Mensajes

        /// <summary>
        /// Save the Message
        /// </summary>
        /// <param name="mensaje">The Message.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        Resultado InsertarMensaje(Mensaje mensaje);

        /// <summary>
        /// Update the Message
        /// </summary>
        /// <param name="mensaje">The Message.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        Resultado ActualizarMensaje(Mensaje mensaje);

        /// <summary>
        /// Search the Message
        /// </summary>
        /// <param name="mensaje">The Message.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        IList<Mensaje> ConsultarMensajes(Mensaje mensaje);

        #endregion

        #region Aprobacion Dual

        /// <summary>
        /// Inserts the approval dual.
        /// </summary>
        /// <param name="aprobacion">The approval.</param>
        /// <returns>Result object</returns>
        [OperationContract]
        BancaSeguros.Entidades.General.Resultado InsertarAprobacionDual(AprobacionDual aprobacion);

        /// <summary>
        /// Search the dual approvals.
        /// </summary>
        /// <param name="aprobacion">The approval to search.</param>
        /// <returns>List of approvals</returns>
        [OperationContract]
        IList<AprobacionDual> ConsultarAprobacionesControlDual(AprobacionDual aprobacion);

        /// <summary>
        /// Update the approval dual.
        /// </summary>
        /// <param name="aprobacion">The approval.</param>
        /// <returns>Result object</returns>
        [OperationContract]
        BancaSeguros.Entidades.General.Resultado ActualizarAprobacionDual(AprobacionDual aprobacion);

        /// <summary>
        /// Search the dual control approval by identifier.
        /// </summary>
        /// <param name="idAprobacionDual">The identifier dual control approval.</param>
        /// <returns>Dual approval</returns>
        [OperationContract]
        AprobacionDual ConsultarAprobacionesControlDualPorId(int idAprobacionDual);

        #endregion

        #region Variables Producto

        /// <summary>
        /// Inserts the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Result object</returns>
        [OperationContract]
        Resultado InsertarVariableProducto(VariableProducto variable);

        /// <summary>
        /// Update the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Result object</returns>
        [OperationContract]
        Resultado ActualizarVariableProducto(VariableProducto variable);

        /// <summary>
        /// Search the product variables.
        /// </summary>
        /// <param name="variable">The variable to search.</param>
        /// <returns>List of variables</returns>
        [OperationContract]
        IList<VariableProducto> ConsultarVariablesProducto(VariableProducto variable);

        /// <summary>
        /// Search the active product variables .
        /// </summary>
        /// <param name="variable">The variable to search.</param>
        /// <returns>List of active variables</returns>
        [OperationContract]
        IList<VariableProducto> ConsultarVariablesProductoActivas(VariableProducto variable);

        /// <summary>
        /// Deletes the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Result object</returns>
        [OperationContract]
        Resultado EliminarVariableProducto(VariableProducto variable);

        #endregion

        #region Maestra

        /// <summary>
        /// Inserts the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        [OperationContract]
        Resultado InsertarMaestra(Maestra maestra);

        /// <summary>
        /// Update the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        [OperationContract]
        Resultado ActualizarMaestra(Maestra maestra);

        /// <summary>
        /// Search the masters.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>List of masters</returns>
        [OperationContract]
        IList<Maestra> ConsultarMaestras(Maestra maestra);

        /// <summary>
        /// Deletes the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        [OperationContract]
        Resultado EliminarMaestra(Maestra maestra);

        #endregion

        #region Item Maestra

        /// <summary>
        /// Inserts the master item.
        /// </summary>
        /// <param name="itemMaestra">The master item.</param>
        /// <returns>Result object</returns>
        [OperationContract]
        Resultado InsertarItemMaestra(ItemMaestra itemMaestra);

        /// <summary>
        /// Update the item master.
        /// </summary>
        /// <param name="itemMaestra">The item master.</param>
        /// <returns>Result object</returns>
        [OperationContract]
        Resultado ActualizarItemMaestra(ItemMaestra itemMaestra);

        /// <summary>
        /// Search the master items.
        /// </summary>
        /// <param name="itemMaestra">The master item.</param>
        /// <returns>List of item masters</returns>
        [OperationContract]
        IList<ItemMaestra> ConsultarItemsMaestra(ItemMaestra itemMaestra);

        /// <summary>
        /// Deletes the master item.
        /// </summary>
        /// <param name="itemMaestra">The master item.</param>
        /// <returns>Result object</returns>
        [OperationContract]
        Resultado EliminarItemMaestra(ItemMaestra itemMaestra);

        #endregion

        #region Parametrización Planos
        /// <summary>
        /// Search the Aseguradora
        /// </summary>
        /// <param name="aseguradora">The Aseguradora.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        IList<Aseguradora> ConsultarAseguradorasActivas();

         /// <summary>
        /// Search the name of Columns Poliza
        /// </summary>
        /// <param name="Poliza">The name of Columns Poliza.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        List<CamposPoliza> ConsultarPolizas(int opcion);


        /// <summary>
        /// Search the name of Columns Cobros
        /// </summary>
        /// <param name="Poliza">The name of Columns Cobros.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        List<CamposCobros> ConsultarCobros(int opcion);


        /// <summary>
        /// Search the name of Columns Cancel
        /// </summary>
        /// <param name="Poliza">The name of Columns Cancel.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        List<CamposCancelaciones> ConsultarCancelaciones(int opcion);

        /// <summary>
        /// Search the filters of Cancelation
        /// </summary>
        /// <param name="Poliza">The the filters of Cancelation.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [OperationContract]
        List<CamposCancelaciones> ConsultarFiltrosCancelaciones();


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
        [OperationContract]
        Resultado GuardarDatosArchivoPlano(ArchivoPlano datosArchivo);

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
        [OperationContract]
        List<ArchivoPlano> ConsultarDatosGrilla();

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
        [OperationContract]
        Resultado ActualizarDatosArchivoPlano(ArchivoPlano datosArchivo);



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
        [OperationContract]
        Resultado EliminarDatosArchivoPlano(int idProgramacion, string usuario);


        #endregion
    }
}
