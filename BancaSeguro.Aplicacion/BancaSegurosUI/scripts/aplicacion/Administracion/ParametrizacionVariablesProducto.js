var oTableReporte;
var variableEditclick = false;
var variableDeleteclick = false;

$(document).ready(function () {
    if (initSession())
    {
        IniciarPrecargaBancaSeguros();
        InicializarGrillaVariables();
        CargarComboAseguradoras();
        CargarComboTipos();
        CargarComboMaestras();
        DetenerPrecargaBancaSeguros();
        SeleccionarFilaVariable();
        CargarSecciones(true);
        $('#btnAct').hide();
        $('#selAseguradora').change(function () {
            CargarComboSeguros();
        });
        $('#selSeguro').change(function () {
            CargarVariablesSeguro();
        });

        $('#selTipo').change(function () {
            HabilitarCampos();
        });
        $('#selMaestra').change(function () {
            CargarNombreVariable();
        });
        ValidarControlDual();
    }
    else {
        IniciarPrecargaBancaSeguros();
        MostrarModalConfirmar(3, "Usted no se encuentra logueado o con permisos para acceder a esa pagina", 'sessLogOut()', 'sessLogOut()');
    }
});

function InicializarGrillaVariables() {
    oTableReporte = $('#gvVariablesProducto').dataTable({
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
            { "data": "IdVariableProducto", "visible": false, "searchable": false },
            { "data": "Orden", "class": "ord"},
            { "data": "IdTipo", "visible": false, "searchable": false },
            { "data": "Tipo" },
            { "data": "Nombre"},
            { "data": "Longitud" },
            { "data": "Activo" },
            { "data": "IdMaestra", "visible": false, "searchable": false },
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

function CargarSecciones(estado) {
    DeshabilitarDivYContenido('panelGrillaReporte', estado);
}

function CargarComboAseguradoras()
{
    var datosAseguradora = {};
    datosAseguradora.Activo = true;
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
            if (aseguradoras.length > 0)
            {
                LlenarListaDesplegable(aseguradoras, 'selAseguradora', "IdAseguradora", "Nombre");
            }
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage)
        }
    });
}

function CargarComboSeguros() {
    if ($('#selAseguradora').val() !== "")
    {
        LimpiarCombo('selSeguro');
        var idAseguradora = parseInt($('#selAseguradora').val(), 0);
        IniciarPrecargaBancaSeguros();
        var seguros;
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionVariablesProducto.aspx/ConsultarSegurosPorAseguradora",
            data: "{idAseguradora:" + idAseguradora + "}",
            dataType: "json",
            success: function (data) {
                seguros = data.d;
            },
            complete: function (data) {
                if (seguros.length > 0) {
                    LlenarComboSeguros(seguros);
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
}

function CargarComboTipos()
{
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
            if (ListTipoDato != undefined) {
                $.jStorage.set('TiposDato', ListTipoDato);
                LlenarListaDesplegable(ListTipoDato, 'selTipo', "IdTipoDato", "Nombre");
            }
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage)
        }
    });
}

function CargarComboMaestras()
{
    var datosMaestra = {};
    datosMaestra.Activo = true;
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
                LlenarListaDesplegable(maestras, 'selMaestra', "IdMaestra", "Nombre");
            }
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage);
        }
    });
}

function HabilitarCampos()
{
    if ($("#selTipo :selected").text() === "Catalogo")
    {
        $('#selMaestra').val('');
        $('#selMaestra').prop('disabled', false);
        $('#selMaestra').prop('required', true);
        $('#txtNombreVariable').prop('disabled', true);
    }
    else
    {
        $('#selMaestra').val('');
        $('#selMaestra').prop('disabled', true);
        $('#selMaestra').removeAttr('required');
        $('#txtNombreVariable').val('');
        $('#txtNombreVariable').prop('disabled', false);
    }

    if ($("#selTipo :selected").text() === "Numérico" || $("#selTipo :selected").text() === "Texto" || $("#selTipo :selected").text() === "Alfanumérico")
    {
        $('#txtLongitud').val('');
        $('#txtLongitud').prop('disabled', false);
    }
    else
    {
        $('#txtLongitud').val('0');
        $('#txtLongitud').prop('disabled', true);
        $('#txtLongitud').parsley().destroy();
    }
}

function CargarNombreVariable()
{
    if ($('#selMaestra').val() === '')
    {
        $('#txtNombreVariable').val('');
    }
    else
    {
        $('#txtNombreVariable').val($('#selMaestra :selected').text());
        $('#txtNombreVariable').parsley().destroy();
    }
}

function SeleccionarFilaVariable() {
    var table = $('#gvVariablesProducto').DataTable();
    $('#gvVariablesProducto tbody').on('click', 'tr', function () {
        rowgvReporte = $(this).index();
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }

        var DatosFila = table.fnGetData(this);
        if (variableEditclick) {
            variableEditclick = false;
            CargarDatosVariable(DatosFila);
        }
        else if (variableDeleteclick)
        {
            variableDeleteclick = false;
            $.confirm({
                text: 'Esta seguro de eliminar el registro?',
                confirm: function (button) {
                    EliminarVariable(DatosFila);                
                },
                cancel: function (button) {

                }
            });          
        }
    });
}

