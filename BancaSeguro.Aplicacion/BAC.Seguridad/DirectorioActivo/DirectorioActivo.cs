using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.DirectoryServices;
using BAC.EntidadesSeguridad;
using BancaSeguros.Entidades.Venta;

namespace BAC.Seguridad.DirectorioActivo
{
    public class DirectorioActivo
    {
        #region Variables

        private BancaSeguros.Repositorio.Seguridad.IRepositorioOficina repositorioOficina;

        #endregion

        #region Constructor

        public DirectorioActivo(BancaSeguros.Repositorio.Seguridad.IRepositorioOficina repositorioUsuarios)
        {
            this.repositorioOficina = repositorioUsuarios;
        }

        #endregion

        #region Metodos publicos

        public AutenticacionUsuario AutenticarUsuario(AutenticacionUsuario autenticacion)
        {
            int codigoOficina = int.Parse(Configuraciones.Parametros.NoExisteOficina);
            int oficinaAsignada = 0;
            string strCodigoOficina = string.Empty;
            string[] valoresGrupo = null;
            string[] valoresNombreGrupo = null;
            int identificacionAsesor = 0;
            autenticacion.Usuario.Grupo = new List<GrupoBAC>();

            try
            {
                string dominio = ConfigurationManager.AppSettings.Get(Configuraciones.Parametros.domain);
                string ruta = ConfigurationManager.AppSettings.Get(Configuraciones.Parametros.lDAP);
                string nombreUsuario = dominio + @"\" + autenticacion.Usuario.Login;

                using (DirectoryEntry entrada = new DirectoryEntry(ruta, nombreUsuario, autenticacion.Usuario.Contrasena))
                {
                    DirectorySearcher buscador = new DirectorySearcher(entrada);

                    buscador.Filter = string.Format(Configuraciones.Parametros.FiltroId, autenticacion.Usuario.Login);

                    buscador.PropertiesToLoad.Add(Configuraciones.Parametros.PropiedadDirectorio1);
                    buscador.PropertiesToLoad.Add(Configuraciones.Parametros.PropiedadDirectorio2);
                    buscador.PropertiesToLoad.Add(Configuraciones.Parametros.PropiedadDirectorio3);
                    buscador.PropertiesToLoad.Add(Configuraciones.Parametros.PropiedadDirectorio4);
                    buscador.PropertiesToLoad.Add(Configuraciones.Parametros.PropiedadDirectorio5);
                    buscador.PropertiesToLoad.Add(Configuraciones.Parametros.PropiedadDirectorio6);

                    DirectoryEntry usuarioDA = null;
                    usuarioDA = buscador.FindOne().GetDirectoryEntry();

                    if (usuarioDA.Properties[Configuraciones.Parametros.PropiedadBusqueda].Count > 0)
                    {
                        foreach (String valoresg in usuarioDA.Properties[Configuraciones.Parametros.PropiedadBusqueda])
                        {
                            valoresGrupo = valoresg.Split(',');
                            if (valoresGrupo.Length > 0)
                            {
                                valoresNombreGrupo = valoresGrupo[0].Split('=');

                                bool validarG = valoresNombreGrupo[1].Contains(Configuraciones.Parametros.GruposBusqueda1);
                                bool validarU = valoresNombreGrupo[1].Contains(Configuraciones.Parametros.GruposBusqueda2);
                                bool validarL = valoresNombreGrupo[1].Contains(Configuraciones.Parametros.GruposBusqueda3);

                                if (valoresNombreGrupo.Length > 1 && (validarG || validarU || validarL))
                                {
                                    strCodigoOficina = validarG ? valoresNombreGrupo[1].Replace(Configuraciones.Parametros.GruposBusqueda1, "") : strCodigoOficina;
                                    strCodigoOficina = validarU ? valoresNombreGrupo[1].Replace(Configuraciones.Parametros.GruposBusqueda2, "") : strCodigoOficina;
                                    strCodigoOficina = validarL ? valoresNombreGrupo[1].Replace(Configuraciones.Parametros.GruposBusqueda3, "") : strCodigoOficina;

                                    if (int.TryParse(strCodigoOficina, out codigoOficina) == true)
                                    {
                                        oficinaAsignada = codigoOficina;
                                    }
                                    else
                                    {
                                        GrupoBAC grupo = new GrupoBAC();
                                        grupo.NombreGrupo = strCodigoOficina;
                                        grupo.CodigoGrupo = Configuraciones.Parametros.GrupoAplicacion;

                                        autenticacion.Usuario.Grupo.Add(grupo);
                                    }
                                }
                            }
                        }

                        autenticacion.Usuario.Nombres = usuarioDA.Properties[Configuraciones.Parametros.PropiedadDirectorio4].Value.ToString() + " " + usuarioDA.Properties["SN"].Value.ToString();
                        int.TryParse(usuarioDA.Properties[Configuraciones.Parametros.PropiedadDirectorio3].Value.ToString(), out identificacionAsesor);
                        autenticacion.Usuario.Identificacion = identificacionAsesor;
                        autenticacion.Usuario.Oficina = new Oficina();
                        autenticacion.Usuario.Oficina.IdOficina = oficinaAsignada;
                        autenticacion.Usuario.Oficina.Nombre = this.repositorioOficina.ConsultarOficinaPorCodigo(oficinaAsignada).Nombre;
                    }
                }

            }
            catch (Exception ex)
            {
                autenticacion.Resultado.Error = true;
                autenticacion.Resultado.Mensaje = ex.Message;
            }

            return autenticacion;
        }

