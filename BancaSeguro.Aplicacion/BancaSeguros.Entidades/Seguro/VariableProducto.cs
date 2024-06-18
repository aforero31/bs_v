//-----------------------------------------------------------------------
// <copyright file="VariableProducto.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Entidades.Seguro
{
    using BancaSeguros.Entidades.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /// <summary>
    /// Product variable class
    /// </summary>
    public class VariableProducto
    {
        /// <summary>
        /// The identifier product variable
        /// </summary>
        private int idVariableProducto;

        /// <summary>
        /// The identifier insurance
        /// </summary>
        private int idSeguro;

        /// <summary>
        /// The field name
        /// </summary>
        private string nombreCampo;

        /// <summary>
        /// The identifier data type
        /// </summary>
        private int idTipoDato;

        /// <summary>
        /// The length
        /// </summary>
        private int longitud;

        /// <summary>
        /// The identifier master
        /// </summary>
        private int? idMaestra;

        /// <summary>
        /// The order
        /// </summary>
        private int orden;

        /// <summary>
        /// The state
        /// </summary>
        private bool? estado;

        /// <summary>
        /// The login
        /// </summary>
        private string login;

        /// <summary>
        /// The items master
        /// </summary>
        private IList<ItemMaestra> itemsMaestra;

        /// <summary>
        /// Gets or sets the identifier product variable.
        /// </summary>
        /// <value>
        /// The identifier product variable.
        /// </value>
        public int IdVariableProducto
        {
            get { return this.idVariableProducto; }
            set { this.idVariableProducto = value; }
        }

        /// <summary>
        /// Gets or sets the identifier insurance.
        /// </summary>
        /// <value>
        /// The identifier insurance.
        /// </value>
        public int IdSeguro
        {
            get { return this.idSeguro; }
            set { this.idSeguro = value; }
        }

        /// <summary>
        /// Gets or sets the field name.
        /// </summary>
        /// <value>
        /// The field name.
        /// </value>
        public string NombreCampo
        {
            get { return this.nombreCampo; }
            set { this.nombreCampo = value; }
        }

        /// <summary>
        /// Gets or sets the identifier data type.
        /// </summary>
        /// <value>
        /// The identifier data type.
        /// </value>
        public int IdTipoDato
        {
            get { return this.idTipoDato; }
            set { this.idTipoDato = value; }
        }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public int Longitud
        {
            get { return this.longitud; }
            set { this.longitud = value; }
        }

        /// <summary>
        /// Gets or sets the identifier master.
        /// </summary>
        /// <value>
        /// The identifier master.
        /// </value>
        public int? IdMaestra
        {
            get { return this.idMaestra; }
            set { this.idMaestra = value; }
        }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public int Orden
        {
            get { return this.orden; }
            set { this.orden = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="VariableProducto"/> is state.
        /// </summary>
        /// <value>
        ///   <c>true</c> if state; otherwise, <c>false</c>.
        /// </value>
        public bool? Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
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
        /// Gets or sets the items master.
        /// </summary>
        /// <value>
        /// The items master.
        /// </value>
        public IList<ItemMaestra> ItemsMaestra
        {
            get { return this.itemsMaestra; }
            set { this.itemsMaestra = value; }
        }
    }
}
