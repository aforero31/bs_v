//-----------------------------------------------------------------------
// <copyright file="GestionSincronizacion.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Aplicacion.Sincronizacion
{
    using Cobis;
    using Configuraciones;
    using Entidades.Catalogo;
    using Entidades.General;
    using Repositorio.Administracion;
    using Repositorio.Sincronizacion;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Web;
    using System.Xml;
    using BancaSeguros.Repositorio.Seguridad;

    /// <summary>
    /// Management sync up
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 10/08/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BancaSeguros.Aplicacion.Sincronizacion.IGestionSincronizacion" />
    public class GestionSincronizacion : IGestionSincronizacion
    {
        #region Variables

        /// <summary>
        /// The management intarface transaction
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionTransaccion gestionTransaccion;

        /// <summary>
        /// The management intarface catalogs
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionCatalogos gestionCatalogos;

        /// <summary>
        /// The management intarface day
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioDiaHabil repositorioDiaHabil;

        /// <summary>
        /// The repository sinc up
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 24/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioSincronizacion repositorioSincronizacion;

        /// <summary>
        /// The repository sinc up
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 24/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioOficinas gestionSincronizacion;

        /// <summary>
        /// The management intarface oficinas
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 15/11/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IGestionOficinas gestionOficinas;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="gestionSincronizacion"/> class.
        /// </summary>
        /// <param name="repositorioDiaHabil">The repository day.</param>
        /// <param name="repositorioSincronizacion">The repository sync up.</param>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 24/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public GestionSincronizacion(IRepositorioDiaHabil repositorioDiaHabil, IRepositorioSincronizacion repositorioSincronizacion, IGestionTransaccion gestionTransaccion, IGestionCatalogos gestionCatalogos)
        {
            this.gestionTransaccion = gestionTransaccion;
            this.gestionCatalogos = gestionCatalogos;
            this.repositorioDiaHabil = repositorioDiaHabil;
            this.repositorioSincronizacion = repositorioSincronizacion;
            //this.gestionOficinas = gestionOficinas;
        }

        #endregion Constructor

        #region Metodos Publicos

        /// <summary>
        /// sync up catalogs.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 09/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado SincronizarCatalogos()
        {
            Resultado resultadoDevuelto;

            try
            {
                //Resultado resultadoDias = this.SincronizarTablaDiasHabiles();
                //Resultado resultadoTablas = this.SincronizarTablasBasicas();
                Resultado resultadoDias = new Resultado { Mensaje = "Sincronización  días hábiles desactivada" };
                Resultado resultadoTablas = new Resultado { Mensaje = "Sincronización tablas básicas desactivada" };
                Resultado resultadoSincronizacionOficinas = this.SincronizarOficinas();

                Resultado resultadoPdf = this.EliminarPdf();
                resultadoDevuelto = this.ManejarResultadoSincronizacion(resultadoTablas, resultadoDias, resultadoPdf);

                return resultadoDevuelto;
            }
            catch (Exception exc)
            {
                resultadoDevuelto = new Resultado();
                resultadoDevuelto.Error = true;
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
                    resultadoDevuelto.Mensaje = s.ToString();
                }
            }

            return resultadoDevuelto;
        }

        #endregion Metodos Publicos

        #region Metodos Privados

        /// <summary>
        /// Sync up the tables basics.
        /// </summary>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// <exception cref="System.NotImplementedException"></exception>
        private Resultado EliminarPdf()
        {
            Resultado resultadoDevuelto = new Resultado();
            try
            {
                var rutaArchivo = ConfigurationManager.AppSettings.Get("RutaLocalArchivos");
                string[] ficherosCarpeta = Directory.GetFiles(rutaArchivo);
                foreach (string ficheroActual in ficherosCarpeta)
                    File.Delete(ficheroActual);

                resultadoDevuelto.Error = false;
                resultadoDevuelto.Mensaje = "Se eliminaron los PDF generados";
            }
            catch (Exception exc)
            {
                resultadoDevuelto = new Resultado();
                resultadoDevuelto.Error = true;
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
                    resultadoDevuelto.Mensaje = s.ToString();
                }
            }

            return resultadoDevuelto;
        }

        /// <summary>
        /// Sync up the tables basics.
        /// </summary>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// <exception cref="System.NotImplementedException"></exception>
        private Resultado SincronizarTablasBasicas()
        {
            Resultado resultado = new Resultado();
            List<Resultado> listaResultado = new List<Resultado>();
            listaResultado.Add(this.SincronizacionTabla(EnumCatalogo.CobisTipoIdentificacion));
            listaResultado.Add(this.SincronizacionTabla(EnumCatalogo.CobisParentesco));
            listaResultado.Add(this.SincronizacionTabla(EnumCatalogo.CobisSubProductoCC, EnumCatalogo.CobisSubProductoCA));
            listaResultado.Add(this.SincronizacionTablaCategoria(EnumCatalogo.CobisCategoriaCC, EnumCatalogo.CobisCategoriaCA));
            resultado = this.ManejarResultadoSincronizacionTablasBasicas(listaResultado);
            return resultado;
        }

        /// <summary>
        /// Sync up catalog catalogo
        /// </summary>
        /// <param name="nombreCatalogo">The name catalog.</param>
        /// <param name="nombreCatalogo2">The name catalog.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\jgonzalezg
        /// CreationDate: 25/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado SincronizacionTablaCategoria(string nombreCatalogo, string nombreCatalogo2)
        {
            DtoCatalogo dtoCatalogo = new DtoCatalogo();

            dtoCatalogo = this.gestionCatalogos.ConsultarCatalogo(nombreCatalogo);

            if (dtoCatalogo == null)
            {
                dtoCatalogo = new DtoCatalogo { Resultado = new Resultado { Error = true, Mensaje = string.Format(Mensajes.SinDTO, nombreCatalogo) } };
                return dtoCatalogo.Resultado;
            }

            if (!dtoCatalogo.Resultado.Error)
            {
                dtoCatalogo.TablaCategoria.AddRange((this.gestionCatalogos.ConsultarCatalogo(nombreCatalogo2)).TablaCategoria);
            }

            if (!dtoCatalogo.Resultado.Error)
            {
                dtoCatalogo.Resultado = this.GuardarEnElSistemaCatalogo(nombreCatalogo, dtoCatalogo);
            }

            return dtoCatalogo.Resultado;
        }

        /// <summary>
        /// Sync up catalog sub product
        /// </summary>
        /// <param name="nombreCatalogo">The name catalog.</param>
        /// <param name="nombreCatalogo2">The name catalog.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 25/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado SincronizacionTabla(string nombreCatalogo, string nombreCatalogo2)
        {
            DtoCatalogo dtoCatalogo = new DtoCatalogo();

            dtoCatalogo = this.gestionCatalogos.ConsultarCatalogo(nombreCatalogo);

            if (dtoCatalogo == null)
            {
                dtoCatalogo = new DtoCatalogo { Resultado = new Resultado { Error = true, Mensaje = string.Format(Mensajes.SinDTO, nombreCatalogo) } };
                return dtoCatalogo.Resultado;
            }

            if (!dtoCatalogo.Resultado.Error)
            {
                dtoCatalogo.TablaSubProducto.AddRange((this.gestionCatalogos.ConsultarCatalogo(nombreCatalogo2)).TablaSubProducto);
            }

            if (!dtoCatalogo.Resultado.Error)
            {
                dtoCatalogo.Resultado = this.GuardarEnElSistemaCatalogo(nombreCatalogo, dtoCatalogo);
            }

            return dtoCatalogo.Resultado;
        }

        /// <summary>
        /// Sync up the table.
        /// </summary>
        /// <param name="nombreCatalogo">The name catalog.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado SincronizacionTabla(string nombreCatalogo)
        {
            DtoCatalogo dtoCatalogo = new DtoCatalogo();

            dtoCatalogo = this.gestionCatalogos.ConsultarCatalogo(nombreCatalogo);

            if (dtoCatalogo == null)
            {
                dtoCatalogo = new DtoCatalogo { Resultado = new Resultado { Error = true, Mensaje = string.Format(Mensajes.SinDTO, nombreCatalogo) } };
                return dtoCatalogo.Resultado;
            }

            if (dtoCatalogo.Resultado != null && !dtoCatalogo.Resultado.Error)
            {
                dtoCatalogo.Resultado = this.GuardarEnElSistemaCatalogo(nombreCatalogo, dtoCatalogo);
            }

            return dtoCatalogo.Resultado;
        }

        #region Sincronizar Oficinas

        /// <summary>
        /// Sync up the table.
        /// </summary>
        /// Author: INTERGRUPO\JGARCIAR
        /// CreationDate: 10/10/2019
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public Resultado SincronizarOficinas()
        {
            Resultado Resp = new Resultado();

            ListaOficinas OficinasServicio = new ListaOficinas();
            OficinasServicio.Resultado = new Resultado();
            ListaOficinas OficinasLocal = new ListaOficinas();
            OficinasLocal.Resultado = new Resultado();

            try
            {
                OficinasServicio = this.CargarOficinasServicioCobis();
                if (OficinasServicio.Resultado.Error != true)
                {
                    OficinasLocal = this.CargarOficinasLocal();
                    if (OficinasLocal.Resultado.Error != true)
                    {
                        if (OficinasServicio.ListOficinas != null && OficinasLocal.ListOficinas != null)
                        {
                            if (OficinasServicio.ListOficinas.Count > 0 )
                            {
                                OficinasLocal.Resultado = CompararListas(OficinasServicio, OficinasLocal);
                            }
                            else
                            {
                                Resp.Error = true;
                                Resp.Mensaje = "SincronizarOficinas: No hay data servicio web para comparar oficinas.";
                            }
                        }
                        else
                        {
                            Resp.Error = true;
                            Resp.Mensaje = "SincronizarOficinas: Objeto(s) en estado NULL - No hay data para comparar oficinas";
                        }
                    }
                    else
                    {
                        Resp.Error = OficinasLocal.Resultado.Error;
                        Resp.Mensaje = OficinasLocal.Resultado.Mensaje;
                    }
                }
                else
                {
                    Resp.Error = OficinasServicio.Resultado.Error;
                    Resp.Mensaje = OficinasServicio.Resultado.Mensaje;
                }
            }
            catch (Exception exc)
            {
                Resp.Error = true;
                Resp.Mensaje = string.Format(Mensajes.ErrorInterno, exc.Message);
            }

            if (OficinasServicio.Resultado.Error == false && OficinasLocal.Resultado.Error == false && Resp.Error == false)
            {
                Resp.Error = false;
                Resp.Mensaje = "El proceso de actualización se generó exitosamente.";
            }

            return Resp;
        }

        private ListaOficinas CargarOficinasServicioCobis()
        {
            Resultado Resp = new Resultado();
            ListaOficinas Oficinas = new ListaOficinas();

            Oficinas = GestionOficinas.CargarOficinasServicioCobis();

            return Oficinas;
        }

        private ListaOficinas CargarOficinasLocal()
        {
            ListaOficinas Oficinas = new ListaOficinas();
            Resultado Resp = new Resultado();
            int Opcion = 1;

            Oficinas = new BancaSeguros.Repositorio.Seguridad.RepositorioOficinas("CONEXION_BANCASEGURO").ConsultarOficinas(Opcion);

            return Oficinas;
        }

        private Resultado CompararListas(ListaOficinas OficinasServicio, ListaOficinas OficinasLocal)
        {
            Resultado Resp = new Resultado();
            Oficina OficinaNueva = new Oficina();

            foreach (Oficina OficinaS in OficinasServicio.ListOficinas)
            {
                Oficina OficinaL = (from Ofi in OficinasLocal.ListOficinas where Ofi.IdOficina.Equals(OficinaS.IdOficina) select Ofi).FirstOrDefault();
                
                if (OficinaL != null)
                {
                    
                        if ((OficinaL.Nombre != OficinaS.Nombre))
                        {
                            //*** Actualizar BD Local (opcion = 1)
                            OficinaL.Opcion = 1;
                            OficinaL.Inicial = OficinaL.IdOficina + " - " + OficinaL.Nombre;
                            OficinaL.Nombre = OficinaS.Nombre;
                            Resp = ActualizarBD(OficinaL);

                            //Escribir LOG
                            OficinaL.Fecha = Convert.ToDateTime(DateTime.Now);
                            OficinaL.Usuario = "System";
                            OficinaL.Tipoevento = "U";
                            //OficinaL.Inicial = OficinaL.IdOficina + " - " + OficinaL.Nombre;
                            OficinaL.Final = OficinaS.IdOficina + " - " + OficinaS.Nombre;
                            Resp = GuardarLOGOficinas(OficinaL);
                        }
                  
                }
                else
                {
                    OficinaNueva = OficinaS;
                    //*** Actualizar BD Local (opcion = 1)
                    OficinaNueva.Opcion = 1;
                    OficinaNueva.Activo = 1;
                    Resp = ActualizarBD(OficinaNueva);

                    //Escribir LOG
                    OficinaNueva.Fecha = Convert.ToDateTime(DateTime.Now);
                    OficinaNueva.Usuario = "System";
                    OficinaNueva.Tipoevento = "I";
                    OficinaNueva.Inicial = String.Empty;
                    OficinaNueva.Final = OficinaS.IdOficina + " - " + OficinaS.Nombre;
                    Resp = GuardarLOGOficinas(OficinaNueva);
                }
            }

            return Resp;
        }

        private Resultado ActualizarBD(Oficina OficinasLocal)
        {
            Resultado Resp = new Resultado();

            //Resp = this.gestionSincronizacion.ActualizarOficinas(OficinasLocal);
            Resp = new BancaSeguros.Repositorio.Seguridad.RepositorioOficinas("CONEXION_BANCASEGURO").ActualizarOficinas(OficinasLocal);

            return Resp;
        }

        private Resultado GuardarLOGOficinas(Oficina OficinasLocal)
        {
            Resultado Resp = new Resultado();

            Resp = new BancaSeguros.Repositorio.Seguridad.RepositorioOficinas("CONEXION_BANCASEGURO").LOGOficinas(OficinasLocal);

            return Resp;
        }

        #endregion

        /// <summary>
        /// Save in the system catalog.
        /// </summary>
        /// <param name="nombreCatalogo">The name catalog.</param>
        /// <param name="dtoCatalogo">The data catalog.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado GuardarEnElSistemaCatalogo(string nombreCatalogo, DtoCatalogo dtoCatalogo)
        {
            Resultado resultado = new Resultado();

            switch (nombreCatalogo)
            {
                case EnumCatalogo.CobisTipoIdentificacion:
                    DataTable tiposIdentificacion = new DataTable();
                    tiposIdentificacion = ToDataTable<TipoIdentificacion>(dtoCatalogo.ListTipoIdentificacion);
                    resultado = this.repositorioSincronizacion.GuardarDatosEnBaseDatos(nombreCatalogo, tiposIdentificacion);
                    break;

                case EnumCatalogo.CobisPeriodicidad:
                    DataTable periodicidades = new DataTable();
                    periodicidades = ToDataTable<Periodicidad>(dtoCatalogo.ListPeriodicidad);
                    resultado = this.repositorioSincronizacion.GuardarDatosEnBaseDatos(nombreCatalogo, periodicidades);
                    break;

                case EnumCatalogo.CobisParentesco:
                    DataTable parentescos = new DataTable();
                    parentescos = ToDataTable<Parentesco>(dtoCatalogo.ListParentesco);
                    resultado = this.repositorioSincronizacion.GuardarDatosEnBaseDatos(nombreCatalogo, parentescos);
                    break;

                case EnumCatalogo.CobisProducto:
                    DataTable productos = new DataTable();
                    productos = ToDataTable<Producto>(dtoCatalogo.TablaProducto);
                    resultado = this.repositorioSincronizacion.GuardarDatosEnBaseDatos(nombreCatalogo, productos);
                    break;

                case EnumCatalogo.CobisSubProductoCC:
                case EnumCatalogo.CobisSubProductoCA:
                    DataTable subProductos = new DataTable();
                    subProductos = ToDataTable<SubProducto>(dtoCatalogo.TablaSubProducto);
                    resultado = this.repositorioSincronizacion.GuardarDatosEnBaseDatos(nombreCatalogo, subProductos);
                    break;

                case EnumCatalogo.CobisCategoriaCC:
                case EnumCatalogo.CobisCategoriaCA:
                    DataTable categorias = new DataTable();
                    categorias = ToDataTable<Categoria>(dtoCatalogo.TablaCategoria);
                    resultado = this.repositorioSincronizacion.GuardarDatosEnBaseDatos(nombreCatalogo, categorias);
                    break;

                default:
                    dtoCatalogo.Resultado = new Resultado { Error = true };
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Drive the result sync table basic.
        /// </summary>
        /// <param name="resultadoTablaTipoIdentificacion">The result table type identification.</param>
        /// <param name="resultadoTablaPeriodicidad">The result table periodicity.</param>
        /// <param name="resultadoTablaParentesco">The result table relationship.</param>
        /// <param name="resultadoTablaProductos">The result table products.</param>
        /// <param name="resultadoTablaSubProductos">The result table sub products.</param>
        /// <param name="resultadoTablaSubProductos2">The result table sub products.</param>
        /// <param name="resultadoTablaCategorias">The result table category.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        ///
        private Resultado ManejarResultadoSincronizacionTablasBasicas(List<Resultado> resultados)
        {
            Resultado resultado = new Resultado();
            resultado.Mensaje = Mensajes.SincronizacionCatalogos;
            StringBuilder sb = new StringBuilder();
            foreach (Resultado re in resultados)
            {
                if (re != null)
                    if (re.Error)
                    {
                        sb.Append(re.Mensaje);
                        sb.AppendLine();
                    }
            }
            resultado.Mensaje = sb.ToString();
            return resultado;
        }

        /// <summary>
        /// Sync the table day skillfull.
        /// </summary>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 10/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        /// <exception cref="System.NotImplementedException"></exception>
        private Resultado SincronizarTablaDiasHabiles()
        {
            Resultado resultado = new Resultado();
            List<DiaHabil> diasASincronizar;
            List<DiaHabil> diasHabiles;

            DateTime fechaControlSistema;
            DateTime dob;
            string sfcs = ConfigurationManager.AppSettings.Get(Parametros.FechaControlSistema);
            if (DateTime.TryParseExact(sfcs, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
                fechaControlSistema = dob;
            else
                fechaControlSistema = ConvertToDateTime(sfcs);

            //DateTime fechaControlSistema = DateTime.ParseExact(ConfigurationManager.AppSettings.Get(Parametros.FechaControlSistema),
            //    "dd/MM/yyyy", CultureInfo.InvariantCulture);
            int diasAAnticipar;
            int.TryParse(ConfigurationManager.AppSettings.Get(Parametros.DiasAAnticipar), out diasAAnticipar);
            DateTime fechaControl = DateTime.Now.AddDays(diasAAnticipar);

            if (fechaControl.Date == fechaControlSistema.Date)
            {
                int diasALlenar = 0;
                int.TryParse(ConfigurationManager.AppSettings.Get(Parametros.DiasALlenar), out diasALlenar);

                diasASincronizar = this.LlenarDiasAVerificar(fechaControl, diasALlenar);
                diasHabiles = this.VerificarDiasASincronizar(diasASincronizar);
                resultado = this.repositorioDiaHabil.EliminarDiasHabilesApartirDeFecha(fechaControl);

                if (!resultado.Error)
                {
                    foreach (var dia in diasHabiles)
                    {
                        resultado = this.repositorioDiaHabil.InsertarDiaHabil(dia.Fecha);
                    }
                }

                if (!resultado.Error)
                {
                    resultado = this.ActualizarLlaveFechaControl(diasASincronizar);
                }
            }
            else
            {
                resultado.Mensaje = string.Format(Mensajes.SinCumplimientoParametros, DateTime.Now.ToString("dd/MM/yyyy"), diasAAnticipar,
                    fechaControl.Date.ToString("dd/MM/yyyy"), fechaControlSistema.Date.ToString("dd/MM/yyyy"));
            }

            resultado.Mensaje = resultado.Mensaje.Insert(0, Mensajes.SincronizacionDias);

            return resultado;
        }

        /// <summary>
        /// Convercion de String a Datime
        /// </summary>
        /// <param name="ConvertToDateTime">Convertir</param>
        /// <returns>Datetime</returns>
        /// <remarks>
        /// Author: INTERGRUPO\ENRIQUE RIVERA
        /// CreationDate: 10/11/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private DateTime ConvertToDateTime(string strDateTime)
        {
            DateTime dtFinaldate; string sDateTime;
            try { dtFinaldate = Convert.ToDateTime(strDateTime); }
            catch (Exception e)
            {
                string[] sDate = strDateTime.Split('/');
                sDateTime = sDate[0] + '/' + sDate[1] + '/' + sDate[2];
                dtFinaldate = Convert.ToDateTime(sDateTime);
            }
            return dtFinaldate;
        }

        /// <summary>
        /// Update the key date control.
        /// </summary>
        /// <param name="diasASincronizar">The day sync up.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado ActualizarLlaveFechaControl(List<DiaHabil> diasASincronizar)
        {
            Resultado resultado = new Resultado();

            diasASincronizar.Count();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement element in xmlDoc.DocumentElement)
            {
                if (element.Name.Equals("appSettings"))
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        if (node.NodeType == XmlNodeType.Element && node.Name == "add")
                        {
                            if (node.Attributes[0].Value.Equals("FechaControlSistema"))
                            {
                                node.Attributes[1].Value = diasASincronizar[diasASincronizar.Count() - 1].Fecha.Date.ToString();
                            }
                        }
                    }
                }
            }

            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("appSettings");

            return resultado;
        }

        /// <summary>
        /// Check the day sync up.
        /// </summary>
        /// <param name="diasASincronizar">The days sync up.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private List<DiaHabil> VerificarDiasASincronizar(List<DiaHabil> diasASincronizar)
        {
            List<DiaHabil> diasHabiles = new List<DiaHabil>();
            diasHabiles.AddRange(diasASincronizar);
            foreach (var dia in diasASincronizar)
            {
                if (!this.gestionTransaccion.ConsultarDiaHabil(dia.Fecha))
                    diasHabiles.Remove(dia);
            }
            return diasHabiles;
        }

        /// <summary>
        /// Complete the check days.
        /// </summary>
        /// <param name="fechaControl">The date control.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private List<DiaHabil> LlenarDiasAVerificar(DateTime fechaControl, int diasALlenar)
        {
            List<DiaHabil> diasHabiles = new List<DiaHabil>();
            DateTime fechaHoy = DateTime.Now;

            DiaHabil diaHabil;
            diaHabil = new DiaHabil();
            diaHabil.Fecha = fechaControl;
            diasHabiles.Add(diaHabil);

            for (int i = 1; i < diasALlenar; i++)
            {
                diaHabil = new DiaHabil();
                diaHabil.Fecha = fechaControl.AddDays(i);
                diasHabiles.Add(diaHabil);
            }
            return diasHabiles;
        }

        /// <summary>
        /// Eliminar PDF creados.
        /// </summary>
        /// <param name="resultadoTablas">The result table.</param>
        /// <param name="resultadoDias">The result day.</param>
        /// <returns>Entity result</returns>
        /// <remarks>
        /// Author: INTERGRUPO\Enrique Rivera
        /// CreationDate: 25/11/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private Resultado ManejarResultadoSincronizacion(Resultado resultadoTablas, Resultado resultadoDias, Resultado ResultadoArchivos)
        {
            Resultado resultado = new Resultado();
            StringBuilder sb = new StringBuilder();
            sb.Append(resultadoDias.Mensaje);
            sb.AppendLine();
            sb.Append(resultadoTablas.Mensaje);
            sb.AppendLine();
            sb.Append(ResultadoArchivos.Mensaje);
            resultado.Mensaje = sb.ToString();

            if (resultadoDias.Error)
                resultado.Error = resultadoDias.Error;
            else if (resultadoTablas.Error)
                resultado.Error = resultadoTablas.Error;
            else if (ResultadoArchivos.Error)
                resultado.Error = ResultadoArchivos.Error;

            return resultado;
        }

        /// <summary>
        /// To the data table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns>data table</returns>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 19/08/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static DataTable ToDataTable<T>(IList<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable

            foreach (DataRow dtRow in dataTable.Rows)
            {
                foreach (DataColumn dc in dataTable.Columns)
                {
                    dtRow[dc] = dtRow[dc].ToString().Replace(",", ".");
                }
            }

            return dataTable;
        }

        #endregion Metodos Privados
    }
}