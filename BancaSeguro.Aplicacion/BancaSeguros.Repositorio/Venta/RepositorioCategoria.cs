//-----------------------------------------------------------------------
// <copyright file="RepositorioCategoria.cs" company="Unión temporal FS-BAC-2013 ">
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

    /// <summary>
    /// Categoria Repository class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 19/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public class RepositorioCategoria : IRepositorioCategoria
    {

        #region Variables

        private Database DataBase;

        #endregion

        #region Constructor

        public RepositorioCategoria(string nombreConexion)
        {
            this.DataBase = SingletonDatabase.ObtenerDataBase(nombreConexion);
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
        public IList<Categoria> ObtenerCategoriasPorIdSubProducto(int idSubProducto)
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            Mapeador mapeador = new Mapeador();
            using (DbCommand dataBaseCommand = DataBase.GetStoredProcCommand(BancaSeguros.Repositorio.Configuraciones.Procedimientos.PR_SEG_ConsultarCategoriasPorSubProductos))
            {
                DataBase.AddInParameter(dataBaseCommand, ParametrosEntradaProcedimientos.IdSubProducto, DbType.Int32, idSubProducto);
                using (IDataReader reader = DataBase.ExecuteReader(dataBaseCommand))
                {
                    while (reader.Read())
                    {
                        Categoria categoria = mapeador.DataReaderCategoria(reader);
                        listaCategorias.Add(categoria);
                    }
                }
            }
            return listaCategorias;
        }

        #endregion

    }
}
