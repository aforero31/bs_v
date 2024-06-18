
namespace BancaSeguros.Entidades.Catalogo
{
    using System;

    /// <summary>
    /// Entity Novedad
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    /// CreationDate: 23/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class Novedad
    {
        /// <summary>
        /// The id Novedad
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 23/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idTipoNovedad;

        /// <summary>
        /// The code Novedad
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 23/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int codigoTipoNovedad;

        /// <summary>
        /// The name Novedad
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 23/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombreTipoNovedad;

        /// <summary>
        /// The state Novedad
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 23/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool estadoNovedad;

        /// <summary>
        /// The user Logged
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 23/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string login;

        /// <summary>
        /// Gets or sets the id Novedad
        /// </summary>
        /// <value>
        ///The id
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 23/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdTipoNovedad
        {
            get { return this.idTipoNovedad; }
            set { this.idTipoNovedad = value; }
        }

        /// <summary>
        /// Gets or sets the code Novedad
        /// </summary>
        /// <value>
        ///The code
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 23/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int CodigoTipoNovedad
        {
            get { return this.codigoTipoNovedad; }
            set { this.codigoTipoNovedad = value; }
        }
        /// <summary>
        /// Gets or sets the name of the Novedad
        /// </summary>
        /// <value>
        ///The name
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 23/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NombreTipoNovedad
        {
            get { return this.nombreTipoNovedad; }
            set { this.nombreTipoNovedad = value; }
        }
        /// <summary>
        /// Gets or sets the state of the Novedad
        /// </summary>
        /// <value>
        ///The state
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 23/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Activo
        {
            get { return this.estadoNovedad; }
            set { this.estadoNovedad = value; }
        }

        /// <summary>
        /// Gets or sets the user Logged
        /// </summary>
        /// <value>
        ///The user
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 23/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Login
        {
            get { return this.login; }
            set { this.login = value;  }
        }
    }

}
