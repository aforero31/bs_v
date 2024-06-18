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
    public class ActualizarMaestraTest
    {
        [TestMethod]
        public void ActualizarGeneraExcepcion_RetornaResultadoConError()
        {
            //arrange
            Maestra maestra = new Maestra();

            var mockRepositorioMaestra = new Mock<IRepositorioMaestra>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Exception excepcion = new Exception("Mensaje de error en actualización");
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "ActualizarMaestra" };

            mockRepositorioMaestra.Setup(x => x.ActualizarMaestra(maestra)).Throws(excepcion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(32, "PMA002")).Returns(mensaje);
            GestionMaestra objGestion = new GestionMaestra(mockRepositorioMaestra.Object);

            //act
            Resultado resultado = objGestion.ActualizarMaestra(maestra);
            string mensajeEsperado = "0 PMA002 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void ActualizaExitosamente_RetornaMensajePersonalizado()
        {
            //arrange
            Maestra mestra = new Maestra();

            var mockRepositorioMaestra = new Mock<IRepositorioMaestra>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoInsercion = new Resultado { Error = false };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada actualizacion", IdEvento = 1, Llave = "ActualizarMaestra" };

            mockRepositorioMaestra.Setup(x => x.ActualizarMaestra(mestra)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(32, "PMA001")).Returns(mensaje);
            GestionMaestra objGestion = new GestionMaestra(mockRepositorioMaestra.Object);

            //act
            Resultado resultado = objGestion.ActualizarMaestra(mestra);
            string mensajeEsperado = "PMA001 Descripcion personalizada actualizacion";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }
    }
}
