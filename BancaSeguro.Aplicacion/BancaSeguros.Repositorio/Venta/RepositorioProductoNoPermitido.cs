//-----------------------------------------------------------------------
// <copyright file="RepositorioProductoNoPermitido.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Venta
{
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioProductoNoPermitido : IRepositorioProductoNoPermitido
    {
        #region Variables

        private Database dataBase;

        #endregion

        #region Constructor
        public RepositorioProductoNoPermitido(string nombreConexion)
        {
            this.dataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }
        #endregion

        #region Metodos Publicos

        public IList<ProductoNoPermitido> ConsultarProductosNoPermitidosPorSeguro(int idSeguro)
        {
            IList<ProductoNoPermitido> listaProductoNoPermitido = new List<ProductoNoPermitido>();
            Mapeador mapeador = new Mapeador();
            ProductoNoPermitido productoNoPermitido;
            using (DbCommand dataBaseCommand = dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarProductosNoPermitidosPorSeguro))
            {
                dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, idSeguro);

                using (IDataReader reader = dataBase.ExecuteReader(dataBaseCommand))
                {
                    while (reader.Read())
                    {
                        productoNoPermitido = mapeador.DataReaderAProductoNoPermitido(reader);

                        listaProductoNoPermitido.Add(productoNoPermitido);
                    }
                }
            }
            return listaProductoNoPermitido;
        }

        /// <summary>
        /// Saves the producto no permitido.
        /// </summary>
        /// <param name="productoNoPermitido">The producto no permitido.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 04/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado GuardarProductoNoPermitido(ProductoNoPermitido productoNoPermitido)
        {
            Resultado resultado = new Resultado();
            try
            {
                using (DbCommand dataBaseCommand = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_InsertarProductoNoPermitido))
                {
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, productoNoPermitido.IdSeguro);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.codigoCategoria, DbType.String, productoNoPermitido.Categoria.Codigo);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.CodigoProducto, DbType.Int32, productoNoPermitido.Producto.Codigo);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.CodigoSubProducto, DbType.Int32, productoNoPermitido.SubProducto.Codigo);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.Login, DbType.String, productoNoPermitido.Login);
                    this.dataBase.ExecuteNonQuery(dataBaseCommand);
                    resultado.Error = false;
                    resultado.Mensaje = Mensajes.InsertarProductoNoPermitidoExitoso;
                }
            }
            catch (Exception)
            {
                resultado.Error = true;
                resultado.Mensaje = Mensajes.ErrorInsertarProductoNoPermitido;
            }
            return resultado;
        }

        /// <summary>
        /// Deletes the producto no permitido.
        /// </summary>
        /// <param name="productoNoPermitido">The producto no permitido.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 04/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado EliminarProductoNoPermitido(ProductoNoPermitido productoNoPermitido)
        {
            Resultado resultado = new Resultado();
            try
            {
                using (DbCommand dataBaseCommand = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_EliminarProductoNoPermitido))
                {
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.idSeguro, DbType.Int32, productoNoPermitido.IdSeguro);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.codigoCategoria, DbType.String, productoNoPermitido.Categoria.Codigo);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.CodigoProducto, DbType.Int32, productoNoPermitido.Producto.Codigo);
                    this.dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.CodigoSubProducto, DbType.Int32, productoNoPermitido.SubProducto.Codigo);
                    dataBaseCommand.ExecuteNonQuery();

                    resultado.Error = false;
                    resultado.Mensaje = Mensajes.InsertarProductoNoPermitidoExitoso;
                }
            }
            catch (Exception)
            {
                resultado.Error = true;
                resultado.Mensaje = Mensajes.ErrorInsertarProductoNoPermitido;
            }
            return resultado;
        }

        /// <summary>
        /// Update the products no access por identifier.
        /// </summary>
        /// <param name="produtos">The produts.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ActualizarProductosNoPermitidosPorId(DataTable produtos, int idSeguro, string login)
        {
            Resultado resultado = new Resultado();

            SqlDatabase db = (SqlDatabase)EnterpriseLibraryContainer.Current.GetInstance<Database>("CONEXION_BANCASEGURO");

            using (var cmd = db.GetStoredProcCommand(Procedimientos.PR_SEG_ActualizarProductosNoPermitidosPorId))
            {
                cmd.CommandTimeout = 0;
                db.AddInParameter(cmd, ParametrosEntradaProcedimientos.TablaProductos, SqlDbType.Structured, produtos);
                db.AddInParameter(cmd, ParametrosEntradaProcedimientos.idSeguro, SqlDbType.Int, idSeguro);
                db.AddInParameter(cmd, ParametrosEntradaProcedimientos.Login, SqlDbType.VarChar, login);

                using (var reader = db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        resultado.Mensaje = reader.IsDBNull(reader.GetOrdinal(Campos.Accion)) ? string.Empty : (string)reader[Campos.Accion];
                    }
                }
            }

            return resultado;
        }

        #endregion
    }
}
