var ArchivoCargado = false;
var esActivaPlantilla = false;
var PlantillaGuardada = false;
var oTableReporte;

$(document).ready(function () {
    if (initSession()) {
        IniciarPrecargaBancaSeguros();
        InicializarGrillaPlantillas();
        $('#btnGuardarPlantilla').click(function () {
            MostrarModalConfirmar(2, "Recuerde que si guarda la plantilla por esta opción, la plantilla quedará como activa para el seguro seleccionado<br />¿Desea guardar la plantilla?", 'GuardarPlantilla(true);', null);
        });
        $('#btnPreGuardarPlantilla').click(function () {
            GuardarPlantilla(false);
        });
        $("input[name*='Parametro']").click(function () {
            //MostrarInformacionDummieSeleccionada();
        });
        $('#btnPrevisualizar').off('click');
        $('#btnPrevisualizar').click(function () {
            PreviewDocumento();
        });
        $('#ddlProductos').change(function () {
            ObtenerPlantillasPorSeguro();

            $(':checkbox').change(function () {
                var txtClass = $(this).attr("class");
                switch (txtClass) {
                    case "EncabezadoPoliza":
                        LlenarInformacionDummie('EncabezadoPoliza', 'EncabezadoPolizaDatosDummie');
                        break;
                    case "EncabezadoPolizaCliente":
                        LlenarInformacionDummie('EncabezadoPolizaCliente', 'ClientePolizaDatosDummie');
                        break;
                    case "ConyugePolizaDocumento":
                        LlenarInformacionDummie('ConyugePolizaDocumento', 'ConyugeDatosDummie');
                        break;
                    case "BeneficiariosPolizaDocumento":
                        LlenarInformacionDummie('BeneficiariosPolizaDocumento', 'BeneficiariosDatosDummie');
                        break;
                    case "VariablesPolizaDocumento":
                        LlenarInformacionDummie('VariablesPolizaDocumento', 'VariableDatosDummie');
                        break;
                }
            });
        });

        LlenarListasDesplegables();
        ColapsarDatosParaSeleccionar();
        ConstructorCargaArchivo();

        var _Mensaje = getParameterByName('Mensaje');
        if (_Mensaje != null) {
            if (_Mensaje.length > 0) {
                MostrarMensajeGenerico(1, _Mensaje);
            }
        }

        ValidarControlDual();
    }
    else {
        IniciarPrecargaBancaSeguros();
        MostrarModalConfirmar(3, "Usted no se encuentra logueado o con permisos para acceder a esa pagina", 'sessLogOut()', 'sessLogOut()');
    }
});

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

function ConstructorCargaArchivo() {
    var NombreArchivo;
    $('#btnFileUpload').fileupload({
        url: 'FileUploadHandler.ashx?upload=start',
        add: function (e, data) {
            NombreArchivo = data.files[0].name;
            $("#files").html('');
            data.context = $('<div/>').appendTo('#files');
            var node = $('<p/>')
                    .append($('<span/>').text(data.files[0].name));
            node.appendTo(data.context);

            var output = NombreArchivo.substr(0, NombreArchivo.lastIndexOf('.')) || NombreArchivo;
            $("#txtNombreNuevaPlantilla").val(output);
            data.submit();
        },
        success: function (response, status) {
            ConvertirArchivoenBytes(NombreArchivo);
        },
        error: function (data) {
            var ArchivoCargado = false;
            var r = data.responseText;
            var errorMessage = r.Message;
            MostrarMensajeGenerico(3, errorMessage);
        }
    });
}

function ConvertirArchivoenBytes(NombreArchivo) {
    $.ajax({
        type: "POST",
        cache: false,
        contentType: "application/json; charset=utf-8",
        url: 'ParametrizacionPlantilla.aspx/ConvertirArchivoenBytes',
        data: "{NombreArchivo:" + JSON.stringify(NombreArchivo) + "}",
        dataType: "json",
        success: function (data) {
            ArchivoCargado = true;
            MostrarMensajeGenerico(data.d.IdTipoMensaje, data.d.Mensaje);
        },
        error: function (data) {
            ArchivoCargado = false;
            MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje);
        }
    });
}

