

namespace BancaSeguros.Aplicacion.Administracion
{
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Planos;
    using BancaSeguros.Entidades.Seguro;
    using BancaSeguros.Repositorio.Administracion;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// Interface Management Causal Novelty
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA   
    /// CreationDate: 27/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Aplicacion.Administracion.IGestionParametrizacionPlanos" />
    public class GestionParametrizacionPlanos : IGestionParametrizacionPlanos
    {
        #region Variables
        /// <summary>
        /// The repository Parametrizacion Planos
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioParametrizacionPlanos repositorioParametrizacionPlanos;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionParametrizacionPlanos"/> class.
        /// </summary>
        /// <param name="interfazRepositorioCausalNovedad">The interface repository Parametrizacion Planos.</param>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// 
        public GestionParametrizacionPlanos(IRepositorioParametrizacionPlanos interfazRepositorioParametrizacionPlanos)
        {
            this.repositorioParametrizacionPlanos = interfazRepositorioParametrizacionPlanos;
        }

        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Obtain the Parametrizacion Planos.
        /// </summary>
        /// <param name="causal novelty">The Parametrizacion Planos.</param>
        /// <returns>Entity Result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 12/07/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public List<CamposCobros> ConsultarCobros(int opcion)
        {
            return this.repositorioParametrizacionPlanos.ConsultarCobros(opcion);
        }


        public List<CamposPoliza> ConsultarPolizas(int opcion)
        {
            return this.repositorioParametrizacionPlanos.ConsultarPolizas(opcion);
        }

        public List<CamposCancelaciones> ConsultarCancelaciones(int opcion)
        {
            return this.repositorioParametrizacionPlanos.ConsultarCancelaciones(opcion);
        }

        public List<CamposCancelaciones> ConsultarFiltrosCancelaciones()
        {
            return this.repositorioParametrizacionPlanos.ConsultarFiltrosCancelaciones();
        }

