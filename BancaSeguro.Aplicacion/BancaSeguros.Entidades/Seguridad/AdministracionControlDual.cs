
namespace BancaSeguros.Entidades.Seguridad
{
    using System;

    /// <summary>
    /// Entity Administracion Control Dual
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    /// CreationDate: 13/06/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class AdministracionControlDual
    {
        /// <summary>
        /// The id Control Dual administration
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idControlDual;

        /// <summary>
        /// The id menu
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idMenu;

        /// <summary>
        /// The id rol
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idRol;

        /// <summary>
        /// The name of rol
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 15/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombreRol;

        /// <summary>
        /// the value boolean requiere
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool requiere;

        /// <summary>
        /// The value boolean autoriza
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private bool autoriza;

        /// <summary>
        /// Gets or sets the id Control Dual Administration
        /// </summary>
        /// <value>
        ///The id
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdControlDual
        {
            get { return this.idControlDual; }
            set { this.idControlDual = value; }
        }

        /// <summary>
        /// Gets or sets the id Menu
        /// </summary>
        /// <value>
        ///The id menu
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdMenu
        {
            get { return this.idMenu; }
            set { this.idMenu = value; }
        }

        /// <summary>
        /// Gets or sets the id rol
        /// </summary>
        /// <value>
        ///The id rol
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdRol
        {
            get { return this.idRol; }
            set { this.idRol = value; }
        }

        /// <summary>
        /// Gets or sets the name of the rol
        /// </summary>
        /// <value>
        ///The value
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 15/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string NombreRol
        {
            get { return this.nombreRol; }
            set { this.nombreRol = value; }
        }

        /// <summary>
        /// Gets or sets the requiere boolean value
        /// </summary>
        /// <value>
        ///The value
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Requiere
        {
            get { return this.requiere; }
            set { this.requiere = value; }
        }

        /// <summary>
        /// Gets or sets the autoriza boolean value
        /// </summary>
        /// <value>
        ///The value
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public bool Autoriza
        {
            get { return this.autoriza; }
            set { this.autoriza = value; }
        }
    }

}
