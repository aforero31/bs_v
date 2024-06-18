//-----------------------------------------------------------------------
// <copyright file="IRepositorioPermiso.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BancaSeguros.Repositorio.Seguridad
{
    using BAC.EntidadesSeguridad;
    using BancaSeguros.Entidades.General;

    /// <summary>
    /// Permissions repository
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 25/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IRepositorioPermiso
    {
        /// <summary>
        /// Inserts permission.
        /// </summary>
        /// <param name="permiso">The permission.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 25/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        BancaSeguros.Entidades.General.Resultado InsertarPermiso(Permisos permiso);

        /// <summary>
        /// Delete permission.
        /// </summary>
        /// <param name="permiso">The permission.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 25/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        BancaSeguros.Entidades.General.Resultado EliminarPermiso(Permisos permiso);
    }
}
