//-----------------------------------------------------------------------
// <copyright file="DatosPolizaDocumento.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Seguro
{
    using BancaSeguros.Entidades.Venta;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Entity data policy document
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 03/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class DatosPolizaDocumento
    {
        /// <summary>
        /// Gets or sets the header policy.
        /// </summary>
        /// <value>
        /// The header policy.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public EncabezadoPolizaDocumento EncabezadoPoliza { get; set; }

        /// <summary>
        /// Gets or sets the spouse policy document.
        /// </summary>
        /// <value>
        /// The spouse policy document.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ConyugePolizaDocumento ConyugePolizaDocumento { get; set; }

        /// <summary>
        /// Gets or sets the beneficiary policy document.
        /// </summary>
        /// <value>
        /// The beneficiary policy document.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<BeneficiariosPolizaDocumento> BeneficiariosPolizaDocumento { get; set; }



        /// <summary>
        /// Gets or sets the dinamico poliza documento.
        /// </summary>
        /// <value>
        /// The dinamico poliza documento.
        /// </value>
        public List<VariableVenta> VariablesPolizaDocumento { get; set; }
    }
}
