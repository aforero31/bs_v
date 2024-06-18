

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
    ///  CreationDate: 27/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IRepositorioCausalNovedad
    {
        /// <summary>
        /// Inserts the Causal.
        /// </summary>
        /// <param name="NOVEDAD">The Causal novelty</param>
        /// <returns>Result operation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado InsertarCausalNovedad(CausalNovedad causalNovedad);

        /// <summary>
        /// Update Causal Novelty.
        /// </summary>
        /// <param name="novedad">The causal novelty.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        Resultado ActualizarCausalNovedad(CausalNovedad causalNovedad);

        /// <summary>
        /// Search Causal Novelty.
        /// </summary>
        /// <param name="novedad">The causal novelty to search.</param>
        /// <returns>List of Causal Novelty</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IList<CausalNovedad> ConsultarCausalNovedad();
    }
}
