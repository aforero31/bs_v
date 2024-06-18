<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ReImpresionPoliza.aspx.cs" Inherits="BancaSegurosUI.Venta.ReImpresionPoliza" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Venta/ReImpresionPoliza.js")%>"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
      <h3>Reimpresión Poliza</h3>
    <div id="panelConsultar" class="x_panel" data-parsley-validate="">
        <table>
            <tr>
                <td>
                    <label>Tipo de Identificación: </label>
                </td>
                <td style="width: 10px;">&nbsp;</td>
                <td>
                    <select id="ddlTipoIdentificacion" class="selectpicker form-control" required>
                    </select>
                </td>
                <td style="width: 10px;"></td>
                <td>
                    <label>No. de Identificación: </label>
                </td>
                <td style="width: 10px;">&nbsp;</td>
                <td>
                    <input id="txtNoIdentificacion" type="text" class="form-control" required data-parsley-type="integer" />
                </td>
                <td style="width: 10px;">&nbsp;</td>
                <td>
                    <input type="image" src="<%=Page.ResolveUrl("~/imagenes/lupa.gif")%>" width="25" height="25" onclick="BuscarPolizaCliente()" title="Buscar" />
                </td>
            </tr>
        </table>
    </div>

    <div id="panelInformacionBasica" class="x_panel table-responsive">
        <table>
            <tr>
                <td>
                    <label>Primer Nombre</label>
                </td>
                <td style="width: 10px;">&nbsp;</td>
                <td>
                    <input id="txtPrimerNombre" type="text" style="width: 150px;" class="form-control" />
                </td>
                <td style="width: 10px;"></td>
                <td>
                    <label>Segundo Nombre</label>
                </td>
                <td style="width: 10px;">&nbsp;</td>
                <td>
                    <input id="txtSegundoNombre" type="text" style="width: 150px;" class="form-control" />
                </td>
                <td style="width: 10px;"></td>
                <td>
                    <label>Primer Apellido</label>
                </td>
                <td style="width: 10px;">&nbsp;</td>
                <td>
                    <input id="txtPrimerApellido" type="text" style="width: 150px;" class="form-control" />
                </td>
                <td style="width: 10px;"></td>
                <td>
                    <label>Segundo Apellido</label>
                </td>
                <td style="width: 10px;">&nbsp;</td>
                <td>
                    <input id="txtSegundoApellido" type="text" style="width: 150px;" class="form-control" />
                </td>
            </tr>
        </table>
    </div>

    <div id="panelGrillaReporte" class="x_panel table-responsive">
        <table id="gvReporte" class="display" cellspacing="0" width="100%">
            <thead>
                <tr class="headings">
                    <th>IdVenta</th>
                    <th>IdSeguro</th>
                    <th>Numero</th>
                    <th>Nombre Plan</th>
                    <th>Nombre del Seguro</th>
                    <th>Valor</th>
                    <th>Cuenta Cliente</th>
                    <th>Imprimir</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

    <div id="panelBotones">
        <input type="button" id="btnLimpiar" value="Limpiar" class="btn btn-default" onclick="LimpiarPagina()" />
    </div>


    <div class="modal fade" id="modPdf" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div id="divmodDocumentoPoliza" data-parsley-validate="">
                <div class="modal-dialog" style="width: 80%;z-index:1;">
                    <div class="modal-content" style="width: 100%">
                        <div class="modal-header" style="width: 100%;text-align:center">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                             <h4><span id="toptitle" class="modal-title" style="text-align:center;width: 100%"></span></h4>
                        </div>
                        <div class="modal-body" style="width: 100%">
                            <div class="modal-content" style="width: 100%" id="divIframeDocumentoPoliza">
                                <iframe style="width: 100%" height="500" id="iframePDF" style="-moz-transform: scale(0.65); -moz-transform-origin: 0 0; -o-transform: scale(0.65); -o-transform-origin: 0 0; -webkit-transform: scale(0.65); -webkit-transform-origin: 0 0;"></iframe>

                            </div>
                        </div>
                    </div>
                </div>
                <iframe style="width: 1%" height="1%" id="iframePdf"></iframe>
            </div>
        </div>
</asp:Content>
