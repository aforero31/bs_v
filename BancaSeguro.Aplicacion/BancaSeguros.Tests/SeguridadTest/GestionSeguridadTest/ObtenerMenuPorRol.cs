//-----------------------------------------------------------------------
// <copyright file="ObtenerMenuPorRol.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Tests.SeguridadTest.GestionSeguridadTest
{
    using System.Collections.Generic;
    using BAC.EntidadesSeguridad;
    using BAC.Seguridad.Seguridad;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Repositorio.Seguridad;

    /// <summary>
    /// Unit Test
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\WZALDUA
    /// CreationDate: 21/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    [TestClass]
    public class ObtenerMenuPorRol
    {
        /// <summary>
        /// Get the menu of role list role is null return list menu initialize.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [TestMethod]
        public void ObtenerMenuPorRol_ListaRolesEsNull_RetornaListaMenuInicializada()
        {
            ////Arrange
            List<Rol> rol = null;
            var mockRepositorioRol = new Mock<IRepositorioRol>();
            var mockRepositorioUsuarios = new Mock<IRepositorioOficina>();
            var mockRepositorioMenu = new Mock<IRepositorioMenu>();
            var mockRepositorioPermiso = new Mock<IRepositorioPermiso>();
            var mockRepositorioGrupoBAC = new Mock<IRepositorioGrupoBAC>();
            var mockRepositorioAdmonControlDual = new Mock<IRepositorioAdmonControlDual>();

            GestionSeguridad gestionSeguridad = new GestionSeguridad(mockRepositorioRol.Object, mockRepositorioUsuarios.Object, mockRepositorioMenu.Object, mockRepositorioPermiso.Object, mockRepositorioGrupoBAC.Object, mockRepositorioAdmonControlDual.Object);

            //Act
            var resultado = gestionSeguridad.ObtenerMenuPorRol(rol);

            //Assert
            Assert.AreEqual(0, resultado.Count);
        }

        /// <summary>
        /// Get the menu of role with role in list return list with two items delete menu.
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\WZALDUA
        /// CreationDate: 21/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [TestMethod]
        public void ObtenerMenuPorRol_ConUnRolEnLista_RetornaListaConDosItemsDelMenu()
        {
            ////Arrange
            List<Rol> roles = new List<Rol>();
            Rol rol = new Rol();
            rol.IdRol = 1;
            roles.Add(rol);
            var mockRepositorioRol = new Mock<IRepositorioRol>();
            var mockRepositorioUsuarios = new Mock<IRepositorioOficina>();
            var mockRepositorioMenu = new Mock<IRepositorioMenu>();
            var mockRepositorioPermiso = new Mock<IRepositorioPermiso>();
            var mockRepositorioGrupoBAC = new Mock<IRepositorioGrupoBAC>();
            var mockRepositorioAdmonControlDual = new Mock<IRepositorioAdmonControlDual>();

            mockRepositorioMenu.Setup(x => x.ObtenerMenuPorRol(1)).Returns(new List<Menu>() { new Menu() { IdMenu = 1 }, new Menu() { IdMenu = 2 } });

            GestionSeguridad gestionSeguridad = new GestionSeguridad(mockRepositorioRol.Object, mockRepositorioUsuarios.Object, mockRepositorioMenu.Object, mockRepositorioPermiso.Object, mockRepositorioGrupoBAC.Object, mockRepositorioAdmonControlDual.Object);

            //Act
            var resultado = gestionSeguridad.ObtenerMenuPorRol(roles);

            //Assert
            Assert.AreEqual(2, resultado.Count);
        }
    }
}
