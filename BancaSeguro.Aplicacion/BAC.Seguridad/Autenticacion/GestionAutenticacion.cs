//-----------------------------------------------------------------------
// <copyright file="GestionAutenticacion.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BAC.Seguridad.Autenticacion
{
    using System.Linq;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Repositorio.Seguridad;
    using EntidadesSeguridad;
   
    /// <summary>
    /// Class management authentication
    /// </summary>
    public class GestionAutenticacion : IGestionAutenticacion
    {
        #region Variables

        /// <summary>
        /// Repository office
        /// </summary>
        private IRepositorioOficina repositorioOficina;

        /// <summary>
        /// Repository role
        /// </summary>
        private IRepositorioRol repositorioRol;

        /// <summary>
        /// entity directory active
        /// </summary>
        private DirectorioActivo.DirectorioActivo directorioActivo;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionAutenticacion"/> class.
        /// </summary>
        /// <param name="repositorioUsuarios">the repository user</param>
        /// <param name="repositorioRol">the repository role</param>
        public GestionAutenticacion(IRepositorioOficina repositorioUsuarios, IRepositorioRol repositorioRol)
        {
            this.repositorioOficina = repositorioUsuarios;
            this.repositorioRol = repositorioRol;
            this.directorioActivo = new DirectorioActivo.DirectorioActivo(this.repositorioOficina);
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Method for authentication user
        /// </summary>
        /// <param name="usuario">the user</param>
        /// <returns>Entity authentication user</returns>
        public AutenticacionUsuario AutenticarUsuario(Usuario usuario)
        {
            BAC.EntidadesSeguridad.AutenticacionUsuario autenticacion = new EntidadesSeguridad.AutenticacionUsuario();
            autenticacion.Resultado = new Resultado();
            autenticacion.Usuario = new Usuario();
            autenticacion.Usuario.Contrasena = usuario.Contrasena;
            autenticacion.Usuario.Login = usuario.Login;

            autenticacion = this.directorioActivo.AutenticarUsuario(autenticacion);

            if (!autenticacion.Resultado.Error)
            {
                if (autenticacion.Usuario.Grupo.Count() > 0)
                {
                    autenticacion = this.repositorioRol.ConsultarRolPorGrupo(autenticacion);
                }
                else
                {
                    autenticacion.Resultado.Mensaje = "Usuario sin grupo asociado en el Banco";
                }
            }
            else
            {
                //if (autenticacion.Resultado.Mensaje.Contains("Logon failure"))
                if (autenticacion.Resultado.Mensaje.Contains("The user name or password is incorrect") || (autenticacion.Resultado.Mensaje.Contains("Logon failure")))
                {
                    autenticacion.Resultado.Error = true ;
                    autenticacion.Resultado.Mensaje = "Usuario o Contraseña inválida";
                }
                else
                {
                    autenticacion.Resultado.Error = true;
                }
            }

            return autenticacion;
        }

        /// <summary>
        /// Method get assessor
        /// </summary>
        /// <param name="asesor">the assessor</param>
        /// <returns>Entity assessor</returns>
        public Asesor ConsultarAsesor(Asesor asesor)
        {
            Asesor asesorDevuelto = new Asesor();
            Oficina oficina = new Oficina();

            asesorDevuelto = this.directorioActivo.ConsultarAsesor(asesor);

            if (asesorDevuelto != null && !string.IsNullOrEmpty(asesorDevuelto.IdAsesor))
            {
                oficina = this.ConsultarOficinaPorCodigo(asesorDevuelto.Oficina.IdOficina);
            }
            else
            {
                asesorDevuelto = new Asesor();
            }

            if (oficina != null)
            {
                asesorDevuelto.Oficina = oficina;
            }

            return asesorDevuelto;
        }

        #region Oficina

        /// <summary>
        /// Consult the office of code.
        /// </summary>
        /// <param name="idOficina">The identifier office.</param>
        /// <returns>Return boolean</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Oficina ConsultarOficinaPorCodigo(int idOficina)
        {
            return this.repositorioOficina.ConsultarOficinaPorCodigo(idOficina);
        }

        #endregion

        #endregion
    }
}
