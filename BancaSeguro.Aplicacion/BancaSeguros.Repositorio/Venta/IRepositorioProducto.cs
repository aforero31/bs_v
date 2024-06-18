//-----------------------------------------------------------------------
// <copyright file="IRepositorioProducto.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Venta
{
    using BancaSeguros.Entidades.Catalogo;
    using System.Collections.Generic;

    /// <summary>
    /// RepositorioProducto Interface
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 02/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IRepositorioProducto
    {
        /// <summary>
        /// gets the subproductos By CodigoProducto.
        /// </summary>
        /// <param name="codigoProducto">The codigo producto.</param>
        /// <returns>list of subProductos</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 02/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IList<SubProducto> ObtenerSubProductosPorCodigoProducto(int codigoProducto);

        /// <summary>
        /// Gets the productos bancarios activos.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 06/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        IList<Producto> ObtenerProductosBancariosActivos();
    }
}
