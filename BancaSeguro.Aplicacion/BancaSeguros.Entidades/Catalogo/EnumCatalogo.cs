//-----------------------------------------------------------------------
// <copyright file="EnumCatalogo.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Entidades.Catalogo
{
    using System;

    /// <summary>
    /// catalog list
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 13/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public static class EnumCatalogo
    {
        /// <summary>
        /// Table parameter
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public const string Parametro = "SEG_Parametro";

        /// <summary>
        /// Table sale channel
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public const string CanalVenta = "SEG_CanalVenta";
        
        /// <summary>
        /// The type data
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public const string TipoDato = "SEG_TipoDato";

        /// <summary>
        /// The table type validation
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public const string TipoValidacion = "SEG_TipoValidacion";

        /// <summary>
        /// Table relationship
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public const string Parentesco = "SEG_Parentesco";

        /// <summary>
        /// Table periodicity
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public const string Periodicidad = "SEG_Periodicidad";

        /// <summary>
        /// Table plan
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public const string Plan = "SEG_Plan";

        /// <summary>
        /// Table type identification
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public const string TipoIdentificacion = "SEG_TipoIdentificacion";

        /// <summary>
        /// Table gender
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public const string Genero = "SEG_Genero";

        /// <summary>
        /// Table type product
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public const string TipoProducto = "SEG_TipoProducto";

        /// <summary>
        /// The audit table
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public const string TablaAuditada = "SEG_TablaAuditada";

        /// <summary>
        /// The Novelty table
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 24/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public const string TablaNovedad = "SEG_TipoNovedad";

        /// <summary>
        /// The Causal Novelty table
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public const string TablaCausalNovedad = "SEG_CausalNovedad";

        /// <summary>
        /// The Event table
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 21/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public const string TablaEventos = "SEG_Evento";

        public const string CobisTipoIdentificacion = "cl_tipo_documento";

        public const string CobisPeriodicidad = "ec_periodicidad";

        public const string CobisParentesco = "cl_parentesco";

        public const string CobisProducto = "cl_producto";

        public const string CobisSubProductoCC = "cc_sub_banc_cte";

        public const string CobisSubProductoCA = "ah_sub_banc_aho";

        public const string CobisCategoria = "pe_categoria";


        /// <summary>
        /// The Event table
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\jgonzalezg
        ///  CreationDate: 19/10/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public const string CobisCategoriaCA = "ah_categoria";
        public const string CobisCategoriaCC = "cc_categoria";
    }
}