//-----------------------------------------------------------------------
// <copyright file="GuardarParametroTests.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Tests.AplicacionTest.AdministracionTest.GestionAdministracionTest
{
    using System;
    using Aplicacion.Administracion;
    using Aplicacion.Configuraciones;
    using Entidades.Catalogo;
    using Entidades.General;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Repositorio.Administracion;
    using Repositorio.Log;
    using Repositorio.Venta;

    /// <summary>
    /// Unit test class Save Parameter
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 18/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [TestClass]
    public class GuardarParametroTests
    {
        [TestInitialize]
        public void InicializarControlMensajes()
        {
            var mockRepositorioMensaje = new Mock<IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<IRepositorioLog>();
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioLog = mockRepositorioLog.Object;
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioMensaje = mockRepositorioMensaje.Object;
        }

        /// <summary>
        /// Save the parameter the entity receive full return false.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [TestMethod]
        public void GuardarParametro_LaEntidadRecibidaEstaLlena_RetornaFalse()
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
            var mockRepositorioParametro = new Mock<IRepositorioParametro>();

            mockRepositorioParametro.Setup(x => x.GuardarParametro(parametro)).Returns(new Resultado() { Error = false, Mensaje = "Insert" });
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParametro.Object);

            ////Act
            var resultado = gestionAdministracion.GuardarParametro(parametro);

            ////Assert
            Assert.IsFalse(resultado.Error);
        }

        /// <summary>
        /// Save the parameter the entity receive full return message.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [TestMethod]
        public void GuardarParametro_LaEntidadRecibidaEstaLlena_RetornaMesaje()
        {
            ////Arrange
            string mensajeEsperado = "IPA-002 Mensaje No Parametrizado";
            Parametro parametro = new Parametro();
            parametro.Activo = false;
            parametro.Descripcion = "Descripcion1";
            parametro.IdTipoDato = 1;
            parametro.IdParametro = 1;
            parametro.Valor = "Valor1";

            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParametro = new Mock<IRepositorioParametro>();

            mockRepositorioParametro.Setup(x => x.GuardarParametro(parametro)).Returns(new Resultado() { Error = false, Mensaje = mensajeEsperado });
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParametro.Object);

            ////Act
            var resultado = gestionAdministracion.GuardarParametro(parametro);

            ////Assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        /// <summary>
        /// Save parameter the entity receiver all by exist the parameter in base data return true.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [TestMethod]
        public void GuardarParametro_LaEntidadRecibidaEstaLlenaPeroYaExisteElParametroEnBD_RetornaTrue()
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
            var mockRepositorioParametro = new Mock<IRepositorioParametro>();

            mockRepositorioParametro.Setup(x => x.GuardarParametro(parametro)).Returns(new Resultado() { Error = false, Mensaje = string.Empty });
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParametro.Object);

            ////Act
            var resultado = gestionAdministracion.GuardarParametro(parametro);

            ////Assert
            Assert.IsFalse(resultado.Error);
        }

        /// <summary>
        /// Save parameter the entity receiver all by exist the parameter in base data return message.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [TestMethod]
        public void GuardarParametro_LaEntidadRecibidaEstaLlenaPeroYaExisteElParametroEnBD_RetornaMensaje()
        {
            ////Arrange
            string mensajeEsperado = "IPA-002 Mensaje No Parametrizado";
            Parametro parametro = new Parametro();
            parametro.Activo = false;
            parametro.Descripcion = "Descripcion1";
            parametro.IdTipoDato = 1;
            parametro.IdParametro = 1;
            parametro.Valor = "Valor1";

            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParamtero = new Mock<IRepositorioParametro>();

            mockRepositorioParamtero.Setup(x => x.GuardarParametro(parametro)).Returns(new Resultado() { Error = false, Mensaje = string.Empty });
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParamtero.Object);

            ////Act
            var resultado = gestionAdministracion.GuardarParametro(parametro);

            ////Assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        /// <summary>
        /// Save the parameter return message.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [TestMethod]
        public void GuardarParametro_ElParametroEsGuardadoSatisfactoriamente_RetornaMensaje()
        {
            ////Arrange
            string mensajeEsperado = LlavesAplicacion.ParametroGuardadoInsertar + " Mensaje No Parametrizado";
            Parametro parametro = new Parametro();
            parametro.Activo = false;
            parametro.Descripcion = "Descripcion1";
            parametro.IdTipoDato = 1;
            parametro.IdParametro = 1;
            parametro.Valor = "Valor1";

            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParametro = new Mock<IRepositorioParametro>();

            mockRepositorioParametro.Setup(x => x.GuardarParametro(parametro)).Returns(new Resultado() { Error = false, Mensaje = mensajeEsperado });
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParametro.Object);

            ////Act
            var resultado = gestionAdministracion.GuardarParametro(parametro);

            ////Assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

        [TestMethod]
        public void RepositorioGeneraError_RetornaMensajeError()
        {
            ////Arrange
            string mensajeEsperado = "0 IPA-003 Mensaje No Parametrizado";
            Parametro parametro = new Parametro();
            parametro.Activo = false;
            parametro.Descripcion = "Descripcion1";
            parametro.IdTipoDato = 1;
            parametro.IdParametro = 1;
            parametro.Valor = "Valor1";

            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioCanalVenta = new Mock<IRepositorioCanalVenta>();
            var mockRepositorioParametro = new Mock<IRepositorioParametro>();

            mockRepositorioParametro.Setup(x => x.GuardarParametro(parametro)).Throws(new Exception("Mensaje del error"));
            GestionAdministracion gestionAdministracion = new GestionAdministracion(mockRepositorioDocumentoPoliza.Object, mockRepositorioCanalVenta.Object, mockRepositorioParametro.Object);

            ////Act
            var resultado = gestionAdministracion.GuardarParametro(parametro);

            ////Assert
            Assert.AreEqual(mensajeEsperado, resultado.Mensaje);
        }

    }
}