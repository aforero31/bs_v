using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BancaSeguros.Repositorio.Administracion;
using BancaSeguros.Repositorio.Log;
using BancaSeguros.Repositorio.Venta;
using BancaSeguros.Entidades.Venta;
using System.Collections.Generic;
using BancaSeguros.Aplicacion.Venta;

namespace BancaSeguros.Tests.AplicacionTest.GestionVentaTest
{
    [TestClass]
    public class ConsultarVentaPorClienteTests
    {
        [TestInitialize]
        public void InicializarControlMensajes()
        {
            var mockRepositorioMensaje = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioLog = mockRepositorioLog.Object;
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioMensaje = mockRepositorioMensaje.Object;
        }

        [TestMethod]
        public void ConsultarVentaPorCliente_SeEnviaUnClienteExistente_RetornaUnaLista()
        {
            //Arrange
            List<ConsultarVenta> consultaVentas = new List<ConsultarVenta>();
            Cliente cliente = new Cliente();
            var mockRepositorioSeguro = new Mock<Repositorio.Venta.IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<Repositorio.Venta.IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioVenta.Setup(x => x.ConsultarVentaPorCliente(cliente)).Returns(new List<ConsultarVenta> { new ConsultarVenta { DatosVenta = new RegistrarVenta { IdVenta = 1 } } });
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object,mockRepositoriologCobis.Object);

            //Act
            consultaVentas = gestionVenta.ConsultarVentaPorCliente(cliente);

            //Assert
            Assert.AreEqual(consultaVentas.Count, 1);
        }

        [TestMethod]
        public void ConsultarVentaPorCliente_SeEnviaUnClienteNOExistente_RetornaUnaListaConMensajeEnResultado()
        {
            //Arrange
            List<ConsultarVenta> consultaVentas = new List<ConsultarVenta>();
            Cliente cliente = new Cliente();
            string mensaje = "CV001 Mensaje No Parametrizado";
            var mockRepositorioSeguro = new Mock<Repositorio.Venta.IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<Repositorio.Venta.IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioVenta.Setup(x => x.ConsultarVentaPorCliente(cliente)).Returns(new List<ConsultarVenta>());
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object,mockRepositoriologCobis.Object);

            //Act
            consultaVentas = gestionVenta.ConsultarVentaPorCliente(cliente);

            //Assert
            Assert.AreEqual(consultaVentas[0].Resultado.Mensaje, mensaje);
        }
    }
}
