//-----------------------------------------------------------------------
// <copyright file="IRepositorioPeriodicidad.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Administracion
{
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RepositorioPeriodicidad : IRepositorioPeriodicidad
    {
        #region Variables
        /// <summary>
        /// variable database
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\cpiza
        /// CreationDate: 06/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Database dataBase;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioParametro"/> class.
        /// </summary>
        /// <param name="nombreConexion">The name connection.</param>
        /// <remarks>
        /// Author: INTERGRUPO\cpiza
        /// CreationDate: 06/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public RepositorioPeriodicidad(string nombreConexion)
        {
            this.dataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }
        #endregion

        /// <summary>
        /// Gets the lista periodicidad activas.
        /// </summary>
        /// <returns>Periodicity List</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 06/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Periodicidad> ObtenerListaPeriodicidadActivas()
        {
            IList<Periodicidad> resultado = new List<Periodicidad>();
            Mapeador mapeador = new Mapeador();
            DbCommand comandoBaseDatos = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarPeriodicidadActivos);
            using (IDataReader reader = this.dataBase.ExecuteReader(comandoBaseDatos))
            {
                while (reader.Read())
                {
                    Periodicidad periodicidad = new Periodicidad();
                    periodicidad = mapeador.DataReaderPeriodicidad(reader);
                    resultado.Add(periodicidad);
                }
            }
            return resultado;
        }
    }
}
