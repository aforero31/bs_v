var oTablePlanes;
var oTableProductos;
var imgbeneditclick = false;
var imgbeneliclick = false;
var cvicoclick = false;
var indiceProducto;
var indicePlan;
var codigoSeguroNoValido = false;

$(document).ready(function (event) {
    if (initSession()) {
        IniciarPrecargaBancaSeguros();
        CargarControlesIniciales();
        CargarEventos();
        CargarValidacionesCampos();
        ValidarControlDual();
    }
    else {
        IniciarPrecargaBancaSeguros();
        MostrarModalConfirmar(3, "Usted no se encuentra logueado o con permisos para acceder a esa pagina", 'sessLogOut()', 'sessLogOut()');
    }
});

document.onkeydown = function () {
    if (window.event && window.event.keyCode === 27) {
        Cancelar();
    }
}

function FormatoNumero(num) {
    var numero = num.value;
    num.value = FormatearNumeros(numero, 2, ',', '.');
}

function SelecionarFila() {
    $('#grvProducto tbody').on('click', 'tr', function () {
        var table = $('#grvProducto').DataTable();
        indiceProducto = $(this).index();
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
            CargarDatosDesdeGrilla(DatosFila);
        }
    });
}

function SelecionarFilaPlan() {
    $('#grvPlan tbody').on('click', 'tr', function () {
        var table = $('#grvPlan').DataTable();

        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }

        if (imgbeneditclick) {
            imgbeneditclick = false;
            var DatosFila = table.fnGetData(this);
            indicePlan = DatosFila.Indice;
            CargarPlanEditar(DatosFila);
        } else if (imgbeneliclick) {
            imgbeneliclick = false;
            var DatosFila = table.fnGetData(this);
            EliminarPlan(indicePlan);
        }
    });
}

function CargarControlesIniciales() {
    CargarTiposIdentificacion();
    CargarAseguradora();
    CargarPeriodicidad();
    ConsultarPlantillasActivas();
    InicializarGrilla();
    SelecionarFila();
    SelecionarFilaPlan();
    CargarCanalesVenta();
    CargarProductosBancarios();
    CargarPresentacionDeSecciones();
    $('input[name=ActualizarPlan]').hide();
    $('#btnAct').hide();
    VerificarPlantillaYActivoSeguro();
}

function CargarEventos() {
    $('#ddlAseguradora').change(function () {
        CargarConvenios();
        ConsultarSegurosPorCodigoYAseguradora();
    });

    $('#btnAgregarPlan').on('click', function () {
        CargarPlanGrilla();
    });

    $('#btnActualizarPlan').on('click', function () {
        ActualizarPlan();
    });

    $('#btnCancelarPlan').on('click', function () {
        LimpiarControlesPlan();
    });

    $("#txtEdadMax").change(function () {
        var n = $(this).val();
        var min = $("#txtEdadMin").val();
        ValidaDiv('txtEdadMax');
        var Resultado = $('#txtEdadMax').parsley().validate();
        if (Resultado) {
            if (min !== "") {
                if (parseInt(min, 0) <= parseInt(n, 0)) {
                    $('li.parsley-required').hide();
                } else {
                    $('#txtEdadMax').parsley({
                        messages: "Hola mundo"
                    });

                    $('li.parsley-required').show();

                    $(this).val("");
                }
            } else {
                $('li.parsley-required').hide();
            }
        } else {
            $(this).val('');
            $('li.parsley-required').show();
        }
    });

    $("#txtEdadMaxConyuge").change(function () {
        var n = $(this).val();
        var min = $("#txtEdadMinConyuge").val();
        ValidaDiv('txtEdadMaxConyuge');
        var Resultado = $('#txtEdadMaxConyuge').parsley().validate();
        if (Resultado) {
            if (min !== "") {
                if (parseInt(min, 0) <= parseInt(n, 0)) {
                    $('li.parsley-required').hide();
                } else {
                    $(this).val("");
                }
            } else {
                $('li.parsley-required').hide();
            }
        } else {
            $(this).val('');
            $('li.parsley-required').show();
        }
    });

    $("#txtEdadMin").change(function () {
        var n = $(this).val();
        var max = $("#txtEdadMax").val();
        ValidaDiv('txtEdadMin');
        var Resultado = $('#txtEdadMin').parsley().validate();
        if (Resultado) {
            if (max !== "") {
                if (parseInt(max, 0) >= parseInt(n, 0)) {
                    $('li.parsley-required').hide();
                } else {
                    $(this).val("");
                }
            } else {
                $('li.parsley-required').hide();
            }
        } else {
            $(this).val('');
            $('li.parsley-required').show();
        }
    });

    $("#txtEdadMinConyuge").change(function () {
        var n = $(this).val();
        var max = $("#txtEdadMaxConyuge").val();
        ValidaDiv('txtEdadMinConyuge');
        var Resultado = $('#txtEdadMinConyuge').parsley().validate();
        if (Resultado) {
            if (max !== "") {
                if (parseInt(max, 0) >= parseInt(n, 0)) {
                    $('li.parsley-required').hide();
                } else {
                    $(this).val("");
                }
            } else {
                $('li.parsley-required').hide();
            }
        } else {
            $(this).val('');
            $('li.parsley-required').show();
        }
    });

    $("#txtCodigoProducto").change(function () {
        ConsultarSegurosPorCodigoYAseguradora();
    });

    $('#ddlPlantilla').change(function () {
        VerificarPlantillaYActivoSeguro();
    });
}

function CargarValidacionesCampos() {

    $("#txtNombreProducto").keyup(function () {
        ValidaDiv('txtNombreProducto');
        var Resultado = $('#txtNombreProducto').parsley().validate();
        if (Resultado) {
            $('li.parsley-required').hide();
        } else {
            $(this).val('');
            $('li.parsley-required').show();
        }
    });

    $("#txtCodigoProducto").keyup(function () {
        ValidaDiv('txtCodigoProducto');
        var Resultado = $('#txtCodigoProducto').parsley().validate();
        if (Resultado) {
            $('li.parsley-required').hide();
        } else {
            $(this).val('');
            $('li.parsley-required').show();
        }
    });

    $("#txtEdadMin").keyup(function () {
        var n = $(this).val();
        var max = $("#txtEdadMax").val();
        ValidaDiv('txtEdadMin');
        var Resultado = $('#txtEdadMin').parsley().validate();
        if (Resultado) {
            if (max !== "") {
                $('li.parsley-required').hide();
            }
        } else {
            $(this).val('');
            $('li.parsley-required').show();
        }
    });

    $("#txtEdadMax").keyup(function () {
        var n = $(this).val();
        var min = $("#txtEdadMin").val();
        ValidaDiv('txtEdadMax');
        var Resultado = $('#txtEdadMax').parsley().validate();
        if (Resultado) {
            $('li.parsley-required').hide();
        } else {
            $(this).val('');
            $('li.parsley-required').show();
        }
    });

    $("#txtEdadMinConyuge").keyup(function () {
        var n = $(this).val();
        var max = $("#txtEdadMaxConyuge").val();
        ValidaDiv('txtEdadMinConyuge');
        var Resultado = $('#txtEdadMinConyuge').parsley().validate();
        if (Resultado) {
            if (max !== "") {
                $('li.parsley-required').hide();
            }
        } else {
            $(this).val('');
            $('li.parsley-required').show();
        }
    });

    $("#txtEdadMaxConyuge").keyup(function () {
        var n = $(this).val();
        var min = $("#txtEdadMinConyuge").val();
        ValidaDiv('txtEdadMaxConyuge');
        var Resultado = $('#txtEdadMaxConyuge').parsley().validate();
        if (Resultado) {
            $('li.parsley-required').hide();
        } else {
            $(this).val('');
            $('li.parsley-required').show();
        }
    });

    $("#txtNumeroMaxBeneficiario").keyup(function () {
        var n = $(this).val();
        ValidaDiv('txtNumeroMaxBeneficiario');
        var Resultado = $('#txtNumeroMaxBeneficiario').parsley().validate();
        if (Resultado) {
            $('li.parsley-required').hide();
        } else {
            $(this).val('');
            $('li.parsley-required').show();
        }
    });

    $("#txtNumeroVentasIgual").keyup(function () {
        var n = $(this).val();
        ValidaDiv('txtNumeroVentasIgual');
        var Resultado = $('#txtNumeroVentasIgual').parsley().validate();
        if (Resultado) {
            $('li.parsley-required').hide();
        } else {
            $(this).val('');
            $('li.parsley-required').show();
        }
    });

    $("#txtNumeroVentasDiferente").keyup(function () {
        var n = $(this).val();
        ValidaDiv('txtNumeroVentasDiferente');
        var Resultado = $('#txtNumeroVentasDiferente').parsley().validate();
        if (Resultado) {
            $('li.parsley-required').hide();
        } else {
            $(this).val('');
            $('li.parsley-required').show();
        }
    });

    $("#txtNombrePlan").keyup(function () {
        ValidaDiv('txtNombrePlan');
        var Resultado = $('#txtNombrePlan').parsley().validate();
        if (Resultado) {
            $('li.parsley-required').hide();
        } else {
            $(this).val('');
            $('li.parsley-required').show();
        }
    });

    $("#txtValorSinIVA").keyup(function () {
        ValidaDiv('txtValorSinIVA');
        var Resultado = $('#txtValorSinIVA').parsley().validate();
        if (Resultado) {
            $('li.parsley-required').hide();
            SumaTotal();
        } else {
            $(this).val('');
            $('li.parsley-required').show();
        }
    });

    $("#txtValorIVA").keyup(function () {
        ValidaDiv('txtValorIVA');
        var Resultado = $('#txtValorIVA').parsley().validate();
        if (Resultado) {
            $('li.parsley-required').hide();
            SumaTotal();
        } else {
            $(this).val('');
            $('li.parsley-required').show();
        }
    });

}

