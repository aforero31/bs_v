namespace BancaSeguros.Tests.AplicacionTest.AdministracionTest.GestionMaestraTest
{
    using System;
    using Aplicacion.Administracion;
    using BAC.Seguridad.Mensaje;
    using Entidades.Catalogo;
    using Entidades.General;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Repositorio.Administracion;
    using Repositorio.Log;

    [TestClass]
    public class EliminarMaestraTest
    {
        [TestMethod]
        public void EliminarGeneraExcepcion_RetornaResultadoConError()
        {
            //arrange
            Maestra maestra = new Maestra();

            var mockRepositorioMaestra = new Mock<IRepositorioMaestra>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Exception excepcion = new Exception("Mensaje de error eliminando");
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "EliminarMaestra" };

            mockRepositorioMaestra.Setup(x => x.EliminarMaestra(maestra)).Throws(excepcion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(33, "PME003")).Returns(mensaje);
            GestionMaestra objGestion = new GestionMaestra(mockRepositorioMaestra.Object);

            //act
            Resultado resultado = objGestion.EliminarMaestra(maestra);
            string mensajeEsperado = "0 PME003 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void EliminaRetornaError_RetornaMensajeErrorPersonalizado()
        {
            //arrange
            Maestra maestra = new Maestra();

            var mockRepositorioMaestra = new Mock<IRepositorioMaestra>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoInsercion = new Resultado { Error = true };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "EliminarMaestra" };

            mockRepositorioMaestra.Setup(x => x.EliminarMaestra(maestra)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(33, "PME002")).Returns(mensaje);
            GestionMaestra objGestion = new GestionMaestra(mockRepositorioMaestra.Object);

            //act
            Resultado resultado = objGestion.EliminarMaestra(maestra);
            string mensajeEsperado = "PME002 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void EliminaExitosamente_RetornaMensajePersonalizado()
        {
            //arrange
            Maestra maestra = new Maestra();

            var mockRepositorioMaestra = new Mock<IRepositorioMaestra>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoInsercion = new Resultado { Error = false };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada al eliminar", IdEvento = 1, Llave = "EliminarMaestra" };

            mockRepositorioMaestra.Setup(x => x.EliminarMaestra(maestra)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(33, "PME001")).Returns(mensaje);
            GestionMaestra objGestion = new GestionMaestra(mockRepositorioMaestra.Object);

            //act
            Resultado resultado = objGestion.EliminarMaestra(maestra);
            string mensajeEsperado = "PME001 Descripcion personalizada al eliminar";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

    }
}
