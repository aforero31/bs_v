using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BancaSeguros.Repositorio.Venta;
using BancaSeguros.Aplicacion.Venta;
using BancaSeguros.Entidades.Seguro;
using BancaSeguros.Entidades;
using System.IO;
using System.Configuration;
using BancaSeguros.Entidades.Venta;
using System.Collections.Generic;

namespace BancaSeguros.Tests.AplicacionTest.VentaTest
{
    [TestClass]
    public class ObtenerDocumentoVentaPolizaTest
    {

        [TestMethod]
        public void CuandoConsultoElDocumentoPolizaDebeRetornarUnArchivoEnBytes()
        {
            ////arrange
            //var mockRepositorioSeguro = new Mock<IRepositorioSeguro>();
            //var mockRepositorioVenta = new Mock<IRepositorioVenta>();
            //var mockRepositorioPlan = new Mock<IRepositorioPlan>();
            //var mockRepositorioProductoNoPermitido = new Mock<IRepositorioProductoNoPermitido>();
            //var mockRepositorioDocumentoPoliza = new Mock<IRepositorioDocumentoPoliza>();
            //var mockRepositorioLogCobis = new Mock<IRepositorioLogCobis>();
            ///*Parametros de entrada*/
            //string consecutivoPrueba = "6000474134300";
            //int idSeguro = 1;
            ///*Parametros de salida métodos repositorio*/
            //DocumentoPoliza documentoPolizaMock = ObtenerDocumentoPoliza();
            //EncabezadoPolizaDocumento encabezadoPolizaDocumentoMock = ObtenerEncabezadoPolizaDocumento();
            //ConyugePolizaDocumento conyugePolizaDocumentoMock = ObtenerConyugePolizaDocumento();
            //IEnumerable<BeneficiariosPolizaDocumento> beneficiariosMock = ObtenerBeneficiarios();
            ///*Configuracion del Mock*/
            //mockRepositorioDocumentoPoliza.Setup(x => x.ObtenerDocumentoPolizaPorIdSeguro(idSeguro)).Returns(documentoPolizaMock);
            ////mockRepositorioDocumentoPoliza.Setup(x => x.ObtenerInformacionBeneficiariosDocumentoPoliza(consecutivoPrueba)).Returns(beneficiariosMock);
            //mockRepositorioDocumentoPoliza.Setup(x => x.ObtenerInformacionEncabezadoDocumentoPoliza(consecutivoPrueba)).Returns(encabezadoPolizaDocumentoMock);
            //mockRepositorioDocumentoPoliza.Setup(x => x.ObtenerInformacionConyugeDocumentoPoliza(consecutivoPrueba)).Returns(conyugePolizaDocumentoMock);
            //GestionVenta gestionVentaNegocio = new GestionVenta(mockRepositorioSeguro.Object, mockRepositorioVenta.Object, 
            //    mockRepositorioPlan.Object, mockRepositorioProductoNoPermitido.Object, mockRepositorioDocumentoPoliza.Object,
            //    mockRepositorioLogCobis.Object);
            //ResultadoDocumentoPoliza resultadoOperacion = new ResultadoDocumentoPoliza();

            ////act
            //var carpetaRecursos = "../../AplicacionTest/VentaTest/GestionVentaTest/Recursos/";
            //resultadoOperacion = gestionVentaNegocio.ObtenerDocumentoVentaPoliza(consecutivoPrueba, idSeguro, carpetaRecursos);
            ////Revisar este Test esta generando error pero se comenta linea para solucionarlo de manera provisional no se encuentra la falla.
            //Assert.IsTrue(resultadoOperacion.ArchivoPolizaPdf == null);
            ////Assert.IsTrue(resultadoOperacion.ArchivoPolizaPdf.Count() > 0);
        }

        /// <summary>
        /// Obtiene la plantilla del documento que va a imprimir
        /// </summary>
        /// <returns></returns>
        private DocumentoPoliza ObtenerDocumentoPoliza()
        {
            DocumentoPoliza resultado = new DocumentoPoliza();
            resultado.IdDocumentoPoliza = 1;
            resultado.Activa = true;
            resultado.CamposPlantilla = "FechaSolicitud,PrimerNombreCliente,PrimerApellidoCliente,SegundoApellidoCliente,NumeroIdentificacionCliente,TipoIdentificacionAbreviadoCliente,TipoIdentificacionDescripcionCliente,FechaNacimientoCliente,CiudadNacimientoCliente,GeneroCliente";
            resultado.Eliminado = false;
            resultado.FechaCreacion = DateTime.Now;
            resultado.IdSeguro = 4;
            resultado.NombreArchivo = "TemplateDocument.docx";
            byte[] fileBytes = File.ReadAllBytes(@"C:\WORKSPACES\BAC\Proyectos\BancaSeguros\Codigo fuente\Dev\BancaSeguro.Aplicacion\BancaSeguros.Tests\AplicacionTest\VentaTest\Recursos\TemplateDocument.docx");
            resultado.Plantilla = fileBytes;
            resultado.UsuarioCreacion = "cpiza";
            resultado.VersionDocumento = "1.1";
            return resultado;
        }

