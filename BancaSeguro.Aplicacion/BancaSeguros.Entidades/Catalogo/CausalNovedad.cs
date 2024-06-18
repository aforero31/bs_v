

namespace BancaSeguros.Entidades.Catalogo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class CausalNovedad
    {
        /// <summary>
        /// The id Causal Novedad
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idCausalNovedad;

        /// <summary>
        /// The id Novedad
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idTipoNovedad;

        /// <summary>
        /// The Causal Code
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string codigoCausalNovedad;

        /// <summary>
        /// The Causal Name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombreCausalNovedad;

        /// <summary>
        /// The State
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 08/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombreTipoNovedad;

        /// <summary>
        /// The State
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool estadoCausalNovedad;

        /// <summary>
        /// The user logged
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string login;

        /// <summary>
        /// Gets or sets the id Causal Novedad
        /// </summary>
        /// <value>
        ///The id
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 31/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdCausalNovedad
        {
            get { return this.idCausalNovedad; }
            set { this.idCausalNovedad = value; }
        }

        /// <summary>
        /// Gets or sets the id Novedad
        /// </summary>
        /// <value>
        ///The id
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdTipoNovedad
        {
            get { return this.idTipoNovedad; }
            set { this.idTipoNovedad = value; }
        }

        /// <summary>
        /// Gets or sets the Causal code
        /// </summary>
        /// <value>
        ///The code
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string CodigoCausalNovedad
        {
            get { return this.codigoCausalNovedad; }
            set { this.codigoCausalNovedad = value; }
        }

        /// <summary>
        /// Gets or sets the Causal Name
        /// </summary>
        /// <value>
        ///The name
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NombreCausalNovedad
        {
            get { return this.nombreCausalNovedad; }
            set { this.nombreCausalNovedad = value; }
        }

        /// <summary>
        /// Gets or sets the Novelty Type Name
        /// </summary>
        /// <value>
        ///The name
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 08/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NombreTipoNovedad
        {
            get { return this.nombreTipoNovedad; }
            set { this.nombreTipoNovedad = value; }
        }
        /// <summary>
        /// Gets or sets the state of the CausalNovedad
        /// </summary>
        /// <value>
        ///The state
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool EstadoCausalNovedad
        {
            get { return this.estadoCausalNovedad; }
            set { this.estadoCausalNovedad = value; }
        }
        /// /// <summary>
        /// Gets or sets the user logged
        /// </summary>
        /// <value>
        ///The user
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Login
        {
            get { return this.login; }
            set { this.login = value; }
        }
    }
}
