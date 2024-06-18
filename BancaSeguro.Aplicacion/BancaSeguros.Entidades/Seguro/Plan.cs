//-----------------------------------------------------------------------
// <copyright file="Plan.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Seguro
{
    using System;
    using BancaSeguros.Entidades.Catalogo;

    /// <summary>
    /// Plan Entity
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 03/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class Plan
    {
        /// <summary>
        /// The identifier plan
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idPlan;

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
        /// The value
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private decimal valor;

        /// <summary>
        /// The money value
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string valorMoneda;

        /// <summary>
        /// The plan name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombrePlan;

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
        /// The periodicity
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Periodicidad periodicidad;

        /// <summary>
        /// The IVA value
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private decimal valorIVA;

        /// <summary>
        /// The value without IVA
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private decimal valorSinIVA;

        /// <summary>
        /// The identifier plan code
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int codigoPlan;

        /// <summary>
        /// The identifier periodicity
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idPeriodicidad;

        /// <summary>
        /// The periodicity name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombrePeriodicidad;

        /// <summary>
        /// The code
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int codigoConvenio;

        /// <summary>
        /// The active
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 11/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool activo;

        /// <summary>
        /// Gets or sets the identifier plan.
        /// </summary>
        /// <value>
        /// The identifier plan.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdPlan
        {
            get { return this.idPlan; }
            set { this.idPlan = value; }
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
        public int IdSeguro
        {
            get { return this.idSeguro; }
            set { this.idSeguro = value; }
        }

        /// <summary>
        /// Gets or sets the identifier code plan.
        /// </summary>
        /// <value>
        /// The identifier code plan.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int CodigoPlan
        {
            get { return this.codigoPlan; }
            set { this.codigoPlan = value; }
        }

        /// <summary>
        /// Gets or sets the valor.
        /// </summary>
        /// <value>
        /// The valor.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public decimal Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }

        /// <summary>
        /// Gets or sets the money value.
        /// </summary>
        /// <value>
        /// The money value.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string ValorMoneda
        {
            get { return this.valorMoneda; }
            set { this.valorMoneda = value; }
        }

        /// <summary>
        /// Gets or sets the plan name.
        /// </summary>
        /// <value>
        /// The plan name.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NombrePlan
        {
            get { return this.nombrePlan; }
            set { this.nombrePlan = value; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }

        /// <summary>
        /// Gets or sets the periodicity.
        /// </summary>
        /// <value>
        /// The periodicity.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Periodicidad Periodicidad
        {
            get { return this.periodicidad; }
            set { this.periodicidad = value; }
        }

        /// <summary>
        /// Gets or sets the valor iva.
        /// </summary>
        /// <value>
        /// The valor iva.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public decimal ValorIVA
        {
            get { return this.valorIVA; }
            set { this.valorIVA = value; }
        }

        /// <summary>
        /// Gets or sets the valor sin iva.
        /// </summary>
        /// <value>
        /// The valor sin iva.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public decimal ValorSinIVA
        {
            get { return this.valorSinIVA; }
            set { this.valorSinIVA = value; }
        }

        /// <summary>
        /// Gets or sets the identifier periodicity.
        /// </summary>
        /// <value>
        /// The identifier periodicity.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdPeriodicidad
        {
            get { return this.idPeriodicidad; }
            set { this.idPeriodicidad = value; }
        }

        /// <summary>
        /// Gets or sets the name periodicity.
        /// </summary>
        /// <value>
        /// The name periodicity.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NombrePeriodicidad
        {
            get { return this.nombrePeriodicidad; }
            set { this.nombrePeriodicidad = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Plan"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 11/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Activo
        {
            get
            {
                return activo;
            }

            set
            {
                activo = value;
            }
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int CodigoConvenio
        {
            get
            {
                return codigoConvenio;
            }

            set
            {
                codigoConvenio = value;
            }
        }

        public string Login { get; set; }
    }
}