function InicializarGrillaPlantillas() {
    oTableReporte = $('#gvReporte').dataTable({
        "oLanguage": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        },
        "sProcessing": true,
        "columns": [
            { "data": "Nombreplantilla" },
            { "data": "Version" },
            { "data": "FechaCreacion" },
            { "data": "PlantillaActiva" },
            { "data": "DescargarPlantilla" },
            { "data": "Previsualizar" },
            { "data": "Editar" },
            { "data": "Eliminar" }
        ],
        "aoColumnDefs": [
            {
                'bSortable': false,
                'aTargets': [0]
            } //disables sorting for column one
        ],
        'iDisplayLength': 10,
        "sPaginationType": "full_numbers",
        "dom": 'T<"clear">lfrtip',
    });
}

function LlenarListasDesplegables() {
    var catalogoSeguros;
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: 'ParametrizacionPlantilla.aspx/ObtenerSeguros',
        data: null,
        dataType: "json",
        success: function (data) {
        },
        complete: function (data) {
            var datad = data.responseJSON.d;
            var estado = "";

            $('#ddlProductos').append($('<option>', { value: "0", text: '--Seleccione--' }));
            for (var i = 0; i < datad.length; i++) {
                if (datad[i].Activo) {
                    estado = "Activo";
                } else {
                    estado = "Inactivo";
                }

                $('#ddlProductos').append($('<option>', { value: datad[i]['IdSeguro'], text: datad[i]['Codigo'] + " - " + datad[i]['Nombre'] + " - " + estado }));
            }
        },
        error: function (data) {
            var r = data.responseText;
            var errorMessage = r.Message;
            MostrarMensajeGenerico(3, errorMessage);
        }
    });
}

function GuardarPlantilla(activa) {
    var idSeguro = $("#ddlProductos").val();
    var versionDocumento = $("#hiddenVersionPlantilla").val();
    var NombreArchivo = $("#txtNombreNuevaPlantilla").val();
    var CamposPlantilla = ObtenerCamposPlantilla();
    if (VaidarPlantillaGuardar()) {
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        var urlServicio;
        var parametrosServicio;
        if (!registroAutorizaDual.requiereAutorizacion) {
            urlServicio = 'ParametrizacionPlantilla.aspx/GuardarPlantilla';
            parametrosServicio = "{IdSeguro:" + idSeguro + ", VersionDocumento:'" + versionDocumento + "', CamposPlantilla:'" + CamposPlantilla + "', nombrePlantilla:'" + NombreArchivo + "', activa:" + activa + "}";
        }
        else {
            urlServicio = 'ParametrizacionPlantilla.aspx/GuardarPlantillaControlDual';
            parametrosServicio = "{IdSeguro:" + idSeguro + ", VersionDocumento:'" + versionDocumento + "', CamposPlantilla:'" + CamposPlantilla + "', nombrePlantilla:'" + NombreArchivo + "', activa:" + activa + ",idMenu:" + registroAutorizaDual.IdMenu + "}";
        }

        $.ajax({
            type: "POST",
            cache: false,
            async: false,
            contentType: "application/json; charset=utf-8",
            url: urlServicio,
            data: parametrosServicio,
            dataType: "json",
            success: function (data) {
            },
            complete: function (data) {
                LimpiarFormulario();
                if (data.responseJSON.d.Error) {
                    validNavigation = true;
                    window.location.href = "ParametrizacionPlantilla.aspx?Mensaje='" + data.responseJSON.d.Mensaje + "'";
                }
                else {
                    ObtenerPlantillasPorSeguro();
                    MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje);
                }
            },
            error: function (data) {
                MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje);
            }
        });
    }
}

function VaidarPlantillaGuardar() {
    var resultado = true;
    var mensaje = "";
    var idSeguro = $("#ddlProductos").val();
    var versionDocumento = "";
    var NombreArchivo = $("#txtNombreNuevaPlantilla").val();
    var CamposPlantilla = ObtenerCamposPlantilla();

    if (idSeguro === "0") {
        mensaje = 'Debe seleccionar un seguro<br/>';
        resultado = false;
    }

    var camposSeleccionados = ObtenerCamposPlantilla();
    if (camposSeleccionados === '') {
        mensaje = mensaje + 'Seleccione los datos asociados a la plantilla<br/>';
        resultado = false;
    }

    if (!ArchivoCargado) {
        mensaje = mensaje + 'No ha cargado un archivo de plantilla<br/>';
        resultado = false;
    }

    if (EstaVacio($('#txtNombreNuevaPlantilla').val())) {
        mensaje = mensaje + 'Debe dar una nombre a la plantilla<br/>';
        resultado = false;
    }

    if (!resultado) {
        MostrarMensajeGenerico(3, mensaje);
    }
    return resultado;
}

