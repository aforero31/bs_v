var oTableReporte;

$(document).ready(function () {
    if (initSession()) {
        IniciarPrecargaBancaSeguros();

        $('#txtFechaInicial').daterangepicker({
            "singleDatePicker": true,
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
        });

        $('#txtFechaFinal').daterangepicker({
            "singleDatePicker": true,
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
        });

        InicializarGrilla();
        CargarSecciones(true);
        CargarComboTablasAuditadas();
        document.getElementById("btnExportar").disabled = "disabled";
        DetenerPrecargaBancaSeguros();
    }
    else {
        IniciarPrecargaBancaSeguros();
        MostrarModalConfirmar(3, "Usted no se encuentra logueado o con permisos para acceder a esa pagina", 'sessLogOut()', 'sessLogOut()');
    }
});

function ValidarRangoFechas() {
    var valido = true;
    if ($('#txtFechaInicial').val() !== '' && $('#txtFechaFinal').val() !== '') {
        var dia = $.trim($('#txtFechaInicial').val()).substr(0, 2);
        var mes = $.trim($('#txtFechaInicial').val()).substr(3, 2) - 1;
        var anio = $.trim($('#txtFechaInicial').val()).substr(6, 4);
        var fechaInicial = new Date(anio, mes, dia);

        var diaf = $.trim($('#txtFechaFinal').val()).substr(0, 2);
        var mesf = $.trim($('#txtFechaFinal').val()).substr(3, 2) - 1;
        var aniof = $.trim($('#txtFechaFinal').val()).substr(6, 4);
        var fechafinal = new Date(aniof, mesf, diaf);

        if (fechafinal < fechaInicial) {
            valido = false;
            MostrarMensajeGenerico(2, 'La fecha inicial no puede ser mayor que la fecha final.');
        }
        else
        {
            if (addMonths(fechaInicial, 6) <= fechafinal) {
                valido = false;
                MostrarMensajeGenerico(2, 'El rango de consulta no puede superar 6 meses.');
            }
        }
    }
    else {
        valido = true;
    }

    return valido;
}

function InicializarGrilla() {
    oTableReporte = $('#gvAuditoria').dataTable({
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
            { "data": "IdAuditoria", "visible": false, "searchable": false },
            { "data": "Tipo" },
            { "data": "NombreTabla" },
            { "data": "CampoLlave" },
            { "data": "ValorLlave" },
            { "data": "Campo" },
            { "data": "ValorAnterior" },
            { "data": "NuevoValor" },
            { "data": "FechaActualizacion" },
            { "data": "Usuario" }
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

function CargarComboTablasAuditadas() {
    var nombreTabla = 'SEG_TablaAuditada';
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "ConsultarLog.aspx/ConsultarTodosCatalogo",
        data: "{'nombreTabla':'" + nombreTabla + "'}",
        dataType: "json",
        success: function (data) {
            DataCatalogo = data.d;
            if (DataCatalogo != null && DataCatalogo !== undefined) {
                ListTablas = Enumerable.From(DataCatalogo.ListTablaAuditada).Select().ToArray();
                LlenarListaDesplegable(ListTablas, 'ddlTablaAuditada', "Nombre", "Nombre");
            }
        },
        error: function (data) {
            var r = data.responseText;
            var errorMessage = r.Message;
            MostrarMensajeGenerico(3, errorMessage);
        }
    });
}

function ConsultarAuditoria() {
    ValidaDiv('panelConsultar');
    var Resultado = $('#panelConsultar').parsley().validate();
    if (Resultado && ValidarRangoFechas()) {
        IniciarPrecargaBancaSeguros();
        var datosAuditoria = {};
        datosAuditoria = LlenarEntidadAuditoria();
        var auditorias;
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ConsultarLog.aspx/ConsultarAuditoria",
            data: "{auditoria:" + JSON.stringify(datosAuditoria) + "}",
            dataType: "json",
            success: function (data) {
                auditorias = data.d;
            },
            complete: function (data) {
                if (auditorias.length > 0) {
                    CargarSecciones(false);
                    CargarGrillaAuditoria(auditorias);
                    CargarAuditoriaParaExportar(auditorias);
                    document.getElementById("btnExportar").disabled = false;
                }
                else {
                    MostrarMensajeGenerico(2, 'No existen registros en el sistema con el filtro seleccionado.');
                    document.getElementById("btnExportar").disabled = true;
                }
                DetenerPrecargaBancaSeguros();
            },
            error: function (data) {
                var errorMessage = data.responseText;
                MostrarMensajeGenerico(3, errorMessage)
                document.getElementById("btnExportar").disabled = true;
                DetenerPrecargaBancaSeguros();
            }
        });
    }
}

function CargarGrillaAuditoria(auditorias) {
    var result = auditorias;
    oSettings = oTableReporte.fnSettings();
    oTableReporte.fnClearTable(this);

    for (var i = 0; i < result.length; i++) {
        var anio, mes, dia, hora, minutos, fechaFormateada, tipo

        switch (result[i].Tipo) {
            case "U":
                tipo = "Actualización";
                break;
            case "I":
                tipo = "Inserción";
                break;
            case "D":
                tipo = "Eliminación";
                break;
        }

        result[i].FechaActualizacion = new Date(parseInt(result[i].FechaActualizacion.substr(6), 0));

        anio = result[i].FechaActualizacion.getFullYear();
        mes = pad(result[i].FechaActualizacion.getMonth() + 1);
        dia = pad(result[i].FechaActualizacion.getDate());
        hora = pad(result[i].FechaActualizacion.getHours());
        minutos = pad(result[i].FechaActualizacion.getMinutes());

        fechaFormateada = dia + "/" + mes + "/" + anio + " " + hora + ":" + minutos;

        FilaAuditoria = {
            IdAuditoria: result[i].IdAuditoria,
            Tipo: tipo,
            Nombre: result[i].Nombre,
            NombreTabla: result[i].NombreTabla,
            CampoLlave: result[i].CampoLlave,
            ValorLlave: result[i].ValorLlave,
            Campo: result[i].Campo,
            ValorAnterior: result[i].ValorAnterior,
            NuevoValor: result[i].NuevoValor,
            FechaActualizacion: fechaFormateada,
            Usuario: result[i].Usuario
        }

        oTableReporte.oApi._fnAddData(oSettings, FilaAuditoria);
    }

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTableReporte.fnDraw();
}

