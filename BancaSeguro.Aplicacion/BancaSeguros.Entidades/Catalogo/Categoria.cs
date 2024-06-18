//-----------------------------------------------------------------------
// <copyright file="Categoria.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Catalogo
{
    using System;

    /// <summary>
    /// Class to manage Categoria
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 19/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class Categoria
    {
        /// <summary>
        /// Gets or sets the identifier categoria.
        /// </summary>
        /// <value>
        /// The identifier categoria.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdCategoria { get; set; }

        /// <summary>
        /// Gets or sets the codigo.
        /// </summary>
        /// <value>
        /// The codigo.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Codigo { get; set; }

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Categoria"/> is activo.
        /// </summary>
        /// <value>
        ///   <c>true</c> if activo; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Activo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Categoria"/> is activo.
        /// </summary>
        /// <value>
        ///   <c>true</c> if activo; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\jgonzalezg
        /// CreationDate: 19/10/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdProducto { get; set; }
    }
}
