namespace BancaSeguros.Tests.AplicacionTest.AdministracionTest.GestionItemMaestraTest
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
    public class ActualizarItemMaestraTest
    {
        [TestMethod]
        public void ActualizarGeneraExcepcion_RetornaResultadoConError()
        {
            //arrange
            ItemMaestra itemMaestra = new ItemMaestra();

            var mockRepositorioItemMaestra = new Mock<IRepositorioItemMaestra>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Exception excepcion = new Exception("Mensaje de error en actualización");
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "ActualizarItemMaestra" };

            mockRepositorioItemMaestra.Setup(x => x.ActualizarItemMaestra(itemMaestra)).Throws(excepcion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(35, "AIM002")).Returns(mensaje);
            GestionItemMaestra objGestion = new GestionItemMaestra(mockRepositorioItemMaestra.Object);

            //act
            Resultado resultado = objGestion.ActualizarItemMaestra(itemMaestra);
            string mensajeEsperado = "0 AIM002 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void ActualizaExitosamente_RetornaMensajePersonalizado()
        {
            //arrange
            ItemMaestra itemMaestra = new ItemMaestra();

            var mockRepositorioItemMaestra = new Mock<IRepositorioItemMaestra>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoInsercion = new Resultado { Error = false };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada insercion", IdEvento = 1, Llave = "ActualizarAseguradora" };

            mockRepositorioItemMaestra.Setup(x => x.ActualizarItemMaestra(itemMaestra)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(35, "AIM001")).Returns(mensaje);
            GestionItemMaestra objGestion = new GestionItemMaestra(mockRepositorioItemMaestra.Object);

            //act
            Resultado resultado = objGestion.ActualizarItemMaestra(itemMaestra);
            string mensajeEsperado = "AIM001 Descripcion personalizada insercion";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

    }
}
