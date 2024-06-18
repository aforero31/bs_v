
namespace BAC.Seguridad.Mensaje
{
    using System.Collections.Generic;
    using BancaSeguros.Entidades.Administracion;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;

    /// <summary>
    /// Interface Message Administration
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    /// CreationDate: 02/06/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionMensaje
    {
        /// <summary>
        /// Obtain the Messages.
        /// </summary>
        /// <param name="idMensaje">The Messages</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 02/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Resultado ConsultarMensajePorLlave(int evento, string llave);
    }
}
