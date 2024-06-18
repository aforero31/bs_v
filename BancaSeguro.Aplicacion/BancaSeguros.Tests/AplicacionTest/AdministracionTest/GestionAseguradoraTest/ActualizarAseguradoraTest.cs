namespace BancaSeguros.Tests.AplicacionTest.AdministracionTest.GestionAseguradoraTest
{
    using System;
    using Aplicacion.Administracion;
    using BAC.Seguridad.Mensaje;
    using Entidades.Seguro;
    using Entidades.General;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Repositorio.Administracion;
    using Repositorio.Log;

    [TestClass]
    public class ActualizarAseguradoraTest
    {
        [TestMethod]
        public void ActualizarGeneraExcepcion_RetornaResultadoConError()
        {
            //arrange
            Aseguradora aseguradora = new Aseguradora();

            var mockRepositorioAseguradora = new Mock<IRepositorioAseguradora>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Exception excepcion = new Exception("Mensaje de error en actualización");
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "ActualizarAseguradora" };

            mockRepositorioAseguradora.Setup(x => x.ActualizarAseguradora(aseguradora)).Throws(excepcion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(25, "AAA-003")).Returns(mensaje);
            GestionAseguradora objGestion = new GestionAseguradora(mockRepositorioAseguradora.Object);

            //act
            Resultado resultado = objGestion.ActualizarAseguradora(aseguradora);
            string mensajeEsperado = "0 AAA-003 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void ActualizaRetornaError_RetornaMensajeErrorPersonalizado()
        {
            //arrange
            Aseguradora aseguradora = new Aseguradora();

            var mockRepositorioAseguradora = new Mock<IRepositorioAseguradora>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoactualizacion = new Resultado { Error = true };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "ActualizarAseguradora" };

            mockRepositorioAseguradora.Setup(x => x.ActualizarAseguradora(aseguradora)).Returns(resultadoactualizacion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(25, "AAA-002")).Returns(mensaje);
            GestionAseguradora objGestion = new GestionAseguradora(mockRepositorioAseguradora.Object);

            //act
            Resultado resultado = objGestion.ActualizarAseguradora(aseguradora);
            string mensajeEsperado = "AAA-002 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void InsertaExitosamente_RetornaMensajePersonalizado()
        {
            //arrange
            Aseguradora aseguradora = new Aseguradora();

            var mockRepositorioAseguradora = new Mock<IRepositorioAseguradora>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoactualizacion = new Resultado { Error = false };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada actualizacion", IdEvento = 1, Llave = "ActualizarAseguradora" };

            mockRepositorioAseguradora.Setup(x => x.ActualizarAseguradora(aseguradora)).Returns(resultadoactualizacion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(25, "AAA-001")).Returns(mensaje);
            GestionAseguradora objGestion = new GestionAseguradora(mockRepositorioAseguradora.Object);

            //act
            Resultado resultado = objGestion.ActualizarAseguradora(aseguradora);
            string mensajeEsperado = "AAA-001 Descripcion personalizada actualizacion";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }
    }
}
