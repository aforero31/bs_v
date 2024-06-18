//-----------------------------------------------------------------------
// <copyright file="Menu.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BAC.EntidadesSeguridad
{
    using System;

    /// <summary>
    /// Class Entity
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 02/06/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class Menu
    {
        /// <summary>
        /// The identifier menu
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idMenu;

        /// <summary>
        /// The identifier dad
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idPadre;

        /// <summary>
        /// The name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombre;

        /// <summary>
        /// The position
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int posicion;

        /// <summary>
        /// The URL
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string url;

        /// <summary>
        /// The active
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool activo;

        /// <summary>
        /// Gets or sets the identifier menu.
        /// </summary>
        /// <value>
        /// The identifier menu.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdMenu
        {
            get { return this.idMenu; }
            set { this.idMenu = value; }
        }

        /// <summary>
        /// Gets or sets the identifier dad.
        /// </summary>
        /// <value>
        /// The identifier dad.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdPadre
        {
            get { return this.idPadre; }
            set { this.idPadre = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int Posicion
        {
            get { return this.posicion; }
            set { this.posicion = value; }
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Url
        {
            get { return this.url; }
            set { this.url = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Menu"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
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
