//-----------------------------------------------------------------------
// <copyright file="GestionSeguridad.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BAC.Seguridad.Seguridad
{
    using System.Collections.Generic;
    using System.Linq;
    using BAC.EntidadesSeguridad;
    using BancaSeguros.Repositorio.Seguridad;
    using System;
    using Mensaje;
    using Configuraciones;

    /// <summary>
    /// Class Management Security
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 21/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BAC.Seguridad.Seguridad.IGestionSeguridad" />
    public class GestionSeguridad : IGestionSeguridad
    {
        #region Variables

        /// <summary>
        /// The repository role
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioRol repositorioRol;

        /// <summary>
        /// The repository users
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioOficina repositorioOficina;

        /// <summary>
        /// The repository menu
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioMenu repositorioMenu;

        /// <summary>
        /// The repository permission
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioPermiso repositorioPermiso;

        /// <summary>
        /// The repository grup banck
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioGrupoBAC repositorioGrupoBAC;

        /// <summary>
        /// The repository control dual
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioAdmonControlDual repositorioAdmonControlDual;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionSeguridad"/> class.
        /// </summary>
        /// <param name="repositorioRol">The repository role.</param>
        /// <param name="repositorioUsuarios">The repository users.</param>
        /// <param name="repositorioMenu">The repository menus.</param>
        /// <param name="repositorioPermiso">The repository permission.</param>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public GestionSeguridad(IRepositorioRol repositorioRol,
                                IRepositorioOficina repositorioUsuarios,
                                IRepositorioMenu repositorioMenu,
                                IRepositorioPermiso repositorioPermiso,
                                IRepositorioGrupoBAC repositorioGrupoBAC,
                                IRepositorioAdmonControlDual repositorioAdmonControlDual)
        {
            this.repositorioRol = repositorioRol;
            this.repositorioOficina = repositorioUsuarios;
            this.repositorioMenu = repositorioMenu;
            this.repositorioPermiso = repositorioPermiso;
            this.repositorioGrupoBAC = repositorioGrupoBAC;
            this.repositorioAdmonControlDual = repositorioAdmonControlDual;
        }

        #endregion

        #region Metodos Publicos

        #region Rol

        /// <summary>
        /// Inserts the role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public BancaSeguros.Entidades.General.Resultado InsertarRol(Rol rol)
        {
            BancaSeguros.Entidades.General.Resultado resultado = new BancaSeguros.Entidades.General.Resultado();
            try
            {
                if (rol.Menus != null && rol.Menus.Count > 0)
                    rol.Menus.AddRange(this.ObtenerMenusPrincipales(rol.Menus));

                resultado = this.repositorioRol.InsertarRol(rol);
                resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoAdminitracionRoles), BAC.Seguridad.Configuraciones.LlavesAplicacion.InsertarRol);
            }
            catch (Exception exc)
            {
                resultado = ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoAdminitracionRoles), exc, BAC.Seguridad.Configuraciones.LlavesAplicacion.CatchInsertarRol);
            }
            return resultado;
        }

        /// <summary>
        /// Update the role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>Result Object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public BancaSeguros.Entidades.General.Resultado ActualizarRol(Rol rol)
        {
            BancaSeguros.Entidades.General.Resultado resultado = new BancaSeguros.Entidades.General.Resultado();
            try
            {
                if (rol.Menus != null && rol.Menus.Count > 0)
                    rol.Menus.AddRange(this.ObtenerMenusPrincipales(rol.Menus));

                resultado = this.repositorioRol.ActualizarRol(rol);
                resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoAdminitracionRoles), BAC.Seguridad.Configuraciones.LlavesAplicacion.ActualizarRol);
            }
            catch (Exception exc)
            {
                resultado = ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoAdminitracionRoles), exc, BAC.Seguridad.Configuraciones.LlavesAplicacion.CatchActualizarRol);
            }
            return resultado;
        }

        /// <summary>
        /// Get the role.
        /// </summary>
        /// <param name="nombre">The name.</param>
        /// <param name="estado">The estate.</param>
        /// <returns>List Entity role</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Rol> ObtenerRoles(string nombre, string estado)
        {
            return this.repositorioRol.ObtenerRoles(nombre, estado);
        }

        /// <summary>
        /// Get the complete roles.
        /// </summary>
        /// <param name="nombre">The name.</param>
        /// <param name="estado">The state.</param>
        /// <returns>List of Roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 11/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Rol> ObtenerRolesCompletos(string nombre, string estado)
        {
            List<Rol> roles = this.repositorioRol.ObtenerRoles(nombre, estado);
            foreach (Rol item in roles)
            {
                item.GruposBAC = this.repositorioGrupoBAC.ConsultarGrupoPorRol(item).ToList();
                item.Menus = this.ObtenerFuncionesMenuPorRol(item).ToList();
            }

            return roles;
        }



        #endregion

        #region Permisos

        /// <summary>
        /// Add the permission.
        /// </summary>
        /// <param name="permiso">The permission.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public BancaSeguros.Entidades.General.Resultado AsignarPermiso(Permisos permiso)
        {
            return this.repositorioPermiso.InsertarPermiso(permiso);
        }

        /// <summary>
        /// Deletes the permissions.
        /// </summary>
        /// <param name="permiso">The permission.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public BancaSeguros.Entidades.General.Resultado EliminarPermiso(Permisos permiso)
        {
            return this.repositorioPermiso.EliminarPermiso(permiso);
        }

        #endregion

        #region Menu

        /// <summary>
        /// get the menu.
        /// </summary>
        /// <returns>Return boolean</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Menu> ObtenerMenu()
        {
            return this.repositorioMenu.ObtenerMenu();
        }

        /// <summary>
        /// Get the menu of role.
        /// </summary>
        /// <param name="roles">The role.</param>
        /// <returns>Return boolean</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Menu> ObtenerMenuPorRol(List<Rol> roles)
        {
            List<Menu> menu = new List<Menu>();

            if (roles == null)
            {
                return menu;
            }

            foreach (var rol in roles)
            {
                menu.AddRange(this.repositorioMenu.ObtenerMenuPorRol(rol.IdRol));
            }

            menu = menu.GroupBy(x => x.IdMenu).Select(s => s.First()).ToList();
            menu = menu.OrderBy(x => x.IdMenu).ToList();

            return menu;
        }

        /// <summary>
        /// Get the menu functions.
        /// </summary>
        /// <returns>List of menu functions</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Menu> ObtenerFuncionesMenu()
        {
            List<Menu> funcionesMenu = new List<Menu>();
            List<Menu> registrosMenu = this.repositorioMenu.ObtenerMenu();
            foreach (Menu registro in registrosMenu)
            {
                if (registro.IdMenu != registro.IdPadre)
                {
                    registro.Nombre = this.ObtenerNombrefuncionMenu(registrosMenu, registro);
                    funcionesMenu.Add(registro);
                }
            }

            return funcionesMenu;
        }

        /// <summary>
        /// Get the menu functions by role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>List of menu functions</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<Menu> ObtenerFuncionesMenuPorRol(Rol rol)
        {
            List<Menu> funcionesMenu = new List<Menu>();
            List<Menu> registrosMenu = this.repositorioMenu.ObtenerMenu();
            List<Menu> registrosMenuRol = this.repositorioMenu.ObtenerMenuPorRol(rol.IdRol);
            foreach (Menu registro in registrosMenuRol)
            {
                if (registro.IdMenu != registro.IdPadre)
                {
                    registro.Nombre = this.ObtenerNombrefuncionMenu(registrosMenu, registro);
                    funcionesMenu.Add(registro);
                }
            }

            return funcionesMenu;
        }

        /// <summary>
        /// Search the menus dual approval.
        /// </summary>
        /// <returns>List of menus</returns>
        public IList<Menu> ConsultaMenusAprobacionDualPorRol(int idRol)
        {
            return this.repositorioMenu.ConsultaMenusAprobacionDualPorRol(idRol);
        }

        /// <summary>
        /// Gets the menus approval dual by roles.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        public IList<Menu> ConsultarMenusAprobacionDualPorRoles(List<Rol> roles)
        {
            List<Menu> menus = new List<Menu>();
            foreach (Rol rol in roles)
            {
                menus.AddRange(this.repositorioMenu.ConsultaMenusAprobacionDualPorRol(rol.IdRol));
            }

            List<Menu> resultado = menus.GroupBy(p => p.IdMenu).Select(g => g.First()).ToList();
            return resultado;
        }

        /// <summary>
        /// Search the menus required dual approval.
        /// </summary>
        /// <returns>List of menus</returns>
        public IList<Menu> ConsultaMenusRequiereDualPorRol(int idRol)
        {
            return this.repositorioMenu.ConsultaMenusRequiereDualPorRol(idRol);
        }

        /// <summary>
        /// Gets the menus required approval dual by roles.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        public IList<Menu> ConsultarMenusRequiereDualPorRoles(List<Rol> roles)
        {
            List<Menu> menus = new List<Menu>();
            foreach (Rol rol in roles)
            {
                menus.AddRange(this.repositorioMenu.ConsultaMenusRequiereDualPorRol(rol.IdRol));
            }

            List<Menu> resultado = menus.GroupBy(p => p.IdMenu).Select(g => g.First()).ToList();
            return resultado;
        }


        #endregion

        #region Administracion Control Dual
        /// <summary>
        /// get the items of menu.
        /// </summary>
        /// <returns>Return boolean</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Menu> ConsultarMenuControlDual()
        {
            return this.repositorioAdmonControlDual.ConsultarMenuControlDual();
        }

        /// <summary>
        /// get the roles.
        /// </summary>
        /// <returns>Return boolean</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> ConsultarAdmonControlDual()
        {
            return this.repositorioAdmonControlDual.ConsultarAdmonControlDual();
        }


        /// <summary>
        /// get the roles.
        /// </summary>
        /// <returns>Return boolean</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 15/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> ConsultarAdmonControlDualIdMenu(int idMenu)
        {
            return this.repositorioAdmonControlDual.ConsultarAdmonControlDualIdMenu(idMenu);
        }

        /// <summary>
        /// Insert the registry of Control Dual.
        /// </summary>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public BancaSeguros.Entidades.General.Resultado InsertarAdmonControlDual(List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> controlDual)
        {
            BancaSeguros.Entidades.General.Resultado resultado = new BancaSeguros.Entidades.General.Resultado();
            try
            {
                resultado = this.repositorioAdmonControlDual.InsertarAdmonControlDual(controlDual);
                resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoAdminitracionControlDual), BAC.Seguridad.Configuraciones.LlavesAplicacion.InsertarAdmControlDual);
            }
            catch (Exception exc)
            {
                resultado = ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoAdminitracionControlDual), exc, BAC.Seguridad.Configuraciones.LlavesAplicacion.CatchInsertarAdmControlDual);
            }
            return resultado;
        }

        /// <summary>
        /// Update the registry of Control Dual.
        /// </summary>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 15/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public BancaSeguros.Entidades.General.Resultado ActualizarAdmonControlDual(List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> controlDual)
        {
            BancaSeguros.Entidades.General.Resultado resultado = new BancaSeguros.Entidades.General.Resultado();
            try
            {
                resultado = this.repositorioAdmonControlDual.ActualizarAdmonControlDual(controlDual);
                resultado = ControlMensajes.ConsultarMensajePorLlave(int.Parse(LlavesAplicacion.EventoAdminitracionControlDual), BAC.Seguridad.Configuraciones.LlavesAplicacion.ActualizarAdmControlDual);
            }
            catch (Exception exc)
            {
                resultado = ControlMensajes.GuardarError(int.Parse(LlavesAplicacion.EventoAdminitracionControlDual), exc, BAC.Seguridad.Configuraciones.LlavesAplicacion.CatchActualizarAdmControlDual);
            }
            return resultado;
        }

        /// <summary>
        /// Required the autorizacion dual.
        /// </summary>
        /// <param name="rolesUsuario">The roles user.</param>
        /// <param name="idMenu">The identifier menu.</param>
        /// <returns>if the dual approval is requiered value</returns>
        public bool RequiereAutorizacionDual(List<Rol> rolesUsuario, int idMenu)
        {
            bool requiereAutorizacion = true;
            List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> administraciones = this.repositorioAdmonControlDual.ConsultarAdmonControlDualIdMenu(idMenu);
            if (administraciones != null && administraciones.Count > 0)
            {
                foreach (Rol rol in rolesUsuario)
                {
                    List<Menu> menusRol = this.ObtenerFuncionesMenuPorRol(rol).ToList();
                    var menuValidacion = (from x in menusRol where x.IdMenu == idMenu select x).FirstOrDefault();
                    if (menuValidacion != null) //si el rol del usuario tiene el menu a validar
                    {
                        var rolRequiere = (from x in administraciones where x.IdRol == rol.IdRol && x.Requiere == true select x).FirstOrDefault();
                        //Si uno de los roles del usuario no requiere autorizacion el usuario no requiere autorizacion dual para el menu
                        if (rolRequiere == null)
                        {
                            requiereAutorizacion = false;
                            break;
                        }
                    }
                }

            }
            else
            {
                requiereAutorizacion = false;
            }

            return requiereAutorizacion;
        }

        /// <summary>
        /// Validate the authorizer dual.
        /// </summary>
        /// <param name="rolesUsuario">The roles user.</param>
        /// <param name="idMenu">The identifier menu.</param>
        /// <returns>if the authorizer dual is valid</returns>
        public bool ValidarAutorizadorDual(List<Rol> rolesUsuario)
        {
            bool autorizador = false;
            List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> administraciones = this.repositorioAdmonControlDual.ConsultarAdmonControlDual();
            if (administraciones != null && administraciones.Count > 0)
            {
                foreach (Rol rol in rolesUsuario)
                {
                    var rolAutorizador = (from x in administraciones where x.IdRol == rol.IdRol && x.Autoriza == true select x).FirstOrDefault();
                    if (rolAutorizador != null) //si el rol es autorizador dual
                    {
                        autorizador = true;
                        break;
                    }
                }

            }

            return autorizador;
        }

        #endregion

        #endregion

        #region Metodos Privados

        /// <summary>
        /// Gets the menu function name.
        /// </summary>
        /// <param name="menus">The menus.</param>
        /// <param name="opcionMenu">The menu option.</param>
        /// <returns>Name of function</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string ObtenerNombrefuncionMenu(List<Menu> menus, Menu opcionMenu)
        {
            if (opcionMenu.IdMenu == opcionMenu.IdPadre)
            {
                return opcionMenu.Nombre;
            }
            else
            {
                var padre = (from x in menus where x.IdMenu == opcionMenu.IdPadre select x).FirstOrDefault();
                return this.ObtenerNombrefuncionMenu(menus, padre) + "->" + opcionMenu.Nombre;
            }
        }

        /// <summary>
        /// Gets the menu principal.
        /// </summary>
        /// <param name="menus">The menus.</param>
        /// <param name="opcionMenu">The option menu.</param>
        /// <returns>Principal menu</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Menu ObtenerMenuPrincipal(List<Menu> menus, Menu opcionMenu)
        {
            if (opcionMenu.IdMenu == opcionMenu.IdPadre)
            {
                return opcionMenu;
            }
            else
            {
                var padre = (from x in menus where x.IdMenu == opcionMenu.IdPadre select x).FirstOrDefault();
                if (padre != null)
                {
                    return this.ObtenerMenuPrincipal(menus, padre);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the menus principals.
        /// </summary>
        /// <param name="menus">The menus.</param>
        /// <returns>Principal menus</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 05/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private List<Menu> ObtenerMenusPrincipales(List<Menu> menus)
        {
            List<Menu> menusCompletos = this.repositorioMenu.ObtenerMenu();
            List<Menu> menusPrincipales = new List<Menu>();
            foreach (Menu menu in menus)
            {
                var menuSeleccionado = (from x in menusCompletos where x.IdMenu == menu.IdMenu select x).FirstOrDefault();
                if (menuSeleccionado != null)
                {
                    Menu principal = this.ObtenerMenuPrincipal(menusCompletos, menuSeleccionado);
                    var menuExistente = (from x in menusPrincipales where x.IdMenu == principal.IdMenu select x).FirstOrDefault();
                    if (menuExistente == null)
                    {
                        menusPrincipales.Add(principal);
                    }
                }
            }

            return menusPrincipales;
        }

        #endregion
    }
}
