<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ParametrizacionMensajes.aspx.cs" Inherits="BancaSegurosUI.Administracion.ParametrizacionMensajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Administracion/ParametrizacionMensajes.js")%>"></script>
    <style type="text/css">
        #taMensaje {
            height: 74px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Parametrización de Mensajes</h3>
    <div id="panelConsulta" class="x_panel">
        <h5>Consulta de Mensajes</h5>
        <div class="x_panel">
            <form id="formConsulta" class="form-horizontal form-label-left">
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Código - Llave 
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <input id="txtLlaveConsulta" type="text" class="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Evento 
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <select id="ddlEventoConsulta" class="selectpicker form-control">
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Tipo Mensaje 
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <select id="ddlTipoMensajeConsulta" class="selectpicker form-control">
                            <option value="">--Seleccione--</option>
                            <option value="1">Informativo</option>
                            <option value="2">Advertencia</option>
                            <option value="3">Error</option>
                        </select>
                    </div>
                </div>
            </form>
        </div>
        <div id="panelBotonesConsulta" class="x_panel">
            <input type="button" name="btnConsultar" value="Consultar Mensajes" class="btn btn-default" onclick="ConsultarMensaje()" />
            <input type="button" name="btnLimpiar" value="Limpiar" class="btn btn-default" onclick="LimpiarConsulta()" />

        </div>
        <h5>Creación de Mensajes</h5>
        <div class="x_panel">
            <input type="button" name="btnInsertar" value="Insertar Nuevo Mensaje" class="btn btn-default" onclick="InsertarNuevoMensaje()" />
        </div>

    </div>

    <div id="panelGrillaReporte" class="x_panel table-responsive">
        <div class="GridviewDiv">
            <table id="gvReporte" class="display" cellspacing="0" width="100%">
                <thead>
                    <tr class="headings">
                        <th>IdMensaje</th>
                        <th>Código - Llave</th>
                        <th>IdEvento</th>
                        <th>Evento</th>
                        <th>IdTipoMensaje</th>
                        <th>Tipo Mensaje</th>
                        <th>Mensaje</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </div>


    <div class="modal fade" style="width: 800px; margin: auto" id="modalMensaje" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog table-responsive">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true" onclick="Cancelar()">&times;</button>
                    <h4 class="modal-title">Información Mensajes</h4>
                </div>
                <div class="modal-body">
                    <div class="x_panel">
                        <form id="formMensajes" class="form-horizontal form-label-left" data-parsley-validate>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                    Código - Llave 
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input id="Llave" type="text" class="form-control" required />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                    Evento 
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <select id="ddlEvento" class="selectpicker form-control" required="required">
                                    </select>
                                    <input id="txtIdMensaje" type="hidden" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                    Tipo Mensaje 
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <select id="ddlTipoMensaje" class="selectpicker form-control" required="required">
                                        <option value="">--Seleccione--</option>
                                        <option value="1">Informativo</option>
                                        <option value="2">Advertencia</option>
                                        <option value="3">Error</option>
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                    Mensaje
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <textarea id="taMensaje" class="form-control col-md-7 col-xs-12" required="required"></textarea>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="x_panel">
                        <form id="formBotones" class="form-vertical form-label-left">
                            <div class="form-group">
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <input type="button" name="btnAgr" value="Guardar" class="btn btn-default" onclick="GuardarMensaje()" />

                                    <input type="button" name="btnAct" value="Actualizar" class="btn btn-default" onclick="ActualizarMensaje()" />

                                    <input type="button" name="btnCan" value="Cancelar" class="btn btn-default" onclick="Cancelar()" />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
