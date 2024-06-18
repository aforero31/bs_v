//-----------------------------------------------------------------------
// <copyright file="Convenio.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Seguro
{
    using System;

    /// <summary>
    /// Convenio entity
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 02/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class Convenio
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 02/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the codigoConvenio.
        /// </summary>
        /// <value>
        /// The codigo convenio.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 02/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int CodigoConvenio { get; set; }

        /// <summary>
        /// Gets or sets the nombre convenio.
        /// </summary>
        /// <value>
        /// The nombre convenio.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 02/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NombreConvenio { get; set; }

        /// <summary>
        /// Gets or sets the identifier aseguradora.
        /// </summary>
        /// <value>
        /// The identifier aseguradora.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 02/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdAseguradora { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Convenio"/> is activo.
        /// </summary>
        /// <value>
        ///   <c>true</c> if activo; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 02/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Activo { get; set; }
    }
}
