namespace BancaSeguros.ServiciosWCF.Generico
{
    using BAC.Seguridad.Mensaje;
    using Aplicacion;
    using Entidades.Catalogo;
    using Entidades.General;
    using Repositorio;
    using Repositorio.Administracion;
    using Repositorio.Log;
    using System;

    public class ServicioGenerico : IServicioGenerico
    {
        #region Variables

        private IGestionGenerico gestionGenerico;
        private IGestionLog gestionLog;
        private IGestionMensaje gestionMensajeSeguridad;
        private IRepositorioGenerico repositorioGenerico;
        private IRepositorioLog repositorioLog;
        private IRepositorioMensaje repositorioMensaje;

        #endregion

        #region Constructor

        public ServicioGenerico()
        {
            this.repositorioGenerico = new RepositorioGenerico(Global.nombreConexionTeradata);
            this.repositorioLog = new RepositorioLog(Global.nombreConexionTeradata);
            this.repositorioMensaje = new RepositorioMensaje(Global.nombreConexionTeradata);
            ControlMensajes.repositorioMensaje = this.repositorioMensaje;
            ControlMensajes.repositorioLog = this.repositorioLog;

            this.gestionGenerico = new GestionGenerico(this.repositorioGenerico);
            this.gestionLog = new GestionLog(this.repositorioLog);
            this.gestionMensajeSeguridad = new GestionMensaje(this.repositorioMensaje);
        }

        #endregion

        #region Metodos Publicos

        #region Catalogo

        public DtoCatalogo ConsultarCatalogo(string NombreTabla)
        {
            return this.gestionGenerico.ConsultarCatalogo(NombreTabla);
        }
        #endregion

        #region Log

        public Resultado GuardarError(int evento, string excepcion, string llave)
        {
            Exception ex = new Exception(excepcion); 

            return this.gestionLog.GuardarError(evento, ex, llave);
        }

        #endregion

        #region Mensaje

        /// <summary>
        /// Consultars the mensaje por identifier.
        /// </summary>
        /// <param name="llave">The llave.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 30/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado ConsultarMensajePorLlave(int evento, string llave)
        {
            return this.gestionMensajeSeguridad.ConsultarMensajePorLlave(evento, llave);
        }

        #endregion

        #endregion
    }
}
