//-----------------------------------------------------------------------
// <copyright file="TipoProductoNoPermitido.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Tipos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TipoProductoNoPermitido
    {
        /// <summary>
        /// The identifier sure
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idSeguro;

        /// <summary>
        /// The code product
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string codigoProducto;

        /// <summary>
        /// The code subproduct
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string codigoSubProducto;

        /// <summary>
        /// The code category
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string codigoCategoria;

        /// <summary>
        /// Gets or sets the identifier sure.
        /// </summary>
        /// <value>
        /// The identifier seguro.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdSeguro
        {
            get
            {
                return idSeguro;
            }

            set
            {
                idSeguro = value;
            }
        }

        /// <summary>
        /// Gets or sets the code product.
        /// </summary>
        /// <value>
        /// The code product.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CodigoProducto
        {
            get
            {
                return codigoProducto;
            }

            set
            {
                codigoProducto = value;
            }
        }

        /// <summary>
        /// Gets or sets the code subproduct.
        /// </summary>
        /// <value>
        /// The code subproduct.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CodigoSubProducto
        {
            get
            {
                return codigoSubProducto;
            }

            set
            {
                codigoSubProducto = value;
            }
        }

        /// <summary>
        /// Gets or sets the code category.
        /// </summary>
        /// <value>
        /// The code category.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CodigoCategoria
        {
            get
            {
                return codigoCategoria;
            }

            set
            {
                codigoCategoria = value;
            }
        }
    }
}
