namespace BancaSeguros.Tests.AplicacionTest.AdministracionTest.GestionAprobacionDualTest
{
    using System;
    using Aplicacion.Administracion;
    using BAC.Seguridad.Mensaje;
    using Entidades.Administracion;
    using Entidades.General;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Repositorio.Administracion;
    using Repositorio.Log;

    [TestClass]
    public class ActualizarAprobacionDualTest
    {
        [TestMethod]
        public void ActualizarGeneraExcepcion_RetornaResultadoConError()
        {
            //arrange
            AprobacionDual aprobacionDual = new AprobacionDual();

            var mockRepositorioAprobacionDual = new Mock<IRepositorioAprobacionDual>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Exception excepcion = new Exception("Mensaje de error en actualización");
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "ActualizarAprobacionDual" };

            mockRepositorioAprobacionDual.Setup(x => x.ActualizarAprobacionDual(aprobacionDual)).Throws(excepcion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(9, "ADA003")).Returns(mensaje);
            GestionAprobacionDual objGestion = new GestionAprobacionDual(mockRepositorioAprobacionDual.Object);

            //act
            Resultado resultado = objGestion.ActualizarAprobacionDual(aprobacionDual);
            string mensajeEsperado = "0 ADA003 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void ActualizaExitosamente_RetornaMensajePersonalizado()
        {
            //arrange
            AprobacionDual aprobacionDual = new AprobacionDual();

            var mockRepositorioAprobacionDual = new Mock<IRepositorioAprobacionDual>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoActualizacion = new Resultado { Error = false };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Actualizacion exitosa", IdEvento = 9, Llave = "ActualizarAprobacionDual" };

            mockRepositorioAprobacionDual.Setup(x => x.ActualizarAprobacionDual(aprobacionDual)).Returns(resultadoActualizacion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(9, "ADA004")).Returns(mensaje);
            GestionAprobacionDual objGestion = new GestionAprobacionDual(mockRepositorioAprobacionDual.Object);

            //act
            Resultado resultado = objGestion.ActualizarAprobacionDual(aprobacionDual);
            string mensajeEsperado = "ADA004 Actualizacion exitosa";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void ActualizaretornaError_RetornaErrorTrue()
        {
            //arrange
            AprobacionDual aprobacionDual = new AprobacionDual();

            var mockRepositorioAprobacionDual = new Mock<IRepositorioAprobacionDual>();

            Resultado resultadoActualizacion = new Resultado { Error = true };

            mockRepositorioAprobacionDual.Setup(x => x.ActualizarAprobacionDual(aprobacionDual)).Returns(resultadoActualizacion);
            GestionAprobacionDual objGestion = new GestionAprobacionDual(mockRepositorioAprobacionDual.Object);

            //act
            Resultado resultado = objGestion.ActualizarAprobacionDual(aprobacionDual);
            bool errorEsperado = true;

            //assert
            Assert.AreEqual(errorEsperado, resultado.Error);
        }

    }
}