function CargarDatosVariable(DatosFila)
{
    $('#hidIdVariableProducto').val(DatosFila.IdVariableProducto);
    $('#hidOrden').val(DatosFila.Orden);
    $('#selTipo').val(DatosFila.IdTipo);
    $('#selTipo').prop('disabled', true);

    $('#txtNombreVariable').val(DatosFila.Nombre);
    if (DatosFila.IdMaestra != null)
    {
        $('#selMaestra').val(DatosFila.IdMaestra);
        $('#selMaestra').prop('required', true);
        $('#txtNombreVariable').prop('disabled', true);
    }
    else
    {
        $('#selMaestra').val('');
        $('#selMaestra').removeAttr('required');
        $('#txtNombreVariable').prop('disabled', false);
    }

    $('#selMaestra').prop('disabled', true);
    
    $('#txtLongitud').val(DatosFila.Longitud);
    $('#txtLongitud').prop('disabled', true);

    if (DatosFila.Activo === "ACTIVO") {
        document.getElementById("chkActivo").checked = true;
    } else {
        document.getElementById("chkActivo").checked = false;
    }
    $('#btnAgr').hide();
    $('#btnAct').show();
    $('#divVars').parsley().destroy();
}

function CargarVariablesSeguro()
{
    LimpiarCampos();
    ConsultarVariables();
}

function LimpiarCampos()
{
    $('#hidIdVariableProducto').val('0');
    $('#selTipo').val('');
    $('#selTipo').prop('disabled', false);

    $('#txtNombreVariable').val('');
    $('#txtNombreVariable').prop('disabled', false);
    
    $('#selMaestra').val('');
    $('#selMaestra').prop('disabled', true);

    $('#txtLongitud').val('');
    $('#txtLongitud').prop('disabled', false);

    document.getElementById("chkActivo").checked = true;
    
    $('#btnAgr').show();
    $('#btnAct').hide();
    $('#divVars').parsley().destroy();
    oTableReporte.fnClearTable(this);
}

function ConsultarVariables()
{
    if ($('#selSeguro').val() !== "") {
        IniciarPrecargaBancaSeguros();
        var datosVariable = {};
        datosVariable.IdSeguro = parseInt($('#selSeguro').val(), 0)
        var variables;
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionVariablesProducto.aspx/ConsultarVariablesProducto",
            data: "{variable:" + JSON.stringify(datosVariable) + "}",
            dataType: "json",
            success: function (data) {
                variables = data.d;
            },
            complete: function (data) {
                if (variables.length > 0) {
                    CargarSecciones(false);
                    CargarGrillaVariables(variables);
                }
                else {
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
}

function CargarGrillaVariables(variables)
{
    var result = variables;
    oSettings = oTableReporte.fnSettings();
    oTableReporte.fnClearTable(this);
    var ListTipoDato = $.jStorage.get("TiposDato");
    var activo;
    var tipo;

    for (var i = 0; i < result.length; i++) {

        for (var j = 0; j < ListTipoDato.length; j++) {
            if (ListTipoDato[j]["IdTipoDato"] === result[i].IdTipoDato)
                tipo = ListTipoDato[j]["Nombre"];
        }

        if (result[i].Estado) {
            activo = 'ACTIVO';
        }
        else {
            activo = 'INACTIVO';
        }


        FilaVariable = {
            IdVariableProducto: result[i].IdVariableProducto,
            Orden: result[i].Orden,
            IdTipo: result[i].IdTipoDato,
            Tipo: tipo,
            Nombre: result[i].NombreCampo,
            Longitud: result[i].Longitud,
            Activo: activo,
            IdMaestra: result[i].IdMaestra,
            Acciones: '<input type="image" src="../imagenes/edit.jpg" width="25" height="25" title="Editar"  onclick="variableEditclick=true"/>' +
                      '<input type="image" src="../imagenes/delete.png" width="25" height="25" title="Eliminar"  onclick="variableDeleteclick=true"/>'
        }

        oTableReporte.oApi._fnAddData(oSettings, FilaVariable);
    }

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTableReporte.fnDraw();
}

function InsertarVariable()
{
    ValidaDiv('divVars');
    var Resultado = $('#divVars').parsley().validate();
    if (Resultado) 
    {
        IniciarPrecargaBancaSeguros();
        var datosVariable = {};
        datosVariable = LlenarEntidadVariable();
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
            var resultado;
            $.ajax({
                type: "POST",
                cache: false,
                async: true,
                contentType: "application/json; charset=utf-8",
                url: "ParametrizacionVariablesProducto.aspx/InsertarVariableProducto",
                data: "{variable:" + JSON.stringify(datosVariable) + "}",
                dataType: "json",
                success: function (data) {
                    resultado = data.d;
                },
                complete: function (data) {
                    if (!resultado.Error) {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                        ConsultarVariables();
                        LimpiarCampos();
                        DetenerPrecargaBancaSeguros();
                    }
                    else {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje)
                        DetenerPrecargaBancaSeguros();
                    }
                },
                error: function (data) {
                    var errorMessage = data.responseText;
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje)
                    DetenerPrecargaBancaSeguros();
                }
            });
        }
        else
        {
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Insertar', 'VariableProducto', JSON.stringify(datosVariable), '');
        }
    }
}

