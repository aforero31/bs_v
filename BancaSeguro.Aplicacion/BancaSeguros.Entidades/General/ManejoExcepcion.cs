//-----------------------------------------------------------------------
// <copyright file="ManejoExcepcion.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.General
{
    using System;

    /// <summary>
    /// Entity use exception
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 15/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class ManejoExcepcion
    {
        /// <summary>
        /// The error
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool error;

        /// <summary>
        /// The message
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string mensaje;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManejoExcepcion"/> class.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ManejoExcepcion()
        {
            this.Error = false;
            this.Mensaje = string.Empty;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ManejoExcepcion"/> is error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if error; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 15/04/2016
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
        /// CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Mensaje
        {
            get { return this.mensaje; }
            set { this.mensaje = value; }
        }
    }
}
