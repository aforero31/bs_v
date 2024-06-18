using BAC.EntidadesSeguridad;
using BancaSeguros.Entidades.Venta;
using System;

namespace BAC.Seguridad.Autenticacion
{
    public interface IGestionAutenticacion
    {
        AutenticacionUsuario AutenticarUsuario(Usuario usuario);

        Asesor ConsultarAsesor(Asesor asesor);

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
        Oficina ConsultarOficinaPorCodigo(int idOficina);
    }
}