function SumaTotal() {
    var valorSinIva = 0;
    var valorIva = 0;
    if ($("#txtValorSinIVA").val() !== "") {
        valorSinIva = $("#txtValorSinIVA").val();

        if ($("#txtValorIVA").val() !== "") {
            valorIva = $("#txtValorIVA").val();
            var total = parseFloat(valorSinIva.replace(',', '.')) + parseFloat(valorIva.replace(',', '.'));
            total = total.toString().replace('.', ',');
            $("#txtValorTotal").val(total);
        } else {
            valorSinIva = valorSinIva.replace('.', ',');
            $("#txtValorTotal").val(valorSinIva);
        }
    } else {
        $("#txtValorTotal").val(0);
    }
}

function InicializarGrilla() {
    oTablePlanes = $('#grvPlan').dataTable({
        "oLanguage": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "No hay registros de planes",
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
            { "data": "Indice", "visible": false, "searchable": false },
            { "data": "IdPlan", "visible": false, "searchable": false },
            { "data": "CodigoPlan", "class": "num" },
            { "data": "NombrePlan" },
            { "data": "Periodicidad" },
            { "data": "IdPeriodicidad", "visible": false, "searchable": false },
            { "data": "Convenio" },
            { "data": "Estado" },
            { "data": "ValorSinIVA" },
            { "data": "ValorIVA" },
            { "data": "ValorTotal" },
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

    oTableProductos = $('#grvProducto').dataTable({
        "oLanguage": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "No hay registros",
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
            { "data": "IdProducto", "visible": false, "searchable": false },
            { "data": "CodigoProducto" },
            { "data": "NombreProducto" },
            { "data": "NombreAseguradora" },
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

function ActualizarPlan() {
    if (ValidaCodigoPlanActualizar() && ValidarDatosPlan()) {
        $('input[name=ActualizarPlan]').hide();
        $('input[name=AgregarPlan]').show();
        var oTable = $('#grvPlan').dataTable();
        oTable.fnUpdate(LeerDatosPlan(), indicePlan);
        LimpiarControlesPlan();
    }
}

function LeerDatosPlan() {
    var table = $('#grvPlan').DataTable()
    var FilaPlan;
    var iva;
    var Indice = $('#txtIndice').val();
    if (Indice === "") {
        Indice = table.fnGetData().length == 0 ? 0 : table.fnGetData().length;
    }

    if ($('#txtValorIVA').val() === "") {
        iva = FormatearNumeros('0.00', 2, ',', '.');
    } else {
        iva = FormatearNumeros($('#txtValorIVA').val(), 2, ',', '.');
    }

    FilaPlan = {
        Indice: parseInt(Indice, 0),
        IdPlan: $('#txtIdPlan').val(),
        CodigoPlan: $('#txtCodigoPlan').val(),
        NombrePlan: $('#txtNombrePlan').val(),
        Periodicidad: $('#ddlPeriodicidad option:selected').text(),
        IdPeriodicidad: $('#ddlPeriodicidad').val(),
        Convenio: $('#ddlConvenio').val(),
        Estado: $('#ddlEstadoPlan option:selected').text(),
        ValorSinIVA: FormatearNumeros($('#txtValorSinIVA').val(), 2, ',', '.'),
        ValorIVA: iva,
        ValorTotal: FormatearNumeros($('#txtValorTotal').val(), 2, ',', '.'),
        Acciones: '<img src=../Imagenes/edit.jpg width=20px height=20px onclick="imgbeneditclick=true" title="Actualizar Plan">'
        //+ '<img src=../Imagenes/delete.png width=20px height=20px onclick="imgbeneliclick=true" title="Eliminar Plan">'
    }

    return FilaPlan;
}

function CargarPlanGrilla() {
    if (ValidaCodigoPlan() && ValidarDatosPlan()) {
        oSettings = oTablePlanes.fnSettings();
        oTablePlanes.oApi._fnAddData(oSettings, LeerDatosPlan());
        oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
        oTablePlanes.fnDraw();
        LimpiarControlesPlan();
    }
}

function ValidarDatosPlan() {
    var CodigoPlan = $('#txtCodigoPlan').val();
    var Periodicidad = $('#ddlPeriodicidad').val();
    var ValorSinIVA = $('#txtValorSinIVA').val();
    var ValorIVA = $('#txtValorIVA').val();
    var ValorTotal = $('#txtValorTotal').val();
    var mensaje = "";
    var error = false;

    ValidaDiv('panelPlanCampos');

    var resultado = $('#panelPlanCampos').parsley().validate();

    if (resultado) {
        if (CodigoPlan === "0") {
            mensaje = mensaje + "- Debe seleccionar un código de plan<br />";
            error = true;
        }

        if (Periodicidad === "0") {
            mensaje = mensaje + "- Debe seleccionar una periodicidad<br />";
            error = true;
        }

        if (parseInt(ValorTotal, 0) <= 0) {
            mensaje = mensaje + "- Debe ingresar un valor total mayor a cero<br />";
            error = true;
        }
        else if ((parseInt(ValorSinIVA, 0) + parseInt(ValorIVA, 0)) >= 0 && ((parseInt(ValorSinIVA, 0) + parseInt(ValorIVA, 0)) > parseInt(ValorTotal, 0) || (parseInt(ValorSinIVA, 0) + parseInt(ValorIVA, 0)) < parseInt(ValorTotal, 0))) {
            mensaje = mensaje + "- El valor del IVA y el valor sin IVA deben ser 0 o su suma debe ser igual al valor total<br />";
            error = true;
        }

        if (error) {
            alert(mensaje);
        }

    } else {
        error = true;
    }

    return !(error);
}

function ValidaCodigoPlan() {
    var retorno = true;
    var oTable = $('#grvPlan').dataTable();
    if (oTable.fnGetData().length > 0) {
        $.each(oTable.fnGetData(), function (i, row) {
            if (row.CodigoPlan == $('#txtCodigoPlan').val()) {
                MostrarMensajeGenerico(2, 'El Código del plan ya existe');
                retorno = false;
                return false;
            }
        });
    }
    return retorno;
}

function ValidaCodigoPlanActualizar() {
    var retorno = true;
    var Indice = $('#txtIndice').val()
    var oTable = $('#grvPlan').dataTable();
    if (oTable.fnGetData().length > 0) {
        $.each(oTable.fnGetData(), function (i, row) {
            if (row.CodigoPlan === $('#txtCodigoPlan').val() && row.Indice.toString() !== Indice) {
                MostrarMensajeGenerico(2, 'El Código del plan ya existe');
                retorno = false;
                return false;
            }
        });
    }

    return retorno;
}

function CargarPlanEditar(DatosFilas) {
    LimpiarControlesPlan();
    $('input[name=ActualizarPlan]').show();
    $('input[name=AgregarPlan]').hide();
    $('#txtIdPlan').val(DatosFilas.IdPlan);
    $('#txtCodigoPlan').val(DatosFilas.CodigoPlan);
    $('#txtNombrePlan').val(DatosFilas.NombrePlan);
    $('#ddlPeriodicidad').val(DatosFilas.IdPeriodicidad.toString());
    $('#txtValorSinIVA').val(DatosFilas.ValorSinIVA.replace(/[. $]/g, ''));
    $('#txtValorIVA').val(DatosFilas.ValorIVA.replace(/[. $]/g, ''));
    $('#txtValorTotal').val(DatosFilas.ValorTotal.replace(/[. $]/g, ''));
    $('#ddlConvenio').val(DatosFilas.Convenio.toString());
    $('#txtIndice').val(DatosFilas.Indice);

    if (DatosFilas.Estado === "ACTIVO") {
        $('#ddlEstadoPlan').val(1);
    } else {
        $('#ddlEstadoPlan').val(0);
    }

}

function EliminarPlan(index) {
    var oTable = $('#grvPlan').dataTable();
    oTable.fnDeleteRow(index);
    LimpiarControlesPlan();
}

function LimpiarControlesPlan() {
    $('#txtIndice').val('');
    $('input[name=ActualizarPlan]').hide();
    $('input[name=AgregarPlan]').show();
    $('#txtNombrePlan').val('');
    $('#txtCodigoPlan').val('');
    $('#txtIdPlan').val('');
    $('#txtValorSinIVA').val('');
    $('#txtValorIVA').val('');
    $('#txtValorTotal').val('');
    $('#ddlEstadoPlan').val(1);

    $('li.parsley-required').hide();
    $('#txtCodigoPlan').removeClass('parsley-error');
    $('#txtNombrePlan').removeClass('parsley-error');
    $('#txtValorSinIVA').removeClass('parsley-error');
    $('#txtValorIVA').removeClass('parsley-error');
    $('#txtValorTotal').removeClass('parsley-error');
    $('#ddlPeriodicidad').removeClass('parsley-error');
    $('#ddlConvenio').removeClass('parsley-error');
}

function CargarTiposIdentificacion() {
    var DataCatalogo = ConsultarCatalogo("SEG_TipoIdentificacion");
    if (DataCatalogo != null && DataCatalogo != undefined) {
        window._TipoIdentificacion = Enumerable.From(DataCatalogo.ListTipoIdentificacion).Where(function (x) { return x.Activo == true }).Select().ToArray();
        CrearControlesTiposIdentificacion(window._TipoIdentificacion);
    }
}

function CrearControlesTiposIdentificacion(tiposIdentificacion) {
    var contenidoTiposIdentificacionControles = "";
    if (tiposIdentificacion.length > 0) {
        for (var i = 0; i < tiposIdentificacion.length; i++) {
            contenidoTiposIdentificacionControles += "<input type='checkbox' id='chkTipoIdentificacion" + tiposIdentificacion[i].IdTipoIdentificacion + "' name='TipoIdentificacion" + tiposIdentificacion[i].IdTipoIdentificacion + "' data-TipoIdentificacion='" + tiposIdentificacion[i].IdTipoIdentificacion + "' /> " + tiposIdentificacion[i].Nombre + " <br />";
        }
    } else {
        contenidoTiposIdentificacionControles += "<h4>No hay tipos de identificación para mostrar</h4><br />"
    }

    $("#panelTiposIdentificacion").prepend(contenidoTiposIdentificacionControles);
}

function CargarAseguradora() {

    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: 'ParametrizacionProducto.aspx/ObtenerAseguradoras',
        data: null,
        dataType: "json",
        success: function (data) {
            $('#ddlAseguradora').empty();
            $('#ddlAseguradora').append($('<option>', { value: "", text: '--Seleccione--' }));
            LlenarListaDesplegable(data.d, 'ddlAseguradora', 'IdAseguradora', 'Nombre');
        },
        complete: function (data) {
        },
        error: function (data) {
            $('#ddlAseguradora').empty();
            $('#ddlAseguradora').append($('<option>', { value: "", text: '--Seleccione--' }));
            var errorMessage = data.responseText;
            alert(errorMessage);
            DetenerPrecargaBancaSeguros();
        }
    });
}

function CargarPeriodicidad() {

    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: 'ParametrizacionProducto.aspx/ObtenerPeriodicidad',
        data: null,
        dataType: "json",
        success: function (data) {
            $('#ddlPeriodicidad').empty();
            $('#ddlPeriodicidad').append($('<option>', { value: "", text: '--Seleccione--' }));
            LlenarListaDesplegable(data.d, 'ddlPeriodicidad', 'IdPeriodicidad', 'Nombre');
        },
        complete: function (data) {
        },
        error: function (data) {
            $('#ddlPeriodicidad').empty();
            $('#ddlPeriodicidad').append($('<option>', { value: "", text: '--Seleccione--' }));
            var errorMessage = data.responseText;
            alert(errorMessage);
            DetenerPrecargaBancaSeguros();
        }
    });
}

function CargarConvenios() {
    var idAseguradora = $("#ddlAseguradora").val();

    if (idAseguradora !== "") {
        IniciarPrecargaBancaSeguros();

        var resultado = false;
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: 'ParametrizacionProducto.aspx/ObtenerConveniosPorAseguradora',
            data: "{idAseguradora:" + idAseguradora + "}",
            dataType: "json",
            success: function (data) {
                resultado = true;
            },
            complete: function (data) {
                if (resultado && data.responseJSON.d != null) {
                    $('#ddlConvenio').empty();
                    $('#ddlConvenio').append($('<option>', { value: "", text: '--Seleccione--' }));
                    if (data.responseJSON.d.length > 0) {
                        LlenarListaDesplegable(data.responseJSON.d, 'ddlConvenio', 'CodigoConvenio', 'CodigoConvenio');
                    } else {
                        alert("El sistema no trajo convenios desde Cobis");
                    }
                }
                else {
                    $('#ddlConvenio').empty();
                    $('#ddlConvenio').append($('<option>', { value: "", text: '--Seleccione--' }));
                    alert("El sistema no trajo convenios desde Cobis");
                }
                DetenerPrecargaBancaSeguros();
            },
            error: function (data) {
                var errorMessage = data.responseText;
                alert(errorMessage);
                $('#ddlConvenio').empty();
                $('#ddlConvenio').append($('<option>', { value: "", text: '--Seleccione--' }));
                DetenerPrecargaBancaSeguros();
            }
        });
    } else {
        $('#ddlConvenio').empty();
        $('#ddlConvenio').append($('<option>', { value: "", text: '--Seleccione--' }));
    }
}

