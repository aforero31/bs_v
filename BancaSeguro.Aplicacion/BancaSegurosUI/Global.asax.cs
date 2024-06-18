using BAC.EntidadesSeguridad;
using Resources;
using System;
using System.Configuration;
using System.Globalization;
using System.Web;

namespace BancaSegurosUI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //No requiere implementación especial
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //No requiere implementación especial
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //No requiere implementación especial
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //No requiere implementación especial
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //No requiere implementación especial
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //No requiere implementación especial
        }

        protected void Application_End(object sender, EventArgs e)
        {
            //No requiere implementación especial
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
           
            if (context.Session != null && context.Session["Usuario"] != null) 
            {
                Usuario usuarioSession = (Usuario)context.Session["Usuario"];
                    
                RefreshTokenResultado validarRefrescoToken = ValidarTokenUsuario(usuarioSession);

                if (validarRefrescoToken == null)
                {
                    this.Session.Abandon();
                }
                else
                {
                    if (validarRefrescoToken.Token != null && validarRefrescoToken.Token != usuarioSession.Token)
                    {
                        usuarioSession.Token = validarRefrescoToken.Token;
                        usuarioSession.Expiracion = validarRefrescoToken.Expiracion;
                        usuarioSession.FechaExpiracionToken = validarRefrescoToken.FechaExpiracionToken;

                        context.Session["Usuario"] = usuarioSession;
                    }
                }
            }
        }

        public static RefreshTokenResultado ValidarTokenUsuario(Usuario usuario)
        {
            RefreshTokenResultado resultado = new RefreshTokenResultado();
            if (usuario == null)
            {
                resultado = null;
                return resultado;
            }

            TimeSpan timeLeftToken = usuario.FechaExpiracionToken.Subtract(DateTime.Now);
            int MinimaVigenciaToken = Convert.ToInt16(ConfigurationManager.AppSettings.Get(Parametros.MinimaVigenciaToken), CultureInfo.InvariantCulture);

            if (timeLeftToken.TotalMinutes > 0)
            {
                if(timeLeftToken.TotalMinutes <= MinimaVigenciaToken)
                {
                    resultado = BancaSegurosUI.App_Code.AdministradorProxy.ObtenerClienteSeguridad().ObtenerRefreshToken(usuario);
                }
            }
            else
            {
                resultado = null;
            }

            return resultado;
        }

        public static RefreshTokenResultado ObtenerRefreshToken(Usuario usuario)
        {
            RefreshTokenResultado resultado = BancaSegurosUI.App_Code.AdministradorProxy.ObtenerClienteSeguridad().ObtenerRefreshToken(usuario);
            return resultado;
        }
    }
}