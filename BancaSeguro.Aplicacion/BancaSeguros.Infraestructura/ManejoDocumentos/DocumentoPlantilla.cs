
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
using System.Drawing;
using System.Drawing.Imaging;

namespace BancaSeguros.Infraestructura.ManejoDocumentos
{

    public class DocumentoPlantilla
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
        /// <returns>Nombre Documento</returns>
        public static string GenerarDocumento(XElement document, byte[] plantilla, string rutaArchivo)
        {
            bool Retorno = false;
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

                var carpetaRecursos = rutaArchivo + fileName;
                using (FileStream fileStream = new FileStream(carpetaRecursos, System.IO.FileMode.CreateNew))
                    memoryStream.WriteTo(fileStream);

                Retorno = true;
            }

            return fileName;
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

        /// <summary>
        /// Convierte archivo word a Pdf.
        /// </summary>
        /// <param name="rutaword"></param>
        /// <returns>Archivo en arreglo de bytes</returns>
        /// <exception cref="System.Exception">Either file does not exist or invalid output path</exception>
        public static byte[] ConvertWord2PDF(string rutaword)
        {
            byte[] resultado = null;
            string inputFile = rutaword;
            string outputPath = Path.ChangeExtension(rutaword, ".pdf");
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document wordDocument = null;
            object objInputFile = inputFile;
            object missParam = Type.Missing;
            try
            {
                if (outputPath.Equals("") || !File.Exists(inputFile))
                {
                    throw new Exception("Either file does not exist or invalid output path");
                }
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
                resultado = File.ReadAllBytes(outputPath);
            }
            catch (Exception e)
            {
                System.Text.StringBuilder s = new System.Text.StringBuilder();
                while (e != null)
                {
                    s.AppendLine("Exception type: " + e.GetType().FullName);
                    s.AppendLine("Message       : " + e.Message);
                    s.AppendLine("Stacktrace:");
                    s.AppendLine(e.StackTrace);
                    s.AppendLine();
                    e = e.InnerException;
                }
            }
            finally
            {
                if (wordDocument != null)
                {
                    wordDocument.Close(ref missParam, ref missParam, ref missParam);
                    wordDocument = null;
                }
                if (wordApp != null)
                {
                    wordApp.Quit(ref missParam, ref missParam, ref missParam);
                    wordApp = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            return resultado;
        }

        /// <summary>
        /// Convierte archivo PDF a imange PNG.
        /// </summary>
        /// <param name="rutaPdf"></param>
        /// <returns>Archivo en arreglo de bytes</returns>
        public static byte[] ConvertPdfToPng(string rutaPdf)
        {
            byte[] resultado;
            PdfConversion.Pdf2Image convertor;
            convertor = new PdfConversion.Pdf2Image(rutaPdf);
            System.Drawing.Bitmap image = null;
            string imagen = Path.ChangeExtension(rutaPdf, ".png");
            System.Drawing.Bitmap[] imagenes = convertor.GetImages();
            for (int i = 0; i < convertor.PageCount; i++)
            {
                if (image == null)
                {
                    image = MergeTwoImages(imagenes[0], imagenes[1]);
                    i = 1;
                }
                else
                    image = MergeTwoImages(image, imagenes[i]);
            }
            Bitmap resized = new Bitmap(image, new Size(image.Width / 2, image.Height / 2));
            resized.Save(imagen, ImageFormat.Jpeg);
            resultado = File.ReadAllBytes(Path.ChangeExtension(rutaPdf, ".png"));
            return resultado;
        }

        /// <summary>
        /// Combina dos imagenes en una sola
        /// </summary>
        /// <param name="firstImage"></param>
        /// <param name="secondImage"></param>
        /// <returns>un BitMap</returns>
        /// <exception cref="System.ArgumentNullException">
        /// firstImage
        /// or
        /// secondImage
        /// </exception>
        private static Bitmap MergeTwoImages(Image firstImage, Image secondImage)
        {
            if (firstImage == null)
            {
                throw new ArgumentNullException("firstImage");
            }

            if (secondImage == null)
            {
                throw new ArgumentNullException("secondImage");
            }

            int outputImageWidth = firstImage.Width > secondImage.Width ? firstImage.Width : secondImage.Width;

            int outputImageHeight = firstImage.Height + secondImage.Height + 1;

            Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                graphics.DrawImage(firstImage, new System.Drawing.Rectangle(new System.Drawing.Point(), firstImage.Size),
                    new System.Drawing.Rectangle(new System.Drawing.Point(), firstImage.Size), GraphicsUnit.Pixel);
                graphics.DrawImage(secondImage, new System.Drawing.Rectangle(new System.Drawing.Point(0, firstImage.Height + 1), secondImage.Size),
                    new System.Drawing.Rectangle(new System.Drawing.Point(), secondImage.Size), GraphicsUnit.Pixel);
            }

            return outputImage;
        }

        /// <summary>
        /// Enviar the archivo a imprimir.
        /// </summary>
        /// <param name="RutaArchivo">The ruta archivo.</param>
        /// <returns>Verdadero o Falso</returns>
        /// <remarks>
        /// Author: UT2013\Enrique Rivera
        /// CreationDate: 15/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>  
        public static bool EnviarArchivoaImprimir(string RutaArchivo)
        {
            return PdfConversion.RawPrinterHelper.SendFileToPrinter(RutaArchivo);
        }

        /// <summary>
        /// Convierte archivo word a Pdf y retorna ruta.
        /// </summary>
        /// <param name="rutaword"></param>
        /// <param name="rutaPdf"></param>
        /// <returns>Archivo en arreglo de bytes</returns>
        /// <exception cref="System.Exception">Either file does not exist or invalid output path</exception>
        public static string ObtenerRutaConvertWord2PDF(string rutaword, string rutaPdf)
        {
            string resultado = string.Empty;
            string inputFile = rutaword;
            string outputPath = rutaPdf;
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document wordDocument = null;
            object objInputFile = inputFile;
            object missParam = Type.Missing;
            try
            {
                if (outputPath.Equals("") || !File.Exists(inputFile))
                {
                    throw new Exception("Either file does not exist or invalid output path");
                }
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
                resultado = outputPath;
            }
            catch (Exception e)
            {
                System.Text.StringBuilder s = new System.Text.StringBuilder();
                while (e != null)
                {
                    s.AppendLine("Exception type: " + e.GetType().FullName);
                    s.AppendLine("Message       : " + e.Message);
                    s.AppendLine("Stacktrace:");
                    s.AppendLine(e.StackTrace);
                    s.AppendLine();
                    e = e.InnerException;
                }
            }
            finally
            {
                if (wordDocument != null)
                {
                    wordDocument.Close(ref missParam, ref missParam, ref missParam);
                    wordDocument = null;
                }
                if (wordApp != null)
                {
                    wordApp.Quit(ref missParam, ref missParam, ref missParam);
                    wordApp = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            return resultado;
        }

    }
}
