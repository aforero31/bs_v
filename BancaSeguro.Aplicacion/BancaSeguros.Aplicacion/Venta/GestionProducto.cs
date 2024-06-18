//-----------------------------------------------------------------------
// <copyright file="GestionProducto.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Venta
{
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Repositorio.Venta;
    using System.Collections.Generic;

    public class GestionProducto : IGestionProducto
    {
        #region Variables
        /// <summary>
        /// The repositorio producto
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 02/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioProducto repositorioProducto;
        #endregion

        #region Constructor

        public GestionProducto(IRepositorioProducto repositorioProducto)
        {
            this.repositorioProducto = repositorioProducto;
        }

        #endregion

        #region Metodos publicos
        /// <summary>
        /// Obteners the sub productos por codigo producto.
        /// </summary>
        /// <param name="codigoProducto">The codigo producto.</param>
        /// <returns>list of subproductos</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 02/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<SubProducto> ObtenerSubProductosPorCodigoProducto(int codigoProducto)
        {
            return this.repositorioProducto.ObtenerSubProductosPorCodigoProducto(codigoProducto);
        }

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
        public IList<Producto> ObtenerProductosBancariosActivos()
        {
            return this.repositorioProducto.ObtenerProductosBancariosActivos();
        }
        #endregion
    }
}
