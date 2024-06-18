using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using BancaSeguros.Entidades;
using BancaSeguros.Aplicacion;
using BAC.EntidadesSeguridad;
using BancaSegurosUI.App_Code;
using BancaSeguros.Entidades.Catalogo;
using BancaSeguros.Entidades.Venta;
using System.Web.Script.Services;


namespace BancaSegurosUI
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if(Session["Usuario"] == null)
            {
                Response.Redirect("~/seguridad/Autenticacion.aspx");
            }
        }
    }
}