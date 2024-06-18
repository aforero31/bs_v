using BAC.EntidadesSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAC.EntidadesSeguridad
{
    public class TokenResultado
    {
        /// <summary>
        /// The message
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 24/06/2020
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string mensaje;

        /// <summary>
        /// The access
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 24/06/2020
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool autenticado;

        /// <summary>
        /// The user
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 24/06/2020
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private TokenResponse tokenResponse;

        /// <summary>
        /// The result
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 24/06/2020
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
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 24/06/2020
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
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 24/06/2020
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
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 24/06/2020
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public TokenResponse TokenResponse
        {
            get { return this.tokenResponse; }
            set { this.tokenResponse = value; }
        }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 24/06/2020
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
