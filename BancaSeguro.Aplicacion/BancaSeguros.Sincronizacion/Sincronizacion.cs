//-----------------------------------------------------------------------
// <copyright file="Sincronizacion.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Sincronizacion
{
    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.ServiceProcess;
    using System.Text;
    using Microsoft.Practices.EnterpriseLibrary.Logging;

    /// <summary>
    /// Class sync up catalogs
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 10/08/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="System.ServiceProcess.ServiceBase" />
    public partial class Sincronizacion : ServiceBase
    {
        #region Atributos

        /// <summary>
        /// Time interval
        /// </summary>
        private int intervalodeTiempo;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Sincronizacion"/> class.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Sincronizacion()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Gets or sets Interval Shooter in minute
        /// </summary>
        public int IntervalodeTiempo
        {
            get { return this.intervalodeTiempo; }
            set { this.intervalodeTiempo = value; }
        }

        #endregion

        #region Metodos Propios

        /// <summary>
        /// When implemented in a derived class, executes when a Start command is sent to the service by the Service Control Manager (SCM) or when the operating system starts (for a service that starts automatically). Specifies actions to take when the service starts.
        /// </summary>
        /// <param name="args">Data passed by the start command.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        protected override void OnStart(string[] args)
        {
            string mensaje = string.Empty;

            try
            {
                this.CrearLog(Mensajes.EstadoServicio, Mensajes.ServicioIniciando, TraceEventType.Information);
                this.tmrServicio.Interval = 1000;
                this.tmrServicio.Enabled = true;
                mensaje = this.ValidacionInicial();
            }
            catch (Exception ex)
            {
                this.CrearLog(Mensajes.OperacionErrorIniciado, ex.Message, TraceEventType.Error);
            }

            this.CrearLog(Mensajes.ServicioIniciado, mensaje, TraceEventType.Start);
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Stop command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service stops running.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        protected override void OnStop()
        {
            tmrServicio.Stop();
            tmrServicio.Enabled = false;
            this.CrearLog(Mensajes.EstadoServicio, Mensajes.ServicioDetenido, TraceEventType.Suspend);
            base.OnStop();
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Pause command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service pauses.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        protected override void OnPause()
        {
            tmrServicio.Stop();
            tmrServicio.Enabled = false;
            this.CrearLog(Mensajes.EstadoServicio, Mensajes.ServicioPausado, TraceEventType.Stop);
            base.OnPause();
            GC.Collect();
        }

        /// <summary>
        /// When implemented in a derived class, <see cref="M:System.ServiceProcess.ServiceBase.OnContinue" /> runs when a Continue command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service resumes normal functioning after being paused.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        protected override void OnContinue()
        {
            this.CrearLog(Mensajes.EstadoServicio, Mensajes.ServicioReanudado, TraceEventType.Resume);
            base.OnContinue();
            GC.Collect();
            tmrServicio.Enabled = true;
            tmrServicio.Start();
        }

        #endregion

        #region Metodods Privados

        /// <summary>
        /// Validation the initial time.
        /// </summary>
        /// <returns>string message</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private string ValidacionInicial()
        {
            StringBuilder respuesta = new StringBuilder();
            int tiempoEjecucion = 1;
            int intervaloTiempo = 60000;

            try
            {
                int.TryParse(ConfigurationManager.AppSettings[Mensajes.ParametroTiempoEjecucion], out tiempoEjecucion);
                intervaloTiempo *= tiempoEjecucion;
                this.tmrServicio.Interval = intervaloTiempo;
                respuesta.AppendLine(string.Format(Mensajes.MensajeTiempoEjecucion, tiempoEjecucion.ToString()));
                this.tmrServicio.Start();
            }
            catch (Exception ex)
            {
                respuesta.Append(ex.Message);
                this.CrearLog(Mensajes.EstadoServicio, Mensajes.OperacionErrorValidando + respuesta.ToString(), TraceEventType.Error);
            }

            return respuesta.ToString();
        }

        /// <summary>
        /// Create the log.
        /// </summary>
        /// <param name="titulo">The title.</param>
        /// <param name="descripcion">The description.</param>
        /// <param name="tipoEvento">Type of the event.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private void CrearLog(string titulo, string descripcion, TraceEventType tipoEvento)
        {
            LogEntry logEntry = new LogEntry();
            logEntry.Message = descripcion;
            logEntry.Priority = 1;
            logEntry.Severity = tipoEvento;
            logEntry.Categories.Clear();
            logEntry.Title = titulo;
            logEntry.Categories.Add("Events");
            Logger.Write(logEntry);
        }

        #endregion

        /// <summary>
        /// Method timer
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the timers</param>
        private void Servicio_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.tmrServicio.Stop();
            this.tmrServicio.Enabled = false;
            int intervaloTiempo = 1;
            int.TryParse(ConfigurationManager.AppSettings[Mensajes.ParametroTiempoIntervaloMinutos], out intervaloTiempo);
            if (intervaloTiempo == 0)
            {
                int.TryParse(ConfigurationManager.AppSettings[Mensajes.ParametroTiempoIntervaloHora], out intervaloTiempo);
                intervaloTiempo = intervaloTiempo * 36000000;
            }
            else
            {
                intervaloTiempo = intervaloTiempo * 600000;
            }

            ServicioSincronizacion.Resultado resultado = new ServicioSincronizacion.Resultado();

            try
            {
                resultado = AdministradorProxy.ObtenerClienteSincronizacion().SincronizarCatalogos();

                if (resultado.error)
                {
                    this.CrearLog(resultado.mensaje, Mensajes.OperacionError, TraceEventType.Error);
                }
                else
                {
                    this.CrearLog(resultado.mensaje, Mensajes.OperacionRealizada, TraceEventType.Information);
                }
            }
            catch (Exception ex)
            {
                this.CrearLog("Service State", Mensajes.OperacionError + ex.Message, TraceEventType.Error);
            }

            this.tmrServicio.Interval = intervaloTiempo;
            this.tmrServicio.Enabled = true;
            this.tmrServicio.Start();
            this.ValidacionInicial();
        }
    }
}