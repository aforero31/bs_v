//-----------------------------------------------------------------------
// <copyright file="IRepositorioRol.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Seguridad
{
    using System;
    using System.Collections.Generic;
    using BAC.EntidadesSeguridad;

    /// <summary>
    /// Interface Role repository
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 26/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IRepositorioRol
    {
        /// <summary>
        /// Inserts the role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        BancaSeguros.Entidades.General.Resultado InsertarRol(Rol rol);

        /// <summary>
        /// Update the role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>Result Object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        BancaSeguros.Entidades.General.Resultado ActualizarRol(Rol rol);

        /// <summary>
        /// Get the roles.
        /// </summary>
        /// <param name="nombre">The name.</param>
        /// <param name="estado">The estate.</param>
        /// <returns>List of Roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<Rol> ObtenerRoles(string nombre, string estado);

        /// <summary>
        /// Search the role by group.
        /// </summary>
        /// <param name="autenticarUsuario">The user authentication.</param>
        /// <returns>User Authentication</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 26/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        AutenticacionUsuario ConsultarRolPorGrupo(AutenticacionUsuario autenticarUsuario);
    }
}