function ConsultarPlantillasActivas() {
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: 'ParametrizacionProducto.aspx/ConsultarPlantillasActivas',
        data: null,
        dataType: "json",
        success: function (data) {
            $('#ddlPlantilla').empty();
            $('#ddlPlantilla').append($('<option>', { value: "", text: '--Seleccione--' }));
            LlenarListaDesplegable(data.d, 'ddlPlantilla', 'IdDocumentoPoliza', 'NombreArchivo');
        },
        complete: function (data) {
        },
        error: function (data) {
            $('#ddlPlantilla').empty();
            $('#ddlPlantilla').append($('<option>', { value: "", text: '--Seleccione--' }));
            var errorMessage = data.responseText;
            alert(errorMessage);
            DetenerPrecargaBancaSeguros();
        }
    });
}

function CargarCanalesVenta() {
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: 'ParametrizacionProducto.aspx/ObtenerCanalesVenta',
        data: null,
        dataType: "json",
        success: function (data) {
            CrearControlesCanalVenta(data.d);
        },
        complete: function (data) {
        },
        error: function (data) {
            var errorMessage = data.responseText;
            alert('Error al cargar los canales de venta');
        }
    });
}

function CrearControlesCanalVenta(listaCanalesVenta) {
    var contenidoCanalesVentaControles = "";
    if (listaCanalesVenta.length > 0) {
        for (var i = 0; i < listaCanalesVenta.length; i++) {
            contenidoCanalesVentaControles += "<input type='radio' id='chkCanalVenta" + listaCanalesVenta[i].IdCanalVenta + "' name='CanalVenta' data-CanalVenta='" + listaCanalesVenta[i].IdCanalVenta + "' /> " + listaCanalesVenta[i].Nombre + " <br />";
        }
    } else {
        contenidoCanalesVentaControles += "<h4>No hay canales de venta para mostrar</h4><br />"
    }
    $("#panelCanalVenta").prepend(contenidoCanalesVentaControles);
}

