<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ParametrizacionAseguradora.aspx.cs" Inherits="BancaSegurosUI.Administracion.ParametrizacionAseguradora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Administracion/ParametrizacionAseguradora.js")%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Parametrización de la Aseguradora</h3>

    <div id="panelConsultar" class="x_panel" data-parsley-validate="">
        <table>
            <tr>
                <td>
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                            Búsqueda Por 
                        </label>
                    </div>
                </td>
                <td>

                    <select id="slopcionBusqueda" class="form-control col-md-7 col-xs-12" onchange="LimpiarValorBusqueda();">
                        <option value="1" selected="selected">Código</option>
                        <option value="2">Nombre</option>
                        <option value="3">NIT</option>
                    </select>

                </td>
                <td>
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                            Valor
                        </label>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <input id="txtValor" type="text" class="form-control col-md-7 col-xs-12" width="300px" required="required" maxlength="50" onkeypress="return ValidaCaracterBusqueda(event);" />
                    </div>
                </td>
                <td>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <input type="image" src="<%=Page.ResolveUrl("~/imagenes/lupa.gif")%>" width="25" height="25" onclick="ConsultarAseguradoras()" title="Buscar" />
                    </div>
                </td>
            </tr>
        </table>
    </div>

    <div class="x_panel">
        <input type="button" name="btnAgr" value="Agregar" class="btn btn-default" onclick="CargarNuevoFormulario()" />
    </div>

    <div id="panelGrillaReporte" class="x_panel table-responsive">
        <table id="gvAseguradora" class="table-responsive">
            <thead>
                <tr class="headings">
                    <th>IdAseguradora</th>
                    <th>Código Aseguradora</th>
                    <th>Nombre Aseguradora</th>
                    <th>IdTipoDocumento</th>
                    <th>Tipo de Documento</th>
                    <th>Número de Documento</th>
                    <th>Contacto</th>
                    <th>Teléfono</th>
                    <th>Correo</th>
                    <th>Estado</th>
                    <th>Consecutivo Inicial</th>
                    <th>Consecutivo Actual</th>
                    <th>Editar</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

    <div class="modal fade" style="width: 650px; margin: auto" id="modalInfoAseguradora" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-parsley-validate="">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Información de la Aseguradora</h4>
                </div>
                <div class="modal-body">
                    <table>
                        <tr>
                            <td>
                                <label>Código Aseguradora </label>
                            </td>

                            <td>
                                <input id="txtCodigoAseguradora" type="text" style="width: 200px;" class="form-control" required="required" maxlength="50" onkeypress="return ValidaCaracterNumerico(event);" />
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <label>Nombre Aseguradora</label>
                            </td>
                            <td>
                                <input id="txtNombreAseguradora" type="text" style="width: 200px;" class="form-control" required="required" maxlength="50" onkeypress="return ValidaCaracterAlfaNumerico(event);" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Tipo de Documento </label>
                            </td>
                            <td>
                                <select id="ddlTipoIdentificacion" style="width: 200px;" class="form-control" disabled="disabled">
                                </select>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <label>Número de Documento</label>
                            </td>
                            <td>
                                <input id="txtNumeroDocumento" type="text" style="width: 200px;" class="form-control" required="required" maxlength="50" onkeypress="return ValidaCaracterNumerico(event);" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Contacto </label>
                            </td>
                            <td>
                                <input id="txtContacto" type="text" style="width: 200px;" class="form-control" required="required" maxlength="50" onkeypress="return ValidaCaracterAlfaNumerico(event);" />
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <label>Teléfono</label>
                            </td>
                            <td>
                                <input id="txtTelefono" type="text" style="width: 200px;" class="form-control" required="required" maxlength="50" onkeypress="return ValidaCaracterNumerico(event);" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Correo </label>
                            </td>
                            <td>
                                <input id="txtCorreo" type="text" style="width: 200px;" class="form-control" required="required" maxlength="100" data-parsley-type="email" />
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <label>
                                    Estado
                                </label>

                            </td>
                            <td>
                                <label>
                                    Activo
                                </label>
                                <input id="chEstado" type="checkbox" />

                            </td>
                        </tr>
                        <tr id="filaActualizaConsecutivo" style="visibility: collapse">
                            <td>
                                <label>Actualiza Consecutivos </label>
                            </td>
                            <td>
                                <input id="chActualizaConsecutivo" type="checkbox" />
                            </td>
                            <td>&nbsp;</td>
                            <td colspan="2">
                                <div id="dividAseguradora" style="visibility: hidden"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Consecutivo Inicial </label>
                            </td>
                            <td>
                                <input id="txtConsecutivoInicial" type="text" style="width: 200px;" class="form-control" required="required" maxlength="10" onkeypress="return ValidaCaracterNumerico(event);" />
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <label>Consecutivo Actual</label>
                            </td>
                            <td>

                                <div id="divConsecutivoActual" class="control-label" style="font-size: small"></div>

                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="5">
                                <input type="button" id="btnAgr" value="Agregar" class="btn btn-default" onclick="GuardarAseguradora()" />

                                <input type="button" id="btnAct" value="Actualizar" class="btn btn-default" onclick="ActualizarAseguradora()" />

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
