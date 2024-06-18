//-----------------------------------------------------------------------
// <copyright file="IGestionProductoNoPermitido.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Venta
{
    using System.Collections.Generic;
    using Entidades.General;
    using Entidades.Venta;

    /// <summary>
    /// GestionProductoNoPermitido interfaz
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 04/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionProductoNoPermitido
    {
        /// <summary>
        /// Gets the not allowed products by insurance.
        /// </summary>
        /// <param name="idSeguro">The identifier seguro.</param>
        /// <returns>not allowed products list</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 04/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>|
        IEnumerable<ProductoNoPermitido> ConsultarProductosNoPermitidosPorSeguro(int idSeguro);

        /// <summary>
        /// Saves the producto no permitido.
        /// </summary>
        /// <param name="productoNoPermitido">The producto no permitido.</param>
        /// <returns>Resultado Object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 04/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado GuardarProductoNoPermitido(ProductoNoPermitido productoNoPermitido);

        /// <summary>
        /// Deletes the producto no permitido.
        /// </summary>
        /// <param name="productoNoPermitido">The producto no permitido.</param>
        /// <returns>Resultado Object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 04/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado EliminarProductoNoPermitido(ProductoNoPermitido productoNoPermitido);
    }
}
