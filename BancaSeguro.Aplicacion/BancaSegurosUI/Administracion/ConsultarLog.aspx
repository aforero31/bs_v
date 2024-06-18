<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ConsultarLog.aspx.cs" Inherits="BancaSegurosUI.Administracion.ConsultarLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Administracion/ConsultarLog.js")%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Consulta de Log de Auditoría</h3>

    <div id="panelConsultar" class="x_panel" data-parsley-validate="">
        <table>
            <tr>
                <td>
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                            Nombre Tabla 
                        </label>
                    </div>
                </td>
                <td>
                    <select id="ddlTablaAuditada" class="form-control" style="width: 200px;">
                    </select>
                </td>
                <td>
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                            Tipo
                        </label>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <select id="ddlEstado" class="form-control">
                            <option value="U" selected="selected">Actualización</option>
                            <option value="I">Inserción</option>
                            <option value="D">Eliminación</option>
                        </select>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                            Fecha Inicial<br />
                            (dd/mm/yyyy)
                        </label>
                    </div>
                </td>
                <td>
                    <input id="txtFechaInicial" type="text" class="form-control" data-parsley-pattern="^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[/\\/](19|20)\d{2}$" />
                </td>
                <td>
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Fecha Final
                        <br />
                        (dd/mm/yyyy)
                    </label>
                </td>
                <td>
                    <input id="txtFechaFinal" type="text" class="form-control" data-parsley-pattern="^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[/\\/](19|20)\d{2}$" />
                </td>
            </tr>
            <tr>
                <td>
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Usuario
                    </label>
                </td>
                <td>
                    <input id="txtUsuario" type="text" style="width: 200px;" class="form-control" maxlength="120" onkeypress="return ValidaCaracterAlfaNumerico(event);" />
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <input type="button" id="btnConsultar" value="Buscar" class="btn btn-default" onclick="ConsultarAuditoria();" />
                    <input type="button" name="btnLimpiar" value="Limpiar" class="btn btn-default" onclick="LimpiarControles();" />
                    <input type="button" id="btnExportar" value="Exportar" class="btn btn-default" onclick="ExportarAExcel();" />
                </td>
            </tr>
        </table>
    </div>

    <div id="panelGrillaReporte" class="x_panel table-responsive">
        <table id="gvAuditoria" class="table-responsive">
            <thead>
                <tr class="headings">
                    <th>IdAuditoria</th>
                    <th>Tipo</th>
                    <th>Nombre Tabla</th>
                    <th>Campo Llave</th>
                    <th>Valor Llave</th>
                    <th>Campo</th>
                    <th>Valor Anterior</th>
                    <th>Nuevo Valor</th>
                    <th>Fecha</th>
                    <th>Usuario</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

    <iframe id="iframeExcel" style="display: none"></iframe>
</asp:Content>
