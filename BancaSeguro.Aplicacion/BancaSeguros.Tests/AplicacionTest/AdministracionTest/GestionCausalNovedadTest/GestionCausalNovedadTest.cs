using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BancaSeguros.Aplicacion.Administracion;
using BancaSeguros.Entidades.Catalogo;
using BancaSeguros.Entidades.General;

namespace BancaSegurosTests.AplicacionTest.AdministracionTest
{
    [TestClass]
    public class GestionCausalNovedadTest
    {
        [TestMethod]
        public void GuardaCausalNovedadyRetornaSinError()
        {
            //arrange
            var mockRepositorioCausalNovedad = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioCausalNovedad>();
            GestionCausalNovedad gestionCausalNovedad = new GestionCausalNovedad(mockRepositorioCausalNovedad.Object);
            CausalNovedad causalNovedad = new CausalNovedad();
            Resultado resultadoCausalNovedad = new Resultado();
            resultadoCausalNovedad.Error = false;
            mockRepositorioCausalNovedad.Setup(x => x.InsertarCausalNovedad(causalNovedad)).Returns(resultadoCausalNovedad);
            //act
            Resultado resultado = gestionCausalNovedad.InsertarCausalNovedad(causalNovedad);

            //Assert
            Assert.AreEqual(false, resultado.Error);
        }

        [TestMethod]
        public void GuardaCausalNovedadyRetornaConError()
        {
            //arrange
            var mockRepositorioCausalNovedad = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioCausalNovedad>();
            GestionCausalNovedad gestionCausalNovedad = new GestionCausalNovedad(mockRepositorioCausalNovedad.Object);
            CausalNovedad causalNovedad = new CausalNovedad();
            Resultado resultadoCausalNovedad = new Resultado();
            resultadoCausalNovedad.Error = true;
            mockRepositorioCausalNovedad.Setup(x => x.InsertarCausalNovedad(causalNovedad)).Returns(resultadoCausalNovedad);
            //act
            Resultado resultado = gestionCausalNovedad.InsertarCausalNovedad(causalNovedad);

            //Assert
            Assert.AreEqual(true, resultado.Error);
        }

        [TestMethod]
        public void ActualizaCausalNovedadyRetornaSinError()
        {
            //arrange
            var mockRepositorioCausalNovedad = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioCausalNovedad>();
            GestionCausalNovedad gestionNovedad = new GestionCausalNovedad(mockRepositorioCausalNovedad.Object);
            CausalNovedad causalNovedad = new CausalNovedad();
            Resultado resultadoCausalNovedad = new Resultado();
            resultadoCausalNovedad.Error = false;
            mockRepositorioCausalNovedad.Setup(x => x.ActualizarCausalNovedad(causalNovedad)).Returns(resultadoCausalNovedad);
            //act
            Resultado resultado = gestionNovedad.ActualizarCausalNovedad(causalNovedad);

            //Assert
            Assert.AreEqual(false, resultado.Error);
        }

        [TestMethod]
        public void ActualizaCausalNovedadyRetornaConError()
        {
            //arrange
            var mockRepositorioCausalNovedad = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioCausalNovedad>();
            GestionCausalNovedad gestionNovedad = new GestionCausalNovedad(mockRepositorioCausalNovedad.Object);
            CausalNovedad causalNovedad = new CausalNovedad();
            Resultado resultadoCausalNovedad = new Resultado();
            resultadoCausalNovedad.Error = true;
            mockRepositorioCausalNovedad.Setup(x => x.ActualizarCausalNovedad(causalNovedad)).Returns(resultadoCausalNovedad);
            //act
            Resultado resultado = gestionNovedad.ActualizarCausalNovedad(causalNovedad);

            //Assert
            Assert.AreEqual(true, resultado.Error);
        }
    }
}
