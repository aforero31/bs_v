namespace BancaSeguros.Tests.AplicacionTest.SincronizacionTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BancaSeguros.Entidades.Catalogo;
    using System.Collections.Generic;
    using BancaSeguros.Aplicacion.Sincronizacion;
    using Moq;

    [TestClass]
    public class LlenarDiasAVerificarTests
    {
        [TestMethod]
        public void LlenarDiasAVerificar_SeEnviaFechaHoyYDiasAContarEnCero_DevuelveUnArrayConLaFecha()
        {
            //arrange            
            List<DiaHabil> diasHabiles = new List<DiaHabil>();
            DateTime fechaControl = DateTime.Now;
            var mockRepositorioDiaHabil = new Mock<BancaSeguros.Repositorio.Administracion.IRepositorioDiaHabil>();
            var mockRepositorioSincronizacion = new Mock<BancaSeguros.Repositorio.Sincronizacion.IRepositorioSincronizacion>();
            var mockGestionTransaccion = new Mock<BancaSeguros.Aplicacion.Cobis.IGestionTransaccion>();
            var mockGestionCatalogos = new Mock<BancaSeguros.Aplicacion.Cobis.IGestionCatalogos>();
            //mockGestionTransaccion.Setup(x => x.ConsultarDiaHabil(DateTime.Now)).Returns(true);
            GestionSincronizacion gestionSincronizacion = new GestionSincronizacion(mockRepositorioDiaHabil.Object, mockRepositorioSincronizacion.Object, mockGestionTransaccion.Object, mockGestionCatalogos.Object);
            //act
            PrivateObject obj = new PrivateObject(gestionSincronizacion);
            diasHabiles = (List<DiaHabil>)obj.Invoke("LlenarDiasAVerificar", fechaControl, 5);

            //Assert
            Assert.AreEqual(5, diasHabiles.Count);
        }
    }
}
