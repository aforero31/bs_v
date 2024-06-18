//-----------------------------------------------------------------------
// <copyright file="ProductoNoPermitido.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Venta
{
    using BancaSeguros.Entidades.Catalogo;
    using System;

    /// <summary>
    /// Not allowed producto entity
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 03/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class ProductoNoPermitido
    {
        private int idSeguro;
        private Producto producto;
        private SubProducto subProducto;
        private Categoria categoria;

        public SubProducto SubProducto
        {
            get { return subProducto; }
            set { subProducto = value; }
        }

        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        public Categoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        /// <summary>
        /// Gets or sets the identifier seguro.
        /// </summary>
        /// <value>
        /// The identifier seguro.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdSeguro
        {
            get { return idSeguro; }
            set { idSeguro = value; }
        }

        public string Login { get; set; }
    }
}
