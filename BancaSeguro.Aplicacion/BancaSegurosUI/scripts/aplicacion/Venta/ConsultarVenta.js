var cvicoclick = false;
var rowgvReporte;
var oTableReporte;

$(document).ready(function () {
    if (initSession()) {
        IniciarPrecargaBancaSeguros();
        InicializarGrilla();
        CargarSecciones(true);
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
            BuscarDetallePoliza(DatosFila);
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
            { "data": "Estado" },
            { "data": "NumeroPoliza" },
            { "data": "FechaCreacion" },
            { "data": "FechaCancelacion" },
            { "data": "DescripcionNovedad" },
            { "data": "Seguro" },
            { "data": "NombreSeguro" },
            { "data": "Plan" },
            { "data": "NombrePlan" },
            { "data": "Periodicidad" },
            { "data": "Valor" },
            { "data": "CuentaCliente" },
            { "data": "FechaUltimoCobro" },
            { "data": "Detalles" }
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
    if (estado) {
        DeshabilitarDivYContenido('panelInformacionBasica', estado);
        DeshabilitarDivYContenido('panelModalCliente', estado);
        DeshabilitarDivYContenido('panelModalCuenta', estado);
        DeshabilitarDivYContenido('panelGrillaReporte', estado);
    } else {
        DeshabilitarDivYContenido('panelGrillaReporte', estado);
    }
}

function CargarComboTipoIdenti() {
    var ListTipoIdentificacion = $.jStorage.get("ListaTipoIdentificacion");
    if (ListTipoIdentificacion != undefined) {
        LlenarListaDesplegable(ListTipoIdentificacion, 'ddlTipoIdentificacion', "IdTipoIdentificacion", "Nombre");
    }
}

function BuscarPolizaCliente() {
    ValidaDiv('panelConsultar');
    var Resultado = $('#panelConsultar').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        var datosCliente = {};
        datosCliente = LlenarEntidadCliente();
        var polizaCliente;
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ConsultarVenta.aspx/ConsultarVentaPorCliente",
            data: "{cliente:" + JSON.stringify(datosCliente) + "}",
            dataType: "json",
            success: function (data) {
                polizaCliente = data.d;
            },
            complete: function (data) {
                if (polizaCliente.length > 0) {
                    if (polizaCliente[0].Resultado.Mensaje === "") {
                        if (!polizaCliente[0].Resultado.Error) {
                            CargarDatosPoliza(polizaCliente);
                            CargarSecciones(false);
                        }
                        else {
                            MostrarMensajeGenerico(polizaCliente[0].Resultado.IdTipoMensaje, polizaCliente[0].Resultado.Mensaje)
                        }
                        
                    } else {
                        MostrarMensajeGenerico(polizaCliente[0].Resultado.IdTipoMensaje, polizaCliente[0].Resultado.Mensaje)
                    }
                }
                else {
                    //MostrarMensajeGenerico(2, 'El cliente no posee polizas registradas en el sistema')
                    MostrarMensajeGenerico(polizaCliente[0].Resultado.IdTipoMensaje, polizaCliente[0].Resultado.Mensaje);
                }
                DetenerPrecargaBancaSeguros();
            },
            error: function (data) {
                polizaCliente = data.d;
                MostrarMensajeGenerico(polizaCliente[0].Resultado.IdTipoMensaje, polizaCliente[0].Resultado.Mensaje)
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
    for (var i = 0; i < result.length; i++) {
        if (ConvertJsonToDate(new Date(parseInt(result[i].FechaCreacion.substr(6), 0))) === "01/01/1") {
            result[i].FechaCreacion = '';
        } else {
            result[i].FechaCreacion = ConvertJsonToDate(new Date(parseInt(result[i].FechaCreacion.substr(6), 0)));
        }

        if (ConvertJsonToDate(new Date(parseInt(result[i].DetalleCancelacionPoliza.FechaCancelacion.substr(6), 0))) === "01/01/1") {
            result[i].DetalleCancelacionPoliza.FechaCancelacion = '';
        } else {
            result[i].DetalleCancelacionPoliza.FechaCancelacion = ConvertJsonToDate(new Date(parseInt(result[i].DetalleCancelacionPoliza.FechaCancelacion.substr(6), 0)));
        }

        if (ConvertJsonToDate(new Date(parseInt(result[i].FechaCobroExitoso.substr(6), 0))) === "01/01/1") {
            result[i].FechaCobroExitoso = '';
        } else {
            result[i].FechaCobroExitoso = ConvertJsonToDate(new Date(parseInt(result[i].FechaCobroExitoso.substr(6), 0)));
        }

        FilaPoliza = {
            IdVenta: result[i].DatosVenta.IdVenta,
            Estado: result[i].Seguro.EstadoPoliza.DescripcionEstadoPoliza,
            NumeroPoliza: result[i].DatosVenta.Consecutivo,
            FechaCreacion: result[i].FechaCreacion,
            FechaCancelacion: result[i].DetalleCancelacionPoliza.FechaCancelacion,
            DescripcionNovedad: result[i].DetalleCancelacionPoliza.CausalRechazo.NombreCausalRechazo,
            Seguro: result[i].Seguro.Nombre,
            NombreSeguro: result[i].Seguro.Descripcion,
            Plan: result[i].Seguro.Plan.NombrePlan,
            NombrePlan: result[i].Seguro.Plan.Descripcion,
            Periodicidad: result[i].Seguro.Plan.Periodicidad.Nombre,
            Valor: result[i].Seguro.Plan.Valor,
            CuentaCliente: result[i].DatosVenta.ProductoBancario.NumeroCuenta,
            FechaUltimoCobro: result[i].FechaCobroExitoso,
            Detalles: '<input type="image" src="../imagenes/info.gif" width="25" height="25" title="Consultar Información Detallada" id="cvico" onclick="cvicoclick=true"/>'
        }

        oTableReporte.oApi._fnAddData(oSettings, FilaPoliza);
    }

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTableReporte.fnDraw();
}

function BuscarDetallePoliza(DatosFilas) {

    IniciarPrecargaBancaSeguros();
    var polizaCliente = {};
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "ConsultarVenta.aspx/ConsultarDetallePolizaPorIdVenta",
        data: "{identificacionVenta:" + DatosFilas.IdVenta + "}",
        dataType: "json",
        success: function (data) {
            polizaCliente = data.d;
        },
        complete: function (data) {
            if (polizaCliente != undefined) {
                LlenarDetallesPoliza(polizaCliente);
            }
            else {
                MostrarMensajeGenerico(2, 'El cliente no posee polizas registradas en el sistema')
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

function LlenarDetallesPoliza(polizaCliente) {
    var fecha = new Date(parseInt(polizaCliente.DatosVenta.Cliente.FechaNacimiento.substr(6), 0));
    $('#txtFechaNacimiento').val(ConvertJsonToDate(fecha));
    $('#txtCiudadNacimiento').val(polizaCliente.DatosVenta.Cliente.CiudadNacimiento);
    $('#txtNacionalidad').val(polizaCliente.DatosVenta.Cliente.Nacionalidad);
    $('#txtGenero').val(polizaCliente.DatosVenta.Cliente.Genero);
    $('#txtDireccion').val(polizaCliente.DatosVenta.Cliente.Direccion);
    $('#txtCiudadResidencia').val(polizaCliente.DatosVenta.Cliente.CiudadResidencia);
    if (polizaCliente.DatosVenta.Cliente.Telefono != null && polizaCliente.DatosVenta.Cliente.Telefono != "") {
        $('#txtTelefono').val(polizaCliente.DatosVenta.Cliente.Telefono);
    }
    else {
        $('#txtTelefono').val(polizaCliente.DatosVenta.Cliente.Celular);
    }
    $('#txtCorreoElectronico').val(polizaCliente.DatosVenta.Cliente.Correo);
    $('#txtCodigoProducto').val(polizaCliente.DatosVenta.ProductoBancario.CodigoProducto);
    $('#txtNombreProducto').val(polizaCliente.DatosVenta.ProductoBancario.NombreProducto);
    $('#txtNumeroCuenta').val(polizaCliente.DatosVenta.ProductoBancario.NumeroCuenta);

    var div = document.getElementById('detPol');
    div.innerHTML = polizaCliente.DatosVenta.Consecutivo;

    $('#modalDetallePoliza').modal('show');
}

function LimpiarPagina() {
    $('#txtPrimerNombre').val('');
    $('#txtSegundoNombre').val('');
    $('#txtPrimerApellido').val('');
    $('#txtSegundoApellido').val('');
    $('#txtNoIdentificacion').val('');
    oTableReporte.fnClearTable(this);
    LimpiarInformacionDetalladaPoliza();
    CargarSecciones(true);
}

function LimpiarInformacionDetalladaPoliza() {
    $('#txtFechaNacimiento').val('');
    $('#txtCiudadNacimiento').val('');
    $('#txtNacionalidad').val('');
    $('#txtGenero').val('');
    $('#txtDireccion').val('');
    $('#txtGenero').val('');
    $('#txtCiudadResidencia').val('');
    $('#txtTelefono').val('');
    $('#txtCorreoElectronico').val('');
    $('#txtCodigoProducto').val('');
    $('#txtNombreProducto').val('');
    $('#txtNumeroCuenta').val('');
}