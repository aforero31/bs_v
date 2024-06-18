//-----------------------------------------------------------------------
// <copyright file="BeneficiariosPolizaDocumento.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Seguro
{
    /// <summary>
    /// Entity Policy document
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 28/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public class BeneficiariosPolizaDocumento
    {
        /// <summary>
        /// The name complete beneficiary
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombreCompletoBeneficiario;

        /// <summary>
        /// The name beneficiary
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombreBeneficiario;

        /// <summary>
        /// The last name beneficiary
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string apellidoBeneficiario;

        /// <summary>
        /// The type number identification beneficiary
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string tipoNumeroIdentificacionBeneficiario;

        /// <summary>
        /// The type identification abbreviation beneficiary
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string tipoIdentificacionAbreviaturaBeneficiario;

        /// <summary>
        /// The number identification beneficiary
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string numeroIdentificacionBeneficiario;

        /// <summary>
        /// The percent participation
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string porcentajeParticipacion;

        /// <summary>
        /// Gets or sets the name complete beneficiary.
        /// </summary>
        /// <value>
        /// The name complete beneficiary.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NombreCompletoBeneficiario
        {
            get { return this.nombreCompletoBeneficiario; }
            set { this.nombreCompletoBeneficiario = value; }
        }

        /// <summary>
        /// Gets or sets the name beneficiary.
        /// </summary>
        /// <value>
        /// The name beneficiary.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NombreBeneficiario
        {
            get { return this.nombreBeneficiario; }
            set { this.nombreBeneficiario = value; }
        }

        /// <summary>
        /// Gets or sets the last name beneficiary.
        /// </summary>
        /// <value>
        /// The last name beneficiary.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string ApellidoBeneficiario
        {
            get { return this.apellidoBeneficiario; }
            set { this.apellidoBeneficiario = value; }
        }

        /// <summary>
        /// Gets or sets the type number identification beneficiary.
        /// </summary>
        /// <value>
        /// The type number identification beneficiary.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string TipoNumeroIdentificacionBeneficiario
        {
            get { return this.tipoNumeroIdentificacionBeneficiario; }
            set { this.tipoNumeroIdentificacionBeneficiario = value; }
        }

        /// <summary>
        /// Gets or sets the type identification abbreviation beneficiary.
        /// </summary>
        /// <value>
        /// The type identification abbreviation beneficiary.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string TipoIdentificacionAbreviaturaBeneficiario
        {
            get { return this.tipoIdentificacionAbreviaturaBeneficiario; }
            set { this.tipoIdentificacionAbreviaturaBeneficiario = value; }
        }

        /// <summary>
        /// Gets or sets the number identification beneficiary.
        /// </summary>
        /// <value>
        /// The number identification beneficiary.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NumeroIdentificacionBeneficiario
        {
            get { return this.numeroIdentificacionBeneficiario; }
            set { this.numeroIdentificacionBeneficiario = value; }
        }

        /// <summary>
        /// Gets or sets the percent participation.
        /// </summary>
        /// <value>
        /// The percent participation.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string PorcentajeParticipacion
        {
            get { return this.porcentajeParticipacion; }
            set { this.porcentajeParticipacion = value; }
        }
    }
}
