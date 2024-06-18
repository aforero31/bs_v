//-----------------------------------------------------------------------
// <copyright file="CodigoPlan.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Seguro
{
    using System;

    /// <summary>
    /// CodigoPlan entidad
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 11/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class CodigoPlan
    {
        /// <summary>
        /// Gets or sets the identifier codigo plan.
        /// </summary>
        /// <value>
        /// The identifier codigo plan.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 11/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdCodigoPlan { get; set; }

        /// <summary>
        /// Gets or sets the codigo.
        /// </summary>
        /// <value>
        /// The codigo.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 11/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Codigo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CodigoPlan"/> is activo.
        /// </summary>
        /// <value>
        ///   <c>true</c> if activo; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 11/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Activo { get; set; }
    }
}
