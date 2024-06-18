//-----------------------------------------------------------------------
// <copyright file="ConsultarLog.aspx.cs" company="Unión temporal FS-BAC-2013 ">
//     Copyright (c) Unión temporal FS-BAC-2013. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BancaSegurosUI.Administracion
{
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Services;
    using System.Web.Services;
    using BancaSeguros.Entidades.Catalogo;
    using BancaSeguros.Entidades.General;
    using BancaSegurosUI.App_Code;

    /// <summary>
    /// Log search class
    /// </summary>
    /// <remarks>
    /// Author: INTERGRUPO\PMORA
    ///  CreationDate: 19/05/2016
    /// ModifiedBy:
    /// ModifiedDate:
    /// </remarks>
    /// <seealso cref="System.Web.UI.Page" />
    public partial class ConsultarLog : System.Web.UI.Page
    {
        /// <summary>
        /// Search the catalogues.
        /// </summary>
        /// <param name="nombreTabla">The table name.</param>
        /// <returns>Catalogue object</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static DtoCatalogo ConsultarTodosCatalogo(string nombreTabla)
        {
            return AdministradorProxy.ObtenerClienteGenerico().ConsultarCatalogo(nombreTabla);
        }

        /// <summary>
        /// Search the audit.
        /// </summary>
        /// <param name="auditoria">The audit.</param>
        /// <returns>List of audits</returns>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<Auditoria> ConsultarAuditoria(Auditoria auditoria)
        {
            return AdministradorProxy.ObtenerClienteAdministracion().ObtenerAuditorias(auditoria);
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// Author: INTERGRUPO\PMORA
        ///  CreationDate: 19/05/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}