function CargarProductosBancarios() {
    var productosBancarios = ObtenerProductosBancarios();
    var productosBancariosHtml = "";
    var active = "";
    var activeClass = "";
    window.SubProductos = [];
    if (productosBancarios != null) {
        productosBancariosHtml += '<ul class="nav nav-tabs" id="nombrePestañas">';
        for (var i = 0; i < productosBancarios.length; i++) {
            if (i === 0) {
                activeClass = 'class="active"';
            } else {
                activeClass = "";
            }

            productosBancariosHtml += '<li ' + activeClass + '><a href="#pnlSudProducto' + productosBancarios[i].IdProductos + '" data-toggle="tab">' + productosBancarios[i].Nombre + '</a></li>';
        }
        productosBancariosHtml += '</ul></br>';
        productosBancariosHtml += '<div class="tab-content">';

        for (var i = 0; i < productosBancarios.length; i++) {
            if (i === 0) {
                active = "in active";
            } else {
                active = "";
            }

            productosBancariosHtml += "<div id='pnlSudProducto" + productosBancarios[i].IdProductos + "' class='tab-pane fade " + active + "'>";
            productosBancariosHtml += '<input type="checkbox" id="chProductos' + productosBancarios[i].IdProductos + '" onclick="SeleccionarProducto(this)"  data-Producto="' + productosBancarios[i].IdProductos + '"> Restringir ' + productosBancarios[i].Nombre + '</>';
            productosBancariosHtml += CargarSubProductosBancarios(productosBancarios[i].Codigo);
            productosBancariosHtml += "</div>";
        }
        productosBancariosHtml += '</div>';
    }
    $("#panelCuentaNoPermitida").append(productosBancariosHtml);
}

function ObtenerProductosBancarios() {
    var productosBancarios;
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: 'ParametrizacionProducto.aspx/ObtenerProductos',
        data: null,
        dataType: "json",
        success: function (data) {
            productosBancarios = data.d;
        },
        complete: function (data) {
        },
        error: function (data) {
            var errorMessage = data.responseText;
            alert('Error al cargar los productos bancarios');
            productosBancarios = null;
            DetenerPrecargaBancaSeguros();
        }
    });

    return productosBancarios;
}

function CargarSubProductosBancarios(codigoProducto) {
    var subProductosBancariosHtml = "";
    var subProductosBancarios = ObtenerSubproductosBancarios(codigoProducto);
    if (subProductosBancarios != null) {
        for (var i = 0; i < subProductosBancarios.length; i++) {
            window.SubProductos.push(subProductosBancarios[i]);
            subProductosBancariosHtml += '<h5 data-toggle="collapse" data-target="#pnlCategoria' + subProductosBancarios[i].Codigo + '">&nbsp&nbsp<img src="../css/jquery/images/arrow-down-01.png" width="20px" height="20px" data-toggle="collapse" data-target="#pnlCategoria' + subProductosBancarios[i].Codigo + '" />&nbsp; ' + subProductosBancarios[i].Nombre + '</h5>';
            subProductosBancariosHtml += "<div id='pnlCategoria" + subProductosBancarios[i].Codigo + "' class='collapse'>";
            subProductosBancariosHtml += '<input type="checkbox" id="chSubProductos' + subProductosBancarios[i].Codigo + '" onclick="SeleccionarSubProducto(this)" data-SubProducto="' + subProductosBancarios[i].Codigo + '"> Restringir ' + subProductosBancarios[i].Nombre + '</></br>';
            subProductosBancariosHtml += CargarCategoriasPorSubProducto(subProductosBancarios[i].IdSubProductos, subProductosBancarios[i].Codigo, codigoProducto);
            subProductosBancariosHtml += "</div>";
        }
    }
    return subProductosBancariosHtml;
}

function ObtenerSubproductosBancarios(codigoProducto) {
    var subProductos;
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: 'ParametrizacionProducto.aspx/ObtenerSubProductosPorProducto',
        data: "{codigoProducto:" + codigoProducto + "}",
        dataType: "json",
        success: function (data) {
            subProductos = data.d;
        },
        complete: function (data) {
        },
        error: function (data) {
            alert('Error al cargar los productos bancarios');
            subProductos = null;
            DetenerPrecargaBancaSeguros();
        }
    });
    return subProductos;
}

function CargarCategoriasPorSubProducto(idSubProducto, codigoSubProducto, codigoProducto) {
    var subCategoriasHtml = "";
    var categorias = ObtenerCategorias(idSubProducto);
    if (categorias != null) {
        for (var i = 0; i < categorias.length; i++) {
            subCategoriasHtml += "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<input type='checkbox' id='chkCategoria" + codigoProducto + codigoSubProducto + $.trim(categorias[i].Codigo) + "' name='Categoria" + categorias[i].IdCategoria + "' data-Producto='" + codigoProducto + "' data-SubProducto='" + codigoSubProducto + "' data-Categoria='" + categorias[i].Codigo + "' />" + categorias[i].Nombre + " <br />";
        }
    }
    return subCategoriasHtml;
}

function ObtenerCategorias(idSubProducto) {
    var categorias;
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: 'ParametrizacionProducto.aspx/ObtenerCategoriasPorSubProductos',
        data: "{idSubProducto:" + idSubProducto + "}",
        dataType: "json",
        success: function (data) {
            categorias = data.d;
        },
        complete: function (data) {
        },
        error: function (data) {
            alert('Error al cargar los productos bancarios');
            categorias = nul;
            DetenerPrecargaBancaSeguros();
        }
    });
    return categorias;
}

function CargarPresentacionDeSecciones() {
    RequiereConyuge();
    RequiereBeneficiario();
    RequiereDiferente();
    RequiereIguales();
    $('#ddlConvenio').append($('<option>', { value: "", text: '--Seleccione--' }));
}

function RequiereConyuge() {

    if ($("#chConyuge").is(':checked')) {
        OcultarPanel("panelConyugeO", false);
        $('#txtEdadMinConyuge').attr('required', '');
        $('#txtEdadMaxConyuge').attr('required', '');
        $('#txtEdadMinConyuge').removeClass('parsley-error');
        $('#txtEdadMaxConyuge').removeClass('parsley-error');
    } else {
        $("#txtEdadMinConyuge").val("");
        $("#txtEdadMaxConyuge").val("");
        OcultarPanel("panelConyugeO", true);
        $('#txtEdadMinConyuge').removeAttr('required', '');
        $('#txtEdadMinConyuge').removeAttr('required', '');
    }
}

