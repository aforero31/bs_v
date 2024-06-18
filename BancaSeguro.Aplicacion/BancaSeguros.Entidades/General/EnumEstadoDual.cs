//-----------------------------------------------------------------------
// <copyright file="EnumEstadoDual.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Entidades.General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Dual Action type class
    /// </summary>
    public static class EnumEstadoDual
    {
        /// <summary>
        /// The state 
        /// </summary>
        public const string PorAprobar = "P";

        /// <summary>
        /// The update
        /// </summary>
        public const string Aprobada = "A";

        /// <summary>
        /// The activate
        /// </summary>
        public const string Rechazada = "R";
    }
}
