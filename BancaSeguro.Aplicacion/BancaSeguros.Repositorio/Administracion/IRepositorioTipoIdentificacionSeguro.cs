
namespace BancaSeguros.Repositorio.Administracion
{
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Resp
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 03/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IRepositorioTipoIdentificacionSeguro
    {
        /// <summary>
        /// Saves the documentType by insurance.
        /// </summary>
        /// <param name="idSeguro">The identifier seguro.</param>
        /// <param name="idTipoIdentificacion">The identifier tipo identificacion.</param>
        /// <returns>Resultado object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado GuardarTipoDocumentoSeguro(int idSeguro, int idTipoIdentificacion, string login);

        /// <summary>
        /// Deletes the documentType by insurance.
        /// </summary>
        /// <param name="idSeguro">The identifier seguro.</param>
        /// <param name="idTipoIdentificacion">The identifier tipo identificacion.</param>
        /// <returns>Resultado object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado EliminarTipoDocumentoSeguro(int idSeguro, int idTipoIdentificacion);

        /// <summary>
        /// Get the type identification of identifier sure.
        /// </summary>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <returns>Entity List Plan</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 17/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IList<TipoIdentificacion> ConsultarTiposIdentificacionPorIdSeguro(int idSeguro);

        /// <summary>
        /// Update the sure type identifier por identifier.
        /// </summary>
        /// <param name="tiposIdentificacion">The type identifier.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado ActualizarSeguroTipoIdentiPorId(DataTable tiposIdentificacion, string login);
    }
}
