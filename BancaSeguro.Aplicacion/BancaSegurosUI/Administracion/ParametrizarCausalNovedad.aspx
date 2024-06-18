<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ParametrizarCausalNovedad.aspx.cs" Inherits="BancaSegurosUI.Administracion.ParametrizarCausalNovedad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Administracion/ParametrizacionCausalNovedad.js")%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Parametrización de Causal de Novedad</h3>
    <div class="x_panel">
        <div class="x_content">
            <form id="formCausalNovedad" class="form-horizontal form-label-left" data-parsley-validate>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Novedad 
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <select id="ddlNovedad" class="selectpicker form-control" required="required"></select>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Código Causal 
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <input id="txtIdCausalNovedad" type="hidden" />
                        <input id="txtCodigoCausalNovedad" type="text" class="form-control col-md-7 col-xs-12" required="required" data-parsley-pattern="/^\d*$/" maxlength="2" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Nombre Causal
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <input id="txtNombreCausalNovedad" type="text" class="form-control col-md-7 col-xs-12" required="required" data-parsley-pattern="/^[a-zA-Z\s]*$/" />
                        <label id="message"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Estado Causal 
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <select id="cmbEstadoCausalNovedad" class="selectpicker form-control" required="required">
                            <option value="">-- Seleccione --</option>
                            <option value="true">Activo</option>
                            <option value="false">Inactivo</option>
                        </select>
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
                        <input type="button" name="btnAgr" value="Guardar" class="btn btn-default" onclick="GuardarCausalNovedad()" />

                        <input type="button" name="btnAct" value="Actualizar" class="btn btn-default" onclick="ActualizarCausalNovedad()" />

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
                        <th>IdCausalNovedad</th>
                        <th>Nombre Causal Novedad</th>
                        <th>IdTipoNovedad</th>
                        <th>Nombre Novedad</th>
                        <th>Código Causal Novedad</th>
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
