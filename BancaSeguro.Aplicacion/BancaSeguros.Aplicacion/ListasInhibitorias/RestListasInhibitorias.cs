using BancaSeguros.Entidades.General;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BancaSeguros.Aplicacion.ListasInhibitorias
{
    class RestListasInhibitorias
    {
        /// <summary>
        /// Realiza la petición utilizando el método POST y devuelve la respuesta del servidor
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetResponse_GET(string url, string token, ContextoTransaccionalAPI contextoTransaccional)
        {
            int eventos = 0;
            string responseFromServer = "";

            do
            {
                try
                {
                    System.Net.WebRequest wr = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                    wr.Method = "GET";
                    wr.ContentType = "application/json";
                    wr.Headers.Add("Authorization", "Bearer " + token);
                    wr.Headers.Add("ContextoTransaccional", Newtonsoft.Json.JsonConvert.SerializeObject(contextoTransaccional));

                    
                    // Obtiene la respuesta
                    using (System.Net.WebResponse response = (System.Net.WebResponse)wr.GetResponse())
                    {
                        // Stream con el contenido recibido del servidor
                        using (Stream streamRs = response.GetResponseStream())
                        {
                            using (System.IO.StreamReader reader = new System.IO.StreamReader(streamRs))
                            {
                                // Leemos el contenido
                                responseFromServer = reader.ReadToEnd();
                                reader.Close();
                            }
                        }
                        // Cerramos los streams
                        response.Close();
                    }
                    return responseFromServer;
                }
                catch (System.Web.HttpException ex)
                {
                    if (ex.ErrorCode == 404)
                        throw new Exception("No se encontró el servidor remoto: " + url);
                    else throw ex;
                }
                catch (Exception exc)
                {
                    eventos += 1;
                    if (eventos == 3)
                    {
                        
                        throw exc;
                    }
                }

            } while (eventos < 3 || responseFromServer != "");

            return string.Empty;
        }

        /// <summary>
        /// Realiza la petición utilizando el método POST y devuelve la respuesta del servidor
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetResponse_POST(string url, string data)
        {
            int eventos = 0;
            string responseFromServer = "";

            do
            {
                try
                {
                    System.Net.WebRequest wr = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                    wr.Method = "POST";
                    wr.ContentType = "application/json";
                    Stream stream = wr.GetRequestStream();
                    StreamWriter streamWriter = new StreamWriter(stream);
                    streamWriter.Write(data);
                    streamWriter.Flush();
                    streamWriter.Close();

                    // Obtiene la respuesta
                    System.Net.HttpWebResponse response = (HttpWebResponse)wr.GetResponse();

                    // Stream con el contenido recibido del servidor
                    using (Stream streamRs = response.GetResponseStream())
                    {
                        System.IO.StreamReader reader = new System.IO.StreamReader(streamRs);
                        // Leemos el contenido
                        responseFromServer = reader.ReadToEnd();
                        reader.Close();
                    }

                    // Cerramos los streams
                    response.Close();
                    return responseFromServer;
                }
                catch (System.Web.HttpException ex)
                {
                    if (ex.ErrorCode == 404)
                        throw new Exception("No se encontró el servidor remoto: " + url);
                    else throw ex;
                }
                catch (Exception exc)
                {
                    //Resp.Error = true;
                    //Resp.Mensaje = exception.Message;
                    eventos += 1;
                    if (eventos == 3)
                    {
                        //throw new Exception(String.Concat("GetResponse_POST: Se generó la excepción - No se pudo consultar el servicio Cobis. - ", exc.Message));
                        return string.Empty;
                    }
                }

            } while (eventos < 3 || responseFromServer != "");

            return string.Empty;
        }

    }
}
