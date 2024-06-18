//-----------------------------------------------------------------------
// <copyright file="GestionMensaje.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Repositorio.Administracion;
    using BancaSeguros.Aplicacion.Configuraciones;

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
        public GestionMensaje(IRepositorioMensaje interfazRepositorioMensaje)
        {
            this.repositorioMensaje = interfazRepositorioMensaje;
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Search Message.
        /// </summary>
        /// <param name="mensaje">The Message</param>
        /// <returns>
        /// Entity Result
        /// </returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 28/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Mensaje> ConsultarMensajes(Mensaje mensaje)
        {
            IList<Mensaje> mensajesRetorno = new List<Mensaje>();
            List<Mensaje> mensajes = new List<Mensaje>();

            try
            {
                mensajesRetorno = this.repositorioMensaje.ConsultarMensajes();
                mensajes.AddRange(mensajesRetorno);
                mensajes = mensajes.FindAll(x => x.IdEvento == (mensaje.IdEvento == 0 ? x.IdEvento : mensaje.IdEvento) && x.IdTipoMensaje == (mensaje.IdTipoMensaje == 0 ? x.IdTipoMensaje : mensaje.IdTipoMensaje) && x.Llave == (mensaje.Llave == string.Empty ? x.Llave : mensaje.Llave));
            }
            catch (System.Exception exc)
            {
                mensajes = new List<Mensaje>();
                Mensaje mensa = new Mensaje();
                mensa.Resultado = new Resultado();
                var controlError = LlavesAplicacion.ExcepcionConsultarMensajes;
                int evento = int.Parse(LlavesAplicacion.EventoParametrizacionMensajesConsultarMensaje);
                mensa.Resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(evento, exc, controlError);
            }

            return mensajes;
        }

        /// <summary>
        /// Inserts the Message.
        /// </summary>
        /// <param name="mensaje">The Message</param>
        /// <returns>Result operation</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado InsertarMensaje(Mensaje mensaje)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioMensaje.InsertarMensaje(mensaje);

                if (!resultado.Error)
                {
                    var controlMensaje = LlavesAplicacion.MensajeGuardado;
                    int evento = int.Parse(LlavesAplicacion.EventoParametrizacionMensajesGuardaMensaje);
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(evento, controlMensaje);
                }
            }
            catch (System.Exception exc)
            {
                var controlError = LlavesAplicacion.ExcepcionGuardarMensaje;
                int evento = int.Parse(LlavesAplicacion.EventoParametrizacionMensajesGuardaMensaje);
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(evento, exc, controlError);
            }

            return resultado;
        }

        /// <summary>
        /// Update Message.
        /// </summary>
        /// <param name="mensaje">The message.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarMensaje(Mensaje mensaje)
        {
            Resultado resultado = new Resultado();

            try
            {
                resultado = this.repositorioMensaje.ActualizarMensaje(mensaje);

                if (!resultado.Error)
                {
                    var controlMensaje = LlavesAplicacion.MensajeActualizado;
                    int evento = int.Parse(LlavesAplicacion.EventoParametrizacionMensajeActualizarMensaje);
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(evento, controlMensaje);
                }
            }
            catch (System.Exception exc)
            {
                var controlError = LlavesAplicacion.ExcepcionActualizarMensaje;
                int evento = int.Parse(LlavesAplicacion.EventoParametrizacionMensajeActualizarMensaje);
                resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(evento, exc, controlError);
            }

            return resultado;
        }

        #endregion
    }
}
