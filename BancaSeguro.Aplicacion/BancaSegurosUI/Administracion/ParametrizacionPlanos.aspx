<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ParametrizacionPlanos.aspx.cs" Inherits="BancaSegurosUI.Administracion.ParametrizacionPlanos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Administracion/ParametrizacionPlanos.js")%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Parametrización Planos</h3>

    <div id="panelAdministracion" class="x_panel">
        <div id="panelGrillaPlanos" class="GridviewDiv table-responsive">
            <table id="grvPlanos" class="display" cellspacing="0" width="100%">
                <thead>
                    <tr class="headings">
                        <th>IdProgramacion</th>
                        <th>Objetivo</th>
                        <th>FechaInicio</th>
                        <th>FechaFin</th>
                        <th>IdAseguradora</th>
                        <th>Separador</th>
                        <th>CodigoFiltro</th>
                        <th>FechaEjecucion</th>
                        <th>DiaSemanal</th>
                        <th>DiaMes</th>
                        <th>NumeroSemana</th>
                        <th>DiaSemana</th>
                        <th>Campos</th>
                        <th>Filtros</th>
                        <th>Nombre</th>
                        <th>Programación</th>
                        <th>Estado</th>
                        <th>Ruta</th>
                        <th>Ultima Ejecucion</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
        <br />
        <br />
        <form id="formProgPlanos" class="form-horizontal form-label-left" data-parsley-validate>
            <div id="panelValores" class="x_panel">
                <table style="margin-left: 5px; margin-right: 0px; width: 100%">
                    <tr>
                        <td>
                            <label>Nombre Archivo</label>
                        </td>
                        <td style="width: 10px;">&nbsp;</td>
                        <td>
                            <input id="txtNombreArchivo" type="text" class="form-control" required="required" maxlength="20" />
                            <input type="hidden" id="hdIdProgramacion" />
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <label>Estado</label>
                        </td>
                        <td style="width: 10px;">&nbsp;</td>
                        <td colspan="3">
                            <select id="ddlEstado" class="selectpicker form-control" required="required">
                                <option value="">-- Seleccione --</option>
                                <option value="True">Activo</option>
                                <option value="False">Inactivo</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Ruta FTP</label>
                        </td>
                        <td style="width: 10px;">&nbsp;</td>
                        <td colspan="11">
                            <input type="text" id="txtRutaFtp" class="form-control" required="required" />
                        </td>
                        <td style="width: 10px;"></td>
                    </tr>
                    <tr>
                        <td>
                            <label>Objetivo</label>
                        </td>
                        <td style="width: 10px;">&nbsp;</td>
                        <td colspan="11">
                            <input type="text" id="txtObjetivo" class="form-control" style="width: 100%;" required="required" />
                        </td>
                        <td style="width: 10px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <label>Separador</label>
                        </td>
                        <td style="width: 10px;">&nbsp;</td>
                        <td>
                            <select id="ddlSeparador" class="selectpicker form-control" required="required">
                                <option value="">-- Seleccione --</option>
                                <option value="|">|</option>
                                <option value=",">,</option>
                                <option value=";">;</option>
                                <option value="/">/</option>
                            </select>
                        </td>
                        <td style="width: 10px;">&nbsp;</td>
                        <td>
                            <label>Frecuencia</label>
                        </td>
                        <td style="width: 10px;">&nbsp;</td>
                        <td colspan="5">
                            <select id="ddlFrecuencia" class="selectpicker form-control" required="required" onchange="MostrarProgramacion()">
                                <option value="">-- Seleccione --</option>
                                <option value="1">Por Demanda</option>
                                <option value="2">Diario</option>
                                <option value="3">Semanal</option>
                                <option value="4">Mensual</option>
                            </select>
                        </td>
                        <%--<td colspan="4">&nbsp;</td>--%>
                    </tr>
                </table>
            </div>
            <div id="Acordeon" class="x_panel">
                <%--Programacion--%>
                <h3 data-toggle="collapse" data-target="#panelProgramacion">
                    <img src="../css/jquery/images/arrow-down-01.png" width="20px" height="20px" data-toggle="collapse" data-target="#panelCampos" />&nbsp; Programación</h3>
                <div id="panelProgramacion" class="collapse">
                    <div id="diario" class="x_panel">
                        <label>Diario</label>
                        <table style="margin-left: 100px;">
                            <tr>
                                <td>
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                        Fecha Inicial<br />
                                        (dd/mm/yyyy)
                                    </label>
                                </td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <input id="txtFechaInicialDiario" type="text" class="fecha" data-parsley-pattern="^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[/\\/](19|20)\d{2}$" />
                                </td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                                <td>
                                    <%--<label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                Fecha Final<br />
                                (dd/mm/yyyy)
                            </label>--%>
                                </td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <%--<input id="txtFechaFinal" type="text" class="form-control" data-parsley-pattern="^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[/\\/](19|20)\d{2}$" />--%>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="semanal" class="x_panel">
                        <label>Semanal</label>
                        <table style="margin-left: 100px;">
                            <tr>
                                <td>
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                        Fecha Inicial<br />
                                        (dd/mm/yyyy)
                                    </label>
                                </td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <input id="txtFechaInicialSemanal" type="text" class="fecha" data-parsley-pattern="^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[/\\/](19|20)\d{2}$" />
                                </td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <label>Día</label>
                                </td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <select id="ddlDiaSemanal" class="selectpicker form-control">
                                        <option value="">-- Seleccione --</option>
                                        <option value="0">Domingo</option>
                                        <option value="1">Lunes</option>
                                        <option value="2">Martes</option>
                                        <option value="3">Miercoles</option>
                                        <option value="4">Jueves</option>
                                        <option value="5">Viernes</option>
                                        <option value="6">Sábado</option>
                                    </select>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="mensual" class="x_panel">
                        <label>Mensual</label>
                        <table style="margin-left: 100px;">
                            <tr>
                                <td>
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                        Fecha Inicial<br />
                                        (dd/mm/yyyy)
                                    </label>
                                </td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <input id="txtFechaInicialMensual" type="text" class="fecha" data-parsley-pattern="^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[/\\/](19|20)\d{2}$" />
                                </td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                            </tr>
                        </table>
                        <br />
                        <table style="margin-left: 100px;">
                            <tr>
                                <td style="width: 150px; margin-left: 12px;">
                                    <label>Configurar por</label>
                                </td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                                <td style="width: 150px;">
                                    <input type="radio" name="opcionSemanal" id="diaSemana" value="1" onclick="MostrarOpcionMensual()" />Días del mes
                                </td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                                <td colspan="5">
                                    <input type="radio" name="opcionSemanal" id="mesSemana" value="2" onclick="MostrarOpcionMensual()" />Semanas del mes
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div id="semanaProgramacion">
                            <table style="margin-left: 100px;">
                                <tr>
                                    <td>
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">El</label>
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 207px;">
                                        <select id="numeroSemanaProgramacion" class="selectpicker form-control">
                                            <option value="">-- Seleccione --</option>
                                            <option value="1">Primer</option>
                                            <option value="2">Segundo</option>
                                            <option value="3">Tercer</option>
                                            <option value="4">Cuarto</option>
                                            <option value="5">Ultimo</option>
                                        </select>
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td>
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">Dia</label>
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 207px;">
                                        <select id="dayWeek" class="selectpicker form-control">
                                            <option value="">-- Seleccione --</option>
                                            <option value="0">Domingo</option>
                                            <option value="1">Lunes</option>
                                            <option value="2">Martes</option>
                                            <option value="3">Miercoles</option>
                                            <option value="4">Jueves</option>
                                            <option value="5">Viernes</option>
                                            <option value="6">Sábado</option>
                                        </select>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="diasSemanaProgramacion">
                            <table style="margin-left: 100px;">
                                <tr>
                                    <td>
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">Día</label>
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 10px;"></td>
                                    <td style="width: 207px;">
                                        <select id="ddlDiasSemana" class="selectpicker form-control"></select>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div id="pordemanda" class="x_panel">
                        <label>Por demanda</label>
                        <table style="margin-left: 100px;">
                            <tr>
                                <td style="width: 220px;">
                                    <label for="first-name" style="margin-left: 12px;">
                                        Fecha Ejecución (dd/mm/yyyy)
                                    </label>
                                </td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <input id="txtFechaEjecucionDemanda" type="text" class="fecha" data-parsley-pattern="^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[/\\/](19|20)\d{2}$" />
                                </td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                                <td colspan="7">&nbsp;</td>
                            </tr>
                        </table>
                        <br />
                        <table style="margin-left: 100px;">
                            <tr>
                                <td>
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                        Fecha Inicial<br />
                                        (dd/mm/yyyy)
                                    </label>
                                </td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <input id="txtFechaInicialDemanda" type="text" class="fecha" data-parsley-pattern="^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[/\\/](19|20)\d{2}$" />
                                </td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                                <td>
                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                        Fecha Final<br />
                                        (dd/mm/yyyy)
                                    </label>
                                </td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;"></td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <input id="txtFechaFinalDemanda" type="text" class="fecha" data-parsley-pattern="^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[/\\/](19|20)\d{2}$" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <%--Criterios de Filtro--%>
                <h3 data-toggle="collapse" data-target="#panelFiltro">
                    <img src="../css/jquery/images/arrow-down-01.png" width="20px" height="20px" data-toggle="collapse" data-target="#panelFiltro" />&nbsp; Criterio de Filtro</h3>
                <div id="panelFiltro" class="collapse">
                    <div class="x_panel" style="width: 100%">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 150px;">
                                    <label>Aseguradora</label>
                                </td>
                                <td>
                                    <select id="ddlAseguradora" class="selectpicker form-control" required="required">
                                    </select>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="x_panel" style="width: 100%">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <input type="radio" name="opciones" onclick="ConsultarPolizas(0)" id="polizas" value="1" />&nbsp;Pólizas
                                </td>
                                <td style="width: 10px;"></td>
                                <td>
                                    <input type="radio" name="opciones" onclick="ConsultarCobros(0)" id="cobros" value="2" />&nbsp;Cobros
                                </td>
                                <td style="width: 10px;"></td>
                                <td style="width: 250px;">
                                    <input type="radio" name="opciones" onclick="ConsultarFiltrosCancelaciones(0)" id="cancelaciones" value="3" />&nbsp;Cancelaciones
                                </td>
                                <%--<td style="width: 10px;"></td>--%>
                                <%-- <td>
                                <input type="radio" name="opciones" />&nbsp;Emisiones
                            </td>--%>
                            </tr>
                        </table>
                    </div>
                    <div class="x_panel" style="width: 100%">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 150px;">
                                    <label>Filtros</label>
                                </td>
                                <td style="width: 10px;"></td>
                                <td align="center">
                                    <div style="width: 300px; height: 150px; overflow: auto">
                                        <select id="lstfuncAdicionar" size="10" style="width: 300px; overflow: visible;"></select>
                                    </div>
                                </td>
                                <td align="center">
                                    <button id="btnAdicionaFunc" type="button" onclick="AdicionaEstado()">--></button>
                                    <br />
                                    <button id="btnEliminaFunc" type="button" onclick="EliminaEstado()"><--</button>
                                </td>
                                <td align="center">
                                    <div style="width: 300px; height: 150px; overflow: auto">
                                        <select id="lstfunAdicionados" size="10" style="width: 300px; overflow: visible;"></select>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <%--Seleccion de Campos--%>
                <h3 data-toggle="collapse" data-target="#panelCampos">
                    <img src="../css/jquery/images/arrow-down-01.png" width="20px" height="20px" data-toggle="collapse" data-target="#panelCampos" />&nbsp; Selección Campos</h3>
                <div id="panelCampos" class="collapse">
                    <div class="x_panel">
                        <table style="margin: auto">
                            <tr>
                                <td>
                                    <div style="width: 300px; height: 150px; overflow: auto">
                                        <select id="lstAdicionCampos" size="10" style="width: 300px; overflow: visible;"></select>
                                    </div>
                                </td>
                                <td style="width: 10px;"></td>
                                <td>
                                    <button id="btnSeleccionaCampo" type="button" onclick="AdicionaCampos()">--></button>
                                    <br />
                                    <button id="btnEliminaCampo" type="button" onclick="EliminaCampos()"><--</button>
                                </td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <div style="width: 300px; height: 150px; overflow: auto">
                                        <select id="lstAgregadoCampos" size="10" style="width: 300px; overflow: visible;"></select>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </form>
        <div id="botones" class="x_panel">
            <input type="button" id="btnGenerar" value="Generar" class="btn btn-default" onclick="GenerarArchivo()" />
            <input type="button" id="btnActualizar" value="Actualizar" class="btn btn-default" onclick="ActualizarArchivo()" />
            <input type="button" id="btnCancelar" value="Cancelar" class="btn btn-default" onclick="LimpiaCampos()" />
        </div>
    </div>
</asp:Content>
