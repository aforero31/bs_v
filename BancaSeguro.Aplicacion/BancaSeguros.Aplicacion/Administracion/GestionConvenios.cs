//-----------------------------------------------------------------------
// <copyright file="GestionConvenios.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Administracion
{
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Repositorio.Administracion;
    using Cobis;
    using System.Collections.Generic;

    /// <summary>
    /// management for agreement
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 02/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public class GestionConvenios : IGestionConvenios
    {
        #region Variables

        private IRepositorioAseguradora repositorioAseguradora;

        #endregion

        #region Constructor
        public GestionConvenios(IRepositorioAseguradora repositorioAseguradora)
        {
            this.repositorioAseguradora = repositorioAseguradora;
        }
        #endregion

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
        public List<Convenio> ConsultarConveniosPorIdAseguradora(int idAseguradora)
        {
            List<Convenio> convenios = new List<Convenio>();
            Aseguradora aseguradora = new Aseguradora();

            try
            {
                aseguradora = this.repositorioAseguradora.ConsultarAseguradoraPorId(idAseguradora);
                convenios = new GestionConvenio().ConsultarConveniosActivos(aseguradora);
            }
            catch (System.Exception)
            {
                convenios = new List<Convenio>();
            }

            return convenios;
        }
    }
}
