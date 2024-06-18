<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ParametrizacionIPC.aspx.cs" Inherits="BancaSegurosUI.Administracion.ParametrizacionIPC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Administracion/ParametrizacionIPC.js")%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Parametrización de IPC</h3>

    <div class="x_panel">
        <div class="x_content">
            <form id="formIPC" class="form-horizontal form-label-left" data-parsley-validate>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Año 
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <input id="txtIdIPC" type="hidden" />
                        <input id="txtAnoIPC" type="text" class="form-control col-md-7 col-xs-12" required="required" data-parsley-type="integer" maxlength="4" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                        Valor IPC
                    </label>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <input id="txtValorIPC" type="text" class="form-control col-md-7 col-xs-12" required="required" data-parsley-pattern="^\d+(.\d+)?$"  />
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12" style="margin-left:259px;">
                        <label for="ipc-message" id="ipcMessage">
                            El IPC ya fue parametrizado para el año en curso
                        </label>
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
                        <input type="button" name="btnAgr" value="Guardar" class="btn btn-default" onclick="GuardarIPC()" />

                        <input type="button" name="btnCan" value="Cancelar" class="btn btn-default" onclick="Cancelar()" />
                    </div>
                </div>
            </form>
        </div>
    </div>

</asp:Content>
