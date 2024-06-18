using BAC.EntidadesSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAC.EntidadesSeguridad
{
    public class RefreshTokenResultado
    {
        /// <summary>
        /// The user
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 24/06/2020
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string token;

        /// <summary>
        /// The user
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 24/06/2020
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private long expiracion;

        /// <summary>
        /// The user
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 24/06/2020
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private DateTime fechaExpiracionToken;

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
        public string Token
        {
            get { return this.token; }
            set { this.token = value; }
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
        public long Expiracion
        {
            get { return this.expiracion; }
            set { this.expiracion = value; }
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
        public DateTime FechaExpiracionToken
        {
            get { return this.fechaExpiracionToken; }
            set { this.fechaExpiracionToken = value; }
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