        public Resultado GuardarDatosArchivoPlano(ArchivoPlano datosArchivo)
        {
            Resultado resultado = new Resultado();
            try
            {
                datosArchivo.Programacion = CrearXML(datosArchivo);
                
                resultado = this.repositorioParametrizacionPlanos.GuardarDatosArchivoPlano(datosArchivo);
                if (resultado.Error == false)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoGuardarProgramacionPlano), Configuraciones.LlavesAplicacion.GuardarProgramacionPlano);
                    resultado.Error = false;
                }
                else
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoGuardarProgramacionPlano), Configuraciones.LlavesAplicacion.NoGuardaProgramacionPlano);
                    resultado.Error = true;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(Configuraciones.LlavesAplicacion.EventoGuardarProgramacionPlano), ex, Configuraciones.LlavesAplicacion.CatchGuardarProgramacionPlano).Mensaje;
            }
            return resultado;
        }

        private String CrearXML(ArchivoPlano datosArchivo)
        {
            XmlDocument xml = new XmlDocument();
            xml.CreateXmlDeclaration("1.0", "utf-8", "yes");
            xml.CreateComment("Programación");
            XmlNode primerNodo = xml.CreateElement("ConfiguracionTarea");
            xml.AppendChild(primerNodo);
            /*Nodo UnaVez*/
            XmlNode unaVez = xml.CreateElement("UnaVez");
            primerNodo.AppendChild(unaVez);
            XmlNode fecha = xml.CreateElement("Fecha");
            XmlNode activo = xml.CreateElement("Activo");
            if (datosArchivo.FrecuenciaTipoProgramacion == "1") /*por demanda*/
            {
                fecha.InnerText = datosArchivo.FechaEjecucion.ToString();
                activo.InnerText = "True";
            }
            else
            {
                fecha.InnerText = DateTime.Now.ToString("dd/MM/yyyy");
                activo.InnerText = "False";
            }
            unaVez.AppendChild(fecha);
            unaVez.AppendChild(activo);
            /*Nodo Diario*/
            XmlNode diario = xml.CreateElement("Diario");
            primerNodo.AppendChild(diario);
            XmlNode intervalo = xml.CreateElement("Intervalo");
            if (datosArchivo.FrecuenciaTipoProgramacion == "2") /*Diario*/
                intervalo.InnerText = "1";
            else
                intervalo.InnerText = "0";
            diario.AppendChild(intervalo);
            /*Nodo Semanal*/
            XmlNode semanal = xml.CreateElement("Semanal");
            primerNodo.AppendChild(semanal);
            XmlNode diasemana = xml.CreateElement("DiaSemana");
            semanal.AppendChild(diasemana);
            for (int i = 0; i <= 6; i++)
            {
                XmlNode booldiasemana = xml.CreateElement("boolean");
                if ((datosArchivo.DiaSemanal != null) && (datosArchivo.DiaSemanal == i.ToString()))
                    booldiasemana.InnerText = "true";
                else
                    booldiasemana.InnerText = "false";
                diasemana.AppendChild(booldiasemana);
            }
            /*Nodo Mensual*/
            XmlNode mensual = xml.CreateElement("Mensual");
            primerNodo.AppendChild(mensual);
            XmlNode mes = xml.CreateElement("Mes");
            mensual.AppendChild(mes);
            if (datosArchivo.FrecuenciaTipoProgramacion == "4")  /*Mensual*/
            {
                for (int i = 1; i <= 12; i++)
                {
                    XmlNode boolmes = xml.CreateElement("boolean");
                    boolmes.InnerText = "true";
                    mes.AppendChild(boolmes);
                }
            }
            else
            {
                for (int i = 1; i <= 12; i++)
                {
                    XmlNode boolmes = xml.CreateElement("boolean");
                    boolmes.InnerText = "false";
                    mes.AppendChild(boolmes);
                }
            }

            XmlNode diames = xml.CreateElement("DiaMes");
            mensual.AppendChild(diames);
            for (int i = 1; i <= 32; i++)
            {
                XmlNode dia = xml.CreateElement("boolean");
                if (datosArchivo.DiaMes == i.ToString())
                    dia.InnerText = "true";
                else
                    dia.InnerText = "false";
                diames.AppendChild(dia);
            }
            XmlNode semanames = xml.CreateElement("SemanaMes");
            mensual.AppendChild(semanames);
            XmlNode numerosemana = xml.CreateElement("NumeroSemana");
            semanames.AppendChild(numerosemana);
            for (int i = 0; i <= 4; i++)
            {
                XmlNode numsemana = xml.CreateElement("boolean");
                if (datosArchivo.NumeroSemana == i.ToString())
                    numsemana.InnerText = "true";
                else
                    numsemana.InnerText = "false";
                numerosemana.AppendChild(numsemana);
            }
            XmlNode diasemanamensual = xml.CreateElement("DiaSemana");
            semanames.AppendChild(diasemanamensual);
            for (int i = 0; i <= 6; i++)
            {
                XmlNode diasemmes = xml.CreateElement("boolean");
                if (datosArchivo.DiaSemana == i.ToString())
                    diasemmes.InnerText = "true";
                else
                    diasemmes.InnerText = "false";
                diasemanamensual.AppendChild(diasemmes);
            }
            return xml.InnerXml.ToString();
        }

        public List<ArchivoPlano> ConsultarDatosGrilla()
        {
            return this.repositorioParametrizacionPlanos.ConsultarDatosGrilla();
        }


        public Resultado ActualizarDatosArchivoPlano(ArchivoPlano datosArchivo)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioParametrizacionPlanos.ActualizarDatosArchivoPlano(datosArchivo);
                if (resultado.Error == false)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoActualizarArchivoPlano), Configuraciones.LlavesAplicacion.ActualizaArchivoPlano);
                    resultado.Error = false;
                }
                else
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoActualizarArchivoPlano), Configuraciones.LlavesAplicacion.ErrorActualizaArchivoPlano);
                    resultado.Error = true;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(Configuraciones.LlavesAplicacion.EventoActualizarArchivoPlano), ex, Configuraciones.LlavesAplicacion.CatchActualizarArchivoPlano).Mensaje;
            }
            return resultado;
        }


        public Resultado EliminarDatosArchivoPlano(int idProgramacion, string usuario)
        {
            Resultado resultado = new Resultado();
            try
            {
                resultado = this.repositorioParametrizacionPlanos.EliminarDatosArchivoPlano(idProgramacion, usuario);
                if (resultado.Error == false)
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoEliminarArchivoPlano), Configuraciones.LlavesAplicacion.EliminarArchivoPlanoOK);
                    resultado.Error = false;
                }
                else
                {
                    resultado = BAC.Seguridad.Mensaje.ControlMensajes.ConsultarMensajePorLlave(int.Parse(Configuraciones.LlavesAplicacion.EventoEliminarArchivoPlano), Configuraciones.LlavesAplicacion.ErrorEliminarArchivoPlano);
                    resultado.Error = true;
                }
            }
            catch (Exception ex)
            {
                resultado.Error = true;
                resultado.Mensaje = BAC.Seguridad.Mensaje.ControlMensajes.GuardarError(int.Parse(Configuraciones.LlavesAplicacion.EventoEliminarArchivoPlano), ex, Configuraciones.LlavesAplicacion.CatchEliminarArchivoPlano).Mensaje;
            }
            return resultado;
        }
        #endregion
    }
}
