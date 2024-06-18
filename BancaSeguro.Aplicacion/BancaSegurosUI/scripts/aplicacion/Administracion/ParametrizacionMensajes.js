var oTableReporte;
var cvicoclick = false;
var rowgvReporte;

$(document).ready(function () {
    if (initSession()) {
        IniciarPrecargaBancaSeguros();
        CargarCatalogo();
        InicializarGrilla();
        SeleccionarFila();
        $('input[name=btnAct]').hide();
        ValidarControlDual();
        OcultarPanel("panelGrillaReporte", true);
    }
    else {
        IniciarPrecargaBancaSeguros();
        MostrarModalConfirmar(3, "Usted no se encuentra logueado o con permisos para acceder a esa pagina", 'sessLogOut()', 'sessLogOut()');
    }
});

function CargarCatalogo() {

    $('#ddlEvento').empty();
    $('#ddlEvento').append($('<option>', { value: "", text: '--Seleccione--' }));
    $('#ddlEventoConsulta').empty();
    $('#ddlEventoConsulta').append($('<option>', { value: "", text: '--Seleccione--' }));

    DataCatalogo = ConsultarCatalogo("SEG_Evento");
    if (DataCatalogo != null && DataCatalogo !== undefined) {
        LlenarListaDesplegable(DataCatalogo.ListTablaEvento, 'ddlEvento', 'IdEvento', 'Eventos');
        LlenarListaDesplegable(DataCatalogo.ListTablaEvento, 'ddlEventoConsulta', 'IdEvento', 'Eventos');
    }
}

function ConsultarCatalogo(NombreTabla) {
    var DataCatalogo;
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionMensajes.aspx/ConsultarCatalogo",
        data: "{'NombreTabla':'" + NombreTabla + "'}",
        dataType: "json",
        success: function (data) {
        },
        complete: function (data) {
            DataCatalogo = data.responseJSON.d
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage);
            DetenerPrecargaBancaSeguros();
        }
    });

    return DataCatalogo;
}

function InicializarGrilla() {
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
            { "data": "IdMensaje", "visible": false, "searchable": false },
            { "data": "Llave" },
            { "data": "IdEvento", "visible": false, "searchable": false },
            { "data": "Eventos" },
            { "data": "IdTipoMensaje", "visible": false, "searchable": false },
            { "data": "TipoMensaje" },
            { "data": "Mensaje" },
            { "data": "Acciones" }
        ],
        "aoColumnDefs": [
            {
                'bSortable': false,
                'aTargets': [0]
            } //disables sorting for column one
        ],
        'iDisplayLength': 12,
        "sPaginationType": "full_numbers",
        "dom": 'T<"clear">lfrtip',
    });

}

function CargarGrillaMensajes(listaMensajes) {

    oSettings = oTableReporte.fnSettings();
    oTableReporte.fnClearTable(this);
    for (var i = 0; i < listaMensajes.length; i++) {
        var IdTipoMensaje = listaMensajes[i].IdTipoMensaje;
        var tipoMensaje;
        var tipoAlerta;
        switch (IdTipoMensaje) {
            case 1:
                tipoMensaje = "Informativo"
                break;
            case 2:
                tipoMensaje = "Advertencia"
                break;
            case 3:
                tipoMensaje = "Error"
                break;
        }
        FilaMensaje = {
            IdMensaje: listaMensajes[i].IdMensaje,
            Llave: listaMensajes[i].Llave,
            IdEvento: listaMensajes[i].IdEvento,
            Eventos: listaMensajes[i].Eventos,
            IdTipoMensaje: listaMensajes[i].IdTipoMensaje,
            TipoMensaje: tipoMensaje,
            Mensaje: listaMensajes[i].DescripcionMensaje,
            Acciones: '<img src=../Imagenes/edit.jpg width=20px height=20px title="Actualizar Mensaje" id="cvico" onclick="cvicoclick=true">'
        }

        oTableReporte.oApi._fnAddData(oSettings, FilaMensaje);
    }

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTableReporte.fnDraw();
}

function SeleccionarFila() {
    var table = $('#gvReporte').DataTable();
    $('#gvReporte tbody').on('click', 'tr', function () {
        rowgvReporte = $(this).index();
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }

        if (cvicoclick) {
            cvicoclick = false;
            var DatosFila = table.fnGetData(this);
            CargarDatosAActualizar(DatosFila);
        }
    });
}

function CargarDatosAActualizar(DatosFilas) {
    $('input[name=btnAct]').show();
    $('input[name=btnAgr]').hide();

    $('#txtIdMensaje').val(DatosFilas.IdMensaje);
    $('#Llave').val(DatosFilas.Llave);
    $('#ddlEvento').val(DatosFilas.IdEvento);
    $('#ddlTipoMensaje').val(DatosFilas.IdTipoMensaje);
    $('#taMensaje').val(DatosFilas.Mensaje);
    $('#Llave').attr("disabled", true);
    $('#ddlEvento').attr("disabled", true);
    $('#ddlTipoMensaje').attr("disabled", true);
    $('#modalMensaje').modal('show');
}

