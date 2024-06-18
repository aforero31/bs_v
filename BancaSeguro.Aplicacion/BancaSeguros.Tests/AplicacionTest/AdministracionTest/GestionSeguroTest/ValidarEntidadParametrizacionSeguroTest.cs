using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BancaSeguros.Entidades.Administracion;
using BancaSeguros.Entidades.General;
using BancaSeguros.Aplicacion.Administracion;
using BancaSeguros.Repositorio.Administracion;
using BancaSeguros.Repositorio.Venta;
using BancaSeguros.Entidades.Seguro;
using Moq;
using System.Collections.Generic;

namespace BancaSegurosTests.AplicacionTest.AdministracionTest.GestionSeguroTest
{
    [TestClass]
    public class ValidarEntidadParametrizacionSeguroTest
    {
        private static ParametrizacionSeguro paramSeguro;

        [TestInitialize]
        public void Incializar()
        {
            paramSeguro = new ParametrizacionSeguro();
            paramSeguro.Planes = new List<Plan>();
            paramSeguro.TiposIdentificacionPorSeguro = new List<BancaSeguros.Entidades.Catalogo.TipoIdentificacion>();
            paramSeguro.Seguro = new Seguro();
            paramSeguro.Seguro.Aseguradora = new Aseguradora();

        }

        [TestMethod]
        public void ValidaEntidadParametrizacionSeguro_CanalesVentaCountIgualaCero_RetornaTrue()
        {
            //arrange            
            Resultado resultado = new Resultado();
            
            var mockRepositorioSeguro = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioSeguro>();
            var mockRepositorioPlan = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioTipoIdentificacionSeguro = new Mock<IRepositorioTipoIdentificacionSeguro>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();

            GestionSeguro gestionSeguro = new GestionSeguro(mockRepositorioSeguro.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioCanalVenta.Object, mockRepositorioTipoIdentificacionSeguro.Object, mockRepositorioDocumentoPoliza.Object);

            //act
            PrivateObject obj = new PrivateObject(gestionSeguro);
            resultado = (Resultado)obj.Invoke("ValidarEntidadParametrizacionSeguro", paramSeguro);

            //Assert

            Assert.AreEqual(resultado.Error, true);

        }

        [TestMethod]
        public void ValidaEntidadParametrizacionSeguro_PlanesCountIgualaCero_RetornaTrue()
        {
            //arrange
            Resultado resultado = new Resultado();

            var mockRepositorioSeguro = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioSeguro>();
            var mockRepositorioPlan = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioTipoIdentificacionSeguro = new Mock<IRepositorioTipoIdentificacionSeguro>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();

            GestionSeguro gestionSeguro = new GestionSeguro(mockRepositorioSeguro.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioCanalVenta.Object, mockRepositorioTipoIdentificacionSeguro.Object, mockRepositorioDocumentoPoliza.Object);
            
            //act
            PrivateObject obj = new PrivateObject(gestionSeguro);
            resultado = (Resultado)obj.Invoke("ValidarEntidadParametrizacionSeguro", paramSeguro);

            //assert
            Assert.AreEqual(true, resultado.Error);
 
        }

    }
}
