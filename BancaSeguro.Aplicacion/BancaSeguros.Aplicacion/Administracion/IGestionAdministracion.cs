//-----------------------------------------------------------------------
// <copyright file="IGestionAdministracion.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.Administracion;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;

    /// <summary>
    /// Interface Management Administration
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 13/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionAdministracion
    {
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
        ResultadoDocumentoPoliza PrevisualizarPlantilla(EntradaPrevisualizacionDocumentoPoliza entradaPrevisualizacionDocumentoPoliza);

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
        Resultado InsertarDocumentoPlantillaSeguro(DocumentoPoliza documentoPoliza);

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
        List<DocumentoPoliza> ObtenerPlantillasPorIdSeguro(int idSeguro);

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
        Resultado EliminarPlantilla(int idDocumentoPlantilla);

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
        Resultado ActivarEstadoPlantilla(int idDocumentoPlantilla);

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
        DocumentoPoliza ObtenerDocumentoPolizaPorIdDocumentoPoliza(int idDocumentoPoliza);

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
        Resultado ActualizaCanalVentaPorId(CanalVenta canalVenta);

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
        Resultado ActualizaParametroPorId(Parametro parametro);

        #endregion
    }
}