function ConsultarTodosLosMensajes() {
    var listaMensajes;
    oTableReporte.fnClearTable(this);
    var Mensaje = {};
    Mensaje.Llave = $('#txtLlaveConsulta').val();

    if ($('#ddlEventoConsulta').val() === "") {
        Mensaje.IdEvento = 0;
    } else {
        Mensaje.IdEvento = $('#ddlEventoConsulta').val();
    }

    if ($('#ddlTipoMensajeConsulta').val() === "") {
        Mensaje.IdTipoMensaje = 0;
    } else {
        Mensaje.IdTipoMensaje = $('#ddlTipoMensajeConsulta').val();
    }

    IniciarPrecargaBancaSeguros();
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionMensajes.aspx/ConsultarMensajes",
        data: "{mensaje:" + JSON.stringify(Mensaje) + "}",
        dataType: "json",
        success: function (data) {
            listaMensajes = data.d;
        },
        complete: function (data) {
            if (listaMensajes != null) {
                if (listaMensajes.length > 0) {
                    if (listaMensajes[0].Resultado.Error) {
                        MostrarMensajeGenerico(listaMensajes[0].Resultado.IdTipoMensaje, listaMensajes[0].Resultado.Mensaje)
                    } else {
                        CargarGrillaMensajes(listaMensajes);
                    }
                } else {
                    MostrarMensajeGenerico(2, 'No hay mensajes parametrizados')
                }
            } else {
                MostrarMensajeGenerico(2, 'No hay mensajes parametrizados')
            }

            DetenerPrecargaBancaSeguros();
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage)
            DetenerPrecargaBancaSeguros();
        }
    });
}

function GuardarMensaje() {
    var mensajes = {};
    var resultado;
    ValidaDiv('formMensajes');
    var Resultado = $('#formMensajes').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        mensajes = LlenarEntidadMensaje();
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
            $.ajax({
                type: "POST",
                cache: false,
                async: true,
                contentType: "application/json; charset=utf-8",
                url: "ParametrizacionMensajes.aspx/InsertarMensaje",
                data: "{mensaje:" + JSON.stringify(mensajes) + "}",
                dataType: "json",
                success: function (data) {
                    resultado = data.d;
                },
                complete: function (data) {
                    if (resultado.Error === undefined) {
                        MostrarMensajeGenerico(3, data.responseText);
                    } else if (resultado.Error) {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                    } else {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                        Cancelar();
                        ConsultarTodosLosMensajes();
                    }

                    DetenerPrecargaBancaSeguros();
                },
                error: function (data) {
                    var errorMessage = data.responseText;
                    MostrarMensajeGenerico(3, errorMessage);
                    DetenerPrecargaBancaSeguros();
                }
            });
        } else {
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Insertar', 'Mensaje', JSON.stringify(mensajes), '');
            Cancelar();
        }
    } else {
        $('li.parsley-required').show();
    }
}

function ActualizarMensaje() {
    var mensaje = {};
    var resultado = {};

    ValidaDiv('formMensajes');
    var Resultado = $('#formMensajes').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        mensaje = LlenarEntidadMensaje();
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
            $.ajax({
                type: "POST",
                cache: false,
                async: true,
                contentType: "application/json; charset=utf-8",
                url: "ParametrizacionMensajes.aspx/ActualizarMensaje",
                data: "{mensaje:" + JSON.stringify(mensaje) + "}",
                dataType: "json",
                success: function (data) {
                    resultado = data.d;
                },
                complete: function (data) {

                    if (resultado.Error === undefined) {
                        MostrarMensajeGenerico(3, data.responseText);
                    } else if (resultado.Error) {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                    } else {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                        Cancelar();
                        ConsultarTodosLosMensajes();
                    }

                    DetenerPrecargaBancaSeguros();
                },
                error: function (data) {
                    var errorMessage = data.responseText;
                    MostrarMensajeGenerico(3, errorMessage);
                    DetenerPrecargaBancaSeguros();
                }
            });
        }
        else {
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Actualizar', 'Mensaje', JSON.stringify(mensaje), '');
            Cancelar();
        }
    }
}

function LlenarEntidadMensaje() {
    var Mensaje = {};

    if ($("#txtIdMensaje").val() === "") {
        Mensaje.IdMensaje = 0;
    }
    else {
        Mensaje.IdMensaje = $("#txtIdMensaje").val();
    }

    Mensaje.Llave = $('#Llave').val();
    Mensaje.IdEvento = $('#ddlEvento').val();
    Mensaje.IdTipoMensaje = $('#ddlTipoMensaje').val();
    Mensaje.DescripcionMensaje = $('#taMensaje').val();

    return Mensaje;
}

function Cancelar() {
    $("#txtIdMensaje").val("");
    $("#Llave").val("");
    $("#ddlEvento").val("");
    $("#ddlTipoMensaje").val("");
    $("#taMensaje").val("");
    $('input[name=btnAgr]').show();
    $('input[name=btnAct]').hide();
    $('#Llave').attr("disabled", false);
    $('#ddlEvento').attr("disabled", false);
    $('#ddlTipoMensaje').attr("disabled", false);
    $('#modalMensaje').modal('hide');

    $('li.parsley-required').hide();
    $('#Llave').removeClass('parsley-error');
    $('#ddlEvento').removeClass('parsley-error');
    $('#ddlTipoMensaje').removeClass('parsley-error');
    $('#taMensaje').removeClass('parsley-error');
}

function InsertarNuevoMensaje() {
    $('#modalMensaje').modal('show');
}

function ConsultarMensaje() {
    ConsultarTodosLosMensajes();
    OcultarPanel("panelGrillaReporte", false);
}

function LimpiarConsulta() {
    $("#txtLlaveConsulta").val("");
    $("#ddlEventoConsulta").val("");
    $("#ddlTipoMensajeConsulta").val("");
    oTableReporte.fnClearTable(this);
    OcultarPanel("panelGrillaReporte", true);
}