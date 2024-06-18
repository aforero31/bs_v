//-----------------------------------------------------------------------
// <copyright file="ActualizaCanalVentaPorIdTests.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Tests.AplicacionTest.AdministracionTest.GestionAdministracionTest
{
    using System;
    using Aplicacion.Administracion;
    using Entidades.Catalogo;
    using Entidades.General;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Repositorio.Administracion;
    using Repositorio.Venta;

    /// <summary>
    /// Test Unit method update channel sale by identifier.
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 14/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [TestClass]
    public class ActualizaCanalVentaPorIdTests
    {
        /// <summary>
        /// update channel sale by identifier the entity receive full return false.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [TestMethod]
        public void ActualizaCanalVentaPorId_LaEntidadRecibidaEstaLlena_RetornaFalse()
        {
            ////Arrange
            CanalVenta canalVenta = new CanalVenta();
            canalVenta.Activo = true;
            canalVenta.Codigo = 1234;
            canalVenta.Nombre = "PruebaCanal";
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParamtero = new Mock<IRepositorioParametro>();

            mockRepositorioCanalVenta.Setup(x => x.ActualizaCanalVentaPorId(canalVenta)).Returns(new Resultado() { Error = false, Mensaje = "Insert" });
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParamtero.Object);

            ////Act
            var resultado = gestionAdministracion.ActualizaCanalVentaPorId(canalVenta);

            ////Assert
            Assert.IsFalse(resultado.Error);
        }

        /// <summary>
        /// update channel sale by identifier the entity receive full return message.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 14/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [TestMethod]
        public void ActualizaCanalVentaPorId_LaEntidadRecibidaEstaLlena_RetornaMensaje()
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

            mockRepositorioCanalVenta.Setup(x => x.ActualizaCanalVentaPorId(canalVenta)).Returns(new Resultado() { Error = false, Mensaje = string.Empty });
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParamtero.Object);

            ////Act
            var resultado = gestionAdministracion.ActualizaCanalVentaPorId(canalVenta);

            ////Assert
            Assert.AreEqual("ACVA-002 Mensaje No Parametrizado", resultado.Mensaje);
        }

        [TestMethod]
        public void RepositorioGeneraExcepcion_RetornaMensajeError()
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

            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "ActualizaCanalVentaPorId" };

            mockRepositorioCanalVenta.Setup(x => x.ActualizaCanalVentaPorId(canalVenta)).Throws(new Exception("Mensaje del error"));
            mockRepositorioMensaje.Setup(x => x.ConsultarMensajePorId(26, "ACVA-003")).Returns(mensaje);
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParamtero.Object);            

            ////Act
            var resultado = gestionAdministracion.ActualizaCanalVentaPorId(canalVenta);

            ////Assert
            Assert.AreEqual("0 ACVA-003 Descripcion personalizada error", resultado.Mensaje);
        }

        [TestMethod]
        public void RepositorioRetornaErrorTrue_SeRetornaMensajeError()
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

            Mensaje mensaje = new Mensaje { DescripcionMensaje = "Descripcion personalizada error", IdEvento = 1, Llave = "ActualizaCanalVentaPorId" };

            mockRepositorioCanalVenta.Setup(x => x.ActualizaCanalVentaPorId(canalVenta)).Returns(new Resultado() { Error = true });
            mockRepositorioMensaje.Setup(x => x.ConsultarMensajePorId(26, "ACVA-001")).Returns(mensaje);
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParamtero.Object);

            ////Act
            var resultado = gestionAdministracion.ActualizaCanalVentaPorId(canalVenta);

            ////Assert
            Assert.AreEqual("ACVA-001 Descripcion personalizada error", resultado.Mensaje);
        }

    }
}
