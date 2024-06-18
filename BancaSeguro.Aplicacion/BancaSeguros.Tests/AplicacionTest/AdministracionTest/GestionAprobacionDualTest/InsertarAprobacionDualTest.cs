namespace BancaSeguros.Tests.AplicacionTest.AdministracionTest.GestionAdministracionTest.GestionAprobacionDual
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
    public class InsertarAprobacionDualTest2
    {
        [TestMethod]
        public void InsertarGeneraExcepcion_RetornaResultadoConError()
        {
            //arrange
            AprobacionDual aprobacionDual = new AprobacionDual();

            var mockRepositorioAprobacionDual = new Mock<IRepositorioAprobacionDual>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;
            
            Exception excepcion = new Exception("Mensaje de error en inserción");
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "InsertarAprobacionDual" };

            mockRepositorioAprobacionDual.Setup(x => x.InsertarAprobacionDual(aprobacionDual)).Throws(excepcion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(9, "ADA001")).Returns(mensaje);
            GestionAprobacionDual objGestion = new GestionAprobacionDual(mockRepositorioAprobacionDual.Object);

            //act
            Resultado resultado = objGestion.InsertarAprobacionDual(aprobacionDual);
            string mensajeEsperado = "0 ADA001 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void InsertaExitosamente_RetornaMensajePersonalizado()
        {
            //arrange
            AprobacionDual aprobacionDual = new AprobacionDual();

            var mockRepositorioAprobacionDual = new Mock<IRepositorioAprobacionDual>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoInsercion = new Resultado { Error = false };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Insercion exitosa", IdEvento = 9, Llave = "InsertarAprobacionDual" };

            mockRepositorioAprobacionDual.Setup(x => x.InsertarAprobacionDual(aprobacionDual)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(9, "ADA002")).Returns(mensaje);
            GestionAprobacionDual objGestion = new GestionAprobacionDual(mockRepositorioAprobacionDual.Object);

            //act
            Resultado resultado = objGestion.InsertarAprobacionDual(aprobacionDual);
            string mensajeEsperado = "ADA002 Insercion exitosa";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void InsertaRetornaError_RetornaErrorTrue()
        {
            //arrange
            AprobacionDual aprobacionDual = new AprobacionDual();

            var mockRepositorioAprobacionDual = new Mock<IRepositorioAprobacionDual>();
            
            Resultado resultadoInsercion = new Resultado { Error = true };            

            mockRepositorioAprobacionDual.Setup(x => x.InsertarAprobacionDual(aprobacionDual)).Returns(resultadoInsercion);            
            GestionAprobacionDual objGestion = new GestionAprobacionDual(mockRepositorioAprobacionDual.Object);

            //act
            Resultado resultado = objGestion.InsertarAprobacionDual(aprobacionDual);
            bool errorEsperado = true;

            //assert
            Assert.AreEqual(errorEsperado, resultado.Error);
        }

    }
}
