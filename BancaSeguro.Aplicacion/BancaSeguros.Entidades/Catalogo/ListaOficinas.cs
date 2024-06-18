using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    /// Author: INTERGRUPO\JGARCIAR
    /// CreationDate: 08/10/2019
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class ListaOficinas
    {

        /// <summary>
        /// Gets or sets the list relationship.
        /// </summary>
        /// <value>
        /// The list relationship.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 08/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Oficina> ListOficinas { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 08/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado Resultado { get; set; }

    }
}
