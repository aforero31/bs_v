//-----------------------------------------------------------------------
// <copyright file="GestionToken.cs" company="InterGrupo 2020">
//     Copyright (c) InterGrupo 2020. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BAC.Seguridad.Autenticacion
{
    using BAC.EntidadesSeguridad;
    using System;
    using System.Configuration;



    /// <summary>
    /// Class Token generation
    /// </summary>
    public class GestionToken : IGestionToken
    {
        #region Variables

        #endregion

        #region Constructor
        
        #endregion

        #region Metodos Publicos
        public TokenResultado ObtenerGestionToken(Usuario usuario)
        {
            TokenResultado tokenResultado = new TokenResultado();
            tokenResultado.Resultado = new Resultado();

            if (usuario  == null)
            {
                tokenResultado.Resultado.Error = true;
                tokenResultado.Resultado.Mensaje = "Error en generación del Token - usuario vacio";
                return tokenResultado; 
            }

            TokenRequest dataToken = new TokenRequest
            {
                userName = usuario.Login,
                userPassword = usuario.Contrasena               
            };

            const string tokenAnterior = "";

            string url = ConfigurationManager.AppSettings.Get("ServicioSeguridadToken");
            string respuestaToken = RestToken.GetResponse_POST(url, Newtonsoft.Json.JsonConvert.SerializeObject(dataToken), tokenAnterior);

            if (respuestaToken == "")
            {
                tokenResultado.Resultado.Error = true;
                tokenResultado.Resultado.Mensaje = "Error en generación del Token";
            }
            else
            {
                TokenResponse tokenResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResponse>(respuestaToken);
                tokenResultado.TokenResponse = tokenResponse;

                if (tokenResultado.TokenResponse.responseCode != "200")
                {
                    tokenResultado.Resultado.Error = true;
                    tokenResultado.Resultado.Mensaje = "Error en generación del Token";
                }
            }
            return tokenResultado;
                                   
        }

        public RefreshTokenResultado ObtenerRefrescoToken(Usuario usuario)
        {
            RefreshTokenResultado tokenResultado = new RefreshTokenResultado();
            tokenResultado.Resultado = new Resultado();

            TokenRequest dataToken = new TokenRequest
            {
                userName = ConfigurationManager.AppSettings.Get("DAUser"),
                userPassword = "***"
            };

            if (usuario == null)
            {
                tokenResultado.Resultado.Error = true;
                tokenResultado.Resultado.Mensaje = "Error en refresco del Token - token vacio";
                return tokenResultado;
            }

            string tokenAnterior = usuario.Token;

            string url = ConfigurationManager.AppSettings.Get("ServicioSeguridadToken");
            string respuestaToken = RestToken.GetResponse_POST(url, Newtonsoft.Json.JsonConvert.SerializeObject(dataToken), tokenAnterior);
            TokenResponse tokenResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResponse>(respuestaToken);

            if (tokenResponse.responseCode != "200")
            {
                tokenResultado.Resultado.Error = true;
                tokenResultado.Resultado.Mensaje = "Error en refresco del Token";
            }
            else
            {
                tokenResultado.Resultado.Error = false;
                tokenResultado.Resultado.Mensaje = "";
                tokenResultado.Token = tokenResponse.authentication;
                tokenResultado.Expiracion = tokenResponse.expires;
                tokenResultado.FechaExpiracionToken = DateTime.Now.AddSeconds(tokenResponse.expires);
            }
            return tokenResultado;

        }

        #endregion
    }
}
