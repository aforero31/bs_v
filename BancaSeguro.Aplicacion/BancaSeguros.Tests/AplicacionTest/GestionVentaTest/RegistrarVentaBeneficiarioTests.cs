using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BancaSeguros.Repositorio.Venta;
using BancaSeguros.Entidades.Venta;
using BancaSeguros.Aplicacion.Venta;
using Moq;

namespace BancaSeguros.Tests.AplicacionTest.VentaTest
{

    [TestClass]
    public class RegistrarVentaBeneficiarioTests
    {

        [TestMethod]
        public void RegistrarVentaBeneficiario_CuandoNoTieneBeneficiarios_DevulveVerdadero()
        {
            //Arrange
            bool resultadoRegistro = true;
            RegistrarVenta venta = new RegistrarVenta();
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioVenta.Setup(x => x.ObtenerConsecutivo(venta)).Returns(string.Empty);
            GestionVenta registroVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object,mockRepositoriologCobis.Object);

            //Act
            PrivateObject obj= new PrivateObject(registroVenta);
            resultadoRegistro = Convert.ToBoolean(obj.Invoke("RegistrarVentaBeneficiario",venta));
            
            //Assert
            Assert.IsTrue(resultadoRegistro);
        }

        [TestMethod]
        public void RegistrarVentaBeneficiario_CuandoExisteBeneficiarioEnVenta_DevuelveVerdadero()
        {
            //Arrange
            bool resultadoRegistro = true;
            RegistrarVenta venta = new RegistrarVenta();
            Beneficiario objBeneficiario = new Beneficiario();
            venta.Beneficiario = new System.Collections.Generic.List<Beneficiario>();
            venta.Beneficiario.Add(objBeneficiario);
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaBeneficiario(objBeneficiario)).Returns(true);
            GestionVenta registroVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object,mockRepositoriologCobis.Object);

            //Act
            PrivateObject obj = new PrivateObject(registroVenta);
            resultadoRegistro = Convert.ToBoolean(obj.Invoke("RegistrarVentaBeneficiario", venta));

            //Assert
            mockRepositorioVenta.VerifyAll();
            
        }

    }
}