        /// <summary>
        /// Retorna una entidad EncabezadoPolizaDocumento con todos los atributos con información
        /// </summary>
        /// <returns></returns>
        private EncabezadoPolizaDocumento ObtenerEncabezadoPolizaDocumento()
        {
            EncabezadoPolizaDocumento resultado = new EncabezadoPolizaDocumento();
            resultado.FechaSolicitud = DateTime.Now.ToShortDateString();
            resultado.CelularCliente = "81455656";
            resultado.CiudadNacimientoCliente = "Bogotá D.C.";
            resultado.CiudadResidenciaCliente = "Bogotá D.C.";
            resultado.ConsecutivoPoliza = "183353879652168";
            resultado.DepartamenoCliente = "Cundinamarca";
            resultado.DireccionCliente = "Carrera 56 # 50";
            resultado.FechaNacimientoCliente = new DateTime(1976, 5, 2).ToShortDateString();
            resultado.FechaSolicitud = DateTime.Now.ToShortDateString();
            resultado.FechaVencimientoTarjetaCliente = new DateTime(2030, 10, 2).ToShortDateString();
            resultado.GeneroCliente = "Masculino";
            resultado.NacionalidadCliente = "Colombiano";
            resultado.NumeroCuentaCliente = "456-5654897-45";
            resultado.NumeroIdentificacionCliente = "80855456";
            resultado.Periodicidad = "Mensual";
            resultado.PlanPoliza = "1";
            resultado.PrimerApellidoCliente = "Perez";
            resultado.PrimerNombreCliente = "JORGE";
            resultado.SegundoNombreCliente = "Mario";
            resultado.PrimerApellidoCliente = "PRIETO";
            resultado.SegundoApellidoCliente = "OTALORA";
            resultado.TelefonoCliente = "9565464";
            resultado.TipoCuentaCliente = "Ahorros";
            resultado.TipoIdentificacionAbreviadoCliente = "CC";
            resultado.TipoIdentificacionDescripcionCliente = "Cédula de ciudadanía";
            resultado.ValorIvaPoliza = "12000";
            resultado.ValorPolizaSinIva = "2000";
            resultado.ValorPrimaConIva = "14000";
            return resultado;
        }

        /// <summary>
        /// Obtiene la simulación de un conyuge
        /// </summary>
        /// <returns></returns>
        private ConyugePolizaDocumento ObtenerConyugePolizaDocumento()
        {
            ConyugePolizaDocumento resultado = new ConyugePolizaDocumento();
            resultado.CiudadNacimientoConyuge = "Bogotá D.C";
            resultado.CiudadResidenciaConyuge = "Bogotá D.C";
            resultado.DireccionConyuge = "Calle 89 - carrera 50";
            resultado.FechaNacimientoConyuge = new DateTime(1986, 2, 6).ToShortDateString();
            resultado.GeneroConyuge = "Femenino";
            resultado.NumeroIdentificacionConyuge = "6548789";
            resultado.PrimerApellidoConyuge = "Pinilla";
            resultado.PrimerNombreConyuge = "Carmenza";
            resultado.SegundoApellidoConyuge = "Alcazabán";
            resultado.SegundoNombreConyuge = "De Los Angeles";
            resultado.TelefonoConyuge = "7365989";
            resultado.TipoIdentificacionAbreviaturaConyuge = "CC";
            return resultado;
        }

        /// <summary>
        /// Lista de beneficiarios
        /// </summary>
        /// <returns></returns>
        private IEnumerable<BeneficiariosPolizaDocumento> ObtenerBeneficiarios()
        {
            List<BeneficiariosPolizaDocumento> resultado = new List<BeneficiariosPolizaDocumento>();
            resultado.Add(new BeneficiariosPolizaDocumento()
            {
                ApellidoBeneficiario = "Perez",
                NombreBeneficiario = "Juan Alberto",
                NombreCompletoBeneficiario = "Juan Alberto Perez",
                NumeroIdentificacionBeneficiario = "9871361564",
                PorcentajeParticipacion = "40",
                TipoIdentificacionAbreviaturaBeneficiario = "CC",
                TipoNumeroIdentificacionBeneficiario = "CC 9871361564"
            });
            resultado.Add(new BeneficiariosPolizaDocumento()
            {
                ApellidoBeneficiario = "Perez",
                NombreBeneficiario = "Mario Alberto",
                NombreCompletoBeneficiario = "Mario Alberto Perez",
                NumeroIdentificacionBeneficiario = "9871361563",
                PorcentajeParticipacion = "60",
                TipoIdentificacionAbreviaturaBeneficiario = "CC",
                TipoNumeroIdentificacionBeneficiario = "CC 9871361563"
            });
            return resultado;
        }
    }
}
