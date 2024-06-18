<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ParametrizacionVariablesProducto.aspx.cs" Inherits="BancaSegurosUI.Administracion.ParametrizacionVariablesProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Administracion/ParametrizacionVariablesProducto.js")%>"></script>
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Parametrización de Variables de Producto</h3>
    <div id="divVars" data-parsley-validate="" class="x_panel table-responsive">
        <table>
            <tr>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <label>Aseguradora </label>
                </td>
                <td class="auto-style1">
                    <select id="selAseguradora" style="width: 200px;" class="form-control">
                        <option value="">-- Seleccione --</option>
                    </select>
                </td>
                <td class="auto-style1">
                    <label>Seguro </label>
                </td>
                <td class="auto-style1">
                    <select id="selSeguro" style="width: 200px;" class="form-control" required="required">
                        <option value="">-- Seleccione --</option>
                    </select>

                </td>
            </tr>
            <tr>
                <td>
                    <label>Tipo </label>
                </td>
                <td>
                    <select id="selTipo" style="width: 200px;" class="form-control" required="required">
                        <option value="">-- Seleccione --</option>
                    </select>
                </td>
                <td>
                    <label>Nombre </label>
                </td>
                <td>
                    <input id="txtNombreVariable" type="text" class="form-control" style="width: 200px" required="required" maxlength="30" onkeypress="return ValidaCaracterAlfaNumerico(event);" />

                </td>
            </tr>

            <tr>
                <td>
                    <label>Catalogo</label>
                </td>
                <td>
                    <select id="selMaestra" style="width: 200px;" class="form-control">
                        <option value="">-- Seleccione --</option>
                    </select></td>
                <td>
                    <label>Longitud </label>
                </td>
                <td>
                    <input id="txtLongitud" type="text" class="form-control" style="width: 100px" required="required" maxlength="10" onkeypress="return ValidaCaracterNumerico(event);" /></td>
            </tr>
            <tr>
                <td>
                    <label>Activo </label>
                </td>
                <td>
                    <input id="chkActivo" type="checkbox" /><input type="hidden" id="hidIdVariableProducto" /><input type="hidden" id="hidOrden" /></td>
                <td colspan="2">
                    <input type="button" id="btnAgr" value="Agregar" class="btn btn-default" onclick="InsertarVariable()" />
                    <input type="button" id="btnAct" value="Actualizar" class="btn btn-default" onclick="ActualizarVariable()" />
                    <input type="button" id="btnCan" value="Cancelar" class="btn btn-default" onclick="LimpiarCampos()" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <div id="panelGrillaReporte" class="x_panel table-responsive">
                        <table id="gvVariablesProducto" class="table-responsive">
                            <thead>
                                <tr class="headings">
                                    <th>IdVariableProducto</th>
                                    <th>Orden</th>
                                    <th>IdTipo</th>
                                    <th>Tipo</th>
                                    <th>Nombre</th>
                                    <th>Longitud</th>
                                    <th>Activo</th>
                                    <th>IdMaestra</th>
                                    <th>Acciones</th>
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

</asp:Content>
