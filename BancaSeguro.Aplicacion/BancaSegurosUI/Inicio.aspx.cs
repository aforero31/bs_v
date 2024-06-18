using BAC.EntidadesSeguridad;
using BancaSeguros.Entidades.Catalogo;
using BancaSegurosUI.App_Code;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancaSegurosUI
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Obteners the menu.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Author: INTERGRUPO\CPIZA
        /// CreationDate: 11/03/2016
        /// ModifiedBy:
        /// ModifiedDate:
        /// </remarks>
        private List<BAC.EntidadesSeguridad.Menu> obtenerMenu()
        {
            if (Session["Menu"] == null)
            {
                Session["Menu"] = AdministradorProxy.ObtenerClienteSeguridad().ObtenerMenu();
            }
            return (List<BAC.EntidadesSeguridad.Menu>)Session["Menu"];
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<BAC.EntidadesSeguridad.Menu> CargarMenu()
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ObtenerMenu();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static List<BAC.EntidadesSeguridad.Menu> CargarMenuPorRol(List<Rol> roles)
        {
            return AdministradorProxy.ObtenerClienteSeguridad().ObtenerMenuPorRol(roles);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static DtoCatalogo ConsultarTodosCatalogo(string NombreTabla)
        {
            return AdministradorProxy.ObtenerClienteGenerico().ConsultarCatalogo(NombreTabla);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static BancaSeguros.Entidades.General.Resultado ConsultarMensajeDB(int evento,string llave)
        {
            BancaSeguros.Entidades.General.Resultado resultado = new BancaSeguros.Entidades.General.Resultado();
            BancaSeguros.Entidades.General.Mensaje mensaje = new BancaSeguros.Entidades.General.Mensaje();
            resultado = AdministradorProxy.ObtenerClienteGenerico().ConsultarMensajePorLlave(evento, llave);
            BancaSeguros.Entidades.Venta.ConsultarVenta _consultarventa = new BancaSeguros.Entidades.Venta.ConsultarVenta();

            return resultado;
        }
    }
}