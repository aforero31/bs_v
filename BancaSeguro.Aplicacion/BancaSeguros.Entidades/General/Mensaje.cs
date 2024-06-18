//-----------------------------------------------------------------------
// <copyright file="Mensaje.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Message Class
    /// </summary>
    [Serializable]
    public class Mensaje
    {
        /// <summary>
        /// The identifier message
        /// </summary>
        private int idMensaje;

        /// <summary>
        /// The key
        /// </summary>
        private string llave;

        /// <summary>
        /// The identifier message type
        /// </summary>
        private int idTipoMensaje;

        /// <summary>
        /// The identifier alert type
        /// </summary>
        private int idEvento;

        /// <summary>
        /// The event
        /// </summary>
        private string eventos;

        /// <summary>
        /// The message
        /// </summary>
        private string mensaje;

        /// <summary>
        /// The user Logged
        /// </summary>
        private string login;

        /// <summary>
        /// The result
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 01/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado resultado;

        /// <summary>
        /// Gets or sets the identifier message.
        /// </summary>
        /// <value>
        /// The identifier message.
        /// </value>
        public int IdMensaje
        {
            get { return this.idMensaje; }
            set { this.idMensaje = value; }
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Llave
        {
            get { return this.llave; }
            set { this.llave = value; }
        }

        /// <summary>
        /// Gets or sets the identifier message type.
        /// </summary>
        /// <value>
        /// The identifier message type.
        /// </value>
        public int IdTipoMensaje
        {
            get { return this.idTipoMensaje; }
            set { this.idTipoMensaje = value; }
        }

        /// <summary>
        /// Gets or sets the identifier alert type.
        /// </summary>
        /// <value>
        /// The identifier alert type.
        /// </value>
        public int IdEvento
        {
            get { return this.idEvento; }
            set { this.idEvento = value; }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string DescripcionMensaje
        {
            get { return this.mensaje; }
            set { this.mensaje = value; }
        }

        /// <summary>
        /// Gets or sets the events
        /// </summary>
        /// <value>
        /// The event.
        /// </value>
        public string Eventos
        {
            get { return this.eventos; }
            set { this.eventos = value; } 
        }

        /// <summary>
        /// Gets or sets the user logged.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public string Login
        {
            get { return this.login; }
            set { this.login = value; }
        }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 01/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado Resultado
        {
            get
            {
                return resultado;
            }

            set
            {
                resultado = value;
            }
        }
    }
}
