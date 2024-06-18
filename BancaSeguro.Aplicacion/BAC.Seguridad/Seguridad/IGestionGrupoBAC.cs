//-----------------------------------------------------------------------
// <copyright file="IGestionGrupoBAC.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BAC.Seguridad.Seguridad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BAC.EntidadesSeguridad;

    /// <summary>
    /// Group Management Interface
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 27/04/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    public interface IGestionGrupoBAC
    {
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
        IList<GrupoBAC> ConsultarGruposBAC(GrupoBAC grupo);

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
        IList<GrupoBAC> ConsultarGrupoPorRol(Rol rol);
    }
}