function LlenarEntidadAuditoria() {
    var Auditoria = {};

    Auditoria.NombreTabla = $('#ddlTablaAuditada').val();
    Auditoria.Tipo = $('#ddlEstado').val();
    Auditoria.Usuario = $('#txtUsuario').val();

    if ($('#txtFechaInicial').val() !== '') {
        var dia = $.trim($('#txtFechaInicial').val()).substr(0, 2);
        var mes = $.trim($('#txtFechaInicial').val()).substr(3, 2) - 1;
        var anio = $.trim($('#txtFechaInicial').val()).substr(6, 4);
        var fechaInicial = new Date(anio, mes, dia);
        Auditoria.FechaIniActualizacion = fechaInicial;
    }

    if ($('#txtFechaFinal').val() !== '') {
        var diaf = $.trim($('#txtFechaFinal').val()).substr(0, 2);
        var mesf = $.trim($('#txtFechaFinal').val()).substr(3, 2) - 1;
        var aniof = $.trim($('#txtFechaFinal').val()).substr(6, 4);
        var fechafinal = new Date(aniof, mesf, diaf);
        Auditoria.FechaFinActualizacion = fechafinal;
    }

    return Auditoria;
}

function LimpiarControles() {
    $('#txtFechaInicial').val("");
    $('#txtFechaFinal').val("");
    $('#txtUsuario').val("");
}

function CargarAuditoriaParaExportar(auditorias) {
    var iframeExcel = document.getElementById("iframeExcel");
    if (iframeExcel != null) {
        var tab_text = "<table border='1px'>";
        tab_text = tab_text + "<tr>";
        tab_text = tab_text + "<th>Tipo</th>";
        tab_text = tab_text + "<th>Nombre Tabla</th>";
        tab_text = tab_text + "<th>Campo Llave</th>";
        tab_text = tab_text + "<th>Valor Llave</th>";
        tab_text = tab_text + "<th>Campo</th>";
        tab_text = tab_text + "<th>Valor Anterior</th>";
        tab_text = tab_text + "<th>Nuevo Valor</th>";
        tab_text = tab_text + "<th>Fecha</th>";
        tab_text = tab_text + "<th>Usuario</th>";
        tab_text = tab_text + "</tr>";

        for (var i = 0; i < auditorias.length; i++) {

            var anio, mes, dia, hora, minutos, fechaFormateada, tipo

            switch (auditorias[i].Tipo) {
                case "U":
                    tipo = "Actualización";
                    break;
                case "I":
                    tipo = "Inserción";
                    break;
                case "D":
                    tipo = "Eliminación";
                    break;
            }

            anio = auditorias[i].FechaActualizacion.getFullYear();
            mes = pad(auditorias[i].FechaActualizacion.getMonth() + 1);
            dia = pad(auditorias[i].FechaActualizacion.getDate());
            hora = pad(auditorias[i].FechaActualizacion.getHours());
            minutos = pad(auditorias[i].FechaActualizacion.getMinutes());

            fechaFormateada = dia + "/" + mes + "/" + anio + " " + hora + ":" + minutos;

            tab_text = tab_text + "<tr>";

            tab_text = tab_text + "<td>" + tipo + "</td>";
            tab_text = tab_text + "<td>" + auditorias[i].NombreTabla + "</td>";
            tab_text = tab_text + "<td>" + auditorias[i].CampoLlave + "</td>";
            tab_text = tab_text + "<td>" + auditorias[i].ValorLlave + "</td>";
            tab_text = tab_text + "<td>" + auditorias[i].Campo + "</td>";
            tab_text = tab_text + "<td>" + auditorias[i].ValorAnterior + "</td>";
            tab_text = tab_text + "<td>" + auditorias[i].NuevoValor + "</td>";
            tab_text = tab_text + "<td>" + fechaFormateada + "</td>";
            tab_text = tab_text + "<td>" + auditorias[i].Usuario + "</td>";

            tab_text = tab_text + "</tr>";
        }

        tab_text = tab_text + "</table>";
        iframeExcel.contentWindow.document.body.innerHTML = tab_text;
    }
}

function ExportarAExcel() {
    var ua = window.navigator.userAgent;
    var msie = ua.indexOf("MSIE ");
    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // Internet Explorer
    {
        var contenido = iframeExcel.document.body.innerHTML;
        iframeExcel.document.open("txt/html", "replace");
        iframeExcel.document.write(contenido);
        iframeExcel.document.close();
        iframeExcel.focus();
        sa = iframeExcel.document.execCommand("SaveAs", true, "Auditoria.xls");
    }
    else                 //other browser 
    {
        var contenido2 = iframeExcel.contentWindow.document.body.innerHTML;
        sa = window.open('data:application/vnd.ms-excel,' + escape(contenido2));
    }

    return (sa);
}


