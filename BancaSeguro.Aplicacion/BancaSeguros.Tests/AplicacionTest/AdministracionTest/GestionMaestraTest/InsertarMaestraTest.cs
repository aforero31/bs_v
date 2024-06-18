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
    public class InsertarMaestraTest
    {
        [TestMethod]
        public void InsertarGeneraExcepcion_RetornaResultadoConError()
        {
            //arrange
            Maestra maestra = new Maestra();

            var mockRepositorioMaestra = new Mock<IRepositorioMaestra>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Exception excepcion = new Exception("Mensaje de error en inserción");
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "InsertarMaestra" };

            mockRepositorioMaestra.Setup(x => x.InsertarMaestra(maestra)).Throws(excepcion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(31, "PMI003")).Returns(mensaje);
            GestionMaestra objGestion = new GestionMaestra(mockRepositorioMaestra.Object);

            //act
            Resultado resultado = objGestion.InsertarMaestra(maestra);
            string mensajeEsperado = "0 PMI003 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void InsertaRetornaError_RetornaMensajeErrorPersonalizado()
        {
            //arrange
            Maestra maestra = new Maestra();

            var mockRepositorioMaestra = new Mock<IRepositorioMaestra>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoInsercion = new Resultado { Error = true };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "InsertarAseguradora" };

            mockRepositorioMaestra.Setup(x => x.InsertarMaestra(maestra)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(31, "PMI002")).Returns(mensaje);
            GestionMaestra objGestion = new GestionMaestra(mockRepositorioMaestra.Object);

            //act
            Resultado resultado = objGestion.InsertarMaestra(maestra);
            string mensajeEsperado = "PMI002 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void InsertaExitosamente_RetornaMensajePersonalizado()
        {
            //arrange
            Maestra maestra = new Maestra();

            var mockRepositorioMaestra = new Mock<IRepositorioMaestra>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoInsercion = new Resultado { Error = false };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada insercion", IdEvento = 1, Llave = "InsertarAseguradora" };

            mockRepositorioMaestra.Setup(x => x.InsertarMaestra(maestra)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(31, "PMI001")).Returns(mensaje);
            GestionMaestra objGestion = new GestionMaestra(mockRepositorioMaestra.Object);

            //act
            Resultado resultado = objGestion.InsertarMaestra(maestra);
            string mensajeEsperado = "PMI001 Descripcion personalizada insercion";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }
    }
}
