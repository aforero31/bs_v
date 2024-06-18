//-----------------------------------------------------------------------
// <copyright file="IGestionCategoria.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Administracion
{
    using BancaSeguros.Entidades.Catalogo;
    using System.Collections.Generic;

    /// <summary>
    /// Category management class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 19/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionCategoria
    {
        /// <summary>
        /// Gets categories by SubProductoIdentifier.
        /// </summary>
        /// <param name="idSubProducto">The identifier sub producto.</param>
        /// <returns>Categories list</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IList<Categoria> ObtenerCategoriasPorIdSubProducto(int idSubProducto);
    }
}
