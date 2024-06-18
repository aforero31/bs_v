//-----------------------------------------------------------------------
// <copyright file="GestionMensaje.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BAC.Seguridad.Mensaje
{
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Repositorio.Administracion;
    using Configuraciones;
    using System;

    /// <summary>
    /// Class Message Management
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    ///  CreationDate: 02/06/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionMensaje" />
    public class GestionMensaje : IGestionMensaje
    {
        #region Variables

        /// <summary>
        /// The interface message repository
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioMensaje repositorioMensaje;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionMensaje"/> class.
        /// </summary>
        /// <param name="interfazRepositorioMensaje">The interface message repository.</param>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public GestionMensaje(IRepositorioMensaje repositorioMensaje)
        {
            this.repositorioMensaje = repositorioMensaje;
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Search Message by identifier.
        /// </summary>
        /// <param name="idMensaje">The identifier.</param>
        /// <returns>Entity Insurance</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ConsultarMensajePorLlave(int evento, string llave)
        {
            Resultado resultado = new Resultado();

            resultado =  ControlMensajes.ConsultarMensajePorLlave(evento, llave);
            
            return resultado;
        }

        #endregion
    }
}
