var cvicoclick = false;
var rowgvReporte;
var eliminaclick = false;
var radio;

$(document).ready(function () {
    if (initSession()) {
        InicializarGrilla();
        ConsultarDatosGrilla();
        IniciarPrecargaBancaSeguros();
        IniciarCalendarios();
        IniciarDivProgramacion();
        CargarCatalogo();
        LlenaComboDiasSemana();
        OcultaOpcionMensual();
        SeleccionarFila();
        $('#btnActualizar').hide();
    }
    else {
        IniciarPrecargaBancaSeguros();
        MostrarModalConfirmar(3, "Usted no se encuentra logueado o con permisos para acceder a esa pagina", 'sessLogOut()', 'sessLogOut()');
    }
});

function InicializarGrilla() {
    oTableReporte = $('#grvPlanos').dataTable({
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
            { "data": "IdProgramacion", "visible": false, "searchable": false },
            { "data": "Objetivo", "visible": false, "searchable": false },
            { "data": "FechaInicio", "visible": false, "searchable": false },
            { "data": "FechaFin", "visible": false, "searchable": false },
            { "data": "IdAseguradora", "visible": false, "searchable": false },
            { "data": "Separador", "visible": false, "searchable": false },
            { "data": "CodigoFiltro", "visible": false, "searchable": false },
            { "data": "FechaEjecucion", "visible": false, "searchable": false },
            { "data": "DiaSemanal", "visible": false, "searchable": false },
            { "data": "DiaMes", "visible": false, "searchable": false },
            { "data": "NumeroSemana", "visible": false, "searchable": false },
            { "data": "DiaSemana", "visible": false, "searchable": false },
            { "data": "Campos", "visible": false, "searchable": false },
            { "data": "Filtros", "visible": false, "searchable": false },
            { "data": "NombreArchivo" },
            { "data": "FrecuenciaTipoProgramacion" },
            { "data": "Estado" },
            { "data": "RutaFTP" },
            { "data": "UltimaEjecucion" },
            { "data": "Acciones" }
        ],
        "aoColumnDefs": [
            {
                'bSortable': false,
                'aTargets': [0]
            } //disables sorting for column one
        ],
        'iDisplayLength': 5,
        "sPaginationType": "full_numbers",
        "dom": 'T<"clear">lfrtip',
    });

}

function CargarGrillaArchivosPlanos(listDatosArchivos) {
    oTableReporte.fnClearTable(this);
    oSettings = oTableReporte.fnSettings();
    var estadoArchivo = "";
    var nombreProgramacion = "";
    for (var i = 0; i < listDatosArchivos.length; i++) {

        if (listDatosArchivos[i].Estado == "True") {
            estadoArchivo = "ACTIVO";
        } else {
            estadoArchivo = "INACTIVO";
        }

        if (listDatosArchivos[i].FrecuenciaTipoProgramacion === "1")
            nombreProgramacion = "Por Demanda";
        if (listDatosArchivos[i].FrecuenciaTipoProgramacion === "2")
            nombreProgramacion = "Diario";
        if (listDatosArchivos[i].FrecuenciaTipoProgramacion === "3")
            nombreProgramacion = "Semanal";
        if (listDatosArchivos[i].FrecuenciaTipoProgramacion === "4")
            nombreProgramacion = "Mensual"
        FilaArchivo = {
            IdProgramacion: listDatosArchivos[i].IdProgramacion,
            Objetivo: listDatosArchivos[i].Objetivo,
            FechaInicio: listDatosArchivos[i].FechaIni,
            FechaFin: listDatosArchivos[i].FechaFin,
            IdAseguradora: listDatosArchivos[i].IdAseguradora,
            Separador: listDatosArchivos[i].Separador,
            CodigoFiltro: listDatosArchivos[i].CodigoFiltro,
            FechaEjecucion: listDatosArchivos[i].FechaEjecucion,
            DiaSemanal: listDatosArchivos[i].DiaSemanal,
            DiaMes: listDatosArchivos[i].DiaMes,
            NumeroSemana: listDatosArchivos[i].NumeroSemana,
            DiaSemana: listDatosArchivos[i].DiaSemana,
            Campos: listDatosArchivos[i].Campos,
            Filtros: listDatosArchivos[i].Filtros,
            NombreArchivo: listDatosArchivos[i].NombreArchivo,
            FrecuenciaTipoProgramacion: nombreProgramacion,
            Estado: estadoArchivo,
            RutaFTP: listDatosArchivos[i].RutaFTP,
            UltimaEjecucion: listDatosArchivos[i].UltimaEjecucion,
            Acciones: '<img src=../Imagenes/edit.jpg width=20px height=20px title="Actualizar Programacion Archivo" id="cvico" onclick="cvicoclick=true">'
            + '<img src=../Imagenes/delete.png width=20px height=20px onclick="eliminaclick = true" title="Eliminar Programacion Archivo">'
        }

        oTableReporte.oApi._fnAddData(oSettings, FilaArchivo);
    }

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTableReporte.fnDraw();
}

