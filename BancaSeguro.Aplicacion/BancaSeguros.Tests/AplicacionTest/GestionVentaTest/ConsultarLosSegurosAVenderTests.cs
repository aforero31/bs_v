using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BancaSeguros.Entidades.Seguro;
using System.Collections.Generic;
using Moq;
using BancaSeguros.Repositorio.Venta;
using BancaSeguros.Aplicacion.Venta;
using BancaSeguros.Repositorio.Administracion;
using BancaSeguros.Repositorio.Log;

namespace BancaSeguros.Tests.AplicacionTest.GestionVentaTest
{
    [TestClass]
    public class ConsultarLosSegurosAVenderTests
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
        public void ConsultarLosSegurosAVender_ConTodosLosParametrosLLenos_RetornaUnaLista()
        {
            //Arrange
            List<Seguro> seguros = new List<Seguro>();
            int idTipoDeIdentificacion = 0;
            DateTime fechaDeNacimientoCliente = DateTime.Now;
            int genero = 0;
            var mockRepositorioSeguro = new Mock<Repositorio.Venta.IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<Repositorio.Venta.IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<Repositorio.Venta.IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioSeguro.Setup(x => x.ConsultarLosSegurosAVender(idTipoDeIdentificacion, fechaDeNacimientoCliente, genero)).Returns(new List<Seguro> { new Seguro { IdSeguro = 1, Activo = true } });
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object,mockRepositoriologCobis.Object);

            //Act
            seguros = (List<Seguro>)gestionVenta.ConsultarLosSegurosAVender(idTipoDeIdentificacion, fechaDeNacimientoCliente, genero);

            //Assert
            Assert.AreEqual(seguros.Count, 1);
        }

        [TestMethod]
        public void ConsultarLosSegurosAVender_ConTodosLosParametrosLLenos_RetornaUnaListaCero()
        {
            //Arrange
            List<Seguro> seguros = new List<Seguro>();
            int idTipoDeIdentificacion = 0;
            DateTime fechaDeNacimientoCliente = DateTime.Now;
            int genero = 0;
            var mockRepositorioSeguro = new Mock<Repositorio.Venta.IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<Repositorio.Venta.IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioSeguro.Setup(x => x.ConsultarLosSegurosAVender(idTipoDeIdentificacion, fechaDeNacimientoCliente, genero)).Returns(new List<Seguro> ());
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object,mockRepositoriologCobis.Object);

            //Act
            seguros = (List<Seguro>)gestionVenta.ConsultarLosSegurosAVender(idTipoDeIdentificacion, fechaDeNacimientoCliente, genero);

            //Assert
            Assert.AreEqual(seguros.Count, 0);
        }
    }
}
