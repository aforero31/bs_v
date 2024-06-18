using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BancaSeguros.Entidades.General;
using BancaSeguros.Repositorio.Venta;
using Moq;
using System.Collections.Generic;
using BancaSeguros.Entidades.Seguro;
using BancaSeguros.Aplicacion.Venta;

namespace BancaSeguros.Tests.AplicacionTest.GestionVentaTest
{
    [TestClass]
    public class ConsultarSegurosPorCodigoYAseguradoraTests
    {
        [TestMethod]
        public void ConsultarSegurosPorCodigoYAseguradora_SeEnvianTodosLosParametrosRespondeUnaLista_RetornaTrue()
        {
            //Arrange
            Resultado resultado = new Resultado();
            int codigoSeguro = 1;
            int codigoAseguradora = 1;
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioSeguro.Setup(x => x.ConsultarSegurosPorCodigoYAseguradora(codigoSeguro, codigoAseguradora)).Returns(new List<Seguro> { new Seguro { IdSeguro = 1, Activo = true } });
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object,mockRepositoriologCobis.Object);

            //Act
            resultado = gestionVenta.ConsultarSegurosPorCodigoYAseguradora(codigoSeguro, codigoAseguradora);

            //Assert
            Assert.IsTrue(resultado.Error);
        }

        [TestMethod]
        public void ConsultarSegurosPorCodigoYAseguradora_SeEnvianTodosLosParametrosRespondeUnaLista_RetornaMensaje()
        {
            //Arrange
            Resultado resultado = new Resultado();
            int codigoSeguro = 1;
            int codigoAseguradora = 1;
            string mensaje = "El código del producto ya existe en el sistema";
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioSeguro.Setup(x => x.ConsultarSegurosPorCodigoYAseguradora(codigoSeguro, codigoAseguradora)).Returns(new List<Seguro> { new Seguro { IdSeguro = 1, Activo = true } });
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object,mockRepositoriologCobis.Object);

            //Act
            resultado = gestionVenta.ConsultarSegurosPorCodigoYAseguradora(codigoSeguro, codigoAseguradora);

            //Assert
            Assert.AreEqual(resultado.Mensaje, mensaje);
        }

        [TestMethod]
        public void ConsultarSegurosPorCodigoYAseguradora_SeEnvianTodosLosParametrosRespondeListaCero_RetornaFalse()
        {
            //Arrange
            Resultado resultado = new Resultado();
            int codigoSeguro = 1;
            int codigoAseguradora = 1;
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioSeguro.Setup(x => x.ConsultarSegurosPorCodigoYAseguradora(codigoSeguro, codigoAseguradora)).Returns(new List<Seguro>());
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object,mockRepositoriologCobis.Object);

            //Act
            resultado = gestionVenta.ConsultarSegurosPorCodigoYAseguradora(codigoSeguro, codigoAseguradora);

            //Assert
            Assert.IsFalse(resultado.Error);
        }
    }
}
