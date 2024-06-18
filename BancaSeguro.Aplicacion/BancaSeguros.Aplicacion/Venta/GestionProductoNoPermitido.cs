//-----------------------------------------------------------------------
// <copyright file="GestionProductoNoPermitido.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Venta
{
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Repositorio.Venta;
    using System.Collections.Generic;

    public class GestionProductoNoPermitido : IGestionProductoNoPermitido
    {
        #region Variables
        private IRepositorioProductoNoPermitido iRepositorioProductoNoPermitido;
        #endregion

        #region Constructores

        public GestionProductoNoPermitido(IRepositorioProductoNoPermitido iRepositorioProductoNoPermitido)
        {
            this.iRepositorioProductoNoPermitido = iRepositorioProductoNoPermitido;
        }
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Consultars the productos no permitidos por seguro.
        /// </summary>
        /// <param name="idSeguro">The identifier seguro.</param>
        /// <returns>ProductoNoPermitido List</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 04/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IEnumerable<ProductoNoPermitido> ConsultarProductosNoPermitidosPorSeguro(int idSeguro)
        {
            return this.iRepositorioProductoNoPermitido.ConsultarProductosNoPermitidosPorSeguro(idSeguro);
        }

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
        public Resultado GuardarProductoNoPermitido(ProductoNoPermitido productoNoPermitido)
        {
            return this.iRepositorioProductoNoPermitido.GuardarProductoNoPermitido(productoNoPermitido);
        }
        
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
        public Resultado EliminarProductoNoPermitido(ProductoNoPermitido productoNoPermitido)
        {
            return this.iRepositorioProductoNoPermitido.EliminarProductoNoPermitido(productoNoPermitido);
        }
        #endregion
    }
}
