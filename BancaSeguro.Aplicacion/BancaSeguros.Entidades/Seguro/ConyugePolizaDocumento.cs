//-----------------------------------------------------------------------
// <copyright file="ConyugePolizaDocumento.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Seguro
{
    using System;

    /// <summary>
    /// Entity policy document spouse
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 03/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class ConyugePolizaDocumento
    {
        /// <summary>
        /// The first name spouse
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string primerNombreConyuge;

        /// <summary>
        /// The second name spouse
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string segundoNombreConyuge;

        /// <summary>
        /// The first last name spouse
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string primerApellidoConyuge;

        /// <summary>
        /// The second last name spouse
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string segundoApellidoConyuge;

        /// <summary>
        /// The type identification abbreviation spouse
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string tipoIdentificacionAbreviaturaConyuge;

        /// <summary>
        /// The number identification spouse
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string numeroIdentificacionConyuge;

        /// <summary>
        /// The date birth spouse
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string fechaNacimientoConyuge;

        /// <summary>
        /// The city birth spouse
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string ciudadNacimientoConyuge;

        /// <summary>
        /// The gender spouse
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string generoConyuge;

        /// <summary>
        /// The address spouse
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string direccionConyuge;

        /// <summary>
        /// The city residence spouse
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string ciudadResidenciaConyuge;

        /// <summary>
        /// The telephone spouse
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string telefonoConyuge;

        /// <summary>
        /// Gets or sets the first name spouse.
        /// </summary>
        /// <value>
        /// The first name spouse.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string PrimerNombreConyuge
        {
            get { return this.primerNombreConyuge; }
            set { this.primerNombreConyuge = value; }
        }

        /// <summary>
        /// Gets or sets the second name spouse.
        /// </summary>
        /// <value>
        /// The second name spouse.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string SegundoNombreConyuge
        {
            get { return this.segundoNombreConyuge; }
            set { this.segundoNombreConyuge = value; }
        }

        /// <summary>
        /// Gets or sets the first last name spouse.
        /// </summary>
        /// <value>
        /// The first last name spouse.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string PrimerApellidoConyuge
        {
            get { return this.primerApellidoConyuge; }
            set { this.primerApellidoConyuge = value; }
        }

        /// <summary>
        /// Gets or sets the second last name spouse.
        /// </summary>
        /// <value>
        /// The second last name spouse.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string SegundoApellidoConyuge
        {
            get { return this.segundoApellidoConyuge; }
            set { this.segundoApellidoConyuge = value; }
        }

        /// <summary>
        /// Gets or sets the type identification abbreviation spouse.
        /// </summary>
        /// <value>
        /// The type identification abbreviation spouse.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string TipoIdentificacionAbreviaturaConyuge
        {
            get { return this.tipoIdentificacionAbreviaturaConyuge; }
            set { this.tipoIdentificacionAbreviaturaConyuge = value; }
        }

        /// <summary>
        /// Gets or sets the number identification spouse.
        /// </summary>
        /// <value>
        /// The number identification spouse.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NumeroIdentificacionConyuge
        {
            get { return this.numeroIdentificacionConyuge; }
            set { this.numeroIdentificacionConyuge = value; }
        }

        /// <summary>
        /// Gets or sets the date birth spouse.
        /// </summary>
        /// <value>
        /// The date birth spouse.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string FechaNacimientoConyuge
        {
            get { return this.fechaNacimientoConyuge; }
            set { this.fechaNacimientoConyuge = value; }
        }

        /// <summary>
        /// Gets or sets the city birth spouse.
        /// </summary>
        /// <value>
        /// The city birth spouse.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CiudadNacimientoConyuge
        {
            get { return this.ciudadNacimientoConyuge; }
            set { this.ciudadNacimientoConyuge = value; }
        }

        /// <summary>
        /// Gets or sets the gender spouse.
        /// </summary>
        /// <value>
        /// The gender spouse.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string GeneroConyuge
        {
            get { return this.generoConyuge; }
            set { this.generoConyuge = value; }
        }

        /// <summary>
        /// Gets or sets the address spouse.
        /// </summary>
        /// <value>
        /// The address spouse.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string DireccionConyuge
        {
            get { return this.direccionConyuge; }
            set { this.direccionConyuge = value; }
        }

        /// <summary>
        /// Gets or sets the city residence spouse.
        /// </summary>
        /// <value>
        /// The city residence spouse.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CiudadResidenciaConyuge
        {
            get { return this.ciudadResidenciaConyuge; }
            set { this.ciudadResidenciaConyuge = value; }
        }

        /// <summary>
        /// Gets or sets the telephone spouse.
        /// </summary>
        /// <value>
        /// The telephone spouse.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string TelefonoConyuge
        {
            get { return this.telefonoConyuge; }
            set { this.telefonoConyuge = value; }
        }
    }
}
