var oTableReporte;
var cvicoclick = false;
var rowgvReporte;

$(document).ready(function () {
    ConsultarElementosCombo();
    InicializarGrilla();
    $('input[name=btnAgr]').hide();
    $('input[name=btnCan]').hide();
    $('input[name=btnAct]').hide();
});

function InicializarGrilla() {
    oTableReporte = $('#gvControlDual').dataTable({
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
            { "data": "IdRol", "visible": false, "searchable": false },
            { "data": "Nombre" },
            { "data": "Requiere"},
            { "data": "Autoriza"}
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

function ConsultarElementosCombo() {
    var DataCatalogo;
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "AdministracionControlDual.aspx/ConsultarMenuControlDual",
        dataType: "json",
        success: function (data) {
            DataCatalogo = data.d;
        },
        complete: function (data) {
            if (DataCatalogo != null) {
                if (DataCatalogo.length > 0) {
                    CargarCombo(DataCatalogo, 'ddlFunciones');
                }
                DetenerPrecargaBancaSeguros();
              }
            },
            error: function (data) {
                var errorMessage = data.responseText;
                MostrarMensajeGenerico(3, errorMessage);
                DetenerPrecargaBancaSeguros();
            }
    });

    return DataCatalogo;
}

function CargarCombo(data, dropDownList) {
    $('#' + dropDownList).append($('<option>', { value: "", text: '-- Seleccione una opción --' }));
    for (var i = 0; i < data.length; i++) {
        switch (dropDownList) {
            case 'ddlFunciones':
                $('#' + dropDownList).append($('<option>', { value: data[i]["IdMenu"], text: data[i]["Nombre"] }));
                break;
        }
    }
    var optionA = $('#' + dropDownList).val();

}

function ConsultarAdmonControlDual() {
    var Roles;
    var idMenu = $('#ddlFunciones').val();
    if (idMenu === "") {
        Cancelar();
    }
    else {
        $.ajax({
            type: "POST",
            cache: false,
            async: false,
            contentType: "application/json; charset=utf-8",
            url: "AdministracionControlDual.aspx/ConsultarAdmonControlDualIdMenu",
            data: "{idMenu:" + JSON.stringify(idMenu) + "}",
            dataType: "json",
            success: function (data) {
                Roles = data.d;
            },
            complete: function (data) {
                CargarGrillaRoles(Roles, idMenu);
                $('#ddlFunciones').val(idMenu);
                DetenerPrecargaBancaSeguros();
            },
            error: function (data) {
                var errorMessage = data.responseText;
                MostrarMensajeGenerico(3, errorMessage);
                DetenerPrecargaBancaSeguros();
            }
        });

        return Roles;
    }
}

function CargarGrillaRoles(roles, idMenu) {
    if (roles.length <= 0) {
        ConsultarRoles();
        $('#ddlFunciones').val(idMenu);
    }
    else {
        var result = roles;
        oSettings = oTableReporte.fnSettings();
        oTableReporte.fnClearTable(this);
        var control;

        for (var i = 0; i < result.length; i++) {
            $('#ddlFunciones').val(result[i].IdMenu);
            if ((!result[i].Requiere) && (!result[i].Autoriza) && (result[i].IdControlDual <= 0)) {
                control = true;
                FilaRol = {
                    IdRol: result[i].IdRol,
                    Nombre: result[i].NombreRol,
                    Requiere: '<input type="checkbox" name="fila' + i + '" id="check-' + i + '" onclick="pulsar(this)"  /> <input type="hidden" id="IdControlDual' + i + '" value="' + result[i].IdControlDual + '" />',
                    Autoriza: '<input type="checkbox" name="fila' + i + '" id="aut' + i + '" onclick="pulsar(this)" value="' + result[i].IdRol + '"  /> <input type="hidden" id="' + result[i].NombreRol + '" value="' + result[i].IdRol + '" />',
                }

            }
            else if (result[i].Requiere) {
                control = false;
                FilaRol = {
                    IdRol: result[i].IdRol,
                    Nombre: result[i].NombreRol,
                    Requiere: '<input type="checkbox" name="fila' + i + '" id="check-' + i + '" onclick="pulsar(this)" checked="checked"  /> <input type="hidden" id="IdControlDual'+ i + '" value="' + result[i].IdControlDual + '" />',
                    Autoriza: '<input type="checkbox" name="fila' + i + '" id="aut' + i + '" onclick="pulsar(this)" value="' + result[i].IdRol + '"  /> <input type="hidden" id="' + result[i].NombreRol + '" value="' + result[i].IdRol + '" />',
                }
            }
            else if ((!result[i].Requiere) && (!result[i].Autoriza))
            {
                control = false;
                FilaRol = {
                    IdRol: result[i].IdRol,
                    Nombre: result[i].NombreRol,
                    Requiere: '<input type="checkbox" name="fila' + i + '" id="check-' + i + '" onclick="pulsar(this)"  /> <input type="hidden" id="IdControlDual' + i + '" value="' + result[i].IdControlDual + '" />',
                    Autoriza: '<input type="checkbox" name="fila' + i + '" id="aut' + i + '" onclick="pulsar(this)" value="' + result[i].IdRol + '"  /> <input type="hidden" id="' + result[i].NombreRol + '" value="' + result[i].IdRol + '" />',
                }

            }
            else if (result[i].Autoriza) {
                control = false;
                FilaRol = {
                    IdRol: result[i].IdRol,
                    Nombre: result[i].NombreRol,
                    Requiere: '<input type="checkbox" name="fila' + i + '" id="check-' + i + '" onclick="pulsar(this)"  /> <input type="hidden" id="IdControlDual' + i + '" value="' + result[i].IdControlDual + '" />',
                    Autoriza: '<input type="checkbox" name="fila' + i + '" id="aut' + i + '" onclick="pulsar(this)" value="' + result[i].IdRol + '" checked="checked"  /> <input type="hidden" id="' + result[i].NombreRol + '" value="' + result[i].IdRol + '" />',
                }
            }
            $('#idRol').val(result[i].IdRol);
            oTableReporte.oApi._fnAddData(oSettings, FilaRol);
        }

        oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
        oTableReporte.fnDraw();
        if (control) {
            $('input[name=btnAct]').hide();
            $('input[name=btnAgr]').show();
            $('input[name=btnCan]').show();
        }
        else {
            $('input[name=btnAct]').show();
            $('input[name=btnAgr]').hide();
            $('input[name=btnCan]').show();
        }
    }
}

function pulsar(obj) {
    if (!obj.checked) return
    else
    {
    elem = document.getElementsByName(obj.name);
    for (i = 0; i < elem.length; i++)
        elem[i].checked = false;
    obj.checked = true;
}
}

function SeleccionarFila() {
    var table = $('#gvControlDual').DataTable();
    $('#gvControlDual tbody').on('click', 'tr', function () {
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
            $('#idRol').val(DatosFilas.IdRol);
            //CargarDatosGuardar(DatosFila);
        }
    });
}

