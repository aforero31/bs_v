namespace BAC.Seguridad.Mensaje
{
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Repositorio.Administracion;
    using BancaSeguros.Repositorio.Log;
    using Configuraciones;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GestionLog : IGestionLog
    {

        #region Variables

        private IRepositorioLog repositorioLog;

        #endregion

        #region Constructor

        public GestionLog(IRepositorioLog repositorioLog)
        {
            this.repositorioLog = repositorioLog;
        }

        #endregion

        public Resultado GuardarError(int evento, Exception exc, string llave)
        {
            Resultado resultado = new Resultado();

            resultado = ControlMensajes.GuardarError(evento, exc, llave);

            return resultado;
        }
    }
}
