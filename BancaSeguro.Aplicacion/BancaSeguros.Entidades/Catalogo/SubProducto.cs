//-----------------------------------------------------------------------
// <copyright file="SubProducto.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Catalogo
{
    using System;

    /// <summary>
    /// Class to manage SubProducto
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 19/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class SubProducto
    {
        /// <summary>
        /// Gets or sets the identifier sub productos.
        /// </summary>
        /// <value>
        /// The identifier sub productos.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdSubProductos { get; set; }

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
        public int Codigo { get; set; }

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
        /// Gets or sets the activo.
        /// </summary>
        /// <value>
        /// The activo.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Activo { get; set; }

        /// <summary>
        /// Gets or sets the IdProducto.
        /// </summary>
        /// <value>
        /// The activo.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\Enrique Rivera
        /// CreationDate: 25/10/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdProducto { get; set; }
    }
}
