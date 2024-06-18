//-----------------------------------------------------------------------
// <copyright file="IRepositorioCategoria.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Venta
{
    using BancaSeguros.Entidades.Catalogo;
    using System.Collections.Generic;

    /// <summary>
    /// Categoria repository class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 19/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IRepositorioCategoria
    {
        /// <summary>
        /// gets the categories by identifier sub producto.
        /// </summary>
        /// <param name="idSubProducto">The identifier sub producto.</param>
        /// <returns>Categories List</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
       IList<Categoria> ObtenerCategoriasPorIdSubProducto(int idSubProducto);
    }
}
