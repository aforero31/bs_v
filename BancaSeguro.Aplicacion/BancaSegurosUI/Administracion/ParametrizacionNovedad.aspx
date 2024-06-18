<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ParametrizacionNovedad.aspx.cs" Inherits="BancaSegurosUI.Administracion.ParametrizacionNovedad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Administracion/ParametrizacionNovedad.js")%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Parametrización de Novedad</h3>
    <div class="x_panel">
        <div class="x_content">
            <form id="formNovedad" class="form-horizontal form-label-left" data-parsley-validate>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Código Novedad 
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <input id="txtIdNovedad" type="hidden" />
                        <input id="txtCodigoNovedad" type="text" class="form-control col-md-7 col-xs-12" required="required" data-parsley-pattern="/^\d*$/" maxlength="4" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Nombre Novedad
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <input id="txtNombreNovedad" type="text" class="form-control col-md-7 col-xs-12" required="required" onblur="validaTilde()"  />
                        <label id="message"></label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Estado Novedad
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <select id="cmbEstadoNovedad" class="selectpicker form-control" required="required">
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
                        <input type="button" name="btnAgr" value="Guardar" class="btn btn-default" onclick="GuardarNovedad()" />

                        <input type="button" name="btnAct" value="Actualizar" class="btn btn-default" onclick="ActualizarNovedad()" />

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
                        <th>IdNovedad</th>
                        <th>Código Novedad</th>
                        <th>Nombre Novedad</th>
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
