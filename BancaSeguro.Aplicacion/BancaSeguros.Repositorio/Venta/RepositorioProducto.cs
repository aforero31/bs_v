//-----------------------------------------------------------------------
// <copyright file="RepositorioProducto.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Venta
{
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Repositorio.Configuraciones;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class RepositorioProducto : IRepositorioProducto
    {        
        #region Variables

        private Database dataBase;

        #endregion

        #region Constructor

        public RepositorioProducto(string nombreConexion)
        {
            this.dataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
        }

        #endregion
        
        #region Metodos publicos

        /// <summary>
        /// gets the categories by identifier sub producto.
        /// </summary>
        /// <param name="idSubProducto">The identifier sub producto.</param>
        /// <returns>Categories List</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 19/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<SubProducto> ObtenerSubProductosPorCodigoProducto(int codigoProducto)
        {
            List<SubProducto> listaSubProductos = new List<SubProducto>();
            Mapeador mapeador = new Mapeador();
            using (DbCommand dataBaseCommand = dataBase.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarSubProductosPorCodigoProducto))
            {
                dataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.CodigoProducto, DbType.Int32, codigoProducto);
                using (IDataReader reader = dataBase.ExecuteReader(dataBaseCommand))
                {
                    while (reader.Read())
                    {
                        SubProducto subProducto = mapeador.DataReaderSubProducto(reader);
                        listaSubProductos.Add(subProducto);
                    }
                }
            }
            return listaSubProductos;
        }

        /// <summary>
        /// Gets the productos bancarios activos.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 06/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Producto> ObtenerProductosBancariosActivos()
        {
            IList<Producto> resultado = new List<Producto>();
            Mapeador mapeador = new Mapeador();
            DbCommand comandoBaseDatos = this.dataBase.GetStoredProcCommand(Procedimientos.PR_SEG_ConsultarProductosBancariosActivos);
            using (IDataReader reader = this.dataBase.ExecuteReader(comandoBaseDatos))
            {
                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto = mapeador.DataReaderProducto(reader);
                    resultado.Add(producto);
                }
            }
            return resultado;
        }

        #endregion
    }
}
