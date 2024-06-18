//-----------------------------------------------------------------------
// <copyright file="IGestionSeguro.cs" company="Unión temporal FS-BAC-2013 ">
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

    /// <summary>
    /// Management sure interface
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 05/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionSeguro
    {
        /// <summary>
        /// Save the sure.
        /// </summary>
        /// <param name="parametrizacionSeguro">The parameterization sure.</param>
        /// <returns>entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado GuardarSeguro(ParametrizacionSeguro parametrizacionSeguro);

        /// <summary>
        /// Get the channel sale active.
        /// </summary>
        /// <returns>channel sale List</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IList<CanalVenta> ObtenerCanalesVentaActivos();

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
        List<Seguro> ConsultarTodosLosSeguros();

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
        Resultado ActualizarSeguroPorId(ParametrizacionSeguro parametrizacionSeguro);

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
        ParametrizacionSeguro ConsultarInformacionSeguroPorId(int idSeguro);

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
        List<Seguro> ConsultarSegurosPorParametros(string nombreProducto, int codigoProducto, string nombreAseguradora);

        /// <summary>
        /// Get sure by insurance.
        /// </summary>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<Seguro> ConsultarSegurosPorAseguradora(int idAseguradora);
    }
}
