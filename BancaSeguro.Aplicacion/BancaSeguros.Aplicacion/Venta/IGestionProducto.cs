//-----------------------------------------------------------------------
// <copyright file="IGestionProducto.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Venta
{
    using BancaSeguros.Entidades.Catalogo;
    using System.Collections.Generic;

    /// <summary>
    /// GestionProducto Interfaz
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 06/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionProducto
    {
        /// <summary>
        /// gets the subProductos by codigoProducto.
        /// </summary>
        /// <param name="codigoProducto">The codigo producto.</param>
        /// <returns>list of subproductos</returns>
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
