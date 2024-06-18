//-----------------------------------------------------------------------
// <copyright file="ParametrizacionSeguro.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Administracion
{
    using System;
    using System.Collections.Generic;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;

    /// <summary>
    /// Insurance config entity
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 04/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class ParametrizacionSeguro
    {
        /// <summary>
        /// Gets or sets the insurance.
        /// </summary>
        /// <value>
        /// The insurance.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 04/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Seguro Seguro { get; set; }

        /// <summary>
        /// Gets or sets the planes.
        /// </summary>
        /// <value>
        /// The planes.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 04/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Plan> Planes { get; set; }

        /// <summary>
        /// Gets or sets the not permitted products.
        /// </summary>
        /// <value>
        /// The not permitted products.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 04/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<ProductoNoPermitido> ProductosNoPermitidos { get; set; }

        /// <summary>
        /// Gets or sets the insurance id types.
        /// </summary>
        /// <value>
        /// The insurances id types.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 04/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<TipoIdentificacion> TiposIdentificacionPorSeguro { get; set; }

        public DocumentoPoliza DocumentoPoliza { get; set; }

        public string Login { get; set; }
    }
}
