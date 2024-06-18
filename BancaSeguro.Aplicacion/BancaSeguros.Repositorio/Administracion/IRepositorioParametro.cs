//-----------------------------------------------------------------------
// <copyright file="IRepositorioParametro.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Administracion
{
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;

    /// <summary>
    /// Interface Parameter
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 18/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IRepositorioParametro
    {
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
    }
}
