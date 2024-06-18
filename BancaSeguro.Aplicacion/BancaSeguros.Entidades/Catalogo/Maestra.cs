//-----------------------------------------------------------------------
// <copyright file="Maestra.cs" company="Unión temporal FS-BAC-2013 ">
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
    public class Maestra
    {
        /// <summary>
        /// The identifier master
        /// </summary>
        private int idMaestra;

        /// <summary>
        /// The name
        /// </summary>
        private string nombre;

        /// <summary>
        /// The active
        /// </summary>
        private bool? activo;

        /// <summary>
        /// The login
        /// </summary>
        private string login;

        /// <summary>
        /// The items
        /// </summary>
        private List<ItemMaestra> items;

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
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
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

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<ItemMaestra> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }
    }
}
