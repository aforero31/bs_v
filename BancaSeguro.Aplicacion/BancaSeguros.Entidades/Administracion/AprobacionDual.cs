//-----------------------------------------------------------------------
// <copyright file="AprobacionDual.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Entidades.Administracion
{
    using BancaSeguros.Entidades.General;
using System;

    /// <summary>
    /// Dual approval class
    /// </summary>
    public class AprobacionDual
    {
        /// <summary>
        /// The identifier dual approval
        /// </summary>
        private int idAprobacionDual;

        /// <summary>
        /// The identifier menu
        /// </summary>
        private int idMenu;

        /// <summary>
        /// The menu name
        /// </summary>
        private string nombreMenu;

        /// <summary>
        /// The state
        /// </summary>
        private string estado;

        /// <summary>
        /// The action
        /// </summary>
        private string accion;

        /// <summary>
        /// The send user
        /// </summary>
        private string usuarioEnvia;

        /// <summary>
        /// The approval user
        /// </summary>
        private string usuarioAprueba;

        /// <summary>
        /// The request date
        /// </summary>
        private DateTime fechaSolicitud;

        /// <summary>
        /// The approval date
        /// </summary>
        private DateTime fechaAprobacion;

        /// <summary>
        /// The object name
        /// </summary>
        private string nombreObjeto;

        /// <summary>
        /// The data object
        /// </summary>
        private string datosObjeto;

        /// <summary>
        /// The description
        /// </summary>
        private string descripcion;

        /// <summary>
        /// The initial request date
        /// </summary>
        private DateTime? fechaSolicitudInicial;

        /// <summary>
        /// The final request date
        /// </summary>
        private DateTime? fechaSolicitudFinal;

        /// <summary>
        /// The data object actual
        /// </summary>
        private string datosObjetoActual;

        /// <summary>
        /// The result
        /// </summary>
        private Resultado resultado;

        /// <summary>
        /// Gets or sets identifier dual approval.
        /// </summary>
        /// <value>
        /// The identifier dual approval.
        /// </value>
        public int IdAprobacionDual
        {
            get { return this.idAprobacionDual; }
            set { this.idAprobacionDual = value; }
        }

        /// <summary>
        /// Gets or sets the identifier menu.
        /// </summary>
        /// <value>
        /// The identifier menu.
        /// </value>
        public int IdMenu
        {
            get { return this.idMenu; }
            set { this.idMenu = value; }
        }

        /// <summary>
        /// Gets or sets the menu name.
        /// </summary>
        /// <value>
        /// The menu name.
        /// </value>
        public string NombreMenu
        {
            get { return this.nombreMenu; }
            set { this.nombreMenu = value; }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public string Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public string Accion
        {
            get { return this.accion; }
            set { this.accion = value; }
        }

        /// <summary>
        /// Gets or sets the send user.
        /// </summary>
        /// <value>
        /// The send user.
        /// </value>
        public string UsuarioEnvia
        {
            get { return this.usuarioEnvia; }
            set { this.usuarioEnvia = value; }
        }

        /// <summary>
        /// Gets or sets the approval user.
        /// </summary>
        /// <value>
        /// The approval user.
        /// </value>
        public string UsuarioAprueba
        {
            get { return this.usuarioAprueba; }
            set { this.usuarioAprueba = value; }
        }

        /// <summary>
        /// Gets or sets the request date.
        /// </summary>
        /// <value>
        /// The request date.
        /// </value>
        public DateTime FechaSolicitud
        {
            get { return this.fechaSolicitud; }
            set { this.fechaSolicitud = value; }
        }

        /// <summary>
        /// Gets or sets the approval date.
        /// </summary>
        /// <value>
        /// The approval date.
        /// </value>
        public DateTime FechaAprobacion
        {
            get { return this.fechaAprobacion; }
            set { this.fechaAprobacion = value; }
        }

        /// <summary>
        /// Gets or sets the object name.
        /// </summary>
        /// <value>
        /// The object name.
        /// </value>
        public string NombreObjeto
        {
            get { return this.nombreObjeto; }
            set { this.nombreObjeto = value; }
        }

        /// <summary>
        /// Gets or sets the data object.
        /// </summary>
        /// <value>
        /// The data object.
        /// </value>
        public string DatosObjeto
        {
            get { return this.datosObjeto; }
            set { this.datosObjeto = value; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }

        /// <summary>
        /// Gets or sets the initial request date.
        /// </summary>
        /// <value>
        /// The initial request date.
        /// </value>
        public DateTime? FechaSolicitudInicial
        {
            get { return this.fechaSolicitudInicial; }
            set { this.fechaSolicitudInicial = value; }
        }

        /// <summary>
        /// Gets or sets the final request date.
        /// </summary>
        /// <value>
        /// The final request date.
        /// </value>
        public DateTime? FechaSolicitudFinal
        {
            get { return this.fechaSolicitudFinal; }
            set { this.fechaSolicitudFinal = value; }
        }

        /// <summary>
        /// Gets or sets the data actual object.
        /// </summary>
        /// <value>
        /// The actual object data.
        /// </value>
        public string DatosObjetoActual 
        {
            get { return this.datosObjetoActual; }
            set { this.datosObjetoActual = value; }
        }

        /// <summary>
        /// Gets or sets the resultado.
        /// </summary>
        /// <value>
        /// The resultado.
        /// </value>
        public Resultado Resultado
        {
            get { return this.resultado; }
            set { this.resultado = value; }
        }
    }
}
