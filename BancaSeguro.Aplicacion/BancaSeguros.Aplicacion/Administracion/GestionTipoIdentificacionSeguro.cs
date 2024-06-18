//-----------------------------------------------------------------------
// <copyright file="GestionTipoIdentificacionSeguro.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Administracion
{
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Repositorio.Administracion;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Gestion TipoIdentificacionSeguro
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 03/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public class GestionTipoIdentificacionSeguro : IGestionTipoIdentificacionSeguro
    {
        #region Variables
        private IRepositorioTipoIdentificacionSeguro repositorioTipoIdentificacionSeguro;
        #endregion

        #region Constructor

        public GestionTipoIdentificacionSeguro(IRepositorioTipoIdentificacionSeguro repositorioTipoIdentificacionSeguro)
        {
            this.repositorioTipoIdentificacionSeguro = repositorioTipoIdentificacionSeguro;
        }

        #endregion
        
        #region Metodos publicos

        /// <summary>
        /// Saves the DocumentTipo by insurance.
        /// </summary>
        /// <param name="idSeguro">The identifier seguro.</param>
        /// <param name="idTipoDocumento">The identifier tipo documento.</param>
        /// <returns>resultado object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GuardarTipoDocumentoSeguro(int idSeguro, int idTipoIdentificacion)
        {
            string login = string.Empty;
            return this.repositorioTipoIdentificacionSeguro.GuardarTipoDocumentoSeguro(idSeguro, idTipoIdentificacion, login);            
        }

        /// <summary>
        /// Deletes the documentType by insurance.
        /// </summary>
        /// <param name="idSeguro">The identifier seguro.</param>
        /// <param name="idTipoIdentificacion">The identifier tipo identificacion.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado EliminarTipoDocumentoSeguro(int idSeguro, int idTipoIdentificacion)
        {  
            return this.repositorioTipoIdentificacionSeguro.EliminarTipoDocumentoSeguro(idSeguro, idTipoIdentificacion);
        }

        #endregion
    }
}
