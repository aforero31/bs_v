//-----------------------------------------------------------------------
// <copyright file="ItemMaestra.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Entidades.Catalogo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Master class
    /// </summary>
    public class ItemMaestra
    {
        /// <summary>
        /// The identifier master
        /// </summary>
        private int idMaestra;

        /// <summary>
        /// The code
        /// </summary>
        private string codigo;

        /// <summary>
        /// The value
        /// </summary>
        private string valor;

        /// <summary>
        /// The active
        /// </summary>
        private bool? activo;

        /// <summary>
        /// The login
        /// </summary>
        private string login;

        /// <summary>
        /// Gets or sets the identifier master.
        /// </summary>
        /// <value>
        /// The identifier master.
        /// </value>
        public int IdMaestra
        {
            get { return this.idMaestra; }
            set { this.idMaestra = value; }
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }

        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        public bool? Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
        }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        /// <value>
        /// The login.
        /// </value>
        public string Login
        {
            get { return this.login; }
            set { this.login = value; }
        }
    }
}
