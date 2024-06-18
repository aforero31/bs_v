<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="BancaSegurosUI.seguridad.Roles" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/seguridad/Roles.js")%>"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="contenidoABancaId" runat="server">

    <h3>Administracion de Rol</h3>

    <div id="panelConsultar" class="x_panel" data-parsley-validate="">
        <table>
            <tr>
                <td>
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                            Nombre de Rol 
                        </label>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <input id="txtNombreBusqueda" type="text" class="form-control col-md-7 col-xs-12" width="300px" required="required" maxlength="50" onkeypress="return ValidaCaracterAlfaNumerico(event);" />
                    </div>
                </td>
                <td>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <input type="image" src="<%=Page.ResolveUrl("~/imagenes/lupa.gif")%>" width="25" height="25" onclick="ConsultarRoles()" title="Buscar" />
                    </div>
                </td>
            </tr>
        </table>
    </div>

    <div id="panelComandos" class="x_panel">
        <input type="button" name="btnAgr" value="Agregar" class="btn btn-default" onclick="CargarNuevoFormulario()" />
        <input type="button" name="btnExp" value="Exportar" class="btn btn-default" onclick="ConsultarRolesExportacion()" />
    </div>

    <div id="panelGrillaRol" class="x_panel table-responsive">
        <table id="gvRol" class="table-responsive">
            <thead>
                <tr class="headings">
                    <th>IdRol </th>
                    <th>Nombre </th>
                    <th>Activo </th>
                    <th>Editar</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

    <iframe id="iframeExcel" style="display: none"></iframe>

    <div class="modal fade" style="width: 900px; margin: auto" id="modalInfoRol" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-parsley-validate="">
        <div class="modal-dialog" style="width: 900px">
            <div class="modal-content" style="width: 900px;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Información del Rol</h4>
                </div>
                <div class="modal-body">
                    <table width="100%">
                        <tr>
                            <td>
                                <label class="control-label" for="first-name">
                                    Nombre de Rol
                                </label>
                            </td>
                            <td>
                                <input type="text" id="txtNombre" required="required" class="form-control" onkeypress="return ValidaCaracterAlfaNumerico(event);" maxlength="50" style="width: 300px" />
                            </td>
                           <td>
                               <label class="control-label">Estado</label>
                           </td>
                            <td>
                                <label>
                                    <input type="radio" name="chkActivo" id="chkActivo-1" value="1" />
                                    Activo
                                </label>
                        </tr>
                        <tr>
                            <td>
                                <div id="dividRol" style="visibility: hidden"></div>
                                
                            </td>
                            <td></td>
                            <td></td>
                            <td>
                                <label>
                                    <input type="radio" name="chkActivo" id="chkActivo-0" value="0" />
                                    Inactivo
                                </label>
                            </td>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="center">
                                <label class="control-label" for="first-name">
                                    Por Asignar
                                </label>
                            </td>
                            <td></td>
                            <td align="center">
                                <label class="control-label" for="first-name">
                                    Asignados
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                    Grupo BAC
                                </label>
                            </td>
                            <td align="center">
                                <div style="width: 300px; overflow-x: auto; overflow-y: hidden;">
                                    <select id="lstgruposAdicionar" size="10" style="min-width: 300px; overflow-x:visible;"></select>
                                </div>
                            </td>
                            <td align="center">
                                
                                <button id="btnAdicionaGrupoBAC" type="button" onclick="AdicionaGrupoBAC()">--></button>
                                <br />
                                <button id="btnEliminaGrupoBAC" type="button" onclick="EliminaGrupoBAC()"><--</button>
                                 
                            </td>
                            <td align="center">
                                <div style="width: 300px; overflow-x: auto; overflow-y: hidden;">
                                    <select id="lstgruposAdicionados" size="10" style="min-width: 300px; overflow-x:visible;"></select>
                                    </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="center">
                                <label class="control-label" for="first-name">
                                    Por Asignar
                                </label>
                            </td>
                            <td></td>
                            <td align="center">
                                <label class="control-label" for="first-name">
                                    Asignados
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                    Funcionalidades
                                </label>
                            </td>
                            <td align="center">
                                <div style="width: 300px; overflow-x: auto; overflow-y: hidden;">
                                    <select id="lstfuncAdicionar" size="10" style="min-width: 300px; overflow-x:visible;"></select>
                                    </div>
                            </td>
                            <td align="center">

                                <button id="btnAdicionaFunc" type="button" onclick="AdicionaMenu()">--></button>
                                <br />
                                <button id="btnEliminaFunc" type="button" onclick="EliminaMenu()"><--</button>
                                 
                            </td>
                            <td align="center">
                                <div style="width: 300px; overflow-x: auto; overflow-y: hidden;">
                                    <select id="lstfunAdicionados" size="10" style="min-width: 300px; overflow-x:visible;"></select>
                                    </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: right">
                                <input type="button" id="btnAgr" value="Agregar" class="btn btn-default" onclick="GuardarRol()" />

                                <input type="button" id="btnAct" value="Actualizar" class="btn btn-default" onclick="ActualizarRol()" />

                            </td>
                            <td></td>
                            <td style="text-align: left">
                                <input type="button" id="btnCan" value="Cancelar" class="btn btn-default" onclick="Cancelar()" />
                            </td>
                        </tr>

                    </table>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