function RequiereBeneficiario() {

    if ($("#chBeneficiario").is(':checked')) {
        OcultarPanel("panelBeneficiarioO", false);
        $('#txtNumeroMaxBeneficiario').attr('required', '');
        $('#txtNumeroMaxBeneficiario').removeClass('parsley-error');
    } else {
        $("#txtNumeroMaxBeneficiario").val("");
        OcultarPanel("panelBeneficiarioO", true);
        $('#txtNumeroMaxBeneficiario').removeAttr('required', '');
    }
}

function Cancelar() {
    $('li.parsley-required').hide();

    //detalleProducto
    CargarAseguradora();
    $('#txtNombreProducto').val("");
    $('#txtNombreProducto').removeClass('parsley-error');
    $('#txtCodigoProducto').val("");
    $('#txtCodigoProducto').removeClass('parsley-error');
    $('#txtEdadMin').val("");
    $('#txtEdadMin').removeClass('parsley-error');
    $('#txtEdadMax').val("");
    $('#txtEdadMax').removeClass('parsley-error');
    $('#ddlEstado').val(1);
    $('#ddlAseguradora').removeClass('parsley-error');
    $('#txtIdProducto').val("");
    $('#txtcodigoProductoAct').val("");

    //panelConyuge
    $("#chConyuge").prop("checked", false);
    $('#txtEdadMinConyuge').removeClass('parsley-error');
    $('#txtEdadMaxConyuge').removeClass('parsley-error');
    RequiereConyuge();

    //panelBeneficiario
    $("#chBeneficiario").prop("checked", false);
    $('#txtNumeroMaxBeneficiario').removeClass('parsley-error');
    RequiereBeneficiario();

    //grvPlan
    LimpiarControlesPlan();
    oTablePlanes.fnClearTable(this);
    $('#ddlConvenio').empty();
    $('#ddlConvenio').append($('<option>', { value: "", text: '--Seleccione--' }));

    //panelCanalVenta
    $("#panelCanalVenta" + " input").each(function (index) {
        $(this).prop("checked", false);
    })

    //panelCuentaNoPermitida
    $("#panelCuentaNoPermitida" + " input").each(function (index) {
        $(this).prop("checked", false);
    })

    var SubProductos = window.SubProductos;
    if (SubProductos != undefined) {
        for (var i = 0; i < SubProductos.length; i++) {
            DeshabilitarDivYContenido("pnlCategoria" + SubProductos[i].Codigo, false);
        }
    }

    //panelEstado
    $('#txtNumeroVentasIgual').val("");
    $('#txtNumeroVentasIgual').removeClass('parsley-error');
    $("#chIguales").prop("checked", false);
    RequiereIguales();
    $('#txtNumeroVentasDiferente').val("");
    $('#txtNumeroVentasDiferente').removeClass('parsley-error');
    $("#chDiferentes").prop("checked", false);
    RequiereDiferente();

    //panelTiposIdentificacion
    $("#panelTiposIdentificacion" + " input").each(function (index) {
        $(this).prop("checked", false);
    })

    //OcultarModal
    $('#modalProducto').modal('hide');

    ActivarDesActivarCampos(false);
    $('#btnAgr').show();
    $('#btnAct').hide();

    $('#ddlPlantilla').empty();
    $('#ddlPlantilla').append($('<option>', { value: "", text: '--Seleccione--' }));
    VerificarPlantillaYActivoSeguro();
    ConsultarPlantillasActivas();
}

function GuardarProducto() {
    IniciarPrecargaBancaSeguros();
    var mensaje = "Hay secciones sin llenar, verifíquelas:</br></br>";
    var resultadoDetalleProducto;
    var resultadoConyuge;
    var resultadoBeneficiario;
    var resultadoPlanes;
    var resultadoCanalVenta;
    var resultadoIdentificacion;
    var resultadoPanelDiferentes;
    var resultadoPanelIguales;

    resultadoDetalleProducto = ValidacionPanelDetalleProducto();
    resultadoPanelDiferentes = ValidacionPanelDiferentes();
    resultadoPanelIguales = ValidacionPanelIguales();

    resultadoConyuge = ValidacionPanelConyuge();
    mensaje += resultadoConyuge;

    resultadoBeneficiario = ValidacionPanelBeneficiario();
    mensaje += resultadoBeneficiario;

    resultadoPlanes = ValidacionPanelPlanes();
    mensaje += resultadoPlanes;

    resultadoCanalVenta = ValidacionCanalVenta();
    mensaje += resultadoCanalVenta;

    resultadoIdentificacion = ValidacionTipoIdentificacion();
    mensaje += resultadoIdentificacion;

    if (resultadoDetalleProducto || resultadoConyuge !== "" || resultadoBeneficiario !== "" || resultadoPanelDiferentes || resultadoPanelIguales) {
        mensaje += "* Campos obligatorios sin diligenciar";
    }

    if (codigoSeguroNoValido) {
        mensaje += "* Código del producto existente";
    }

    if (mensaje === "Hay secciones sin llenar, verifíquelas:</br></br>") {
        var ParametrizacionSeguro = {};
        ParametrizacionSeguro = LLenarEntidadParametrizacionSeguro();
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
            GuardarProductoSeguro(ParametrizacionSeguro);
        } else {
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Insertar', 'ParametrizacionSeguro', JSON.stringify(ParametrizacionSeguro), '');
            Cancelar();
            DetenerPrecargaBancaSeguros();
        }
    } else {
        DetenerPrecargaBancaSeguros();
        $('li.parsley-required').show();
        alert(mensaje);
    }
}

function ValidacionPanelDetalleProducto() {
    var resultado = false;

    ValidaDiv('detalleProducto');
    var resultadoDetalle = $('#detalleProducto').parsley().validate();
    if (!resultadoDetalle) {
        $('li.parsley-required').show();
        resultado = true;
    }

    ValidaDiv('panelDatosAdd');
    var resultadoPlantilla = $('#panelDatosAdd').parsley().validate();
    if (!resultadoPlantilla) {
        $('li.parsley-required').show();
        resultado = true;
    }

    return resultado;
}

function ValidacionPanelConyuge() {
    var mensaje = "";
    if ($("#chConyuge").is(':checked')) {
        ValidaDiv('panelConyugeO');
        var Resultado = $('#panelConyugeO').parsley().validate();

        if (!Resultado) {
            mensaje = "* Verifique la sección del cónyuge</br>";
            $('li.parsley-required').show();
        }
    }

    return mensaje;
}

function ValidacionPanelBeneficiario() {
    var mensaje = "";
    if ($("#chBeneficiario").is(':checked')) {
        ValidaDiv('panelBeneficiarioO');
        var Resultado = $('#panelBeneficiarioO').parsley().validate();

        if (!Resultado) {
            mensaje = "* Verifique la sección del beneficiario</br>";
            $('li.parsley-required').show();
        }
    }
    return mensaje;
}

function ValidacionPanelDiferentes() {
    var resultado = false;
    if ($("#chDiferentes").is(':checked')) {
        ValidaDiv('panelDiferentesO');
        var Resultado = $('#panelDiferentesO').parsley().validate();

        if (!Resultado) {
            $('li.parsley-required').show();
            resultado = true;
        }
    }
    return resultado;
}

function ValidacionPanelIguales() {
    var resultado = false;
    if ($("#chIguales").is(':checked')) {
        ValidaDiv('panelIgualesO');
        var Resultado = $('#panelIgualesO').parsley().validate();

        if (!Resultado) {
            $('li.parsley-required').show();
            resultado = true;
        }
    }
    return resultado;
}

function ValidacionPanelPlanes() {
    var mensaje = "";
    var error = false;

    if (oTablePlanes.fnSettings().aoData.length === 0) {
        mensaje = '* Debe registrar un plan <br>';
        error = true;
    }

    if (error) {
        return mensaje;
    } else {
        mensaje = "";
        return mensaje;
    }
}

function ValidacionCanalVenta() {
    var numero = 0;
    $("#panelCanalVenta" + " input").each(function (index) {
        if ($(this).is(':checked')) {
            numero += 1;
        }
    })

    if (numero === 0) {
        return "* Debe seleccionar un canal de venta</br>";
    } else {
        return "";
    }
}

