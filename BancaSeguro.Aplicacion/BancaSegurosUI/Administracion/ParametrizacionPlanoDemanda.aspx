<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ParametrizacionPlanoDemanda.aspx.cs" Inherits="BancaSegurosUI.Administracion.ParametrizacionPlano" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Administracion/ParametrizacionPlanoDemanda.js")%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Parametrización Plano por Demanda</h3>

    <div id="panelPlanos" class="GridviewDiv x_panel">
        <table id="grvPlanos" class="display" cellspacing="0" width="100%">
            <thead>
                <tr class="headings">
                    <th>IdPlano</th>
                    <th>Nombre</th>
                    <th>Periodicidad</th>
                    <th>Última Ejecución</th>
                    <th>Estado</th>
                    <th>Ruta</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

    <div id="panelAdministracion" class="x_panel">
        <table style="margin: auto">
            <tr>
                <td>
                    <label>Nombre Archivo</label>
                </td>
                <td style="width: 10px;">&nbsp;</td>
                <td>
                    <input id="txtNombreArchivo" type="text" class="form-control" required />
                </td>
                <td style="width: 10px;"></td>
                <td>
                    <label>Separador</label>
                </td>
                <td style="width: 10px;">&nbsp;</td>
                <td>
                    <select id="ddlSeparador" class="selectpicker form-control" required>
                    </select>
                </td>
            </tr>
        </table>

        <div id="Acordeon" class="x_panel">
            <h3 data-toggle="collapse" data-target="#panelCampos">
                <img src="../css/jquery/images/arrow-down-01.png" width="20px" height="20px" data-toggle="collapse" data-target="#panelCampos" />&nbsp; Selección Campos</h3>
            <div id="panelCampos" class="collapse">
                <table style="margin: auto">
                    <tr>
                        <td>
                            <select id="lstFiltroAntes" size="10" style="width:300px;overflow:visible;"></select>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <input type="button" name="btnInsertarFiltro" value=">>>>" class="btn btn-default" />
                        <br />
                            <input type="button" name="btnEliminarFiltro" value="<<<<" class="btn btn-default" />
                        </td>
                        <td style="width: 10px;">&nbsp;</td>
                        <td>
                            <select id="lstFiltroDespues" size="10" style="width:300px;overflow:visible;"></select>
                        </td>
                    </tr>
                </table>
            </div>

            <h3 data-toggle="collapse" data-target="#panelFiltro">
                <img src="../css/jquery/images/arrow-down-01.png" width="20px" height="20px" data-toggle="collapse" data-target="#panelFiltro" />&nbsp; Criterio de Filtro</h3>
            <div id="panelFiltro" class="collapse">
                <table style="margin: auto">
                    <tr>
                        <td>
                            <label>Desde</label>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <input id="txtFechaDesde" type="text" class="form-control" />
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <label>Hasta</label>
                        </td>
                        <td style="width: 10px;">&nbsp;</td>
                        <td>
                            <input id="txtFechaHasta" type="text" class="form-control" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Estado</label>
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <select id="ddlEstado" class="selectpicker form-control" required>
                            </select>
                        </td>
                    </tr>
                </table>
            </div>
            <input type="button" id="btnGenerar" value="Generar" class="btn btn-default"/>
        </div>
    </div>
</asp:Content>