function LimpiarFormulario() {
    LimpiarDatosPlantilla();
    LimpiarCamposPlantilla();
    ColapsarDatosParaSeleccionar();
    LimpiarDatosDummie();
    $('#CarguePlantilla').removeAttr('disabled');
}

function LimpiarFormularioParaEditar(editar, data) {
    LimpiarDatosPlantilla();
    LimpiarCamposPlantilla();
    ColapsarDatosParaSeleccionar();
    LimpiarDatosDummie();
    if (editar) {
        CargarDatosEditar(data);
        ArchivoCargado = true;
    }
}

function LimpiarDatosPlantilla() {
    $("#txtNombreNuevaPlantilla").val('');
    var nombrePlantilla = $("[name='lblArchivoCargado']").text('');
}

function ColapsarDatosParaSeleccionar() {
    $('#encabezadoPoliza').removeAttr('aria-expanded');
    $('#encabezadoPoliza').attr("aria-expanded", "false");
    $('#encabezadoPoliza').attr("style", "height: 0px;");

    $('#clientePoliza').removeAttr('aria-expanded');
    $('#clientePoliza').attr("aria-expanded", "false");
    $('#clientePoliza').attr("style", "height: 0px;");

    $('#conyuge').removeAttr('aria-expanded');
    $('#conyuge').attr("aria-expanded", "false");
    $('#conyuge').attr("style", "height: 0px;");

    $('#beneficiarios').removeAttr('aria-expanded');
    $('#beneficiarios').attr("aria-expanded", "false");
    $('#beneficiarios').attr("style", "height: 0px;");

    $('#variablesProducto').removeAttr('aria-expanded');
    $('#variablesProducto').attr("aria-expanded", "false");
    $('#variablesProducto').attr("style", "height: 0px;");
}

function LimpiarCamposPlantilla() {
    var parametros = "";
    $("input[name*='Parametro']").each(function (check) {
        parametros += $("#" + this.id).removeAttr("checked");
    });
}

function LimpiarDatosDummie() {
    $("#BeneficiariosDatosDummie").html('No se han seleccionado marcadores para esta sección');
    $("#ConyugeDatosDummie").html('No se han seleccionado marcadores para esta sección');
    $("#ClientePolizaDatosDummie").html('No se han seleccionado marcadores para esta sección');
    $("#EncabezadoPolizaDatosDummie").html('No se han seleccionado marcadores para esta sección');
    $("#VariableDatosDummie").html('No se han seleccionado marcadores para esta sección');
}

function ObtenerCamposPlantilla() {
    var parametros = "";
    for (var i = 0; i < $("input[name*='Parametro']").length; i++) {
        if ($("input[name*='Parametro']")[i].checked) {
            parametros += $("#" + $("input[name*='Parametro']")[i].id).data("nombrecolumna") + ',';
        }
    }
    return parametros.substring(0, (parametros.length - 1));
}

function MostrarInformacionDummieSeleccionada() {
    LlenarInformacionDummie('EncabezadoPoliza', 'EncabezadoPolizaDatosDummie');
    LlenarInformacionDummie('EncabezadoPolizaCliente', 'ClientePolizaDatosDummie');
    LlenarInformacionDummie('ConyugePolizaDocumento', 'ConyugeDatosDummie');
    LlenarInformacionDummie('BeneficiariosPolizaDocumento', 'BeneficiariosDatosDummie');
    LlenarInformacionDummie('VariablePolizaDocumento', 'VariableDatosDummie');
}

function LlenarInformacionDummie(seccionPoliza, idDivSeccion) {
    IniciarPrecargaBancaSeguros();
    var camposSeleccionados = ObtenerCamposPlantilla();
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionPlantilla.aspx/ObtenerTablaDummie",
        data: "{camposSeleccionados: '" + camposSeleccionados + "', seccionPoliza:'" + seccionPoliza + "', idSeguro: '" + $('#ddlProductos').val() + "'}",
        dataType: "json",
        success: function (data) {
        },
        complete: function (data) {
            DetenerPrecargaBancaSeguros();
            $("#" + idDivSeccion).html(data.responseJSON.d);
        },
        error: function (data) {
            DetenerPrecargaBancaSeguros();
            var r = data.responseText;
            var errorMessage = r.Message;
            MostrarMensajeGenerico(3, errorMessage);
        }
    });
}

