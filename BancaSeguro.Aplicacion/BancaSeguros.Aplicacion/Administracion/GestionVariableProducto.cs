//-----------------------------------------------------------------------
// <copyright file="GestionVariableProducto.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSeguros.Aplicacion.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BAC.Seguridad.Mensaje;
    using BancaSeguros.Aplicacion.Configuraciones;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Repositorio.Administracion;
    using BancaSeguros.Entidades.Catalogo;

    /// <summary>
    /// Product Variable Manage
    /// </summary>
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionVariableProducto" />
    public class GestionVariableProducto : IGestionVariableProducto
    {
        #region Variables

        /// <summary>
        /// The repository product variable
        /// </summary>
        private IRepositorioVariableProducto repositorioVariableProducto;

        /// <summary>
        /// The repositorio maestras
        /// </summary>
        private IRepositorioMaestra repositorioMaestras;

        /// <summary>
        /// The repositorio items maestra
        /// </summary>
        private IRepositorioItemMaestra repositorioItemsMaestra;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionVariableProducto"/> class.
        /// </summary>
        /// <param name="repositorio">The repository.</param>
        public GestionVariableProducto(IRepositorioVariableProducto repositorio, IRepositorioMaestra repositorioMaestra, IRepositorioItemMaestra repositorioItems)
        {
            this.repositorioVariableProducto = repositorio;
            this.repositorioMaestras = repositorioMaestra;
            this.repositorioItemsMaestra = repositorioItems;
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Inserts the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Result object</returns>
        public Resultado InsertarVariableProducto(VariableProducto variable)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioVariableProducto.InsertarVariableProducto(variable);

                if (resultado.Error)
                {
                    resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoInsertarVariableProducto), LlavesAplicacion.VariableProductoExisteInsercion);
                    resultado.Error = true;
                }
                else if (!resultado.Error)
                {
                    resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoInsertarVariableProducto), LlavesAplicacion.VariableProductoInsertada);
                    resultado.Error = false;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoInsertarVariableProducto), ex, LlavesAplicacion.ExcepcionInsertaVariableProducto).Mensaje;
            }

            return resultado;
        }

        /// <summary>
        /// Update the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Result object</returns>
        public Resultado ActualizarVariableProducto(VariableProducto variable)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioVariableProducto.ActualizarVariableProducto(variable);

                if (resultado.Error)
                {
                    resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoActualizarVariableProducto), LlavesAplicacion.VariableProductoExisteActualizacion);
                    resultado.Error = true;
                }
                else if (!resultado.Error)
                {
                    resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoActualizarVariableProducto), LlavesAplicacion.VariableProductoActualizada);
                    resultado.Error = false;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoActualizarVariableProducto), ex, LlavesAplicacion.ExcepcionActualizaVariableProducto).Mensaje;
            }

            return resultado;
        }

        /// <summary>
        /// Search the product variables.
        /// </summary>
        /// <param name="variable">The variable to search.</param>
        /// <returns>List of variables</returns>
        public IList<VariableProducto> ConsultarVariablesProducto(VariableProducto variable)
        {
            return this.repositorioVariableProducto.ConsultarVariablesProducto(variable);
        }

        /// <summary>
        /// Search the active product variables .
        /// </summary>
        /// <param name="variable">The variable to search.</param>
        /// <returns>List of active variables</returns>
        public IList<VariableProducto> ConsultarVariablesProductoActivas(VariableProducto variable)
        {
            IList<VariableProducto> variablesActivas = new List<VariableProducto>();
            IList<VariableProducto> variables = this.repositorioVariableProducto.ConsultarVariablesProducto(variable);
            foreach(VariableProducto variableProducto in variables)
            {
                if (variableProducto.Estado.Value)
                {
                    if (variableProducto.IdMaestra != null)
                    {
                        Maestra maestraBuscar = new Maestra();
                        maestraBuscar.IdMaestra = variableProducto.IdMaestra.Value;
                        IList<Maestra> maestras = this.repositorioMaestras.ConsultarMaestras(maestraBuscar);
                        if (maestras != null)
                        {
                            if (maestras.Count > 0)
                            {
                                var maestra = (from x in maestras where x.IdMaestra == variableProducto.IdMaestra.Value select x).FirstOrDefault();
                                if (maestra != null)
                                {
                                    if (maestra.Activo.Value)
                                    {
                                        ItemMaestra itemBusqueda = new ItemMaestra();
                                        itemBusqueda.IdMaestra = maestra.IdMaestra;
                                        itemBusqueda.Activo = true;

                                        variableProducto.ItemsMaestra = this.repositorioItemsMaestra.ConsultarItemsMaestra(itemBusqueda);

                                        variablesActivas.Add(variableProducto);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (variableProducto.Estado.Value)
                        {
                            variablesActivas.Add(variableProducto);
                        }
                    }
                }
            }

            return variablesActivas.OrderBy(x => x.Orden).ToList(); 
        }

        /// <summary>
        /// Deletes the product variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>Result object</returns>
        public Resultado EliminarVariableProducto(VariableProducto variable)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioVariableProducto.EliminarVariableProducto(variable);

                if (resultado.Error)
                {
                    resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoEliminarVariableProducto), LlavesAplicacion.VariableProductoExisteEliminacion);
                    resultado.Error = true;
                }
                else if (!resultado.Error)
                {
                    resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoEliminarVariableProducto), LlavesAplicacion.VariableProductoEliminada);
                    resultado.Error = false;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoEliminarVariableProducto), ex, LlavesAplicacion.ExcepcionEliminarVariableProducto).Mensaje;
            }

            return resultado;
        }

        #endregion
    }
}
