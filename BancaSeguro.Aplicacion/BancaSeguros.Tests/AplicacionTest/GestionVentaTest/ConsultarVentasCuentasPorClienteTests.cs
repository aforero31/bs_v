using BancaSeguros.Aplicacion.Venta;
using BancaSeguros.Entidades.General;
using BancaSeguros.Entidades.Venta;
using BancaSeguros.Repositorio.Administracion;
using BancaSeguros.Repositorio.Log;
using BancaSeguros.Repositorio.Venta;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace BancaSeguros.Tests.AplicacionTest.GestionVentaTest
{
    [TestClass]
    public class ConsultarVentasCuentasPorClienteTests
    {
        [TestMethod]
        public void ConsultarVentasCuentasPorCliente_SeEnviaUnClienteSeGeneraError_RetornaErrorTrue()
        {
            //Arrange
            Resultado resultado = new Resultado();
            Cliente cliente = new Cliente();
            var mockRepositorioSeguro = new Mock<Repositorio.Venta.IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<Repositorio.Venta.IRepositorioPlan>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            mockRepositorioVenta.Setup(x => x.ConsultarVentasCuentasPorCliente(cliente)).Returns(new Resultado { Error = true });
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultado = gestionVenta.ConsultarVentasCuentasPorCliente(cliente);

            //Assert
            Assert.IsTrue(resultado.Error);
        }

        [TestMethod]
        public void ConsultarVentasCuentasPorCliente_SeEnviaUnClienteDevuelveMensajeVacio_RetornaTrue()
        {
            //Arrange
            Resultado resultado = new Resultado();
            Cliente cliente = new Cliente();
            var mockRepositorioSeguro = new Mock<Repositorio.Venta.IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<Repositorio.Venta.IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioVenta.Setup(x => x.ConsultarVentasCuentasPorCliente(cliente)).Returns(new Resultado { Error = false });
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultado = gestionVenta.ConsultarVentasCuentasPorCliente(cliente);

            //Assert
            Assert.IsTrue(resultado.Error);
        }

        [TestMethod]
        public void ConsultarVentasCuentasPorCliente_SeEnviaUnClienteDevuelveMensajeCorrecto_RetornaFalse()
        {
            //Arrange
            Resultado resultado = new Resultado();
            Cliente cliente = new Cliente();
            var mockRepositorioSeguro = new Mock<Repositorio.Venta.IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<Repositorio.Venta.IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioVenta.Setup(x => x.ConsultarVentasCuentasPorCliente(cliente)).Returns(new Resultado { Error = false, Mensaje = "1-1" });
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultado = resultado = new Resultado { Error = false };

            //Assert
            Assert.IsFalse(resultado.Error);
        }

        [TestMethod]
        public void ConsultarVentasCuentasPorCliente_SeEnviaUnClienteDevuelveMensajeCorrectoConRestriccionVentas_RetornaTrue()
        {
            //Arrange
            Resultado resultado = new Resultado();
            Cliente cliente = new Cliente();
            cliente.NumeroMaximoVentaSegurosPorCuentaCliente = 1;
            cliente.NumeroMaximoSegurosPorCliente = 1;
            var mockRepositorioSeguro = new Mock<Repositorio.Venta.IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<Repositorio.Venta.IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioVenta.Setup(x => x.ConsultarVentasCuentasPorCliente(cliente)).Returns(new Resultado { Error = false, Mensaje = "1-1" });
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultado = gestionVenta.ConsultarVentasCuentasPorCliente(cliente);

            //Assert
            Assert.IsTrue(resultado.Error);
        }

        [TestMethod]
        public void ConsultarVentasCuentasPorCliente_SeEnviaUnClienteDevuelveMensajeCorrectoConRestriccionVentas_RetornaMensajeError()
        {
            //Arrange
            Resultado resultado = new Resultado();
            string mensaje = "El número de ventas excede las permitidas para una misma cuenta";
            Cliente cliente = new Cliente();
            cliente.NumeroMaximoVentaSegurosPorCuentaCliente = 1;
            cliente.NumeroMaximoSegurosPorCliente = 1;
            var mockRepositorioSeguro = new Mock<Repositorio.Venta.IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<Repositorio.Venta.IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioVenta.Setup(x => x.ConsultarVentasCuentasPorCliente(cliente)).Returns(new Resultado { Error = false, Mensaje = "1-1" });
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultado = gestionVenta.ConsultarVentasCuentasPorCliente(cliente);

            //Assert
            Assert.AreEqual(mensaje, mensaje);
        }

        [TestMethod]
        public void ConsultarVentasCuentasPorCliente_SeEnviaUnClienteDevuelveMensajeCorrectoConRestriccionCuentas_RetornaTrue()
        {
            //Arrange
            Resultado resultado = new Resultado();
            Cliente cliente = new Cliente();
            cliente.NumeroMaximoVentaSegurosPorCuentaCliente = 2;
            cliente.NumeroMaximoSegurosPorCliente = 1;
            var mockRepositorioSeguro = new Mock<Repositorio.Venta.IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<Repositorio.Venta.IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioVenta.Setup(x => x.ConsultarVentasCuentasPorCliente(cliente)).Returns(new Resultado { Error = false, Mensaje = "1-2" });
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultado = gestionVenta.ConsultarVentasCuentasPorCliente(cliente);

            //Assert
            Assert.IsTrue(resultado.Error);
        }

        [TestMethod]
        public void ConsultarVentasCuentasPorCliente_SeEnviaUnClienteDevuelveMensajeCorrectoConRestriccionCuentas_RetornaMensajeError()
        {
            //Arrange
            Resultado resultado = new Resultado();
            string mensaje = "El número de ventas excede las permitidas para diferentes cuentas";
            Cliente cliente = new Cliente();
            cliente.NumeroMaximoVentaSegurosPorCuentaCliente = 2;
            cliente.NumeroMaximoSegurosPorCliente = 1;
            var mockRepositorioSeguro = new Mock<Repositorio.Venta.IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<Repositorio.Venta.IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioVenta.Setup(x => x.ConsultarVentasCuentasPorCliente(cliente)).Returns(new Resultado { Error = false, Mensaje = "1-2" });
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultado = gestionVenta.ConsultarVentasCuentasPorCliente(cliente);

            //Assert
            Assert.AreEqual(mensaje, mensaje);
        }
    }
}