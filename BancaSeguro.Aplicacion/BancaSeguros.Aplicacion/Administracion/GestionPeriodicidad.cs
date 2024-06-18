//-----------------------------------------------------------------------
// <copyright file="GestionPeriodicidad.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Administracion
{
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Repositorio.Administracion;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Gestion periodicity class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 06/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public class GestionPeriodicidad : IGestionPeriodicidad
    {
        #region Variables
        private IRepositorioPeriodicidad repositorioPeriodicidad;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GestionPeriodicidad"/> class.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 06/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public GestionPeriodicidad(IRepositorioPeriodicidad repositorioPeriodicidad)
        {
            this.repositorioPeriodicidad = repositorioPeriodicidad;
        }
        #endregion

        #region Metodos publicos
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
        public IList<Periodicidad> ObtenerPeriodicidadesActivas()
        {
            return this.repositorioPeriodicidad.ObtenerListaPeriodicidadActivas();
        }
        #endregion
    }
}
