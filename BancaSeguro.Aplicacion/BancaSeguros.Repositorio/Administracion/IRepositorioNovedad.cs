

namespace BancaSeguros.Repositorio.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Catalogo;
    /// <summary>
    /// Interface Repository
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    ///  CreationDate: 24/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IRepositorioNovedad
    {
        /// <summary>
        /// Search Novelty.
        /// </summary>
        /// <param name="novedad">The novelty to search.</param>
        /// <returns>List of Novelty</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IList<Novedad> ConsultarNovedades(Novedad novedad);

        /// <summary>
        /// Inserts the Novelty.
        /// </summary>
        /// <param name="NOVEDAD">The novelty</param>
        /// <returns>Result operation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado InsertarNovedad(Novedad novedad);

        /// <summary>
        /// Update Novelty.
        /// </summary>
        /// <param name="novedad">The novelty.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado ActualizarNovedad(Novedad novedad);
    }
}
