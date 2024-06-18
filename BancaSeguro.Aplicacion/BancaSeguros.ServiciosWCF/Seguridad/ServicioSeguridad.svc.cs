using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BAC.Seguridad;
using BAC.EntidadesSeguridad;
using BancaSeguros.Repositorio.Seguridad;
using BancaSeguros.Entidades.Venta;
using BAC.Seguridad.Autenticacion;
using BAC.Seguridad.Seguridad;
using BancaSeguros.Repositorio.Log;
using BancaSeguros.Repositorio.Administracion;
using System.Configuration;


namespace BancaSeguros.ServiciosWCF.Seguridad
{
    public class ServicioSeguridad : IServicioSeguridad, IGestionGrupoBAC
    {
        #region Variables

        private IGestionSeguridad gestionSeguridad;
        private IGestionAutenticacion gestionAutenticacion;
        private IRepositorioRol repositorioRol;
        private IRepositorioOficina repositorioUsuarios;
        private IRepositorioMenu repositorioMenu;
        private IRepositorioPermiso repositorioPermiso;
        private IRepositorioGrupoBAC repositorioGrupoBAC;
        private IRepositorioAdmonControlDual repositorioAdmonControlDual;
        private IRepositorioLog repositorioLog;
        private IRepositorioMensaje repositorioMensaje;
        private IGestionToken gestionToken;
        
        /// <summary>
        /// The gestion grupo bac
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionGrupoBAC gestionGrupoBAC;

        #endregion

        #region Constructor

        public ServicioSeguridad()
        {
            this.repositorioRol = new RepositorioRol(Global.nombreConexionTeradata);
            this.repositorioUsuarios = new RepositorioOficina(Global.nombreConexionTeradata);
            this.repositorioMenu = new RepositorioMenu(Global.nombreConexionTeradata);
            this.repositorioPermiso = new RepositorioPermiso(Global.nombreConexionTeradata);
            this.repositorioGrupoBAC = new RepositorioGrupoBAC(Global.nombreConexionTeradata);
            this.repositorioAdmonControlDual = new RepositorioAdmonControlDual(Global.nombreConexionTeradata);
            this.repositorioLog = new RepositorioLog(Global.nombreConexionTeradata);
            this.repositorioMensaje = new RepositorioMensaje(Global.nombreConexionTeradata);
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioMensaje = this.repositorioMensaje;
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioLog = this.repositorioLog;

            this.gestionSeguridad = new GestionSeguridad(this.repositorioRol, this.repositorioUsuarios, this.repositorioMenu, this.repositorioPermiso, this.repositorioGrupoBAC, this.repositorioAdmonControlDual);
            this.gestionAutenticacion = new GestionAutenticacion(this.repositorioUsuarios, this.repositorioRol);
            this.gestionGrupoBAC = new GestionGrupoBAC(this.repositorioGrupoBAC);

            this.gestionToken = new GestionToken();
          
        }

        #endregion

        #region Metodos Publicos

        #region Usuario

