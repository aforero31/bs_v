
namespace BancaSeguros.Tests.AplicacionTest.SincronizacionTest
{
    using Aplicacion.Sincronizacion;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Data;
    using System;

    [TestClass]
    public class SincronizarCatalogosTests
    {
        //[TestMethod]
        public void SincronizarCatalogos_AlGenerarseAlgunErrorEnelProceso_RetornaErrorFalse()
        {
            //arrange            
            var mockRepositorioDiaHabil = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioDiaHabil>();
            var mockRepositorioSincronizacion = new Mock<BancaSeguros.Repositorio.Sincronizacion.IRepositorioSincronizacion>();
            var mockGestionTransaccion = new Mock<BancaSeguros.Aplicacion.Cobis.IGestionTransaccion>();
            var mockGestionCatalogos = new Mock<BancaSeguros.Aplicacion.Cobis.IGestionCatalogos>();            
            mockGestionCatalogos.Setup(x => x.ConsultarCatalogo("cl_tipo_documento")).Throws(new Exception());
            GestionSincronizacion gestionSincronizacion = new GestionSincronizacion(mockRepositorioDiaHabil.Object, mockRepositorioSincronizacion.Object, mockGestionTransaccion.Object, mockGestionCatalogos.Object);

            //act
            var resultado = gestionSincronizacion.SincronizarCatalogos();

            //Assert
            Assert.IsFalse(resultado.Error);
        }

        [TestMethod]
        public void SincronizarCatalogos_AlGenerarseAlgunErrorEnelProceso_RetornaMensajeDeError()
        {
            //arrange            
            var mockRepositorioDiaHabil = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioDiaHabil>();
            var mockRepositorioSincronizacion = new Mock<BancaSeguros.Repositorio.Sincronizacion.IRepositorioSincronizacion>();
            var mockGestionTransaccion = new Mock<BancaSeguros.Aplicacion.Cobis.IGestionTransaccion>();
            var mockGestionCatalogos = new Mock<BancaSeguros.Aplicacion.Cobis.IGestionCatalogos>();
            mockGestionCatalogos.Setup(x => x.ConsultarCatalogo("cl_tipo_documento")).Throws(new Exception());
            GestionSincronizacion gestionSincronizacion = new GestionSincronizacion(mockRepositorioDiaHabil.Object, mockRepositorioSincronizacion.Object, mockGestionTransaccion.Object, mockGestionCatalogos.Object);

            //act
            var resultado = gestionSincronizacion.SincronizarCatalogos();

            //Assert
            Assert.IsTrue(!string.IsNullOrEmpty(resultado.Mensaje));
        }
               
        //[TestMethod]
        public void SincronizarCatalogos_SincronizaTablaBasicaPeriodicidadElRestoNO_RetornaMensajeError()
        {
            //arrange            
            var mockRepositorioDiaHabil = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioDiaHabil>();
            var mockRepositorioSincronizacion = new Mock<BancaSeguros.Repositorio.Sincronizacion.IRepositorioSincronizacion>();
            var mockGestionTransaccion = new Mock<BancaSeguros.Aplicacion.Cobis.IGestionTransaccion>();
            var mockGestionCatalogos = new Mock<BancaSeguros.Aplicacion.Cobis.IGestionCatalogos>();
            string fechaHoy = DateTime.Today.ToString("dd/MM/yyyy");
            string mensajeEsperado = "Sincronización Dias Habiles: Hoy " + fechaHoy + " mas los dias de anticipo 0 es igual al 30/10/2016 la cual no es la fecha control 01/01/0001" + 
                "Sincronización Catalogos: Sin datos en la consulta a Cobis cl_tipo_documento Sin datos en la consulta a Cobis cl_parentesco Sin datos en la consulta a Cobis cc_sub_banc_cte Sin datos en la consulta a Cobis cc_categoria ";

            mockGestionCatalogos.Setup(x => x.ConsultarCatalogo("ec_periodicidad")).Returns(
                 new Entidades.Catalogo.DtoCatalogo
                 {
                     Resultado = new Entidades.General.Resultado
                     {
                         Error = false
                     },
                     ListPeriodicidad = new System.Collections.Generic.List<Entidades.Catalogo.Periodicidad>
                     {
                        new Entidades.Catalogo.Periodicidad
                        {
                            Nombre = "ANUAL"
                        }
                     }
                 });

            GestionSincronizacion gestionSincronizacion = new GestionSincronizacion(mockRepositorioDiaHabil.Object, mockRepositorioSincronizacion.Object, mockGestionTransaccion.Object, mockGestionCatalogos.Object);

            //act
            var resultado = gestionSincronizacion.SincronizarCatalogos();

            //Assert
            Assert.AreEqual(mensajeEsperado.Contains("Sincronización Dias Habiles"), resultado.Mensaje.Contains("Sincronización Dias Habiles"));
        }

