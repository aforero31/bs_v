//-----------------------------------------------------------------------
// <copyright file="CanalVenta.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Catalogo
{
    using System;

    /// <summary>
    /// Entity saleChannel
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 12/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class CanalVenta
    {
        /// <summary>
        /// The identifier saleChannel
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idCanalVenta;

        /// <summary>
        /// The code sale
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int codigo;

        /// <summary>
        /// The name sale channel
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombre;

        /// <summary>
        /// The name sale channel
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string login;

        /// <summary>
        /// The active
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool activo;

        /// <summary>
        /// Gets or sets the name sale channel.
        /// </summary>
        /// <value>
        /// The name sale channel.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Gets or sets the code sale channel.
        /// </summary>
        /// <value>
        /// The code sale channel.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }

        /// <summary>
        /// Gets or sets the identifier sale channel.
        /// </summary>
        /// <value>
        /// The identifier sale channel.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdCanalVenta
        {
            get { return this.idCanalVenta; }
            set { this.idCanalVenta = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CanalVenta"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CanalVenta"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Login 
        {
            get { return this.login; }
            set { this.login = value; }
        }
    }
}
