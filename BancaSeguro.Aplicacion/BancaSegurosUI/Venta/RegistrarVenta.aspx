<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RegistrarVenta.aspx.cs" Inherits="BancaSegurosUI.Venta.RegistrarVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Venta/RegistrarVenta.js")%>"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <h3>Registrar Venta</h3>
    <input type="hidden" id="hdnEdadMaximaConyugueSeguro" name="edadMaximaConyugueSeguro" />
    <input type="hidden" id="hdnEdadMinimaConyugueSeguro" name="edadMinimaConyugueSeguro" />
    <div id="div-registroVenta" data-parsley-validate="">
        <div id="panelBusquedaCliente" class="x_panel table-responsive">

            <table>
                <tr>
                    <td>
                        <label>Tipo de Identificación: </label>
                    </td>
                    <td style="width: 10px;">&nbsp;</td>
                    <td>
                        <select id="ddlTipoIdentificacion" class="selectpicker form-control" data-parsley-required>
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
                        <input type="image" src="<%=Page.ResolveUrl("~/imagenes/lupa.gif")%>" width="25" height="25" onclick="BuscarCliente()" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="panelConsultarDatosCliente" class="x_panel">
        <label>Información del Cliente</label>
        <div class="table-responsive">
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
        <table style="width: 100%">
            <tr>
                <td>
                    <input id="divCelular" name="divCelular" type="hidden" />
                </td>
                <td>
                        <input id="divCelularValor" name= "divCelularValor" type="hidden" />
                </td>
                <td>
                    <input id="divActividadEco" name= "divActividadEco" type="hidden" />
                </td>
                <td>
                    <input id="divDepartamentoResidencia" name= "divDepartamentoResidencia" type="hidden" />
                </td>
                <td>
                    <input id="divCodigoDANE" name= "divCodigoDANE" type="hidden" />
                </td>
            </tr>
        </table>
    </div>

    <div id="div-Seguro" data-parsley-validate="">
        <div id="panelSeguro" class="x_panel table-responsive">
            <table>
                <tr>
                    <td>
                        <label>Seguro</label>
                    </td>
                    <td style="width: 75px;">&nbsp;</td>
                    <td>
                        <input id="autoCompletSeguro" type="text" class="form-control" style="width: 350px;" data-parsley-required />
                    </td>
                    <td>
                        <input type="image" src="<%=Page.ResolveUrl("~/imagenes/lupa.gif")%>" width="25" height="25" onclick="ConsultarPlanes()" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div id="panelPlanes" class="x_panel">
        <label>Planes</label>
        <div class="GridviewDiv">
            <table id="gvPlanes" class="display">
                <thead>
                    <tr class="headings">
                        <th>Id del Plan</th>
                        <th>CodigoConvenio</th>
                        <th>Codigo del Plan</th>
                        <th>Nombre del Plan</th>
                        <th>Periodicidad</th>
                        <th>Valor</th>
                        <th>Selección</th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </div>

    <div id="panelPestanas" class="x_panel table-responsive">
        <ul class="nav nav-tabs" id="nombrePestañas">
            <li class="active"><a href="#productosBancarios" data-toggle="tab">Productos Bancarios</a></li>
            <li id="nombrePestañaConyuge"><a href="#registrarInformaciónCónyuge" data-toggle="tab">Registrar Información Cónyuge</a></li>
            <li id="nombrePestañaBeneficiario"><a href="#registrarBeneficiarios" data-toggle="tab">Registrar Beneficiarios</a></li>
            <li><a href="#variablesProductos" data-toggle="tab">Variables Productos</a></li>
        </ul>
        <div class="tab-content table-responsive">
            <div class="tab-pane fade in active" id="productosBancarios">
                <div class="GridviewDiv">
                    <table id="gvProductosBancarios" class="display">
                        <thead>
                            <tr class="headings">
                                <th>Codigo Producto</th>
                                <th>Codigo SubProducto</th>
                                <th>Codigo Categoria</th>
                                <th>Numero de Cuenta</th>
                                <th>Nombre del Producto</th>
                                <th>Saldo</th>
                                <th>Descripción</th>
                                <th>Selección</th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>

            <div class="tab-pane fade" id="registrarInformaciónCónyuge">
                <div id="div-Conyuge" data-parsley-validate="">
                    <div id="panelRegistrarInformaciónCónyuge">
                        <div class="x_panel">
                            <table>
                                <tr>
                                    <td>
                                        <label>Tipo de Identificación: </label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <select id="ddlTipoIdentificacionConyuge" class="selectpicker form-control" data-parsley-required>
                                        </select>
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td>
                                        <label>No. de Identificación: </label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtNoIdentificacionConyuge" type="text" class="form-control" required data-parsley-type="integer" />
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="btnBuscarConyuge" type="image" src="<%=Page.ResolveUrl("~/imagenes/lupa.gif")%>" width="25" height="25" onclick="BuscarConyuge()" />
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td colspan="2">
                                        <button title="Creación Rápida de Clientes" type="button" data-toggle="modal" data-target="#CreacionRapidadClientes" style="width: 120px;" disabled="disabled" class="btn btn-default" id="btnCreacion">Crear Cliente</button>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="x_panel" id="panelConsultarDatosConyuge">
                            <table>
                                <tr>
                                    <td>
                                        <label>Primer Nombre</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtPrimerNombreConyuge" type="text" style="width: 150px;" class="form-control" onblur="upperCase()" />
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td>
                                        <label>Segundo Nombre</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtSegundoNombreConyuge" type="text" style="width: 150px;" class="form-control" />
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td>
                                        <label>Primer Apellido</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtPrimerApellidoConyuge" type="text" style="width: 150px;" class="form-control" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 3px;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Segundo Apellido</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtSegundoApellidoConyuge" type="text" style="width: 150px;" class="form-control" />
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td>
                                        <label>Fecha de Nacimiento</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtFechaNacimientoConyuge" type="text" style="width: 150px;" class="form-control" />
                                    </td>
                                    <td style="width: 10px;"></td>
                                    <td>
                                        <label>Genero</label>
                                    </td>
                                    <td style="width: 10px;">&nbsp;</td>
                                    <td>
                                        <input id="txtGeneroConyuge" type="text" style="width: 150px;" class="form-control" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <input type="button" id="btnLimpiarConyuge" value="Limpiar" class="btn btn-default" onclick="LimpiarConyuge()" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="tab-pane fade" id="registrarBeneficiarios">
                <div id="div-RegistraBeneficiarios" data-parsley-validate="">
                    <div id="panelRegistrarBeneficiarios">
                        <div class="x_panel">
                            <table>
                                <tr>
                                    <td>
                                        <input type="checkbox" id="RegistroBeneficiarios" checked="checked" onclick="ActivaCamposBeneficiario()" /><b>Beneficiarios de Ley</b>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="x_panel">
                            <div class="x_panel">
                                <table>
                                    <tr>
                                        <td>
                                            <label>Tipo de Identificación: </label>
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <select id="ddlTipoIdentificacionBeneficiario" required="required" class="selectpicker tipo form-control">
                                            </select>
                                        </td>
                                        <td style="width: 10px;"></td>
                                        <td>
                                            <label>No. de Identificación: </label>
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td colspan="5">
                                            <input id="txtNoIdentificacionBeneficiario" type="text" class="num form-control" data-parsley-type="integer" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Primer Nombre</label>
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <input id="txtPrimerNombreBeneficiario" type="text" style="width: 150px;" class="form-control" required="required" data-parsley-pattern="^[a-z A-ZÑÁÉÍÓÚáéíóú]*$" />
                                        </td>
                                        <td style="width: 10px;"></td>
                                        <td>
                                            <label>Segundo Nombre</label>
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <input id="txtSegundoNombreBeneficiario" type="text" style="width: 150px;" class="form-control" data-parsley-pattern="^[a-z A-ZÑÁÉÍÓÚáéíóú]*$" />
                                        </td>
                                        <td style="width: 10px;"></td>
                                        <td>
                                            <label>Primer Apellido</label>
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <input id="txtPrimerApellidoBeneficiario" type="text" style="width: 150px;" class="form-control" required="required" data-parsley-pattern="^[a-z A-ZÑÁÉÍÓÚáéíóú]*$" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 3px;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Segundo Apellido</label>
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <input id="txtSegundoApellidoBeneficiario" type="text" style="width: 150px;" class="form-control" data-parsley-pattern="^[a-z A-ZÑÁÉÍÓÚáéíóú]*$" />
                                        </td>
                                        <td style="width: 10px;"></td>
                                        <td>
                                            <label>Parentesco</label>
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <select id="ddlParentescoBeneficiario" class="selectpicker form-control" required>
                                            </select>
                                        </td>
                                        <td style="width: 10px;"></td>
                                        <td>
                                            <label>Porcentaje %</label>
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <input id="txtPorcentajeBeneficiario" type="number" min="1" max="100" style="width: 150px;" class="post form-control" required="required" data-parsley-type="integer" />
                                            <input type="hidden" id="porcentajeAnterior" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input type="hidden" id="txtIndice" /></td>
                                    </tr>
                                </table>
                            </div>
                            <div id="panelBotonesBeneficiarios" class="x_panel">
                                <table>
                                    <tr>
                                        <td>
                                            <input type="button" name="btnAgrBen" value="Agregar Beneficiario" class="btn btn-default" onclick="AgregarBeneficiario()" />
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <input type="button" name="btnActBen" value="Actualizar Beneficiario" class="btn btn-default" onclick="ActualizarBeneficiario()" />
                                        </td>
                                        <td style="width: 10px;">&nbsp;</td>
                                        <td>
                                            <input type="button" name="btnCanBen" value="Cancelar" class="btn btn-default" onclick="CancelarBeneficiario()" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="x_content">
                                <div class="GridviewDiv">
                                    <table id="GridBeneficiario" class="display">
                                        <thead>
                                            <tr class="headings">
                                                <th>Indice</th>
                                                <th>IdTipoDocumento</th>
                                                <th>Tipo Documento</th>
                                                <th>Numero Documento</th>
                                                <th>Primer Nombre </th>
                                                <th>Segundo Nombre</th>
                                                <th>Primer Apellido</th>
                                                <th>Segundo Apellido</th>
                                                <th>IdTipoParentesco</th>
                                                <th>Parentesco</th>
                                                <th>Porcentaje %</th>
                                                <th>Acciones</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <div class="tab-pane fade" id="variablesProductos">
                <table id="tblVariablesProducto">
                </table>
            </div>
            <div class="modal fade" id="CreacionRapidadClientes" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div id="div-CreacionRapidaClientes" data-parsley-validate="">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">Creación Rápida de Clientes</h4>
                            </div>
                            <div class="modal-body">
                                <div class="table-responsive">
                                    <table>
                                        <tr>
                                            <td>
                                                <label>Tipo de Identificación </label>
                                            </td>
                                            <td>
                                                <select id="ddlTipoIdentificacionClienteNuevo" class="selectpicker form-control" style="width: 159px;" required>
                                                </select>
                                            </td>
                                            <td style="width: 20px;">&nbsp;</td>
                                            <td>
                                                <label>&nbsp;No. de Identificación </label>
                                            </td>
                                            <td>
                                                <input id="txtNoIdentificacionClienteNuevo" type="text" class="form-control" required data-parsley-type="integer" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>Primer Nombre</label>
                                            </td>
                                            <td>
                                                <input id="txtPrimerNombreClienteNuevo" type="text" class="form-control" required data-parsley-pattern="^[a-z A-ZÑÁÉÍÓÚáéíóú]*$" />
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <label>&nbsp;Segundo Nombre</label>
                                            </td>
                                            <td>
                                                <input id="txtSegundoNombreClienteNuevo" type="text" class="form-control" data-parsley-pattern="^[a-z A-ZÑÁÉÍÓÚáéíóú]*$" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>Primer Apellido</label>
                                            </td>
                                            <td>
                                                <input id="txtPrimerApellidoClienteNuevo" type="text" class="form-control" required data-parsley-pattern="^[a-z A-ZÑÁÉÍÓÚáéíóú]*$" />
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <label>&nbsp;Segundo Apellido</label>
                                            </td>
                                            <td>
                                                <input id="txtSegundoApellidoClienteNuevo" type="text" class="form-control" data-parsley-pattern="^[a-z A-ZÑÁÉÍÓÚáéíóú]*$" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>Genero</label>
                                            </td>
                                            <td>
                                                <select id="ddlSexoClienteNuevo" class="selectpicker form-control" required>
                                                </select>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <label>&nbsp;Fecha de Nacimiento</label>
                                            </td>
                                            <td>
                                                <input id="txtFechaNacimientoClienteNuevo" type="text" class="form-control" required data-parsley-pattern="^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[/\\/](19|20)\d{2}$" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" onclick="LimpiarCreacionRapidaCliente()">Limpiar</button>
                                <button type="button" class="btn btn-default" onclick="GuardarConyuge()">Guardar</button>
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="div-Asesor" class="x_panel table-responsive">
        <label>Información del Asesor</label>
        <div class="table-responsive">
            <div class="x_panel">
                <table>
                    <tr>
                        <td>
                            <label>No. de Identificación: </label>
                        </td>
                        <td style="width: 10px;">&nbsp;</td>
                        <td>
                            <input id="txtNoIdentificacionAsesor" type="text" style="width: 150px;" class="form-control" data-parsley-type="integer" />
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <label>Usuario Asesor: </label>
                        </td>
                        <td style="width: 10px;">&nbsp;</td>
                        <td>
                            <input id="txtUsuarioAsesor" type="text" style="width: 150px;" class="form-control" />
                        </td>
                        <td style="width: 10px;"></td>
                        <td>
                            <input type="image" src="<%=Page.ResolveUrl("~/imagenes/lupa.gif")%>" width="25" height="25" onclick="ObtenerDatosAsesor()" />
                        </td>

                        <td style="width: 10px;">&nbsp;</td>
                        <td style="width: 10px;">&nbsp;</td>
                        <td style="width: 10px;">&nbsp;</td>

                        <td>
                            <label>Nombre del Asesor: </label>
                        </td>
                        <td style="width: 10px;">&nbsp;</td>
                        <td>
                            <input id="txtNombreAsesor" type="text" style="width: 250px;" class="form-control" disabled="disabled" />
                        </td>

                    </tr>
                </table>
            </div>
            <div class="x_panel" id="div-ConsultaOficina" data-parsley-validate="">
                <table>
                    <tr>
                        <td>
                            <label>Código Oficina:</label>
                        </td>
                        <td style="width: 10px;">&nbsp;</td>
                        <td>
                            <input id="txtCodigoOficina" type="text" style="width: 150px;" class="form-control" required data-parsley-type="integer" />
                        </td>
                        <td>
                            <input type="image" src="<%=Page.ResolveUrl("~/imagenes/lupa.gif")%>" width="25" height="25" onclick="ConsultarOficinaPorCodigo()" />
                        </td>

                        <td style="width: 10px;">&nbsp;</td>

                        <td>
                            <label>Nombre Oficina:</label>
                        </td>
                        <td style="width: 10px;">&nbsp;</td>
                        <td>
                            <input id="txtNombreOficina" type="text" style="width: 250px;" class="form-control" disabled="disabled" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

    <div id="panelBotones">
        <table>
            <tr>
                <td>
                    <input type="button" id="btnRegistrarVenta" value="Registrar Venta" class="btn btn-default" onclick="RegistarVenta()" />
                </td>
                <td style="width: 10px;">&nbsp;</td>
                <td>
                    <input type="button" id="btnLimpiar" value="Limpiar" class="btn btn-default" onclick="LimpiarCamposPagina()" />
                </td>
                <td style="width: 10px;">&nbsp;</td>
                <td>
                    <input type="button" id="btnSalir" value="Salir" class="btn btn-default" onclick="SalirPagina()" />
                </td>
            </tr>
        </table>
    </div>
    <div class="modal fade" id="modPdf" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div id="divmodDocumentoPoliza" data-parsley-validate="">
            <div class="modal-dialog" style="width: 80%;">
                <div class="modal-content" style="width: 100%">
                    <div class="modal-header" style="width: 100%;text-align:center">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4><span id="toptitle" class="modal-title" style="width: 100%"></span></h4>
                    </div>
                    <div class="modal-body" style="width: 100%">
                        <div class="modal-content" style="width: 100%" id="divIframeDocumentoPoliza">
                            <iframe style="width: 100%" height="500" id="iframePDF" style="-moz-transform: scale(0.65); -moz-transform-origin: 0 0; -o-transform: scale(0.65); -o-transform-origin: 0 0; -webkit-transform: scale(0.65); -webkit-transform-origin: 0 0;"></iframe>

                        </div>
                    </div>
                </div>
            </div>           
        </div>
    </div>
</asp:Content>
