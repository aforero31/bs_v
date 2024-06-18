//-----------------------------------------------------------------------
// <copyright file="Resultado.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.General
{
    using System;

    /// <summary>
    /// Entity Result
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 13/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class Resultado
    {
        /// <summary>
        /// The ex
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\CBLANDON
        /// CreationDate: 06/03/2017
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string ex;

        /// <summary>
        /// The error
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 23/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool error;

        /// <summary>
        /// The message
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 23/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string mensaje;

        /// <summary>
        /// The Id message type
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 23/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idTipoMensaje;

        /// <summary>
        /// Initializes a new instance of the <see cref="Resultado"/> class.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado()
        {
            this.Error = false;
            this.Mensaje = string.Empty;
            this.IdTipoMensaje = 0;
            this.Ex = string.Empty;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Ex"/> is error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if error; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CBLANDON
        /// CreationDate: 06/03/2017
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Ex
        {
            get { return this.ex; }
            set { this.ex = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Resultado"/> is error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if error; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Error
        {
            get { return this.error; }
            set { this.error = value; }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Mensaje
        {
            get { return this.mensaje; }
            set { this.mensaje = value; }
        }

        /// <summary>
        /// Gets or sets the identifier tipo mensaje.
        /// </summary>
        /// <value>
        /// The identifier tipo mensaje.
        /// </value>
        public int IdTipoMensaje
        {
            get { return this.idTipoMensaje; }
            set { this.idTipoMensaje = value; }
        }
    }
}