function ConsultarDatosGrilla() {
    var listaDatosArchivos;

    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionPlanos.aspx/ConsultarDatosGrilla",
        dataType: "json",
        success: function (data) {
            listaDatosArchivos = data.d;
        },
        complete: function (data) {
            if (listaDatosArchivos != null) {
                if (listaDatosArchivos.length > 0) {
                    CargarGrillaArchivosPlanos(listaDatosArchivos);
                } else {
                    MostrarMensajeGenerico(2, 'No hay programaciones de archivos parametrizados')
                }
            } else {
                MostrarMensajeGenerico(2, 'No hay programaciones de archivos parametrizados')
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

function SeleccionarFila() {
    var table = $('#grvPlanos').DataTable();
    $('#grvPlanos tbody').on('click', 'tr', function () {
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

        if (eliminaclick) {
            eliminaclick = false;
            var DatosFila = table.fnGetData(this);
            var acept = MostrarModalConfirmar(2, "Esta seguro de eliminar este registro? ", 'EliminarRegistroFila(true, ' + DatosFila.IdProgramacion + ')', 'EliminarRegistroFila(false, ' + DatosFila.IdProgramacion + ')');

        }
    });
}

function EliminarRegistroFila(acept, IdProgramacion) {
    if (acept) {
        acept = false;
        EliminarRegistro(IdProgramacion);
    }
    else {
        LimpiaCampos();
        ConsultarDatosGrilla();
    }
}

function CargarDatosAActualizar(DatosFilas) {
    BorrarEstados();
    BorrarCampos();    
    $('#btnActualizar').show();
    $('#btnGenerar').hide();    
    $('#hdIdProgramacion').val(DatosFilas.IdProgramacion);
    $('#txtNombreArchivo').val(DatosFilas.NombreArchivo);
    $('#txtRutaFtp').val(DatosFilas.RutaFTP);
    $('#txtObjetivo').val(DatosFilas.Objetivo);
    $('#ddlSeparador').val(DatosFilas.Separador);
    if (DatosFilas.CodigoFiltro !== "") {
        if (DatosFilas.CodigoFiltro === "1") {
            $('input[name=opciones]').val("1");            
            $('#polizas').prop('checked', 'checked')
            ConsultarPolizas(1);
        }
        if (DatosFilas.CodigoFiltro === "2") {
            $('input[name=opciones]').val("2");
            $('#cobros').prop('checked', 'checked')            
            ConsultarCobros(1);
        }
        if (DatosFilas.CodigoFiltro === "3") {
            $('input[name=opciones]').val("3");                        
            $('#cancelaciones').prop('checked', 'checked')
            ConsultarFiltrosCancelaciones(1);
        }               
    }

    $('#ddlAseguradora').val(DatosFilas.IdAseguradora);
    /* Programacion*/
    if (DatosFilas.FrecuenciaTipoProgramacion === "Por Demanda") {
        $('#ddlFrecuencia').val(1);
        MostrarProgramacion();
        $('#txtFechaInicialDemanda').val(DatosFilas.FechaInicio);
        $('#txtFechaFinalDemanda').val(ConvertJsonToDate(new Date(parseInt(DatosFilas.FechaFin.substr(6), 0))));
        $('#txtFechaEjecucionDemanda').val(ConvertJsonToDate(new Date(DatosFilas.FechaEjecucion.toString("dd/MM/yyyy"))));
        $('#txtFechaInicialDemanda').attr('disabled', true);
        $('#txtFechaFinalDemanda').attr('disabled', true);
        $('#txtFechaEjecucionDemanda').attr('disabled', true);
        $('#ddlFrecuencia').attr('disabled', true);
    }
    if (DatosFilas.FrecuenciaTipoProgramacion === "Diario") {
        $('#ddlFrecuencia').val(2);
        MostrarProgramacion();
        $('#txtFechaInicialDiario').val(DatosFilas.FechaInicio);
        $('#txtFechaInicialDiario').attr('disabled', true);
        $('#ddlFrecuencia').attr('disabled', true);
    }
    if (DatosFilas.FrecuenciaTipoProgramacion === "Semanal") {
        $('#ddlFrecuencia').val(3);
        MostrarProgramacion();
        $('#txtFechaInicialSemanal').val(DatosFilas.FechaInicio);
        $('#ddlDiaSemanal').val(DatosFilas.DiaSemanal);
        $('#txtFechaInicialSemanal').attr('disabled', true);
        $('#ddlDiaSemanal').attr('disabled', true);
        $('#ddlFrecuencia').attr('disabled', true);
    }
    if (DatosFilas.FrecuenciaTipoProgramacion === "Mensual") {
        $('#ddlFrecuencia').val(4);
        MostrarProgramacion();
        $('#txtFechaInicialMensual').val(DatosFilas.FechaInicio);
        if ((DatosFilas.DiaMes !== "") && (DatosFilas.DiaMes != null)) {
            $('#ddlDiasSemana').val(DatosFilas.DiaMes);
            $('#ddlDiasSemana').attr('disabled', true);
            $('input[name=opcionSemanal]').val(1);
            $('#diaSemana').attr('checked', true);
            $('#diasSemanaProgramacion').show();
        }
        else {
            $('#numeroSemanaProgramacion').val(DatosFilas.NumeroSemana);
            $('#numeroSemanaProgramacion').attr('disabled', true);
            $('#dayWeek').val(DatosFilas.DiaSemana);
            $('#dayWeek').attr('disabled', true);
            $('input[name=opcionSemanal]').val(2);
            $('#mesSemana').attr('checked', true);
            $('#semanaProgramacion').show();
        }
        $('#txtFechaInicialMensual').attr('disabled', true);
        $('#ddlDiaSemanal').attr('disabled', true);
        $('#numeroSemanaProgramacion').attr('disabled', true);
        $('input[name=opcionSemanal]').attr('disabled', true);
        $('#ddlFrecuencia').attr('disabled', true);
    }
    /* Combo Estado */
    if (DatosFilas.Estado === "ACTIVO") {
        $("#ddlEstado").val('True');
    } else {
        $("#ddlEstado").val('False');
    }

    /* Campos */
    var campos = DatosFilas.Campos.split(",");
    var listaCamposAgregados = document.getElementById('lstAgregadoCampos');
    for (var i = 0; i < campos.length; i++) {
        var campo = campos[i];
        listaCamposAgregados.add(new Option(campo, campo, false));
        //$('#lstAgregadoCampos').append($('<option>', { value: campo, text: campo }));
    }

    /* Filtros */
    var filtros = DatosFilas.Filtros.split(",");
    for (var i = 0; i < filtros.length; i++) {
        var filtro = filtros[i];
        var nombreFiltro = "";
        if (DatosFilas.CodigoFiltro === "1") {
            if (filtro === "1")
                nombreFiltro = "Vigente";
            if (filtro === "2")
                nombreFiltro = "Cancelada";
            if (filtro === "3")
                nombreFiltro = "Emisiones";
            $('#lstfunAdicionados').append($('<option>', { value: filtro, text: nombreFiltro }));
        }
        if (DatosFilas.CodigoFiltro === "2") {
            if (filtro === "1")
                nombreFiltro = "Cobro Exitoso";
            if (filtro === "2")
                nombreFiltro = "Cobro pendiente";
            $('#lstfunAdicionados').append($('<option>', { value: filtro, text: nombreFiltro }));
        }
        if (DatosFilas.CodigoFiltro === "3") {
            //ConsultarCancelaciones();
            var listfiltros = document.getElementById("lstfuncAdicionar");
            var listaMenuAdicionados = document.getElementById('lstfunAdicionados');

            for (var j = 0; j < listfiltros.length; j++) {
                if (filtro === listfiltros.options[j].value) {
                    listaMenuAdicionados.add(new Option(listfiltros.options[j].text, listfiltros.options[j].value, false));
                }
            }
        }
    }

    $('#polizas').prop('disabled', true);
    $('#cobros').prop('disabled', true);
    $('#cancelaciones').prop('disabled', true);

}

function IniciarCalendarios() {
    $(document).on('focus', ".fecha", function () {
        $(this).daterangepicker({
            "singleDatePicker": true,
            "minDate": "01/01/1920",
            "showDropdowns": true,
            "locale": {
                "format": "DD/MM/YYYY",
                "separator": " - ",
                "applyLabel": "Apply",
                "cancelLabel": "Cancel",
                "fromLabel": "From",
                "toLabel": "To",
                "customRangeLabel": "Custom",
                "weekLabel": "W",
                "daysOfWeek": [
                     "Do",
                    "Lu",
                    "Ma",
                    "Mi",
                    "Ju",
                    "Vi",
                    "Sa"
                ],
                "monthNames": [
                    "Enero",
                    "Febrero",
                    "Marzo",
                    "Abril",
                    "Mayo",
                    "Junio",
                    "Julio",
                    "Agosto",
                    "Septiembre",
                    "Octubre",
                    "Noviembre",
                    "Diciembre"
                ],
                "firstDay": 1
            },
        }, function (start, end, label) {
            var years = moment().diff(start, 'years');
        })
    });
}

function ValidarRangoFechas() {
    var valido = true;
    if ($('#ddlFrecuencia').val() === "1") /* por demanda */ {
        if ($('#txtFechaInicialDemanda').val() !== '' && $('#txtFechaFinalDemanda').val() !== '') {
            var dia = $.trim($('#txtFechaInicialDemanda').val()).substr(0, 2);
            var mes = $.trim($('#txtFechaInicialDemanda').val()).substr(3, 2) - 1;
            var anio = $.trim($('#txtFechaInicialDemanda').val()).substr(6, 4);
            var fechaInicial = new Date(anio, mes, dia);

            var diaf = $.trim($('#txtFechaFinalDemanda').val()).substr(0, 2);
            var mesf = $.trim($('#txtFechaFinalDemanda').val()).substr(3, 2) - 1;
            var aniof = $.trim($('#txtFechaFinalDemanda').val()).substr(6, 4);
            var fechafinal = new Date(aniof, mesf, diaf);

            if (fechafinal < fechaInicial) {
                valido = false;
                MostrarMensajeGenerico(2, 'La fecha inicial no puede ser mayor que la fecha final.');
            }
            if (((aniof - anio) > 1)) {
                valido = false;
                MostrarMensajeGenerico(2, 'El rango de las fechas no debe superar 12 meses.');
            }
        }
        else {
            valido = true;
        }
    }

    if ($('#ddlFrecuencia').val() === "2") /* diario */ {
        var fechaDiario = $('#txtFechaInicialDiario').val();     
        var fechaActual = moment(new Date()).format("DD/MM/YYYY");
        if (fechaDiario < fechaActual) {
            valido = false;
            MostrarMensajeGenerico(2, 'La fecha debe ser igual o mayor a la fecha actual.');
        }
        else { valido = true; }

    }
    if ($('#ddlFrecuencia').val() === "3") {
        var fechaDiario = $('#txtFechaInicialSemanal').val();
        var fechaActual = moment(new Date()).format("DD/MM/YYYY");
        if (fechaDiario < fechaActual) {
            valido = false;
            MostrarMensajeGenerico(2, 'La fecha debe ser igual o mayor a la fecha actual.');
        }
        else { valido = true; }
    }

    if ($('#ddlFrecuencia').val() === "4") {
        var fechaDiario = $('#txtFechaInicialMensual').val();
        var fechaActual = moment(new Date()).format("DD/MM/YYYY");
        if (fechaDiario < fechaActual) {
            valido = false;
            MostrarMensajeGenerico(2, 'La fecha debe ser igual o mayor a la fecha actual.');
        }
        else { valido = true; }
    }
    return valido;
}

function IniciarDivProgramacion() {
    $('#diario').hide();
    $('#semanal').hide();
    $('#mensual').hide();
    $('#pordemanda').hide();
}

function MostrarProgramacion() {
    var valor = $('#ddlFrecuencia').val();
    if (valor === "")
        IniciarDivProgramacion();
    if (valor === "1") {
        $('#diario').hide();
        $('#semanal').hide();
        $('#mensual').hide();
        $('#pordemanda').show();
        $('#txtFechaEjecucionDemanda').attr('required', '');
        $('#txtFechaEjecucionDemanda').removeClass('parsley-error');
        $('#txtFechaInicialDemanda').attr('required', '');
        $('#txtFechaInicialDemanda').removeClass('parsley-error');
        $('#txtFechaFinalDemanda').attr('required', '');
        $('#txtFechaFinalDemanda').removeClass('parsley-error');
        $('#txtFechaInicialDiario').removeAttr('required', '');
        $('#txtFechaInicialSemanal').removeAttr('required', '');
        $('#ddlDiaSemanal').removeAttr('required', '');
        $('#txtFechaInicialMensual').removeAttr('required', '');
    }
    if (valor === "2") {
        $('#semanal').hide();
        $('#mensual').hide();
        $('#pordemanda').hide();
        $('#diario').show();
        $('#txtFechaInicialDiario').attr('required', '');
        $('#txtFechaInicialDiario').removeClass('parsley-error');
        $('#txtFechaFinalDemanda').removeAttr('required', '');
        $('#txtFechaInicialDemanda').removeAttr('required', '');
        $('#txtFechaEjecucionDemanda').removeAttr('required', '');
        $('#txtFechaInicialSemanal').removeAttr('required', '');
        $('#ddlDiaSemanal').removeAttr('required', '');
        $('#txtFechaInicialMensual').removeAttr('required', '');
    }

    if (valor === "3") {
        $('#diario').hide();
        $('#mensual').hide();
        $('#pordemanda').hide();
        $('#semanal').show();
        $('#txtFechaInicialSemanal').attr('required', '');
        $('#txtFechaInicialSemanal').removeClass('parsley-error');
        $('#ddlDiaSemanal').attr('required', '');
        $('#ddlDiaSemanal').removeClass('parsley-error');
        $('#txtFechaFinalDemanda').removeAttr('required', '');
        $('#txtFechaInicialDemanda').removeAttr('required', '');
        $('#txtFechaEjecucionDemanda').removeAttr('required', '');
        $('#txtFechaInicialDiario').removeAttr('required', '');
        $('#txtFechaInicialMensual').removeAttr('required', '');
    }

    if (valor === "4") {
        $('#diario').hide();
        $('#semanal').hide();
        $('#pordemanda').hide();
        $('#mensual').show();
        $('#txtFechaInicialMensual').attr('required', '');
        $('#txtFechaInicialMensual').removeClass('parsley-error');
        $('#txtFechaFinalDemanda').removeAttr('required', '');
        $('#txtFechaInicialDemanda').removeAttr('required', '');
        $('#txtFechaEjecucionDemanda').removeAttr('required', '');
        $('#txtFechaInicialSemanal').removeAttr('required', '');
        $('#ddlDiaSemanal').removeAttr('required', '');
        $('#txtFechaInicialDiario').removeAttr('required', '');
    }
}

function CargarCatalogo() {

    DataCatalogo = ConsultarCatalogo();
    if (DataCatalogo != null && DataCatalogo != undefined)
        LlenarCombo(DataCatalogo, 'ddlAseguradora');
}

function ConsultarCatalogo() {
    var DataCatalogo;
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionPlanos.aspx/ConsultarAseguradoras",
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
    $('#' + dropDownList).append($('<option>', { value: "", text: '-- Seleccione --' }));
    $('#' + dropDownList).append($('<option>', { value: "0", text: 'Todas' }));
    for (var i = 0; i < data.length; i++) {
        switch (dropDownList) {
            case 'ddlAseguradora':
                $('#' + dropDownList).append($('<option>', { value: data[i]["IdAseguradora"], text: data[i]["Nombre"] }));
                break;
        }
    }
    var optionA = $('#' + dropDownList).val();
}

function BorrarEstados() {
    $('#lstfuncAdicionar').find('option').remove().end().append().val();
    $('#lstfunAdicionados').find('option').remove().end().append().val();
}

function BorrarCampos() {
    $('#lstAdicionCampos').find('option').remove().end().append().val();
    $('#lstAgregadoCampos').find('option').remove().end().append().val();
}

function AdicionaEstado() {
    var adicionado = false;
    var idMenuSeleccionado = $("#lstfuncAdicionar").val();
    $('#lstfunAdicionados').removeClass('parsley-error');
    $('#lstfunAdicionados').removeClass('parsley-required');
    $('#lstfunAdicionados').removeClass('parsley-errors-list filled');
    $('#lstfunAdicionados').removeAttr('required', '');
    var nombreMenuSeleccionado = $("#lstfuncAdicionar option:selected").text();
    if (idMenuSeleccionado != undefined) {
        var listaMenuAdicionados = document.getElementById('lstfunAdicionados');
        if (listaMenuAdicionados.options.length > 0) {

            for (var i = 0; i < listaMenuAdicionados.options.length; i++) {
                if (listaMenuAdicionados.options[i].value === idMenuSeleccionado) {
                    adicionado = true;
                    MostrarMensajeGenerico(2, 'El Estado ya se adicionó a la lista.');
                    break;
                }
            }

            if (!adicionado) {
                listaMenuAdicionados.add(new Option(nombreMenuSeleccionado, idMenuSeleccionado, false));
                $('#lstfunAdicionados option[value="' + idMenuSeleccionado + '"]').attr('selected', 'selected');
            }
        }
        else
            listaMenuAdicionados.add(new Option(nombreMenuSeleccionado, idMenuSeleccionado, false));
        $('#lstfunAdicionados option[value="' + idMenuSeleccionado + '"]').attr('selected', 'selected');
        $('#lstfunAdicionados').removeClass('parsley-error');
        $('#lstfunAdicionados').removeClass('parsley-required');
        $('#lstfunAdicionados').removeClass('parsley-errors-list filled');
        $('#lstfunAdicionados').removeAttr('required', '');

    }
    else {
        MostrarMensajeGenerico(2, "Debe seleccionar un estado de la lista");
    }
}

function EliminaEstado() {
    var listaMenuAdicionados = document.getElementById('lstfunAdicionados');
    for (var i = 0; i < listaMenuAdicionados.options.length; i++) {
        if (listaMenuAdicionados.options[i].selected)
            listaMenuAdicionados.remove(i);
    }
}

function AdicionaCampos() {
    var adicionado = false;
    var idCampoSeleccionado = $("#lstAdicionCampos").val();
    $('#lstAgregadoCampos').removeClass('parsley-error');
    $('#lstAgregadoCampos').removeClass('parsley-required');
    $('#lstAgregadoCampos').removeClass('parsley-errors-list filled');
    $('#lstAgregadoCampos').removeAttr('required', '');
    var nombreCampoSeleccionado = $("#lstAdicionCampos option:selected").text();
    if (idCampoSeleccionado != undefined) {
        var listaCamposAdicionados = document.getElementById('lstAgregadoCampos');
        if (listaCamposAdicionados.options.length > 0) {

            for (var i = 0; i < listaCamposAdicionados.options.length; i++) {
                if (listaCamposAdicionados.options[i].value === idCampoSeleccionado) {
                    adicionado = true;
                    MostrarMensajeGenerico(2, 'El Campo ya se adicionó a la lista.');
                    break;
                }

            }

            if (!adicionado) {
                listaCamposAdicionados.add(new Option(nombreCampoSeleccionado, idCampoSeleccionado, false));
                $('#lstAgregadoCampos option[value="' + idCampoSeleccionado + '"]').attr('selected', 'selected');
            }
        }
        else
            listaCamposAdicionados.add(new Option(nombreCampoSeleccionado, idCampoSeleccionado, false));
        $('#lstAgregadoCampos option[value="' + idCampoSeleccionado + '"]').attr('selected', 'selected');
        $('#lstAgregadoCampos').removeClass('parsley-error');
        $('#lstAgregadoCampos').removeClass('parsley-required');
        $('#lstAgregadoCampos').removeClass('parsley-errors-list filled');
        $('#lstAgregadoCampos').removeAttr('required', '');

    }
    else {
        MostrarMensajeGenerico(2, "Debe seleccionar un estado de la lista");
    }
}

function EliminaCampos() {
    var listaMenuAdicionados = document.getElementById('lstAgregadoCampos');
    for (var i = 0; i < listaMenuAdicionados.options.length; i++) {
        if (listaMenuAdicionados.options[i].selected)
            listaMenuAdicionados.remove(i);
    }
}

function ConsultarPolizas(parametro) {
    radio = 1;
    if (parametro === 0) {
        BorrarEstados();
        BorrarCampos();
    }

    $('#lstfuncAdicionar').append('<option value="1">Vigente</option>');
    $('#lstfuncAdicionar').append('<option value="2">Cancelada</option>');
    $('#lstfuncAdicionar').append('<option value="3">Emisiones</option>');
    if ($('#polizas').is(':checked')) {
        var opcion = $('#polizas').val();
        var resultadoCampos;
        $.ajax({
            type: "POST",
            cache: false,
            async: false,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionPlanos.aspx/ConsultarPolizas",
            data: "{'opcion':'" + opcion + "'}",
            dataType: "json",
            success: function (data) {
            },
            complete: function (data) {
                resultadoCampos = data.responseJSON.d
                if (resultadoCampos.length > 0) {
                    LlenarListaDesplegable(resultadoCampos, 'lstAdicionCampos', "Campos", "Campos");
                }
                else {
                    MostrarMensajeGenerico(2, 'No existen opciones configuradas.')
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

function ConsultarCobros(parametro) {
    radio = 2;
    if (parametro === 0) {
        BorrarEstados();
        BorrarCampos();
    }

    $('#lstfuncAdicionar').append('<option value="1">Cobro Exitoso</option>');
    $('#lstfuncAdicionar').append('<option value="2">Cobro Pendiente</option>');
    if ($('#cobros').is(':checked')) {
        var opcion = $('#cobros').val();
        var resultadoCampos;
        $.ajax({
            type: "POST",
            cache: false,
            async: false,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionPlanos.aspx/ConsultarCobros",
            data: "{'opcion':'" + opcion + "'}",
            dataType: "json",
            success: function (data) {
            },
            complete: function (data) {
                resultadoCampos = data.responseJSON.d
                if (resultadoCampos.length > 0) {
                    LlenarListaDesplegable(resultadoCampos, 'lstAdicionCampos', "Campos", "Campos");
                }
                else {
                    MostrarMensajeGenerico(2, 'No existen opciones configuradas.')
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

function ConsultarCancelaciones(parametro) {
    if ($('#cancelaciones').is(':checked')) {
        var opcion = $('#cancelaciones').val();
        var resultadoCampos;
        $.ajax({
            type: "POST",
            cache: false,
            async: false,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionPlanos.aspx/ConsultarCancelaciones",
            data: "{'opcion':'" + opcion + "'}",
            dataType: "json",
            success: function (data) {
            },
            complete: function (data) {
                resultadoCampos = data.responseJSON.d
                if (resultadoCampos.length > 0) {
                    LlenarListaDesplegable(resultadoCampos, 'lstAdicionCampos', "Campos", "Campos");                    
                }
                else {
                    MostrarMensajeGenerico(2, 'No existen opciones configuradas.')
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

function ConsultarFiltrosCancelaciones(parametro) {
    radio = 3;
    if (parametro === 0) {
        BorrarEstados();
        BorrarCampos();
    }
   
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionPlanos.aspx/ConsultarFiltrosCancelaciones",
        dataType: "json",
        success: function (data) {
        },
        complete: function (data) {
            resultadoCampos = data.responseJSON.d
            if (resultadoCampos.length > 0) {
                LlenarListaDesplegable(resultadoCampos, 'lstfuncAdicionar', "IdCausalNovedad", "Campos");
                ConsultarCancelaciones(0)
            }
            else {
                MostrarMensajeGenerico(2, 'No existen opciones configuradas.')
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

function GenerarArchivo() {
    var datosArchivo = {};
    var resultado;
    ValidaDiv('formProgPlanos');
    var resultValidaCampos = validarCamposFiltros();
    var resultFechas = ValidarRangoFechas();
    var Resultado = $('#formProgPlanos').parsley().validate();
    if ((Resultado) && (resultFechas) && (resultValidaCampos)) {
        datosArchivo = LlenarEntidadArchivo();
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionPlanos.aspx/GuardarDatosArchivoPlano",
            data: "{datosArchivo:" + JSON.stringify(datosArchivo) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (resultado.Error == undefined) {
                    MostrarMensajeGenerico(3, data.responseText);
                }
                else if (resultado.Error) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                }
                else {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                    LimpiaCampos();
                    ConsultarDatosGrilla();
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

function LlenarEntidadArchivo() {
    var ArchivoPlano = {};

    ArchivoPlano.IdProgramacion = $('#hdIdProgramacion').val();
    if (ArchivoPlano.IdProgramacion === "")
        ArchivoPlano.IdProgramacion = 0;
    ArchivoPlano.NombreArchivo = $('#txtNombreArchivo').val();
    ArchivoPlano.Estado = $('#ddlEstado').val();
    ArchivoPlano.RutaFTP = $('#txtRutaFtp').val();
    ArchivoPlano.Objetivo = $('#txtObjetivo').val();
    ArchivoPlano.Separador = $('#ddlSeparador').val();
    ArchivoPlano.FrecuenciaTipoProgramacion = $('#ddlFrecuencia').val();
    ArchivoPlano.IdAseguradora = $('#ddlAseguradora').val();
    ArchivoPlano.CodigoFiltro = radio;   

    if (ArchivoPlano.FrecuenciaTipoProgramacion === "1") {
        ArchivoPlano.FechaEjecucion = $('#txtFechaEjecucionDemanda').val();
        if ($('#txtFechaInicialDemanda').val() !== '') {
            var diaDem = $.trim($('#txtFechaInicialDemanda').val()).substr(0, 2);
            var mesDem = $.trim($('#txtFechaInicialDemanda').val()).substr(3, 2) - 1;
            var anioDem = $.trim($('#txtFechaInicialDemanda').val()).substr(6, 4);
            var fechaInicialDeman = new Date(anioDem, mesDem, diaDem);
            ArchivoPlano.FechaInicio = fechaInicialDeman;
        }
        if ($('#txtFechaFinalDemanda').val() !== '') {
            var diaFDem = $.trim($('#txtFechaFinalDemanda').val()).substr(0, 2);
            var mesFDem = $.trim($('#txtFechaFinalDemanda').val()).substr(3, 2) - 1;
            var anioFDem = $.trim($('#txtFechaFinalDemanda').val()).substr(6, 4);
            var fechaFinalDeman = new Date(anioFDem, mesFDem, diaFDem);
            ArchivoPlano.FechaFin = fechaFinalDeman;
        }
    }
    if (ArchivoPlano.FrecuenciaTipoProgramacion === "2") {
        if ($('#txtFechaInicialDiario').val() !== '') {
            var diaD = $.trim($('#txtFechaInicialDiario').val()).substr(0, 2);
            var mesD = $.trim($('#txtFechaInicialDiario').val()).substr(3, 2) - 1;
            var anioD = $.trim($('#txtFechaInicialDiario').val()).substr(6, 4);
            var fechaInicial = new Date(anioD, mesD, diaD);
            ArchivoPlano.FechaInicio = fechaInicial;
        }

    }

    if (ArchivoPlano.FrecuenciaTipoProgramacion === "3") {
        if ($('#txtFechaInicialSemanal').val() !== '') {
            var diaSem = $.trim($('#txtFechaInicialSemanal').val()).substr(0, 2);
            var mesSem = $.trim($('#txtFechaInicialSemanal').val()).substr(3, 2) - 1;
            var anioSem = $.trim($('#txtFechaInicialSemanal').val()).substr(6, 4);
            var fechaInicialSema = new Date(anioSem, mesSem, diaSem);
            ArchivoPlano.FechaInicio = fechaInicialSema;
        }
        ArchivoPlano.DiaSemanal = $('#ddlDiaSemanal').val();
    }
    if (ArchivoPlano.FrecuenciaTipoProgramacion === "4") {
        if ($('#txtFechaInicialMensual').val() !== '') {
            var diaMen = $.trim($('#txtFechaInicialMensual').val()).substr(0, 2);
            var mesMen = $.trim($('#txtFechaInicialMensual').val()).substr(3, 2) - 1;
            var anioMen = $.trim($('#txtFechaInicialMensual').val()).substr(6, 4);
            var fechaInicialMens = new Date(anioMen, mesMen, diaMen);
            ArchivoPlano.FechaInicio = fechaInicialMens;
        }
        var opcionescogida = $('input[name=opcionSemanal]').val();
        if (opcionescogida === "1") {
            ArchivoPlano.DiaMes = $('#ddlDiasSemana').val();
        }
        if (opcionescogida === "2") {
            ArchivoPlano.NumeroSemana = $('#numeroSemanaProgramacion').val();
            ArchivoPlano.DiaSemana = $('#dayWeek').val();
        }
    }

    var listcampos = document.getElementById("lstAgregadoCampos");
    if (listcampos.length > 0) {
        var campos = "";
        var campo = "";
        for (var i = 0; i < listcampos.length; i++) {
            campo = listcampos.options[i].value;
            if (i === 0) {
                campos = campo;
            }
            else {
                campos = campos + "," + campo;
            }
        }
        ArchivoPlano.Campos = campos;
    }
    else {
        $('#lstAgregadoCampos').attr('required', '');
        $('#lstAgregadoCampos').removeClass('parsley-error');
    }

    var listfiltros = document.getElementById("lstfunAdicionados");
    if (listfiltros.length > 0) {
        var filtros = "";
        var filtro = "";
        for (var i = 0; i < listfiltros.length; i++) {
            filtro = listfiltros.options[i].value;
            if (i === 0) {
                filtros = filtro;
            }
            else {
                filtros = filtros + "," + filtro;
            }
        }
        ArchivoPlano.Filtros = filtros;
    }
    else {
        $('#lstfunAdicionados').attr('required', '');
        $('#lstfunAdicionados').removeClass('parsley-error');
    }
    return ArchivoPlano;
}

function LlenaComboDiasSemana() {
    $('#ddlDiasSemana').append($('<option>', { value: "", text: '-- Seleccione --' }));
    for (var i = 1; i <= 31; i++) {
        $('#ddlDiasSemana').append($('<option>', { value: i, text: i }));
    }
    $('#ddlDiasSemana').append($('<option>', { value: "32", text: 'Ultimo día' }));
}

function MostrarOpcionMensual() {
    if ($('#diaSemana').is(':checked')) {
        $('#semanaProgramacion').hide();
        $('#diasSemanaProgramacion').show();
        $('#ddlDiasSemana').attr('required', '');
        $('#ddlDiasSemana').removeClass('parsley-error');
    }
    else if ($('#mesSemana').is(':checked')) {
        $('#diasSemanaProgramacion').hide();
        $('#semanaProgramacion').show();
        $('#diaSemanaProgramacion').attr('required', '');
        $('#diaSemanaProgramacion').removeClass('parsley-error');
        $('#dayWeek').attr('required', '');
        $('#dayWeek').removeClass('parsley-error');
    }
    else { OcultaOpcionMensual(); }
}

function OcultaOpcionMensual() {
    $('#semanaProgramacion').hide();
    $('#diasSemanaProgramacion').hide();
}

function ActualizarArchivo() {
    var datosArchivo = {};
    var resultado;
    RemoverAtributoRequeridoFechas();
    ValidaDiv('formProgPlanos');
    var Resultado = $('#formProgPlanos').parsley().validate();
    if (Resultado) {
        datosArchivo = LlenarEntidadArchivo();
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionPlanos.aspx/ActualizarDatosArchivoPlano",
            data: "{datosArchivo:" + JSON.stringify(datosArchivo) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (resultado.Error == undefined) {
                    MostrarMensajeGenerico(3, data.responseText);
                }
                else if (resultado.Error) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                }
                else {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                    LimpiaCampos();
                    ConsultarDatosGrilla();
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

function RemoverAtributoRequeridoFechas() {
    $('#txtFechaInicialDemanda').removeAttr('required', '');
    $('#txtFechaInicialDemanda').removeAttr('data-parsley-pattern', '');
    $('#txtFechaFinalDemanda').removeAttr('required', '');
    $('#txtFechaFinalDemanda').removeAttr('data-parsley-pattern', '');
    $('#txtFechaEjecucionDemanda').removeAttr('required', '');
    $('#txtFechaEjecucionDemanda').removeAttr('data-parsley-pattern', '');
    $('#txtFechaInicialDiario').removeAttr('required', '');
    $('#txtFechaInicialDiario').removeAttr('data-parsley-pattern', '');
    $('#txtFechaInicialSemanal').removeAttr('required', '');
    $('#txtFechaInicialSemanal').removeAttr('data-parsley-pattern', '');
    $('#txtFechaInicialMensual').removeAttr('required', '');
    $('#txtFechaInicialMensual').removeAttr('data-parsley-pattern', '');
}

function LimpiaCampos() {
    $('#txtNombreArchivo').val('');
    $('#hdIdProgramacion').val('');
    $('#ddlEstado').val('');
    $('#txtRutaFtp').val('');
    $('#txtObjetivo').val('');
    $('#ddlSeparador').val('');
    $('#ddlFrecuencia').val('');
    $('#ddlFrecuencia').prop('disabled', false);
    $('#txtFechaInicialDiario').val('');
    $('#txtFechaInicialDiario').prop('disabled', false);
    $('#txtFechaInicialSemanal').val('');
    $('#txtFechaInicialSemanal').prop('disabled', false);
    $('#ddlDiaSemanal').val('');
    $('#ddlDiaSemanal').prop('disabled', false);
    $('#txtFechaInicialMensual').val('');
    $('#txtFechaInicialMensual').prop('disabled', false);
    $('#diaSemana').prop('checked', false);
    $('#diaSemana').prop('disabled', false);
    $('#mesSemana').prop('checked', false);
    $('#mesSemana').prop('disabled', false);
    $('#numeroSemanaProgramacion').val('');
    $('#numeroSemanaProgramacion').prop('disabled', false);
    $('#dayWeek').val('');
    $('#dayWeek').prop('disabled', false);
    $('#ddlDiasSemana').val('');
    $('#ddlDiasSemana').prop('disabled', false);
    $('#txtFechaEjecucionDemanda').val('');
    $('#txtFechaEjecucionDemanda').prop('disabled', false);
    $('#txtFechaInicialDemanda').val('');
    $('#txtFechaInicialDemanda').prop('disabled', false);
    $('#txtFechaFinalDemanda').val('');
    $('#txtFechaFinalDemanda').prop('disabled', false);
    $('#ddlAseguradora').val('');
    $('#polizas').prop('checked', false);
    $('#cobros').prop('checked', false);
    $('#cancelaciones').prop('checked', false);
    BorrarCampos();
    BorrarEstados();
    IniciarDivProgramacion();
    $('#btnGenerar').show();
    $('#btnActualizar').hide();
    $('#polizas').attr('disabled', false);
    $('#cobros').attr('disabled', false);
    $('#cancelaciones').attr('disabled', false);
}

function EliminarRegistro(idProgramacion) {
    var id = idProgramacion;
    if (id !== "") {
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionPlanos.aspx/EliminarDatosArchivoPlano",
            data: "{idProgramacion:" + JSON.stringify(id) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (resultado.Error == undefined) {
                    MostrarMensajeGenerico(3, data.responseText);
                }
                else if (resultado.Error) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                    ConsultarDatosGrilla();
                }
                else {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                    LimpiaCampos();
                    ConsultarDatosGrilla();
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

function validarCamposFiltros() {
    var valido = true;
    if (($('#lstfunAdicionados').val() === "") || ($('#lstfunAdicionados').val() == null)) {
        valido = false;
        MostrarMensajeGenerico(2, 'Debe escoger como mínimo un filtro.');
        $('#lstfunAdicionados').attr('required', '');
    }

    if (($('#lstAgregadoCampos').val() === "") || ($('#lstAgregadoCampos').val() == null)) {
        valido = false;
        MostrarMensajeGenerico(2, 'Debe escoger como mínimo un campo.');
        $('#lstAgregadoCampos').attr('required', '');
    }

    return valido;

}