        /// <summary>
        /// Se obtiene y valida el codigo de la oficina del usuario informado en Directorio Activo 
        /// </summary>
        /// <param name="usuario">entrada usuario</param>
        /// <returns>Codigo oficina</returns>
        private int ObtenerCodigoOficina(DirectoryEntry usuario)
        {
            int codigoOficina = int.Parse(Configuraciones.Parametros.NoExisteOficina);
            int oficinaAsignada = 0;
            string strCodigoOficina = string.Empty;
            string[] valoresGrupo = null;
            string[] valoresNombreGrupo = null;

            if (usuario.Properties[Configuraciones.Parametros.PropiedadBusqueda].Count > 0)
            {
                foreach (String valoresg in usuario.Properties[Configuraciones.Parametros.PropiedadBusqueda])
                {
                    valoresGrupo = valoresg.Split(',');
                    if (valoresGrupo.Length > 0)
                    {
                        valoresNombreGrupo = valoresGrupo[0].Split('=');

                        bool validarG = valoresNombreGrupo[1].Contains(Configuraciones.Parametros.GruposBusqueda1);
                        bool validarU = valoresNombreGrupo[1].Contains(Configuraciones.Parametros.GruposBusqueda2);
                        bool validarL = valoresNombreGrupo[1].Contains(Configuraciones.Parametros.GruposBusqueda3);

                        if (valoresNombreGrupo.Length > 1 && (validarG || validarU || validarL))
                        {
                            strCodigoOficina = validarG ? valoresNombreGrupo[1].Replace(Configuraciones.Parametros.GruposBusqueda1, "") : strCodigoOficina;
                            strCodigoOficina = validarU ? valoresNombreGrupo[1].Replace(Configuraciones.Parametros.GruposBusqueda2, "") : strCodigoOficina;
                            strCodigoOficina = validarL ? valoresNombreGrupo[1].Replace(Configuraciones.Parametros.GruposBusqueda3, "") : strCodigoOficina;
                            if (int.TryParse(strCodigoOficina, out codigoOficina) == true)
                            {
                                oficinaAsignada = codigoOficina;

                            }
                        }
                    }
                }
            }
            return oficinaAsignada;
        }

        /// <summary>
        /// Realiza la autenticación contra el directorio activo
        /// </summary>
        /// <returns></returns>
        public Asesor ConsultarAsesor(Asesor _asesor)
        {
            string dominio = ConfigurationManager.AppSettings.Get(Configuraciones.Parametros.domain);
            string ruta = ConfigurationManager.AppSettings.Get(Configuraciones.Parametros.lDAP);
            string usuario = ConfigurationManager.AppSettings.Get(Configuraciones.Parametros.DAUser);
            string contrasena = ConfigurationManager.AppSettings.Get(Configuraciones.Parametros.DAPwd);
            string nombreUsuario = dominio + @"\" + usuario;
            int identificacionAsesor = 0;
            string filtroDAUsuario = string.Empty;
            string filtroDAIdenti = string.Empty;
            Asesor asesor = new Asesor();

            using (DirectoryEntry entrada = new DirectoryEntry(ruta, nombreUsuario, contrasena))
            {
                if (string.IsNullOrEmpty(_asesor.IdAsesor) && string.IsNullOrEmpty(_asesor.Identificacion.ToString()))
                    return null;

                DirectorySearcher buscador = new DirectorySearcher(entrada);

                try
                {
                    filtroDAIdenti = _asesor.Identificacion.Equals(int.Parse(Configuraciones.Parametros.NoExisteOficina)) ? "*" : _asesor.Identificacion.ToString();
                    filtroDAUsuario = string.IsNullOrEmpty(_asesor.IdAsesor) ? "*" : _asesor.IdAsesor;
                    buscador.Filter = string.Format(Configuraciones.Parametros.FiltroConCedula, filtroDAUsuario, filtroDAIdenti);
                    buscador.PropertiesToLoad.Add(Configuraciones.Parametros.PropiedadDirectorio1);
                    buscador.PropertiesToLoad.Add(Configuraciones.Parametros.PropiedadDirectorio2);
                    buscador.PropertiesToLoad.Add(Configuraciones.Parametros.PropiedadDirectorio3);
                    buscador.PropertiesToLoad.Add(Configuraciones.Parametros.PropiedadDirectorio4);
                    buscador.PropertiesToLoad.Add(Configuraciones.Parametros.PropiedadDirectorio5);
                    buscador.PropertiesToLoad.Add(Configuraciones.Parametros.PropiedadDirectorio6);

                    DirectoryEntry usuarioDA = null;
                    usuarioDA = buscador.FindOne().GetDirectoryEntry();

                    if (usuarioDA.Properties[Configuraciones.Parametros.PropiedadBusqueda].Count > 0)
                    {
                        asesor.IdAsesor = usuarioDA.Properties[Configuraciones.Parametros.FiltroDirectorio].Value.ToString();
                        asesor.Nombre = usuarioDA.Properties[Configuraciones.Parametros.PropiedadDirectorio4].Value.ToString() + " " + usuarioDA.Properties[Configuraciones.Parametros.PropiedadDirectorio6].Value.ToString();
                        int.TryParse(usuarioDA.Properties[Configuraciones.Parametros.PropiedadDirectorio3].Value.ToString(), out identificacionAsesor);
                        asesor.Identificacion = identificacionAsesor;
                        asesor.Oficina = new Oficina();
                        asesor.Oficina.IdOficina = ObtenerCodigoOficina(usuarioDA);
                    }
                }
                catch (Exception)
                {
                    asesor = new Asesor();
                }

            }
            return asesor;
        }

        #endregion
    }
}



