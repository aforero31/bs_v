//-----------------------------------------------------------------------
// <copyright file="VariableVenta.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Entidades.Venta
{
    /// <summary>
    /// Sale variable class
    /// </summary>
    public class VariableVenta
    {
        /// <summary>
        /// The identifier sale variable
        /// </summary>
        private int idVariableVenta;

        /// <summary>
        /// The identifier sale
        /// </summary>
        private int idVenta;

        /// <summary>
        /// The consecutive policy
        /// </summary>
        private string consecutivoPoliza;

        /// <summary>
        /// The identifier product variable
        /// </summary>
        private int idVariableProducto;

        /// <summary>
        /// The order
        /// </summary>
        private int orden;

        /// <summary>
        /// The value
        /// </summary>
        private string valor;

        /// <summary>
        /// The master value indicator
        /// </summary>
        private bool valorMaestra;

        /// <summary>
        /// The value name
        /// </summary>
        private string nombreValor;

        /// <summary>
        /// The login
        /// </summary>
        private string login;

        /// <summary>
        /// Gets or sets the identifier sale variable.
        /// </summary>
        /// <value>
        /// The identifier sale variable.
        /// </value>
        public int IdVariableVenta
        {
            get { return this.idVariableVenta; }
            set { this.idVariableVenta = value; }
        }

        /// <summary>
        /// Gets or sets the identifier sale.
        /// </summary>
        /// <value>
        /// The identifier sale.
        /// </value>
        public int IdVenta
        {
            get { return this.idVenta; }
            set { this.idVenta = value; }
        }

        /// <summary>
        /// Gets or sets the policy consecutive.
        /// </summary>
        /// <value>
        /// The policy consecutive.
        /// </value>
        public string ConsecutivoPoliza
        {
            get { return this.consecutivoPoliza; }
            set { this.consecutivoPoliza = value; }
        }

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
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [master value].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [master value]; otherwise, <c>false</c>.
        /// </value>
        public bool ValorMaestra
        {
            get { return this.valorMaestra; }
            set { this.valorMaestra = value; }
        }

        /// <summary>
        /// Gets or sets the value name.
        /// </summary>
        /// <value>
        /// The value name.
        /// </value>
        public string NombreValor
        {
            get { return this.nombreValor; }
            set { this.nombreValor = value; }
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
