
namespace BancaSeguros.Aplicacion.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.Administracion;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;

    /// <summary>
    /// Interface Causal Novelty Administration
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    /// CreationDate: 27/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionCausalNovedad
    {
        /// <summary>
        /// Save the Causal Novelty.
        /// </summary>
        /// <param name="ipc">The Causal Novelty</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado InsertarCausalNovedad(CausalNovedad causalNovedad);

        /// <summary>
        /// Update the Causal Novelty.
        /// </summary>
        /// <param name="ipc">The Causal Novelty</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado ActualizarCausalNovedad(CausalNovedad causalNovedad);

        /// <summary>
        /// Obtain the Causal Novelty.
        /// </summary>
        /// <param name="ipc">The Causal Novelty</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IList<CausalNovedad> ConsultarCausalNovedad(CausalNovedad causalNovedad);

    }
}
