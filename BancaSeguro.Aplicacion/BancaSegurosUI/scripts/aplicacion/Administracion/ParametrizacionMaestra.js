var oTableReporte;
var oTableReporteItems;
var maestraEditclick = false;
var maestraDeleteclick = false;
var itemEditclick = false;
var itemDeleteclick = false;
var indexItem

$(document).ready(function () {
    if (initSession()) {
        
        IniciarPrecargaBancaSeguros();
        InicializarGrillaMaestras();
        InicializarGrillaItems();
        CargarSecciones(true);
        DetenerPrecargaBancaSeguros();
        SelecionarFilaMaestra();
        SelecionarFilaItems();
        ValidarControlDual();
    }
    else {
        IniciarPrecargaBancaSeguros();
        MostrarModalConfirmar(3, "Usted no se encuentra logueado o con permisos para acceder a esa pagina", 'sessLogOut()', 'sessLogOut()');
    }
});

function InicializarGrillaMaestras() {
    oTableReporte = $('#gvMaestra').dataTable({
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
            { "data": "IdMaestra", "visible": false, "searchable": false },
            { "data": "Nombre" },
            { "data": "Activo" },
            { "data": "Acciones" }
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

function InicializarGrillaItems() {
    oTableReporteItems = $('#gvItemsMaestra').dataTable({
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
            { "data": "Indice", "visible": false, "searchable": false },
            { "data": "IdMaestra", "visible": false, "searchable": false },
            { "data": "Codigo", "class": "cod"},
            { "data": "Valor" },
            { "data": "Activo" },
            { "data": "Acciones" },
            { "data": "Temporal", "visible": false, "searchable": false }
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

function SelecionarFilaMaestra() {
    var table = $('#gvMaestra').DataTable();
    $('#gvMaestra tbody').on('click', 'tr', function () {
        rowgvReporte = $(this).index();
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }

        var DatosFila = table.fnGetData(this);
        if (maestraEditclick) {
            maestraEditclick = false;
            CargarDatosMaestra(DatosFila);
        }
        else if (maestraDeleteclick)
        {
            maestraDeleteclick = false;
            $.confirm({
                text: 'Esta seguro de eliminar el registro?',
                confirm: function (button) {
                    EliminarMaestra(DatosFila);
                },
                cancel: function (button) {

                }
            });
        }
    });
}

function SelecionarFilaItems() {
    var table = $('#gvItemsMaestra').DataTable();
    $('#gvItemsMaestra tbody').on('click', 'tr', function () {
        rowgvReporte = $(this).index();
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }

        var DatosFila = table.fnGetData(this);
        indexItem = DatosFila.Indice;

        if (itemEditclick) {
            itemEditclick = false;
            CargarDatosItem(DatosFila);
        }
        else if (itemDeleteclick) {
            var indice = $(this).index();
            itemDeleteclick = false;
            $.confirm({
                text: 'Esta seguro de eliminar el registro?',
                confirm: function (button) {
                    if (DatosFila.Temporal) {
                        EliminarItemTemporal(indice);
                    }
                    else {
                        EliminarItem(DatosFila);
                    }
                },
                cancel: function (button) {
                   
                }
            });
        }
    });
}

function CargarDatosMaestra(DatosFila)
{
    $('#txtIdMaestra').val(DatosFila.IdMaestra);
    $('#txtNombreMaestra').val(DatosFila.Nombre);
    $('#txtNombreMaestra').prop('disabled', true);
    if (DatosFila.Activo === "ACTIVO") {
        document.getElementById("chkActivo").checked = true;
    } else {
        document.getElementById("chkActivo").checked = false;
    }
    $('#btnAgr').hide();
    $('#btnAct').show();
    $('#btnActItem').hide();
    $('#btnAgrItem').show();
    $('#divMaestra').parsley().destroy();
    LimpiarCamposItem();
    oTableReporteItems.fnClearTable(this);
    CargarItemsMaestra(DatosFila.IdMaestra);

    $('#modalInfoMaestra').modal('show');
}

function CargarDatosItem(DatosFila) {
    $('#txtCodigo').val(DatosFila.Codigo);
    $('#txtValor').val(DatosFila.Valor);
    if (DatosFila.Temporal)
    {
        $('#txtCodigo').prop('disabled', false);
        $('#txtValor').prop('disabled', false);
    }
    else
    {
        $('#txtCodigo').prop('disabled', true);
    }
    
    if (DatosFila.Activo === "ACTIVO") {
        document.getElementById("chkActivoItem").checked = true;
    } else {
        document.getElementById("chkActivoItem").checked = false;
    }
    $('#txtIndice').val(DatosFila.Indice);
    $('#txtTemporal').val(DatosFila.Temporal);
    $('#btnAgrItem').hide();
    $('#btnActItem').show();
}

function LimpiarCamposItem() {
    $('#txtCodigo').val('');
    $('#txtCodigo').prop('disabled', false);
    $('#txtValor').val('');
    $('#txtValor').prop('disabled', false);
    $('#txtIndice').val('');

    document.getElementById("chkActivoItem").checked = true;

    $('#btnAgrItem').show();
    $('#btnActItem').hide();
    $('#divItems').parsley().destroy();

}

function AdicionarItem()
{
    ValidaDiv('divItems');
    var resultado = $('#divItems').parsley().validate();
    if (resultado)
    {
        resultado = ValidaCodigoItem();
        if (resultado)
        {
            var idMaestra = $('#txtIdMaestra').val();
            if (idMaestra === '0') {
                oSettings = oTableReporteItems.fnSettings();
                oTableReporteItems.oApi._fnAddData(oSettings, LeerDatosItem());
                oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
                oTableReporteItems.fnDraw();
            }
            else
            {
                InsertarItem();
            }

            LimpiarCamposItem();
        }
    }
}

function ValidaCodigoItem()
{
    var cod;
    var codigo = $('#txtCodigo').val();
    var valido = true;
    var Indice = $('#txtIndice').val()
    $("#gvItemsMaestra .cod").each(function () {
        cod = $(this).html();
        if (valido) {
            if (cod === codigo && Indice === "") {
                MostrarMensajeGenerico(2, 'Ya existe un Item con el mismo código');
                valido = false;
            }
        }
    });

    return valido;
}

function LeerDatosItem() {
    var table = $('#gvItemsMaestra').DataTable()
    var Indice = $('#txtIndice').val();
    if (Indice === "")
        Indice = table.fnGetData().length === 0 ? 0 : table.fnGetData().length;
    var activo;
    if (document.getElementById("chkActivoItem").checked)
    {
        activo = "ACTIVO";
    }
    else
    {
        activo = "FALSE";
    }

    var dataItem = {
          "Indice": parseInt(Indice, 0)
        , "IdMaestra": parseInt($('#txtIdMaestra').val(), 0)
        , "Codigo": $('#txtCodigo').val()
        , "Valor": $('#txtValor').val()
        , "Activo": activo
        , "Acciones": '<img type="image" src="../Imagenes/edit.jpg" width="25" height="25" title="Editar" onclick="itemEditclick=true"/>' +
                      '<img type="image" src="../Imagenes/delete.png" width="25" height="25" title="Eliminar" onclick="itemDeleteclick=true"/>'
        ,Temporal: true

    }

    return dataItem;
}

function ConsultarMaestras()
{
    IniciarPrecargaBancaSeguros();
    var datosMaestra = {};
    datosMaestra = LlenarEntidadMaestraBusqueda();
    var maestras;
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionMaestras.aspx/ConsultarMaestras",
        data: "{maestra:" + JSON.stringify(datosMaestra) + "}",
        dataType: "json",
        success: function (data) {
            maestras = data.d;
        },
        complete: function (data) {
            if (maestras.length > 0) {
                CargarSecciones(false);
                CargarGrillaMaestras(maestras);
            }
            else {
                MostrarMensajeGenerico(2, 'No existen maestras registradas en el sistema con el filtro seleccionado.')
                oTableReporte.fnClearTable(this);
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

function LlenarEntidadMaestraBusqueda()
{
    var maestra = {};
    maestra.IdMaestra = 0;
    maestra.Nombre = $('#txtNombreMaestraConsulta').val();
    maestra.Activo = null;
    return maestra;
}

function LlenarEntidadMaestra() {
    var maestra = {};
    maestra.IdMaestra = $('#txtIdMaestra').val();
    maestra.Nombre = $('#txtNombreMaestra').val();
    maestra.Activo = document.getElementById("chkActivo").checked;
    maestra.Items = LLenarItemsMaestra();

    return maestra;
}

function LLenarItemsMaestra()
{
    ArrayItems = [];
    var oTable = $('#gvItemsMaestra').dataTable();
    for (var i = 0; i < oTable.fnGetNodes().length; i++) {
        var DatosFilas = oTable.fnGetData(i);
        var ItemMaestra = {};
        ItemMaestra.IdMaestra = DatosFilas.IdMaestra;
        ItemMaestra.Codigo = DatosFilas.Codigo;
        ItemMaestra.Valor = DatosFilas.Valor;
        if (DatosFilas.Activo === "ACTIVO") {
            ItemMaestra.Activo = true;
        }
        else
        {
            ItemMaestra.Activo = false;
        }
        ArrayItems.push(ItemMaestra);
    }

    return ArrayItems;
}

function CargarGrillaMaestras(maestras)
{
    var result = maestras;
    oSettings = oTableReporte.fnSettings();
    oTableReporte.fnClearTable(this);
    var activo;

    for (var i = 0; i < result.length; i++) {

        if (result[i].Activo) {
            activo = 'ACTIVO';
        }
        else {
            activo = 'INACTIVO';
        }

        FilaMaestra = {
            IdMaestra: result[i].IdMaestra,
            Nombre: result[i].Nombre,
            Activo: activo,
            Acciones: '<input type="image" src="../imagenes/edit.jpg" width="25" height="25" title="Editar"  onclick="maestraEditclick=true"/>' +
                      '<input type="image" src="../imagenes/delete.png" width="25" height="25" title="Eliminar"  onclick="maestraDeleteclick=true"/>'
        }

        oTableReporte.oApi._fnAddData(oSettings, FilaMaestra);
    }

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTableReporte.fnDraw();
}

function CargarNuevoFormulario() {
    $('#txtIdMaestra').val('0');
    $('#txtNombreMaestra').val('');
    $('#txtNombreMaestra').prop('disabled', false);
    document.getElementById("chkActivo").checked = true;
    $('#btnAgr').show();
    $('#btnAct').hide();
    $('#divMaestra').parsley().destroy();
    LimpiarCamposItem();
    oTableReporteItems.fnClearTable(this);
    $('#modalInfoMaestra').modal('show');
}

function Cancelar() {
    $('#modalInfoMaestra').modal('hide');
}

function GuardarMaestra()
{
    ValidaDiv('divMaestra');
    var Resultado = $('#divMaestra').parsley().validate();
    if (Resultado) {
        Resultado = ValidarItems(false);
        if (Resultado) {
            IniciarPrecargaBancaSeguros();
            var datosMaestra = {};
            datosMaestra = LlenarEntidadMaestra();
            var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
            if (!registroAutorizaDual.requiereAutorizacion) {
                var resultado;
                $.ajax({
                    type: "POST",
                    cache: false,
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    url: "ParametrizacionMaestras.aspx/InsertarMaestra",
                    data: "{maestra:" + JSON.stringify(datosMaestra) + "}",
                    dataType: "json",
                    success: function (data) {
                        resultado = data.d;
                    },
                    complete: function (data) {
                        if (!resultado.Error) {
                            MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                            $('#modalInfoMaestra').modal('hide');
                            DetenerPrecargaBancaSeguros();
                            ConsultarMaestra(datosMaestra);
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
                AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Insertar', 'Maestra', JSON.stringify(datosMaestra), '#modalInfoMaestra');
            }
        }
    }
}

function ValidarItems(eliminacion)
{
    var valido = true;
    var oTable = $('#gvItemsMaestra').dataTable();
    var itemsGrilla;
    if (eliminacion)
    {
        itemsGrilla = oTable.fnGetNodes().length - 1;
    }
    else
    {
        itemsGrilla = oTable.fnGetNodes().length;
    }
    if (itemsGrilla < 2)
    {
        MostrarMensajeGenerico(2, 'La maestra debe tener al menos 2 items');
        valido = false;
    }

    return valido;
}

function ConsultarMaestra(datosMaestra) {
    IniciarPrecargaBancaSeguros();
    var maestras;
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionMaestras.aspx/ConsultarMaestras",
        data: "{maestra:" + JSON.stringify(datosMaestra) + "}",
        dataType: "json",
        success: function (data) {
            maestras = data.d;
        },
        complete: function (data) {
            if (maestras.length > 0)
            {
                CargarSecciones(false);
                CargarGrillaMaestras(maestras);
            }
            else
            {
                oTableReporte.fnClearTable(this);
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

function ActualizarMaestra()
{
    ValidaDiv('divMaestra');
    var Resultado = $('#divMaestra').parsley().validate();
    if (Resultado) {
        Resultado = ValidarItems(false);
        if (Resultado) {
            IniciarPrecargaBancaSeguros();
            var datosMaestra = {};
            datosMaestra = LlenarEntidadMaestra();
            var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
            if (!registroAutorizaDual.requiereAutorizacion) {
                var resultado;
                $.ajax({
                    type: "POST",
                    cache: false,
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    url: "ParametrizacionMaestras.aspx/ActualizarMaestra",
                    data: "{maestra:" + JSON.stringify(datosMaestra) + "}",
                    dataType: "json",
                    success: function (data) {
                        resultado = data.d;
                    },
                    complete: function (data) {
                        if (!resultado.Error) {
                            MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                            $('#modalInfoMaestra').modal('hide');
                            DetenerPrecargaBancaSeguros();
                            ConsultarMaestra(datosMaestra);
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
                AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Actualizar', 'Maestra', JSON.stringify(datosMaestra), '#modalInfoMaestra');
            }
        }
    }
}

function EliminarMaestra(datosMaestra)
{
    IniciarPrecargaBancaSeguros();
    var maestra = {};
    maestra.IdMaestra = datosMaestra.IdMaestra;
    maestra.Nombre = datosMaestra.Nombre;
    if (datosMaestra.Activo === "ACTIVO")
    {
        maestra.Activo = true;
    }
    else
    {
        maestra.Activo = false;
    }

    var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
    if (!registroAutorizaDual.requiereAutorizacion) {
        var resultado;
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionMaestras.aspx/EliminarMaestra",
            data: "{maestra:" + JSON.stringify(maestra) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (!resultado.Error) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                    DetenerPrecargaBancaSeguros();
                    ConsultarMaestra(maestra);
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
        AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Eliminar', 'Maestra', JSON.stringify(maestra), '#modalInfoMaestra');
    }
}

function CargarItemsMaestra(IdMaestra)
{
    IniciarPrecargaBancaSeguros();
    var datosItem = {};
    datosItem.IdMaestra = IdMaestra;
    var ItemsMaestra;
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "ParametrizacionMaestras.aspx/ConsultarItemsMaestra",
        data: "{itemMaestra:" + JSON.stringify(datosItem) + "}",
        dataType: "json",
        success: function (data) {
            ItemsMaestra = data.d;
        },
        complete: function (data) {
            if (ItemsMaestra.length > 0) {
                CargarGrillaItemsMaestra(ItemsMaestra);
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

function CargarGrillaItemsMaestra(ItemsMaestra) {
    var result = ItemsMaestra;
    oSettings = oTableReporteItems.fnSettings();
    oTableReporteItems.fnClearTable(this);
    var activo;

    for (var i = 0; i < result.length; i++) {

        if (result[i].Activo) {
            activo = 'ACTIVO';
        }
        else {
            activo = 'INACTIVO';
        }

        FilaItemMaestra = {
            Indice: i,
            IdMaestra: result[i].IdMaestra,
            Codigo: result[i].Codigo,
            Valor: result[i].Valor,
            Activo: activo,
            Acciones: '<input type="image" src="../imagenes/edit.jpg" width="25" height="25" title="Editar"  onclick="itemEditclick=true"/>' +
                      '<input type="image" src="../imagenes/delete.png" width="25" height="25" title="Eliminar"  onclick="itemDeleteclick=true"/>',
            Temporal:false
        }

        oTableReporteItems.oApi._fnAddData(oSettings, FilaItemMaestra);
    }

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTableReporteItems.fnDraw();
}

function InsertarItem()
{
    IniciarPrecargaBancaSeguros();
    var datosItem = LlenaEntidadItemMaestra();
    var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
    if (!registroAutorizaDual.requiereAutorizacion) {
        var resultado;
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionMaestras.aspx/InsertarItemMaestra",
            data: "{itemMaestra:" + JSON.stringify(datosItem) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (!resultado.Error) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                    DetenerPrecargaBancaSeguros();
                    CargarItemsMaestra(datosItem.IdMaestra);
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
        AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Insertar', 'ItemMaestra', JSON.stringify(datosItem), '');
    }
}

function LlenaEntidadItemMaestra()
{
    var itemMaestra = {};

    itemMaestra.IdMaestra = parseInt($('#txtIdMaestra').val(), 0);
    itemMaestra.Codigo = $('#txtCodigo').val();
    itemMaestra.Valor = $('#txtValor').val();
    itemMaestra.Activo = document.getElementById("chkActivoItem").checked;

    return itemMaestra;
}

function ActualizarItem()
{
    if ($('#txtTemporal').val() === "true")
    {
        ActualizarItemTemporal();
    }
    else
    {
        IniciarPrecargaBancaSeguros();
        var datosItem = LlenaEntidadItemMaestra();
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
            var resultado;
            $.ajax({
                type: "POST",
                cache: false,
                async: true,
                contentType: "application/json; charset=utf-8",
                url: "ParametrizacionMaestras.aspx/ActualizarItemMaestra",
                data: "{itemMaestra:" + JSON.stringify(datosItem) + "}",
                dataType: "json",
                success: function (data) {
                    resultado = data.d;
                },
                complete: function (data) {
                    if (!resultado.Error) {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                        DetenerPrecargaBancaSeguros();
                        CargarItemsMaestra(datosItem.IdMaestra);
                        LimpiarCamposItem();
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
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Actualizar', 'ItemMaestra', JSON.stringify(datosItem), '');
        }
    }
}

function ActualizarItemTemporal()
{
    var oTable = $('#gvItemsMaestra').dataTable();
    oTable.fnUpdate(LeerDatosItem(), indexItem);
    LimpiarCamposItem();
}

function EliminarItem(DatosFila)
{
    Resultado = ValidarItems(true);
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        var datosItem = {};
        datosItem.IdMaestra = DatosFila.IdMaestra;
        datosItem.Codigo = DatosFila.Codigo;
        datosItem.Valor = DatosFila.Valor;
        if (DatosFila.Activo === "ACTIVO") {
            datosItem.Activo = true;
        }
        else {
            datosItem.Activo = false;
        }
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
            var resultado;
            $.ajax({
                type: "POST",
                cache: false,
                async: true,
                contentType: "application/json; charset=utf-8",
                url: "ParametrizacionMaestras.aspx/EliminarItemMaestra",
                data: "{itemMaestra:" + JSON.stringify(datosItem) + "}",
                dataType: "json",
                success: function (data) {
                    resultado = data.d;
                },
                complete: function (data) {
                    if (!resultado.Error) {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                        DetenerPrecargaBancaSeguros();
                        CargarItemsMaestra(datosItem.IdMaestra);
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
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Eliminar', 'ItemMaestra', JSON.stringify(datosItem), '');
        }
    }
}

function EliminarItemTemporal(index)
{
    var oTable = $('#gvItemsMaestra').dataTable();
    oTable.fnDeleteRow(index);
}



