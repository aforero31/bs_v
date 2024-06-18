//-----------------------------------------------------------------------
// <copyright file="RepositorioSeguro.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// Repository sure
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 14/06/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Repositorio.Administracion.IRepositorioSeguro" />
    public class RepositorioSeguro : IRepositorioSeguro
    {
        #region Variables

        /// <summary>
        /// The data base
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Database dataBase;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorioSeguro"/> class.
        /// </summary>
        /// <param name="nombreConexion">The name connection.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public RepositorioSeguro(string nombreConexion)
        {
            this.dataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Save the sure.
        /// </summary>
        /// <param name="seguro">The sure.</param>
        /// <returns>Entity result sure</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 03/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public ResultadoSeguro InsertarSeguro(Seguro seguro)
        {
            ResultadoSeguro resultado = new ResultadoSeguro();
            try
            {
                using (DbCommand dataBaseCommand = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_InsertarSeguro))
                {
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idAseguradora, DbType.Int32, seguro.IdAseguradora);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.nombre, DbType.String, seguro.Nombre);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Descripcion, DbType.String, seguro.Descripcion);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Codigo, DbType.String, seguro.Codigo);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Conyuge, DbType.Boolean, seguro.Conyuge);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Beneficiario, DbType.Boolean, seguro.Beneficiario);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.EdadMinimaMujer, DbType.Int32, seguro.EdadMinimaMujer);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.EdadMaximaMujer, DbType.Int32, seguro.EdadMaximaMujer);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.EdadMinimaHombre, DbType.Int32, seguro.EdadMinimaHombre);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.EdadMaximaHombre, DbType.Int32, seguro.EdadMaximaHombre);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, seguro.Activo);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.EdadMinimaConyugue, DbType.Int32, seguro.EdadMinimaConyuge);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.EdadMaximaConyugue, DbType.Int32, seguro.EdadMaximaConyuge);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.IdCanalVenta, DbType.Int32, seguro.IdCanalVenta);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.MaximoBeneficiarios, DbType.Int32, seguro.MaximoBeneficiarios);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.NumeroMaximoSegurosPorCliente, DbType.Int32, seguro.NumeroMaximoSegurosPorCliente);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.NumeroMaximoVentaSegurosPorCuentaCliente, DbType.Int32, seguro.NumeroMaximoVentaSegurosPorCuentaCliente);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Login, DbType.String, seguro.Login);


                    using (IDataReader reader = this.dataBase.ExecuteReader(dataBaseCommand))
                    {
                        while (reader.Read())
                        {
                            resultado.IdSeguro = reader.IsDBNull(reader.GetOrdinal(Campos.idSeguro)) ? 0 : Convert.ToInt32(reader[Campos.idSeguro]);
                        }

                        resultado.Resultado = new Resultado() { Error = false, Mensaje = Mensajes.InsertarSeguroExitoso };
                    }
                }
            }
            catch (Exception)
            {
                resultado.IdSeguro = 0;
                resultado.Resultado = new Resultado() { Error = true, Mensaje = Mensajes.ErrorInsertarSeguro };
            }

            return resultado;
        }

        /// <summary>
        /// Get all the sure.
        /// </summary>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Seguro> ConsultarTodosLosSeguros()
        {
            List<Seguro> listaSeguros = new List<Seguro>();
            try
            {
                Mapeador mapeador = new Mapeador();
                Seguro seguro;
                using (DbCommand dataBaseCommand = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarTodosLosSeguros))
                {
                    using (IDataReader reader = this.dataBase.ExecuteReader(dataBaseCommand))
                    {
                        while (reader.Read())
                        {
                            seguro = mapeador.DataReaderASeguro(reader);
                            listaSeguros.Add(seguro);
                        }
                    }
                }
            }
            catch (Exception)
            {
                //resultado = new Resultado() { Error = true, Mensaje = Mensajes.ErrorInsertarSeguro };
            }

            return listaSeguros;
        }

        /// <summary>
        /// Update the sure of identifier.
        /// </summary>
        /// <param name="seguro">The sure.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarSeguroPorId(Seguro seguro)
        {
            Resultado resultado = new Resultado();
            try
            {
                DbCommand dataBaseCommand = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizaSeguroPorId);

                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, seguro.IdSeguro);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Beneficiario, DbType.Boolean, seguro.Beneficiario);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.MaximoBeneficiarios, DbType.Int32, seguro.MaximoBeneficiarios);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Codigo, DbType.String, seguro.Codigo);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Conyuge, DbType.Boolean, seguro.Conyuge);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.EdadMinimaConyugue, DbType.Int32, seguro.EdadMinimaConyuge);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.EdadMaximaConyugue, DbType.Int32, seguro.EdadMaximaConyuge);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.EdadMinimaHombre, DbType.Int32, seguro.EdadMinimaHombre);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.EdadMaximaHombre, DbType.Int32, seguro.EdadMaximaHombre);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.EdadMinimaMujer, DbType.Int32, seguro.EdadMinimaMujer);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.EdadMaximaMujer, DbType.Int32, seguro.EdadMaximaMujer);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.IdCanalVenta, DbType.Int32, seguro.IdCanalVenta);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.nombre, DbType.String, seguro.Nombre);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.NumeroMaximoSegurosPorCliente, DbType.Int32, seguro.NumeroMaximoSegurosPorCliente);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.NumeroMaximoVentaSegurosPorCuentaCliente, DbType.Int32, seguro.NumeroMaximoVentaSegurosPorCuentaCliente);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Activo, DbType.Boolean, seguro.Activo);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Login, DbType.String, seguro.Login);

                this.dataBase.ExecuteNonQuery(dataBaseCommand);
            }
            catch (Exception)
            {
                resultado = new Resultado() { Error = true, Mensaje = Mensajes.ErrorInsertarSeguro };
            }

            return resultado;
        }

        /// <summary>
        /// Get the sure of identifier.
        /// </summary>
        /// <param name="idSeguro">The identifier sure.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 17/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Seguro ConsultarSeguroPorId(int idSeguro)
        {
            Seguro seguro = new Seguro();

            try
            {
                Mapeador mapeador = new Mapeador();

                using (DbCommand dataBaseCommand = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarSeguroPorId))
                {
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, idSeguro);

                    using (IDataReader reader = this.dataBase.ExecuteReader(dataBaseCommand))
                    {
                        while (reader.Read())
                        {
                            seguro = mapeador.DataReaderASeguro(reader);
                        }
                    }
                }
            }
            catch (Exception)
            {
                //resultado = new Resultado() { Error = true, Mensaje = Mensajes.ErrorInsertarSeguro };
            }

            return seguro;
        }

        /// <summary>
        /// Get all the sure.
        /// </summary>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Seguro> ConsultarSegurosPorParametros(string nombreProducto, int codigoProducto, string nombreAseguradora)
        {
            List<Seguro> listaSeguros = new List<Seguro>();
            Mapeador mapeador = new Mapeador();

            using (DbCommand dataBaseCommand = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarSegurosPorParametros))
            {
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.nombre, DbType.String, nombreProducto);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Codigo, DbType.Int32, codigoProducto);
                this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.aseguradora, DbType.String, nombreAseguradora);

                using (IDataReader reader = this.dataBase.ExecuteReader(dataBaseCommand))
                {
                    while (reader.Read())
                    {
                        Seguro seguro = new Seguro();
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
