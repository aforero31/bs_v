var oTableReporte;
var cvicoclick = false;
var rowgvReporte;

$(document).ready(function () {
    if (initSession()) {
        IniciarPrecargaBancaSeguros();
        InicializarGrilla();
        CargarComboTipoDato();
        CargarInicialVisual();
        ConsultarTodosLosParametros();
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
            { "data": "IdVariable", "visible": false, "searchable": false },
            { "data": "NombreVariable" },
            { "data": "Valor" },
            { "data": "IdTipoDato", "visible": false, "searchable": false },
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

function CargarComboTipoDato() {
    var ListTipoDato;
    IniciarPrecargaBancaSeguros();
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionGeneral.aspx/ConsultarTipoDato",
        dataType: "json",
        success: function (data) {
            ListTipoDato = data.d;
        },
        complete: function (data) {
            if (ListTipoDato !== undefined) {
                for (var i = 0; i < ListTipoDato.length; i++)
                {
                    if (ListTipoDato[i].Nombre === "Catalogo")
                    {
                        ListTipoDato.splice(i, 1);
                    }
                }
                LlenarListaDesplegable(ListTipoDato, 'ddlTipoVariable', "IdTipoDato", "Nombre");
                ConsultarTodasLasValidaciones();
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

function CargarInicialVisual() {
    $('input[name=btnAct]').hide();
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

function ConsultarTodosLosParametros() {
    IniciarPrecargaBancaSeguros();
    var Parametros;

    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionGeneral.aspx/ConsultarTodoLosParamteros",
        dataType: "json",
        success: function (data) {
            Parametros = data.d;
        },
        complete: function (data) {
            if (Parametros !== undefined) {
                CargarGrilla(Parametros);
            } else {
                MostrarMensajeGenerico(3, data.responseText);
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

function CargarGrilla(Parametros) {

    oSettings = oTableReporte.fnSettings();
    oTableReporte.fnClearTable(this);
    var estado = "";
    for (var i = 0; i < Parametros.length; i++) {

        if (Parametros[i].Activo) {
            estado = "ACTIVO";
        } else {
            estado = "INACTIVO";
        }

        FilaPoliza = {
            IdVariable: Parametros[i].IdParametro,
            NombreVariable: Parametros[i].Descripcion,
            IdTipoDato: Parametros[i].IdTipoDato,
            Valor: Parametros[i].Valor,
            Estado: estado,
            Acciones: '<input type="image" src="../imagenes/edit.jpg" width="25" height="25" title="Actualizar Parametro" id="cvico" onclick="cvicoclick=true"/>'
        }

        oTableReporte.oApi._fnAddData(oSettings, FilaPoliza);
    }

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTableReporte.fnDraw();
}

function CargarDatosAActualizar(DatosFila) {
    $('input[name=btnAct]').show();
    $('input[name=btnAgr]').hide();

    $('#txtIdVariable').val(DatosFila.IdVariable);
    $('#txtNombreVariable').val(DatosFila.NombreVariable);
    $('#ddlTipoVariable').val(DatosFila.IdTipoDato);
    $('#txtValor').val(DatosFila.Valor);

    if (DatosFila.Estado === "ACTIVO") {
        document.getElementById("chEstado").checked = true;
    } else {
        document.getElementById("chEstado").checked = false;
    }

    $('#txtNombreVariable').attr('disabled', 'disabled');
    $('#ddlTipoVariable').attr('disabled', 'disabled');

    OcultarError();
    AgregarValidacion();
}

function Actualizar() {
    var Parametro = {};
    var resultado = {};

    ValidaDiv('formConsulta');
    var Resultado = $('#formConsulta').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        Parametro = LlenarEntidadParametro();
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionGeneral.aspx/ActualizaParametroPorId",
            data: "{parametro:" + JSON.stringify(Parametro) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (resultado.Errork__BackingField) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                } else {
                    ConsultarTodosLosParametros();
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
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Actualizar', 'Parametro', JSON.stringify(Parametro), '');
        }
    } else {
        $('li.parsley-required').show();
    }
}

function Guardar() {
    var parametro = {};
    var resultado;

    ValidaDiv('formConsulta');
    var Resultado = $('#formConsulta').parsley().validate();
    if (Resultado) {
        parametro = LlenarEntidadParametro();
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionGeneral.aspx/GuardarParametro",
            data: "{parametro:" + JSON.stringify(parametro) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d; 
            },
            complete: function (data) {
                if (resultado.Error === undefined) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                } else if (resultado.Error) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                } else {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                    ConsultarTodosLosParametros();
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
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Insertar', 'Parametro', JSON.stringify(parametro), '');
        }
    } else {
        $('li.parsley-required').show();
    }
}

function LlenarEntidadParametro() {
    var Parametro = {};

    if ($("#txtIdVariable").val() === "") {
        Parametro.IdParametro = 0;
    } else {
        Parametro.IdParametro = $("#txtIdVariable").val();
    }

    Parametro.Descripcion = $("#txtNombreVariable").val();
    Parametro.IdTipoDato = $("#ddlTipoVariable").val();
    Parametro.Valor = $("#txtValor").val();

    if ($('#chEstado').is(':checked')) {
        Parametro.Activo = true;
    } else {
        Parametro.Activo = false;
    }

    return Parametro;
}

function Cancelar() {
    $('#txtIdVariable').val("");
    $('#txtNombreVariable').val("");
    $('#ddlTipoVariable').val(1);
    $('#txtValor').val("");
    document.getElementById("chEstado").checked = false;
    $('input[name=btnAct]').hide();
    $('input[name=btnAgr]').show();
    $('#txtNombreVariable').removeAttr('disabled', 'disabled');
    $('#ddlTipoVariable').removeAttr('disabled', 'disabled');
    OcultarError();
    AgregarValidacion();
}

function ConsultarTodasLasValidaciones() {
    IniciarPrecargaBancaSeguros();
    var Validaciones;

    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionGeneral.aspx/ConsultarTodasLasValidaciones",
        dataType: "json",
        success: function (data) {
            Validaciones = data.d;
        },
        complete: function (data) {
            if (Validaciones !== undefined) {
                window.ListaValidaciones = Validaciones;
                AgregarValidacion();
            } else {
                MostrarMensajeGenerico(3, data.responseText);
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

function AgregarValidacion() {
    var TipoVariable;
    TipoVariable = $("#ddlTipoVariable option:selected").val();
    if (window.ListaValidaciones !== undefined) {
        for (var i = 0; i < window.ListaValidaciones.length; i++) {
            $('#txtValor').removeAttr(window.ListaValidaciones[i].Propiedad, window.ListaValidaciones[i].Valor);
        }

        for (var x = 0; x < window.ListaValidaciones.length; x++) {
            if (window.ListaValidaciones[x].IdTipoDato === TipoVariable) {
                $('#txtValor').attr(window.ListaValidaciones[x].Propiedad, window.ListaValidaciones[x].Valor);
            }
        }
    }
}

function OcultarError() {
    $('li.parsley-required').hide();
    $('#txtNombreVariable').removeClass('parsley-error');
    $('#txtValor').removeClass('parsley-error');
}