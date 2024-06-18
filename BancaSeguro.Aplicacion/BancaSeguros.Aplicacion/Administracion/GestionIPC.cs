
namespace BancaSeguros.Aplicacion.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using BancaSeguros.Aplicacion.Configuraciones;
    using BancaSeguros.Entidades.Administracion;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;
    using BancaSeguros.Infraestructura.ManejoDocumentos;
    using BancaSeguros.Repositorio.Administracion;
    using BancaSeguros.Repositorio.Venta;

    /// <summary>
    /// Interface Management IPC
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA   
    /// CreationDate: 18/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionIPC" />
    public class GestionIPC : IGestionIPC
    {
        #region Variables
        /// <summary>
        /// The repository IPC
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioIPC repositorioIpc;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionIPC"/> class.
        /// </summary>
        /// <param name="interfazRepositorioIPC">The interface repository IPC.</param>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public GestionIPC(IRepositorioIPC interfazRepositorioIPC)
        {
            this.repositorioIpc = interfazRepositorioIPC;
        }

        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Save the IPC.
        /// </summary>
        /// <param name="ipc">The IPC.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public Resultado GuardarIPC(IPC ipc)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioIpc.GuardarIPC(ipc);
                if (resultado.Error)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoParametrizarIPCGuardar), Configuraciones.LlavesAplicacion.InsertarIPCNoExitoso);
                    resultado.Error = true;
                }
                else if (!resultado.Error)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoParametrizarIPCGuardar), Configuraciones.LlavesAplicacion.InsertarIPC);  //Mensajes.Guardado;
                    resultado.Error = false;
                }

            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(Configuraciones.LlavesAplicacion.EventoParametrizarIPCGuardar),  ex, Configuraciones.LlavesAplicacion.CatchInsertarIPC).Mensaje;
            }
            return resultado;
        }

        /// <summary>
        /// Update the IPC.
        /// </summary>
        /// <param name="ipc">The IPC.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public Resultado ActualizaIPC(IPC ipc)
        {
            Resultado resultado = new Resultado();
            try
            {
                return this.repositorioIpc.ActualizaIPC(ipc);
 
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = ex.Message;
            }
            return resultado;
        }

        /// <summary>
        /// Obtain the IPC.
        /// </summary>
        /// <param name="ipc">The IPC.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public IPC ConsultarIPC()
        {
            return this.repositorioIpc.ConsultarIPC();
        }
        #endregion
    }
}
