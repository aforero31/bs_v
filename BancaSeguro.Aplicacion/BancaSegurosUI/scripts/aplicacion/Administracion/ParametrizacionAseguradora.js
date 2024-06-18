var oTableReporte;
var cvicoclick = false;

$(document).ready(function () {
    if (initSession()) {
        $('#chActualizaConsecutivo').on('click', function () {
            if (this.checked) {
                $('#txtConsecutivoInicial').prop('disabled', false);
            } else {
                $('#txtConsecutivoInicial').prop('disabled', true);
            }
        });
        IniciarPrecargaBancaSeguros();
        InicializarGrilla();
        CargarSecciones(true);
        CargarComboTipoIdenti();
        DetenerPrecargaBancaSeguros();
        SelecionarFila();
        ValidarControlDual();
    }
    else {
        IniciarPrecargaBancaSeguros();
        MostrarModalConfirmar(3, "Usted no se encuentra logueado o con permisos para acceder a esa pagina", 'sessLogOut()', 'sessLogOut()');
    }
});

function InicializarGrilla() {
    oTableReporte = $('#gvAseguradora').dataTable({
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
            { "data": "IdAseguradora", "visible": false, "searchable": false },
            { "data": "CodigoSuperintendencia" },
            { "data": "Nombre" },
            { "data": "IdTipoIdentificacion", "visible": false, "searchable": false },
            { "data": "TipoIdentificacion" },
            { "data": "Identificacion" },
            { "data": "Contacto" },
            { "data": "Telefono" },
            { "data": "Correo" },
            { "data": "Estado" },
            { "data": "ConsecutivoInicial" },
            { "data": "ConsecutivoActual" },
            { "data": "Editar" }
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

function CargarSecciones(estado) {
    DeshabilitarDivYContenido('panelGrillaReporte', estado);
}

function CargarComboTipoIdenti() {
    var ListTipoIdentificacion = $.jStorage.get("ListaTipoIdentificacion");
    if (ListTipoIdentificacion !== undefined) {
        LlenarListaDesplegable(ListTipoIdentificacion, 'ddlTipoIdentificacion', "IdTipoIdentificacion", "Nombre");
    }
}

function SelecionarFila() {
    var table = $('#gvAseguradora').DataTable();
    $('#gvAseguradora tbody').on('click', 'tr', function () {
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
            CargarDatosAseguradora(DatosFila);
        }
    });
}

function CargarDatosAseguradora(DatosFilas) {
    $('#dividAseguradora').html(DatosFilas.IdAseguradora);
    $('#txtCodigoAseguradora').val(DatosFilas.CodigoSuperintendencia);
    $('#txtNombreAseguradora').val(DatosFilas.Nombre);
    $('#ddlTipoIdentificacion').val(DatosFilas.IdTipoIdentificacion);
    $('#txtNumeroDocumento').val(DatosFilas.Identificacion);
    $('#txtContacto').val(DatosFilas.Contacto);
    $('#txtTelefono').val(DatosFilas.Telefono);
    $('#txtCorreo').val(DatosFilas.Correo);

    if (DatosFilas.Estado === "ACTIVO") {
        document.getElementById("chEstado").checked = true;
    } else {
        document.getElementById("chEstado").checked = false;
    }
    document.getElementById("filaActualizaConsecutivo").style.visibility = "visible";
    document.getElementById("chActualizaConsecutivo").checked = false;

    $('#txtConsecutivoInicial').val(DatosFilas.ConsecutivoInicial);
    $('#txtConsecutivoInicial').prop('disabled', true);
    $('#divConsecutivoActual').html(DatosFilas.ConsecutivoActual);
    document.getElementById("btnAgr").style.visibility = "hidden";
    document.getElementById("btnAct").style.visibility = "visible";
    $('#modalInfoAseguradora').modal('show');
}

function CargarNuevoFormulario() {
    $('#dividAseguradora').html('0');
    $('#txtCodigoAseguradora').val('');
    $('#txtNombreAseguradora').val('');
    $('#ddlTipoIdentificacion').val('6');
    $('#txtNumeroDocumento').val('');
    $('#txtContacto').val('');
    $('#txtTelefono').val('');
    $('#txtCorreo').val('');
    document.getElementById("chEstado").checked = true;
    document.getElementById("filaActualizaConsecutivo").style.visibility = "collapse";
    $('#txtConsecutivoInicial').val('');
    $('#txtConsecutivoInicial').prop('disabled', false);
    $('#divConsecutivoActual').empty();
    document.getElementById("btnAgr").style.visibility = "visible";
    document.getElementById("btnAct").style.visibility = "hidden";
    $('#modalInfoAseguradora').parsley().destroy();
    $('#modalInfoAseguradora').modal('show');
}

function ConsultarAseguradoras() {
    ValidaDiv('panelConsultar');
    var Resultado = $('#panelConsultar').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        var datosAseguradora = {};
        datosAseguradora = LlenarEntidadAseguradoraBusqueda();
        var aseguradoras;
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionAseguradora.aspx/ConsultarAseguradoras",
            data: "{aseguradora:" + JSON.stringify(datosAseguradora) + "}",
            dataType: "json",
            success: function (data) {
                aseguradoras = data.d;
            },
            complete: function (data) {
                if (aseguradoras.length > 0) {
                    CargarSecciones(false);
                    CargarGrillaAseguradoras(aseguradoras);
                }
                else {
                    MostrarMensajeGenerico(2, 'No existen Aseguradoras registradas en el sistema con el filtro seleccionado.')
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

function ConsultarAseguradoraPorCodigo(codigoAseguradora) {
    IniciarPrecargaBancaSeguros();
    var datosAseguradora = {};
    datosAseguradora.CodigoSuperintendencia = codigoAseguradora;
    var aseguradoras;
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionAseguradora.aspx/ConsultarAseguradoras",
        data: "{aseguradora:" + JSON.stringify(datosAseguradora) + "}",
        dataType: "json",
        success: function (data) {
            aseguradoras = data.d;
        },
        complete: function (data) {
            if (aseguradoras.length > 0) {
                CargarSecciones(false);
                CargarGrillaAseguradoras(aseguradoras);
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

function CargarGrillaAseguradoras(aseguradoras) {
    var result = aseguradoras;
    oSettings = oTableReporte.fnSettings();
    oTableReporte.fnClearTable(this);
    var auto;
    var est;
    var ListTipoIdentificacion = $.jStorage.get("ListaTipoIdentificacion");

    var tipoIdentificacion;
    var estado;

    for (var i = 0; i < result.length; i++) {

        for (var j = 0; j < ListTipoIdentificacion.length; j++) {
            if (ListTipoIdentificacion[j]["IdTipoIdentificacion"] === result[i].TipoIdentificacion.IdTipoIdentificacion) {
                tipoIdentificacion = ListTipoIdentificacion[j]["Nombre"];
            }
        }

        if (result[i].Activo) {
            estado = 'ACTIVO';
        }
        else {
            estado = 'INACTIVO';
        }

        FilaAseguradora = {
            IdAseguradora: result[i].IdAseguradora,
            CodigoSuperintendencia: result[i].CodigoSuperintendencia,
            Nombre: result[i].Nombre,
            IdTipoIdentificacion: result[i].TipoIdentificacion.IdTipoIdentificacion,
            TipoIdentificacion: tipoIdentificacion,
            Identificacion: result[i].Identificacion,
            Contacto: result[i].Contacto,
            Telefono: result[i].Telefono,
            Correo: result[i].Correo,
            Estado: estado,
            ConsecutivoInicial: result[i].ConsecutivoInicial,
            ConsecutivoActual: result[i].ConsecutivoActual,
            Editar: '<input type="image" src="../imagenes/edit.jpg" width="25" height="25" title="Editar" id="cvico" onclick="cvicoclick=true"/>'
        }

        oTableReporte.oApi._fnAddData(oSettings, FilaAseguradora);
    }

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTableReporte.fnDraw();
}

function LlenarEntidadAseguradoraBusqueda() {
    var Aseguradora = {};

    var opcion = $("#slopcionBusqueda").val();
    var valor = $("#txtValor").val();

    switch (opcion) {
        case '1':
            {
                Aseguradora.CodigoSuperintendencia = valor;
                break;
            }
        case '2':
            {
                Aseguradora.Nombre = valor;
                break;
            }
        case '3':
            {
                Aseguradora.TipoIdentificacion = {};
                Aseguradora.TipoIdentificacion.IdTipoIdentificacion = 6;
                Aseguradora.Identificacion = valor;
                break;
            }
    }

    return Aseguradora;
}

function LlenarEntidadAseguradora(actualiza) {
    var Aseguradora = {};
    Aseguradora.IdAseguradora = parseInt($('#dividAseguradora').html(), 0);
    Aseguradora.CodigoSuperintendencia = $('#txtCodigoAseguradora').val();
    Aseguradora.Nombre = $('#txtNombreAseguradora').val();
    Aseguradora.TipoIdentificacion = {};
    Aseguradora.TipoIdentificacion.IdTipoIdentificacion = parseInt($('#ddlTipoIdentificacion').val(), 0);
    Aseguradora.Identificacion = $('#txtNumeroDocumento').val();
    Aseguradora.Contacto = $('#txtContacto').val();
    Aseguradora.Telefono = $('#txtTelefono').val();
    Aseguradora.Correo = $('#txtCorreo').val();

    if (document.getElementById("chEstado").checked) {
        Aseguradora.Activo = true;
    }
    else {
        Aseguradora.Activo = false;
    }

    Aseguradora.ConsecutivoInicial = parseInt($('#txtConsecutivoInicial').val(), 0);

    Aseguradora.ConsecutivoActual = Aseguradora.ConsecutivoInicial;

    if (actualiza) {
        if (document.getElementById('txtConsecutivoInicial').disabled) {
            Aseguradora.ActualizaConsecutivo = false;
        }
        else {
            Aseguradora.ActualizaConsecutivo = true;
        }
    }

    return Aseguradora;
}

function GuardarAseguradora() {
    ValidaDiv('modalInfoAseguradora');
    var Resultado = $('#modalInfoAseguradora').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        var datosAseguradora = {};
        datosAseguradora = LlenarEntidadAseguradora(false);
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
            var resultado;
            $.ajax({
                type: "POST",
                cache: false,
                async: true,
                contentType: "application/json; charset=utf-8",
                url: "ParametrizacionAseguradora.aspx/InsertarAseguradora",
                data: "{aseguradora:" + JSON.stringify(datosAseguradora) + "}",
                dataType: "json",
                success: function (data) {
                    resultado = data.d;
                },
                complete: function (data) {
                    if (!resultado.Error) {
                        

                        $('#modalInfoAseguradora').modal('hide');
                        DetenerPrecargaBancaSeguros();
                        ConsultarAseguradoraPorCodigo(datosAseguradora.CodigoSuperintendencia);
                    }
                    else {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje)
                        DetenerPrecargaBancaSeguros();
                    }
                },
                error: function (data) {
                    var errorMessage = data.responseText;
                    MostrarMensajeGenerico(3, errorMessage)
                    DetenerPrecargaBancaSeguros();
                }
            });
        }
        else {
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Insertar', 'Aseguradora', JSON.stringify(datosAseguradora), '#modalInfoAseguradora');
        }
    }
}

function ActualizarAseguradora() {
    ValidaDiv('modalInfoAseguradora');
    var Resultado = $('#modalInfoAseguradora').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        var datosAseguradora = {};
        datosAseguradora = LlenarEntidadAseguradora(true);
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
            var resultado;
            $.ajax({
                type: "POST",
                cache: false,
                async: true,
                contentType: "application/json; charset=utf-8",
                url: "ParametrizacionAseguradora.aspx/ActualizarAseguradora",
                data: "{aseguradora:" + JSON.stringify(datosAseguradora) + "}",
                dataType: "json",
                success: function (data) {
                    resultado = data.d;
                },
                complete: function (data) {
                    if (!resultado.Error) {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                        $('#modalInfoAseguradora').modal('hide');
                        DetenerPrecargaBancaSeguros();
                        ConsultarAseguradoraPorCodigo(datosAseguradora.CodigoSuperintendencia);
                    }
                    else {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje)
                        DetenerPrecargaBancaSeguros();
                    }
                },
                error: function (data) {
                    var errorMessage = data.responseText;
                    MostrarMensajeGenerico(3, errorMessage)
                    DetenerPrecargaBancaSeguros();
                }
            });
        }
        else {
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Actualizar', 'Aseguradora', JSON.stringify(datosAseguradora), '#modalInfoAseguradora');

        }
    }
}

function Cancelar() {
    $('#modalInfoAseguradora').modal('hide');
}

function ValidaCaracterBusqueda(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    var key = String.fromCharCode(charCode);
    if (charCode === 8) {
        return true;
    }
    else {
        var opcion = $("#slopcionBusqueda").val();

        if (opcion === '1' || opcion === '3') {
            return ValidaNumerico(key);
        }
        else {
            return ValidaAlfaNumerico(key);
        }
    }
}

function LimpiarValorBusqueda() {
    $('#txtValor').val('');
}

