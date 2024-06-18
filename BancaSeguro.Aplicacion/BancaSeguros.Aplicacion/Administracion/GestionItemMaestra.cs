//-----------------------------------------------------------------------
// <copyright file="GestionItemMaestra.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Aplicacion.Administracion
{
    using System;
    using System.Collections.Generic;
    using BAC.Seguridad.Mensaje;
    using BancaSeguros.Aplicacion.Configuraciones;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Repositorio.Administracion;

    /// <summary>
    /// Master Item Management
    /// </summary>
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionItemMaestra" />
    public class GestionItemMaestra : IGestionItemMaestra
    {
        #region Variables

        /// <summary>
        /// The master item repository
        /// </summary>
        private IRepositorioItemMaestra repositorioItemMaestra;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionItemMaestra"/> class.
        /// </summary>
        /// <param name="repositorio">The repository.</param>
        public GestionItemMaestra(IRepositorioItemMaestra repositorio)
        {
            this.repositorioItemMaestra = repositorio;
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Inserts the master item.
        /// </summary>
        /// <param name="itemMaestra">The master item.</param>
        /// <returns>Result object</returns>
        public Resultado InsertarItemMaestra(ItemMaestra itemMaestra)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioItemMaestra.InsertarItemMaestra(itemMaestra);

                if (resultado.Error)
                {
                    resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoInsertarItemMaestra), LlavesAplicacion.ItemMaestraExiste);
                    resultado.Error = true;
                }
                else if (!resultado.Error)
                {
                    resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoInsertarItemMaestra), LlavesAplicacion.ItemMaestraGuardado);
                    resultado.Error = false;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoInsertarItemMaestra), ex, LlavesAplicacion.ExcepcionGuardarItemMaestra).Mensaje;
            }

            return resultado;
        }

        /// <summary>
        /// Update the item master.
        /// </summary>
        /// <param name="itemMaestra">The item master.</param>
        /// <returns>Result object</returns>
        public Resultado ActualizarItemMaestra(ItemMaestra itemMaestra)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioItemMaestra.ActualizarItemMaestra(itemMaestra);

                resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoActualizarItemMaestra), LlavesAplicacion.ItemMaestraActualizado);
                resultado.Error = false;
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoActualizarItemMaestra), ex, LlavesAplicacion.ExcepcionActualizarItemMaestra).Mensaje;
            }

            return resultado;
        }

        /// <summary>
        /// Search the master items.
        /// </summary>
        /// <param name="itemMaestra">The master item.</param>
        /// <returns>List of item masters</returns>
        public IList<ItemMaestra> ConsultarItemsMaestra(ItemMaestra itemMaestra)
        {
            return this.repositorioItemMaestra.ConsultarItemsMaestra(itemMaestra);
        }

        /// <summary>
        /// Deletes the item master.
        /// </summary>
        /// <param name="itemMaestra">The master item.</param>
        /// <returns>Result object</returns>
        public Resultado EliminarItemMaestra(ItemMaestra itemMaestra)
        {
            Resultado resultado = new Resultado();
            try
            {
                ItemMaestra itemBusqueda = new ItemMaestra();
                itemBusqueda.IdMaestra = itemMaestra.IdMaestra;
                IList<ItemMaestra> items = this.repositorioItemMaestra.ConsultarItemsMaestra(itemBusqueda);
                if (items.Count - 1 < 2)
                {
                    resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoEliminarItemMaestra), LlavesAplicacion.MinimoItemsMaestraSuperado);
                    resultado.Error = true;
                }
                else
                {
                    resultado = this.repositorioItemMaestra.EliminarItemMaestra(itemMaestra);

                    if (resultado.Error)
                    {
                        resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoEliminarItemMaestra), LlavesAplicacion.ItemMaestraUsadoVenta);
                        resultado.Error = true;
                    }
                    else if (!resultado.Error)
                    {
                        resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoEliminarItemMaestra), LlavesAplicacion.ItemMaestraEliminado);
                        resultado.Error = false;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoEliminarItemMaestra), ex, LlavesAplicacion.ExcepcionEliminarItemMaestra).Mensaje;
            }

            return resultado;
        }

        #endregion
    }
}