function ValidacionTipoIdentificacion() {
    var numero = 0;
    $("#panelTiposIdentificacion" + " input").each(function (index) {
        if ($(this).is(':checked')) {
            numero += 1;
        }
    })

    if (numero === 0) {
        return "* Debe seleccionar un tipo de identificación</br>";
    } else {
        return "";
    }

}

function LLenarEntidadParametrizacionSeguro() {
    var ParametrizacionSeguro = {};
    var Seguro = {};
    var DocumentoPoliza = {};
    var ListaPlanes = [];
    var ListaProductosNoPermitidos = [];
    var ListaTiposIdentificacionPorSeguro = [];

    Seguro = LLenarEntidadSeguro();
    DocumentoPoliza = LLenarDocumentoPoliza();
    ListaPlanes = LLenarListaPlanes();
    ListaProductosNoPermitidos = LLenarListaProductosNoPermitidos();
    ListaTiposIdentificacionPorSeguro = LlenarListaTiposIdentificacionPorSeguro();

    ParametrizacionSeguro.Seguro = Seguro;
    ParametrizacionSeguro.DocumentoPoliza = DocumentoPoliza;
    ParametrizacionSeguro.Planes = ListaPlanes;
    ParametrizacionSeguro.ProductosNoPermitidos = ListaProductosNoPermitidos;
    ParametrizacionSeguro.TiposIdentificacionPorSeguro = ListaTiposIdentificacionPorSeguro;

    return ParametrizacionSeguro;
}

function LLenarEntidadSeguro() {
    var Seguro = {};

    Seguro.Codigo = $('#txtCodigoProducto').val();
    Seguro.Descripcion = $('#txtNombreProducto').val();
    Seguro.Nombre = $('#txtNombreProducto').val();

    if ($('#txtIdProducto').val() !== "") {
        Seguro.IdSeguro = $('#txtIdProducto').val();
    }

    if ($('#txtNumeroVentasDiferente').val() === "") {
        Seguro.NumeroMaximoSegurosPorCliente = 0;
    } else {
        Seguro.NumeroMaximoSegurosPorCliente = $('#txtNumeroVentasDiferente').val();
    }

    if ($('#txtNumeroVentasIgual').val() === "") {
        Seguro.NumeroMaximoVentaSegurosPorCuentaCliente = 0;
    } else {
        Seguro.NumeroMaximoVentaSegurosPorCuentaCliente = $('#txtNumeroVentasIgual').val();
    }

    if ($("#chBeneficiario").is(':checked')) {
        Seguro.Beneficiario = true;
        Seguro.MaximoBeneficiarios = $('#txtNumeroMaxBeneficiario').val();
    } else {
        Seguro.Beneficiario = false;
    }

    if ($("#chConyuge").is(':checked')) {
        Seguro.Conyuge = true;
        Seguro.EdadMaximaConyuge = $('#txtEdadMaxConyuge').val();
        Seguro.EdadMinimaConyuge = $('#txtEdadMinConyuge').val();
    } else {
        Seguro.Conyuge = false;
    }

    Seguro.IdAseguradora = $('#ddlAseguradora').val();

    if ($("#ddlEstado").val() === "1") {
        Seguro.Activo = true;
    } else {
        Seguro.Activo = false;
    }

    Seguro.EdadMinimaMujer = $('#txtEdadMin').val();
    Seguro.EdadMaximaMujer = $('#txtEdadMax').val();
    Seguro.EdadMinimaHombre = $('#txtEdadMin').val();
    Seguro.EdadMaximaHombre = $('#txtEdadMax').val();

    $("#panelCanalVenta" + " input").each(function (index) {
        if ($(this).is(':checked')) {
            Seguro.IdCanalVenta = $(this)[0].getAttribute("data-CanalVenta");
        }
    })

    return Seguro;
}

function LLenarDocumentoPoliza() {
    var DocumentoPoliza = {};

    if ($('#ddlPlantilla').val() === "" || $('#ddlPlantilla').val() == undefined) {
        DocumentoPoliza = null;
    } else {
        DocumentoPoliza.IdDocumentoPoliza = $('#ddlPlantilla').val();
        if ($('#txtIdProducto').val() !== "") {
            DocumentoPoliza.IdSeguro = $('#txtIdProducto').val();
        }
    }

    return DocumentoPoliza;
}

function LLenarListaPlanes() {
    var ListaPlanes = [];

    var oTable = $('#grvPlan').dataTable();
    for (var i = 0; i < oTable.fnGetNodes().length; i++) {
        var DatosFilas = oTable.fnGetData(i);
        var Plan = {};
        var Periodicidad = {};
        var ValorSinIVA = DatosFilas.ValorSinIVA.replace(/[. $]/g, '');
        ValorSinIVA = parseFloat(ValorSinIVA.replace(',', '.'));
        var ValorIVA = DatosFilas.ValorIVA.replace(/[. $]/g, '');
        ValorIVA = parseFloat(ValorIVA.replace(',', '.'));
        var ValorTotal = DatosFilas.ValorTotal.replace(/[. $]/g, '');
        ValorTotal = parseFloat(ValorTotal.replace(',', '.'));

        if (DatosFilas.IdPlan != "") {
            Plan.IdPlan = DatosFilas.IdPlan;
        }

        Plan.CodigoPlan = DatosFilas.CodigoPlan;
        Plan.NombrePlan = DatosFilas.NombrePlan;
        Plan.Descripcion = DatosFilas.NombrePlan;
        Plan.ValorSinIVA = ValorSinIVA;
        Plan.ValorIVA = ValorIVA;
        Plan.Valor = ValorTotal;
        Plan.CodigoConvenio = DatosFilas.Convenio;

        if (DatosFilas.Estado === "ACTIVO") {
            Plan.Activo = true;
        } else {
            Plan.Activo = false;
        }

        Periodicidad.IdPeriodicidad = DatosFilas.IdPeriodicidad;;
        Plan.Periodicidad = Periodicidad;

        ListaPlanes.push(Plan);
    }

    return ListaPlanes;
}

function LLenarListaProductosNoPermitidos() {

    var ListaProductosNoPermitidos = [];

    $("#panelCuentaNoPermitida" + " input").each(function (index) {
        if ($(this).is(':checked')) {
            var ProductoNoPermitido = {};
            var Producto = {};
            var SubProducto = {};
            var Categoria = {};

            Producto.Codigo = $(this)[0].getAttribute("data-Producto");
            SubProducto.Codigo = $(this)[0].getAttribute("data-SubProducto");
            Categoria.Codigo = $(this)[0].getAttribute("data-Categoria");

            ProductoNoPermitido.Producto = Producto;
            ProductoNoPermitido.SubProducto = SubProducto;
            ProductoNoPermitido.Categoria = Categoria;

            if (Producto.Codigo != null && SubProducto.Codigo != null && Categoria.Codigo != null) {
                ListaProductosNoPermitidos.push(ProductoNoPermitido);
            }
        }
    })

    return ListaProductosNoPermitidos;
}

function LlenarListaTiposIdentificacionPorSeguro() {
    var ListaTiposIdentificacionPorSeguro = [];

    $("#panelTiposIdentificacion" + " input").each(function (index) {
        if ($(this).is(':checked')) {
            var TipoIdentificacion = {};
            TipoIdentificacion.IdTipoIdentificacion = $(this)[0].getAttribute("data-TipoIdentificacion");
            ListaTiposIdentificacionPorSeguro.push(TipoIdentificacion);
        }
    })

    return ListaTiposIdentificacionPorSeguro;
}

