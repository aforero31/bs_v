//-----------------------------------------------------------------------
// <copyright file="IGestionConvenios.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.Seguro;

    public interface IGestionConvenios
    {
        /// <summary>
        /// Get the agreement of identifier insurance.
        /// </summary>
        /// <param name="idAseguradora">The identifier insurance.</param>
        /// <returns>List entity agreement</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<Convenio> ConsultarConveniosPorIdAseguradora(int idAseguradora);
    }
}
