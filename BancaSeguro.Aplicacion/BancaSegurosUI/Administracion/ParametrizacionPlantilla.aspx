<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ParametrizacionPlantilla.aspx.cs" Inherits="BancaSegurosUI.Administracion.ParametrizacionPlantilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" href="../imagenes/favicon.ico" type="../image/vnd.microsoft.icon" />
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/scripts/aplicacion/Administracion/ParametrizacionPlantilla.js")%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoABancaId" runat="server">
    <form id="form1" runat="server">
        <input type="hidden" id="hiddenVersionPlantilla" name="hiddenVersionPlantilla" />
        <div id="principal" class="x_panel table-responsive">
            <h3>Plantillas por seguro</h3>
            <div class="table-responsive" id="plantillasPorProducto">
                <table class="table">
                    <tr>
                        <td>Seguro (Producto):</td>
                        <td>&nbsp;</td>
                        <td>
                            <select id="ddlProductos" class="selectpicker form-control">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div id="panelPlanes" class="x_panel">
                                <label>Plantillas asociadas al producto seleccionado</label>
                                <div class="GridviewDiv" id="plantillasSeguroDiv">
                                    <table id="gvReporte" class="display" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th>Nombre plantilla</th>
                                                <th>Versión</th>
                                                <th>Fecha Creación</th>
                                                <th>Plantilla activa</th>
                                                <th></th>
                                                <th></th>
                                                <th></th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

        <div class="x_panel">

            <div class="table-responsive" id="nuevaPlantillaDiv">
                <h3>1. Cargue la plantilla</h3>
                <div id="CarguePlantilla">
                    <span class="btn btn-success fileinput-button">
                        <i class="glyphicon glyphicon-plus"></i>
                        <span>Adicionar Archivo...</span>
                        <!-- The file input field used as target for the file upload widget -->
                        <input type="file" name="file" id="btnFileUpload" />
                    </span>                    
                    <!-- The container for the uploaded files -->
                    <div id="files" class="files"></div>
                    <table class="table" style="width: 100%">                    
                        <tr>
                            <td>Nombre de la plantilla: </td>
                            <td colspan="2">
                                <input type="text" id="txtNombreNuevaPlantilla" />
                            </td>
                        </tr>
                    </table>
                </div>
                <h3>2. Seleccione los datos para su plantilla</h3>
                <table class="table">
                    <tr>
                        <td>
                            <h4 data-toggle="collapse" data-target="#encabezadoPoliza">
                                <img id="polizaAcordeon" src="../css/jquery/images/arrow-down-01.png" width="20px" height="20px" data-toggle="collapse" data-target="#encabezadoPoliza" />&nbsp; Datos de la póliza</h4>
                            <div class="table-responsive" id="encabezadoPoliza">
                                <table class="table">
                                    <tr>
                                        <th>Campo</th>
                                        <th colspan="2">Marcador para la plantilla</th>
                                    </tr>
                                    <tr>
                                        <td>Fecha de Solicitúd</td>
                                        <td>./EncabezadoPoliza/FechaSolicitud</td>
                                        <td>
                                            <input type="checkbox" name="ParametroFechaSolicitud" id="chkParametroFechaSolicitud" data-nombrecolumna="FechaSolicitud" class="EncabezadoPoliza" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Consecutivo de la póliza</td>
                                        <td>./EncabezadoPoliza/ConsecutivoPoliza</td>
                                        <td>
                                            <input type="checkbox" name="ParametroConsecutivoPoliza" id="chkParametroConsecutivoPoliza" data-nombrecolumna="ConsecutivoPoliza" class="EncabezadoPoliza" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Valor de la póliza sin IVA</td>
                                        <td>./EncabezadoPoliza/ValorPolizaSinIva</td>
                                        <td>
                                            <input type="checkbox" name="ParametroValorPolizaSinIva" id="chkParametroValorPolizaSinIva" data-nombrecolumna="ValorPolizaSinIva" class="EncabezadoPoliza" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Valor IVA de la póliza</td>
                                        <td>./EncabezadoPoliza/ValorIvaPoliza</td>
                                        <td>
                                            <input type="checkbox" name="ParametroValorIvaPoliza" id="chkParametroValorIvaPoliza" data-nombrecolumna="ValorIvaPoliza" class="EncabezadoPoliza" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Valor de la prima con IVA</td>
                                        <td>./EncabezadoPoliza/ValorPrimaConIva</td>
                                        <td>
                                            <input type="checkbox" name="ParametroValorPrimaConIva" id="chkParametroValorPrimaConIva" data-nombrecolumna="ValorPrimaConIva" class="EncabezadoPoliza" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Periodicidad</td>
                                        <td>./EncabezadoPoliza/Periodicidad</td>
                                        <td>
                                            <input type="checkbox" name="ParametroPeriodicidad" id="chkParametroPeriodicidad" data-nombrecolumna="Periodicidad" class="EncabezadoPoliza" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Plan Poliza</td>
                                        <td>./EncabezadoPoliza/PlanPoliza</td>
                                        <td>
                                            <input type="checkbox" name="ParametroPlanPoliza" id="chkParametroPlanPoliza" data-nombrecolumna="PlanPoliza" class="EncabezadoPoliza" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Nombre Oficina</td>
                                        <td>./EncabezadoPoliza/NombreOficina</td>
                                        <td>
                                            <input type="checkbox" name="ParametroNombreOficina" id="chkParametroNombreOficina" data-nombrecolumna="NombreOficina" class="EncabezadoPoliza" />
                                        </td>
                                     </tr>
                                     <tr>
                                        <td>Ciudad Oficina</td>
                                        <td>./EncabezadoPoliza/CiudadOficina</td>
                                        <td>
                                            <input type="checkbox" name="ParametroCiudadOficina" id="chkParametroCiudadOficina" data-nombrecolumna="CiudadOficina" class="EncabezadoPoliza" />
                                        </td>
                                     </tr>
                                        <tr>
                                        <td>Identificacion Asesor</td>
                                        <td>./EncabezadoPoliza/IdentificacionAsesor</td>
                                        <td>
                                            <input type="checkbox" name="ParametroIdentificacionAsesor" id="chkParametroIdentificacionAsesor" data-nombrecolumna="IdentificacionAsesor" class="EncabezadoPoliza" />
                                        </td>
                                    </tr>
                                        <tr>
                                        <td>Nombre Asesor</td>
                                        <td>./EncabezadoPoliza/NombreAsesor</td>
                                        <td>
                                            <input type="checkbox" name="ParametroNombreAsesor" id="chkParametroNombreAsesor" data-nombrecolumna="NombreAsesor" class="EncabezadoPoliza" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h4 data-toggle="collapse" data-target="#clientePoliza">
                                <img id="clienteAcordeon" src="../css/jquery/images/arrow-down-01.png" width="20px" height="20px" data-toggle="collapse" data-target="#clientePoliza" />&nbsp; Datos del cliente</h4>
                            <div class="table-responsive" id="clientePoliza" <%--aria-expanded="false" style="height: 0px;--%>>
                                <table class="table">
                                    <tr>
                                        <th>Campo</th>
                                        <th colspan="2">Marcador para la plantilla</th>
                                    </tr>
                                    <tr>
                                        <td>Primer nombre</td>
                                        <td>./EncabezadoPoliza/PrimerNombreCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroPrimerNombreCliente" id="chkParametroPrimerNombreCliente" data-nombrecolumna="PrimerNombreCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Segundo nombre</td>
                                        <td>./EncabezadoPoliza/SegundoNombreCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroSegundoNombreCliente" id="chkParametroSegundoNombreCliente" data-nombrecolumna="SegundoNombreCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Primer apellido</td>
                                        <td>./EncabezadoPoliza/PrimerApellidoCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroPrimerApellidoCliente" id="chkParametroPrimerApellidoCliente" data-nombrecolumna="PrimerApellidoCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Segundo apellido</td>
                                        <td>./EncabezadoPoliza/SegundoApellidoCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroSegundoApellidoCliente" id="chkParametroSegundoApellidoCliente" data-nombrecolumna="SegundoApellidoCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Número identificación</td>
                                        <td>./EncabezadoPoliza/NumeroIdentificacionCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroNumeroIdentificacionCliente" id="chkParametroNumeroIdentificacionCliente" data-nombrecolumna="NumeroIdentificacionCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Tipo de identificación abreviado</td>
                                        <td>./EncabezadoPoliza/TipoIdentificacionAbreviadoCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroTipoIdentificacionAbreviadoCliente" id="chkParametroTipoIdentificacionAbreviadoCliente" data-nombrecolumna="TipoIdentificacionAbreviadoCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fecha de nacimiento</td>
                                        <td>./EncabezadoPoliza/FechaNacimientoCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroFechaNacimientoCliente" id="chkParametroFechaNacimientoCliente" data-nombrecolumna="FechaNacimientoCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Ciudad de nacimiento</td>
                                        <td>./EncabezadoPoliza/CiudadNacimientoCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroCiudadNacimientoCliente" id="chkParametroCiudadNacimientoCliente" data-nombrecolumna="CiudadNacimientoCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Género</td>
                                        <td>./EncabezadoPoliza/GeneroCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroGeneroCliente" id="chkParametroGeneroCliente" data-nombrecolumna="GeneroCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Actividad económica</td>
                                        <td>./EncabezadoPoliza/ActividadEconomicaCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroActividadEconomicaCliente" id="chkParametroActividadEconomicaCliente" data-nombrecolumna="ActividadEconomicaCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Dirección de residencia</td>
                                        <td>./EncabezadoPoliza/DireccionCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroDireccionCliente" id="chkParametroDireccionCliente" data-nombrecolumna="DireccionCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Teléfono</td>
                                        <td>./EncabezadoPoliza/TelefonoCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroTelefonoCliente" id="chkParametroTelefonoCliente" data-nombrecolumna="TelefonoCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Ciudad de residencia</td>
                                        <td>./EncabezadoPoliza/CiudadResidenciaCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroCiudadResidenciaCliente" id="chkParametroCiudadResidenciaCliente" data-nombrecolumna="CiudadResidenciaCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Departameno</td>
                                        <td>./EncabezadoPoliza/DepartamenoCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroDepartamenoCliente" id="chkParametroDepartamenoCliente" data-nombrecolumna="DepartamenoCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Nacionalidad</td>
                                        <td>./EncabezadoPoliza/NacionalidadCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroNacionalidadCliente" id="chkParametroNacionalidadCliente" data-nombrecolumna="NacionalidadCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Celular</td>
                                        <td>./EncabezadoPoliza/CelularCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroCelularCliente" id="chkParametroCelularCliente" data-nombrecolumna="CelularCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Tipo de cuenta</td>
                                        <td>./EncabezadoPoliza/TipoCuentaCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroTipoCuentaCliente" id="chkParametroTipoCuentaCliente" data-nombrecolumna="TipoCuentaCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Número cuenta</td>
                                        <td>./EncabezadoPoliza/NumeroCuentaCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroNumeroCuentaCliente" id="chkParametroNumeroCuentaCliente" data-nombrecolumna="NumeroCuentaCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fecha de vencimiento de la tarjeta</td>
                                        <td>./EncabezadoPoliza/FechaVencimientoTarjetaCliente</td>
                                        <td>
                                            <input type="checkbox" name="ParametroFechaVencimientoTarjetaCliente" id="chkParametroFechaVencimientoTarjetaCliente" data-nombrecolumna="FechaVencimientoTarjetaCliente" class="EncabezadoPolizaCliente" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h4 id="lblConyuge" data-toggle="collapse" data-target="#conyuge">
                                <img id="ConyugeAcordeon" src="../css/jquery/images/arrow-down-01.png" width="20px" height="20px" data-toggle="collapse" data-target="#conyuge" />&nbsp; Datos del cónyuge</h4>
                            <div class="table-responsive" id="conyuge">
                                <table class="table">
                                    <tr>
                                        <th>Campo</th>
                                        <th colspan="2">Marcador para la plantilla</th>
                                    </tr>
                                    <tr>
                                        <td>Primer nombre</td>
                                        <td>./ConyugePolizaDocumento/PrimerNombreConyuge</td>
                                        <td>
                                            <input type="checkbox" name="ParametroPrimerNombreConyuge" id="chkParametroPrimerNombreConyuge" data-nombrecolumna="PrimerNombreConyuge" class="ConyugePolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Segundo nombre</td>
                                        <td>./ConyugePolizaDocumento/SegundoNombreConyuge</td>
                                        <td>
                                            <input type="checkbox" name="ParametroSegundoNombreConyuge" id="chkParametroSegundoNombreConyuge" data-nombrecolumna="SegundoNombreConyuge" class="ConyugePolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Primer apellido</td>
                                        <td>./ConyugePolizaDocumento/PrimerApellidoConyuge</td>
                                        <td>
                                            <input type="checkbox" name="ParametroPrimerApellidoConyuge" id="chkParametroPrimerApellidoConyuge" data-nombrecolumna="PrimerApellidoConyuge" class="ConyugePolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Segundo apellido</td>
                                        <td>./ConyugePolizaDocumento/SegundoApellidoConyuge</td>
                                        <td>
                                            <input type="checkbox" name="ParametroSegundoApellidoConyuge" id="chkParametroSegundoApellidoConyuge" data-nombrecolumna="SegundoApellidoConyuge" class="ConyugePolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Tipo de identificación abreviada</td>
                                        <td>./ConyugePolizaDocumento/TipoIdentificacionAbreviaturaConyuge</td>
                                        <td>
                                            <input type="checkbox" name="ParametroTipoIdentificacionAbreviatura" id="chkParametroTipoIdentificacionAbreviatura" data-nombrecolumna="TipoIdentificacionAbreviaturaConyuge" class="ConyugePolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Número de identificación</td>
                                        <td>./ConyugePolizaDocumento/NumeroIdentificacionConyuge</td>
                                        <td>
                                            <input type="checkbox" name="ParametroNumeroIdentificacionConyuge" id="chkParametroNumeroIdentificacionConyuge" data-nombrecolumna="NumeroIdentificacionConyuge" class="ConyugePolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fecha nacimiento</td>
                                        <td>./ConyugePolizaDocumento/FechaNacimientoConyuge</td>
                                        <td>
                                            <input type="checkbox" name="ParametroFechaNacimientoConyuge" id="chkParametroFechaNacimientoConyuge" data-nombrecolumna="FechaNacimientoConyuge" class="ConyugePolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Ciudad de nacimiento</td>
                                        <td>./ConyugePolizaDocumento/CiudadNacimientoConyuge</td>
                                        <td>
                                            <input type="checkbox" name="ParametroCiudadNacimientoConyuge" id="chkParametroCiudadNacimientoConyuge" data-nombrecolumna="CiudadNacimientoConyuge" class="ConyugePolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Genero</td>
                                        <td>./ConyugePolizaDocumento/GeneroConyuge</td>
                                        <td>
                                            <input type="checkbox" name="ParametroGeneroConyuge" id="chkParametroGeneroConyuge" data-nombrecolumna="GeneroConyuge"  class="ConyugePolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Dirección</td>
                                        <td>./ConyugePolizaDocumento/DireccionConyuge</td>
                                        <td>
                                            <input type="checkbox" name="ParametroDireccionConyuge" id="chkParametroDireccionConyuge" data-nombrecolumna="DireccionConyuge" class="ConyugePolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Ciudad de residencia</td>
                                        <td>./ConyugePolizaDocumento/CiudadResidenciaConyuge</td>
                                        <td>
                                            <input type="checkbox" name="ParametroCiudadResidenciaConyuge" id="chkParametroCiudadResidenciaConyuge" data-nombrecolumna="CiudadResidenciaConyuge" class="ConyugePolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Teléfono</td>
                                        <td>./ConyugePolizaDocumento/TelefonoConyuge</td>
                                        <td>
                                            <input type="checkbox" name="ParametroTelefonoConyuge" id="chkParametroTelefonoConyuge" data-nombrecolumna="TelefonoConyuge" class="ConyugePolizaDocumento" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <h4 data-toggle="collapse" data-target="#beneficiarios">
                                <img id="BeneficiarioAcordeon" height="20px" src="../css/jquery/images/arrow-down-01.png" width="20px" data-toggle="collapse" data-target="#beneficiarios" />&nbsp; Beneficiarios</h4>
                            <div class="table-responsive" id="beneficiarios">
                                <table class="table">
                                    <tr>
                                        <th>Campo</th>
                                        <th colspan="2">Marcador para la plantilla</th>
                                    </tr>
                                    <tr>
                                        <td>Nombre completo</td>
                                        <td>./BeneficiariosPolizaDocumento/NombreCompletoBeneficiario</td>
                                        <td>
                                            <input type="checkbox" name="ParametroNombreCompletoBeneficiario" id="chkParametroNombreCompletoBeneficiario" data-nombrecolumna="NombreCompletoBeneficiario" class="BeneficiariosPolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Nombres</td>
                                        <td>./BeneficiariosPolizaDocumento/NombreBeneficiario</td>
                                        <td>
                                            <input type="checkbox" name="ParametroNombreBeneficiario" id="chkParametroNombreBeneficiario" data-nombrecolumna="NombreBeneficiario" class="BeneficiariosPolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Apellidos</td>
                                        <td>./BeneficiariosPolizaDocumento/ApellidoBeneficiario</td>
                                        <td>
                                            <input type="checkbox" name="ParametroApellidoBeneficiario" id="chkParametroApellidoBeneficiario" data-nombrecolumna="ApellidoBeneficiario" class="BeneficiariosPolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Tipo y número de identificación</td>
                                        <td>./BeneficiariosPolizaDocumento/TipoNumeroIdentificacionBeneficiario</td>
                                        <td>
                                            <input type="checkbox" name="ParametroTipoNumeroIdentificacionBeneficiario" id="chkParametroTipoNumeroIdentificacionBeneficiario" data-nombrecolumna="TipoNumeroIdentificacionBeneficiario" class="BeneficiariosPolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Tipo identificación abreviado</td>
                                        <td>./BeneficiariosPolizaDocumento/TipoIdentificacionAbreviaturaBeneficiario</td>
                                        <td>
                                            <input type="checkbox" name="ParametroTipoIdentificacionAbreviaturaBeneficiario" id="chkParametroTipoIdentificacionAbreviaturaBeneficiario" data-nombrecolumna="TipoIdentificacionAbreviaturaBeneficiario" class="BeneficiariosPolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Número de identificación</td>
                                        <td>./BeneficiariosPolizaDocumento/NumeroIdentificacionBeneficiario</td>
                                        <td>
                                            <input type="checkbox" name="ParametroNumeroIdentificacionBeneficiario" id="chkParametroNumeroIdentificacionBeneficiario" data-nombrecolumna="NumeroIdentificacionBeneficiario" class="BeneficiariosPolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Porcentaje de participación</td>
                                        <td>./BeneficiariosPolizaDocumento/PorcentajeParticipacion</td>
                                        <td> 
                                            <input type="checkbox" name="ParametroPorcentajeParticipacion" id="chkParametroPorcentajeParticipacion" data-nombrecolumna="PorcentajeParticipacion" class="BeneficiariosPolizaDocumento" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"></td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h4 data-toggle="collapse" data-target="#variablesProducto">
                                <img id="VariableAcordeon"  src="../css/jquery/images/arrow-down-01.png" width="20px" height="20px" data-toggle="collapse" data-target="#variablesProducto" />&nbsp; Variables Productos</h4>
                            <div class="table-responsive" id="variablesProducto">
                            
                            </div>
                        </td>
                    </tr>
                </table>
                <h3>3. Verifique los datos Seleccionados</h3>
                <table class="table">
                    <tr>
                        <td>
                            <h4>Datos seleccionados de la póliza </h4>
                            <div id="EncabezadoPolizaDatosDummie" class="table-responsive" style="width: 1000px;">No se han seleccionado marcadores para esta sección</div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h4>Datos seleccionados del cliente</h4>
                            <div id="ClientePolizaDatosDummie" class="table-responsive" style="width: 1000px;">No se han seleccionado marcadores para esta sección</div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h4>Datos seleccionados del conyuge</h4>
                            <div id="ConyugeDatosDummie" class="table-responsive" style="width: 1000px;">No se han seleccionado marcadores para esta sección</div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h4>Datos seleccionados del beneficiario </h4>
                            <div id="BeneficiariosDatosDummie" class="table-responsive" style="width: 1000px;">No se han seleccionado marcadores para esta sección</div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h4>Datos seleccionados variables del producto</h4>
                            <div id="VariableDatosDummie" class="table-responsive" style="width: 1000px;">No se han seleccionado marcadores para esta sección</div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <br />
                            <input type="button" id="btnPrevisualizar" value="Previsualizar" />&nbsp;
                        <input type="button" id="btnLimpiarFormulario" value="Limpiar el formulario" onclick="LimpiarFormulario();" />&nbsp;
                        <input type="button" id="btnPreGuardarPlantilla" value="Pre-Guardar" />
                            <input type="button" id="btnGuardarPlantilla" value="Guardar" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>

        <div class="modal fade" id="modDocumentoPolizaPreview" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div id="div-modDocumentoPolizaPreview" data-parsley-validate="">
                <div class="modal-dialog" style="width: 80%;">
                    <div class="modal-content" style="width: 100%">
                        <div class="modal-header" style="width: 100%">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" style="width: 100%">Póliza</h4>
                        </div>
                        <div class="modal-body" style="width: 100%">
                            <div class="modal-content" style="width: 100%" id="divIframeDocumentoPoliza">
                                <iframe style="width: 100%" height="500" id="iframePlantilla" style="-moz-transform: scale(0.65); -moz-transform-origin: 0 0; -o-transform: scale(0.65); -o-transform-origin: 0 0; -webkit-transform: scale(0.65); -webkit-transform-origin: 0 0;"></iframe>

                            </div>
                        </div>
                    </div>
                </div>
                <iframe style="width: 1%" height="1%" id="iframePdf"></iframe>
            </div>
        </div>
        <div class="modal fade" id="modDocumentoPlantilla" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div id="div-modDocumentoPlantilla" data-parsley-validate="">
                <div class="modal-dialog" style="width: 80%;">
                    <div class="modal-content" style="width: 100%">
                        <div class="modal-header" style="width: 100%">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" style="width: 100%">Plantilla</h4>
                        </div>
                        <div class="modal-body" style="width: 100%">
                            <div class="modal-content" style="width: 100%" id="divIframeDocumentoPlantilla">
                                <iframe style="width: 100%" height="500" id="iframeDocumentoPlantilla" style="-moz-transform: scale(0.65); -moz-transform-origin: 0 0; -o-transform: scale(0.65); -o-transform-origin: 0 0; -webkit-transform: scale(0.65); -webkit-transform-origin: 0 0;"></iframe>
                            </div>
                        </div>
                    </div>
                </div>
                <iframe style="width: 1%" height="1%" id="iframePlantillaDoc"></iframe>
            </div>
        </div>
    </form>
</asp:Content>
