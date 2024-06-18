namespace BancaSeguros.Tests.AplicacionTest.AdministracionTest.GestionAdministracionTest
{
    using System;
    using Aplicacion.Administracion;
    using Aplicacion.Configuraciones;
    using Entidades.Seguro;
    using Entidades.General;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using BAC.Seguridad.Mensaje;
    using Repositorio.Administracion;
    using Repositorio.Log;
    using Repositorio.Venta;

    [TestClass]
    public class ActivarEstadoPlantillaTest
    {
        [TestMethod]
        public void ActivaExitosamenteRetornaErrorFalse()
        {
            //arrange
            DocumentoPoliza documentoPoliza = new DocumentoPoliza();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParametro = new Mock<IRepositorioParametro>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParametro.Object);

            int idDocumentoPlantilla = 1;
            Mensaje mensaje = new Mensaje { DescripcionMensaje = string.Empty, IdEvento = 7, Llave = "ActivarEstadoPlantilla" };

            mockRepositorioDocumentoPoliza.Setup(x => x.ActivarEstadoPlantilla(idDocumentoPlantilla)).Returns(new Resultado());
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(7, "IPA002")).Returns(mensaje);

            //act            
            Resultado resultado = gestionAdministracion.ActivarEstadoPlantilla(idDocumentoPlantilla);

            //assert
            Assert.IsFalse(resultado.Error);
        }

        [TestMethod]
        public void RepositorioGeneraErrorRetornaErrorTrue()
        {
            //arrange
            DocumentoPoliza documentoPoliza = new DocumentoPoliza();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParametro = new Mock<IRepositorioParametro>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParametro.Object);

            int idDocumentoPlantilla = 1;
            mockRepositorioDocumentoPoliza.Setup(x => x.ActivarEstadoPlantilla(idDocumentoPlantilla)).Returns(new Resultado() { Error = true });            

            //act            
            Resultado resultado = gestionAdministracion.ActivarEstadoPlantilla(idDocumentoPlantilla);

            //assert
            Assert.IsTrue(resultado.Error);
        }

        [TestMethod]
        public void RepositorioGeneraExcepcionRetornaMensajeError()
        {
            //arrange
            DocumentoPoliza documentoPoliza = new DocumentoPoliza();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParametro = new Mock<IRepositorioParametro>();
            var mockRepositorioMensajes = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            ControlMensajes.repositorioMensaje = mockRepositorioMensajes.Object;
            ControlMensajes.repositorioLog = mockRepositorioLog.Object;

            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParametro.Object);

            int idDocumentoPlantilla = 1;
            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Mensaje de error ActivarEstadoPlantilla", IdEvento = 7, Llave = "ActivarEstadoPlantilla" };
            Exception exception = new Exception();

            mockRepositorioDocumentoPoliza.Setup(x => x.ActivarEstadoPlantilla(idDocumentoPlantilla)).Throws(exception);
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(7, "IPA001")).Returns(mensaje);

            //act            
            Resultado resultado = gestionAdministracion.ActivarEstadoPlantilla(idDocumentoPlantilla);

            //assert
            Assert.AreEqual("0 IPA001 Mensaje de error ActivarEstadoPlantilla", resultado.Mensaje);
        }

    }
}
