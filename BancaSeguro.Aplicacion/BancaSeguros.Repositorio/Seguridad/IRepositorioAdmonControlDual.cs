using System;
using System.Collections.Generic;
using BAC.EntidadesSeguridad;

namespace BancaSeguros.Repositorio.Seguridad
{
    public interface IRepositorioAdmonControlDual
    {
        /// <summary>
        /// Search the items of menu.
        /// </summary>
        /// <param name="">The menu.</param>
        /// <returns>List of menu</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<Menu> ConsultarMenuControlDual();

        /// <summary>
        /// Search the roles.
        /// </summary>
        /// <param name="">The rol.</param>
        /// <returns>List of roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> ConsultarAdmonControlDual();

         /// <summary>
        /// Search the roles.
        /// </summary>
        /// <param name="">The rol.</param>
        /// <returns>List of roles</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> ConsultarAdmonControlDualIdMenu(int idMenu);

        /// <summary>
        /// Insert the registry of ControlDual.
        /// </summary>
        /// <param name="controlDual">The control Dual Entity</param>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Entidades.General.Resultado InsertarAdmonControlDual(List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> controlDual);

        /// <summary>
        /// Update the registry of ControlDual.
        /// </summary>
        /// <param name="controlDual">The control Dual Entity</param>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        ///  CreationDate: 15/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        Entidades.General.Resultado ActualizarAdmonControlDual(List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> controlDual);



    }
}
