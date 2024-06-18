//-----------------------------------------------------------------------
// <copyright file="CausalRechazo.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Seguro
{
    using System;

    /// <summary>
    /// Entity Rejection Causal
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 03/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class CausalRechazo
    {
        /// <summary>
        /// The code causal rejection
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int codigoCausalRechazo;

        /// <summary>
        /// The name causal rejection
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombreCausalRechazo;

        /// <summary>
        /// Gets or sets the code causal rejection.
        /// </summary>
        /// <value>
        /// The code causal rejection.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int CodigoCausalRechazo
        {
            get { return this.codigoCausalRechazo; }
            set { this.codigoCausalRechazo = value; }
        }

        /// <summary>
        /// Gets or sets the name causal rejection.
        /// </summary>
        /// <value>
        /// The name causal rejection.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NombreCausalRechazo
        {
            get { return this.nombreCausalRechazo; }
            set { this.nombreCausalRechazo = value; }
        }
    }
}
