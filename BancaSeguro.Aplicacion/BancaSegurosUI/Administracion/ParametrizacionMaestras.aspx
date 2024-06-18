<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ParametrizacionMaestras.aspx.cs" Inherits="BancaSegurosUI.Administracion.ParametrizacionMaestras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Administracion/ParametrizacionMaestra.js")%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Parametrización de Maestras</h3>

    <div id="panelConsultar" class="x_panel" data-parsley-validate="">
        <table>
            <tr>
                <td>
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                            Nombre Maestra
                        </label>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <input id="txtNombreMaestraConsulta" type="text" class="form-control col-md-7 col-xs-12" width="300px"  maxlength="30" onkeypress="return ValidaCaracterAlfaNumerico(event);" />
                    </div>
                </td>
                <td>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <input type="image" src="<%=Page.ResolveUrl("~/imagenes/lupa.gif")%>" width="25" height="25" onclick="ConsultarMaestras()" title="Buscar" />
                    </div>
                </td>
            </tr>
        </table>
    </div>

    <div class="x_panel">
        <input type="button" name="btnAgr" value="Agregar" class="btn btn-default" onclick="CargarNuevoFormulario()" />
    </div>

    <div id="panelGrillaReporte" class="x_panel table-responsive">
        <table id="gvMaestra" class="table-responsive">
            <thead>
                <tr class="headings">
                    <th>IdMaestra</th>
                    <th>Nombre</th>
                    <th>Activo</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

    <div class="modal fade" style="width: 800px; margin: auto" id="modalInfoMaestra" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog table-responsive">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Información de la Maestra</h4>
                </div>
                <div class="modal-body">
                    <table>
                        <tr>
                            <td>
                                <label>Nombre </label>
                            </td>
                            <td>
                                <div id="divMaestra" data-parsley-validate="">
                                <input id="txtNombreMaestra" type="text" class="form-control col-md-7 col-xs-12" width="300px" required="required" maxlength="30" onkeypress="return ValidaCaracterAlfaNumerico(event);" />
                                    </div>
                            </td>
                            <td>
                                <label>
                                    Activo
                                </label>
                            </td>
                            <td>
                                <input id="chkActivo" type="checkbox" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan ="4">
                                 <input type="hidden" id="txtIdMaestra" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div id="divItems" data-parsley-validate="" class="x_panel table-responsive">
                                <table>
                                    <tr>
                                        <td colspan="4">
                                            <label>Item</label>  <input type="hidden" id="txtIndice" /><input type="hidden" id="txtTemporal" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Código </label>
                                        </td>
                                        <td>
                                            <input id="txtCodigo" type="text" class="form-control col-md-7 col-xs-12" style="width:150px" required="required" maxlength="50" onkeypress="return ValidaCaracterAlfaNumerico(event);" /></td>
                                        <td>
                                            <label>Valor </label>
                                        </td>
                                        <td>
                                            <input id="txtValor" type="text" class="form-control col-md-7 col-xs-12" style="width:300px" required="required" maxlength="30" onkeypress="return ValidaCaracterAlfaNumerico(event);" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Activo </label>
                                        </td>
                                        <td>
                                            <input id="chkActivoItem" type="checkbox" /></td>
                                        <td colspan="2">
                                            <input type="button" id="btnAgrItem" value="Agregar Item" class="btn btn-default" onclick="AdicionarItem()" />
                                            <input type="button" id="btnActItem" value="Actualizar Item" class="btn btn-default" onclick="ActualizarItem()" />
                                             <input type="button" id="btnCanItem" value="Cancelar" class="btn btn-default" onclick="LimpiarCamposItem()" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div id="panelGrillaItems" class="x_panel table-responsive">
                                                <table id="gvItemsMaestra" class="table-responsive">
                                                    <thead>
                                                        <tr class="headings">
                                                            <th>Indice</th>
                                                            <th>IdMaestra</th>
                                                            <th>Código</th>
                                                            <th>Valor</th>
                                                            <th>Activo</th>
                                                            <th>Acciones</th>
                                                            <th>Temporal</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                </div>
                            </td>
                        </tr>


                        <tr>
                            <td align="center" colspan="5">
                                <input type="button" id="btnAgr" value="Guardar" class="btn btn-default" onclick="GuardarMaestra()" />

                                <input type="button" id="btnAct" value="Actualizar" class="btn btn-default" onclick="ActualizarMaestra()" />

                                <input type="button" id="btnCan" value="Cancelar" class="btn btn-default" onclick="Cancelar()" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>

</asp:Content>