function GuardarProductoSeguro(ParametrizacionSeguro) {
    var resultado = {};

    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: 'ParametrizacionProducto.aspx/InsertarSeguro',
        data: "{parametrizacionSeguro:" + JSON.stringify(ParametrizacionSeguro) + "}",
        dataType: "json",
        success: function (data) {
            resultado = data.d;
        },
        complete: function (data) {
            if (resultado.Error) {
                alert(resultado.Mensaje);
            } else {
                Cancelar();
                LimpiarPaginaPrincipal();
                MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
            }

            DetenerPrecargaBancaSeguros();
        },
        error: function (data) {
            var errorMessage = data.responseText;
            alert(errorMessage);
        }
    });

    return resultado;
}

function InsertarNuevoProducto() {
    $('#modalProducto').modal('show');
}

function ConsultarTodosLosSeguros() {
    var Productos;

    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: 'ParametrizacionProducto.aspx/ConsultarTodosLosSeguros',
        data: null,
        dataType: "json",
        success: function (data) {
            Productos = data.d;
        },
        complete: function (data) {
            if (Productos != undefined) {
                CargarGrillaProductos(Productos);
            } else {
                alert(data.responseText);
            }
            DetenerPrecargaBancaSeguros();
        },
        error: function (data) {
            var errorMessage = data.responseText;
            alert(3, errorMessage);
            DetenerPrecargaBancaSeguros();
        }
    });
}

function CargarGrillaProductos(productos) {
    oSettings = oTableProductos.fnSettings();
    oTableProductos.fnClearTable(this);
    var estado = "";
    for (var i = 0; i < productos.length; i++) {

        if (productos[i].Activo) {
            estado = "ACTIVO";
        } else {
            estado = "INACTIVO";
        }

        FilaProducto = {
            IdProducto: productos[i].IdSeguro,
            CodigoProducto: productos[i].Codigo,
            NombreProducto: productos[i].Nombre,
            NombreAseguradora: productos[i].Aseguradora.Nombre,
            Estado: estado,
            Acciones: '<input type="image" src="../imagenes/edit.jpg" width="25" height="25" title="Consultar Producto" id="cvico" onclick="cvicoclick=true"/>'
        }

        oTableProductos.oApi._fnAddData(oSettings, FilaProducto);
    }

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTableProductos.fnDraw();
}

function CargarDatosDesdeGrilla(datosGrilla) {
    Cancelar();
    ConsultarInformacionSeguroPorId(datosGrilla.IdProducto);
    $('#txtIdProducto').val(datosGrilla.IdProducto);
    $('#txtcodigoProductoAct').val(datosGrilla.CodigoProducto);
    $('#modalProducto').modal('show');
    ActivarDesActivarCampos(true);

    $('#btnAgr').hide();
    $('#btnAct').show();
}

function ActualizarProducto() {
    IniciarPrecargaBancaSeguros();
    var mensaje = "Hay secciones sin llenar, verifíquelas:</br></br>";
    var resultadoDetalleProducto;
    var resultadoConyuge;
    var resultadoBeneficiario;
    var resultadoPlanes;
    var resultadoCanalVenta;
    var resultadoIdentificacion;
    var resultadoPanelDiferentes;
    var resultadoPanelIguales;

    resultadoDetalleProducto = ValidacionPanelDetalleProducto();
    resultadoPanelDiferentes = ValidacionPanelDiferentes();
    resultadoPanelIguales = ValidacionPanelIguales();

    resultadoConyuge = ValidacionPanelConyuge();
    mensaje += resultadoConyuge;

    resultadoBeneficiario = ValidacionPanelBeneficiario();
    mensaje += resultadoBeneficiario;

    resultadoPlanes = ValidacionPanelPlanes();
    mensaje += resultadoPlanes;

    resultadoCanalVenta = ValidacionCanalVenta();
    mensaje += resultadoCanalVenta;

    resultadoIdentificacion = ValidacionTipoIdentificacion();
    mensaje += resultadoIdentificacion;

    if (resultadoDetalleProducto || resultadoConyuge !== "" || resultadoBeneficiario !== "" || resultadoPanelDiferentes || resultadoPanelIguales) {
        mensaje += "* Campos obligatorios sin diligenciar";
    }

    if (codigoSeguroNoValido) {
        mensaje += "* Código del producto existente";
    }

    if (mensaje === "Hay secciones sin llenar, verifíquelas:</br></br>") {
        var ParametrizacionSeguro = {};
        ParametrizacionSeguro = LLenarEntidadParametrizacionSeguro();
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
            ActualizarSeguroPorId(ParametrizacionSeguro);
        } else {
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Actualizar', 'ParametrizacionSeguro', JSON.stringify(ParametrizacionSeguro), '');
            Cancelar();
            DetenerPrecargaBancaSeguros();
        }
    } else {
        DetenerPrecargaBancaSeguros();
        $('li.parsley-required').show();
        alert(mensaje);
    }
}

function ActualizarSeguroPorId(parametrizacionSeguro) {
    var resultado = {};
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: 'ParametrizacionProducto.aspx/ActualizarSeguroPorId',
        data: "{parametrizacionSeguro:" + JSON.stringify(parametrizacionSeguro) + "}",
        dataType: "json",
        success: function (data) {
            resultado = data.d;
        },
        complete: function (data) {
            if (resultado.Error) {
                alert(resultado.Mensaje);
            } else {
                Cancelar();
                LimpiarPaginaPrincipal();
                MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
            }

            DetenerPrecargaBancaSeguros();
        },
        error: function (data) {
            var errorMessage = data.responseText;
            alert(errorMessage);
            DetenerPrecargaBancaSeguros();
        }
    });

    return resultado;
}

function ActivarDesActivarCampos(accion) {
    $('#ddlAseguradora').attr("disabled", accion);
}

function ConsultarInformacionSeguroPorId(idProducto) {
    var seguro;
    IniciarPrecargaBancaSeguros();

    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: 'ParametrizacionProducto.aspx/ConsultarInformacionSeguroPorId',
        data: "{idSeguro:" + idProducto + "}",
        dataType: "json",
        success: function (data) {
            seguro = data.d;
            LlenarDatosEnModal(seguro);
        },
        error: function (data) {
            var errorMessage = data.responseText;
            alert(errorMessage);
            DetenerPrecargaBancaSeguros();
        }
    });
}

function LlenarDatosEnModal(seguro) {
    //detalleProducto
    $('#ddlAseguradora').val(seguro.Seguro.Aseguradora.IdAseguradora);
    CargarConvenios();
    $('#txtNombreProducto').val(seguro.Seguro.Nombre);
    $('#txtCodigoProducto').val(seguro.Seguro.Codigo);
    $('#txtEdadMin').val(seguro.Seguro.EdadMinimaHombre);
    $('#txtEdadMax').val(seguro.Seguro.EdadMaximaHombre);

    if (seguro.DocumentoPoliza.IdDocumentoPoliza !== 0) {
        $('#ddlPlantilla').val(seguro.DocumentoPoliza.IdDocumentoPoliza)
    }

    if (seguro.Seguro.Activo) {
        $('#ddlEstado').val(1);
    } else {
        $('#ddlEstado').val(0);
    }

    //panelConyuge
    $("#chConyuge").prop("checked", seguro.Seguro.Conyuge);
    if (seguro.Seguro.Conyuge) {
        $('#txtEdadMinConyuge').val(seguro.Seguro.EdadMinimaConyuge);
        $('#txtEdadMaxConyuge').val(seguro.Seguro.EdadMaximaConyuge);
        RequiereConyuge();
    }

    //panelBeneficiario
    $("#chBeneficiario").prop("checked", seguro.Seguro.Beneficiario);
    if (seguro.Seguro.Beneficiario) {
        $('#txtNumeroMaxBeneficiario').val(seguro.Seguro.MaximoBeneficiarios);
        RequiereBeneficiario();
    }

    //grvPlanes
    CargarPlanesSeguro(seguro.Planes);

    //panelCanalVenta
    $("#chkCanalVenta" + seguro.Seguro.IdCanalVenta).prop("checked", true);;

    //panelCuentaNoPermitida
    for (var i = 0; i < seguro.ProductosNoPermitidos.length; i++) {
        $("#chkCategoria" + seguro.ProductosNoPermitidos[i].Producto.Codigo + seguro.ProductosNoPermitidos[i].SubProducto.Codigo + $.trim(seguro.ProductosNoPermitidos[i].Categoria.Codigo)).prop("checked", true);
    }

    //panelEstado
    if (seguro.Seguro.NumeroMaximoVentaSegurosPorCuentaCliente === 0) {
        $('#txtNumeroVentasIgual').val('');
    } else {
        $("#chIguales").prop("checked", true);
        RequiereIguales();
        $('#txtNumeroVentasIgual').val(seguro.Seguro.NumeroMaximoVentaSegurosPorCuentaCliente);
    }

    if (seguro.Seguro.NumeroMaximoSegurosPorCliente === 0) {
        $('#txtNumeroVentasDiferente').val('');
    } else {
        $("#chDiferentes").prop("checked", true);
        RequiereDiferente();
        $('#txtNumeroVentasDiferente').val(seguro.Seguro.NumeroMaximoSegurosPorCliente);
    }

    //panelTiposIdentificacion
    for (var i = 0; i < seguro.TiposIdentificacionPorSeguro.length; i++) {
        $("#chkTipoIdentificacion" + seguro.TiposIdentificacionPorSeguro[i].IdTipoIdentificacion).prop("checked", true);
    }

    VerificarPlantillaYActivoSeguro();
}

