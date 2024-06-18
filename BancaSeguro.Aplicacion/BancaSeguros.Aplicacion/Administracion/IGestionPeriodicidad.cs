//-----------------------------------------------------------------------
// <copyright file="IGestionPeriodicidad.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Administracion
{
    using BancaSeguros.Entidades.Catalogo;
    using System.Collections.Generic;

    /// <summary>
    /// Gestion periodicidad Interfaz
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 06/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionPeriodicidad
    {
        /// <summary>
        /// gets the periodicidades activas.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 06/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IList<Periodicidad> ObtenerPeriodicidadesActivas();
    }
}
