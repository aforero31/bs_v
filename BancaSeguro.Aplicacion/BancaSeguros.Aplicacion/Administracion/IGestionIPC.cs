
namespace BancaSeguros.Aplicacion.Administracion
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.Administracion;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Entidades.Venta;

    /// <summary>
    /// Interface IPC Administration
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    /// CreationDate: 18/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionIPC
    {
        /// <summary>
        /// Save the IPC.
        /// </summary>
        /// <param name="ipc">The IPC</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 18/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        Resultado GuardarIPC(IPC ipc);

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
        Resultado ActualizaIPC(IPC ipc);

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
        IPC ConsultarIPC();
    }
}