        [TestMethod]
        public void SincronizarCatalogos_SincronizaTablaBasicaParentescoElRestoNO_RetornaErrorTrue()
        {
            //arrange            
            var mockRepositorioDiaHabil = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioDiaHabil>();
            var mockRepositorioSincronizacion = new Mock<BancaSeguros.Repositorio.Sincronizacion.IRepositorioSincronizacion>();
            var mockGestionTransaccion = new Mock<BancaSeguros.Aplicacion.Cobis.IGestionTransaccion>();
            var mockGestionCatalogos = new Mock<BancaSeguros.Aplicacion.Cobis.IGestionCatalogos>();

            mockGestionCatalogos.Setup(x => x.ConsultarCatalogo("cl_parentesco")).Returns(
                  new Entidades.Catalogo.DtoCatalogo
                  {
                      Resultado = new Entidades.General.Resultado
                      {
                          Error = false
                      },
                      ListParentesco = new System.Collections.Generic.List<Entidades.Catalogo.Parentesco>
                      {
                        new Entidades.Catalogo.Parentesco
                        {
                            Nombre = "TIO"
                        }
                      }
                  });

            mockGestionCatalogos.Setup(x => x.ConsultarCatalogo("cl_tipo_documento")).Throws(new Exception());
            GestionSincronizacion gestionSincronizacion = new GestionSincronizacion(mockRepositorioDiaHabil.Object, mockRepositorioSincronizacion.Object, mockGestionTransaccion.Object, mockGestionCatalogos.Object);

            //act
            var resultado = gestionSincronizacion.SincronizarCatalogos();

            //Assert
            Assert.IsTrue(resultado.Error);
        }

        //[TestMethod]
        public void SincronizarCatalogos_SincronizaTablaBasicaParentescoElRestoNO_RetornaMensajeError()
        {
            //arrange            
            var mockRepositorioDiaHabil = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioDiaHabil>();
            var mockRepositorioSincronizacion = new Mock<BancaSeguros.Repositorio.Sincronizacion.IRepositorioSincronizacion>();
            var mockGestionTransaccion = new Mock<BancaSeguros.Aplicacion.Cobis.IGestionTransaccion>();
            var mockGestionCatalogos = new Mock<BancaSeguros.Aplicacion.Cobis.IGestionCatalogos>();
            string fechaHoy = DateTime.Today.ToString("dd/MM/yyyy");
            string mensajeEsperado = "Sincronización Dias Habiles: Hoy " + fechaHoy + " mas los dias de anticipo 0 es igual al 30/10/2016 la cual no es la fecha control 01/01/0001" + 
                "Sincronización Catalogos: Sin datos en la consulta a Cobis cl_tipo_documento Sin datos en la consulta a Cobis cc_sub_banc_cte Sin datos en la consulta a Cobis cc_categoria ";

            mockGestionCatalogos.Setup(x => x.ConsultarCatalogo("cl_parentesco")).Returns(
                 new Entidades.Catalogo.DtoCatalogo
                 {
                     Resultado = new Entidades.General.Resultado
                     {
                         Error = false
                     },
                     ListParentesco = new System.Collections.Generic.List<Entidades.Catalogo.Parentesco>
                     {
                        new Entidades.Catalogo.Parentesco
                        {
                            Nombre = "TIO"
                        }
                     }
                 });

            GestionSincronizacion gestionSincronizacion = new GestionSincronizacion(mockRepositorioDiaHabil.Object, mockRepositorioSincronizacion.Object, mockGestionTransaccion.Object, mockGestionCatalogos.Object);

            //act
            var resultado = gestionSincronizacion.SincronizarCatalogos();

            //Assert
            Assert.AreEqual(mensajeEsperado.Contains("Sincronización Dias Habiles"), resultado.Mensaje.Contains("Sincronización Dias Habiles"));
        }

