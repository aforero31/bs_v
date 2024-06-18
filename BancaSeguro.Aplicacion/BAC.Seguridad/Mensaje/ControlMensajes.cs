

namespace BAC.Seguridad.Mensaje
{
    using Configuraciones;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Repositorio.Administracion;
    using BancaSeguros.Repositorio.Log;
    using System;

    public static class ControlMensajes
    {
        public static IRepositorioLog repositorioLog;
        public static IRepositorioMensaje repositorioMensaje;

        public static Resultado GuardarError(int evento, Exception exc, string llave)
        {
            Mensaje mensaje = new BancaSeguros.Entidades.General.Mensaje();
            Resultado resultado = new Resultado();

            Int64 CodLogError = 0;
            try
            {
                mensaje = repositorioMensaje.ConsultarMensajePorId(evento, llave);
                System.Text.StringBuilder s = new System.Text.StringBuilder();
                if (exc != null)
                {
                    while (exc != null)
                    {
                        s.AppendLine("Exception type: " + exc.GetType().FullName);
                        s.AppendLine("Message       : " + exc.Message);
                        s.AppendLine("Stacktrace:");
                        s.AppendLine(exc.StackTrace);
                        s.AppendLine();
                        exc = exc.InnerException;
                    }
                    CodLogError = repositorioLog.GuardarError(s.ToString());
                }

                resultado.Error = true;

                if (mensaje != null)
                {
                    resultado.Mensaje = CodLogError.ToString() + " " + llave + " " + mensaje.DescripcionMensaje;
                    resultado.IdTipoMensaje = mensaje.IdTipoMensaje;
                }
                else
                {
                    resultado.Mensaje = CodLogError.ToString() + " " + llave + " " + Mensajes.MensajeNoParametrizado;
                }
            }
            catch (Exception exception)
            {
                resultado.Error = true;
                resultado.Mensaje = "00 " + llave + exception.Message;
            }
            return resultado;
        }

        public static Resultado ConsultarMensajePorLlave(int evento, string llave)
        {
            string llaveEntera = string.Empty;
            if (llave.Contains("Error Cobis - "))
                llaveEntera = llave.Substring(llave.IndexOf("Error Cobis - ") + 14);
            else
                llaveEntera = llave;


            Mensaje mensaje = new BancaSeguros.Entidades.General.Mensaje();
            Resultado resultado = new Resultado();
            try
            {
                mensaje = repositorioMensaje.ConsultarMensajePorId(evento, llaveEntera);

                if (mensaje != null)
                {
                    resultado.Mensaje = llave + " " + mensaje.DescripcionMensaje;
                    resultado.IdTipoMensaje = mensaje.IdTipoMensaje;
                }
                else
                {
                    resultado.Mensaje = llave + " " + Mensajes.MensajeNoParametrizado;
                    resultado.IdTipoMensaje = int.Parse(Parametros.IdTipoMensajeInformativo);
                }

            }
            catch (Exception exception)
            {
                resultado.Error = true;
                resultado.Mensaje = "00 " + llave + exception.Message;
            }

            return resultado;
        }
    }
}
