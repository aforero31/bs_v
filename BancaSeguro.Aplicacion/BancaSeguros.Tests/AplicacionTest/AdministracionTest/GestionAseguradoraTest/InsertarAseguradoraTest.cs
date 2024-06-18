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
    public class InsertarAseguradoraTest
    {
        [TestMethod]
        public void InsertarGeneraExcepcion_RetornaResultadoConError()
        {
            //arrange
            Aseguradora aseguradora = new Aseguradora();

            var mockRepositorioAseguradora = new Mock<IRepositorioAseguradora>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Exception excepcion = new Exception("Mensaje de error en inserción");
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "InsertarAseguradora" };

            mockRepositorioAseguradora.Setup(x => x.InsertarAseguradora(aseguradora)).Throws(excepcion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(14, "IAA-003")).Returns(mensaje);
            GestionAseguradora objGestion = new GestionAseguradora(mockRepositorioAseguradora.Object);

            //act
            Resultado resultado = objGestion.InsertarAseguradora(aseguradora);
            string mensajeEsperado = "0 IAA-003 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void InsertaRetornaError_RetornaMensajeErrorPersonalizado()
        {
            //arrange
            Aseguradora aseguradora = new Aseguradora();

            var mockRepositorioAseguradora = new Mock<IRepositorioAseguradora>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoInsercion = new Resultado { Error = true };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "InsertarAseguradora" };

            mockRepositorioAseguradora.Setup(x => x.InsertarAseguradora(aseguradora)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(14, "IAA-001")).Returns(mensaje);
            GestionAseguradora objGestion = new GestionAseguradora(mockRepositorioAseguradora.Object);

            //act
            Resultado resultado = objGestion.InsertarAseguradora(aseguradora);
            string mensajeEsperado = "IAA-001 Descripcion personalizada error";

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

            Resultado resultadoInsercion = new Resultado { Error = false };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada insercion", IdEvento = 1, Llave = "InsertarAseguradora" };

            mockRepositorioAseguradora.Setup(x => x.InsertarAseguradora(aseguradora)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(14, "IAA-002")).Returns(mensaje);
            GestionAseguradora objGestion = new GestionAseguradora(mockRepositorioAseguradora.Object);

            //act
            Resultado resultado = objGestion.InsertarAseguradora(aseguradora);
            string mensajeEsperado = "IAA-002 Descripcion personalizada insercion";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

    }
}