function PreviewDocumento() {
    IniciarPrecargaBancaSeguros();
    if (!ArchivoCargado) {
        MostrarMensajeGenerico(3, 'No ha cargado un archivo de plantilla');
        return false;
    }

    if (EstaVacio($('#txtNombreNuevaPlantilla').val())) {
        MostrarMensajeGenerico(3, 'Debe dar una nombre a la plantilla');
        return false;
    }

    var camposSeleccionados = ObtenerCamposPlantilla();
    if (camposSeleccionados.length == 0) {
        MostrarMensajeGenerico(3, 'Seleccione los datos asociados a la plantilla');
        return false;
    }

    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionPlantilla.aspx/PrevisualizarPlantilla",
        data: "{CamposSeleccionados: '" + camposSeleccionados + "', idSeguro: '" + $('#ddlProductos').val() + "'}",
        dataType: "json",
        success: function (data) {
        },
        complete: function (data) {
            DetenerPrecargaBancaSeguros();
            if (!data.responseJSON.d.Error) {
                $("#iframePlantilla").attr('src', data.responseJSON.d.Mensaje);
                $('#modDocumentoPolizaPreview').modal('show');
            }
            else {
                MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje);
            }
        },
        error: function (data) {
            MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje);
        }
    });
}

function PrevisualizarPlantillaSeleccionada(IdDocumentoPoliza) {
    IniciarPrecargaBancaSeguros();
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionPlantilla.aspx/PrevisualizarPlantillaSeleccion",
        data: "{idDocumentoPoliza: '" + IdDocumentoPoliza + "', idSeguro: '" + $('#ddlProductos').val() + "'}",
        dataType: "json",
        success: function (data) {
        },
        complete: function (data) {
            DetenerPrecargaBancaSeguros();
            if (!data.responseJSON.d.Error) {
                $("#iframePlantilla").attr('src', data.responseJSON.d.Mensaje);
                $('#modDocumentoPolizaPreview').modal('show');
            }
            else {
                MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje);
            }
        },
        error: function (data) {
            MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje);
        }
    });
}

function ObtenerPlantillasPorSeguro() {
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionPlantilla.aspx/ObtenerPlantillasSeguro",
        data: "{idSeguro: '" + $('#ddlProductos').val() + "'}",
        dataType: "json",
        success: function (data) {
        },
        complete: function (data) {
            CargarGrillaPlantillasPorSeguro(data.responseJSON.d);
            ObtenerDatosVariablesPorSeguro();
        },
        error: function (data) {
            var r = data.responseText;
            var errorMessage = r.Message;
            MostrarMensajeGenerico(3, errorMessage);
        }
    });
}

function ObtenerDatosVariablesPorSeguro() {
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionPlantilla.aspx/ConsultarVariablesActivasProducto",
        data: "{idSeguro: '" + $('#ddlProductos').val() + "'}",
        dataType: "json",
        success: function (data) {
        },
        complete: function (data) {
            CargarTablaDatosVariables(data.responseJSON.d);
        },
        error: function (data) {
            var r = data.responseText;
            var errorMessage = r.Message;
            MostrarMensajeGenerico(3, errorMessage);
        }
    });
}

function pasoDummie(check) {
    if ($(check).is(":checked")) {
        LlenarInformacionDummie('VariablesPolizaDocumento', 'VariableDatosDummie');
    }
}

function CargarTablaDatosVariables(data) {
    $("variablesProducto").collapse("show");
    $('#variablesProducto').empty();
    $('#variablesProducto').append("<table class='table'></table>");
    var table = $('#variablesProducto').children();
    table.append("<tr><th>Campo</th><th colspan='2'>Marcador para la plantilla</th></tr>");
    for (var i = 0; i < data.length; i++) {
        var orden = data[i].Orden;
        table.append("<tr><td>" + data[i].NombreCampo + " </td><td>./VariablesPolizaDocumento/CampoVariable" + orden +
            "</td><td><input type='checkbox' " +
            " class ='VariablesPolizaDocumento' " +
            " name='ParametroCampoVariable" + orden + "'" +
            " id='ParametrochkCampoVariable" + orden + "'" +
            " data-nombrecolumna='CampoVariable" + orden + "' /></td></tr>");
    }
    $("variablesProducto").collapse("hide");
}

