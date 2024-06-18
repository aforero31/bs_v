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
    public class EliminarDatosArchivoPlanoTest
    {
        [TestMethod]
        public void EliminarGeneraExcepcion_RetornaResultadoConError()
        {
            //arrange
            ArchivoPlano ArchivoPlano = new ArchivoPlano();

            var mockRepositorioArchivoPlano = new Mock<IRepositorioParametrizacionPlanos>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Exception excepcion = new Exception("Mensaje de error en inserción");
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "EliminarDatosArchivoPlano" };

            int idProgramacion = 1;
            string usuario = "usuario";
            mockRepositorioArchivoPlano.Setup(x => x.EliminarDatosArchivoPlano(idProgramacion, usuario)).Throws(excepcion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(39, "EAP-003")).Returns(mensaje);
            GestionParametrizacionPlanos objGestion = new GestionParametrizacionPlanos(mockRepositorioArchivoPlano.Object);

            //act
            Resultado resultado = objGestion.EliminarDatosArchivoPlano(idProgramacion, usuario);
            string mensajeEsperado = "0 EAP-003 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void EliminaretornaError_RetornaMensajeErrorPersonalizado()
        {
            //arrange
            ArchivoPlano ArchivoPlano = new ArchivoPlano();

            var mockRepositorioArchivoPlano = new Mock<IRepositorioParametrizacionPlanos>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoInsercion = new Resultado { Error = true };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "EliminarDatosArchivoPlano" };

            int idProgramacion = 1;
            string usuario = "usuario";
            mockRepositorioArchivoPlano.Setup(x => x.EliminarDatosArchivoPlano(idProgramacion, usuario)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(39, "EAP-002")).Returns(mensaje);
            GestionParametrizacionPlanos objGestion = new GestionParametrizacionPlanos(mockRepositorioArchivoPlano.Object);

            //act
            Resultado resultado = objGestion.EliminarDatosArchivoPlano(idProgramacion, usuario);
            string mensajeEsperado = "EAP-002 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void EliminaExitosamente_RetornaMensajePersonalizado()
        {
            //arrange
            ArchivoPlano ArchivoPlano = new ArchivoPlano();

            var mockRepositorioArchivoPlano = new Mock<IRepositorioParametrizacionPlanos>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoInsercion = new Resultado { Error = false };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada elimina", IdEvento = 1, Llave = "EliminarDatosArchivoPlano" };

            int idProgramacion = 1;
            string usuario = "usuario";
            mockRepositorioArchivoPlano.Setup(x => x.EliminarDatosArchivoPlano(idProgramacion, usuario)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(39, "EAP-001")).Returns(mensaje);
            GestionParametrizacionPlanos objGestion = new GestionParametrizacionPlanos(mockRepositorioArchivoPlano.Object);

            //act
            Resultado resultado = objGestion.EliminarDatosArchivoPlano(idProgramacion, usuario);
            string mensajeEsperado = "EAP-001 Descripcion personalizada elimina";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }
    }
}
