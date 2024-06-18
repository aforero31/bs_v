//-----------------------------------------------------------------------
// <copyright file="Resultado.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BAC.EntidadesSeguridad
{
    using System;

    /// <summary>
    /// Class Entity
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 02/06/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class Resultado
    {
        /// <summary>
        /// The error
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool error;

        /// <summary>
        /// The message
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string mensaje;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Resultado"/> is error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if error; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
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
        /// CreationDate: 02/06/2016
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
