

namespace BancaSegurosUI.Administracion
{
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSegurosUI.App_Code;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Script.Services;
    using System.Web.Services;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// CodeBehind Page Load
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\LCOMBARIZA
    /// CreationDate: 26/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class ParametrizarCausalNovedad : System.Web.UI.Page
    {
        /// <summary>
        /// Obtain the Catalog.
        /// </summary>
        /// <returns>The Catalog</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 26/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>

        #region Catalogos

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static DtoCatalogo ConsultarCatalogo(string NombreTabla)
        {
            return AdministradorProxy.ObtenerClienteGenerico().ConsultarCatalogo(NombreTabla);
        }

        #endregion

        /// <summary>
        /// Save the Causal Novelty.
        /// </summary>
        /// <returns>The Causal Novelty</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado InsertarCausalNovedad(CausalNovedad causalNovedad)
        {
            if(!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                causalNovedad.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }
            return AdministradorProxy.ObtenerClienteAdministracion().InsertarCausalNovedad(causalNovedad);
        }

        /// <summary>
        /// Update the Causal Novelty.
        /// </summary>
        /// <returns>The Causal Novelty</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static Resultado ActualizarCausalNovedad(CausalNovedad causalNovedad)
        {
            if (!string.IsNullOrEmpty(((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString()))
            {
                causalNovedad.Login = ((BAC.EntidadesSeguridad.Usuario)(System.Web.HttpContext.Current.Session["Usuario"])).Login.ToString();
            }
            return AdministradorProxy.ObtenerClienteAdministracion().ActualizarCausalNovedad(causalNovedad);
        }
        /// <summary>
        /// Obtain the Causal Novelty.
        /// </summary>
        /// <returns>The Causal Novelty</returns>
        /// <remarks>
        /// Author: INTERGRUPO\LCOMBARIZA
        /// CreationDate: 27/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static IList<CausalNovedad> ConsultarCausalNovedad()
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ConsultarCausalNovedad();

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}