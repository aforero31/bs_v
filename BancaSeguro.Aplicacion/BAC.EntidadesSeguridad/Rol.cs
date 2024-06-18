//-----------------------------------------------------------------------
// <copyright file="Rol.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BAC.EntidadesSeguridad
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Role Class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 26/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class Rol
    {
        /// <summary>
        /// The identifier role
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idRol;

        /// <summary>
        /// The name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombre;

        /// <summary>
        /// The active
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool activo;
        
        /// <summary>
        /// The BC group
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private List<GrupoBAC> gruposBAC;

        /// <summary>
        /// The menus
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private List<Menu> menus;

        /// <summary>
        /// The login
        /// </summary>
        private string login;

        /// <summary>
        /// Gets or sets the identifier role.
        /// </summary>
        /// <value>
        /// The identifier role.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdRol
        {
            get { return this.idRol; }
            set { this.idRol = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Rol"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
        }

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>
        /// The group.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<GrupoBAC> GruposBAC
        {
            get { return this.gruposBAC; }
            set { this.gruposBAC = value; }
        }

        /// <summary>
        /// Gets or sets the menus.
        /// </summary>
        /// <value>
        /// The menus.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Menu> Menus
        {
            get { return this.menus; }
            set { this.menus = value; }
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
