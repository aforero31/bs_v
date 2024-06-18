//-----------------------------------------------------------------------
// <copyright file="GestionMaestra.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Aplicacion.Administracion
{
    using System;
    using System.Collections.Generic;
    using BAC.Seguridad.Mensaje;
    using BancaSeguros.Aplicacion.Configuraciones;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Repositorio.Administracion;

    /// <summary>
    /// Product Variable Manage
    /// </summary>
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionMaestra" />
    public class GestionMaestra : IGestionMaestra
    {
        #region Variables

        /// <summary>
        /// The master repository
        /// </summary>
        private IRepositorioMaestra repositorioMaestra;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionMaestra"/> class.
        /// </summary>
        /// <param name="repositorio">The repository.</param>
        public GestionMaestra(IRepositorioMaestra repositorio)
        {
            this.repositorioMaestra = repositorio;
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Inserts the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        public Resultado InsertarMaestra(Maestra maestra)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioMaestra.InsertarMaestra(maestra);

                if (resultado.Error)
                {
                    resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoInsertarMaestra), LlavesAplicacion.MaestraExiste);
                    resultado.Error = true;
                }
                else if (!resultado.Error)
                {
                    resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoInsertarMaestra), LlavesAplicacion.MaestraGuardada);
                    resultado.Error = false;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoInsertarMaestra), ex, LlavesAplicacion.ExcepcionGuardarMaestra).Mensaje;
            }

            return resultado;
        }

        /// <summary>
        /// Update the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        public Resultado ActualizarMaestra(Maestra maestra)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioMaestra.ActualizarMaestra(maestra);

                resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoActualizarMaestra), LlavesAplicacion.MaestraActualizada);
                resultado.Error = false;
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoActualizarMaestra), ex, LlavesAplicacion.ExcepcionActualizarMaestra).Mensaje;
            }

            return resultado;
        }

        /// <summary>
        /// Search the masters.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>List of masters</returns>
        public IList<Maestra> ConsultarMaestras(Maestra maestra)
        {
            return this.repositorioMaestra.ConsultarMaestras(maestra);
        }

        /// <summary>
        /// Search the master by name.
        /// </summary>
        /// <param name="maestra">The master name.</param>
        /// <returns>List of masters</returns>
        public Maestra ConsultarMaestraPorNombre(string nombreMaestra)
        {
            return this.repositorioMaestra.ConsultarMaestraPorNombre(nombreMaestra);
        }

        /// <summary>
        /// Deletes the master.
        /// </summary>
        /// <param name="maestra">The master.</param>
        /// <returns>Result object</returns>
        public Resultado EliminarMaestra(Maestra maestra)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioMaestra.EliminarMaestra(maestra);

                if (resultado.Error)
                {
                    resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoEliminarMaestra), LlavesAplicacion.MaestraUsadaVenta);
                    resultado.Error = true;
                }
                else if (!resultado.Error)
                {
                    resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoEliminarMaestra), LlavesAplicacion.MaestraEliminada);
                    resultado.Error = false;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoEliminarMaestra), ex, LlavesAplicacion.ExcepcionEliminarMaestra).Mensaje;
            }

            return resultado;
        }

        #endregion
    }
}
