using BAC.EntidadesSeguridad;
using System;

namespace BAC.Seguridad.Autenticacion
{
    public interface IGestionToken
    {
        TokenResultado ObtenerGestionToken(Usuario usuario);

        RefreshTokenResultado ObtenerRefrescoToken(Usuario usuario);
    }
}
