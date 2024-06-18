using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BancaSeguros.Aplicacion.Administracion;
using BancaSeguros.Entidades.General;
using BancaSeguros.Entidades.Catalogo;
using BancaSeguros.Repositorio.Administracion;

namespace BancaSeguros.Tests.AplicacionTest.AdministracionTest.GestionIPCTest
{
    [TestClass]
    public class GuardarIPCTests
    {
        [TestMethod]
        public void GuardarIPC_CuandoGuardaIPC_RetornaErrorFalse()
        {
            //arrange
            var mockRepositorioIPC = new Mock<IRepositorioIPC>();
            GestionIPC gestionIpc = new GestionIPC(mockRepositorioIPC.Object);
            IPC ipc = new IPC();
            Resultado resultadoRepositorio = new Resultado();
            resultadoRepositorio.Error = false;
            mockRepositorioIPC.Setup(x => x.GuardarIPC(ipc)).Returns(resultadoRepositorio);
            
            //act
            Resultado resultado = gestionIpc.GuardarIPC(ipc);

            //Assert
            Assert.AreEqual(false, resultado.Error);

        }

        [TestMethod]
        public void GuardarIPC_CuandoNoGuardaIPC_RetornaErrorTrue()
        {
            //arrange
            var mockRepositorioIPC = new Mock<IRepositorioIPC>();
            GestionIPC gestionIpc = new GestionIPC(mockRepositorioIPC.Object);
            IPC ipc = new IPC();
            Resultado resultadoRepositorio = new Resultado();
            resultadoRepositorio.Error = true;
            mockRepositorioIPC.Setup(x => x.GuardarIPC(ipc)).Returns(resultadoRepositorio);

            //act
            Resultado resultado = gestionIpc.GuardarIPC(ipc);

            //Assert
            Assert.AreEqual(true, resultado.Error);

        }
    }
}
