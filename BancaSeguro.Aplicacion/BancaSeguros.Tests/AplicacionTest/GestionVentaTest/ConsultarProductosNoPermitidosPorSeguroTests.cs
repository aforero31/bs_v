using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BancaSeguros.Entidades.Venta;
using Moq;
using BancaSeguros.Repositorio.Venta;
using BancaSeguros.Aplicacion.Venta;
using System.Collections.Generic;

namespace BancaSeguros.Tests.AplicacionTest.GestionVentaTest
{
    [TestClass]
    public class ConsultarProductosNoPermitidosPorSeguroTests
    {
        [TestMethod]
        public void ConsultarProductosNoPermitidosPorSeguro_SeEnviaIdSeguro_RetornaLista()
        {
            //Arrange
            List<ProductoNoPermitido> productoNoPermitidos = new List<ProductoNoPermitido>();
            int idSeguro = 1;
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            mockRepositorioProductoNoPermitido.Setup(x => x.ConsultarProductosNoPermitidosPorSeguro(idSeguro)).Returns(new List<ProductoNoPermitido> { new ProductoNoPermitido { IdSeguro = 1 } });
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            productoNoPermitidos = (List<ProductoNoPermitido>)gestionVenta.ConsultarProductosNoPermitidosPorSeguro(idSeguro);

            //Assert
            Assert.AreEqual(productoNoPermitidos.Count, 1);
        }

        [TestMethod]
        public void ConsultarProductosNoPermitidosPorSeguro_SeEnviaIdSeguro_RetornaListaCero()
        {
            //Arrange
            List<ProductoNoPermitido> productoNoPermitidos = new List<ProductoNoPermitido>();
            int idSeguro = 1;
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioProductoNoPermitido.Setup(x => x.ConsultarProductosNoPermitidosPorSeguro(idSeguro)).Returns(new List<ProductoNoPermitido>());
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object,mockRepositoriologCobis.Object);

            //Act
            productoNoPermitidos = (List<ProductoNoPermitido>)gestionVenta.ConsultarProductosNoPermitidosPorSeguro(idSeguro);

            //Assert
            Assert.AreEqual(productoNoPermitidos.Count, 0);
        }
    }
}
