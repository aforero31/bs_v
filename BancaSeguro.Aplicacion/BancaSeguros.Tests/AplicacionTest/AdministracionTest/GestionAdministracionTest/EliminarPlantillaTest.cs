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
    public class EliminarPlantillaTest
    {
        [TestMethod]
        public void EliminaExitosamenteRetornaErrorFalse()
        {
            //arrange
            DocumentoPoliza documentoPoliza = new DocumentoPoliza();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParametro = new Mock<IRepositorioParametro>();
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParametro.Object);

            int idDocumentoPlantilla = 1;
            mockRepositorioDocumentoPoliza.Setup(x => x.EliminarPlantilla(idDocumentoPlantilla)).Returns(new Resultado());

            //act            
            Resultado resultado = gestionAdministracion.EliminarPlantilla(idDocumentoPlantilla);

            //assert
            Assert.IsFalse(resultado.Error);
        }

        [TestMethod]
        public void EliminarGeneraErrorRetornaMensaje()
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

            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "InsertarDocumentoPlantillaSeguro" };
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParametro.Object);

            int idDocumentoPlantilla = 1;
            mockRepositorioDocumentoPoliza.Setup(x => x.EliminarPlantilla(idDocumentoPlantilla)).Throws(new Exception("Mensaje del error"));
            mockRepositorioMensajes.Setup(x => x.ConsultarMensajePorId(7, "IPA001")).Returns(mensaje);

            //act            
            Resultado resultado = gestionAdministracion.EliminarPlantilla(idDocumentoPlantilla);
            string mensajeEsperado = "0 IPA001 Descripcion personalizada error";

            //assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

    }
}
