using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BancaSeguros.Entidades.Seguro;
using System.Collections.Generic;
using Moq;
using BancaSeguros.Repositorio.Venta;
using BancaSeguros.Aplicacion.Venta;

namespace BancaSeguros.Tests.AplicacionTest.GestionVentaTest
{
    [TestClass]
    public class ConsultarPlanesPorIdSeguroTests
    {
        [TestMethod]
        public void ConsultarPlanesPorIdSeguro_SeEnviaIdSeguro_RetornaLista()
        {
            //Arrange
            List<Plan> planes = new List<Plan>();
            int idSeguro = 1;
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioPlan.Setup(x => x.ConsultarPlanesPorIdSeguro(idSeguro)).Returns(new List<Plan> { new Plan { IdSeguro = 1, Activo = true } });
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object,mockRepositoriologCobis.Object);

            //Act
            planes = (List<Plan>)gestionVenta.ConsultarPlanesPorIdSeguro(idSeguro);

            //Assert
            Assert.AreEqual(planes.Count, 1);
        }


        [TestMethod]
        public void ConsultarPlanesPorIdSeguro_SeEnviaIdSeguro_NoRetornaLista()
        {
            //Arrange
            List<Plan> planes = new List<Plan>();
            int idSeguro = 1;
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioPlan.Setup(x => x.ConsultarPlanesPorIdSeguro(idSeguro)).Returns(new List<Plan>());
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object,mockRepositoriologCobis.Object);

            //Act
            planes = (List<Plan>)gestionVenta.ConsultarPlanesPorIdSeguro(idSeguro);

            //Assert
            Assert.AreEqual(planes.Count, 0);
        }
    }
}
