//-----------------------------------------------------------------------
// <copyright file="Permisos.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BAC.EntidadesSeguridad
{
    using System;

    /// <summary>
    /// Permissions Class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 26/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class Permisos
    {
        /// <summary>
        /// The identifier menu
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idMenu;

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
        /// The active
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool? activo;

        /// <summary>
        /// Gets or sets the identifier menu.
        /// </summary>
        /// <value>
        /// The identifier menu.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdMenu
        {
            get { return this.idMenu; }
            set { this.idMenu = value; }
        }

        /// <summary>
        /// Gets or sets the identifier role.
        /// </summary>
        /// <value>
        /// The identifier rol.
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
        /// The login
        /// </summary>
        public string login;

        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The activo.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool? Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
        }
    }
}
