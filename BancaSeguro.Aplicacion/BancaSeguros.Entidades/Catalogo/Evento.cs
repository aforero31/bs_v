
namespace BancaSeguros.Entidades.Catalogo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Evento
    {
        /// <summary>
        /// The id Evento
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 21/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idEvento;

        /// <summary>
        /// The key
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 21/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string llave;

        /// <summary>
        /// The event
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 21/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string evento;

        /// <summary>
        /// Gets or sets the id Event
        /// </summary>
        /// <value>
        ///The id
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 21/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdEvento
        {
            get { return this.idEvento; }
            set { this.idEvento = value; }
        }

        /// <summary>
        /// Gets or sets the key
        /// </summary>
        /// <value>
        ///The key
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Llave
        {
            get { return this.llave; }
            set { this.llave = value; }
        }

        /// <summary>
        /// Gets or sets the event
        /// </summary>
        /// <value>
        ///The event
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 21/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Eventos
        {
            get { return this.evento; }
            set { this.evento = value; }
        }
    }
}