function CargarGrillaPlantillasPorSeguro(DocumentosPoliza) {
    var result = DocumentosPoliza;
    oSettings = oTableReporte.fnSettings();
    oTableReporte.fnClearTable(this);
    var auto;
    var est;
    for (var i = 0; i < result.length; i++) {
        if (new Date(parseInt(result[i].FechaCreacion.substr(6), 0)).toString("MM/dd/yyyy") === "01/01/1") {
            result[i].FechaCreacion = '';
        } else {
            result[i].FechaCreacion = ConvertJsonToDate(new Date(parseInt(result[i].FechaCreacion.substr(6), 0)));
        }

        FilaPoliza = {
            Nombreplantilla: result[i].NombreArchivo,
            Version: result[i].VersionDocumento,
            FechaCreacion: result[i].FechaCreacion,
            PlantillaActiva: "<input type='checkbox' name='DocumentoPlantillaActivo" + result[i].IdDocumentoPoliza + "' id='chkDocumentoPlantillaActivo" + result[i].IdDocumentoPoliza + "' data-IdDocumentoPoliza='" + result[i].IdDocumentoPoliza + "'" + ValidarCampoPlantillaActiva(result[i].Activa) + " OnClick='ActivarPlantilla(" + result[i].IdDocumentoPoliza + ");'/>",
            DescargarPlantilla: "<input type='button' id='btnDescargarPlantilla" + result[i].IdDocumentoPoliza + "' value='DescargarPlantilla' data-IdDocumentoPoliza='" + result[i].IdDocumentoPoliza + "' OnClick='DescargarPlantilla(" + result[i].IdDocumentoPoliza + ");'/>",
            Previsualizar: "<input type='button' id='btnPrevisualizar" + result[i].IdDocumentoPoliza + "' value='Previsualizar' data-IdDocumentoPoliza='" + result[i].IdDocumentoPoliza + "' OnClick='PrevisualizarPlantillaSeleccionada(" + result[i].IdDocumentoPoliza + ");'/>",
            Editar: "<input type='button' id='btnEditar" + result[i].IdDocumentoPoliza + "' value='Editar campos plantilla' data-IdDocumentoPoliza='" + result[i].IdDocumentoPoliza + "' OnClick='EditarPlantilla(" + result[i].IdDocumentoPoliza + "," + result[i].Activa + ");'/>",
            Eliminar: "<input type='button' id='btnEliminar" + result[i].IdDocumentoPoliza + "' value='Eliminar' data-IdDocumentoPoliza='" + result[i].IdDocumentoPoliza + "' OnClick='EliminarPlantilla(" + result[i].IdDocumentoPoliza + ");'/>"
        }

        oTableReporte.oApi._fnAddData(oSettings, FilaPoliza);
    }

    if (result.length === 0) esActivaPlantilla = true;

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTableReporte.fnDraw();
}

function ValidarCampoPlantillaActiva(activa) {
    if (activa) {
        return "checked='checked'";
    }
    else {
        return "";
    }
}

function ActivarPlantilla(idDocumentoPoliza) {
    IniciarPrecargaBancaSeguros();
    if (ValidarEstadoDocumentos()) {
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        var urlServicio;
        var parametrosServicio;
        if (!registroAutorizaDual.requiereAutorizacion) {
            urlServicio = 'ParametrizacionPlantilla.aspx/ActualizarEstadoPlantilla';
            parametrosServicio = "{idDocumentoPlantilla:" + idDocumentoPoliza + "}";
        }
        else {
            urlServicio = 'ParametrizacionPlantilla.aspx/ActualizarEstadoPlantillaControlDual';
            parametrosServicio = "{idDocumentoPlantilla:" + idDocumentoPoliza + ",idMenu:" + registroAutorizaDual.IdMenu + "}";
        }
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: urlServicio,
            data: parametrosServicio,
            dataType: "json",
            success: function (data) {
            },
            complete: function (data) {
                DetenerPrecargaBancaSeguros();
                if (!data.responseJSON.d.Error) {
                    MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje);
                }
                else {
                    MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje);
                }
            },
            error: function (data) {
                MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje);
            }
        });
    }
    ObtenerPlantillasPorSeguro();
}

function ValidarEstadoDocumentos() {
    var chekeada = false;
    $("input[name*='DocumentoPlantillaActivo']").each(function (check) {
        if (this.checked) {
            chekeada = true;
        }
    });
    if (!chekeada) {
        MostrarMensajeGenerico(3, 'No se puede dejar todos los documentos inactivos');
        return false
    }
    return true;
}

