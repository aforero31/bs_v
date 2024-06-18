using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BancaSeguros.Repositorio.Administracion;
using BancaSeguros.Repositorio.Venta;
using BancaSeguros.Aplicacion.Administracion;
using BancaSeguros.Entidades.General;
using BancaSeguros.Entidades.Administracion;
using BancaSeguros.Entidades.Seguro;
using Moq;


namespace BancaSegurosTests.AplicacionTest.AdministracionTest.GestionSeguroTest
{
    [TestClass]
    public class GuardarSeguroTest
    {
        [TestMethod]
        public void GuardarSeguro_CuandoValidaEntidadParametrizacionSeguroNoEsExitoso_RetornaErrorTrue()
        {
            //arrange
            var mockRepositorioSeguro = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioSeguro>();
            var mockRepositorioPlan = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioTipoIdentificacionSeguro = new Mock<IRepositorioTipoIdentificacionSeguro>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();

            GestionSeguro gestion = new GestionSeguro(mockRepositorioSeguro.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioCanalVenta.Object, mockRepositorioTipoIdentificacionSeguro.Object, mockRepositorioDocumentoPoliza.Object);           
            ParametrizacionSeguro parametroseguro = new ParametrizacionSeguro();

            //act
            Resultado resultado = gestion.GuardarSeguro(parametroseguro);            

            //Assert
            Assert.AreEqual(true, resultado.Error);

        }
    }
}
