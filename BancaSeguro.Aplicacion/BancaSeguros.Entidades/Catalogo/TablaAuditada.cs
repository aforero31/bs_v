//-----------------------------------------------------------------------
// <copyright file="TablaAuditada.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Entidades.Catalogo
{
    using System;

    /// <summary>
    /// Audit table class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 19/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class TablaAuditada
    {
        /// <summary>
        /// The identifier table
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idTabla;

        /// <summary>
        /// The name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombre;

        /// <summary>
        /// Gets or sets the identifier table.
        /// </summary>
        /// <value>
        /// The identifier table.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdTabla
        {
            get { return this.idTabla; }
            set { this.idTabla = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
    }
}
