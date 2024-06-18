//-----------------------------------------------------------------------
// <copyright file="IRepositorioProductoNoPermitido.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Venta
{
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Venta;
    using System.Collections.Generic;
    using System.Data;

    public interface IRepositorioProductoNoPermitido
    {
        IList<ProductoNoPermitido> ConsultarProductosNoPermitidosPorSeguro(int idSeguro);

        Resultado GuardarProductoNoPermitido(ProductoNoPermitido productoNoPermitido);

        Resultado EliminarProductoNoPermitido(ProductoNoPermitido productoNoPermitido);

        /// <summary>
        /// Update the products no access por identifier.
        /// </summary>
        /// <param name="produtos">The produts.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado ActualizarProductosNoPermitidosPorId(DataTable produtos, int idSeguro, string login);
    }
}
