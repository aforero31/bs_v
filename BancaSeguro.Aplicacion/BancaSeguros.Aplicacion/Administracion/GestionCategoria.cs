//-----------------------------------------------------------------------
// <copyright file="IRepositorioCategoria.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Administracion
{
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Repositorio.Venta;
    using System.Collections.Generic;

    public class GestionCategoria : IGestionCategoria
    {
        #region Variables

        private IRepositorioCategoria repositorioCategoria;

        #endregion

        #region Constructores

        public GestionCategoria(IRepositorioCategoria repositorioCategoria)
        {
            this.repositorioCategoria = repositorioCategoria;
        }

        #endregion

        #region Metodos Publicos

        public IList<Categoria> ObtenerCategoriasPorIdSubProducto(int idSubProducto)
        {
            return this.repositorioCategoria.ObtenerCategoriasPorIdSubProducto(idSubProducto);
        }

        #endregion
    }
}
