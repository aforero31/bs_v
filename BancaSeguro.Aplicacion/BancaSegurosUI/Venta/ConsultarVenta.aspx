<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ConsultarVenta.aspx.cs" Inherits="BancaSegurosUI.Venta.ConsultarVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Venta/ConsultarVenta.js")%>"></script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Consultar Venta</h3>
    <div id="panelConsultar" class="x_panel table-responsive" data-parsley-validate="">
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
                <tr>
                    <th>IdVenta</th>
                    <th>Estado</th>
                    <th>Número Poliza</th>
                    <th>Fecha Creación</th>
                    <th>Fecha Cancelación</th>
                    <th>Descripción Novedad</th>
                    <th>Seguro</th>
                    <th>Nombre del Seguro</th>
                    <th>Plan</th>
                    <th>Nombre Plan</th>
                    <th>Periodicidad</th>
                    <th>Valor</th>
                    <th>Cuenta Cliente</th>
                    <th>Fecha Último Cobro</th>
                    <th>Detalles</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

    <div id="panelBotones">
        <input type="button" id="btnLimpiar" value="Limpiar" class="btn btn-default" onclick="LimpiarPagina()" />
    </div>

    <div class="modal fade table-responsive" id="modalDetallePoliza" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-parsley-validate="">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Detalle de la Poliza</h4>
                    <div id="detPol" class="modal-title"></div>
                </div>
                <div class="modal-body">
                    <div id="panelModalCliente" class="table-responsive">
                        <label>Información Cliente</label>
                        <div class="x_panel table-responsive" id="modal_detalle">
                            <table>
                                <tr>
                                    <td>
                                        <label>Fecha de Nacimiento</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtFechaNacimiento" type="text" style="width: 150px;" class="form-control" />
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td>
                                        <label>Ciudad de Nacimiento</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtCiudadNacimiento" type="text" style="width: 150px;" class="form-control" />
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td>
                                        <label>Nacionalidad</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtNacionalidad" type="text" style="width: 150px;" class="form-control" />
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td>
                                        <label>Genero</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input type="text" id="txtGenero" style="width: 150px;" class="form-control" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Dirección</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtDireccion" type="text" style="width: 150px;" class="form-control" />
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td>
                                        <label>Ciudad de Residencia</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtCiudadResidencia" type="text" style="width: 150px;" class="form-control" />
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td>
                                        <label>Telefono</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtTelefono" type="text" style="width: 150px;" class="form-control" />
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td>
                                        <label>Correo Electronico</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtCorreoElectronico" type="text" style="width: 150px;" class="form-control" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                    <div id="panelModalCuenta" class="table-responsive">
                        <label>Información Cuenta Bancaria</label>
                        <div class="x_panel table-responsive" id="modal_bancaria">
                            <table>
                                <tr>
                                    <td>
                                        <label>Codigo Producto</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtCodigoProducto" type="text" style="width: 150px;" class="form-control" />
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td>
                                        <label>Nombre del Producto</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtNombreProducto" type="text" style="width: 150px;" class="form-control" />
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td>
                                        <label>Numero de Cuenta</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtNumeroCuenta" type="text" style="width: 150px;" class="form-control" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div id="divCelular" style="visibility: hidden"></div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
</asp:Content>