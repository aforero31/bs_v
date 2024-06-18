//-----------------------------------------------------------------------
// <copyright file="TipoSeguroTipoIdenti.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Tipos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class TipoSeguroTipoIdenti
    {
        /// <summary>
        /// The identifier sure
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idSeguro;

        /// <summary>
        /// The identifier type identification
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idTipoIdentificacion;

        /// <summary>
        /// Gets or sets the identifier sure.
        /// </summary>
        /// <value>
        /// The identifier sure.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdSeguro
        {
            get
            {
                return idSeguro;
            }

            set
            {
                idSeguro = value;
            }
        }

        /// <summary>
        /// Gets or sets the identifier type identification.
        /// </summary>
        /// <value>
        /// The identifier type identification.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdTipoIdentificacion
        {
            get
            {
                return idTipoIdentificacion;
            }

            set
            {
                idTipoIdentificacion = value;
            }
        }
    }
}
