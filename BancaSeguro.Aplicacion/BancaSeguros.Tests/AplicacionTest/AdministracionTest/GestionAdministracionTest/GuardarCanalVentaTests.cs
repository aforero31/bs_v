//-----------------------------------------------------------------------
// <copyright file="GuardarCanalVentaTests.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Tests.AplicacionTest.AdministracionTest.GestionAdministracionTest
{
    using Aplicacion.Administracion;
    using Entidades.Catalogo;
    using Entidades.General;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Repositorio.Administracion;
    using Repositorio.Venta;

    /// <summary>
    /// Test Unit method save channel sale
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 14/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [TestClass]
    public class GuardarCanalVentaTests
    {
        /// <summary>
        /// Save the channel sale the entity receive full return false.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [TestMethod]
        public void GuardarCanalVenta_LaEntidadRecibidaEstaLlena_RetornaFalse()
        {
            ////Arrange
            CanalVenta canalVenta = new CanalVenta();
            canalVenta.Activo = true;
            canalVenta.Codigo = 1234;
            canalVenta.Nombre = "PruebaCanal";
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParamtero = new Mock<IRepositorioParametro>();

            mockRepositorioCanalVenta.Setup(x => x.GuardarCanalVenta(canalVenta)).Returns(new Resultado() { Error = false, Mensaje = "Insert" });
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParamtero.Object);

            ////Act
            var resultado = gestionAdministracion.GuardarCanalVenta(canalVenta);

            ////Assert
            Assert.IsFalse(resultado.Error);
        }

        /// <summary>
        /// Save the channel sale the entity receive full return message.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [TestMethod]
        public void GuardarCanalVenta_LaEntidadRecibidaEstaLlena_RetornaMesaje()
        {
            ////Arrange
            var mockRepositorioMensaje = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<BancaSeguros.Repositorio.Log.IRepositorioLog>();
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioLog = mockRepositorioLog.Object;
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioMensaje = mockRepositorioMensaje.Object;

            string mensajeEsperado = "ICVA-002 Mensaje No Parametrizado";
            CanalVenta canalVenta = new CanalVenta();
            canalVenta.Activo = true;
            canalVenta.Codigo = 1234;
            canalVenta.Nombre = "PruebaCanal";
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParamtero = new Mock<IRepositorioParametro>();

            mockRepositorioCanalVenta.Setup(x => x.GuardarCanalVenta(canalVenta)).Returns(new Resultado() { Error = false, Mensaje = mensajeEsperado });
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParamtero.Object);

            ////Act
            var resultado = gestionAdministracion.GuardarCanalVenta(canalVenta);

            ////Assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        /// <summary>
        /// Save the channel sale the entity receive full by exists the channel sale in data base return true.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [TestMethod]
        public void GuardarCanalVenta_LaEntidadRecibidaEstaLlenaPeroYaExisteElCanalVentaEnBD_RetornaTrue()
        {
            ////Arrange
            var mockRepositorioMensaje = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<BancaSeguros.Repositorio.Log.IRepositorioLog>();
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioLog = mockRepositorioLog.Object;
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioMensaje = mockRepositorioMensaje.Object;

            CanalVenta canalVenta = new CanalVenta();
            canalVenta.Activo = true;
            canalVenta.Codigo = 1234;
            canalVenta.Nombre = "PruebaCanal";
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParamtero = new Mock<IRepositorioParametro>();

            mockRepositorioCanalVenta.Setup(x => x.GuardarCanalVenta(canalVenta)).Returns(new Resultado() { Error = false, Mensaje = string.Empty });
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParamtero.Object);

            ////Act
            var resultado = gestionAdministracion.GuardarCanalVenta(canalVenta);

            ////Assert
            Assert.IsFalse(resultado.Error);
        }

        /// <summary>
        /// Save the channel sale the entity receive full by exists the channel sale in data base return message.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [TestMethod]
        public void GuardarCanalVenta_LaEntidadRecibidaEstaLlenaPeroYaExisteElCanalVentaEnBD_RetornaMensaje()
        {
            ////Arrange
            var mockRepositorioMensaje = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<BancaSeguros.Repositorio.Log.IRepositorioLog>();
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioLog = mockRepositorioLog.Object;
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioMensaje = mockRepositorioMensaje.Object;

            string mensajeEsperado = "ICVA-002 Mensaje No Parametrizado";
            CanalVenta canalVenta = new CanalVenta();
            canalVenta.Activo = true;
            canalVenta.Codigo = 1234;
            canalVenta.Nombre = "PruebaCanal";
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParamtero = new Mock<IRepositorioParametro>();

            mockRepositorioCanalVenta.Setup(x => x.GuardarCanalVenta(canalVenta)).Returns(new Resultado() { Error = false, Mensaje = string.Empty });
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParamtero.Object);

            ////Act
            var resultado = gestionAdministracion.GuardarCanalVenta(canalVenta);

            ////Assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        /// <summary>
        /// Save the channel sale is save satisfaction return message.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 15/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [TestMethod]
        public void GuardarCanalVenta_ElCanalVentaEsGuardadoSatisfactoriamente_RetornaMensaje()
        {
            ////Arrange
            var mockRepositorioMensaje = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<BancaSeguros.Repositorio.Log.IRepositorioLog>();
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioLog = mockRepositorioLog.Object;
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioMensaje = mockRepositorioMensaje.Object;

            string mensajeEsperado = "ICVA-002 Mensaje No Parametrizado";
            CanalVenta canalVenta = new CanalVenta();
            canalVenta.Activo = true;
            canalVenta.Codigo = 1234;
            canalVenta.Nombre = "PruebaCanal";
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParamtero = new Mock<IRepositorioParametro>();

            mockRepositorioCanalVenta.Setup(x => x.GuardarCanalVenta(canalVenta)).Returns(new Resultado() { Error = false, Mensaje = mensajeEsperado });
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParamtero.Object);

            ////Act
            var resultado = gestionAdministracion.GuardarCanalVenta(canalVenta);

            ////Assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }
    }
}
