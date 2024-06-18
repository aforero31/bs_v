var cvicoclick = false;
var rowgvReporte;

$(document).ready(function () {
    if (initSession()) {
        CargarCatalogo();
        InicializarGrilla();
        $('input[name=btnAct]').hide();
        ConsultarTodasLasCausalesNovedades();
        SeleccionarFila();
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
            { "data": "IdCausalNovedad", "visible": false, "searchable": false },
            { "data": "NombreCausalNovedad" },
            { "data": "IdTipoNovedad", "visible": false, "searchable": false },
            { "data": "NombreNovedad"},
            { "data": "CodigoCausalNovedad" },
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

function CargarCatalogo() {

    DataCatalogo = ConsultarCatalogo("SEG_TipoNovedad");
    if (DataCatalogo != null && DataCatalogo !== undefined)
        LlenarCombo(DataCatalogo.ListTablaNovedad, 'ddlNovedad');
}

function ConsultarCatalogo(NombreTabla) {
    var DataCatalogo;
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizarCausalNovedad.aspx/ConsultarCatalogo",
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

function LlenarCombo(data, dropDownList) {
    $('#' + dropDownList).append($('<option>', { value: "", text: '-- Seleccione una opción --' }));
    for (var i = 0; i < data.length; i++) {
        switch (dropDownList) {
            case 'ddlNovedad':
                $('#' + dropDownList).append($('<option>', { value: data[i]["IdTipoNovedad"], text: data[i]["CodigoTipoNovedad"] + ' - ' + data[i]["NombreTipoNovedad"] }));
                break;
        }
    }
}

function GuardarCausalNovedad() {
    var causalNovedad = {};
    var resultado;
    ValidaDiv('formCausalNovedad');
    var Resultado = $('#formCausalNovedad').parsley().validate();
    if (Resultado) {
        causalNovedad = LlenarEntidadCausalNovedad();
        var mensaje = $('#message').val();
        if (mensaje === "") {
            var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
            if (!registroAutorizaDual.requiereAutorizacion) {
            $.ajax({
                type: "POST",
                cache: false,
                async: true,
                contentType: "application/json; charset=utf-8",
                url: "ParametrizarCausalNovedad.aspx/InsertarCausalNovedad",
                data: "{causalNovedad:" + JSON.stringify(causalNovedad) + "}",
                dataType: "json",
                success: function (data) {
                    resultado = data.d;
                },
                complete: function (data) {
                    if (resultado.Error !== undefined) {
                        if (resultado.Error) {
                            MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                        }
                        else {
                            MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                            ConsultarTodasLasCausalesNovedades();
                            Cancelar();
                        }
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
                AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Insertar', 'CausalNovedad', JSON.stringify(causalNovedad), '');
            }
        }
    }
}

function LlenarEntidadCausalNovedad() {
    var CausalNovedad = {};

    if ($("#txtIdCausalNovedad").val() === "") {
        CausalNovedad.IdCausalNovedad = 0;
    }
    else {
        CausalNovedad.IdCausalNovedad = $("#txtIdCausalNovedad").val();
    }
    CausalNovedad.IdTipoNovedad = $('#ddlNovedad').val();
    CausalNovedad.CodigoCausalNovedad = $("#txtCodigoCausalNovedad").val();
    CausalNovedad.NombreCausalNovedad = $("#txtNombreCausalNovedad").val();
    CausalNovedad.EstadoCausalNovedad = $("#cmbEstadoCausalNovedad").val();

    return CausalNovedad;
}

function ConsultarTodasLasCausalesNovedades() {
    var listaCausales;

    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizarCausalNovedad.aspx/ConsultarCausalNovedad",
        dataType: "json",
        success: function (data) {
            listaCausales = data.d;
        },
        complete: function (data) {
            if (listaCausales != null) {
                if (listaCausales.length > 0) {
                    CargarGrillaCausalNovedad(listaCausales);
                } else {
                    MostrarMensajeGenerico(2, 'No hay causales de novedades parametrizadas')
                }
            } else {
                MostrarMensajeGenerico(2, 'No hay causales de novedades parametrizadas')
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

function CargarGrillaCausalNovedad(listaCausales) {
    oTableReporte.fnClearTable(this);
    oSettings = oTableReporte.fnSettings();
    var estadoCausalNovedad = "";
    for (var i = 0; i < listaCausales.length; i++) {

        if (listaCausales[i].EstadoCausalNovedad) {
            estadoCausalNovedad = "ACTIVO";
        } else {
            estadoCausalNovedad = "INACTIVO";
        }

        FilaCausal = {
            IdCausalNovedad: listaCausales[i].IdCausalNovedad,
            IdTipoNovedad: listaCausales[i].IdTipoNovedad,
            NombreNovedad: listaCausales[i].NombreTipoNovedad,
            CodigoCausalNovedad: listaCausales[i].CodigoCausalNovedad,
            NombreCausalNovedad: listaCausales[i].NombreCausalNovedad,
            Activo: estadoCausalNovedad,
            Acciones: '<img src=../Imagenes/edit.jpg width=20px height=20px title="Actualizar Causal Novedad" id="cvico" onclick="cvicoclick=true">'
        }

        oTableReporte.oApi._fnAddData(oSettings, FilaCausal);
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
    $('#txtCodigoCausalNovedad').attr('disabled', true);

    $('#txtIdCausalNovedad').val(DatosFilas.IdCausalNovedad);
    $('#ddlNovedad').val(DatosFilas.IdTipoNovedad);
    $('#txtCodigoCausalNovedad').val(DatosFilas.CodigoCausalNovedad);
    $('#txtNombreCausalNovedad').val(DatosFilas.NombreCausalNovedad);

    if (DatosFilas.Activo === "ACTIVO") {
        $("#cmbEstadoCausalNovedad").val('true');
    } else {
        $("#cmbEstadoCausalNovedad").val('false');
    }
}

function ActualizarCausalNovedad() {
    var causalNovedad = {};
    var resultado = {};

    ValidaDiv('formCausalNovedad');
    var Resultado = $('#formCausalNovedad').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        causalNovedad = LlenarEntidadCausalNovedad();
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizarCausalNovedad.aspx/ActualizarCausalNovedad",
            data: "{causalNovedad:" + JSON.stringify(causalNovedad) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (resultado.Error)
                {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                }
                else
                {
                    ConsultarTodasLasCausalesNovedades();
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
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Actualizar', 'CausalNovedad', JSON.stringify(causalNovedad), '');
        }
    }
}

function Cancelar() {
    $("#ddlNovedad").val("");
    $("#txtIdCausalNovedad").val("");
    $("#txtCodigoCausalNovedad").val("");
    $("#txtNombreCausalNovedad").val("");
    $("#cmbEstadoCausalNovedad").val("");
    $('input[name=btnAgr]').show();
    $('input[name=btnAct]').hide();
    $('#txtCodigoCausalNovedad').attr('disabled', false);
}