using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BancaSeguros.Repositorio.Venta;
using BancaSeguros.Entidades.Venta;
using BancaSeguros.Aplicacion.Venta;
using Moq;
using System.Collections.Generic;

namespace BancaSeguros.Tests.AplicacionTest.GestionVentaTest
{
    [TestClass]
    public class RegistrarVariablesVentaTests
    {
        [TestMethod]
        public void RegistrarVariablesVenta_CuandoNoTieneVariables_DevulveVerdadero()
        {
            //Arrange
            bool resultadoRegistro = true;
            RegistrarVenta venta = new RegistrarVenta();
            VariableVenta variable = new VariableVenta();
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            mockRepositorioVenta.Setup(x => x.GuardarVariableVenta(variable)).Returns(false);
            GestionVenta registroVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            PrivateObject obj = new PrivateObject(registroVenta);
            resultadoRegistro = Convert.ToBoolean(obj.Invoke("RegistrarVariablesVenta", venta));

            //Assert
            Assert.IsTrue(resultadoRegistro);
        }

        [TestMethod]
        public void RegistrarVariablesVenta_CuandoExisteVariablesEnVenta_DevuelveVerdadero()
        {
            //Arrange
            bool resultadoRegistro = true;
            RegistrarVenta venta = new RegistrarVenta();
            venta.VariablesVenta = new List<VariableVenta> { new VariableVenta { IdVariableVenta = 1 } };
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioVenta.Setup(x => x.GuardarVariableVenta(venta.VariablesVenta[0])).Returns(true);
            GestionVenta registroVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object,mockRepositoriologCobis.Object);

            //Act
            PrivateObject obj = new PrivateObject(registroVenta);
            resultadoRegistro = Convert.ToBoolean(obj.Invoke("RegistrarVariablesVenta", venta));

            //Assert
            mockRepositorioVenta.VerifyAll();

        }

        [TestMethod]
        public void RegistrarVariablesVenta_CuandoTieneVariablesPeroRetornaErrorElGuardado_DevulveVerdadero()
        {
            //Arrange
            bool resultadoRegistro = true;
            RegistrarVenta venta = new RegistrarVenta();
            venta.VariablesVenta = new List<VariableVenta> { new VariableVenta { IdVariableVenta = 1 } };
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioVenta.Setup(x => x.GuardarVariableVenta(venta.VariablesVenta[0])).Returns(false);
            GestionVenta registroVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object,mockRepositoriologCobis.Object);

            //Act
            PrivateObject obj = new PrivateObject(registroVenta);
            resultadoRegistro = Convert.ToBoolean(obj.Invoke("RegistrarVariablesVenta", venta));

            //Assert
            Assert.IsFalse(resultadoRegistro);
        }
    }
}
