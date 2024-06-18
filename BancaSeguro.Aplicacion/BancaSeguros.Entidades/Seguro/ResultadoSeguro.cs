//-----------------------------------------------------------------------
// <copyright file="ResultadoSeguro.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Seguro
{
    using BancaSeguros.Entidades.General;

    /// <summary>
    /// Insurance result Entity
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 03/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public class ResultadoSeguro
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado Resultado { get; set; }
        
        /// <summary>
        /// Gets or sets the identifier insurance.
        /// </summary>
        /// <value>
        /// The identifier insurance.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdSeguro { get; set; }
    }
}
