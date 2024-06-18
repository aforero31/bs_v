//-----------------------------------------------------------------------
// <copyright file="Aseguradora.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Seguro
{
    using System;
    using Entidades.Catalogo;

    /// <summary>
    /// Class Insurance
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 14/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class Aseguradora
    {
        /// <summary>
        /// The identifier 
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idAseguradora;

        /// <summary>
        /// The name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombre;

        /// <summary>
        /// The code
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string codigoSuperintendencia;

        /// <summary>
        /// The identification type
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private TipoIdentificacion tipoIdentificacion;

        /// <summary>
        /// The identification
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string identificacion;

        /// <summary>
        /// The contact
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string contacto;

        /// <summary>
        /// The phone
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string telefono;

        /// <summary>
        /// The mail
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string correo;

        /// <summary>
        /// The active
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        /// CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool? activo;

        /// <summary>
        /// The initial consecutive
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int consecutivoInicial;

        /// <summary>
        /// The current consecutive
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int consecutivoActual;

        /// <summary>
        /// The current User logged
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 04/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string login;

        /// <summary>
        /// The update consecutive
        /// </summary>
        private bool actualizaConsecutivo;

        /// <summary>
        /// The agreement
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Convenio convenio;

        /// <summary>
        /// Gets or sets the agreement.
        /// </summary>
        /// <value>
        /// The agreement.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Convenio Convenio
        {
            get { return convenio; }
            set { convenio = value; }
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdAseguradora
        {
            get { return this.idAseguradora; }
            set { this.idAseguradora = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CodigoSuperintendencia
        {
            get { return this.codigoSuperintendencia; }
            set { this.codigoSuperintendencia = value; }
        }

        /// <summary>
        /// Gets or sets the identification type.
        /// </summary>
        /// <value>
        /// The identification type.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        /// CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public TipoIdentificacion TipoIdentificacion
        {
            get { return this.tipoIdentificacion; }
            set { this.tipoIdentificacion = value; }
        }

        /// <summary>
        /// Gets or sets the identification.
        /// </summary>
        /// <value>
        /// The identification.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Identificacion
        {
            get { return this.identificacion; }
            set { this.identificacion = value; }
        }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        /// <value>
        /// The contact.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Contacto
        {
            get { return this.contacto; }
            set { this.contacto = value; }
        }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }

        /// <summary>
        /// Gets or sets the mail.
        /// </summary>
        /// <value>
        /// The mail.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Correo
        {
            get { return this.correo; }
            set { this.correo = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Administradora"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        /// CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool? Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
        }

        /// <summary>
        /// Gets or sets the initial consecutive.
        /// </summary>
        /// <value>
        /// The initial consecutive.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int ConsecutivoInicial
        {
            get { return this.consecutivoInicial; }
            set { this.consecutivoInicial = value; }
        }

        /// <summary>
        /// Gets or sets the current consecutive.
        /// </summary>
        /// <value>
        /// The current consecutive.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int ConsecutivoActual
        {
            get { return this.consecutivoActual; }
            set { this.consecutivoActual = value; }
        }

        /// <summary>
        /// Gets or sets the current user logged.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 04/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Login
        {
            get { return this.login; }
            set { this.login = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [update consecutive].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [update consecutive]; otherwise, <c>false</c>.
        /// </value>
        public bool ActualizaConsecutivo
        {
            get { return this.actualizaConsecutivo; }
            set { this.actualizaConsecutivo = value; }
        }
    }
}