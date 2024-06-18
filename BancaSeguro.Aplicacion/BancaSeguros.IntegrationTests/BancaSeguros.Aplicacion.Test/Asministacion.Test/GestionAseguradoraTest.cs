//-----------------------------------------------------------------------
// <copyright file="GestionAseguradoraTest.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.IntegrationTests.AplicacionTest.AdministracionTest
{
    using Aplicacion.Administracion;
    using Repositorio.Administracion;
    using BancaSeguros.Repositorio.Seguridad;
    using Entidades.Seguro;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// class Test Insurance
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 18/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [TestClass]
    public class GestionAseguradoraTest
    {
        /// <summary>
        /// Inserts the insurance test.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        //[TestMethod]
        public void InsertaAseguradoraTest()
        {
            Aseguradora aseguradora = new Aseguradora();
            aseguradora.CodigoSuperintendencia = "00222244";
            IRepositorioAseguradora repositorioAseguradora = new RepositorioAseguradora("CONEXION_BANCASEGURO");
            IGestionAseguradora gestion = new GestionAseguradora(repositorioAseguradora);
            Assert.AreEqual(gestion.InsertarAseguradora(aseguradora).Error, false);
        }

        /// <summary>
        /// Search the insurance by identifier test.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 18/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        //[TestMethod]
        public void ConsultarAseguradoraPorIdTest()
        {
            int idAseguradora = 1;
            IRepositorioAseguradora repositorioAseguradora = new RepositorioAseguradora("CONEXION_BANCASEGURO");
            IGestionAseguradora gestion = new GestionAseguradora(repositorioAseguradora);
            Assert.AreEqual(gestion.ConsultarAseguradoraPorId(idAseguradora).IdAseguradora, idAseguradora);
        }
    }
}
