//-----------------------------------------------------------------------
// <copyright file="EncabezadoPolizaDocumento.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Seguro
{
    using System;

    /// <summary>
    /// Entity header policy document
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 03/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class EncabezadoPolizaDocumento
    {
        /// <summary>
        /// The date request
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string fechaSolicitud;

        /// <summary>
        /// The first name customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string primerNombreCliente;

        /// <summary>
        /// The second name customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string segundoNombreCliente;

        /// <summary>
        /// The first last name customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string primerApellidoCliente;

        /// <summary>
        /// The second last name customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string segundoApellidoCliente;

        /// <summary>
        /// The number identification customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string numeroIdentificacionCliente;

        /// <summary>
        /// The type identification abbreviation customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string tipoIdentificacionAbreviadoCliente;

        /// <summary>
        /// The type identification description customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string tipoIdentificacionDescripcionCliente;

        /// <summary>
        /// The date birth customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string fechaNacimientoCliente;

        /// <summary>
        /// The city birth customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string ciudadNacimientoCliente;

        /// <summary>
        /// The gender customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string generoCliente;

        /// <summary>
        /// The economic client activity
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string actividadEconomicaCliente;

        /// <summary>
        /// The address customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string direccionCliente;

        /// <summary>
        /// The telephone customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string telefonoCliente;

        /// <summary>
        /// The city residence customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string ciudadResidenciaCliente;

        /// <summary>
        /// The department customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string departamenoCliente;

        /// <summary>
        /// The nationality customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nacionalidadCliente;

        /// <summary>
        /// The cell phone customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string celularCliente;

        /// <summary>
        /// The type account customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string tipoCuentaCliente;

        /// <summary>
        /// The number account customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string numeroCuentaCliente;

        /// <summary>
        /// The date expiration card customer
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string fechaVencimientoTarjetaCliente;

        /// <summary>
        /// The consecutive policy
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string consecutivoPoliza;

        /// <summary>
        /// The value policy without iva
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string valorPolizaSinIva;

        /// <summary>
        /// The value iva policy
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string valorIvaPoliza;

        /// <summary>
        /// The value prime with iva
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string valorPrimaConIva;

        /// <summary>
        /// The periodicity
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string periodicidad;

        /// <summary>
        /// The plan policy
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string planPoliza;

        /// <summary>
        /// The plan policy
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombreOficina;

        /// <summary>
        /// The plan policy
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string ciudadOficina;

        /// <summary>
        /// The plan policy
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string identificacionAsesor;

        /// <summary>
        /// The plan policy
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombreAsesor;

        /// <summary>
        /// Gets or sets the date request.
        /// </summary>
        /// <value>
        /// The date request.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string FechaSolicitud
        {
            get { return this.fechaSolicitud; }
            set { this.fechaSolicitud = value; }
        }

        /// <summary>
        /// Gets or sets the first name customer.
        /// </summary>
        /// <value>
        /// The first name customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string PrimerNombreCliente
        {
            get { return this.primerNombreCliente; }
            set { this.primerNombreCliente = value; }
        }

        /// <summary>
        /// Gets or sets the second name customer.
        /// </summary>
        /// <value>
        /// The second name customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string SegundoNombreCliente
        {
            get { return this.segundoNombreCliente; }
            set { this.segundoNombreCliente = value; }
        }

        /// <summary>
        /// Gets or sets the first last name customer.
        /// </summary>
        /// <value>
        /// The first last name customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string PrimerApellidoCliente
        {
            get { return this.primerApellidoCliente; }
            set { this.primerApellidoCliente = value; }
        }

        /// <summary>
        /// Gets or sets the second last name customer.
        /// </summary>
        /// <value>
        /// The second last name customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string SegundoApellidoCliente
        {
            get { return this.segundoApellidoCliente; }
            set { this.segundoApellidoCliente = value; }
        }

        /// <summary>
        /// Gets or sets the number identification customer.
        /// </summary>
        /// <value>
        /// The number identification customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NumeroIdentificacionCliente
        {
            get { return this.numeroIdentificacionCliente; }
            set { this.numeroIdentificacionCliente = value; }
        }

        /// <summary>
        /// Gets or sets the type identification abbreviation customer.
        /// </summary>
        /// <value>
        /// The type identification abbreviation customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string TipoIdentificacionAbreviadoCliente
        {
            get { return this.tipoIdentificacionAbreviadoCliente; }
            set { this.tipoIdentificacionAbreviadoCliente = value; }
        }

        /// <summary>
        /// Gets or sets the type identification description customer.
        /// </summary>
        /// <value>
        /// The type identification description customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string TipoIdentificacionDescripcionCliente
        {
            get { return this.tipoIdentificacionDescripcionCliente; }
            set { this.tipoIdentificacionDescripcionCliente = value; }
        }

        /// <summary>
        /// Gets or sets the date birth customer.
        /// </summary>
        /// <value>
        /// The date birth customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string FechaNacimientoCliente
        {
            get { return this.fechaNacimientoCliente; }
            set { this.fechaNacimientoCliente = value; }
        }

        /// <summary>
        /// Gets or sets the city birth customer.
        /// </summary>
        /// <value>
        /// The city birth customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CiudadNacimientoCliente
        {
            get { return this.ciudadNacimientoCliente; }
            set { this.ciudadNacimientoCliente = value; }
        }

        /// <summary>
        /// Gets or sets the gender customer.
        /// </summary>
        /// <value>
        /// The gender customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string GeneroCliente
        {
            get { return this.generoCliente; }
            set { this.generoCliente = value; }
        }

        /// <summary>
        /// Gets or sets economic client activity.
        /// </summary>
        /// <value>
        /// The economic client activity.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string ActividadEconomicaCliente 
        { 
            get { return this.actividadEconomicaCliente; } 
            set { this.actividadEconomicaCliente = value; } 
        }

        /// <summary>
        /// Gets or sets the address customer.
        /// </summary>
        /// <value>
        /// The address customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string DireccionCliente
        {
            get { return this.direccionCliente; }
            set { this.direccionCliente = value; }
        }

        /// <summary>
        /// Gets or sets the telephone customer.
        /// </summary>
        /// <value>
        /// The telephone customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string TelefonoCliente
        {
            get { return this.telefonoCliente; }
            set { this.telefonoCliente = value; }
        }

        /// <summary>
        /// Gets or sets the city residence customer.
        /// </summary>
        /// <value>
        /// The city residence customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CiudadResidenciaCliente
        {
            get { return this.ciudadResidenciaCliente; }
            set { this.ciudadResidenciaCliente = value; }
        }

        /// <summary>
        /// Gets or sets the department customer.
        /// </summary>
        /// <value>
        /// The department customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string DepartamenoCliente
        {
            get { return this.departamenoCliente; }
            set { this.departamenoCliente = value; }
        }

        /// <summary>
        /// Gets or sets the nationality customer.
        /// </summary>
        /// <value>
        /// The nationality customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NacionalidadCliente
        {
            get { return this.nacionalidadCliente; }
            set { this.nacionalidadCliente = value; }
        }

        /// <summary>
        /// Gets or sets the cell phone customer.
        /// </summary>
        /// <value>
        /// The cell phone customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CelularCliente
        {
            get { return this.celularCliente; }
            set { this.celularCliente = value; }
        }

        /// <summary>
        /// Gets or sets the type account customer.
        /// </summary>
        /// <value>
        /// The type account customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string TipoCuentaCliente
        {
            get { return this.tipoCuentaCliente; }
            set { this.tipoCuentaCliente = value; }
        }

        /// <summary>
        /// Gets or sets the number account customer.
        /// </summary>
        /// <value>
        /// The number account customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NumeroCuentaCliente
        {
            get { return this.numeroCuentaCliente; }
            set { this.numeroCuentaCliente = value; }
        }

        /// <summary>
        /// Gets or sets the date expiration card customer.
        /// </summary>
        /// <value>
        /// The date expiration card customer.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string FechaVencimientoTarjetaCliente
        {
            get { return this.fechaVencimientoTarjetaCliente; }
            set { this.fechaVencimientoTarjetaCliente = value; }
        }

        /// <summary>
        /// Gets or sets the consecutive policy.
        /// </summary>
        /// <value>
        /// The consecutive policy.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string ConsecutivoPoliza
        {
            get { return this.consecutivoPoliza; }
            set { this.consecutivoPoliza = value; }
        }

        /// <summary>
        /// Gets or sets the value policy without iva.
        /// </summary>
        /// <value>
        /// The value policy without iva.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string ValorPolizaSinIva
        {
            get { return this.valorPolizaSinIva; }
            set { this.valorPolizaSinIva = value; }
        }

        /// <summary>
        /// Gets or sets the value iva policy.
        /// </summary>
        /// <value>
        /// The value iva policy.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string ValorIvaPoliza
        {
            get { return this.valorIvaPoliza; }
            set { this.valorIvaPoliza = value; }
        }

        /// <summary>
        /// Gets or sets the value prima with iva.
        /// </summary>
        /// <value>
        /// The value prima with iva.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string ValorPrimaConIva
        {
            get { return this.valorPrimaConIva; }
            set { this.valorPrimaConIva = value; }
        }

        /// <summary>
        /// Gets or sets the periodicity.
        /// </summary>
        /// <value>
        /// The periodicity.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Periodicidad
        {
            get { return this.periodicidad; }
            set { this.periodicidad = value; }
        }

        /// <summary>
        /// Gets or sets the plan policy.
        /// </summary>
        /// <value>
        /// The plan policy.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string PlanPoliza
        {
            get { return this.planPoliza; }
            set { this.planPoliza = value; }
        }


        public string NombreOficina
        {
            get { return this.nombreOficina; }
            set { this.nombreOficina = value; }
        }

        public string CiudadOficina
        {
            get { return this.ciudadOficina; }
            set { this.ciudadOficina = value; }
        }

        public string IdentificacionAsesor
        {
            get { return this.identificacionAsesor; }
            set { this.identificacionAsesor = value; }
        }

        public string NombreAsesor
        {
            get { return this.nombreAsesor; }
            set { this.nombreAsesor = value; }
        }
    }
}
