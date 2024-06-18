//-----------------------------------------------------------------------
// <copyright file="DetalleCancelacionPoliza.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Seguro
{
    using System;

    /// <summary>
    /// Entity detail cancellation policy
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 03/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class DetalleCancelacionPoliza
    {
        /// <summary>
        /// The causal reject
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private CausalRechazo causalRechazo;

        /// <summary>
        /// The date cancellation
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private DateTime fechaCancelacion;

        /// <summary>
        /// Gets or sets the causal reject.
        /// </summary>
        /// <value>
        /// The causal reject.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public CausalRechazo CausalRechazo
        {
            get { return this.causalRechazo; }
            set { this.causalRechazo = value; }
        }

        /// <summary>
        /// Gets or sets the date cancellation.
        /// </summary>
        /// <value>
        /// The date cancellation.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DateTime FechaCancelacion
        {
            get { return this.fechaCancelacion; }
            set { this.fechaCancelacion = value; }
        }  
    }
}
