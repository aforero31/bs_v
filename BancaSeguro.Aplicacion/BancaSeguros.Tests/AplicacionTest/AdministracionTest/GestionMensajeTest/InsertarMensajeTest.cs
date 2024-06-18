namespace BancaSeguros.Tests.AplicacionTest.AdministracionTest.GestionMensajeTest
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
    public class InsertarMensajeTest
    {
        [TestMethod]
        public void InsertarGeneraExcepcion_RetornaResultadoConError()
        {
            //arrange
            Mensaje objMensaje = new Mensaje();

            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();            
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Exception excepcion = new Exception("Mensaje de error en inserción");
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "InsertarMensaje" };

            mockRepositorioMensajes.Setup(x => x.InsertarMensaje(objMensaje)).Throws(excepcion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(21, "GM-001")).Returns(objMensaje);
            BancaSeguros.Aplicacion.Administracion.GestionMensaje objGestion = new BancaSeguros.Aplicacion.Administracion.GestionMensaje(mockRepositorioMensajes.Object);

            //act
            Resultado resultado = objGestion.InsertarMensaje(objMensaje);
            string mensajeEsperado = "0 GM-001 ";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void InsertaRetornaError_RetornaMensajeVacio()
        {
            //arrange
            Mensaje objMensaje = new Mensaje();
            
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoInsercion = new Resultado { Error = true };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "InsertarMensaje" };

            mockRepositorioMensajes.Setup(x => x.InsertarMensaje(objMensaje)).Returns(resultadoInsercion);
            BancaSeguros.Aplicacion.Administracion.GestionMensaje objGestion = new BancaSeguros.Aplicacion.Administracion.GestionMensaje(mockRepositorioMensajes.Object);

            //act
            Resultado resultado = objGestion.InsertarMensaje(objMensaje);
            string mensajeEsperado = string.Empty;

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void InsertaExitosamente_RetornaMensajePersonalizado()
        {
            //arrange
            Mensaje objMensaje = new Mensaje();
            
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoInsercion = new Resultado { Error = false };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada insercion", IdEvento = 1, Llave = "InsertarMensaje" };

            mockRepositorioMensajes.Setup(x => x.InsertarMensaje(objMensaje)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(21, "GM-002")).Returns(objMensaje);
            BancaSeguros.Aplicacion.Administracion.GestionMensaje objGestion = new BancaSeguros.Aplicacion.Administracion.GestionMensaje(mockRepositorioMensajes.Object);

            //act
            Resultado resultado = objGestion.InsertarMensaje(objMensaje);
            string mensajeEsperado = "GM-002 ";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }


    }
}
