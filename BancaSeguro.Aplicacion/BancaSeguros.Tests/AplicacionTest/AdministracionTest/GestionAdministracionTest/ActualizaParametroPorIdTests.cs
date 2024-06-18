//-----------------------------------------------------------------------
// <copyright file="ActualizaParametroPorIdTests.cs" company="Unión temporal FS-BAC-2013 ">
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
    /// Test Unit method Update Parameter
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 18/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [TestClass]
    public class ActualizaParametroPorIdTests
    {
        /// <summary>
        /// Update the parameter of identifier receiver all return false.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [TestMethod]
        public void ActualizaParametroPorId_LaEntidadRecibidaEstaLlena_RetornaFalse()
        {
            ////Arrange

            Parametro parametro = new Parametro();
            parametro.Activo = false;
            parametro.Descripcion = "Descripcion1";
            parametro.IdTipoDato = 1;
            parametro.IdParametro = 1;
            parametro.Valor = "Valor1";

            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParamtero = new Mock<IRepositorioParametro>();

            mockRepositorioParamtero.Setup(x => x.ActualizaParametroPorId(parametro)).Returns(new Resultado() { Error = false, Mensaje = "Insert" });
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParamtero.Object);

            ////Act
            var resultado = gestionAdministracion.ActualizaParametroPorId(parametro);

            ////Assert
            Assert.IsFalse(resultado.Error);
        }

        /// <summary>
        /// Update the parameter of identifier receiver all return message.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [TestMethod]
        public void ActualizaParametroPorId_LaEntidadRecibidaEstaLlena_RetornaMensaje()
        {
            ////Arrange
            var mockRepositorioMensaje = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<BancaSeguros.Repositorio.Log.IRepositorioLog>();
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioLog = mockRepositorioLog.Object;
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioMensaje = mockRepositorioMensaje.Object;

            Parametro parametro = new Parametro();
            parametro.Activo = false;
            parametro.Descripcion = "Descripcion1";
            parametro.IdTipoDato = 1;
            parametro.IdParametro = 1;
            parametro.Valor = "Valor1";

            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParamtero = new Mock<IRepositorioParametro>();

            mockRepositorioParamtero.Setup(x => x.ActualizaParametroPorId(parametro)).Returns(new Resultado() { Error = false, Mensaje = string.Empty });
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParamtero.Object);

            ////Act
            var resultado = gestionAdministracion.ActualizaParametroPorId(parametro);

            ////Assert
            Assert.AreEqual("APA-001 Mensaje No Parametrizado", resultado.Mensaje);
        }

        [TestMethod]
        public void RepositorioGeneraErrorRetornaMensajeError()
        {
            ////Arrange
            var mockRepositorioMensaje = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<BancaSeguros.Repositorio.Log.IRepositorioLog>();
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioLog = mockRepositorioLog.Object;
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioMensaje = mockRepositorioMensaje.Object;

            Parametro parametro = new Parametro();
            parametro.Activo = false;
            parametro.Descripcion = "Descripcion1";
            parametro.IdTipoDato = 1;
            parametro.IdParametro = 1;
            parametro.Valor = "Valor1";

            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParamtero = new Mock<IRepositorioParametro>();

            mockRepositorioParamtero.Setup(x => x.ActualizaParametroPorId(parametro)).Throws(new Exception("Mensaje del error"));
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParamtero.Object);

            ////Act
            var resultado = gestionAdministracion.ActualizaParametroPorId(parametro);

            ////Assert
            Assert.AreEqual("0 APA-002 Mensaje No Parametrizado", resultado.Mensaje);
        }

    }
}
