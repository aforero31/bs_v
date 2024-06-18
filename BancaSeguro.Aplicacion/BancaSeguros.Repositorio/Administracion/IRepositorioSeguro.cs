//-----------------------------------------------------------------------
// <copyright file="IRepositorioSeguro.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;

    /// <summary>
    /// Interface repository sure
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 04/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IRepositorioSeguro
    {
        /// <summary>
        /// Save the sure.
        /// </summary>
        /// <param name="seguro">The sure.</param>
        /// <returns>Entity result sure</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        ResultadoSeguro InsertarSeguro(Seguro seguro);

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
        Resultado ActualizarSeguroPorId(Seguro seguro);

        /// <summary>
        /// Get the sure of identifier.
        /// </summary>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <returns>Entity sure</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 17/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Seguro ConsultarSeguroPorId(int idSeguro);

        /// <summary>
        /// Get all the sure.
        /// </summary>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 06/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<Seguro> ConsultarSegurosPorParametros(string nombreProducto, int codigoProducto, string nombreAseguradora);
    }
}
