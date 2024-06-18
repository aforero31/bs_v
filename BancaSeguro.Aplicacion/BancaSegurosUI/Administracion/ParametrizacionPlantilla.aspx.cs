//-----------------------------------------------------------------------
// <copyright file="ParametrizacionPlantilla.aspx.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSegurosUI.Administracion
{
    using BancaSeguros.Entidades.Administracion;
    using BancaSeguros.Entidades.General;
    using BancaSeguros.Entidades.Seguro;
    using BancaSegurosUI.App_Code;
    using Newtonsoft.Json;
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Script.Services;
    using System.Web.Services;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// template parameterize 
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 12/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public partial class ParametrizacionPlantilla : System.Web.UI.Page
    {
        /// <summary>
        /// Gets or sets the template docx.
        /// </summary>
        /// <value>
        /// The template word file.
        /// </value>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public static byte[] PlantillaDocx { get; set; }
        public static bool EsPostback { get; set; }
        #region Metodos publicos


        #region Obtener


        /// <summary>
        /// Descargars the plantilla.
        /// </summary>
        /// <param name="idDocumentoPoliza">The identifier documento poliza.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado DescargarPlantilla(int idDocumentoPoliza)
        {
            Resultado resultado = new Resultado();
            var resultadoOperacion = AdministradorProxy.ObtenerClienteAdministracion().ObtenerDocumentoPolizaPorIdDocumentoPoliza(idDocumentoPoliza);
            resultado = ConstruirPlantilla(resultadoOperacion.Plantilla, resultadoOperacion.NombreArchivo);
            return resultado;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static DocumentoPoliza ObtenerPlantillaEdicion(int idDocumentoPoliza)
        {
            var documentoPlantilla = AdministradorProxy.ObtenerClienteAdministracion().ObtenerDocumentoPolizaPorIdDocumentoPoliza(idDocumentoPoliza);
            PlantillaDocx = documentoPlantilla.Plantilla;
            return documentoPlantilla;
        }

        /// <summary>
        /// Gets dumie table.
        /// </summary>
        /// <param name="camposSeleccionados">The selected fields.</param>
        /// <param name="seccionPoliza">The insurance section.</param>
        /// <returns>Html table </returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static string ObtenerTablaDummie(string camposSeleccionados, string seccionPoliza, int idSeguro)
        {
            string tablaHtml = string.Empty;
            EncabezadoPolizaDocumento resultado = new EncabezadoPolizaDocumento();
            try
            {
                var archivoXML = new XmlDocument();
                archivoXML = XmlDummie(idSeguro, seccionPoliza);
                XmlNodeList seccionXml = seccionPoliza.Equals("BeneficiariosPolizaDocumento") ? archivoXML.GetElementsByTagName(seccionPoliza)[0].ChildNodes : archivoXML.GetElementsByTagName(seccionPoliza);
                switch (seccionPoliza)
                {
                    case "BeneficiariosPolizaDocumento":
                        seccionXml = archivoXML.GetElementsByTagName(seccionPoliza)[0].ChildNodes;
                        break;
                    case "EncabezadoPolizaCliente":
                        seccionXml = ObtenerNodosCliente(archivoXML.GetElementsByTagName("EncabezadoPoliza")[0].ChildNodes, true);
                        break;
                    case "EncabezadoPoliza":
                        seccionXml = ObtenerNodosCliente(archivoXML.GetElementsByTagName("EncabezadoPoliza")[0].ChildNodes, false);
                        break;
                    case "VariablesPolizaDocumento":
                        seccionXml = ObtenerNodosCliente(archivoXML.GetElementsByTagName("VariablesPolizaDocumento")[0].ChildNodes, false);
                        break;
                    default:
                        seccionXml = archivoXML.GetElementsByTagName(seccionPoliza);
                        break;
                }
                tablaHtml = ConvertirXmlTablaHtml(seccionXml, camposSeleccionados);
            }
            catch (Exception ex)
            {
                tablaHtml = ex.Message;
            }
            return tablaHtml;
        }

        /// <summary>
        /// gets the insurances.
        /// </summary>
        /// <returns>insurances list</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IEnumerable<Seguro> ObtenerSeguros()
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarTodosLosSeguros();
        }

        /// <summary>
        /// Obteners the plantillas seguro.
        /// </summary>
        /// <param name="idSeguro">The identifier seguro.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<DocumentoPoliza> ObtenerPlantillasSeguro(int idSeguro)
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ObtenerPlantillasPorIdSeguro(idSeguro);
        }

        /// <summary>
        /// Obteners the plantillas por identifier seguro.
        /// </summary>
        /// <param name="idSeguro">The identifier seguro.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<DocumentoPoliza> ObtenerPlantillasPorIdSeguro(int idSeguro)
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ObtenerPlantillasPorIdSeguro(idSeguro).ToList();
        }

        /// <summary>
        /// Previsualizars the plantilla.
        /// </summary>
        /// <param name="CamposSeleccionados">The campos seleccionados.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado PrevisualizarPlantilla(string CamposSeleccionados, int idSeguro)
        {
            Resultado resultado = ConstruirPdfPlantilla(CamposSeleccionados, PlantillaDocx, idSeguro);
            return resultado;
        }

        /// <summary>
        /// Previsualizars the plantilla seleccion.
        /// </summary>
        /// <param name="idDocumentoPoliza">The identifier documento poliza.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado PrevisualizarPlantillaSeleccion(int idDocumentoPoliza, int idSeguro)
        {
            Resultado resultado = new Resultado();
            var resultadoOperacion = AdministradorProxy.ObtenerClienteAdministracion().ObtenerDocumentoPolizaPorIdDocumentoPoliza(idDocumentoPoliza);
            resultado = ConstruirPdfPlantilla(resultadoOperacion.CamposPlantilla, resultadoOperacion.Plantilla, idSeguro);
            return resultado;
        }

        #endregion

        #region Transacciones
        /// <summary>
        /// saves the template.
        /// </summary>
        /// <param name="IdSeguro">The identifier insurance.</param>
        /// <param name="VersionDocumento">The document version.</param>
        /// <param name="CamposPlantilla">The template fields.</param>
        /// <param name="nombrePlantilla">The template name.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado GuardarPlantilla(int IdSeguro, string VersionDocumento, string CamposPlantilla, string nombrePlantilla, bool activa)
        {
            Resultado resultado = new Resultado();

            DocumentoPoliza documentoPoliza = new DocumentoPoliza();
            documentoPoliza.IdSeguro = IdSeguro;
            documentoPoliza.VersionDocumento = VersionDocumento;
            documentoPoliza.CamposPlantilla = CamposPlantilla;
            documentoPoliza.Activa = activa;
            documentoPoliza.Eliminado = false;
            documentoPoliza.FechaCreacion = DateTime.Now;
            documentoPoliza.UsuarioCreacion = HttpContext.Current.User.Identity.Name;
            documentoPoliza.Plantilla = PlantillaDocx;
            documentoPoliza.NombreArchivo = nombrePlantilla;
            documentoPoliza.Usuario = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            resultado = AdministradorProxy.ObtenerClienteAdministracion().InsertarDocumentoPlantillaSeguro(documentoPoliza);
            resultado = ValidarEstadoSeguro(IdSeguro, resultado,activa);
            return resultado;

        }


        /// <summary>
        /// Save the template control dual.
        /// </summary>
        /// <param name="IdSeguro">The identifier seguro.</param>
        /// <param name="VersionDocumento">The version document.</param>
        /// <param name="CamposPlantilla">The fields template.</param>
        /// <param name="nombrePlantilla">The name template.</param>
        /// <param name="activa">if set to <c>true</c> [activa].</param>
        /// <param name="idMenu">The identifier menu.</param>
        /// <returns>Object Result</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado GuardarPlantillaControlDual(int IdSeguro, string VersionDocumento, string CamposPlantilla, string nombrePlantilla, bool activa, int idMenu)
        {
            Resultado resultado = new Resultado();

            DocumentoPoliza documentoPoliza = new DocumentoPoliza();
            documentoPoliza.IdSeguro = IdSeguro;

            int nuevaVersion;
            int versionActual;
            string nuevaVersionFormato = string.Empty;
            if (activa)
            {
                List<DocumentoPoliza> polizasSeguros = AdministradorProxy.ObtenerClienteAdministracion().ObtenerPlantillasPorIdSeguro(IdSeguro);
                if (polizasSeguros != null && polizasSeguros.Count > 0)
                {
                    List<int> versiones = (from x in polizasSeguros select Convert.ToInt32(x.VersionDocumento.Split('.')[0])).ToList();
                    int versionMayor = versiones.OrderByDescending(x => x).FirstOrDefault();
                    nuevaVersion = versionMayor + 1;
                }
                else
                {

                    int.TryParse(VersionDocumento.Split('.')[0], out versionActual);
                    nuevaVersion = versionActual + 1;
                }
                nuevaVersionFormato = string.Format("{0}.{1}", nuevaVersion.ToString(), "0");
            }
            else
            {
                if (!string.IsNullOrEmpty(VersionDocumento))
                    nuevaVersionFormato = string.Format("{0}.{1}", VersionDocumento.Split('.')[0], 1 + int.Parse(VersionDocumento.Split('.')[1].ToString()));
                else
                    nuevaVersionFormato = string.Format("{0}.{1}", "1", "0");
            }


            documentoPoliza.VersionDocumento = nuevaVersionFormato;
            documentoPoliza.CamposPlantilla = CamposPlantilla;
            documentoPoliza.Activa = activa;
            documentoPoliza.Eliminado = false;
            documentoPoliza.FechaCreacion = DateTime.Now;
            documentoPoliza.UsuarioCreacion = HttpContext.Current.User.Identity.Name;
            documentoPoliza.Plantilla = PlantillaDocx;
            documentoPoliza.NombreArchivo = nombrePlantilla;

            AprobacionDual aprobacion = new AprobacionDual();
            aprobacion.IdMenu = idMenu;
            aprobacion.Accion = EnumAccionDual.Insertar;
            aprobacion.NombreObjeto = "DocumentoPoliza";
            aprobacion.Estado = EnumEstadoDual.PorAprobar;

            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                aprobacion.UsuarioEnvia = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
                documentoPoliza.Usuario = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }

            aprobacion.DatosObjeto = JsonConvert.SerializeObject(documentoPoliza);
            resultado = AdministradorProxy.ObtenerClienteAdministracion().InsertarAprobacionDual(aprobacion);

            return resultado;
        }

        /// <summary>
        /// Eliminars the plantilla seleccionada.
        /// </summary>
        /// <param name="idPlantilla">The identifier plantilla.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado EliminarPlantillaSeleccionada(int idPlantilla)
        {
            return AdministradorProxy.ObtenerClienteAdministracion().EliminarPlantilla(idPlantilla);
        }

        /// <summary>
        /// Eliminars the plantilla.
        /// </summary>
        /// <param name="idDocumentoPlantilla">The identifier documento plantilla.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado EliminarPlantilla(int idDocumentoPlantilla)
        {
            Resultado resultado = new Resultado();
            var resultadoOperacion = AdministradorProxy.ObtenerClienteAdministracion().EliminarPlantilla(idDocumentoPlantilla);
            resultado.Error = resultadoOperacion.Error;
            resultado.Mensaje = resultadoOperacion.Mensaje;
            return resultado;
        }


        /// <summary>
        /// Delete the template control dual.
        /// </summary>
        /// <param name="idDocumentoPlantilla">The identifier document template.</param>
        /// <param name="idMenu">The identifier menu.</param>
        /// <returns>Object Result</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado EliminarPlantillaControlDual(int idDocumentoPlantilla, int idMenu)
        {
            Resultado resultado = new Resultado();

            AprobacionDual aprobacion = new AprobacionDual();
            aprobacion.IdMenu = idMenu;
            aprobacion.Accion = "Eliminar";
            aprobacion.NombreObjeto = "DocumentoPoliza";
            aprobacion.Estado = "P";

            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                aprobacion.UsuarioEnvia = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }

            DocumentoPoliza documentoPoliza = AdministradorProxy.ObtenerClienteAdministracion().ObtenerDocumentoPolizaPorIdDocumentoPoliza(idDocumentoPlantilla);
            aprobacion.DatosObjeto = JsonConvert.SerializeObject(documentoPoliza);

            resultado = AdministradorProxy.ObtenerClienteAdministracion().InsertarAprobacionDual(aprobacion);
            return resultado;
        }

        /// <summary>
        /// Actualizars the estado plantilla.
        /// </summary>
        /// <param name="idDocumentoPlantilla">The identifier documento plantilla.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado ActualizarEstadoPlantilla(int idDocumentoPlantilla)
        {
            Resultado resultado = new Resultado();
            var resultadoOperacion = AdministradorProxy.ObtenerClienteAdministracion().ActivarEstadoPlantilla(idDocumentoPlantilla);
            resultado.Error = resultadoOperacion.Error;
            resultado.Mensaje = resultadoOperacion.Mensaje;
            return resultado;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado ActualizarEstadoPlantillaControlDual(int idDocumentoPlantilla, int idMenu)
        {
            Resultado resultado = new Resultado();

            AprobacionDual aprobacion = new AprobacionDual();
            aprobacion.IdMenu = idMenu;
            aprobacion.Accion = "Activar";
            aprobacion.NombreObjeto = "DocumentoPoliza";
            aprobacion.Estado = "P";

            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                aprobacion.UsuarioEnvia = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }

            DocumentoPoliza documentoPoliza = AdministradorProxy.ObtenerClienteAdministracion().ObtenerDocumentoPolizaPorIdDocumentoPoliza(idDocumentoPlantilla);
            aprobacion.DatosObjeto = JsonConvert.SerializeObject(documentoPoliza);

            resultado = AdministradorProxy.ObtenerClienteAdministracion().InsertarAprobacionDual(aprobacion);
            return resultado;
        }

        #endregion

        /// <summary>
        /// Limpiars the plantilla cargada.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static void LimpiarPlantillaCargada()
        {
            PlantillaDocx = null;
        }


        /// <summary>
        /// Convierte archivo subido en Bytes.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\Enrique Rivera
        /// CreationDate: 17/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado ConvertirArchivoenBytes(string NombreArchivo)
        {
            Resultado resultado = new Resultado();
            try
            {
                string Serverpath = HttpContext.Current.Server.MapPath("Plantillas");
                string rutaArchivo = Serverpath + "\\" + NombreArchivo;
                PlantillaDocx = System.IO.File.ReadAllBytes(rutaArchivo);
                File.Delete(rutaArchivo);
                resultado = AdministradorProxy.ObtenerClienteGenerico().ConsultarMensajePorLlave(Int32.Parse(LlavesUI.EventoPlantilla), LlavesUI.PlantillaAlmacenada);

            }
            catch (Exception exc)
            {
                resultado = AdministradorProxy.ObtenerClienteGenerico().GuardarError(Int32.Parse(LlavesUI.EventoPlantilla), exc.ToString(), LlavesUI.CatchCargarPlantilla);
            }

            return resultado;

        }
        #endregion

        #region Metodos Privados

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Convierte un XML a una tabla HTML.
        /// </summary>
        /// <param name="seccionXml">Seccion XML.</param>
        /// <param name="columnas">Columnas.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 22/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static string ConvertirXmlTablaHtml(XmlNodeList seccionXml, string columnas)
        {
            StringBuilder tablaHtml = new StringBuilder();
            bool mensaje = true;
            tablaHtml.Append("<Table class='table'>");
            tablaHtml.Append("<tr>");
            for (int j = seccionXml[0].ChildNodes.Count - 1; j >= 0; j--)
            {
                if (columnas.Contains(seccionXml[0].ChildNodes[j].Name))
                {
                    mensaje = false;
                    tablaHtml.Append("<th>");
                    tablaHtml.Append(seccionXml[0].ChildNodes[j].Name);
                    //tablaHtml.Append(ObtenerTituloPorNombreNodo(seccionXml[0].ChildNodes[j].Name));
                    tablaHtml.Append("</th>");
                }
            }
            tablaHtml.Append("</tr>");
            for (int i = 0; i < seccionXml.Count; i++)
            {
                tablaHtml.Append("<tr>");
                for (int j = seccionXml[i].ChildNodes.Count - 1; j >= 0; j--)
                {
                    if (columnas.Contains(seccionXml[i].ChildNodes[j].Name))
                    {
                        mensaje = false;
                        tablaHtml.Append("<td>");
                        foreach (XmlNode xn in seccionXml[i])
                        {
                            if (xn.Name == seccionXml[i].ChildNodes[j].Name)
                            {
                                string value = xn.InnerText;
                                tablaHtml.Append(value);
                                break;
                            }
                        }
                        tablaHtml.Append("</td>");
                    }
                }
                tablaHtml.Append("</tr>");
            }
            tablaHtml.Append("</Table>");
            return mensaje ? "No se han seleccionado marcadores para esta sección" : tablaHtml.ToString();
        }

        /// <summary>
        /// Obteners the nodos cliente.
        /// </summary>
        /// <param name="xmlNodeList">The XML node list.</param>
        /// <param name="obtenerSoloDatosCliente">if set to <c>true</c> [obtener solo datos cliente].</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 28/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static XmlNodeList ObtenerNodosCliente(XmlNodeList xmlNodeList, bool obtenerSoloDatosCliente)
        {
            XmlDocument resultado = new XmlDocument();
            string nodosSeleccionados = string.Empty;
            for (int i = xmlNodeList.Count - 1; i >= 0; i--)
            {
                if (obtenerSoloDatosCliente && xmlNodeList[i].Name.ToUpper().Contains("CLIENTE"))
                {
                    nodosSeleccionados += xmlNodeList[i].OuterXml;
                }
                else if (!obtenerSoloDatosCliente && !xmlNodeList[i].Name.ToUpper().Contains("CLIENTE"))
                {
                    nodosSeleccionados += xmlNodeList[i].OuterXml;
                }
            }
            resultado.LoadXml(string.Format("<root><EncabezadoPoliza>{0}</EncabezadoPoliza></root>", nodosSeleccionados));
            return resultado.GetElementsByTagName("EncabezadoPoliza");
        }

        /// <summary>
        /// Construye la tabla plantillas por seguro.
        /// </summary>
        /// <param name="plantillas">The plantillas.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 28/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static string ConstruirTablaPlantillasPorSeguro(DocumentoPoliza[] plantillas)
        {
            StringBuilder tablaHtml = new StringBuilder();
            tablaHtml.Append("<Table class='table'>");
            tablaHtml.Append("<tr>");
            tablaHtml.Append("<th>");
            tablaHtml.Append("Nombre plantilla");
            tablaHtml.Append("</th>");
            tablaHtml.Append("<th>");
            tablaHtml.Append("Versión");
            tablaHtml.Append("</th>");
            tablaHtml.Append("<th>");
            tablaHtml.Append("Fecha de creación");
            tablaHtml.Append("</th>");
            tablaHtml.Append("<th>");
            tablaHtml.Append("Plantilla activa");
            tablaHtml.Append("</th>");
            tablaHtml.Append("<th>");
            tablaHtml.Append("");
            tablaHtml.Append("</th>");
            tablaHtml.Append("<th>");
            tablaHtml.Append("");
            tablaHtml.Append("</th>");
            tablaHtml.Append("<th>");
            tablaHtml.Append("");
            tablaHtml.Append("</th>");
            tablaHtml.Append("<th>");
            tablaHtml.Append("");
            tablaHtml.Append("</th>");
            tablaHtml.Append("</tr>");
            foreach (var item in plantillas)
            {
                tablaHtml.Append("<tr>");
                tablaHtml.Append("<td>");
                tablaHtml.Append(item.NombreArchivo);
                tablaHtml.Append("</td>");
                tablaHtml.Append("<td>");
                tablaHtml.Append(item.VersionDocumento);
                tablaHtml.Append("</td>");
                tablaHtml.Append("<td>");
                tablaHtml.Append(item.FechaCreacion.ToShortDateString().ToString(CultureInfo.CurrentCulture));
                tablaHtml.Append("</td>");
                tablaHtml.Append("<td>");
                tablaHtml.Append("<input type='checkbox' name='DocumentoPlantillaActivo" + item.IdDocumentoPoliza + "' id='chkDocumentoPlantillaActivo" + item.IdDocumentoPoliza + "' data-IdDocumentoPoliza='" + item.IdDocumentoPoliza + "'" + (item.Activa ? "checked='checked'" : string.Empty) + " OnClick='ActivarPlantilla(" + item.IdDocumentoPoliza + ");'/>");
                tablaHtml.Append("</td>");
                tablaHtml.Append("<td>");
                tablaHtml.Append("<input type='button' id='btnDescargarPlantilla" + item.IdDocumentoPoliza + "' value='DescargarPlantilla' data-IdDocumentoPoliza='" + item.IdDocumentoPoliza + "' OnClick='DescargarPlantilla(" + item.IdDocumentoPoliza + ");'/>");
                tablaHtml.Append("</td>");
                tablaHtml.Append("<td>");
                tablaHtml.Append("<input type='button' id='btnPrevisualizar" + item.IdDocumentoPoliza + "' value='Previsualizar' data-IdDocumentoPoliza='" + item.IdDocumentoPoliza + "' OnClick='PrevisualizarPlantillaSeleccionada(" + item.IdDocumentoPoliza + ");'/>");
                tablaHtml.Append("</td>");
                tablaHtml.Append("<td>");
                tablaHtml.Append("<input type='button' id='btnEditar" + item.IdDocumentoPoliza + "' value='Editar campos plantilla' data-IdDocumentoPoliza='" + item.IdDocumentoPoliza + "' OnClick='EditarPlantilla(" + item.IdDocumentoPoliza + ");'/>");
                tablaHtml.Append("</td>");
                tablaHtml.Append("<td>");
                tablaHtml.Append("<input type='button' id='btnEliminar" + item.IdDocumentoPoliza + "' value='Eliminar' data-IdDocumentoPoliza='" + item.IdDocumentoPoliza + "' OnClick='EliminarPlantilla(" + item.IdDocumentoPoliza + ");'/>");
                tablaHtml.Append("</td>");
                tablaHtml.Append("</tr>");
            }
            tablaHtml.Append("</Table>");
            return tablaHtml.ToString();
        }


        private class ProductoDinamicos
        {
            public string NombreCampo { get; set; }
            public string ValorCampo { get; set; }
            public int Orden { get; set; }
        }

        /// <summary>
        /// Construirs the PDF plantilla.
        /// </summary>
        /// <param name="CamposSeleccionados">The campos seleccionados.</param>
        /// <param name="archivoPlantilla">The archivo plantilla.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 29/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static Resultado ConstruirPdfPlantilla(string CamposSeleccionados, byte[] archivoPlantilla, int idSeguro)
        {
            Resultado resultado = new Resultado();
            string nombrePlantilla = DateTime.Now.ToString().Replace(':', '-').Replace('.', '1').Replace('/', '-') + DateTime.Now.Millisecond.ToString();
            try
            {
                //XmlDocument xmlDocumento = new XmlDocument();
                //xmlDocumento.Load(HttpContext.Current.Server.MapPath(Parametros.RutaArchivoXmlDummie));
                EntradaPrevisualizacionDocumentoPoliza entradaPrevisualizacionDocumentoPoliza = new EntradaPrevisualizacionDocumentoPoliza();
                entradaPrevisualizacionDocumentoPoliza.Campos = CamposSeleccionados;
                entradaPrevisualizacionDocumentoPoliza.Plantilla = archivoPlantilla == null ? PlantillaDocx : archivoPlantilla;
                entradaPrevisualizacionDocumentoPoliza.DatosXML = XmlDummie(idSeguro, "VariablesPolizaDocumento").OuterXml;

                var documentoPrevio = AdministradorProxy.ObtenerClienteAdministracion().PrevisualizarPlantilla(entradaPrevisualizacionDocumentoPoliza);
                string nombreArchivo = string.Concat(nombrePlantilla, Parametros.PuntoPDF);
                string rutaArchivo = string.Concat(Parametros.RutaArchivosPoliza, nombreArchivo);
                System.IO.File.WriteAllBytes(HttpContext.Current.Server.MapPath(rutaArchivo), documentoPrevio.ArchivoPolizaPdf.ToArray());
                entradaPrevisualizacionDocumentoPoliza = null;
                documentoPrevio = null;
                resultado.Mensaje = rutaArchivo;
            }
            catch (Exception exc)
            {
                resultado = AdministradorProxy.ObtenerClienteGenerico().GuardarError(Int32.Parse(LlavesUI.EventoPlantilla), exc.ToString(), LlavesUI.CatchConstruirPDF);
            }
            return resultado;
        }

        private static XmlDocument XmlDummie(int idSeguro, string seccionPoliza)
        {

            IList<VariableProducto> lpd = new List<VariableProducto>();
            if (seccionPoliza == "VariablesPolizaDocumento")
                lpd = ConsultarVariablesActivasProducto(idSeguro);

            XDocument xDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", string.Empty),
                new XElement("DatosPolizaDocumento",
                    new XElement("EncabezadoPoliza",
                        new XElement("FechaSolicitud", "20160309"),
                        new XElement("PrimerNombreCliente", "JORGE"),
                        new XElement("SegundoNombreCliente", "ANDRES"),
                        new XElement("PrimerApellidoCliente", "PRIETO"),
                        new XElement("SegundoApellidoCliente", "OTALORA"),
                        new XElement("NumeroIdentificacionCliente", "53879652"),
                        new XElement("TipoIdentificacionAbreviadoCliente", "CC"),
                        new XElement("TipoIdentificacionDescripcionCliente", "CEDULA DE CIUDADANIA"),
                        new XElement("FechaNacimientoCliente", "19280812"),
                        new XElement("CiudadNacimientoCliente", "CUNDINAMARCA"),
                        new XElement("GeneroCliente", "Masculino"),
                        new XElement("ActividadEconomicaCliente", "Profesor"),
                        new XElement("DireccionCliente", "CALLE 3 NO 8 45"),
                        new XElement("TelefonoCliente", "8356974"),
                        new XElement("CiudadResidenciaCliente", "CIRCASIA"),
                        new XElement("DepartamenoCliente", "QUINDIO"),
                        new XElement("NacionalidadCliente", "Colombiana"),
                        new XElement("CelularCliente", "3003100320"),
                        new XElement("TipoCuentaCliente", "CUENTA DE AHORROS"),
                        new XElement("NumeroCuentaCliente", "487654923171"),
                        new XElement("FechaVencimientoTarjetaCliente", "31/12/2010"),
                        new XElement("ConsecutivoPoliza", "183353879652168"),
                        new XElement("ValorPolizaSinIva", "706896.55"),
                        new XElement("ValorIvaPoliza", "113103.44"),
                        new XElement("ValorPrimaConIva", "820000.00"),
                        new XElement("Periodicidad", "Mensual"),
                        new XElement("PlanPoliza", "Plan A"),
                        new XElement("NombreOficina", "Principal"),
                        new XElement("CiudadOficina", "Bogota"),
                        new XElement("IdentificacionAsesor", "10200300"),
                        new XElement("NombreAsesor", "Andres Perez")
                        ),
                    new XElement("ConyugePolizaDocumento",
                        new XElement("PrimerNombreConyuge", "MARIA"),
                        new XElement("SegundoNombreConyuge", "LUZ"),
                        new XElement("PrimerApellidoConyuge", "PEREZ"),
                        new XElement("SegundoApellidoConyuge", "MARTINEZ"),
                        new XElement("TipoIdentificacionAbreviaturaConyuge", "CC"),
                        new XElement("NumeroIdentificacionConyuge", "1023852147"),
                        new XElement("FechaNacimientoConyuge", "01/01/1980"),
                        new XElement("CiudadNacimientoConyuge", "BOYACA"),
                        new XElement("GeneroConyuge", "Femenino"),
                        new XElement("DireccionConyuge", "CRA 7 # 22 - 45"),
                        new XElement("CiudadResidenciaConyuge", "BOGOTA"),
                        new XElement("TelefonoConyuge", "4235612")
                        ),
                        new XElement("BeneficiariosPolizaDocumento",
                            new XElement("BeneficiariosPolizaDocumento",
                                new XElement("NombreCompletoBeneficiario", "MARIO TORRES"),
                                new XElement("NombreBeneficiario", "MARIO"),
                                new XElement("ApellidoBeneficiario", "TORRES"),
                                new XElement("TipoNumeroIdentificacionBeneficiario", "CC 1021244"),
                                new XElement("TipoIdentificacionAbreviaturaBeneficiario", "CC"),
                                new XElement("NumeroIdentificacionBeneficiario", "1021244"),
                                new XElement("PorcentajeParticipacion", "60")
                                ),
                             new XElement("BeneficiariosPolizaDocumento",
                                new XElement("NombreCompletoBeneficiario", "JUAN TORRES"),
                                new XElement("NombreBeneficiario", "JUAN"),
                                new XElement("ApellidoBeneficiario", "TORRES"),
                                new XElement("TipoNumeroIdentificacionBeneficiario", "CC 1021232"),
                                new XElement("TipoIdentificacionAbreviaturaBeneficiario", "CC"),
                                new XElement("NumeroIdentificacionBeneficiario", "1021232"),
                                new XElement("PorcentajeParticipacion", "40")
                                )/*,
                                new XElement("BeneficiariosPolizaDocumento",
                                new XElement("NombreCompletoBeneficiario", "MARIO TORRES"),
                                new XElement("NombreBeneficiario", "MARIO"),
                                new XElement("ApellidoBeneficiario", "TORRES"),
                                new XElement("TipoNumeroIdentificacionBeneficiario", "CC 1021244"),
                                new XElement("TipoIdentificacionAbreviaturaBeneficiario", "CC"),
                                new XElement("NumeroIdentificacionBeneficiario", "1021244"),
                                new XElement("PorcentajeParticipacion", "60")
                                ),
                             new XElement("BeneficiariosPolizaDocumento",
                                new XElement("NombreCompletoBeneficiario", "JUAN TORRES"),
                                new XElement("NombreBeneficiario", "JUAN"),
                                new XElement("ApellidoBeneficiario", "TORRES"),
                                new XElement("TipoNumeroIdentificacionBeneficiario", "CC 1021232"),
                                new XElement("TipoIdentificacionAbreviaturaBeneficiario", "CC"),
                                new XElement("NumeroIdentificacionBeneficiario", "1021232"),
                                new XElement("PorcentajeParticipacion", "40")
                                ),
                                new XElement("BeneficiariosPolizaDocumento",
                                new XElement("NombreCompletoBeneficiario", "MARIO TORRES"),
                                new XElement("NombreBeneficiario", "MARIO"),
                                new XElement("ApellidoBeneficiario", "TORRES"),
                                new XElement("TipoNumeroIdentificacionBeneficiario", "CC 1021244"),
                                new XElement("TipoIdentificacionAbreviaturaBeneficiario", "CC"),
                                new XElement("NumeroIdentificacionBeneficiario", "1021244"),
                                new XElement("PorcentajeParticipacion", "60")
                                ),
                             new XElement("BeneficiariosPolizaDocumento",
                                new XElement("NombreCompletoBeneficiario", "JUAN TORRES"),
                                new XElement("NombreBeneficiario", "JUAN"),
                                new XElement("ApellidoBeneficiario", "TORRES"),
                                new XElement("TipoNumeroIdentificacionBeneficiario", "CC 1021232"),
                                new XElement("TipoIdentificacionAbreviaturaBeneficiario", "CC"),
                                new XElement("NumeroIdentificacionBeneficiario", "1021232"),
                                new XElement("PorcentajeParticipacion", "40")
                                ),
                             new XElement("BeneficiariosPolizaDocumento",
                                new XElement("NombreCompletoBeneficiario", "JUAN TORRES"),
                                new XElement("NombreBeneficiario", "JUAN"),
                                new XElement("ApellidoBeneficiario", "TORRES"),
                                new XElement("TipoNumeroIdentificacionBeneficiario", "CC 1021232"),
                                new XElement("TipoIdentificacionAbreviaturaBeneficiario", "CC"),
                                new XElement("NumeroIdentificacionBeneficiario", "1021232"),
                                new XElement("PorcentajeParticipacion", "40")
                                ),
                                new XElement("BeneficiariosPolizaDocumento",
                                new XElement("NombreCompletoBeneficiario", "MARIO TORRES"),
                                new XElement("NombreBeneficiario", "MARIO"),
                                new XElement("ApellidoBeneficiario", "TORRES"),
                                new XElement("TipoNumeroIdentificacionBeneficiario", "CC 1021244"),
                                new XElement("TipoIdentificacionAbreviaturaBeneficiario", "CC"),
                                new XElement("NumeroIdentificacionBeneficiario", "1021244"),
                                new XElement("PorcentajeParticipacion", "60")
                                ),
                             new XElement("BeneficiariosPolizaDocumento",
                                new XElement("NombreCompletoBeneficiario", "JUAN TORRES"),
                                new XElement("NombreBeneficiario", "JUAN"),
                                new XElement("ApellidoBeneficiario", "TORRES"),
                                new XElement("TipoNumeroIdentificacionBeneficiario", "CC 1021232"),
                                new XElement("TipoIdentificacionAbreviaturaBeneficiario", "CC"),
                                new XElement("NumeroIdentificacionBeneficiario", "1021232"),
                                new XElement("PorcentajeParticipacion", "40")
                                ),
                                new XElement("BeneficiariosPolizaDocumento",
                                new XElement("NombreCompletoBeneficiario", "MARIO TORRES"),
                                new XElement("NombreBeneficiario", "MARIO"),
                                new XElement("ApellidoBeneficiario", "TORRES"),
                                new XElement("TipoNumeroIdentificacionBeneficiario", "CC 1021244"),
                                new XElement("TipoIdentificacionAbreviaturaBeneficiario", "CC"),
                                new XElement("NumeroIdentificacionBeneficiario", "1021244"),
                                new XElement("PorcentajeParticipacion", "60")
                                ),
                             new XElement("BeneficiariosPolizaDocumento",
                                new XElement("NombreCompletoBeneficiario", "JUAN TORRES"),
                                new XElement("NombreBeneficiario", "JUAN"),
                                new XElement("ApellidoBeneficiario", "TORRES"),
                                new XElement("TipoNumeroIdentificacionBeneficiario", "CC 1021232"),
                                new XElement("TipoIdentificacionAbreviaturaBeneficiario", "CC"),
                                new XElement("NumeroIdentificacionBeneficiario", "1021232"),
                                new XElement("PorcentajeParticipacion", "40")
                                )*/),

                         new XElement("VariablesPolizaDocumento",
                          from c in lpd
                          select
                              new XElement("CampoVariable" + c.Orden.ToString(), c.NombreCampo)
                        )));

            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
                xmlDocument.Load(xmlReader);

            return xmlDocument;


        }

        /// <summary>
        /// Construirs the plantilla.
        /// </summary>
        /// <param name="archivoPlantilla">The archivo plantilla.</param>
        /// <param name="nombrePlantilla">The nombre plantilla.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 12/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static Resultado ConstruirPlantilla(byte[] archivoPlantilla, string nombrePlantilla)
        {
            Resultado resultado = new Resultado();
            try
            {
                XmlDocument xmlDocumento = new XmlDocument();
                string nombreArchivo = string.Concat(nombrePlantilla, Parametros.PuntoDocx);
                string rutaArchivo = string.Concat(Parametros.RutaArchivosPoliza, nombreArchivo);
                System.IO.File.WriteAllBytes(HttpContext.Current.Server.MapPath(rutaArchivo), archivoPlantilla);
                resultado.Mensaje = rutaArchivo;
            }
            catch (Exception exc)
            {
                resultado = AdministradorProxy.ObtenerClienteGenerico().GuardarError(Int32.Parse(LlavesUI.EventoPlantilla), exc.ToString(), LlavesUI.CatchConstruirPlantilla);
            }
            return resultado;
        }

        /// <summary>
        /// Obteners the titulo por nombre nodo.
        /// </summary>
        /// <param name="nombreNodo">The nombre nodo.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 30/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static string ObtenerTituloPorNombreNodo(string nombreNodo)
        {
            Dictionary<string, string> listaTitulosPorNombreNodo = new Dictionary<string, string>();
            listaTitulosPorNombreNodo.Add("FechaSolicitud", "Fecha de Solicitúd");
            listaTitulosPorNombreNodo.Add("ConsecutivoPoliza", "Consecutivo de la póliza");
            listaTitulosPorNombreNodo.Add("ValorPolizaSinIva", "Valor de la póliza sin IVA");
            listaTitulosPorNombreNodo.Add("ValorIvaPoliza", "Valor IVA de la póliza");
            listaTitulosPorNombreNodo.Add("ValorPrimaConIva", "Valor de la prima con IVA");
            listaTitulosPorNombreNodo.Add("Periodicidad", "Periodicidad");
            listaTitulosPorNombreNodo.Add("PlanPoliza", "Plan Poliza");
            listaTitulosPorNombreNodo.Add("PrimerNombreCliente", "Primer nombre");
            listaTitulosPorNombreNodo.Add("SegundoNombreCliente", "Segundo nombre");
            listaTitulosPorNombreNodo.Add("PrimerApellidoCliente", "Primer apellido");
            listaTitulosPorNombreNodo.Add("SegundoApellidoCliente", "Segundo apellido");
            listaTitulosPorNombreNodo.Add("NumeroIdentificacionCliente", "Número identificación");
            listaTitulosPorNombreNodo.Add("TipoIdentificacionAbreviadoCliente", "Tipo de identificación abreviado");
            listaTitulosPorNombreNodo.Add("FechaNacimientoCliente", "Fecha de nacimiento");
            listaTitulosPorNombreNodo.Add("CiudadNacimientoCliente", "Ciudad de nacimiento");
            listaTitulosPorNombreNodo.Add("GeneroCliente", "Género");
            listaTitulosPorNombreNodo.Add("ActividadEconomicaCliente", "Actividad económica");
            listaTitulosPorNombreNodo.Add("DireccionCliente", "Dirección de residencia");
            listaTitulosPorNombreNodo.Add("TelefonoCliente", "Teléfono");
            listaTitulosPorNombreNodo.Add("CiudadResidenciaCliente", "Ciudad de residencia");
            listaTitulosPorNombreNodo.Add("DepartamenoCliente", "Departameno");
            listaTitulosPorNombreNodo.Add("NacionalidadCliente", "Nacionalidad");
            listaTitulosPorNombreNodo.Add("CelularCliente", "Celular");
            listaTitulosPorNombreNodo.Add("TipoCuentaCliente", "Tipo de cuenta");
            listaTitulosPorNombreNodo.Add("NumeroCuentaCliente", "Número cuenta");
            listaTitulosPorNombreNodo.Add("FechaVencimientoTarjetaCliente", "Fecha de vencimiento de la tarjeta");
            listaTitulosPorNombreNodo.Add("PrimerNombreConyuge", "Primer nombre");
            listaTitulosPorNombreNodo.Add("SegundoNombreConyuge", "Segundo nombre");
            listaTitulosPorNombreNodo.Add("PrimerApellidoConyuge", "Primer apellido");
            listaTitulosPorNombreNodo.Add("SegundoApellidoConyuge", "Segundo apellido");
            listaTitulosPorNombreNodo.Add("TipoIdentificacionAbreviaturaConyuge", "Tipo de identificación abreviada");
            listaTitulosPorNombreNodo.Add("NumeroIdentificacionConyuge", "Número de identificación");
            listaTitulosPorNombreNodo.Add("FechaNacimientoConyuge", "Fecha nacimiento");
            listaTitulosPorNombreNodo.Add("CiudadNacimientoConyuge", "Ciudad de nacimiento");
            listaTitulosPorNombreNodo.Add("GeneroConyuge", "Genero");
            listaTitulosPorNombreNodo.Add("DireccionConyuge", "Dirección");
            listaTitulosPorNombreNodo.Add("CiudadResidenciaConyuge", "Ciudad de residencia");
            listaTitulosPorNombreNodo.Add("TelefonoConyuge", "Teléfono");
            listaTitulosPorNombreNodo.Add("NombreCompletoBeneficiario", "Nombre completo");
            listaTitulosPorNombreNodo.Add("NombreBeneficiario", "Nombres");
            listaTitulosPorNombreNodo.Add("ApellidoBeneficiario", "Apellidos");
            listaTitulosPorNombreNodo.Add("TipoNumeroIdentificacionBeneficiario", "Tipo y número de identificación");
            listaTitulosPorNombreNodo.Add("TipoIdentificacionAbreviaturaBeneficiario", "Tipo identificación abreviado");
            listaTitulosPorNombreNodo.Add("NumeroIdentificacionBeneficiario", "Número de identificación");
            listaTitulosPorNombreNodo.Add("PorcentajeParticipacion", "Porcentaje de participación");
            return listaTitulosPorNombreNodo.FirstOrDefault(nodo => nodo.Key.Equals(nombreNodo)).Value;
        }

        /// <summary>
        /// Validates insuirance state and show a respective message.
        /// </summary>
        /// <param name="IdSeguro">The identifier insurance.</param>
        /// <param name="resultado">The resultado object.</param>
        /// <returns>A resultado object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 13/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static Resultado ValidarEstadoSeguro(int IdSeguro, Resultado resultado, bool activa)
        {
            if (activa)
            {
                var seguros = ObtenerSeguros();
                var seguroSeleccionado = seguros.Where(s => s.IdSeguro.Equals(IdSeguro)).FirstOrDefault();
                resultado.Mensaje = seguroSeleccionado.Activo ? Mensajes.MensajeSeguroActivo : Mensajes.MensajeSeguroInactivo;
            }
            else
                resultado.Mensaje = Mensajes.MensajePreguardar;
            
            return resultado;
        }


        /// <summary>
        /// Search the variables active product.
        /// </summary>
        /// <param name="idSeguro">The identifier seguro.</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IList<VariableProducto> ConsultarVariablesActivasProducto(int idSeguro)
        {
            VariableProducto variableBusqueda = new VariableProducto();
            variableBusqueda.IdSeguro = idSeguro;
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarVariablesProductoActivas(variableBusqueda);
        }



        #endregion

    }

}