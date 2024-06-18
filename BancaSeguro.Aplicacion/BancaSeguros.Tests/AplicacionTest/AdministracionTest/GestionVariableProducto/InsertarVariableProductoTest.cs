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
    public class InsertarVariableProductoTest
    {
        [TestMethod]
        public void InsertarGeneraExcepcion_RetornaResultadoConError()
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

            Exception excepcion = new Exception("Mensaje de error en inserción");
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "InsertarVariableProducto" };

            mockRepositorioVariableProducto.Setup(x => x.InsertarVariableProducto(variableProducto)).Throws(excepcion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(28, "IVV003")).Returns(mensaje);
            GestionVariableProducto objGestion = new GestionVariableProducto(mockRepositorioVariableProducto.Object, mockRepositorioMaestra.Object, mockRepositorioItemMaestra.Object);

            //act
            Resultado resultado = objGestion.InsertarVariableProducto(variableProducto);
            string mensajeEsperado = "0 IVV003 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void InsertaRetornaError_RetornaMensajeErrorPersonalizado()
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

            Resultado resultadoInsercion = new Resultado { Error = true };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "InsertarVariableProducto" };

            mockRepositorioVariableProducto.Setup(x => x.InsertarVariableProducto(variableProducto)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(28, "IVV002")).Returns(mensaje);
            GestionVariableProducto objGestion = new GestionVariableProducto(mockRepositorioVariableProducto.Object, mockRepositorioMaestra.Object, mockRepositorioItemMaestra.Object);

            //act
            Resultado resultado = objGestion.InsertarVariableProducto(variableProducto);
            string mensajeEsperado = "IVV002 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void InsertaExitosamente_RetornaMensajePersonalizado()
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

            Resultado resultadoInsercion = new Resultado { Error = false };
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada insercion", IdEvento = 1, Llave = "InsertarVariableProducto" };

            mockRepositorioVariableProducto.Setup(x => x.InsertarVariableProducto(variableProducto)).Returns(resultadoInsercion);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(28, "IVV001")).Returns(mensaje);
            GestionVariableProducto objGestion = new GestionVariableProducto(mockRepositorioVariableProducto.Object, mockRepositorioMaestra.Object, mockRepositorioItemMaestra.Object);

            //act
            Resultado resultado = objGestion.InsertarVariableProducto(variableProducto);
            string mensajeEsperado = "IVV001 Descripcion personalizada insercion";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }
    }
}
