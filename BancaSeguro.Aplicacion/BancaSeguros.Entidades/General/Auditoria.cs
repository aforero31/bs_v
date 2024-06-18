//-----------------------------------------------------------------------
// <copyright file="Auditoria.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Entidades.General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Audit class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 17/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class Auditoria
    {
        /// <summary>
        /// The identifier audit
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idAuditoria;

        /// <summary>
        /// The type
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string tipo;

        /// <summary>
        /// The table name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombreTabla;

        /// <summary>
        /// The key field
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string campoLlave;

        /// <summary>
        /// The value key
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string valorLlave;

        /// <summary>
        /// The field
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string campo;

        /// <summary>
        /// The old value
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string valorAnterior;

        /// <summary>
        /// The new value
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nuevoValor;

        /// <summary>
        /// The update date
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private DateTime fechaActualizacion;

        /// <summary>
        /// The user
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string usuario;

        /// <summary>
        /// The update initial date
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private DateTime? fechaIniActualizacion;

        /// <summary>
        /// The update final date
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private DateTime? fechaFinActualizacion;

        /// <summary>
        /// Gets or sets the identifier audit.
        /// </summary>
        /// <value>
        /// The identifier audit.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdAuditoria
        {
            get { return this.idAuditoria; }
            set { this.idAuditoria = value; }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        /// <summary>
        /// Gets or sets the table name.
        /// </summary>
        /// <value>
        /// The table name.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NombreTabla
        {
            get { return this.nombreTabla; }
            set { this.nombreTabla = value; }
        }

        /// <summary>
        /// Gets or sets the key field.
        /// </summary>
        /// <value>
        /// The key field.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CampoLlave
        {
            get { return this.campoLlave; }
            set { this.campoLlave = value; }
        }

        /// <summary>
        /// Gets or sets the key value.
        /// </summary>
        /// <value>
        /// The key value.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string ValorLlave
        {
            get { return this.valorLlave; }
            set { this.valorLlave = value; }
        }

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>
        /// The field.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Campo
        {
            get { return this.campo; }
            set { this.campo = value; }
        }

        /// <summary>
        /// Gets or sets the old value.
        /// </summary>
        /// <value>
        /// The old value.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string ValorAnterior
        {
            get { return this.valorAnterior; }
            set { this.valorAnterior = value; }
        }

        /// <summary>
        /// Gets or sets the new value.
        /// </summary>
        /// <value>
        /// The new value.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NuevoValor
        {
            get { return this.nuevoValor; }
            set { this.nuevoValor = value; }
        }

        /// <summary>
        /// Gets or sets the update date.
        /// </summary>
        /// <value>
        /// The update date.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DateTime FechaActualizacion
        {
            get { return this.fechaActualizacion; }
            set { this.fechaActualizacion = value; }
        }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        /// <summary>
        /// Gets or sets the initial update date.
        /// </summary>
        /// <value>
        /// The initial update date.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DateTime? FechaIniActualizacion
        {
            get { return this.fechaIniActualizacion; }
            set { this.fechaIniActualizacion = value; }
        }

        /// <summary>
        /// Gets or sets the final update date.
        /// </summary>
        /// <value>
        /// The final update date.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DateTime? FechaFinActualizacion
        {
            get { return this.fechaFinActualizacion; }
            set { this.fechaFinActualizacion = value; }
        }
    }
}
