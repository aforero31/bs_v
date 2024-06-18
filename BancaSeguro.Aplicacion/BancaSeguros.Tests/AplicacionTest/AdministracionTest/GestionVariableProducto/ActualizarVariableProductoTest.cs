namespace BancaSeguros.Tests.AplicacionTest.AdministracionTest.GestionVariableProducto
{
    using System;
    using Aplicacion.Administracion;
    using BAC.Seguridad.Mensaje;
    using Entidades.General;
    using Entidades.Seguro;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Repositorio.Administracion;
    using Repositorio.Log;

    [TestClass]
    public class ActualizarVariableProductoTest
    {
        [TestMethod]
        public void ActualizarGeneraExcepcion_RetornaResultadoConError()
        {
            //arrange
            VariableProducto variableProducto = new VariableProducto();

            var mockRepositorioVariableProducto = new Mock<IRepositorioVariableProducto>();
            var mockRepositorioMaestra = new Mock<IRepositorioMaestra>();
            var mockRepositorioItemMaestra = new Mock<IRepositorioItemMaestra>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Exception excepcion = new Exception("Mensaje de error en actualización");
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "ActualizarVariableProducto" };

            mockRepositorioVariableProducto.Setup(x => x.ActualizarVariableProducto(variableProducto)).Throws(excepcion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(29, "AVV003")).Returns(mensaje);
            GestionVariableProducto objGestion = new GestionVariableProducto(mockRepositorioVariableProducto.Object, mockRepositorioMaestra.Object, mockRepositorioItemMaestra.Object);

            //act
            Resultado resultado = objGestion.ActualizarVariableProducto(variableProducto);
            string mensajeEsperado = "0 AVV003 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void ActualizaRetornaError_RetornaMensajeErrorPersonalizado()
        {
            //arrange
            VariableProducto variableProducto = new VariableProducto();

            var mockRepositorioVariableProducto = new Mock<IRepositorioVariableProducto>();
            var mockRepositorioMaestra = new Mock<IRepositorioMaestra>();
            var mockRepositorioItemMaestra = new Mock<IRepositorioItemMaestra>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoActualizacion = new Resultado { Error = true };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "ActualizarVariableProducto" };

            mockRepositorioVariableProducto.Setup(x => x.ActualizarVariableProducto(variableProducto)).Returns(resultadoActualizacion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(29, "AVV002")).Returns(mensaje);
            GestionVariableProducto objGestion = new GestionVariableProducto(mockRepositorioVariableProducto.Object, mockRepositorioMaestra.Object, mockRepositorioItemMaestra.Object);

            //act
            Resultado resultado = objGestion.ActualizarVariableProducto(variableProducto);
            string mensajeEsperado = "AVV002 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void ActualizaExitosamente_RetornaMensajePersonalizado()
        {
            //arrange
            VariableProducto variableProducto = new VariableProducto();

            var mockRepositorioVariableProducto = new Mock<IRepositorioVariableProducto>();
            var mockRepositorioMaestra = new Mock<IRepositorioMaestra>();
            var mockRepositorioItemMaestra = new Mock<IRepositorioItemMaestra>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            Resultado resultadoActualizacion = new Resultado { Error = false };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada actualización", IdEvento = 1, Llave = "ActualizarVariableProducto" };

            mockRepositorioVariableProducto.Setup(x => x.ActualizarVariableProducto(variableProducto)).Returns(resultadoActualizacion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(29, "AVV001")).Returns(mensaje);
            GestionVariableProducto objGestion = new GestionVariableProducto(mockRepositorioVariableProducto.Object, mockRepositorioMaestra.Object, mockRepositorioItemMaestra.Object);

            //act
            Resultado resultado = objGestion.ActualizarVariableProducto(variableProducto);
            string mensajeEsperado = "AVV001 Descripcion personalizada actualización";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }
    }
}
