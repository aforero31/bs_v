using BancaSeguros.Infraestructura.Configuraciones;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using Microsoft.Office.Interop.Word;
using System;
using System.Configuration;


namespace BancaSeguros.Infraestructura.ManejoDocumentos
{

    public class PreviewDocumentoPlantilla
    {

        /// <summary>
        /// The word processing GML
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 18/02/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private static XNamespace WordProcessingGml = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";

        /// <summary>
        /// Retorna un elemento por nombre
        /// </summary>
        /// <param name="ancestor"></param>
        /// <param name="tag"></param>
        /// <returns>lo que sea</returns>
        private static XElement GetContentControlByTag(XContainer ancestor, string tag)
        {
            return UtilidadesManejoDocumentos.GetContentControlByTag(ancestor, tag);
        }

        /// <summary>
        /// Retorna el contenido de un control
        /// </summary>
        /// <param name="contentControl"></param>
        /// <returns></returns>
        static string GetContentControlContents(XElement contentControl)
        {
            return UtilidadesManejoDocumentos.GetContentControlContents(contentControl);
        }

        static object Transform(XNode node, XElement document)
        {
            return UtilidadesManejoDocumentos.Transform(node, document);
        }

        /// <summary>
        /// Inserta la informacion dentro del documento plantilla y retorna un archivo en arreglo de bytes
        /// </summary>
        /// <param name="document"></param>
        /// <param name="name"></param>
        /// <param name="plantilla"></param>
        /// <returns>Archivo en arreglo de bytes</returns>
        public static byte[] GenerarDocumento(XElement document, byte[] plantilla, string rutaArchivo)
        {
            byte[] resultado;
            string fileName = DateTime.Now.ToString().Replace(':', '-').Replace('.', '1').Replace('/', '-') + DateTime.Now.Millisecond.ToString() + ".docx";

            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(plantilla, 0, (int)plantilla.Length);
                using (WordprocessingDocument documentoWord = WordprocessingDocument.Open(memoryStream, true))
                {
                    XDocument documentoXml = documentoWord.MainDocumentPart.ObtenerXDocument();
                    XElement nuevoElementoRaiz = (XElement)Transform(documentoWord.MainDocumentPart.ObtenerXDocument().Root, document);
                    documentoXml.Elements().First().ReplaceWith(nuevoElementoRaiz);
                    documentoWord.MainDocumentPart.GuardarDocumento();
                }

                resultado = memoryStream.ToArray();

                var carpetaRecursos = rutaArchivo + fileName;
                using (FileStream fileStream = new FileStream(carpetaRecursos,
                 System.IO.FileMode.CreateNew))
                    memoryStream.WriteTo(fileStream);

                resultado = ConvertWord2PDF(fileName, rutaArchivo);
                File.Delete(rutaArchivo + fileName);

            }
            return resultado;
        }

        private static byte[] ConvertWordToPdfArray(byte[] documento, string documentoWord, string rutaArchivo)
        {
            byte[] resultado;
            object missParam = Type.Missing;
            string nombrePdf = DateTime.Now.ToString().Replace(':', '-').Replace('.', '1').Replace('/', '-') + DateTime.Now.Millisecond.ToString() + ".pdf";
            Application word = new Application();
            Document doc = word.Documents.Open(documentoWord);
            doc.Activate();
            doc.SaveAs2(rutaArchivo + @"\" + nombrePdf, WdSaveFormat.wdFormatPDF, ref missParam, ref missParam, ref missParam, ref missParam, ref missParam, ref missParam, ref missParam, false, false, ref missParam, ref missParam, ref missParam, ref missParam, ref missParam, ref missParam);
            doc.Close();
            word.Quit();

            resultado = File.ReadAllBytes(rutaArchivo + @"\" + nombrePdf);
            File.Delete(rutaArchivo + @"\" + nombrePdf);
            return resultado;
        }

        private static byte[] ConvertWord2PDF(string nombrearchivo, string rutaArchivo)
        {
            byte[] resultado;
            string inputFile = rutaArchivo + nombrearchivo;
            string outputPath = Path.ChangeExtension(rutaArchivo + nombrearchivo, ".pdf"); ;
            try
            {
                if (outputPath.Equals("") || !File.Exists(inputFile))
                {
                    throw new Exception("Either file does not exist or invalid output path");
                }

                // app to open the document belower
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Document wordDocument = new Document();

                // input variables
                object objInputFile = inputFile;
                object missParam = Type.Missing;

                wordDocument = wordApp.Documents.Open(ref objInputFile, ref missParam, ref missParam, ref missParam,
                    ref missParam, ref missParam, ref missParam, ref missParam, ref missParam, ref missParam,
                    ref missParam, ref missParam, ref missParam, ref missParam, ref missParam, ref missParam);

                if (wordDocument != null)
                {
                    // make the convertion
                    wordDocument.ExportAsFixedFormat(outputPath, WdExportFormat.wdExportFormatPDF, false,
                        WdExportOptimizeFor.wdExportOptimizeForOnScreen, WdExportRange.wdExportAllDocument,
                        0, 0, WdExportItem.wdExportDocumentContent, true, true,
                        WdExportCreateBookmarks.wdExportCreateWordBookmarks, true, true, false, ref missParam);
                }

                // close document and quit application
                wordDocument.Close();
                wordApp.Quit();
                resultado = File.ReadAllBytes(outputPath);
                File.Delete(outputPath);
            }

            catch (Exception e)
            {
                throw e;
            }

            return resultado;
        }

    }
}
