var oTableReporte;
var cvicoclick = false;
var rowgvReporte;

$(document).ready(function () {
    if (initSession()) {
        IniciarPrecargaBancaSeguros();
        InicializarGrilla();
        CargarInicialVisual();
        ConsularTodosLosCanales();
        SelecionarFila();
        ValidarControlDual();
    }
    else {
        IniciarPrecargaBancaSeguros();
        MostrarModalConfirmar(3, "Usted no se encuentra logueado o con permisos para acceder a esa pagina", 'sessLogOut()', 'sessLogOut()');
    }
});

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
            { "data": "IdCanalVenta", "visible": false, "searchable": false },
            { "data": "CodigoCanalVenta" },
            { "data": "NombreCanalVenta" },
            { "data": "Estado" },
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

function CargarInicialVisual() {
    $('input[name=btnAct]').hide();
}

function ConsularTodosLosCanales() {
    var listaCanales;

    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionCanalVenta.aspx/ConsultarTodoLosCanalesVenta",
        dataType: "json",
        success: function (data) {
            listaCanales = data.d;
        },
        complete: function (data) {
            if (listaCanales != null) {
                if (listaCanales.length > 0) {
                    CargarGrillaCanal(listaCanales);
                } else {
                    MostrarMensajeGenerico(2, 'No hay canales de venta parametrizados')
                }
            } else {
                MostrarMensajeGenerico(2, 'No hay canales de venta parametrizados')
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

function CargarGrillaCanal(listaCanales) {
    oSettings = oTableReporte.fnSettings();
    oTableReporte.fnClearTable(this);
    var estadoCanal = "";
    for (var i = 0; i < listaCanales.length; i++) {

        if (listaCanales[i].Activo) {
            estadoCanal = "ACTIVO";
        } else {
            estadoCanal = "INACTIVO";
        }

        FilaCanal = {
            IdCanalVenta: listaCanales[i].IdCanalVenta,
            CodigoCanalVenta: listaCanales[i].Codigo,
            NombreCanalVenta: listaCanales[i].Nombre,
            Estado: estadoCanal,
            Acciones: '<img src=../Imagenes/edit.jpg width=20px height=20px title="Actualizar Canal de Venta" id="cvico" onclick="cvicoclick=true">'
        }

        oTableReporte.oApi._fnAddData(oSettings, FilaCanal);
    }

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTableReporte.fnDraw();
}

function SelecionarFila() {
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
    $('#txtCodigoCanalVenta').attr('disabled', 'disabled');

    $('#txtIdCanalVenta').val(DatosFilas.IdCanalVenta);
    $('#txtCodigoCanalVenta').val(DatosFilas.CodigoCanalVenta);
    $('#txtNombreCanalVenta').val(DatosFilas.NombreCanalVenta);

    if (DatosFilas.Estado === "ACTIVO") {
        document.getElementById("chEstado").checked = true;
    } else {
        document.getElementById("chEstado").checked = false;
    }
}

function ActualizarCanal() {
    var canalVenta = {};
    var resultado = {};

    ValidaDiv('formConsulta');
    var Resultado = $('#formConsulta').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        canalVenta = LlenarEntidadCanalVenta();
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionCanalVenta.aspx/ActualizaCanalVentaPorId",
            data: "{canalVenta:" + JSON.stringify(canalVenta) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (resultado.Error) {
                    



                } else {
                    ConsularTodosLosCanales();
                    Cancelar();
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
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
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Actualizar', 'CanalVenta', JSON.stringify(canalVenta), '');
        }
    }
}

function GuardarCanal() {
    var canalVenta = {};
    var resultado;

    ValidaDiv('formConsulta');
    var Resultado = $('#formConsulta').parsley().validate();
    if (Resultado) {
        canalVenta = LlenarEntidadCanalVenta();
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionCanalVenta.aspx/GuardarCanalVenta",
            data: "{canalVenta:" + JSON.stringify(canalVenta) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (resultado.Error === undefined) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje) /*3, data.responseText);*/
                } else if (resultado.Error) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                } else {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                    ConsularTodosLosCanales();
                    Cancelar();
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
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Insertar', 'CanalVenta', JSON.stringify(canalVenta), '');
        }
    }
}

function LlenarEntidadCanalVenta() {
    var CanalVenta = {};

    if ($("#txtIdCanalVenta").val() === "") {
        CanalVenta.IdCanalVenta = 0;
    } else {
        CanalVenta.IdCanalVenta = $("#txtIdCanalVenta").val();
    }

    CanalVenta.Codigo = $("#txtCodigoCanalVenta").val();
    CanalVenta.Nombre = $("#txtNombreCanalVenta").val();

    if ($('#chEstado').is(':checked')) {
        CanalVenta.Activo = true;
    } else {
        CanalVenta.Activo = false;
    }

    return CanalVenta;
}

function Cancelar() {
    $("#txtCodigoCanalVenta").val("");
    $("#txtNombreCanalVenta").val("");
    document.getElementById("chEstado").checked = false;
    $('input[name=btnAct]').hide();
    $('input[name=btnAgr]').show();
    $('#txtCodigoCanalVenta').removeAttr('disabled', 'disabled');
}
