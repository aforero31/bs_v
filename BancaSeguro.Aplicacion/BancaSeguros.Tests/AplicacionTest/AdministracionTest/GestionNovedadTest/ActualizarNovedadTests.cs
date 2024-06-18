using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BancaSeguros.Aplicacion.Administracion;
using BancaSeguros.Entidades.General;
using BancaSeguros.Entidades.Catalogo;
using BancaSeguros.Repositorio.Administracion;

namespace BancaSeguros.Tests.AplicacionTest.AdministracionTest.GestionNovedadTest
{
    [TestClass]
    public class ActualizarNovedadTests
    {
        [TestInitialize]
        public void InicializarControlMensajes()
        {
            var mockRepositorioMensaje = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<BancaSeguros.Repositorio.Log.IRepositorioLog>();
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioLog = mockRepositorioLog.Object;
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioMensaje = mockRepositorioMensaje.Object;
        }

        [TestMethod]
        public void ActualizarNovedad_ActualizaNovedad_RetornaSinError()
        {
            //arrange
            var mockRepositorioNovedad = new Mock<IRepositorioNovedad>();
            GestionNovedad gestionNovedad = new GestionNovedad(mockRepositorioNovedad.Object);
            Novedad novedad = new Novedad();
            Resultado resultadoNovedad = new Resultado();
            resultadoNovedad.Error = false;
            mockRepositorioNovedad.Setup(x => x.ActualizarNovedad(novedad)).Returns(resultadoNovedad);
            //act
            Resultado resultado = gestionNovedad.ActualizarNovedad(novedad);

            //Assert
            Assert.AreEqual(false, resultado.Error);
        }

        [TestMethod]
        public void ActualizarNovedad_ActualizaNovedad_RetornaConError()
        {
            //arrange
            var mockRepositorioNovedad = new Mock<IRepositorioNovedad>();
            GestionNovedad gestionNovedad = new GestionNovedad(mockRepositorioNovedad.Object);
            Novedad novedad = new Novedad();
            Resultado resultadoNovedad = new Resultado();
            resultadoNovedad.Error = true;
            mockRepositorioNovedad.Setup(x => x.ActualizarNovedad(novedad)).Returns(resultadoNovedad);
            //act
            Resultado resultado = gestionNovedad.ActualizarNovedad(novedad);

            //Assert
            Assert.AreEqual(true, resultado.Error);
        }
    }
}
