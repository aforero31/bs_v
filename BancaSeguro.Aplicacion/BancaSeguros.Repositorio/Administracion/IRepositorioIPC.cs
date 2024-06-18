namespace BancaSeguros.Repositorio.Administracion
{
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using System.Collections.Generic;
    public interface IRepositorioIPC
    {
        /// <summary>
        /// Save IPC.
        /// </summary>
        /// <param name="canalVenta">The IPC.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        Resultado GuardarIPC(IPC ipc);

        /// <summary>
        /// Update IPC.
        /// </summary>
        /// <param name="canalVenta">The IPC.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        Resultado ActualizaIPC(IPC ipc);

        /// <summary>
        /// Obtain IPC.
        /// </summary>
        /// <param name="canalVenta">The IPC.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        IPC ConsultarIPC();
    }
}
