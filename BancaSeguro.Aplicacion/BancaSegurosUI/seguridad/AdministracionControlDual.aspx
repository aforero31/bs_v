<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AdministracionControlDual.aspx.cs" Inherits="BancaSegurosUI.seguridad.AdministracionControlDual" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/seguridad/AdministracionControlDual.js")%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Administración Control Dual</h3>
    <div class="x_panel">
        <div class="x_content">
            <form id="formControlDual" class="form-horizontal form-label-left" data-parsley-validate>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Funciones
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                       <select id="ddlFunciones" class="selectpicker form-control" required="required" onchange="ConsultarAdmonControlDual()"></select>
                    
                    </div>
                </div>
                <div class="form-group">
                    
                </div>
                <div class="form-group">

                </div>
                <div class="form-group">

                </div>
            </form>
        </div>
    </div>

     <div id="panelGrillaControlDual" class="x_panel table-responsive">
        <div class="GridviewDiv">
            <table id="gvControlDual" class="table-responsive">
                <thead>
                    <tr class="headings">
                        <th>IdRol</th>
                        <th>Rol</th>
                        <th>Requiere</th>
                        <th>Autoriza</th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </div>

    <div class="x_panel">
        <div class="x_content">
            <form id="formBotones" class="form-vertical form-label-left">
                <div class="form-group">
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <input type="button" name="btnAgr" value="Agregar" class="btn btn-default" onclick="Guardar()" />

                        <input type="button" name="btnAct" value="Actualizar" class="btn btn-default" onclick="Actualizar()" />

                        <input type="button" name="btnCan" value="Cancelar" class="btn btn-default" onclick="Cancelar()" />
                    </div>
                </div>
            </form>
        </div>
    </div>

   
</asp:Content>
