//-----------------------------------------------------------------------
// <copyright file="Usuario.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BAC.EntidadesSeguridad
{
    using System;
    using System.Collections.Generic;

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
    public class Usuario
    {
        /// <summary>
        /// The identifier user
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idUsuario;

        /// <summary>
        /// The login
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string login;

        /// <summary>
        /// The password
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string contrasena;

        /// <summary>
        /// The names
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombres;

        /// <summary>
        /// The last name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string apellidos;

        /// <summary>
        /// The identification
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int identificacion;

        /// <summary>
        /// The email
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string email;

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
        /// The role
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private List<Rol> roles;

        /// <summary>
        /// The team
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private List<GrupoBAC> grupo;

        /// <summary>
        /// The office
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Oficina oficina;

        /// <summary>
        /// The token
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 23/06/2020
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string token;

        /// <summary>
        /// The expiracion
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 24/06/2020
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private long expiracion;

        /// <summary>
        /// The expiracion
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 24/06/2020
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private DateTime fechaExpiracionToken;

        /// <summary>
        /// Gets or sets the identifier user.
        /// </summary>
        /// <value>
        /// The identifier user.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdUsuario
        {
            get { return this.idUsuario; }
            set { this.idUsuario = value; }
        }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        /// <value>
        /// The login.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Login
        {
            get { return this.login; }
            set { this.login = value; }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Contrasena
        {
            get { return this.contrasena; }
            set { this.contrasena = value; }
        }

        /// <summary>
        /// Gets or sets the names.
        /// </summary>
        /// <value>
        /// The names.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Nombres
        {
            get { return this.nombres; }
            set { this.nombres = value; }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Apellidos
        {
            get { return this.apellidos; }
            set { this.apellidos = value; }
        }

        /// <summary>
        /// Gets or sets the identification.
        /// </summary>
        /// <value>
        /// The identification.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int Identificacion
        {
            get { return this.identificacion; }
            set { this.identificacion = value; }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Usuario"/> is active.
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

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Rol> Roles
        {
            get { return this.roles; }
            set { this.roles = value; }
        }

        /// <summary>
        /// Gets or sets the team.
        /// </summary>
        /// <value>
        /// The team.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<GrupoBAC> Grupo
        {
            get { return this.grupo; }
            set { this.grupo = value; }
        }

        /// <summary>
        /// Gets or sets the office.
        /// </summary>
        /// <value>
        /// The office.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Oficina Oficina
        {
            get { return this.oficina; }
            set { this.oficina = value; }
        }

        /// <summary>
        /// The token
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 23/06/2020
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Token
        {
            get { return this.token; }
            set { this.token = value; }
        }

        /// <summary>
        /// The expiration
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 24/06/2020
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public long Expiracion
        {
            get { return this.expiracion; }
            set { this.expiracion = value; }
        }

        /// <summary>
        /// The expiration
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCHACON
        /// CreationDate: 24/06/2020
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DateTime FechaExpiracionToken
        {
            get { return this.fechaExpiracionToken; }
            set { this.fechaExpiracionToken = value; }
        }

    }
}
