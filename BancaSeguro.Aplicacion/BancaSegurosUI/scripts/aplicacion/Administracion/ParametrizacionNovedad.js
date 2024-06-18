var oTableReporte;
var cvicoclick = false;
var rowgvReporte;

$(document).ready(function () {
    if (initSession()) {
        IniciarPrecargaBancaSeguros();
        InicializarGrilla();
        ConsultarTodasLasNovedades();
        SeleccionarFila();
        $('#message').hide();
        $('input[name=btnAct]').hide();
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
            { "data": "IdTipoNovedad", "visible": false, "searchable": false },
            { "data": "CodigoTipoNovedad" },
            { "data": "NombreTipoNovedad" },
            { "data": "Activo" },
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

function CargarGrillaNovedad(listaNovedades) {
    oTableReporte.fnClearTable(this);
    oSettings = oTableReporte.fnSettings();
    var estadoNovedad = "";
    for (var i = 0; i < listaNovedades.length; i++) {

        if (listaNovedades[i].Activo) {
            estadoNovedad = "ACTIVO";
        } else {
            estadoNovedad = "INACTIVO";
        }

        FilaNovedad = {
            IdTipoNovedad: listaNovedades[i].IdTipoNovedad,
            CodigoTipoNovedad: listaNovedades[i].CodigoTipoNovedad,
            NombreTipoNovedad: listaNovedades[i].NombreTipoNovedad,
            Activo: estadoNovedad,
            Acciones: '<img src=../Imagenes/edit.jpg width=20px height=20px title="Actualizar Novedad" id="cvico" onclick="cvicoclick=true">'
        }

        oTableReporte.oApi._fnAddData(oSettings, FilaNovedad);
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
    $('#txtCodigoNovedad').attr('disabled', true);
    $('#txtNombreNovedad').attr('disabled', true);

    $('#txtIdNovedad').val(DatosFilas.IdTipoNovedad);
    $('#txtCodigoNovedad').val(DatosFilas.CodigoTipoNovedad);
    $('#txtNombreNovedad').val(DatosFilas.NombreTipoNovedad);

    if (DatosFilas.Activo === "ACTIVO") {
        $("#cmbEstadoNovedad").val('true');
    } else {
        $("#cmbEstadoNovedad").val('false');
    }
}

function ConsultarTodasLasNovedades() {
    var listaNovedades;

    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionNovedad.aspx/ConsultarTodasLasNovedades",
        dataType: "json",
        success: function (data) {
            listaNovedades = data.d;
        },
        complete: function (data) {
            if (listaNovedades != null) {
                if (listaNovedades.length > 0) {
                    CargarGrillaNovedad(listaNovedades);
                } else {
                    MostrarMensajeGenerico(2, 'No hay novedades parametrizadas')
                }
            } else {
                MostrarMensajeGenerico(2, 'No hay novedades parametrizadas')
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

function GuardarNovedad() {
    var novedad = {};
    var resultado;
    ValidaDiv('formNovedad');
    var Resultado = $('#formNovedad').parsley().validate();
    if (Resultado) {
        novedad = LlenarEntidadNovedad();
        var mensaje = $('#message').val();
        if (mensaje === "") {
            var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
            if (!registroAutorizaDual.requiereAutorizacion) {
                $.ajax({
                    type: "POST",
                    cache: false,
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    url: "ParametrizacionNovedad.aspx/InsertarNovedad",
                    data: "{novedad:" + JSON.stringify(novedad) + "}",
                    dataType: "json",
                    success: function (data) {
                        resultado = data.d;
                    },
                    complete: function (data) {
                        if (resultado.Error !== undefined) {
                            if (resultado.Error) {
                                MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                            } else {
                                MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                                ConsultarTodasLasNovedades();
                                Cancelar();
                            }
                        }
                        DetenerPrecargaBancaSeguros();
                    },
                    error: function (data) {
                        var errorMessage = data.responseText;
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                        DetenerPrecargaBancaSeguros();
                    }
                });
            }
            else {
                AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Insertar', 'Novedad', JSON.stringify(novedad), '');
            }
        }
    }
}

function LlenarEntidadNovedad() {
    var Novedad = {};

    if ($("#txtIdNovedad").val() === "") {
        Novedad.IdTipoNovedad = 0;
    }
    else {
        Novedad.IdTipoNovedad = $("#txtIdNovedad").val();
    }

    Novedad.CodigoTipoNovedad = $("#txtCodigoNovedad").val();
    if (validaTilde($("#txtNombreNovedad").val())) {
        Novedad.NombreTipoNovedad = $("#txtNombreNovedad").val();
    }
    Novedad.Activo = $("#cmbEstadoNovedad").val();

    return Novedad;
}

function Cancelar() {
    $("#txtIdNovedad").val("");
    $("#txtCodigoNovedad").val("");
    $("#txtNombreNovedad").val("");
    $("#cmbEstadoNovedad").val(-1);
    $('input[name=btnAgr]').show();
    $('input[name=btnAct]').hide();
    $('#txtCodigoNovedad').attr('disabled', false);
    $('#txtNombreNovedad').attr('disabled', false);
}

function ActualizarNovedad() {
    var novedad = {};
    var resultado = {};

    ValidaDiv('formNovedad');
    var Resultado = $('#formNovedad').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        novedad = LlenarEntidadNovedad();
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
            $.ajax({
                type: "POST",
                cache: false,
                async: true,
                contentType: "application/json; charset=utf-8",
                url: "ParametrizacionNovedad.aspx/ActualizarNovedad",
                data: "{novedad:" + JSON.stringify(novedad) + "}",
                dataType: "json",
                success: function (data) {
                    resultado = data.d;
                },
                complete: function (data) {
                    if (!resultado.Error) {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                    } else {
                        ConsultarTodasLasNovedades();
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
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Actualizar', 'Novedad', JSON.stringify(novedad), '');
        }
    }
}

function validaTilde() {
    //var reg = /^([ñáéíóú]{2,60})$/i;
    var reg = /^[a-zA-Z\s]*$/;
    var valor = $("#txtNombreNovedad").val();
    if (reg.test(valor)) {
        $("#message").html("");
        $("#message").hide();
        return true;
    }
    else {
        $("#message").show();
        $("#message").html("La entrada es incorrecta, no se permiten tildes ni caracteres especiales");
        $("#message").css("color", "red");
        return false;
    }
}