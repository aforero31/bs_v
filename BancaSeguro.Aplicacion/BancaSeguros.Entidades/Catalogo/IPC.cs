namespace BancaSeguros.Entidades.Catalogo
{

    using System;

    /// <summary>
    /// Entity IPC
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    /// CreationDate: 17/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [Serializable]
    public class IPC
    {
        /// <summary>
        /// The id IPC
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int idIPC; 

        /// <summary>
        /// The year
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int ano;

        /// <summary>
        /// The IPC value
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private decimal valor;

        /// <summary>
        /// The User Logged value
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 20/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string login;

        /// <summary>
        /// The current year
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PRO-IMONTOYAM
        /// CreationDate: 13/09/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private int anoActual;

        /// <summary>
        /// Gets or sets the id IPC
        /// </summary>
        /// <value>
        ///The id
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public int IdIpc
        {
            get { return this.idIPC; }
            set { this.idIPC = value; }
        }

        /// <summary>
        /// Gets or sets the year of the IPC
        /// </summary>
        /// <value>
        ///The year
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public int Ano
        {
            get { return this.ano; }
            set { this.ano = value; }
        }

        /// <summary>
        /// Gets or sets the IPC value
        /// </summary>
        /// <value>
        ///The year
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public decimal Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }

        /// <summary>
        /// Gets or sets the User Logged
        /// </summary>
        /// <value>
        ///The year
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 20/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public string Login
        {
            get { return this.login; }
            set { this.login = value; }
        }

        /// <summary>
        /// Gets or sets the current year of system
        /// </summary>
        /// <value>
        ///The year
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\PRO-IMONTOYAM
        /// CreationDate: 13/09/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public int AnoActual
        {
            get { return this.anoActual; }
            set { this.anoActual = value; }
        }
    }
}
