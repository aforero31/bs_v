$(document).ready(function () {
    if (initSession()) {
        IniciarPrecargaBancaSeguros();
        ConsultarIPC();
        ValidarControlDual();
    }
    else {
        IniciarPrecargaBancaSeguros();
        MostrarModalConfirmar(3, "Usted no se encuentra logueado o con permisos para acceder a esa pagina", 'sessLogOut()', 'sessLogOut()');
    }
});

$('#txtValorIPC').on('keypress', function (e) {
    // Backspace = 8, Enter = 13, ’0′ = 48, ’9′ = 57, ‘.’ = 46 ','=188
    var field = $(this);
    key = e.keyCode ? e.keyCode : e.which;

    if (key === 8) return true;
    if (key > 47 && key < 58) {
        if (field.val() === "") return true;
        var existePto = (/[.]/).test(field.val());
        if (existePto === false) {
            regexp = /.[0-9]{10}$/;
        }
        else {
            regexp = /.[0-9]{2}$/;
        }

        return !(regexp.test(field.val()));
    }
    if (key === 188) {
        if (field.val() === "") return false;
        regexp = /^[0-9]+$/;
        return regexp.test(field.val());
    }
    return false;
});

function GuardarIPC() {
    var ipc = {};
    var resultado;
    ValidaComa();
    ValidaDiv('formIPC');
    var Resultado = $('#formIPC').parsley().validate();
    if (Resultado) {
        ipc = LlenarEntidadIPC();
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionIPC.aspx/GuardarIPC",
            data: "{ipc:" + JSON.stringify(ipc) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (resultado.Error === undefined) {
                    MostrarMensajeGenerico(3, 'Error');
                } else if (resultado.Error) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                } else {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                    ConsultarIPC();
                    //Cancelar();
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
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Insertar', 'IPC', JSON.stringify(ipc), '');
        }
    }
}

function ActualizarIPC() {
    var ipc = {};
    var resultado = {};

    ValidaDiv('formIPC');
    var Resultado = $('#formIPC').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        ipc = LlenarEntidadIPC();

        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionIPC.aspx/ActualizaIPC",
            data: "{canalVenta:" + JSON.stringify(ipc) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (resultado.Error) {
                    MostrarMensajeGenerico(3, resultado.Mensaje);
                } else {
                    //ConsularTodosLosCanales();
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
}

function ConsultarIPC() {
    var ipc = {};
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionIPC.aspx/ConsultarIPC",
        dataType: "json",
        success: function (data) {
            ipc = data.d;
        },
        complete: function (data) {
            year = ipc.AnoActual;
            if (ipc.IdIpc != 0) {
                if (ipc.Ano === year)
                    CargarDatosAActualizar(ipc);
                else
                    CargarSinDatos(year);
            } else {
                CargarSinDatos(year);
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

function LlenarEntidadIPC() {
    var Ipc = {};

    if ($("#txtIdIPC").val() === "") {
        Ipc.IdIPC = 0;
    }
    else {
        Ipc.idIPC = $("#txtIdIPC").val();
    }

    Ipc.Ano = $("#txtAnoIPC").val();
    Ipc.Valor = $("#txtValorIPC").val();

    return Ipc;
}

function CargarDatosAActualizar(DatosFilas) {
    $('#formBotones').hide();
    $('input[name=btnAgr]').hide();
    $('#txtAnoIPC').attr('disabled', 'disabled');
    $('#txtValorIPC').attr('disabled', 'disabled');
    $('#txtIdIPC').val(DatosFilas.IdIpc);
    $('#txtAnoIPC').val(DatosFilas.Ano);
    $('#txtValorIPC').val(DatosFilas.Valor);
    $('#ipcMessage').show();
    $('#ipcMessage').css('color', 'red');
}

function CargarSinDatos(year) {
    $('#txtIdIPC').val("");
    $('#txtAnoIPC').val(year);
    $('#txtAnoIPC').attr('disabled', 'disabled');
    $('#txtValorIPC').val("");
    $('#formBotones').show();
    $('#ipcMessage').hide();

}

function Cancelar() {
    $("#txtAñoIPC").val("");
    $("#txtValorIPC").val("");
    $('input[name=btnAgr]').show();
    $('#ipcMessage').hide();
}

function ValidaComa() {
    var valor = $("#txtValorIPC").val();
    var substring = ',';
    if (valor.indexOf(substring)) {
        valor = valor.replace(/\,/i, '.');

    }
    $("#txtValorIPC").val(valor);
}