//-----------------------------------------------------------------------
// <copyright file="GestionSeguridadTest.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using BAC.EntidadesSeguridad;
using BAC.Seguridad.Seguridad;
using BancaSeguros.Repositorio.Seguridad;
using BancaSeguros.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BancaSeguros.IntegrationTests.BAC.Seguridad.Test.Seguridad.Test
{
    /// <summary>
    /// Security Management Test Class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 28/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [TestClass]
    public class GestionSeguridadTest
    {
        /// <summary>
        /// Inserts the role test.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 28/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        //[TestMethod]
        public void ObtenerFuncionesMenuTest()
        {
            IRepositorioRol repositorioRol = new RepositorioRol("CONEXION_BANCASEGURO");
            IRepositorioMenu repositorioMenu = new RepositorioMenu("CONEXION_BANCASEGURO");
            IRepositorioOficina repositorioUsuarios = new RepositorioOficina("CONEXION_BANCASEGURO");
            IRepositorioPermiso repositorioPermiso = new RepositorioPermiso("CONEXION_BANCASEGURO");
            IRepositorioGrupoBAC repositorioGrupoBAC = new RepositorioGrupoBAC("CONEXION_BANCASEGURO");
            IRepositorioAdmonControlDual repositorioAdmonControlDual = new RepositorioAdmonControlDual("CONEXION_BANCASEGURO");

            IGestionSeguridad gestion = new GestionSeguridad(
                repositorioRol,
                repositorioUsuarios,
                repositorioMenu,
                repositorioPermiso,
                repositorioGrupoBAC,
                repositorioAdmonControlDual);
            gestion.ObtenerFuncionesMenu();
            Assert.AreEqual(gestion.ObtenerFuncionesMenu().Count > 0, true);
        }
    }
}
