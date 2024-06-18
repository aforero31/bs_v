//-----------------------------------------------------------------------
// <copyright file="IRepositorioAseguradora.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;

    /// <summary>
    /// Interface Repository
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 14/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IRepositorioAseguradora
    {
        /// <summary>
        /// Search insurances.
        /// </summary>
        /// <param name="aseguradora">The insurance to search.</param>
        /// <returns>List of insurances</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
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
        Resultado ActualizarAseguradora(Aseguradora aseguradora);
    }
}
