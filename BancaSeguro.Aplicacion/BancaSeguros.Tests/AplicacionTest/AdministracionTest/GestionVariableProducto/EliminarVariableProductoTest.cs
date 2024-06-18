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
    public class EliminarVariableProductoTest
    {
        [TestMethod]
        public void EliminarGeneraExcepcion_RetornaResultadoConError()
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
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "EliminarVariableProducto" };

            mockRepositorioVariableProducto.Setup(x => x.EliminarVariableProducto(variableProducto)).Throws(excepcion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(30, "EVV003")).Returns(mensaje);
            GestionVariableProducto objGestion = new GestionVariableProducto(mockRepositorioVariableProducto.Object, mockRepositorioMaestra.Object, mockRepositorioItemMaestra.Object);

            //act
            Resultado resultado = objGestion.EliminarVariableProducto(variableProducto);
            string mensajeEsperado = "0 EVV003 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void EliminaretornaError_RetornaMensajeErrorPersonalizado()
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
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "EliminarVariableProducto" };

            mockRepositorioVariableProducto.Setup(x => x.EliminarVariableProducto(variableProducto)).Returns(resultadoActualizacion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(30, "EVV002")).Returns(mensaje);
            GestionVariableProducto objGestion = new GestionVariableProducto(mockRepositorioVariableProducto.Object, mockRepositorioMaestra.Object, mockRepositorioItemMaestra.Object);

            //act
            Resultado resultado = objGestion.EliminarVariableProducto(variableProducto);
            string mensajeEsperado = "EVV002 Descripcion personalizada error";

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
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada al eliminar", IdEvento = 1, Llave = "EliminarVariableProducto" };

            mockRepositorioVariableProducto.Setup(x => x.EliminarVariableProducto(variableProducto)).Returns(resultadoActualizacion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(30, "EVV001")).Returns(mensaje);
            GestionVariableProducto objGestion = new GestionVariableProducto(mockRepositorioVariableProducto.Object, mockRepositorioMaestra.Object, mockRepositorioItemMaestra.Object);

            //act
            Resultado resultado = objGestion.EliminarVariableProducto(variableProducto);
            string mensajeEsperado = "EVV001 Descripcion personalizada al eliminar";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }
    }
}