        public AutenticacionUsuario AutenticarUsuario(Usuario usuario)
        {
           
            AutenticacionUsuario autenticacion = this.gestionAutenticacion.AutenticarUsuario(usuario);
            var controlError = Aplicacion.Configuraciones.LlavesAplicacion.ErrorAPISeguridad;
            try
            {
                if (!autenticacion.Resultado.Error)
                {
                    
                    Usuario usuarioConsultaToken = new Usuario();
                    usuarioConsultaToken.Login = ConfigurationManager.AppSettings.Get("DAUser");
                    usuarioConsultaToken.Contrasena = ConfigurationManager.AppSettings.Get("DAPwd");

                    TokenResultado tokenResultado = this.gestionToken.ObtenerGestionToken(usuarioConsultaToken);

                    if (tokenResultado.Resultado.Error)
                    {
                        autenticacion.Resultado.Error = tokenResultado.Resultado.Error;
                        autenticacion.Resultado.Mensaje = tokenResultado.Resultado.Mensaje;
                    }
                    else
                    {
                        autenticacion.Usuario.Token = tokenResultado.TokenResponse.authentication;
                        autenticacion.Usuario.Expiracion = tokenResultado.TokenResponse.expires;
                        autenticacion.Usuario.FechaExpiracionToken = DateTime.Now.AddSeconds(tokenResultado.TokenResponse.expires);

                        if (tokenResultado.TokenResponse.responseCode != "200")
                        {
                            autenticacion.Resultado.Error = tokenResultado.Resultado.Error;
                            autenticacion.Resultado.Mensaje = tokenResultado.Resultado.Mensaje;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                autenticacion.Resultado.Error = true;
                var resultado = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(Aplicacion.Configuraciones.LlavesAplicacion.EventoRegistrarVentaConsultarCliente), ex, controlError);
                autenticacion.Mensaje = resultado.Mensaje;

            }
            return autenticacion;

        }

        public RefreshTokenResultado ObtenerRefreshToken(Usuario usuario)
        {
            return this.gestionToken.ObtenerRefrescoToken(usuario);
        }

        #endregion

        #region Asesor

        public Asesor ConsultarAsesor(Asesor asesor)
        {
            return this.gestionAutenticacion.ConsultarAsesor(asesor);
        }

        #endregion

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
            return this.gestionSeguridad.InsertarRol(rol);
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
            return this.gestionSeguridad.ActualizarRol(rol);
        }

        /// <summary>
        /// Get the roles.
        /// </summary>
        /// <param name="nombre">The name.</param>
        /// <param name="estado">The estate.</param>
        /// <returns>List of Roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Rol> ObtenerRoles(string nombre, string estado)
        {
            return this.gestionSeguridad.ObtenerRoles(nombre, estado);
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
            return this.gestionSeguridad.ObtenerRolesCompletos(nombre, estado);
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

        public List<Menu> ObtenerMenu()
        {
            return this.gestionSeguridad.ObtenerMenu();
        }

        public List<Menu> ObtenerMenuPorRol(List<Rol> roles)
        {
            return this.gestionSeguridad.ObtenerMenuPorRol(roles);
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
            return this.gestionSeguridad.ObtenerFuncionesMenu();
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
            return this.gestionSeguridad.ObtenerFuncionesMenuPorRol(rol);
        }

        /// <summary>
        /// Gets the menus approval dual by roles.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        public IList<Menu> ConsultarMenusAprobacionDualPorRoles(List<Rol> roles)
        {
            return this.gestionSeguridad.ConsultarMenusAprobacionDualPorRoles(roles);
        }

        /// <summary>
        /// Gets the menus required approval dual by roles.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        public IList<Menu> ConsultarMenusRequiereDualPorRoles(List<Rol> roles)
        {
            return this.gestionSeguridad.ConsultarMenusRequiereDualPorRoles(roles);
        }

        #endregion

        #region Oficina

        public Oficina ConsultarOficinaPorCodigo(int idOficina)
        {
            return this.gestionAutenticacion.ConsultarOficinaPorCodigo(idOficina);
        }

        #endregion

        #region GrupoBAC

        /// <summary>
        /// Search the groups.
        /// </summary>
        /// <param name="grupo">The group.</param>
        /// <returns>List of groups</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<GrupoBAC> ConsultarGruposBAC(GrupoBAC grupo)
        {
            return this.gestionGrupoBAC.ConsultarGruposBAC(grupo);
        }

        /// <summary>
        /// Search the group by role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>List of Groups</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<GrupoBAC> ConsultarGrupoPorRol(Rol rol)
        {
            return this.gestionGrupoBAC.ConsultarGrupoPorRol(rol);
        }

        #endregion

        #region Administracion Control Dual
        /// <summary>
        /// Search the items of Menu for fill the DropDownList.
        /// </summary>
        /// <param name="grupo">The items.</param>
        /// <returns>List of items of Menu</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA   
        ///  CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<Menu> ConsultarMenuControlDual()
        {
            return this.gestionSeguridad.ConsultarMenuControlDual();
        }

        /// <summary>
        /// Search the roles for fill the Grid.
        /// </summary>
        /// <param name="grupo">The roles.</param>
        /// <returns>List of roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA   
        ///  CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> ConsultarAdmonControlDual()
        {
            return this.gestionSeguridad.ConsultarAdmonControlDual();
        }


        /// <summary>
        /// Search the roles for fill the Grid.
        /// </summary>
        /// <param name="grupo">The roles.</param>
        /// <returns>List of roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA   
        ///  CreationDate: 15/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> ConsultarAdmonControlDualIdMenu(int idMenu)
        {
            return this.gestionSeguridad.ConsultarAdmonControlDualIdMenu(idMenu);
        }

        /// <summary>
        /// Insert the registry of Control Dual
        /// </summary>
        /// <param name="controlDual">The roles.</param>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA   
        ///  CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public BancaSeguros.Entidades.General.Resultado InsertarAdmonControlDual(List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> controlDual)
        {
            return this.gestionSeguridad.InsertarAdmonControlDual(controlDual);
        }

        /// <summary>
        /// Update the registry of Control Dual
        /// </summary>
        /// <param name="controlDual">The roles.</param>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA   
        ///  CreationDate: 15/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public BancaSeguros.Entidades.General.Resultado ActualizarAdmonControlDual(List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> controlDual)
        {
            return this.gestionSeguridad.ActualizarAdmonControlDual(controlDual);
 
        }

        /// <summary>
        /// Required the autorizacion dual.
        /// </summary>
        /// <param name="rolesUsuario">The roles user.</param>
        /// <param name="idMenu">The identifier menu.</param>
        /// <returns>if the dual approval is requiered value</returns>
        public bool RequiereAutorizacionDual(List<Rol> rolesUsuario, int idMenu)
        {
            return this.gestionSeguridad.RequiereAutorizacionDual(rolesUsuario, idMenu);
        }

        /// <summary>
        /// Validate the authorizer dual.
        /// </summary>
        /// <param name="rolesUsuario">The roles user.</param>
        /// <param name="idMenu">The identifier menu.</param>
        /// <returns>if the authorizer dual is valid</returns>
        public bool ValidarAutorizadorDual(List<Rol> rolesUsuario)
        {
            return this.gestionSeguridad.ValidarAutorizadorDual(rolesUsuario);
        }

        #endregion

        #endregion
    }
}
