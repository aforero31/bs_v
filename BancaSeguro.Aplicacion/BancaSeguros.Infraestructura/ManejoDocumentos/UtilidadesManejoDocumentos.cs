using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using Microsoft.Office.Interop.Word;

namespace BancaSeguros.Infraestructura.ManejoDocumentos
{
    public static class UtilidadesManejoDocumentos
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
        public static XElement GetContentControlByTag(XContainer ancestor, string tag)
        {
            //return ancestor.Descendants(string.Concat(WordProcessingGml, Parametros.sdt)).Where(e => e.Elements(string.Concat(WordProcessingGml, Parametros.sdtPr)).Elements(string.Concat(WordProcessingGml, Parametros.alias)).Attributes(string.Concat(WordProcessingGml, Parametros.val)).FirstOrDefault().Value.Equals(tag)).FirstOrDefault();
            return ancestor.Descendants(WordProcessingGml + "sdt").Where(e => e.Elements(WordProcessingGml + "sdtPr").Elements(WordProcessingGml + "alias").Attributes(WordProcessingGml + "val").FirstOrDefault().Value == tag).FirstOrDefault();
        }

        /// <summary>
        /// Retorna el contenido de un control
        /// </summary>
        /// <param name="contentControl"></param>
        /// <returns></returns>
        public static string GetContentControlContents(XElement contentControl)
        {
            return contentControl.Element(WordProcessingGml + "sdtContent")
                .Descendants(WordProcessingGml + "t")
                .Select(t => (string)t)
                .ConcaternarCadena();
        }

        public static object Transform(XNode node, XElement document)
        {
            XElement element = node as XElement;
            if (element != null)
            {
                if (element.Name == WordProcessingGml + "sdt")
                {
                    string tag = element.Elements(WordProcessingGml + "sdtPr")
                        .Elements(WordProcessingGml + "alias")
                        .Attributes(WordProcessingGml + "val")
                        .FirstOrDefault()
                        .Value;
                    if (tag == "Config") return null;
                    if (tag == "SelectValue")
                    {
                        XElement run = element.Element(WordProcessingGml + "sdtContent").Element(WordProcessingGml + "r");
                        if (run != null)
                        {
                            string valueSelector = GetContentControlContents(element);
                            string newValue = string.Empty;
                            if (document.XPathSelectElement(valueSelector) != null)
                                newValue = document.XPathSelectElement(valueSelector).Value;
                            return (new XElement(WordProcessingGml + "r", run.Elements().Where(e => e.Name != WordProcessingGml + "t"), new XElement(WordProcessingGml + "t", newValue)));
                        }
                    }
                    if (tag == "Repeat")
                    {
                        XElement contentContentControl = GetContentControlByTag(element, "Content");
                        XElement selectRepeatingDataContentControl =
                            GetContentControlByTag(element, "SelectRepeatingData");
                        string selector = GetContentControlContents(selectRepeatingDataContentControl);
                        var repeatingData = document.XPathSelectElements(selector);
                        var newContent = repeatingData.Select(d =>
                        {
                            var content = contentContentControl.Element(WordProcessingGml + "sdtContent")
                                .Elements().Select(e => Transform(e, d)).ToList();
                            return content;
                        })
                            .ToList();
                        return newContent;
                    }
                    if (tag == "Table")
                    {
                        XElement content = GetContentControlByTag(element, "Content");
                        XElement selectRowsContentControl =
                            GetContentControlByTag(element, "SelectRows");
                        string selector = GetContentControlContents(selectRowsContentControl);
                        var tableData = document.XPathSelectElements(selector);
                        XElement table = content.Descendants(WordProcessingGml + "tbl").FirstOrDefault();
                        XElement protoRow = table.Elements(WordProcessingGml + "tr").Skip(1).FirstOrDefault();
                        XElement newTable = new XElement(WordProcessingGml + "tbl",
                            table.Elements().Where(e => e.Name != WordProcessingGml + "tr"),
                            table.Elements(WordProcessingGml + "tr").FirstOrDefault(),
                            tableData.Select(d =>
                                new XElement(WordProcessingGml + "tr",
                                    protoRow.Elements().Where(r => r.Name != WordProcessingGml + "tc"),
                                    protoRow.Elements(WordProcessingGml + "tc")
                                        .Select(tc =>
                                        {
                                            XElement paragraph = tc.Elements(WordProcessingGml + "p")
                                                .FirstOrDefault();
                                            XElement run = paragraph.Elements(WordProcessingGml + "r")
                                                .FirstOrDefault();
                                            string cellSelector = paragraph.Value;
                                            string cellData =
                                                d.XPathSelectElement(cellSelector).Value;
                                            XElement newCell = new XElement(WordProcessingGml + "tc",
                                                tc.Elements().Where(z => z.Name != WordProcessingGml + "p"),
                                                new XElement(WordProcessingGml + "p",
                                                    paragraph.Elements().Where(z1 => z1.Name != WordProcessingGml + "r"),
                                                    new XElement(WordProcessingGml + "r",
                                                        run.Elements().Where(z2 => z2.Name != WordProcessingGml + "t"),
                                                        new XElement(WordProcessingGml + "t", cellData))));
                                            return newCell;
                                        }))));
                        return newTable;
                    }
                    if (tag == "Conditional")
                    {
                        XElement selectTestValueContentControl =
                            GetContentControlByTag(element, "SelectTestValue");
                        string selectTestValue =
                            GetContentControlContents(selectTestValueContentControl);
                        string match = GetContentControlContents(
                            GetContentControlByTag(element, "Match"));
                        XElement contentContentControl =
                            GetContentControlByTag(element, "Content");
                        string value =
                            document.XPathSelectElement(selectTestValue).Value;
                        if (value == match)
                        {
                            var content = contentContentControl.Element(WordProcessingGml + "sdtContent")
                                .Elements().Select(e => Transform(e, document));
                            return content;
                        }
                        else
                            return null;
                    }
                }
                return new XElement(element.Name,
                    element.Attributes(),
                    element.Nodes().Select(n => Transform(n, document)));
            }
            return node;
        }

    }
}
