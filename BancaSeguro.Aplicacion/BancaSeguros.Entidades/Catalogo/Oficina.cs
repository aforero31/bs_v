using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaSeguros.Entidades.Catalogo
{
    using System;

    /// <summary>
    /// The identifier
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\JGARCIAR
    /// CreationDate: 08/10/2019
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class Oficina
    {
        /// <summary>
        /// The identifier office
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 08/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idOficina;

        /// <summary>
        /// The name
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 08/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string nombre;

        /// <summary>
        /// The city
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 08/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string ciudad;

        /// <summary>
        /// The active
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 08/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int activo;

        /// <summary>
        /// The identifier opcion
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 08/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int opcion;


        public BancaSeguros.Entidades.General.Resultado Resultado {get; set;}

        /// <summary>
        /// Gets or sets the identifier office.
        /// </summary>
        /// <value>
        /// The identifier office.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 08/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdOficina
        {
            get { return this.idOficina; }
            set { this.idOficina = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 08/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 08/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Ciudad
        {
            get { return this.ciudad; }
            set { this.ciudad = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Oficina"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 08/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
        }

        /// <summary>
        /// Gets or sets a value opcion
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 08/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int Opcion
        {
            get { return this.opcion; }
            set { this.opcion = value; }
        }

        #region Log Oficinas

        /// <summary>
        /// The identifier fecha
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 15/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private DateTime fecha;

        /// <summary>
        /// The identifier fecha
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 15/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string usuario;

        /// <summary>
        /// The identifier tipoevento
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 15/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string tipoevento;

        /// <summary>
        /// The identifier inicial
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 15/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string inicial;

        /// <summary>
        /// The identifier final
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 15/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string final;

        /// <summary>
        /// Gets or sets Fecha.
        /// </summary>
        /// <value>
        /// The identifier Fecha.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 15/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }

        /// <summary>
        /// Gets or sets Usuario.
        /// </summary>
        /// <value>
        /// The identifier Usuario.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 15/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        /// <summary>
        /// Gets or sets Tipoevento.
        /// </summary>
        /// <value>
        /// The identifier Tipoevento.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 15/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Tipoevento
        {
            get { return this.tipoevento; }
            set { this.tipoevento = value; }
        }

        /// <summary>
        /// Gets or sets Inicial.
        /// </summary>
        /// <value>
        /// The identifier Inicial.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 15/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Inicial
        {
            get { return this.inicial; }
            set { this.inicial = value; }
        }

        /// <summary>
        /// Gets or sets Final.
        /// </summary>
        /// <value>
        /// The identifier Final.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 15/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public string Final
        {
            get { return this.final; }
            set { this.final = value; }
        }

        # endregion

    }
}
