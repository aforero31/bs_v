<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ParametrizacionCanalVenta.aspx.cs" Inherits="BancaSegurosUI.Administracion.ParametrizacionCanalVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Administracion/ParametrizacionCanalVenta.js")%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Parametrización de Canal Venta</h3>
    <div class="x_panel">
        <div class="x_content">
            <form id="formConsulta" class="form-horizontal form-label-left" data-parsley-validate>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Código Canal Venta 
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <input id="txtIdCanalVenta" type="hidden"/>
                        <input id="txtCodigoCanalVenta" type="text" class="form-control col-md-7 col-xs-12" required data-parsley-type="integer" maxlength="2" data-parsley-range="[1, 99]"/>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Nombre Canal Venta
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <input id="txtNombreCanalVenta" type="text" class="form-control col-md-7 col-xs-12" required />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name" required>
                        Estado
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <input id="chEstado" type="checkbox" class="form-control" />
                    </div>
                </div>
            </form>
        </div>
    </div>

    <div class="x_panel">
        <div class="x_content">
            <form id="formBotones" class="form-vertical form-label-left">
                <div class="form-group">
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <input type="button" name="btnAgr" value="Agregar" class="btn btn-default" onclick="GuardarCanal()" />

                        <input type="button" name="btnAct" value="Actualizar" class="btn btn-default" onclick="ActualizarCanal()" />

                        <input type="button" name="btnCan" value="Cancelar" class="btn btn-default" onclick="Cancelar()" />
                    </div>
                </div>
            </form>
        </div>
    </div>
    <div id="panelGrillaReporte" class="x_panel table-responsive">
        <div class="GridviewDiv">
            <table id="gvReporte" class="display" cellspacing="0" width="100%"">
                <thead>
                    <tr class="headings">
                        <th>IdCanalVenta</th>
                        <th>Código Canal Venta</th>
                        <th>Nombre Canal Venta</th>
                        <th>Estado</th>
                        <th>Editar</th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
