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
    public class GuardarDatosArchivoPlanoTest
    {
        [TestMethod]
        public void InsertarGeneraExcepcion_RetornaResultadoConError()
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

            mockRepositorioArchivoPlano.Setup(x => x.GuardarDatosArchivoPlano(ArchivoPlano)).Throws(excepcion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(37, "GPROG-003")).Returns(mensaje);
            GestionParametrizacionPlanos objGestion = new GestionParametrizacionPlanos(mockRepositorioArchivoPlano.Object);

            //act
            Resultado resultado = objGestion.GuardarDatosArchivoPlano(ArchivoPlano);
            string mensajeEsperado = "0 GPROG-003 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void InsertaRetornaError_RetornaMensajeErrorPersonalizado()
        {
            //arrange
            ArchivoPlano ArchivoPlano = new ArchivoPlano();

            var mockRepositorioArchivoPlano = new Mock<IRepositorioParametrizacionPlanos>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoInsercion = new Resultado { Error = true };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "GuardarDatosArchivoPlano" };

            mockRepositorioArchivoPlano.Setup(x => x.GuardarDatosArchivoPlano(ArchivoPlano)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(37, "GPROG-002")).Returns(mensaje);
            GestionParametrizacionPlanos objGestion = new GestionParametrizacionPlanos(mockRepositorioArchivoPlano.Object);

            //act
            Resultado resultado = objGestion.GuardarDatosArchivoPlano(ArchivoPlano);
            string mensajeEsperado = "GPROG-002 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void InsertaExitosamente_RetornaMensajePersonalizado()
        {
            //arrange
            ArchivoPlano ArchivoPlano = new ArchivoPlano();

            var mockRepositorioArchivoPlano = new Mock<IRepositorioParametrizacionPlanos>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoInsercion = new Resultado { Error = false };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada insercion", IdEvento = 1, Llave = "GuardarDatosArchivoPlano" };

            mockRepositorioArchivoPlano.Setup(x => x.GuardarDatosArchivoPlano(ArchivoPlano)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(37, "GPROG-001")).Returns(mensaje);
            GestionParametrizacionPlanos objGestion = new GestionParametrizacionPlanos(mockRepositorioArchivoPlano.Object);

            //act
            Resultado resultado = objGestion.GuardarDatosArchivoPlano(ArchivoPlano);
            string mensajeEsperado = "GPROG-001 Descripcion personalizada insercion";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }
    }
}
