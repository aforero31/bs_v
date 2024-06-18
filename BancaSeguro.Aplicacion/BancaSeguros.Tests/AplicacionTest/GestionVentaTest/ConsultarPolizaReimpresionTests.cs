using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BancaSeguros.Entidades.Venta;
using Moq;
using BancaSeguros.Repositorio.Venta;
using BancaSeguros.Aplicacion.Venta;
using System.Collections.Generic;
using BancaSeguros.Entidades.Seguro;

namespace BancaSeguros.Tests.AplicacionTest.GestionVentaTest
{
    [TestClass]
    public class ConsultarPolizaReimpresionTests
    {
        [TestMethod]
        public void ConsultarPolizaReimpresion_NoRetornaInformacionPoliza_RetornaErrorTrue()
        {
            //Arrange
            ResultadoDocumentoPoliza resultado = new ResultadoDocumentoPoliza();
            DocumentoPoliza documentoPoliza = new DocumentoPoliza();
            string consecutivoPoliza = "2342134234";
            string rutaArchivo = "";
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioDocumentoPoliza.Setup(x => x.ConsultarInformacionReimpresion(consecutivoPoliza)).Returns(documentoPoliza);
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object,mockRepositoriologCobis.Object);

            //Act
            resultado = gestionVenta.ConsultarPolizaReimpresion(consecutivoPoliza, rutaArchivo);

            //Assert
            Assert.IsTrue(resultado.Resultado.Error);
        }
    }
}