function CargarPlanesSeguro(planes) {

    for (var i = 0; i < planes.length; i++) {

        var table = $('#grvPlan').DataTable()
        var Indice = table.fnGetData().length == 0 ? 0 : table.fnGetData().length;
        oSettings = oTablePlanes.fnSettings();
        var estado;

        if (planes[i].Activo) {
            estado = "ACTIVO";
        } else {
            estado = "INACTIVO";
        }

        FilaPlan = {
            Indice: parseInt(Indice, 0),
            IdPlan: planes[i].IdPlan,
            CodigoPlan: planes[i].CodigoPlan,
            NombrePlan: planes[i].NombrePlan,
            Periodicidad: planes[i].NombrePeriodicidad,
            IdPeriodicidad: planes[i].IdPeriodicidad,
            Convenio: planes[i].CodigoConvenio,
            Estado: estado,
            ValorSinIVA: FormatearNumeros(planes[i].ValorSinIVA.toString().replace('.', ','), 2, ',', '.'),
            ValorIVA: FormatearNumeros(planes[i].ValorIVA.toString().replace('.', ','), 2, ',', '.'),
            ValorTotal: FormatearNumeros(planes[i].Valor.toString().replace('.', ','), 2, ',', '.'),
            Acciones: '<img src=../Imagenes/edit.jpg width=20px height=20px onclick="imgbeneditclick=true" title="Actualizar Plan">'
            //+ '<img src=../Imagenes/delete.png width=20px height=20px onclick="imgbeneliclick=true" title="Eliminar Plan">'
        }
        oTablePlanes.oApi._fnAddData(oSettings, FilaPlan);
        oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
        oTablePlanes.fnDraw();
    }

    LimpiarControlesPlan();
}

function LimpiarValorBusqueda() {
    $('#txtValor').val('');
}

function ConsultarProductos() {
    var Productos;
    var nombreProducto = "";
    var codigoProducto = 0;
    var nombreAseguradora = "";

    ValidaDiv('panelConsultar');
    var Resultado = $('#panelConsultar').parsley().validate();
    if (Resultado) {
        if ($("#slopcionBusqueda").val() === "1") {
            nombreProducto = $("#txtValor").val();
        } else if ($("#slopcionBusqueda").val() === "2") {

            if (!isNaN($("#txtValor").val())) {
                codigoProducto = $("#txtValor").val();
            } else {
                $("#txtValor").val("0");
            }

        } else if ($("#slopcionBusqueda").val() === "3") {
            nombreAseguradora = $("#txtValor").val();
        }

        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: 'ParametrizacionProducto.aspx/ConsultarSegurosPorParametros',
            data: "{nombreProducto:'" + nombreProducto + "', codigoProducto:" + codigoProducto + ", nombreAseguradora:'" + nombreAseguradora + "'}",
            dataType: "json",
            success: function (data) {
                Productos = data.d;
            },
            complete: function (data) {
                if (Productos != undefined) {
                    CargarGrillaProductos(Productos);
                } else {
                    alert(data.responseText);
                }
                DetenerPrecargaBancaSeguros();
            },
            error: function (data) {
                var errorMessage = data.responseText;
                alert(errorMessage);
                DetenerPrecargaBancaSeguros();
            }
        });
    }
}

function RequiereDiferente() {

    if ($("#chDiferentes").is(':checked')) {
        OcultarPanel("panelDiferentesO", false);
        $('#txtNumeroVentasDiferente').attr('required', '');
        $('#txtNumeroVentasDiferente').removeClass('parsley-error');

    } else {
        $("#txtNumeroVentasDiferente").val("");
        OcultarPanel("panelDiferentesO", true);
        $('#txtNumeroVentasDiferente').removeAttr('required', '');
    }
}

function RequiereIguales() {

    if ($("#chIguales").is(':checked')) {
        OcultarPanel("panelIgualesO", false);
        $('#txtNumeroVentasIgual').attr('required', '');
        $('#txtNumeroVentasIgual').removeClass('parsley-error');
    } else {
        $("#txtNumeroVentasIgual").val("");
        OcultarPanel("panelIgualesO", true);
        $('#txtNumeroVentasIgual').removeAttr('required', '');
    }
}

function SeleccionarProducto(check) {
    var Producto;

    Producto = $(check)[0].getAttribute("data-Producto");

    $("#pnlSudProducto" + Producto + " input").each(function (index) {
        if ($(check).is(':checked')) {
            $(this).prop("checked", true);
        } else {
            $(this).prop("checked", false);
        }
    })
}

function SeleccionarSubProducto(check) {
    var SubProducto;

    SubProducto = $(check)[0].getAttribute("data-SubProducto");

    $("#pnlCategoria" + SubProducto + " input").each(function (index) {
        if ($(check).is(':checked')) {
            $(this).prop("checked", true);
        } else {
            $(this).prop("checked", false);
        }
    })
}

function ConsultarSegurosPorCodigoYAseguradora() {
    var codigoSeguro = $('#txtCodigoProducto').val();
    var codigoAseguradora = $("#ddlAseguradora").val();
    var codigoSeguroAnt = $('#txtcodigoProductoAct').val();

    var resultado;
    if (codigoAseguradora !== '' && codigoSeguro !== '' && codigoSeguro !== codigoSeguroAnt) {
        IniciarPrecargaBancaSeguros();
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionProducto.aspx/ConsultarSegurosPorCodigoYAseguradora",
            data: "{codigoSeguro:" + codigoSeguro + ", codigoAseguradora:" + codigoAseguradora + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (resultado != null) {
                    if (resultado.Error) {
                        alert(resultado.Mensaje);
                        codigoSeguroNoValido = true;
                    } else {
                        codigoSeguroNoValido = false;
                    }
                } else {
                    alert(errorMessage);
                }
                DetenerPrecargaBancaSeguros();
            },
            error: function (data) {
                var errorMessage = data.responseText;
                alert(errorMessage);
                DetenerPrecargaBancaSeguros();
            }
        });
    } else {
        codigoSeguroNoValido = false;
    }
}

function VerificarPlantillaYActivoSeguro() {
    if ($('#ddlPlantilla').val() === "" || $('#ddlPlantilla').val() == undefined) {
        $('#ddlEstado').attr("disabled", true);
        $('#ddlEstado').val(0);
    } else {
        $('#ddlEstado').attr("disabled", false);
    }
}

function LimpiarPaginaPrincipal() {
    oTableProductos.fnClearTable(this);
    ConsultarProductos();
}

function LimpiarConsultaInicio() {
    $('#txtValor').val('');
    $('#slopcionBusqueda').val(1);
    oTableProductos.fnClearTable(this);
}