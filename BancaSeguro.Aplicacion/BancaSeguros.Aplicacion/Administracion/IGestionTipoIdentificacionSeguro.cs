//-----------------------------------------------------------------------
// <copyright file="IGestionTipoIdentificacionSeguro.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Administracion
{
    using BancaSeguros.Entidades.General;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// GestionTipoIdentificacionSeguro Interface
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 03/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionTipoIdentificacionSeguro
    {
        /// <summary>
        /// Saves the documentType by insurance.
        /// </summary>
        /// <param name="idSeguro">The identifier seguro.</param>
        /// <param name="idTipoIdentificacion">The identifier tipo identificacion.</param>
        /// <returns>Resultado object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado GuardarTipoDocumentoSeguro(int idSeguro, int idTipoIdentificacion);

        /// <summary>
        /// Deletes the documentType by insurance.
        /// </summary>
        /// <param name="idSeguro">The identifier seguro.</param>
        /// <param name="idTipoIdentificacion">The identifier tipo identificacion.</param>
        /// <returns>Resultado object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado EliminarTipoDocumentoSeguro(int idSeguro, int idTipoIdentificacion);
    }
}
