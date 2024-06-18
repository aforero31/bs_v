//-----------------------------------------------------------------------
// <copyright file="IGestionGenerico.cs" company="UT">
//     Copyright (c) UT. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Entidades.Catalogo;
    public interface IGestionGenerico
    {
        /// <summary>
        /// Get the catalog.
        /// </summary>
        /// <param name="nombreTabla">The name table.</param>
        /// <returns>Entity catalog</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        DtoCatalogo ConsultarCatalogo(string nombreTabla);

        /// <summary>
        /// Save the error.
        /// </summary>
        /// <param name="exc">The exception.</param>
        /// <returns>number number</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Int64 GuardarError(Exception Mensaje);

        /// <summary>
        /// Save the error.
        /// </summary>
        /// <param name="exc">The exception.</param>
        /// <returns>number number</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 05/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Int64 GuardarError(string Mensaje);
        
    }
}
