using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BancaSeguros.Aplicacion.Venta;
using System.IO;
using BancaSeguros.Entidades.Seguro;
using BancaSeguros;
using Moq;
using BancaSeguros.Repositorio.Venta;
using BancaSeguros.Entidades;
using BancaSeguros.Entidades.General;
using BancaSeguros.Aplicacion.Administracion;

namespace BancaSeguros.Tests.AplicacionTest.VentaTest
{
    [TestClass]
    public class InsertarDocumentoPlantillaSeguroTest
    {
        //[TestMethod]
        //public void CuandoInsertaUnDocumentoRetornaErrorEnFalse()
        //    {
        //    //arrange
        //    var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
        //    var mockRepositorioVenta = new Mock<IRepositorioVenta>();
        //    var mockRepositorioPlan = new Mock<IRepositorioPlan>();
        //    var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
        //    var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
        //    var documentoPoliza = ObtenerParametrosEntrada();
        //    var resultadoMock = new Resultado();
        //    mockRepositorioDocumentoPoliza.Setup(x => x.InsertarDocumentoPlantillaSeguro(documentoPoliza)).Returns(resultadoMock);
        //    //GestionVenta registroVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object);
        //    Resultado resultadoOperacion = new Resultado();

        //    var mockRepositorioCanalVenta = new Mock<Repositorio.Administracion.IRepositorioCanalVenta>();
        //    var mockRepositorioParametro = new Mock<Repositorio.Administracion.IRepositorioParametro>();
       
        //    GestionAdministracion registroAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object,
        //        mockRepositorioCanalVenta.Object, mockRepositorioParametro.Object);
        //                //act
        //    resultadoOperacion = registroAdministracion.InsertarDocumentoPlantillaSeguro(documentoPoliza);

        //    //assert
        //    Assert.IsFalse(resultadoOperacion.Error);
        //}

        //[TestMethod]
        //public void CuandoInsertaUnDocumentoConIdDocumentoPolizaRetornaErrorFalse()
        //{
        //    //arrange
        //    var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
        //    var mockRepositorioVenta = new Mock<IRepositorioVenta>();
        //    var mockRepositorioPlan = new Mock<IRepositorioPlan>();
        //    var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
        //    var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
        //    var documentoPoliza = ObtenerParametrosEntrada();
        //    var resultadoMock = new Resultado();
        //    documentoPoliza.IdDocumentoPoliza = 1;
        //    mockRepositorioDocumentoPoliza.Setup(x => x.InsertarDocumentoPlantillaSeguro(documentoPoliza)).Returns(resultadoMock);
        //    GestionVenta registroVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object);
        //    Resultado resultadoOperacion = new Resultado();
        //    //act
        //    //resultadoOperacion = registroVenta.InsertarDocumentoPlantillaSeguro(documentoPoliza);
        //    //assert
        //    Assert.IsFalse(resultadoOperacion.Error);
        //}

        /// <summary>
        /// Obteners the parametros entrada.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 09/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private DocumentoPoliza ObtenerParametrosEntrada()
        {
            DocumentoPoliza documentoPoliza = new DocumentoPoliza();
            string rutaTemplate = Directory.GetCurrentDirectory();
            rutaTemplate = rutaTemplate.Substring(0, rutaTemplate.IndexOf("BancaSeguros"));
            rutaTemplate = rutaTemplate.Replace("BancaSeguros", "");
            rutaTemplate = Path.Combine(rutaTemplate, @"C:\WORKSPACES\BAC\Proyectos\BancaSeguros\Codigo fuente\Dev\BancaSeguro.Aplicacion\BancaSeguros.Tests\AplicacionTest\VentaTest\Recursos\TemplateDocument.docx");            
            FileStream stream = File.OpenRead(rutaTemplate);
            byte[] fileBytes = new byte[stream.Length];
            stream.Read(fileBytes, 0, fileBytes.Length);
            stream.Close();
            documentoPoliza.Plantilla = fileBytes;
            documentoPoliza.IdSeguro = 6;
            documentoPoliza.Activa = false;
            documentoPoliza.CamposPlantilla = "FechaSolicitud, PrimerNombreCliente, PrimerApellidoCliente, SegundoApellidoCliente, NumeroIdentificacionCliente";
            documentoPoliza.Eliminado = false;
            documentoPoliza.FechaCreacion = DateTime.Now;
            documentoPoliza.NombreArchivo = "TemplateDocument.docx";
            documentoPoliza.VersionDocumento = "1.0";
            documentoPoliza.UsuarioCreacion = "cpiza";
            return documentoPoliza;
        }
    }
}
