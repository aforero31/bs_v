<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="EjecucionManualETL.aspx.cs" Inherits="BancaSegurosUI.Administracion.EjecucionManualETL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Administracion/EjecucionManualETL.js")%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Ejecución Manual ETL</h3>

    <div id="panelGrillaPlanos" class="GridviewDiv x_panel">
        <table id="grvETL" class="display" cellspacing="0" width="100%">
            <thead>
                <tr class="headings">
                    <th>IdProceso</th>
                    <th>Proceso</th>
                    <th>Estado</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>
    <div id="panelRefrescar" class="x_panel">
        <button type="button" id="btnRefrescar" value="Refrescar" class="btn btn-default">Refrescar</button>
    </div>
    <div id="panelAdministracion" class="x_panel">
        <table>
            <tr>
                <td style="width: 250px;">&nbsp;</td>
                <td>
                    <button type="button" id="generaCancelacion" class="btn btn-default">Generar Cancelaciones</button>
                </td>
                <td style="width: 100px;">&nbsp;</td>
                <td>
                    <input type="checkbox" id="inacGenerarCancel" class="" />&nbsp; Inactivar
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 250px;">&nbsp;</td>
                <td>
                    <button type="button" id="ejecutarCobro" class="btn btn-default">Ejecutar Cobros</button>
                </td>
                <td style="width: 100px;">&nbsp;</td>
                <td>
                    <input type="checkbox" id="inacEjeCobro" class="" />&nbsp; Inactivar
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 250px;">&nbsp;</td>
                <td>
                    <button type="button" id="generaEmision" class="btn btn-default">Generar Emisiones</button>
                </td>
                <td style="width: 100px;">&nbsp;</td>
                <td>
                    <input type="checkbox" id="inacGenerarEmision" class="" />&nbsp; Inactivar
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 250px;">&nbsp;</td>
                <td>
                    <button type="button" id="ejecutarRecobis" class="btn btn-default">Ejecutar Respuesta Cobis</button>
                </td>
                <td style="width: 100px;">&nbsp;</td>
                <td>
                    <input type="checkbox" id="inacEjeRecobis" class="" />&nbsp; Inactivar
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 250px;">&nbsp;</td>
                <td>
                    <button type="button" id="genCobAseg" class="btn btn-default">Generar Cobros a la Aseguradora</button>
                </td>
                <td style="width: 100px;">&nbsp;</td>
                <td>
                    <input type="checkbox" id="" class="inacGenCobAseg" />&nbsp; Inactivar
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