function Guardar() {
    var listItems = [];
    var resultado;
    ValidaDiv('formControlDual');
    var Resultado = $('#formControlDual').parsley().validate();
    if (Resultado) {
        listItems = LlenaEntidadControlDual();
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "AdministracionControlDual.aspx/InsertarAdmonControlDual",
            data: "{controlDual:" + JSON.stringify(listItems) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (resultado.Error == undefined) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                } else if (resultado.Error) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                } else {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                    Cancelar();
                }

                DetenerPrecargaBancaSeguros();
            },
            error: function (data) {
                MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
            }
        });
    }
    
    
}

function LlenaEntidadControlDual() {
    var listControlDual = [];
    
    var campo1, campo2, campo3;
    $("#gvControlDual tbody tr").each(function (index) {
        var ControlDual = {};
        $(this).children("td").each(function (index2) {
            switch (index2) {
                case 0:
                    var nombre = $(this).text();
                    ControlDual.IdRol = document.getElementById(nombre).value;
                    ControlDual.IdMenu = $('#ddlFunciones').val();
                    ControlDual.IdControlDual = $('#IdControlDual' + index).val();
                    //alert(campo1);
                    break;
                case 1:
                    if ($('#check-' + index).is(":checked")) {
                        ControlDual.Requiere = true;
                        ControlDual.Autoriza = false;
                    }
                    else if ($('#aut' + index).is(":checked")) {
                        ControlDual.Requiere = false;
                        ControlDual.Autoriza = true;
                    }
                    else if ((!$('#aut' + index).is(":checked")) && (!$('#check-' + index).is(":checked")))
                    {
                        ControlDual.Requiere = false;
                        ControlDual.Autoriza = false;
                    }

                    break;
            }
            $(this).css("background-color", "#ECF8E0"); 
        })
        listControlDual.push(ControlDual);
    })
    
    //console.log(listControlDual);
    return listControlDual;
}

function Actualizar() {
    var listItems = [];
    var resultado;
    ValidaDiv('formControlDual');
    var Resultado = $('#formControlDual').parsley().validate();
    if (Resultado) {
        listItems = LlenaEntidadControlDual();
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "AdministracionControlDual.aspx/ActualizarAdmonControlDual",
            data: "{controlDual:" + JSON.stringify(listItems) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (resultado.Error == undefined) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje)
                } else if (resultado.Error) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje)
                } else {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje)
                    //ConsultarRoles();
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
}

function Cancelar() {
    $('#ddlFunciones').val("");
    oSettings = oTableReporte.fnSettings();
    oTableReporte.fnClearTable(this);
    $('input[name=btnAct]').hide();
    $('input[name=btnAgr]').hide();
    $('input[name=btnCan]').hide();
}

