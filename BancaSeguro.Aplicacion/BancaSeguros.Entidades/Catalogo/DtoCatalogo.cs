//-----------------------------------------------------------------------
// <copyright file="DtoCatalogo.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Catalogo
{
    using System;
    using System.Collections.Generic;
    using BancaSeguros.Entidades.Seguro;
    using General;

    /// <summary>
    /// The Entity
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 13/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class DtoCatalogo
    {
        /// <summary>
        /// Gets or sets the list relationship.
        /// </summary>
        /// <value>
        /// The list relationship.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Parentesco> ListParentesco { get; set; }

        /// <summary>
        /// Gets or sets the list periodicity.
        /// </summary>
        /// <value>
        /// The list periodicity.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Periodicidad> ListPeriodicidad { get; set; }

        /// <summary>
        /// Gets or sets the list type identification.
        /// </summary>
        /// <value>
        /// The list type identification.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<TipoIdentificacion> ListTipoIdentificacion { get; set; }

        /// <summary>
        /// Gets or sets the list gender.
        /// </summary>
        /// <value>
        /// The list gender.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Genero> ListGenero { get; set; }

        /// <summary>
        /// Gets or sets the list type product.
        /// </summary>
        /// <value>
        /// The list type product.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<TipoProducto> ListTipoProducto { get; set; }

        /// <summary>
        /// Gets or sets the list plans.
        /// </summary>
        /// <value>
        /// The list plans.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Plan> ListPlanes { get; set; }

        /// <summary>
        /// Gets or sets the list parameter.
        /// </summary>
        /// <value>
        /// The list parameter.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Parametro> ListParametro { get; set; }

        /// <summary>
        /// Gets or sets the list channel sale.
        /// </summary>
        /// <value>
        /// The list channel sale.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<CanalVenta> ListCanalVenta { get; set; }

        /// <summary>
        /// Gets or sets the list type data.
        /// </summary>
        /// <value>
        /// The list type data.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<TipoDato> ListTipoDato { get; set; }

        /// <summary>
        /// Gets or sets the list type validation.
        /// </summary>
        /// <value>
        /// The list type validation.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<TipoValidacion> ListTipoValidacion { get; set; }

        /// <summary>
        /// Gets or sets the list audit tables.
        /// </summary>
        /// <value>
        /// The list audit tables.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<TablaAuditada> ListTablaAuditada { get; set; }

        /// <summary>
        /// Gets or sets the list Novelty table.
        /// </summary>
        /// <value>
        /// The list Novelty table.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Novedad> ListTablaNovedad { get; set; }

        /// <summary>
        /// Gets or sets the list Causal Novelty table.
        /// </summary>
        /// <value>
        /// The list Causal Novelty table.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<CausalNovedad> ListTablaCausalNovedad { get; set; }

        /// <summary>
        /// Gets or sets the list of events
        /// </summary>
        /// <value>
        /// The list of events.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 21/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Evento> ListTablaEvento { get; set; }

        public List<Producto> TablaProducto { get; set; }

        public List<SubProducto> TablaSubProducto { get; set; }

        public List<Categoria> TablaCategoria { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 17/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado Resultado { get; set; }
    }
}
