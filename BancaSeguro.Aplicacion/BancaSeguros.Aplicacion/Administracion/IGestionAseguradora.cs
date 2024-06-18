//-----------------------------------------------------------------------
// <copyright file="IGestionAseguradora.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;

    /// <summary>
    /// interface Insurance Management
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 15/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionAseguradora
    {
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
        IList<Aseguradora> ConsultarAseguradoras(Aseguradora aseguradora);
        
        /// <summary>
        /// gets actives insurances.
        /// </summary>
        /// <returns>list of actives insurances </returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IList<Aseguradora> ConsultarAseguradorasActivas();

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
