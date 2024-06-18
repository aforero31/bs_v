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
    public class VariableVentaPolizaDocumento
    {
        /// <summary>
        /// Orden de salida
        /// </summary>
        /// <remarks>
        /// Author: Enrique Rivera
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int orden;

        /// <summary>
        /// The name Valor
        /// </summary>
        /// <remarks>
        /// Author: Enrique Rivera
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string valor;

        
        /// <summary>
        /// Gets or sets el orden
        /// </summary>
        /// <value>
        /// orden.
        /// </value>
        /// <remarks>
        /// Author: Enrique Rivera
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int Orden
        {
            get { return this.orden; }
            set { this.orden = value; }
        }

        /// <summary>
        /// Gets or sets el valor
        /// </summary>
        /// <value>
        /// valor.
        /// </value>
        /// <remarks>
        /// Author: Enrique Rivera
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }        
    }
}
