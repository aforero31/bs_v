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
    public class InsertarItemMaestraTest
    {
        [TestMethod]
        public void InsertarGeneraExcepcion_RetornaResultadoConError()
        {
            //arrange
            ItemMaestra itemMaestra = new ItemMaestra();

            var mockRepositorioItemMaestra = new Mock<IRepositorioItemMaestra>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Exception excepcion = new Exception("Mensaje de error en inserción");
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "InsertarItemMaestra" };

            mockRepositorioItemMaestra.Setup(x => x.InsertarItemMaestra(itemMaestra)).Throws(excepcion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(34, "IIM003")).Returns(mensaje);
            GestionItemMaestra objGestion = new GestionItemMaestra(mockRepositorioItemMaestra.Object);

            //act
            Resultado resultado = objGestion.InsertarItemMaestra(itemMaestra);
            string mensajeEsperado = "0 IIM003 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void InsertaRetornaError_RetornaMensajeErrorPersonalizado()
        {
            //arrange
            ItemMaestra itemMaestra = new ItemMaestra();

            var mockRepositorioItemMaestra = new Mock<IRepositorioItemMaestra>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoInsercion = new Resultado { Error = true };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "InsertarAseguradora" };

            mockRepositorioItemMaestra.Setup(x => x.InsertarItemMaestra(itemMaestra)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(34, "IIM002")).Returns(mensaje);
            GestionItemMaestra objGestion = new GestionItemMaestra(mockRepositorioItemMaestra.Object);

            //act
            Resultado resultado = objGestion.InsertarItemMaestra(itemMaestra);
            string mensajeEsperado = "IIM002 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void InsertaExitosamente_RetornaMensajePersonalizado()
        {
            //arrange
            ItemMaestra itemMaestra = new ItemMaestra();

            var mockRepositorioItemMaestra = new Mock<IRepositorioItemMaestra>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoInsercion = new Resultado { Error = false };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada insercion", IdEvento = 1, Llave = "InsertarAseguradora" };

            mockRepositorioItemMaestra.Setup(x => x.InsertarItemMaestra(itemMaestra)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(34, "IIM001")).Returns(mensaje);
            GestionItemMaestra objGestion = new GestionItemMaestra(mockRepositorioItemMaestra.Object);

            //act
            Resultado resultado = objGestion.InsertarItemMaestra(itemMaestra);
            string mensajeEsperado = "IIM001 Descripcion personalizada insercion";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }


    }
}
