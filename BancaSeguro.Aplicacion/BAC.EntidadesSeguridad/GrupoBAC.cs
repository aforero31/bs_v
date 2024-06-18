//-----------------------------------------------------------------------
// <copyright file="GrupoBAC.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BAC.EntidadesSeguridad
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Group Class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 27/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class GrupoBAC
    {
        /// <summary>
        /// The identifier group
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idGrupo;

        /// <summary>
        /// The group code
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string codigoGrupo;

        /// <summary>
        /// The group name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombreGrupo;

        /// <summary>
        /// The active
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool? activo;

        /// <summary>
        /// The role
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private List<Rol> roles;

        /// <summary>
        /// Gets or sets the identifier group.
        /// </summary>
        /// <value>
        /// The identifier group.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdGrupo
        {
            get { return this.idGrupo; }
            set { this.idGrupo = value; }
        }

        /// <summary>
        /// Gets or sets the group code.
        /// </summary>
        /// <value>
        /// The group code.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CodigoGrupo
        {
            get { return this.codigoGrupo; }
            set { this.codigoGrupo = value; }
        }

        /// <summary>
        /// Gets or sets the group name.
        /// </summary>
        /// <value>
        /// The group name.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NombreGrupo
        {
            get { return this.nombreGrupo; }
            set { this.nombreGrupo = value; }
        }

        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool? Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
        }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Rol> Roles
        {
            get { return this.roles; }
            set { this.roles = value; }
        }
    }
}
