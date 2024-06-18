var cvicoclick = false;
var rowgvReporte;
var oTableReporte;

$(document).ready(function () {
    if (initSession()) {
        IniciarPrecargaBancaSeguros();
        InicializarGrilla();
        CargarSecciones();
        CargarComboTipoIdenti();
        DetenerPrecargaBancaSeguros();
        SelecionarFila();     
    }
    else {
        IniciarPrecargaBancaSeguros();
        MostrarModalConfirmar(3, "Usted no se encuentra logueado o con permisos para acceder a esa pagina", 'sessLogOut()', 'sessLogOut()');
    }
});

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
            AccionImprimirPoliza(DatosFila);

        }
    });
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
            { "data": "IdVenta", "visible": false, "searchable": false },
            { "data": "IdSeguro", "visible": false, "searchable": false },
            { "data": "NumeroPoliza" },
            { "data": "NombrePlan" },
            { "data": "NombreSeguro" },
            { "data": "Valor", "class": "num" },
            { "data": "CuentaCliente" },
            { "data": "Imprimir" }
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

function CargarSecciones() {
    DeshabilitarDivYContenido("panelGrillaReporte", true);
    DeshabilitarDivYContenido("panelInformacionBasica", true);
}

function CargarComboTipoIdenti() {
    var ListTipoIdentificacion = $.jStorage.get("ListaTipoIdentificacion");
    if (ListTipoIdentificacion != undefined) {
        LlenarComboTipoIdenti(ListTipoIdentificacion, 'ddlTipoIdentificacion');
    }
}

function LlenarComboTipoIdenti(data, dropDownList) {
    //$('#' + dropDownList).append($('<option>', { value: "0", text: 'Seleccione una opción' }));
    for (var i = 0; i < data.length; i++) {
        switch (dropDownList) {
            case 'ddlTipoIdentificacion':
                $('#' + dropDownList).append($('<option>', { value: data[i]["IdTipoIdentificacion"], text: data[i]["Nombre"] }));
                break;
        }
    }

    var optionA = $('#' + dropDownList).val();
}

function BuscarPolizaCliente() {
    ValidaDiv('panelConsultar');
    var Resultado = $('#panelConsultar').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        var datosCliente = {};
        datosCliente = LlenarEntidadCliente();
        var polizaCliente;
        var IdUsuario = $.jStorage.get('IdUsuario');
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ReImpresionPoliza.aspx/ConsultarVentaPorCliente",
            data: "{cliente:" + JSON.stringify(datosCliente) + ",'asesor':'" + IdUsuario + "'}",
            dataType: "json",
            success: function (data) {
                polizaCliente = data.d;
            },
            complete: function (data) {
                if (polizaCliente.length > 0) {
                    if (!polizaCliente[0].Resultado.Error) {
                        CargarDatosPoliza(polizaCliente);
                    } else {
                        MostrarMensajeGenerico(polizaCliente[0].Resultado.IdTipoMensaje, polizaCliente[0].Resultado.Mensaje)                     
                    }
                }
                else {
                    ConsultarMensajeDB("8", "RIW002");
                }
                DetenerPrecargaBancaSeguros();
            },
            error: function (data) {
                var r = data.responseText;
                var errorMessage = r.Message;
                MostrarMensajeGenerico(3, errorMessage);
                DetenerPrecargaBancaSeguros();
            }
        });
    }
}

function LlenarEntidadCliente() {
    var Cliente = {};
    Cliente.TipoIdentificacion = {};
    var ListTipoIdentificacion = $.jStorage.get("ListaTipoIdentificacion");

    Cliente.TipoIdentificacion.IdTipoIdentificacion = $("#ddlTipoIdentificacion").val();
    Cliente.Identificacion = $("#txtNoIdentificacion").val();

    return Cliente;
}

function CargarDatosPoliza(polizaCliente) {
    CargarDatosBasicos(polizaCliente);
    CargarGrillaPoliza(polizaCliente);
    DeshabilitarDivYContenido("panelGrillaReporte", false);
}

function CargarDatosBasicos(polizaCliente) {
    $('#txtPrimerNombre').val(polizaCliente[0].DatosVenta.Cliente.PrimerNombre);
    $('#txtSegundoNombre').val(polizaCliente[0].DatosVenta.Cliente.SegundoNombre);
    $('#txtPrimerApellido').val(polizaCliente[0].DatosVenta.Cliente.PrimerApellido);
    $('#txtSegundoApellido').val(polizaCliente[0].DatosVenta.Cliente.SegundoApellido);
}

function CargarGrillaPoliza(polizaCliente) {
    var result = polizaCliente;
    oSettings = oTableReporte.fnSettings();
    oTableReporte.fnClearTable(this);
    var auto;
    var est;
    for (var i = 0; i < result.length; i++) {
        FilaPoliza = {
            IdVenta: result[i].DatosVenta.IdVenta,
            IdSeguro: result[i].Seguro.IdSeguro,
            NumeroPoliza: result[i].DatosVenta.Consecutivo,
            NombrePlan: result[i].Seguro.Plan.Descripcion,
            NombreSeguro: result[i].Seguro.Descripcion,
            Valor: result[i].Seguro.Plan.Valor,
            CuentaCliente: result[i].DatosVenta.ProductoBancario.NumeroCuenta,
            Imprimir: '<input type="image" src="../imagenes/imprimir.jpg" width="25" height="25" title="Imprimir Poliza" id="cvico" onclick="cvicoclick=true"/>'
        }

        oTableReporte.oApi._fnAddData(oSettings, FilaPoliza);
    }

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTableReporte.fnDraw();
}

function LimpiarPagina() {
    $('#txtPrimerNombre').val('');
    $('#txtSegundoNombre').val('');
    $('#txtPrimerApellido').val('');
    $('#txtSegundoApellido').val('');
    $('#txtNoIdentificacion').val('');
    oTableReporte.fnClearTable(this);
    CargarSecciones();
}

function ObtenerDocumentoPoliza(consecutivoPoliza, idseguro) {
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "ReImpresionPoliza.aspx/ConsultarPolizaReimpresion",
        data: "{consecutivoPoliza:" + consecutivoPoliza + "}",
        dataType: "json",
        success: function (data) {
            if (data.d.Resultado.Error) {
                MostrarMensajeGenerico(data.d.Resultado.IdTipoMensaje, data.d.Resultado.Mensaje);
            }
            else {
                $("#toptitle").text('Poliza Regenerada Con Exito');
                $("#iframePDF").attr('src', data.d.RutaArchivo);
                $('#modPdf').modal('show');                
            }
        },
        complete: function (data) {
            DetenerPrecargaBancaSeguros();
        },
        error: function (data) {
            MostrarMensajeGenerico(data.d.Resultado.IdTipoMensaje, data.d.Resultado.Mensaje);
        }
    });
}

function ImprimirPoliza() {
    var PDF = document.getElementById("iframePdf");
    PDF.focus();
    PDF.contentWindow.print();
}

function AccionImprimirPoliza(DatosFilas) {
    IniciarPrecargaBancaSeguros();
    ObtenerDocumentoPoliza(DatosFilas.NumeroPoliza, DatosFilas.IdSeguro);
}