function EliminarPlantilla(IdDocumentoPoliza) {
    if (ValidarEliminarPlantilla(IdDocumentoPoliza)) {
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        var urlServicio;
        var parametrosServicio;
        if (!registroAutorizaDual.requiereAutorizacion) {
            urlServicio = 'ParametrizacionPlantilla.aspx/EliminarPlantilla';
            parametrosServicio = "{idDocumentoPlantilla:" + IdDocumentoPoliza + "}";
        }
        else {
            urlServicio = 'ParametrizacionPlantilla.aspx/EliminarPlantillaControlDual';
            parametrosServicio = "{idDocumentoPlantilla:" + IdDocumentoPoliza + ",idMenu:" + registroAutorizaDual.IdMenu + "}";
        }
        IniciarPrecargaBancaSeguros();
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: urlServicio,
            data: parametrosServicio,
            dataType: "json",
            success: function (data)
            { },
            complete: function (data) {
                DetenerPrecargaBancaSeguros();
                if (!data.responseJSON.d.Error) {
                    if (!registroAutorizaDual.requiereAutorizacion) {
                        ObtenerPlantillasPorSeguro();
                    }
                    else {
                        MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje);
                    }
                }
                else {
                    MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje);
                }
            },
            error: function (data) {
                DetenerPrecargaBancaSeguros();
                MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje);
            }
        });
    }
}

function ValidarEliminarPlantilla(IdDocumentoPoliza) {
    var resultado = true;
    var attr = $("#chkDocumentoPlantillaActivo" + IdDocumentoPoliza).attr('checked');
    if (attr === 'checked') {
        MostrarMensajeGenerico(3, 'No se puede eliminar la plantilla activa');
        return false;
    }
    resultado = ValidarNumeroMinimoDocumentos();
    return resultado;
}

function ValidarNumeroMinimoDocumentos() {
    var cantidadRegistros = 0;
    $("input[name*='DocumentoPlantillaActivo']").each(function (check) {
        cantidadRegistros += 1;
    });
    if (cantidadRegistros === 1) {
        MostrarMensajeGenerico(3, 'Solo existe una plantilla para este producto, no se puede eliminar');
        return false;
    }
    return true;
}

function DescargarPlantilla(IdDocumentoPoliza) {
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionPlantilla.aspx/DescargarPlantilla",
        data: "{idDocumentoPoliza: '" + IdDocumentoPoliza + "'}",
        dataType: "json",
        success: function (data) {
        },
        complete: function (data) {
            if (!data.responseJSON.d.Error) {
                $("#iframeDocumentoPlantilla").attr('src', data.responseJSON.d.Mensaje);
            }
            else {
                MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje);
            }
        },
        error: function (data) {
            MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje);
        }
    });
}

function EditarPlantilla(IdDocumentoPoliza, EsActiva) {
    esActivaPlantilla = EsActiva;
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionPlantilla.aspx/ObtenerPlantillaEdicion",
        data: "{idDocumentoPoliza: '" + IdDocumentoPoliza + "'}",
        dataType: "json",
        success: function (data) {
        },
        complete: function (data) {
            LimpiarFormularioParaEditar(true, data);
            $('#btnPrevisualizar').off('click');
            $('#btnPrevisualizar').click(function () {
                ArchivoCargado = true;
                PrevisualizarPlantillaSeleccionada(IdDocumentoPoliza);
            });
            $('#CarguePlantilla').attr('disabled', 'disabled');
        },
        error: function (data) {
            MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje);
        }
    });
}

function UbicarCamposSeleccionados(camposPlantilla) {
    var campos = camposPlantilla.split(",");
    for (var i = 0; i < campos.length; i++) {
        $("input[name='Parametro" + campos[i] + "']").removeAttr('checked');
        $("input[name='Parametro" + campos[i] + "']")[0].checked = true;
    }
    //MostrarInformacionDummieSeleccionada();
}

function CargarDatosEditar(data) {
    UbicarCamposSeleccionados(data.responseJSON.d.CamposPlantilla);
    $("#txtNombreNuevaPlantilla").val(data.responseJSON.d.NombreArchivo);
    $("[name='lblArchivoCargado']").text(data.responseJSON.d.NombreArchivo);
    $("#hiddenVersionPlantilla").val(data.responseJSON.d.VersionDocumento);
}