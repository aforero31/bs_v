//-----------------------------------------------------------------------
// <copyright file="GestionGrupoBAC.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BAC.Seguridad.Seguridad
{
    using System.Collections.Generic;
    using BAC.EntidadesSeguridad;
    using BancaSeguros.Repositorio.Seguridad;

    /// <summary>
    /// Group Management class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 27/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="BAC.Seguridad.Seguridad.IGestionGrupoBAC" />
    public class GestionGrupoBAC : IGestionGrupoBAC
    {
        #region Variables

        /// <summary>
        /// The group repository
        /// </summary>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private IRepositorioGrupoBAC repositorioGrupo;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GestionGrupoBAC"/> class.
        /// </summary>
        /// <param name="repositorio">The repository.</param>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public GestionGrupoBAC(IRepositorioGrupoBAC repositorio)
        {
            this.repositorioGrupo = repositorio;
        }        
        #endregion

        /// <summary>
        /// Search the groups.
        /// </summary>
        /// <param name="grupo">The group.</param>
        /// <returns>List of groups</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<GrupoBAC> ConsultarGruposBAC(GrupoBAC grupo)
        {
            return this.repositorioGrupo.ConsultarGruposBAC(grupo);
        }

        /// <summary>
        /// Search the group by role.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>List of Groups</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 27/04/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        public IList<GrupoBAC> ConsultarGrupoPorRol(Rol rol)
        {
            return this.repositorioGrupo.ConsultarGrupoPorRol(rol);
        }
    }
}
