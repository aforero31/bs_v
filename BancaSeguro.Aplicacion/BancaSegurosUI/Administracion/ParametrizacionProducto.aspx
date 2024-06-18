<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ParametrizacionProducto.aspx.cs" Inherits="BancaSegurosUI.Administracion.ParametrizacionProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Administracion/ParametrizacionProducto.js")%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Parametrización del Producto</h3>

    <div id="panelConsultar" class="x_panel" data-parsley-validate="">
        <table>
            <tr>
                <td>
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                            Búsqueda Por 
                        </label>
                    </div>
                </td>
                <td>

                    <select id="slopcionBusqueda" class="form-control col-md-7 col-xs-12" onchange="LimpiarValorBusqueda();">
                        <option value="1" selected="selected">Nombre Producto</option>
                        <option value="2">Código Producto</option>
                        <option value="3">Nombre Aseguradora</option>
                    </select>

                </td>
                <td>
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                            Valor
                        </label>
                    </div>
                </td>
                <td>
                    <div class="form-group">
                        <input id="txtValor" type="text" class="form-control col-md-7 col-xs-12" width="300px" required="required" maxlength="50" />
                    </div>
                </td>
                <td>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <input type="image" src="<%=Page.ResolveUrl("~/imagenes/lupa.gif")%>" width="25" height="25" onclick="ConsultarProductos()" title="Buscar" />
                    </div>
                </td>
            </tr>
        </table>
    </div>

    <div class="x_panel">
        <input type="button" name="btnInsertar" value="Insertar Producto" class="btn btn-default" onclick="InsertarNuevoProducto()" />
        <input type="button" name="btnLimpiarInicio" value="Limpiar Consulta" class="btn btn-default" onclick="LimpiarConsultaInicio()" />
    </div>

    <div id="panelGrvProducto" class="GridviewDiv x_panel">
        <table id="grvProducto" class="display" cellspacing="0" width="100%">
            <thead>
                <tr class="headings">
                    <th>IdProducto</th>
                    <th>Código del Producto</th>
                    <th>Nombre del Producto</th>
                    <th>Nombre de la Aseguradora</th>
                    <th>Estado</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

    <div class="modal fade" style="width: 850px; margin: auto" id="modalProducto" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="width: 837px;">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true" onclick="Cancelar()">&times;</button>
                    <h4 class="modal-title">Información del Producto</h4>
                </div>
                <div class="modal-body" style="width: 832px;">

                    <div id="detalleProducto" class="x_panel" data-parsley-validate="">
                        <table style="margin: auto">
                            <tr>
                                <td>
                                    <label>Aseguradora: </label>
                                </td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <select id="ddlAseguradora" class="selectpicker form-control" required>
                                    </select>
                                    <input id="txtIdProducto" type="text" hidden />
                                    <input id="txtcodigoProductoAct" type="text" hidden />
                                </td>
                                <td style="width: 10px;"></td>
                                <td>
                                    <label>Estado: </label>
                                </td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <select id="ddlEstado" class="selectpicker form-control" required>
                                        <option value="1">ACTIVO</option>
                                        <option value="0">INACTIVO</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Nombre Producto: </label>
                                </td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <input id="txtNombreProducto" type="text" style="width: 150px;" class="form-control selectpicker" required data-parsley-type="alphanum" />
                                </td>
                                <td style="width: 10px;"></td>
                                <td>
                                    <label>Código Producto: </label>
                                </td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <input id="txtCodigoProducto" type="text" style="width: 150px;" class="form-control" required data-parsley-type="integer" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Edad Mínima: </label>
                                </td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <input id="txtEdadMin" type="text" style="width: 150px;" maxlength="2" class="form-control" required data-parsley-type="integer" data-parsley-pattern="^[1-9]+" />
                                </td>
                                <td style="width: 10px;"></td>
                                <td>
                                    <label>Edad Máxima: </label>
                                </td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <input id="txtEdadMax" type="text" style="width: 150px;" maxlength="2" class="form-control" required data-parsley-type="integer" data-parsley-pattern="^[1-9]+" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="panelConyuge" class="x_panel">
                        <table style="margin: auto">
                            <tr>
                                <td>
                                    <label>Requiere Cónyuge</label>
                                </td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <input type="checkbox" id="chConyuge" onclick="RequiereConyuge()" />
                                </td>
                            </tr>
                        </table>

                        <div id="panelConyugeO" data-parsley-validate="">
                            <table style="margin: auto">
                                <tr>
                                    <td>
                                        <label>Edad Mínima: </label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtEdadMinConyuge" type="text" style="width: 150px;" maxlength="2" class="form-control" data-parsley-type="integer" data-parsley-pattern="^[1-9]+" />
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td>
                                        <label>Edad Máxima: </label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtEdadMaxConyuge" type="text" style="width: 150px;" maxlength="2" class="form-control" data-parsley-type="integer" data-parsley-pattern="^[1-9]+" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div id="panelBeneficiario" class="x_panel">
                        <table style="margin: auto">
                            <tr>
                                <td>
                                    <label>Requiere Beneficiario</label>
                                </td>
                                <td style="width: 10px;">&nbsp;</td>
                                <td>
                                    <input type="checkbox" id="chBeneficiario" onclick="RequiereBeneficiario()" name="" />
                                </td>
                            </tr>
                        </table>

                        <div id="panelBeneficiarioO" data-parsley-validate="">
                            <table style="margin: auto">
                                <tr>
                                    <td>
                                        <label>Número Máximo: </label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtNumeroMaxBeneficiario" type="text" style="width: 150px;" maxlength="2" class="form-control" data-parsley-type="integer" data-parsley-pattern="^[1-9]+" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                    <div id="panelEstado" class="x_panel" data-parsley-validate="">
                        <div id="panelDatosAdd" class="x_panel" data-parsley-validate="">
                            <table style="margin: auto">
                                <tr>
                                    <td style="width: 150px;">
                                        <label>Plantilla: </label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <select id="ddlPlantilla" class="selectpicker form-control">
                                        </select>
                                    </td>

                                </tr>
                            </table>
                            <br />
                            <table style="margin: auto">
                                <tr>
                                    <td style="width: 300px;">
                                        <div id="panelDiferentes">
                                            <table>
                                                <tr>
                                                    <td style="width: 250px;">
                                                        <label>Restringir número de cuentas</label>
                                                    </td>
                                                    <td style="width: 10px;">&nbsp;</td>
                                                    <td>
                                                        <input type="checkbox" id="chDiferentes" onclick="RequiereDiferente()" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td style="width: 300px;">
                                        <div id="panelIguales">
                                            <table style="margin: auto">
                                                <tr>
                                                    <td style="width: 250px;">
                                                        <label>Restringir ventas por cliente a la misma cuenta</label>
                                                    </td>
                                                    <td style="width: 10px;">&nbsp;</td>
                                                    <td>
                                                        <input type="checkbox" id="chIguales" onclick="RequiereIguales()" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>

                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 50%">
                                        <div id="panelDiferentesO" data-parsley-validate="">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <label style="margin-left: 77px;">Número de Cuentas: </label>
                                                    </td>
                                                    <td style="width: 10px;">&nbsp;</td>
                                                    <td>
                                                        <input id="txtNumeroVentasDiferente" type="text" style="width: 150px;" class="form-control" data-parsley-type="integer" data-parsley-pattern="^[1-9]+" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td style="width: 50%">
                                        <div id="panelIgualesO" data-parsley-validate="">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <label style="margin-left: 16px;">Número de Ventas: </label>
                                                    </td>
                                                    <td style="width: 10px;">&nbsp;</td>
                                                    <td>
                                                        <input id="txtNumeroVentasIgual" type="text" style="width: 150px;" class="form-control" data-parsley-type="integer" data-parsley-pattern="^[1-9]+" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </div>
                        <%--</div>
                    <div id="Acordeon" class="x_panel">--%>
                        <h3 data-toggle="collapse" data-target="#panelPlan">
                            <img id="planesAcordeon" src="../css/jquery/images/arrow-down-01.png" width="20px" height="20px" data-toggle="collapse" data-target="#panelPlan" />&nbsp; Planes del Producto</h3>
                        <div id="panelPlan" class="collapse">
                            <div id="panelPlanCampos" class="x_panel table-responsive" data-parsley-validate="">
                                <table style="margin: auto">
                                    <tr>
                                        <td>
                                            <label>Código del Plan: </label>
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <input id="txtCodigoPlan" type="text" style="width: 150px;" class="form-control" required data-parsley-type="integer" />
                                            <input id="txtIdPlan" type="text" hidden />
                                            <input id="txtIndice" type="text" hidden />
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <label>Nombre del Plan: </label>
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <input id="txtNombrePlan" type="text" style="width: 150px;" class="form-control" required data-parsley-type="alphanum" />
                                        </td>
                                        <td style="width: 10px;"></td>
                                        <td>
                                            <label>Periodicidad: </label>
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <select id="ddlPeriodicidad" class="selectpicker form-control" required>
                                            </select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Valor Sin IVA: </label>
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <input id="txtValorSinIVA" type="text" style="width: 150px;" class="form-control" required data-parsley-pattern="^\d+(\,\d{1,2})?$" />
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <label>Valor del IVA: </label>
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <input id="txtValorIVA" type="text" style="width: 150px;" class="form-control" data-parsley-pattern="^\d+(\,\d{1,2})?$" />
                                        </td>
                                        <td style="width: 10px;"></td>
                                        <td>
                                            <label>Valor Total: </label>
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <input id="txtValorTotal" type="text" style="width: 150px;" class="form-control" disabled="disabled" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Convenio: </label>
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <select id="ddlConvenio" class="selectpicker form-control" required>
                                            </select>
                                        </td>
                                        <td style="width: 10px;"></td>
                                        <td>
                                            <label>Estado: </label>
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <select id="ddlEstadoPlan" class="selectpicker form-control" required>
                                                <option value="1">ACTIVO</option>
                                                <option value="0">INACTIVO</option>
                                            </select>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="panelPlanBotones" class="x_panel table-responsive">
                                <input type="button" id="btnAgregarPlan" name="AgregarPlan" value="Agregar" class="btn btn-default" />
                                <input type="button" id="btnActualizarPlan" name="ActualizarPlan" value="Actualizar" class="btn btn-default" />
                                <input type="button" id="btnCancelarPlan" name="CancelarPlan" value="Cancelar" class="btn btn-default" />
                            </div>
                            <div id="panelPlanGv" class="GridviewDiv x_panel table-responsive">
                                <table id="grvPlan" class="display" cellspacing="0" width="100%">
                                    <thead>
                                        <tr class="headings">
                                            <th>Indice</th>
                                            <th>IdPlan</th>
                                            <th>Código del Plan</th>
                                            <th>Nombre del Plan</th>
                                            <th>Periodicidad</th>
                                            <th>IdPeriodicidad</th>
                                            <th>Convenio</th>
                                            <th>Estado</th>
                                            <th>Valor Sin IVA</th>
                                            <th>Valor del IVA</th>
                                            <th>Valor Total</th>
                                            <th>Acciones</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                        <h3 data-toggle="collapse" data-target="#panelCanalVentaAC">
                            <img id="CanalVentaAcordeon" src="../css/jquery/images/arrow-down-01.png" width="20px" height="20px" data-toggle="collapse" data-target="#panelCanalVentaAC" />&nbsp; Canales de Venta</h3>
                        <div id="panelCanalVentaAC" class="collapse">
                            <div id="panelCanalVenta" class="x_panel">
                            </div>
                        </div>

                        <h3 data-toggle="collapse" data-target="#panelTiposIdentificacionAC">
                            <img id="TiposIdentificacionAcordeon" src="../css/jquery/images/arrow-down-01.png" width="20px" height="20px" data-toggle="collapse" data-target="#panelTiposIdentificacionAC" />&nbsp; Tipos de identificación disponibles para la venta</h3>
                        <div id="panelTiposIdentificacionAC" class="collapse">
                            <div id="panelTiposIdentificacion" class="x_panel">
                            </div>
                        </div>

                        <h3 data-toggle="collapse" data-target="#panelCuentaNoPermitidaAC">
                            <img id="CuentaNoPermitidaAcordeon" src="../css/jquery/images/arrow-down-01.png" width="20px" height="20px" data-toggle="collapse" data-target="#panelCuentaNoPermitidaAC" />&nbsp; Productos bancarios para restringir la venta</h3>
                        <div id="panelCuentaNoPermitidaAC" class="collapse">
                            <div id="panelCuentaNoPermitida" class="x_panel">
                            </div>
                        </div>
                        <br />

                        <div id="panelBotones">
                            <input type="button" id="btnAct" name="btnAct" value="Actualizar" class="btn btn-default" onclick="ActualizarProducto()" />
                            <input type="button" id="btnAgr" name="btnAgr" value="Guardar" class="btn btn-default" onclick="GuardarProducto()" />
                            <input type="button" name="btnCan" value="Cancelar" class="btn btn-default" onclick="Cancelar()" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
