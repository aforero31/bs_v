
namespace BancaSeguros.Infraestructura.ManejoDocumentos
{
    using DocumentFormat.OpenXml.Packaging;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\CPIZA
    /// CreationDate: 18/02/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public static class ExtencionesLocales
    {
        /// <summary>
        /// Concaternar cadena.
        /// </summary>
        /// <param name="fuente">fuente.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 18/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public static string ConcaternarCadena(this IEnumerable<string> fuente)
        {
            StringBuilder ConstructorCadena = new StringBuilder();
            foreach (string item in fuente) ConstructorCadena.Append(item);
            return ConstructorCadena.ToString();
        }

        /// <summary>
        /// Obtiene el documento como XDocument.
        /// </summary>
        /// <param name="parteEstructura">Parte estructura.</param>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 18/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public static XDocument ObtenerXDocument(this OpenXmlPart parteEstructura)
        {
            XDocument documento = parteEstructura.Annotation<XDocument>();
            if (documento != null) return documento;
            using (StreamReader streamReader = new StreamReader(parteEstructura.GetStream()))
            using (XmlReader lectorEstructura = XmlReader.Create(streamReader))
                documento = XDocument.Load(lectorEstructura);
            parteEstructura.AddAnnotation(documento);
            return documento;
        }

        /// <summary>
        /// Guarda el documento en una ruta especificada.
        /// </summary>
        /// <param name="estructura">The estructura.</param>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 18/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public static void GuardarDocumento(this OpenXmlPart estructura)
        {
            XDocument documento = estructura.ObtenerXDocument();
            if (documento != null)
                using (XmlWriter xmlWriter = XmlWriter.Create(estructura.GetStream
                  (FileMode.Create, FileAccess.Write)))
                    documento.Save(xmlWriter);
        }
    }
}
