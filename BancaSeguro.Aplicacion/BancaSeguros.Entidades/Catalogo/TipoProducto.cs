//-----------------------------------------------------------------------
// <copyright file="TipoProducto.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Catalogo
{
    using System;

    /// <summary>
    /// Entity type product
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 15/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class TipoProducto
    {
        /// <summary>
        /// The identifier type account
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idTipoCuenta;

        /// <summary>
        /// The code product
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string codigoProducto;

        /// <summary>
        /// The name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombre;

        /// <summary>
        /// The can debit
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool puedeDebitar;

        /// <summary>
        /// The active
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool activo;

        /// <summary>
        /// Gets or sets the identifier type account.
        /// </summary>
        /// <value>
        /// The identifier type account.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdTipoCuenta
        {
            get { return this.idTipoCuenta; }
            set { this.idTipoCuenta = value; }
        }

        /// <summary>
        /// Gets or sets the code product.
        /// </summary>
        /// <value>
        /// The code product.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CodigoProducto
        {
            get { return this.codigoProducto; }
            set { this.codigoProducto = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [can debit].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [can debit]; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool PuedeDebitar
        {
            get { return this.puedeDebitar; }
            set { this.puedeDebitar = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TipoProducto"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
        }
    }
}
