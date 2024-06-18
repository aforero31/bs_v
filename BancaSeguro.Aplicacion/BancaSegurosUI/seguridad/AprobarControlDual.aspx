<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AprobarControlDual.aspx.cs" Inherits="BancaSegurosUI.seguridad.AprobarControlDual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/seguridad/AprobarControlDual.js")%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Aprobación Control Dual</h3>

    <div id="panelConsultar" class="x_panel" data-parsley-validate="">
        <table>
            <tr>
                <td>
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                            Función 
                        </label>
                    </div>
                </td>
                <td>
                    <select id="ddlFuncion" class="form-control" style="width: 200px;" required="required">
                        <option value="">-- Seleccione --</option>
                    </select>
                </td>
                <td>
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                            Estado
                        </label>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <select id="ddlEstado" class="form-control">
                            <option value="">-- Seleccione --</option>
                            <option value="P">Por Aprobar</option>
                            <option value="A">Aprobada</option>
                            <option value="R">Rechazada</option>
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
                    <input id="txtFechaInicial" type="text" class="form-control fecha" data-parsley-pattern="^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[/\\/](19|20)\d{2}$" />
                </td>
                <td>
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Fecha Final
                        <br />
                        (dd/mm/yyyy)
                    </label>
                </td>
                <td>
                    <input id="txtFechaFinal" type="text" class="form-control fecha" data-parsley-pattern="^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[/\\/](19|20)\d{2}$" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <input type="button" id="btnConsultar" value="Buscar" class="btn btn-default" onclick="ConsultarAprobaciones();" />
                    <input type="button" name="btnLimpiar" value="Limpiar" class="btn btn-default" onclick="LimpiarControles();" />
                </td>
            </tr>
        </table>
    </div>

    <div id="panelGrillaReporte" class="x_panel table-responsive">
        <table id="gvAprobaciones" class="table-responsive" style="white-space: nowrap">
            <thead>
                <tr class="headings">
                    <th>IdAprobacionDual</th>
                    <th>IdMenu</th>
                    <th>Función</th>
                    <th>Estado</th>
                    <th>Acción</th>
                    <th>U. Envia</th>
                    <th>U. Aprueba/Rechaza</th>
                    <th>F. Solicitud</th>
                    <th>F. Aprobación/Rechazo</th>
                    <th>Detalle</th>
                    <th align="center">Proceso</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

    <div class="modal fade" style="margin: auto" id="modalDetalle" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-parsley-validate="">
        <div style="width: 800px;margin: auto">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Detalle del Registro</h4>
                    
                </div>
                <div class="modal-body">
                    <table style="width: 100%;">
                        <tr>
                            <td><label><span id="divNombreRegistro"></span></label></td>
                        </tr>
                        <tr>
                            
                            <td style="padding:5px">
                         
                                <table id="tblEntidad" style="width: 100%;table-layout:fixed"" border="1">
                                    <tr>
                                        <td>
                                            <label>Campo </label>
                                        </td>
                                        <td>
                                            <label>Valor</label>
                                        </td>
                                        <td id="tdValorAntes">
                                            <label id="lblAntes">Valor Antes</label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div id="divDescripcion"></div>
                            </td>
                        </tr>

                    </table>
                     
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" style="width: 600px; margin: auto" id="modalAutorizacion" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-parsley-validate="">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title"><span id="spantituloAutoriza"></span></h4>
                </div>
                <div class="modal-body">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <div id="divIdAprobacionDual" style="visibility: hidden" />
                            </td>
                            <td>
                                <div id="divAccionAprobacionDual" style="visibility: hidden" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Descripción </label>
                            </td>

                            <td>
                                <textarea id="txtDescripcion" style="width: 400px" required="required" maxlength="500" onkeypress="return ValidaCaracterAlfaNumerico(event);"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <input type="button" id="btnAprobar" value="Aceptar" class="btn btn-default" onclick="AutorizarCambio();" />
                                <input type="button" id="btnRechazar" value="Aceptar" class="btn btn-default" onclick="RechazarCambio();" />
                                <input type="button" id="btnCancelar" value="Cancelar" class="btn btn-default" onclick="CancelarCambio();" />
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
