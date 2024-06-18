using BancaSegurosUI.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancaSegurosUI.seguridad
{
    public partial class AdministracionControlDual : System.Web.UI.Page
    {
        /// <summary>
        /// Search the items of menu for fill the Combo.
        /// </summary>
        /// <param name="rol">The menu.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 10/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<BAC.EntidadesSeguridad.Menu> ConsultarMenuControlDual()
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ConsultarMenuControlDual();
        }

        /// <summary>
        /// Search the items of rol for fill the Grid.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 13/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> ConsultarAdmonControlDual()
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ConsultarAdmonControlDual();
        }

        /// <summary>
        /// Insert the registry for Control Dual
        /// </summary>
        /// <param name="controlDual">The Control Dual Entity</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 14/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static BancaSeguros.Entidades.General.Resultado InsertarAdmonControlDual(List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> controlDual)
        {
            return AdministradorProxy.ObtenerClienteSeguridad().InsertarAdmonControlDual(controlDual);
        }

        /// <summary>
        /// Search the items of rol for fill the Grid.
        /// </summary>
        /// <param name="rol">The role.</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 15/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> ConsultarAdmonControlDualIdMenu(int idMenu)
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ConsultarAdmonControlDualIdMenu(idMenu);
        }

        /// <summary>
        /// Update the registry for Control Dual
        /// </summary>
        /// <param name="controlDual">The Control Dual Entity</param>
        /// <returns>Result object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 15/06/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static BancaSeguros.Entidades.General.Resultado ActualizarAdmonControlDual(List<BancaSeguros.Entidades.Seguridad.AdministracionControlDual> controlDual)
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ActualizarAdmonControlDual(controlDual);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}