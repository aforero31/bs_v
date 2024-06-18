using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BancaSeguros.Aplicacion.Cobis;
using BancaSeguros.Entidades.Venta;

namespace BancaSeguros.Tests.AplicacionTest.CobisTest
{
    [TestClass]
    public class MapearClienteCobisAClienteBancaTests
    {
        [TestMethod]
        public void MapearClienteCobisAClienteBanca_CunadoArrayClienteCobisEsNull_RetornaUnMensaje()
        {
            //Arrange
            Cliente cliente = null;
            Mapeador mapeadorCobisABancaSeguros = new Mapeador();
            global::BancaSeguros.Aplicacion.ServicioCobisCliente.Cliente[] arrayClienteCobis = null;

            //Act
            cliente = mapeadorCobisABancaSeguros.MapearClienteCobisAClienteBanca(arrayClienteCobis,1);

            //Assert
            Assert.IsNotNull(cliente.Resultado.Mensaje);
        }

        //[TestMethod]
        //public void MapearClienteCobisAClienteBanca_CunadoArrayClienteCobisEsNull_RetornaUnMensajeEspecifico()
        //{
        //    //Arrange
        //    string mensajerRetorno = "Cobis no trajo información del cliente";
        //    Cliente cliente = null;
        //    Mapeador mapeadorCobisABancaSeguros = new Mapeador();
        //    global::BancaSeguros.Aplicacion.ServicioCobisCliente.Cliente[] arrayClienteCobis = null;

        //    //Act
        //    cliente = mapeadorCobisABancaSeguros.MapearClienteCobisAClienteBanca(arrayClienteCobis,1);

        //    //Assert
        //    Assert.AreEqual(mensajerRetorno, cliente.Resultado.Mensaje);
        //}
    }
}
