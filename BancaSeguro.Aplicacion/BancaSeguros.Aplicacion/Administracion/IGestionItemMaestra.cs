﻿//-----------------------------------------------------------------------
// <copyright file="IGestionItemMaestra.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Aplicacion.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    
    /// <summary>
    /// Master Item Manage interface
    /// </summary>
    public interface IGestionItemMaestra
    {
        /// <summary>
        /// Inserts the master item.
        /// </summary>
        /// <param name="itemMaestra">The master item.</param>
        /// <returns>Result object</returns>
        Resultado InsertarItemMaestra(ItemMaestra itemMaestra);

        /// <summary>
        /// Update the item master.
        /// </summary>
        /// <param name="itemMaestra">The item master.</param>
        /// <returns>Result object</returns>
        Resultado ActualizarItemMaestra(ItemMaestra itemMaestra);

        /// <summary>
        /// Search the master items.
        /// </summary>
        /// <param name="itemMaestra">The master item.</param>
        /// <returns>List of item masters</returns>
        IList<ItemMaestra> ConsultarItemsMaestra(ItemMaestra itemMaestra);

        /// <summary>
        /// Deletes the master item.
        /// </summary>
        /// <param name="itemMaestra">The master item.</param>
        /// <returns>Result object</returns>
        Resultado EliminarItemMaestra(ItemMaestra itemMaestra);
    }
}
