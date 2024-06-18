//-----------------------------------------------------------------------
// <copyright file="IRepositorioConvenio.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Administracion
{
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// RepositorioPlan Interfaz
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 03/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IRepositorioPlan
    {
        /// <summary>
        /// Saves a plan.
        /// </summary>
        /// <param name="plan">The plan.</param>
        /// <returns>Resultado object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado GuardarPlan(Plan plan);

        /// <summary>
        /// Get the plans of identifier sure.
        /// </summary>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <returns>Entity List Plan</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 17/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IList<Plan> ConsultarPlanesPorIdSeguro(int idSeguro);

        /// <summary>
        /// update the plan por identifier sure.
        /// </summary>
        /// <param name="planes">The planes.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado ActualizaPlanesPorIdSeguro(DataTable planes, string login);
    }
}
