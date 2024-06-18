//-----------------------------------------------------------------------
// <copyright file="GestionAprobacionDual.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Aplicacion.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.Administracion;
    using BancaSeguros.Repositorio.Administracion;
    using BancaSeguros.Entidades.General;
    using System;
    using BancaSeguros.Aplicacion.Configuraciones;
    
    /// <summary>
    /// Dual Control Approval manage class
    /// </summary>
    /// <seealso cref="BAC.Seguridad.Seguridad.IGestionAprobacionDual" />
    public class GestionAprobacionDual : IGestionAprobacionDual
    {
        #region Variables

        /// <summary>
        /// The group repository
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioAprobacionDual repositorioAprobacionDual;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionAprobacionDual"/> class.
        /// </summary>
        /// <param name="repositorio">The repository.</param>
        public GestionAprobacionDual(IRepositorioAprobacionDual repositorio)
        {
            this.repositorioAprobacionDual = repositorio;
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Inserts the approval dual.
        /// </summary>
        /// <param name="aprobacion">The approval.</param>
        /// <returns>Result object</returns>
        public BancaSeguros.Entidades.General.Resultado InsertarAprobacionDual(AprobacionDual aprobacion)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioAprobacionDual.InsertarAprobacionDual(aprobacion);
                if (!resultado.Error)
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoControlDual), LlavesAplicacion.RegistroTemporalAlmacenado);
            }
            catch(Exception exc)
            {
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoControlDual), exc, LlavesAplicacion.CatchInsertarAprobacionDual);  
            }

            return resultado;
        }

        /// <summary>
        /// Search the dual approvals.
        /// </summary>
        /// <param name="aprobacion">The approval to search.</param>
        /// <returns>List of approvals</returns>
        public IList<AprobacionDual> ConsultarAprobacionesControlDual(AprobacionDual aprobacion)
        {
            return this.repositorioAprobacionDual.ConsultarAprobacionesControlDual(aprobacion);
        }

        /// <summary>
        /// Update the approval dual.
        /// </summary>
        /// <param name="aprobacion">The approval.</param>
        /// <returns>Result object</returns>
        public BancaSeguros.Entidades.General.Resultado ActualizarAprobacionDual(AprobacionDual aprobacion)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioAprobacionDual.ActualizarAprobacionDual(aprobacion);
                if (!resultado.Error)
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoControlDual), LlavesAplicacion.ActualizarAprobacionDual);
            }
            catch (Exception exc)
            {
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoControlDual), exc, LlavesAplicacion.CatchActualizarAprobacionDual);
            }

            return resultado;      
        }

        /// <summary>
        /// Search the dual control approval by identifier.
        /// </summary>
        /// <param name="idAprobacionDual">The identifier dual control approval.</param>
        /// <returns>Dual approval</returns>
        public AprobacionDual ConsultarAprobacionesControlDualPorId(int idAprobacionDual) 
        {
            return this.repositorioAprobacionDual.ConsultarAprobacionesControlDualPorId(idAprobacionDual);
        }

        #endregion
    }
}
