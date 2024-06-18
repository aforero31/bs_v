namespace BancaSeguros.Tests.AplicacionTest.AdministracionTest.GestionParametrizacionPlanosTest
{
    using System;
    using Aplicacion.Administracion;
    using BAC.Seguridad.Mensaje;
    using Entidades.Planos;
    using Entidades.General;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Repositorio.Administracion;
    using Repositorio.Log;

    [TestClass]
    public class ActualizarDatosArchivoPlanoTest
    {
        [TestMethod]
        public void ActualizarGeneraExcepcion_RetornaResultadoConError()
        {
            //arrange
            ArchivoPlano ArchivoPlano = new ArchivoPlano();

            var mockRepositorioArchivoPlano = new Mock<IRepositorioParametrizacionPlanos>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Exception excepcion = new Exception("Mensaje de error en inserción");
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "GuardarArchivoPlano" };

            mockRepositorioArchivoPlano.Setup(x => x.ActualizarDatosArchivoPlano(ArchivoPlano)).Throws(excepcion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(38, "AAP-003")).Returns(mensaje);
            GestionParametrizacionPlanos objGestion = new GestionParametrizacionPlanos(mockRepositorioArchivoPlano.Object);

            //act
            Resultado resultado = objGestion.ActualizarDatosArchivoPlano(ArchivoPlano);
            string mensajeEsperado = "0 AAP-003 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void ActualizaRetornaError_RetornaMensajeErrorPersonalizado()
        {
            //arrange
            ArchivoPlano ArchivoPlano = new ArchivoPlano();

            var mockRepositorioArchivoPlano = new Mock<IRepositorioParametrizacionPlanos>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoactualizacion = new Resultado { Error = true };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "ActualizarDatosArchivoPlano" };

            mockRepositorioArchivoPlano.Setup(x => x.ActualizarDatosArchivoPlano(ArchivoPlano)).Returns(resultadoactualizacion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(38, "AAP-002")).Returns(mensaje);
            GestionParametrizacionPlanos objGestion = new GestionParametrizacionPlanos(mockRepositorioArchivoPlano.Object);

            //act
            Resultado resultado = objGestion.ActualizarDatosArchivoPlano(ArchivoPlano);
            string mensajeEsperado = "AAP-002 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void ActualizaExitosamente_RetornaMensajePersonalizado()
        {
            //arrange
            ArchivoPlano ArchivoPlano = new ArchivoPlano();

            var mockRepositorioArchivoPlano = new Mock<IRepositorioParametrizacionPlanos>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoactualizacion = new Resultado { Error = false };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada actualizacion", IdEvento = 1, Llave = "ActualizarDatosArchivoPlano" };

            mockRepositorioArchivoPlano.Setup(x => x.ActualizarDatosArchivoPlano(ArchivoPlano)).Returns(resultadoactualizacion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(38, "AAP-001")).Returns(mensaje);
            GestionParametrizacionPlanos objGestion = new GestionParametrizacionPlanos(mockRepositorioArchivoPlano.Object);

            //act
            Resultado resultado = objGestion.ActualizarDatosArchivoPlano(ArchivoPlano);
            string mensajeEsperado = "AAP-001 Descripcion personalizada actualizacion";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }
    }
}
