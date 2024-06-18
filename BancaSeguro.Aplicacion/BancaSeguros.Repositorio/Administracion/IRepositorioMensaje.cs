//-----------------------------------------------------------------------
// <copyright file="IRepositorioMensaje.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Repositorio.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.General;

    /// <summary>
    /// Message repository interface
    /// </summary>
    public interface IRepositorioMensaje
    {
        /// <summary>
        /// Search the messages.
        /// </summary>
        /// <param name="mensaje">The message to search.</param>
        /// <returns>List of messages</returns>
        IList<Mensaje> ConsultarMensajes();

        /// <summary>
        /// Inserts the message.
        /// </summary>
        /// <param name="mensaje">The message.</param>
        /// <returns>result of operation</returns>
        Resultado InsertarMensaje(Mensaje mensaje);

        /// <summary>
        /// Update the message.
        /// </summary>
        /// <param name="mensaje">The message.</param>
        /// <returns>Result of operation</returns>
        Resultado ActualizarMensaje(Mensaje mensaje);

        /// <summary>
        /// Search the message by identifier.
        /// </summary>
        /// <param name="idMensaje">The identifier of message.</param>
        /// <returns>Message object</returns>
        Mensaje ConsultarMensajePorId(int? idEvento, string Llave);
    }
}
