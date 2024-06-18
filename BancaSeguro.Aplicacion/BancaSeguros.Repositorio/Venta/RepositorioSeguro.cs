//-----------------------------------------------------------------------
// <copyright file="RepositorioSeguro.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Venta
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    public class RepositorioSeguro : IRepositorioSeguro
    {
        #region Variables

        private Database DataBase;

        #endregion

        #region Constructor

        public RepositorioSeguro(string nombreConexion)
        {
            this.DataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Get los sure a sale.
        /// </summary>
        /// <param name="idTipoDeIdentificacion">identification number.</param>
        /// <param name="fechaDeNacimientoCliente">date client.</param>
        /// <param name="genero">gender.</param>
        /// <returns>
        /// List Entity sure
        /// </returns>
        /// <remarks>
        /// Author: Wilver Guillermo Zaldua
        /// CreationDate: 09/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IEnumerable<Seguro> ConsultarLosSegurosAVender(int idTipoDeIdentificacion, DateTime fechaDeNacimientoCliente, int genero)
        {
            List<Seguro> listaSeguros = new List<Seguro>();
            Mapeador mapeador = new Mapeador();
            Seguro seguro;
            using (DbCommand dataBaseCommand = DataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarLosSegurosAVender))
            {
                DataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idTipoDeIdentificacion, DbType.Int32, idTipoDeIdentificacion);
                DataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.fechaDeNacimientoCliente, DbType.DateTime, fechaDeNacimientoCliente);
                DataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.genero, DbType.Int32, genero);
                using (IDataReader reader = DataBase.ExecuteReader(dataBaseCommand))
                {
                    while (reader.Read())
                    {
                        seguro = mapeador.DataReaderASeguro(reader);
                        listaSeguros.Add(seguro);
                    }
                }
            }
            return listaSeguros;

        }

        /// <summary>
        /// Get the sure of code y insurance.
        /// </summary>
        /// <param name="codigoSeguro">The code sure.</param>
        /// <param name="codigoAseguradora">The code insurance.</param>
        /// <returns>List entity sure</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 02/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Seguro> ConsultarSegurosPorCodigoYAseguradora(int codigoSeguro, int codigoAseguradora)
        {
            List<Seguro> listaSeguros = new List<Seguro>();
            Mapeador mapeador = new Mapeador();
            Seguro seguro;
            using (DbCommand dataBaseCommand = DataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarSegurosPorCodigoYAseguradora))
            {
                DataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.codigoSeguro, DbType.Int32, codigoSeguro);
                DataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.codigoAseguradora, DbType.Int32, codigoAseguradora);

                using (IDataReader reader = DataBase.ExecuteReader(dataBaseCommand))
                {
                    while (reader.Read())
                    {
                        seguro = mapeador.DataReaderASeguro(reader);
                        listaSeguros.Add(seguro);
                    }
                }
            }

            return listaSeguros;
        }

        #endregion
    }
}
