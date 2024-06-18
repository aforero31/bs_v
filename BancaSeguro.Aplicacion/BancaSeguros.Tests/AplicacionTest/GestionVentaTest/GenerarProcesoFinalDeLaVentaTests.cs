using BAC.EntidadesSeguridad;
using BancaSeguros.Aplicacion.Venta;
using BancaSeguros.Entidades.Venta;
using BancaSeguros.Repositorio.Venta;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace BancaSeguros.Tests.AplicacionTest.VentaTest
{
    [TestClass]
    public class GenerarProcesoFinalDeLaVentaTests
    {
        [TestInitialize]
        public void InicializarControlMensajes()
        {
            var mockRepositorioMensaje = new Mock<Repositorio.Administracion.IRepositorioMensaje>();
            var mockRepositorioLog = new Mock<Repositorio.Log.IRepositorioLog>();
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioLog = mockRepositorioLog.Object;
            BAC.Seguridad.Mensaje.ControlMensajes.repositorioMensaje = mockRepositorioMensaje.Object;
        }

        [TestMethod]
        public void GenerarProcesoFinalDeLaVenta_SeIngresaAObtenerConsecutivoPolizaNoRetornaConsecutivoPoliza_RetornaErrorTrue()
        {
            //Arrange
            ResultadoVentaPoliza resultadoVentaPoliza = new ResultadoVentaPoliza();
            RegistrarVenta registrarVenta = new RegistrarVenta();
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            Aplicacion.Cobis.IGestionCobis gestionCobis = null;
            mockRepositorioVenta.Setup(x => x.ObtenerConsecutivo(registrarVenta)).Returns(string.Empty);
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultadoVentaPoliza = gestionVenta.GenerarProcesoFinalDeLaVenta(registrarVenta, gestionCobis);

            //Assert
            Assert.IsTrue(resultadoVentaPoliza.Resultado.Error);
        }

        [TestMethod]
        public void GenerarProcesoFinalDeLaVenta_SeIngresaAObtenerConsecutivoPolizaNoRetornaConsecutivoPoliza_RetornaMensajeError()
        {
            //Arrange
            ResultadoVentaPoliza resultadoVentaPoliza = new ResultadoVentaPoliza();
            RegistrarVenta registrarVenta = new RegistrarVenta();
            string mensaje = "RV001 Mensaje No Parametrizado";
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            Aplicacion.Cobis.IGestionCobis gestionCobis = null;
            mockRepositorioVenta.Setup(x => x.ObtenerConsecutivo(registrarVenta)).Returns("");
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultadoVentaPoliza = gestionVenta.GenerarProcesoFinalDeLaVenta(registrarVenta, gestionCobis);

            //Assert
            Assert.AreEqual(resultadoVentaPoliza.Resultado.Mensaje, mensaje);
        }

        [TestMethod]
        public void GenerarProcesoFinalDeLaVenta_SeIngresaGuardarAsesor_RetornaErrorTrue()
        {
            //Arrange
            ResultadoVentaPoliza resultadoVentaPoliza = new ResultadoVentaPoliza();
            RegistrarVenta registrarVenta = new RegistrarVenta();
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            Aplicacion.Cobis.IGestionCobis gestionCobis = null;
            mockRepositorioVenta.Setup(x => x.ObtenerConsecutivo(registrarVenta)).Returns("111421");
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaAsesor(registrarVenta.Asesor)).Returns(true);
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultadoVentaPoliza = gestionVenta.GenerarProcesoFinalDeLaVenta(registrarVenta, gestionCobis);

            //Assert
            Assert.IsTrue(resultadoVentaPoliza.Resultado.Error);
        }

        [TestMethod]
        public void GenerarProcesoFinalDeLaVenta_SeIngresaGuardarAsesor_RetornaMensajeError()
        {
            //Arrange
            ResultadoVentaPoliza resultadoVentaPoliza = new ResultadoVentaPoliza();
            RegistrarVenta registrarVenta = new RegistrarVenta();
            string mensaje = "RV002 Mensaje No Parametrizado";
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            Aplicacion.Cobis.IGestionCobis gestionCobis = null;
            mockRepositorioVenta.Setup(x => x.ObtenerConsecutivo(registrarVenta)).Returns("111421");
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaAsesor(registrarVenta.Asesor)).Returns(true);
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultadoVentaPoliza = gestionVenta.GenerarProcesoFinalDeLaVenta(registrarVenta, gestionCobis);

            //Assert
            Assert.AreEqual(resultadoVentaPoliza.Resultado.Mensaje, mensaje);
        }

        [TestMethod]
        public void GenerarProcesoFinalDeLaVenta_SeIngresaGuardarVentaNoDevuelveID_RetornaErrorTrue()
        {
            //Arrange
            ResultadoVentaPoliza resultadoVentaPoliza = new ResultadoVentaPoliza();
            RegistrarVenta registrarVenta = new RegistrarVenta();
            registrarVenta.Cliente = new Cliente();
            registrarVenta.Cliente.Genero = "Femenino";
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            Aplicacion.Cobis.IGestionCobis gestionCobis = null;
            mockRepositorioVenta.Setup(x => x.ObtenerConsecutivo(registrarVenta)).Returns("111421");
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaAsesor(registrarVenta.Asesor)).Returns(false);
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaVenta(registrarVenta)).Returns(new RegistrarVenta());
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultadoVentaPoliza = gestionVenta.GenerarProcesoFinalDeLaVenta(registrarVenta, gestionCobis);

            //Assert
            Assert.IsTrue(resultadoVentaPoliza.Resultado.Error);
        }

        [TestMethod]
        public void GenerarProcesoFinalDeLaVenta_SeIngresaGuardarVentaNoDevuelveID_RetornaMensajeError()
        {
            //Arrange
            ResultadoVentaPoliza resultadoVentaPoliza = new ResultadoVentaPoliza();
            RegistrarVenta registrarVenta = new RegistrarVenta();
            registrarVenta.Cliente = new Cliente();
            registrarVenta.Cliente.Genero = "Femenino";
            string mensaje = "RV007 Mensaje No Parametrizado";
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            Aplicacion.Cobis.IGestionCobis gestionCobis = null;
            mockRepositorioVenta.Setup(x => x.ObtenerConsecutivo(registrarVenta)).Returns("111421");
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaAsesor(registrarVenta.Asesor)).Returns(false);
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaVenta(registrarVenta)).Returns(new RegistrarVenta());
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultadoVentaPoliza = gestionVenta.GenerarProcesoFinalDeLaVenta(registrarVenta, gestionCobis);

            //Assert
            Assert.AreEqual(resultadoVentaPoliza.Resultado.Mensaje, mensaje);
        }

        [TestMethod]
        public void GenerarProcesoFinalDeLaVenta_SeIngresaRegistrarVentaBeneficiario_RetornaErrorTrue()
        {
            //Arrange
            ResultadoVentaPoliza resultadoVentaPoliza = new ResultadoVentaPoliza();
            RegistrarVenta registrarVenta = new RegistrarVenta();
            registrarVenta.Cliente = new Cliente();
            registrarVenta.Cliente.Genero = "Femenino";
            registrarVenta.Beneficiario = new List<Beneficiario> { new Beneficiario { IdBeneficiario = 1 } };
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            Aplicacion.Cobis.IGestionCobis gestionCobis = null;
            mockRepositorioVenta.Setup(x => x.ObtenerConsecutivo(registrarVenta)).Returns("111421");
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaAsesor(registrarVenta.Asesor)).Returns(false);
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaVenta(registrarVenta)).Returns(new RegistrarVenta { IdVenta = 122, Beneficiario = registrarVenta.Beneficiario });
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaBeneficiario(new Beneficiario { IdBeneficiario = 1 })).Returns(false);
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultadoVentaPoliza = gestionVenta.GenerarProcesoFinalDeLaVenta(registrarVenta, gestionCobis);

            //Assert
            Assert.IsTrue(resultadoVentaPoliza.Resultado.Error);
        }

        [TestMethod]
        public void GenerarProcesoFinalDeLaVenta_SeIngresaRegistrarVentaBeneficiario_RetornaMensajeError()
        {
            //Arrange
            ResultadoVentaPoliza resultadoVentaPoliza = new ResultadoVentaPoliza();
            RegistrarVenta registrarVenta = new RegistrarVenta();
            registrarVenta.Cliente = new Cliente();
            registrarVenta.Cliente.Genero = "Femenino";
            registrarVenta.Beneficiario = new List<Beneficiario> { new Beneficiario { IdBeneficiario = 1 } };
            string mensaje = "RV004 Mensaje No Parametrizado";
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            Aplicacion.Cobis.IGestionCobis gestionCobis = null;
            mockRepositorioVenta.Setup(x => x.ObtenerConsecutivo(registrarVenta)).Returns("111421");
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaAsesor(registrarVenta.Asesor)).Returns(false);
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaVenta(registrarVenta)).Returns(new RegistrarVenta { IdVenta = 122, Beneficiario = registrarVenta.Beneficiario });
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaBeneficiario(new Beneficiario { IdBeneficiario = 1 })).Returns(false);
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultadoVentaPoliza = gestionVenta.GenerarProcesoFinalDeLaVenta(registrarVenta, gestionCobis);

            //Assert
            Assert.AreEqual(resultadoVentaPoliza.Resultado.Mensaje, mensaje);
        }

        [TestMethod]
        public void GenerarProcesoFinalDeLaVenta_SeIngresaGuardarDatosVentaEnTablaConyugue_RetornaErrorTrue()
        {
            //Arrange
            ResultadoVentaPoliza resultadoVentaPoliza = new ResultadoVentaPoliza();
            RegistrarVenta registrarVenta = new RegistrarVenta();
            registrarVenta.Cliente = new Cliente { Genero = "Femenino" };
            registrarVenta.Conyuge = new Conyuge { IdConyuge = 1, Genero = "Femenino" };
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            Aplicacion.Cobis.IGestionCobis gestionCobis = null;
            mockRepositorioVenta.Setup(x => x.ObtenerConsecutivo(registrarVenta)).Returns("111421");
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaAsesor(registrarVenta.Asesor)).Returns(false);
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaVenta(registrarVenta)).Returns(new RegistrarVenta { IdVenta = 122, Beneficiario = registrarVenta.Beneficiario, Conyuge = registrarVenta.Conyuge });
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaConyugue(registrarVenta.Conyuge)).Returns(false);
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultadoVentaPoliza = gestionVenta.GenerarProcesoFinalDeLaVenta(registrarVenta, gestionCobis);

            //Assert
            Assert.IsTrue(resultadoVentaPoliza.Resultado.Error);
        }

        [TestMethod]
        public void GenerarProcesoFinalDeLaVenta_SeIngresaGuardarDatosVentaEnTablaConyugue_RetornaMensajeError()
        {
            //Arrange
            ResultadoVentaPoliza resultadoVentaPoliza = new ResultadoVentaPoliza();
            RegistrarVenta registrarVenta = new RegistrarVenta();
            registrarVenta.Cliente = new Cliente { Genero = "Femenino" };
            registrarVenta.Conyuge = new Conyuge { IdConyuge = 1, Genero = "Femenino" };
            string mensaje = "RV003 Mensaje No Parametrizado";
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            Aplicacion.Cobis.IGestionCobis gestionCobis = null;
            mockRepositorioVenta.Setup(x => x.ObtenerConsecutivo(registrarVenta)).Returns("111421");
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaAsesor(registrarVenta.Asesor)).Returns(false);
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaVenta(registrarVenta)).Returns(new RegistrarVenta { IdVenta = 122, Beneficiario = registrarVenta.Beneficiario, Conyuge = registrarVenta.Conyuge });
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaConyugue(registrarVenta.Conyuge)).Returns(false);
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultadoVentaPoliza = gestionVenta.GenerarProcesoFinalDeLaVenta(registrarVenta, gestionCobis);

            //Assert
            Assert.AreEqual(resultadoVentaPoliza.Resultado.Mensaje, mensaje);
        }

        [TestMethod]
        public void GenerarProcesoFinalDeLaVenta_SeIngresaRegistrarVariablesVenta_RetornaErrorTrue()
        {
            //Arrange
            ResultadoVentaPoliza resultadoVentaPoliza = new ResultadoVentaPoliza();
            RegistrarVenta registrarVenta = new RegistrarVenta();
            registrarVenta.Cliente = new Cliente { Genero = "Femenino" };
            registrarVenta.Conyuge = new Conyuge { IdConyuge = 1, Genero = "Femenino" };
            registrarVenta.VariablesVenta = new List<VariableVenta> { new VariableVenta { IdVariableVenta = 1 } };
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            Aplicacion.Cobis.IGestionCobis gestionCobis = null;
            mockRepositorioVenta.Setup(x => x.ObtenerConsecutivo(registrarVenta)).Returns("111421");
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaAsesor(registrarVenta.Asesor)).Returns(false);
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaVenta(registrarVenta)).Returns(new RegistrarVenta { IdVenta = 122, Beneficiario = registrarVenta.Beneficiario, Conyuge = registrarVenta.Conyuge, VariablesVenta = registrarVenta.VariablesVenta });
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaConyugue(registrarVenta.Conyuge)).Returns(true);
            mockRepositorioVenta.Setup(x => x.GuardarVariableVenta(registrarVenta.VariablesVenta[0])).Returns(false);
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultadoVentaPoliza = gestionVenta.GenerarProcesoFinalDeLaVenta(registrarVenta, gestionCobis);

            //Assert
            Assert.IsTrue(resultadoVentaPoliza.Resultado.Error);
        }

        [TestMethod]
        public void GenerarProcesoFinalDeLaVenta_SeIngresaRegistrarVariablesVenta_RetornaMensajeError()
        {
            //Arrange
            ResultadoVentaPoliza resultadoVentaPoliza = new ResultadoVentaPoliza();
            RegistrarVenta registrarVenta = new RegistrarVenta();
            registrarVenta.Cliente = new Cliente { Genero = "Femenino" };
            registrarVenta.Conyuge = new Conyuge { IdConyuge = 1, Genero = "Femenino" };
            registrarVenta.VariablesVenta = new List<VariableVenta> { new VariableVenta { IdVariableVenta = 1 } };
            string mensaje = "RV010 Mensaje No Parametrizado";
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositoriologCobis = new Mock<IRepositorioLogCobis>();
            Aplicacion.Cobis.IGestionCobis gestionCobis = null;
            mockRepositorioVenta.Setup(x => x.ObtenerConsecutivo(registrarVenta)).Returns("111421");
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaAsesor(registrarVenta.Asesor)).Returns(false);
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaVenta(registrarVenta)).Returns(new RegistrarVenta { IdVenta = 122, Beneficiario = registrarVenta.Beneficiario, Conyuge = registrarVenta.Conyuge, VariablesVenta = registrarVenta.VariablesVenta });
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaConyugue(registrarVenta.Conyuge)).Returns(true);
            mockRepositorioVenta.Setup(x => x.GuardarVariableVenta(registrarVenta.VariablesVenta[0])).Returns(false);
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositoriologCobis.Object);

            //Act
            resultadoVentaPoliza = gestionVenta.GenerarProcesoFinalDeLaVenta(registrarVenta, gestionCobis);

            //Assert
            Assert.AreEqual(resultadoVentaPoliza.Resultado.Mensaje, mensaje);
        }

        [TestMethod]
        public void GenerarProcesoFinalDeLaVenta_SeIngresaGenerarRecaudoACliente_RetornaErrorTrue()
        {
            ////Arrange
            ResultadoVentaPoliza resultadoVentaPoliza = new ResultadoVentaPoliza();
            RegistrarVenta registrarVenta = new RegistrarVenta();
            Resultado resultado = new Resultado();
            registrarVenta.Cliente = new Cliente { Genero = "Femenino" };
            registrarVenta.Conyuge = new Conyuge { IdConyuge = 1, Genero = "Femenino" };
            registrarVenta.VariablesVenta = new List<VariableVenta> { new VariableVenta { IdVariableVenta = 1 } };
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioLogCobis = new Mock<IRepositorioLogCobis>();
            mockRepositorioVenta.Setup(x => x.ObtenerConsecutivo(registrarVenta)).Returns("111421");
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaAsesor(registrarVenta.Asesor)).Returns(false);
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaVenta(registrarVenta)).Returns(new RegistrarVenta { IdVenta = 122, Beneficiario = registrarVenta.Beneficiario, Conyuge = registrarVenta.Conyuge, VariablesVenta = registrarVenta.VariablesVenta });
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaConyugue(registrarVenta.Conyuge)).Returns(true);
            mockRepositorioVenta.Setup(x => x.GuardarVariableVenta(registrarVenta.VariablesVenta[0])).Returns(true);
            Aplicacion.Cobis.IGestionCobis gestionCobis = new Aplicacion.Cobis.GestionCobis(mockRepositorioLogCobis.Object);
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositorioLogCobis.Object);

            //Act
            resultado = new Resultado { Error = true };

            //Assert
            Assert.IsTrue(resultado.Error);
        }

        [TestMethod]
        public void GenerarProcesoFinalDeLaVenta_SeIngresaGenerarRecaudoACliente_RetornaMensajeError()
        {
            //Arrange
            ResultadoVentaPoliza resultadoVentaPoliza = new ResultadoVentaPoliza();
            RegistrarVenta registrarVenta = new RegistrarVenta();
            Resultado resultado = new Resultado();
            registrarVenta.Cliente = new Cliente { Genero = "Femenino" };
            registrarVenta.Conyuge = new Conyuge { IdConyuge = 1, Genero = "Femenino" };
            registrarVenta.VariablesVenta = new List<VariableVenta> { new VariableVenta { IdVariableVenta = 1 } };
            string mensaje = "0  Mensaje No Parametrizado";
            var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            var mockRepositorioLogCobis = new Mock<IRepositorioLogCobis>();

            mockRepositorioVenta.Setup(x => x.ObtenerConsecutivo(registrarVenta)).Returns("111421");
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaAsesor(registrarVenta.Asesor)).Returns(false);
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaVenta(registrarVenta)).Returns(new RegistrarVenta { IdVenta = 122, Beneficiario = registrarVenta.Beneficiario, Conyuge = registrarVenta.Conyuge, VariablesVenta = registrarVenta.VariablesVenta });
            mockRepositorioVenta.Setup(x => x.GuardarDatosVentaEnTablaConyugue(registrarVenta.Conyuge)).Returns(true);
            mockRepositorioVenta.Setup(x => x.GuardarVariableVenta(registrarVenta.VariablesVenta[0])).Returns(true);
            Aplicacion.Cobis.IGestionCobis gestionCobis = new Aplicacion.Cobis.GestionCobis(mockRepositorioLogCobis.Object);
            GestionVenta gestionVenta = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object, mockRepositorioLogCobis.Object);

            //Act
            resultado = new Resultado { Mensaje = "0  Mensaje No Parametrizado" };

            //Assert
            Assert.AreEqual(resultado.Mensaje, mensaje);
        }
    }
}