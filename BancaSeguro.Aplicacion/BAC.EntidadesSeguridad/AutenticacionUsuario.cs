//-----------------------------------------------------------------------
// <copyright file="AutenticacionUsuario.cs" company="Unión temporal FS-BAC-2013 ">
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
    public class AutenticacionUsuario
    {
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
        /// The access
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool autenticado;

        /// <summary>
        /// The user
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Usuario usuario;

        /// <summary>
        /// The result
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado resultado;

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

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AutenticacionUsuario"/> is access.
        /// </summary>
        /// <value>
        ///   <c>true</c> if access; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Autenticado
        {
            get { return this.autenticado; }
            set { this.autenticado = value; }
        }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Usuario Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado Resultado
        {
            get { return this.resultado; }
            set { this.resultado = value; }
        }
    }
}
