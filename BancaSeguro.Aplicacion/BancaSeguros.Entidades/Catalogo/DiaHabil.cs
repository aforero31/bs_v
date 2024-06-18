//-----------------------------------------------------------------------
// <copyright file="Categoria.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace BancaSeguros.Entidades.Catalogo
{
    public class DiaHabil
    {
        /// <summary>
        /// The identifier
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 16/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int id;

        /// <summary>
        /// The Date
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 16/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private DateTime fecha;

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 16/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The fecha.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 16/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }
    }
}