        [TestMethod]
        public void SincronizarCatalogos_SincronizaTablaBasicaCategoriaElRestoNO_RetornaErrorTrue()
        {
            //arrange            
            var mockRepositorioDiaHabil = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioDiaHabil>();
            var mockRepositorioSincronizacion = new Mock<BancaSeguros.Repositorio.Sincronizacion.IRepositorioSincronizacion>();
            var mockGestionTransaccion = new Mock<BancaSeguros.Aplicacion.Cobis.IGestionTransaccion>();
            var mockGestionCatalogos = new Mock<BancaSeguros.Aplicacion.Cobis.IGestionCatalogos>();

            mockGestionCatalogos.Setup(x => x.ConsultarCatalogo("pe_categoria")).Returns(
                new Entidades.Catalogo.DtoCatalogo
                {
                    Resultado = new Entidades.General.Resultado
                    {
                        Error = false
                    },
                    TablaCategoria = new System.Collections.Generic.List<Entidades.Catalogo.Categoria>
                    {
                        new Entidades.Catalogo.Categoria
                        {
                            Nombre = "Ahorros"
                        }
                    }
                });

            mockGestionCatalogos.Setup(x => x.ConsultarCatalogo("cl_tipo_documento")).Throws(new Exception());
            GestionSincronizacion gestionSincronizacion = new GestionSincronizacion(mockRepositorioDiaHabil.Object, mockRepositorioSincronizacion.Object, mockGestionTransaccion.Object, mockGestionCatalogos.Object);

            //act
            var resultado = gestionSincronizacion.SincronizarCatalogos();

            //Assert
            Assert.IsTrue(resultado.Error);
        }

        //[TestMethod]
        public void SincronizarCatalogos_SincronizaTablaBasicaCategoriaElRestoNO_RetornaMensajeError()
        {
            //arrange            
            var mockRepositorioDiaHabil = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioDiaHabil>();
            var mockRepositorioSincronizacion = new Mock<BancaSeguros.Repositorio.Sincronizacion.IRepositorioSincronizacion>();
            var mockGestionTransaccion = new Mock<BancaSeguros.Aplicacion.Cobis.IGestionTransaccion>();
            var mockGestionCatalogos = new Mock<BancaSeguros.Aplicacion.Cobis.IGestionCatalogos>();
            string fechaHoy = DateTime.Today.ToString("dd/MM/yyyy");
            string mensajeEsperado = "Sincronización Dias Habiles: Hoy " + fechaHoy + " mas los dias de anticipo 0 es igual al 30/10/2016 la cual no es la fecha control 01/01/0001" + 
                "Sincronización Catalogos: Sin datos en la consulta a Cobis cl_tipo_documento Sin datos en la consulta a Cobis cl_parentesco Sin datos en la consulta a Cobis cc_sub_banc_cte Sin datos en la consulta a Cobis cc_categoria ";

            mockGestionCatalogos.Setup(x => x.ConsultarCatalogo("pe_categoria")).Returns(
                 new Entidades.Catalogo.DtoCatalogo
                 {
                     Resultado = new Entidades.General.Resultado
                     {
                         Error = false
                     },
                     TablaCategoria = new System.Collections.Generic.List<Entidades.Catalogo.Categoria>
                     {
                        new Entidades.Catalogo.Categoria
                        {
                            Nombre = "Ahorros"
                        }
                     }
                 });

            //mockGestionCatalogos.Setup(x => x.ConsultarCatalogo("cl_tipo_documento")).Throws(new Exception());
            GestionSincronizacion gestionSincronizacion = new GestionSincronizacion(mockRepositorioDiaHabil.Object, mockRepositorioSincronizacion.Object, mockGestionTransaccion.Object, mockGestionCatalogos.Object);

            //act
            var resultado = gestionSincronizacion.SincronizarCatalogos();

            //Assert
            Assert.AreEqual(mensajeEsperado.Contains("Sincronización Dias Habiles"), resultado.Mensaje.Contains("Sincronización Dias Habiles"));
        }
    }
}