function LlenarEntidadVariable() {
    var variable = {};
    variable.IdVariableProducto = parseInt($('#hidIdVariableProducto').val(), 0);
    variable.IdSeguro = parseInt($('#selSeguro').val(), 0);
    variable.NombreCampo = $('#txtNombreVariable').val();
    variable.IdTipoDato = parseInt($('#selTipo').val(), 0);
    variable.Longitud = $('#txtLongitud').val();
    if ($("#selTipo :selected").text() === "Catalogo")
    {
        variable.IdMaestra = parseInt($('#selMaestra').val(), 0);
    }
    else
    {
        variable.IdMaestra = null;
    }
    if (variable.IdVariableProducto === 0)
    {
        variable.Orden = CalcularOrden();
    }
    else
    {
        variable.Orden = parseInt($('#hidOrden').val(), 0);
    }

    if (document.getElementById("chkActivo").checked)
    {
        variable.Estado = true;
    }
    else
    {
        variable.Estado = false;
    }

    return variable;
}

function ActualizarVariable()
{
    ValidaDiv('divVars');
    var Resultado = $('#divVars').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        var datosVariable = {};
        datosVariable = LlenarEntidadVariable();
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
            var resultado;
            $.ajax({
                type: "POST",
                cache: false,
                async: true,
                contentType: "application/json; charset=utf-8",
                url: "ParametrizacionVariablesProducto.aspx/ActualizarVariableProducto",
                data: "{variable:" + JSON.stringify(datosVariable) + "}",
                dataType: "json",
                success: function (data) {
                    resultado = data.d;
                },
                complete: function (data) {
                    if (!resultado.Error) {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                        ConsultarVariables();
                        LimpiarCampos();
                        DetenerPrecargaBancaSeguros();
                    }
                    else {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje)
                        DetenerPrecargaBancaSeguros();
                    }
                },
                error: function (data) {
                    var errorMessage = data.responseText;
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje)
                    DetenerPrecargaBancaSeguros();
                }
            });
        }
        else {
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Actualizar', 'VariableProducto', JSON.stringify(datosVariable), '');
        }
    }
}

function EliminarVariable(datos)
{
    IniciarPrecargaBancaSeguros();
    var datosVariable = {};
    datosVariable = LlenarVariable(datos);

    var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
    if (!registroAutorizaDual.requiereAutorizacion) {
        var resultado;
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "ParametrizacionVariablesProducto.aspx/EliminarVariableProducto",
            data: "{variable:" + JSON.stringify(datosVariable) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (!resultado.Error) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                    ConsultarVariables();
                    DetenerPrecargaBancaSeguros();
                }
                else {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje)
                    DetenerPrecargaBancaSeguros();
                }
            },
            error: function (data) {
                var errorMessage = data.responseText;
                MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje)
                DetenerPrecargaBancaSeguros();
            }
        });
    }
    else
    {
        AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Eliminar', 'VariableProducto', JSON.stringify(datosVariable), '');
    }
}

function LimpiarCombo(nombreCombo)
{
    var selectorCombo = '#' + nombreCombo;
    var combo = $(selectorCombo);
    if (combo != undefined)
    {
        combo.children('option:not(:first)').remove();
    } 
}

function CalcularOrden()
{
    var nuevoOrden = 0;
    var orden;
    $("#gvVariablesProducto .ord").each(function () {
        orden = parseInt($(this).html(), 0);
        if (orden >= nuevoOrden)
        {
            nuevoOrden = orden;
        }
    });

    nuevoOrden = nuevoOrden + 1;

    return nuevoOrden;
}

function LlenarComboSeguros(data) {
    for (var i = 0; i < data.length; i++) {
        $('#selSeguro').append($('<option>', { value: data[i]["IdSeguro"], text: data[i]["Codigo"] + ' - ' + data[i]["Nombre"]  }));
    }
}

function LlenarVariable(data)
{
    var variable = {};
    variable.IdVariableProducto = data.IdVariableProducto;
    variable.IdSeguro = data.IdSeguro;
    variable.NombreCampo = data.Nombre;
    variable.IdTipoDato = data.IdTipo;
    variable.Longitud = data.Longitud;
    variable.Orden = data.Orden;
    variable.IdMaestra = data.IdMaestra;
    if (data.Activo === "ACTIVO")
    {
        variable.Activo = true;
    }
    else
    {
        variable.Activo = false;
    }

    return variable;
}





