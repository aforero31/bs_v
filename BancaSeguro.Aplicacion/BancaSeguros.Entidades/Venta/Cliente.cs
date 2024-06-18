//-----------------------------------------------------------------------
// <copyright file="Cliente.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Venta
{
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using System;

    /// <summary>
    /// Client class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 31/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class Cliente
    {
        /// <summary>
        /// The type identification
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private TipoIdentificacion tipoIdentificacion;

        /// <summary>
        /// The identification
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string identificacion;

        /// <summary>
        /// The first name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string primerNombre;

        /// <summary>
        /// The second first name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string segundoNombre;

        /// <summary>
        /// The last name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string primerApellido;

        /// <summary>
        /// The second last name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string segundoApellido;

        /// <summary>
        /// The born date
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private DateTime fechaNacimiento;

        /// <summary>
        /// The born city
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string ciudadNacimiento;

        /// <summary>
        /// The nationality
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nacionalidad;

        /// <summary>
        /// The id gender
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idgenero;

        /// <summary>
        /// The gender
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string genero;

        /// <summary>
        /// The address
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string direccion;

        /// <summary>
        /// The resident city
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string ciudadResidencia;

        private string codigoDANE;

        /// <summary>
        /// Departamento Recidencia
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\Enrique Rivera
        ///  CreationDate: 07/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string departamentoResidencia;

        /// <summary>
        /// The telephone
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string telefono;

        /// <summary>
        /// The cell phone
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string celular;

        /// <summary>
        /// The mail
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string correo;

        /// <summary>
        /// The economic activity
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string actividadEconomica;

        /// <summary>
        /// The email
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string correoElectronico;

        /// <summary>
        /// The banking product
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private ProductoBancario productoBancario;

        /// <summary>
        /// The exception manage
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado resultado;

        private int numeroMaximoSegurosPorCliente;

        private int numeroMaximoVentaSegurosPorCuentaCliente;

        private int codigoSeguro;

        private int tipocliente;

        /// <summary>
        /// Gets or sets the type identification.
        /// </summary>
        /// <value>
        /// The type identification.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
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
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Identificacion
        {
            get { return this.identificacion; }
            set { this.identificacion = value; }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string PrimerNombre
        {
            get { return this.primerNombre; }
            set { this.primerNombre = value; }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string PrimerApellido
        {
            get { return this.primerApellido; }
            set { this.primerApellido = value; }
        }

        /// <summary>
        /// Gets or sets the second first name.
        /// </summary>
        /// <value>
        /// The second first name.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string SegundoNombre
        {
            get { return this.segundoNombre; }
            set { this.segundoNombre = value; }
        }

        /// <summary>
        /// Gets or sets the second last name.
        /// </summary>
        /// <value>
        /// The second last name.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string SegundoApellido
        {
            get { return this.segundoApellido; }
            set { this.segundoApellido = value; }
        }

        /// <summary>
        /// Gets or sets the born date.
        /// </summary>
        /// <value>
        /// The born date.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DateTime FechaNacimiento
        {
            get { return this.fechaNacimiento; }
            set { this.fechaNacimiento = value; }
        }

        /// <summary>
        /// Gets or sets the born city.
        /// </summary>
        /// <value>
        /// The born city.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CiudadNacimiento
        {
            get { return this.ciudadNacimiento; }
            set { this.ciudadNacimiento = value; }
        }

        /// <summary>
        /// Gets or sets the nationality.
        /// </summary>
        /// <value>
        /// The nationality.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// Gets or sets the identifier gender.
        /// </summary>
        /// <value>
        /// The identifier gender.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdGenero
        {
            get { return this.idgenero; }
            set { this.idgenero = value; }
        }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Genero
        {
            get { return this.genero; }
            set { this.genero = value; }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Direccion
        {
            get { return this.direccion; }
            set { this.direccion = value; }
        }

        /// <summary>
        /// Gets or sets the resident city.
        /// </summary>
        /// <value>
        /// The resident city.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CiudadResidencia
        {
            get { return this.ciudadResidencia; }
            set { this.ciudadResidencia = value; }
        }

        /// <summary>
        /// Gets or sets the resident city.
        /// </summary>
        /// <value>
        /// Departamento Recidencia.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\Enrique Rivera
        ///  CreationDate: 07/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string DepartamentoResidencia
        {
            get { return this.departamentoResidencia; }
            set { this.departamentoResidencia = value; }
        }

        /// <summary>
        /// Gets or sets the telephone.
        /// </summary>
        /// <value>
        /// The telephone.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }

        /// <summary>
        /// Gets or sets the cell phone.
        /// </summary>
        /// <value>
        /// The cell phone.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Celular
        {
            get { return this.celular; }
            set { this.celular = value; }
        }

        /// <summary>
        /// Gets or sets the economic activity.
        /// </summary>
        /// <value>
        /// The economic activity.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string ActividadEconomica
        {
            get { return this.actividadEconomica; }
            set { this.actividadEconomica = value; }
        }

        /// <summary>
        /// Gets or sets the mail.
        /// </summary>
        /// <value>
        /// The mail.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Correo
        {
            get { return this.correo; }
            set { this.correo = value; }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CorreoElectronico
        {
            get { return this.correoElectronico; }
            set { this.correoElectronico = value; }
        }

        /// <summary>
        /// Gets or sets the banking product.
        /// </summary>
        /// <value>
        /// The banking product.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ProductoBancario ProductoBancario
        {
            get { return this.productoBancario; }
            set { this.productoBancario = value; }
        }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado Resultado
        {
            get { return this.resultado; }
            set { this.resultado = value; }
        }

        public int NumeroMaximoSegurosPorCliente
        {
            get
            {
                return numeroMaximoSegurosPorCliente;
            }

            set
            {
                numeroMaximoSegurosPorCliente = value;
            }
        }

        public int NumeroMaximoVentaSegurosPorCuentaCliente
        {
            get
            {
                return numeroMaximoVentaSegurosPorCuentaCliente;
            }

            set
            {
                numeroMaximoVentaSegurosPorCuentaCliente = value;
            }
        }

        public int CodigoSeguro
        {
            get
            {
                return codigoSeguro;
            }

            set
            {
                codigoSeguro = value;
            }
        }

        public string CodigoDANE
        {
            get
            {
                return codigoDANE;
            }

            set
            {
                codigoDANE = value;
            }
        }

        /// <summary>
        /// GET o SET TipoCliente
        /// </summary>
        /// <value>
        /// Tipocliente.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\Enrique Rivera
        /// CreationDate: 07/09/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int TipoCliente
        {
            get { return this.tipocliente; }
            set { this.tipocliente = value; }
        }
    }
}