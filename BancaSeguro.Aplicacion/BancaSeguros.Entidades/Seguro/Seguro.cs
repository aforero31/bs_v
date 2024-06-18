//-----------------------------------------------------------------------
// <copyright file="Seguro.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Seguro
{
    using System;
   
    /// <summary>
    /// Represents an insurance to BANCASEGUROS
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 12/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class Seguro
    {
        /// <summary>
        /// The identifier insurance
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idSeguro;

        /// <summary>
        /// The name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombre;

        /// <summary>
        /// The description
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string descripcion;

        /// <summary>
        /// The code
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string codigo;

        /// <summary>
        /// The spouse
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool conyuge;

        /// <summary>
        /// The beneficiary
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool beneficiario;

        /// <summary>
        /// The min woman age
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int edadMinimaMujer;

        /// <summary>
        /// The min woman age
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int edadMaximaMujer;

        /// <summary>
        /// The min man age
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int edadMinimaHombre;

        /// <summary>
        /// The max man age
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int edadMaximaHombre;

        /// <summary>
        /// The insurance
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Aseguradora aseguradora;

        /// <summary>
        /// The active
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool activo;

        /// <summary>
        /// The max spouse age
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int edadMaximaConyuge;

        /// <summary>
        /// The min spouse age
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int edadMinimaConyuge;

        /// <summary>
        /// The plan
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Plan plan;

        /// <summary>
        /// The policy state
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private EstadoPoliza estadoPoliza;

        /// <summary>
        /// The rejection cause
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private CausalRechazo causalRechazo;

        /// <summary>
        /// The state name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombreEstado;

        /// <summary>
        /// The max number sold by client account.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int numeroMaximoVentaSegurosPorCuentaCliente;

        /// <summary>
        /// The login
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string login;

        /// <summary>
        /// Gets or sets the identifier insurance.
        /// </summary>
        /// <value>
        /// The identifier insurance.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdSeguro
        {
            get { return this.idSeguro; }
            set { this.idSeguro = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Gets or sets the StateName.
        /// </summary>
        /// <value>
        /// The StateName.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NombreEstado
        {
            get { return this.nombreEstado; }
            set { this.nombreEstado = value; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Seguro"/> is spouse.
        /// </summary>
        /// <value>
        ///   <c>true</c> if spouse; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Conyuge
        {
            get { return this.conyuge; }
            set { this.conyuge = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Seguro"/> is beneficiary.
        /// </summary>
        /// <value>
        ///   <c>true</c> if beneficiary; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Beneficiario
        {
            get { return this.beneficiario; }
            set { this.beneficiario = value; }
        }

        /// <summary>
        /// Gets or sets the min age woman.
        /// </summary>
        /// <value>
        /// The min age woman.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int EdadMinimaMujer
        {
            get { return this.edadMinimaMujer; }
            set { this.edadMinimaMujer = value; }
        }

        /// <summary>
        /// Gets or sets the max age woman.
        /// </summary>
        /// <value>
        /// The max age woman.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int EdadMaximaMujer
        {
            get { return this.edadMaximaMujer; }
            set { this.edadMaximaMujer = value; }
        }

        /// <summary>
        /// Gets or sets the min age man.
        /// </summary>
        /// <value>
        /// The min age man.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int EdadMinimaHombre
        {
            get { return this.edadMinimaHombre; }
            set { this.edadMinimaHombre = value; }
        }

        /// <summary>
        /// Gets or sets the max age man.
        /// </summary>
        /// <value>
        /// the max age man.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int EdadMaximaHombre
        {
            get { return this.edadMaximaHombre; }
            set { this.edadMaximaHombre = value; }
        }

        /// <summary>
        /// Gets or sets the insurance.
        /// </summary>
        /// <value>
        /// The insurance.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Aseguradora Aseguradora
        {
            get { return this.aseguradora; }
            set { this.aseguradora = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Seguro"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
        }
        
        /// <summary>
        /// Gets or sets  max age allowed.
        /// </summary>
        /// <value>
        ///  Max age allowed spouse.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 09/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int EdadMaximaConyuge 
        {
            get { return this.edadMaximaConyuge; }
            set { this.edadMaximaConyuge = value; }
        }

        /// <summary>
        /// Gets or sets the min age spouse.
        /// </summary>
        /// <value>
        /// min age spouse.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 09/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int EdadMinimaConyuge
        {
            get { return this.edadMinimaConyuge; }
            set { this.edadMinimaConyuge = value; }
        }

        /// <summary>
        /// Gets or sets the plan.
        /// </summary>
        /// <value>
        /// The plan.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Plan Plan
        {
            get { return this.plan; }
            set { this.plan = value; }
        }

        /// <summary>
        /// Gets or sets the insurance state.
        /// </summary>
        /// <value>
        /// The insurance state.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public EstadoPoliza EstadoPoliza
        {
            get { return this.estadoPoliza; }
            set { this.estadoPoliza = value; }
        }

        /// <summary>
        /// Gets or sets the rejection cause.
        /// </summary>
        /// <value>
        /// The rejection cause.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public CausalRechazo CausalRechazo
        {
            get { return this.causalRechazo; }
            set { this.causalRechazo = value; }
        }

        /// <summary>
        /// Gets or sets the identifier insurance.
        /// </summary>
        /// <value>
        /// The identifier insurance.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdAseguradora { get; set; }

        /// <summary>
        /// Gets or sets the identifier sold channel.
        /// </summary>
        /// <value>
        /// The identifier sold channel.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdCanalVenta { get; set; }

        /// <summary>
        /// Gets or sets the max beneficiaries.
        /// </summary>
        /// <value>
        /// The max beneficiaries.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int MaximoBeneficiarios { get; set; }

        /// <summary>
        /// Gets or sets the max number insurances by client.
        /// </summary>
        /// <value>
        /// The max number insurances by client.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int NumeroMaximoSegurosPorCliente { get; set; }

        /// <summary>
        /// Gets or sets the max number sold by client account.
        /// </summary>
        /// <value>
        /// The max number sold by client account.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int NumeroMaximoVentaSegurosPorCuentaCliente
        {
            get { return this.numeroMaximoVentaSegurosPorCuentaCliente; }
            set { this.numeroMaximoVentaSegurosPorCuentaCliente = value; }
        }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        /// <value>
        /// The login.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Login
        {
            get { return this.login; }
            set { this.login = value; }
        }
    }
}
