var oTableReporte;
var cvicoclick = false;

$(document).ready(function () {
    if (initSession()) {
        IniciarPrecargaBancaSeguros();
        InicializarGrilla();
        CargarSecciones(true);
        CargarListaGruposBAC();
        CargarListaFuncionesMenu()
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
    oTableReporte = $('#gvRol').dataTable({
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
            { "data": "Estado" },
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
    DeshabilitarDivYContenido('panelGrillaRol', estado);
}

function CargarListaGruposBAC() {
    var grupoBac = {};
    var grupos = {};

    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "Roles.aspx/ObtenerGruposBAC",
        data: "{grupo:" + JSON.stringify(grupoBac) + "}",
        dataType: "json",
        success: function (data) {
            grupos = data.d;
        },
        complete: function (data) {
            if (grupos.length > 0) {
                LlenarListaDesplegable(grupos, 'lstgruposAdicionar', "IdGrupo", "NombreGrupo");
            }
            else {
                MostrarMensajeGenerico(2, 'No existen Grupos BAC configurados.')
            }
            DetenerPrecargaBancaSeguros();
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage)
            DetenerPrecargaBancaSeguros();
        }
    });;
}

function CargarListaFuncionesMenu() {
    var funcionesmenu = {};

    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "Roles.aspx/ObtenerFuncionesMenu",
        dataType: "json",
        success: function (data) {
            funcionesmenu = data.d;
        },
        complete: function (data) {
            if (funcionesmenu.length > 0) {
                LlenarListaDesplegable(funcionesmenu, 'lstfuncAdicionar', "IdMenu", "Nombre");
            }
            else {
                MostrarMensajeGenerico(2, 'No existen opciones de menu configuradas.')
            }
            DetenerPrecargaBancaSeguros();
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage)
            DetenerPrecargaBancaSeguros();
        }
    });;
}

function SelecionarFila() {
    var table = $('#gvRol').DataTable();
    $('#gvRol tbody').on('click', 'tr', function () {
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
            CargarDatosRol(DatosFila);
        }
    });
}

function CargarDatosRol(DatosFilas) {
    $('#dividRol').html(DatosFilas.IdRol);
    $('#txtNombre').val(DatosFilas.Nombre);

    if (DatosFilas.Estado == "ACTIVO") {
        document.getElementById("chkActivo-1").checked = true;
        document.getElementById("chkActivo-0").checked = false;
    } else {
        document.getElementById("chkActivo-1").checked = false;
        document.getElementById("chkActivo-0").checked = true;
    }
    document.getElementById("btnAgr").style.visibility = "hidden";
    document.getElementById("btnAct").style.visibility = "visible";
    $('#lstfunAdicionados').empty();
    $('#lstgruposAdicionados').empty();
    CargarListaGruposBACPorRol(DatosFilas);
    CargarListaFuncionesMenuPorRol(DatosFilas);
    $('#modalInfoRol').modal('show');
}

function Cancelar() {
    $('#modalInfoRol').modal('hide');
}

function CargarNuevoFormulario() {
    $('#dividRol').html('0');
    $('#txtNombre').val('');
    document.getElementById("chkActivo-1").checked = true;
    document.getElementById("chkActivo-0").checked = false;
    document.getElementById("btnAgr").style.visibility = "visible";
    document.getElementById("btnAct").style.visibility = "hidden";
    $('#lstfunAdicionados').empty();
    $('#lstgruposAdicionados').empty();
    $('#modalInfoRol').parsley().destroy();
    $('#modalInfoRol').modal('show');
}

function ConsultarRoles() {
    ValidaDiv('panelConsultar');
    var Resultado = $('#panelConsultar').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        var nombreRol = $('#txtNombreBusqueda').val();
        var estado = '';
        var roles;
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "Roles.aspx/ObtenerRoles",
            data: "{nombre:'" + nombreRol + "',estado:'" + estado + "'}",
            dataType: "json",
            success: function (data) {
                roles = data.d;
            },
            complete: function (data) {
                if (roles.length > 0) {
                    CargarSecciones(false);
                    CargarGrillaRoles(roles);
                }
                else {
                    MostrarMensajeGenerico(2, 'No existen roles registrados en el sistema con el filtro seleccionado.')
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

function ConsultarRolesPorNombre(nombreRol) {
    IniciarPrecargaBancaSeguros();
    var estado = '';
    var roles;
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "Roles.aspx/ObtenerRoles",
        data: "{nombre:'" + nombreRol + "',estado:'" + estado + "'}",
        dataType: "json",
        success: function (data) {
            roles = data.d;
        },
        complete: function (data) {
            if (roles.length > 0) {
                CargarSecciones(false);
                CargarGrillaRoles(roles);
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

function CargarGrillaRoles(roles) {
    var result = roles;
    oSettings = oTableReporte.fnSettings();
    oTableReporte.fnClearTable(this);

    var estado;

    for (var i = 0; i < result.length; i++) {

        if (result[i].Activo) {
            estado = 'ACTIVO';
        }
        else {
            estado = 'INACTIVO';
        }


        FilaRol = {
            IdRol: result[i].IdRol,
            Nombre: result[i].Nombre,
            Estado: estado,
            Editar: '<input type="image" src="../imagenes/edit.jpg" width="25" height="25" title="Editar" id="cvico" onclick="cvicoclick=true"/>'
        }

        oTableReporte.oApi._fnAddData(oSettings, FilaRol);
    }

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTableReporte.fnDraw();
}

function CargarListaGruposBACPorRol(Rol) {
    var gruposRol = {};

    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "Roles.aspx/ObtenerGruposPorRol",
        data: "{rol:" + JSON.stringify(Rol) + "}",
        dataType: "json",
        success: function (data) {
            gruposRol = data.d;
        },
        complete: function (data) {
            if (gruposRol.length > 0) {
                LlenarListaDesplegable(gruposRol, 'lstgruposAdicionados', "IdGrupo", "NombreGrupo");
            }
            DetenerPrecargaBancaSeguros();
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage)
            DetenerPrecargaBancaSeguros();
        }
    });;
}

function CargarListaFuncionesMenuPorRol(Rol) {
    var funcionesRol = {};

    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "Roles.aspx/ObtenerFuncionesMenuPorRol",
        data: "{rol:" + JSON.stringify(Rol) + "}",
        dataType: "json",
        success: function (data) {
            funcionesRol = data.d;
        },
        complete: function (data) {
            if (funcionesRol.length > 0) {
                LlenarListaDesplegable(funcionesRol, 'lstfunAdicionados', "IdMenu", "Nombre");
            }
            DetenerPrecargaBancaSeguros();
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage)
            DetenerPrecargaBancaSeguros();
        }
    });;
}

function GuardarRol() {
    ValidaDiv('modalInfoRol');
    var Resultado = $('#modalInfoRol').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        var datosRol = {};
        datosRol = LlenarEntidadRol();
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
            var resultado;
            $.ajax({
                type: "POST",
                cache: false,
                async: true,
                contentType: "application/json; charset=utf-8",
                url: "Roles.aspx/InsertarRol",
                data: "{rol:" + JSON.stringify(datosRol) + "}",
                dataType: "json",
                success: function (data) {
                    resultado = data.d;
                },
                complete: function (data) {
                    if (!resultado.Error) {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                        $('#modalInfoRol').modal('hide');
                        DetenerPrecargaBancaSeguros();
                        ConsultarRolesPorNombre(datosRol.Nombre);
                    }
                    else {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                        DetenerPrecargaBancaSeguros();
                    }
                },
                error: function (data) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje)
                    DetenerPrecargaBancaSeguros();
                }
            });
        }
        else {
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Insertar', 'Rol', JSON.stringify(datosRol), '#modalInfoRol');
        }
    }
}

function ActualizarRol() {
    ValidaDiv('modalInfoRol');
    var Resultado = $('#modalInfoRol').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        var datosRol = {};
        datosRol = LlenarEntidadRol();
        var registroAutorizaDual = $.jStorage.get('RegistroAutorizaDual');
        if (!registroAutorizaDual.requiereAutorizacion) {
            var resultado;
            $.ajax({
                type: "POST",
                cache: false,
                async: true,
                contentType: "application/json; charset=utf-8",
                url: "Roles.aspx/ActualizarRol",
                data: "{rol:" + JSON.stringify(datosRol) + "}",
                dataType: "json",
                success: function (data) {
                    resultado = data.d;
                },
                complete: function (data) {
                    if (!resultado.Error) {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje)
                        $('#modalInfoRol').modal('hide');
                        DetenerPrecargaBancaSeguros();
                        ConsultarRolesPorNombre(datosRol.Nombre);
                    }
                    else {
                        MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje)
                        DetenerPrecargaBancaSeguros();
                    }
                },
                error: function (data) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje)
                    DetenerPrecargaBancaSeguros();
                }
            });
        }
        else {
            AlmacenarRegistroTemporalControlDual(registroAutorizaDual.IdMenu, 'Actualizar', 'Rol', JSON.stringify(datosRol), '#modalInfoRol');
        }
    }
}

function LlenarEntidadRol() {
    var Rol = {};
    Rol.IdRol = parseInt($('#dividRol').html(), 0);
    Rol.Nombre = $('#txtNombre').val();
    if (document.getElementById("chkActivo-1").checked) {
        Rol.Activo = true;
    }
    else {
        Rol.Activo = false;
    }

    var listGruposAdicionados = document.getElementById("lstgruposAdicionados");
    if (listGruposAdicionados.length > 0) {
        var gruposRol = [];
        for (var i = 0; i < listGruposAdicionados.length; i++) {
            var GrupoBAC = {};
            GrupoBAC.IdGrupo = parseInt(listGruposAdicionados.options[i].value, 0);
            gruposRol.push(GrupoBAC);
        }
        Rol.GruposBAC = gruposRol;
    }

    var listMenusAdicionados = document.getElementById("lstfunAdicionados");
    if (listMenusAdicionados.length > 0) {
        var menusRol = [];
        for (var i = 0; i < listMenusAdicionados.length; i++) {
            var Menu = {};
            Menu.IdMenu = parseInt(listMenusAdicionados.options[i].value, 0);
            menusRol.push(Menu);
        }
        Rol.Menus = menusRol;
    }
    return Rol;
}

function AdicionaGrupoBAC() {
    var adicionado = false;
    var idGrupoSeleccionado = $("#lstgruposAdicionar").val();
    var nombreGrupoSeleccionado = $("#lstgruposAdicionar option:selected").text();
    if (idGrupoSeleccionado != undefined) {
        var listaGrupoAdicionados = document.getElementById('lstgruposAdicionados');
        if (listaGrupoAdicionados.options.length > 0) {

            for (var i = 0; i < listaGrupoAdicionados.options.length; i++) {
                if (listaGrupoAdicionados.options[i].value === idGrupoSeleccionado) {
                    adicionado = true;
                    MostrarMensajeGenerico(2, 'El grupo ya se adicionó a la lista.');
                    break;
                }

            }

            if (!adicionado) {
                listaGrupoAdicionados.add(new Option(nombreGrupoSeleccionado, idGrupoSeleccionado, false));
            }
        }
        else
            listaGrupoAdicionados.add(new Option(nombreGrupoSeleccionado, idGrupoSeleccionado, false));

    }
    else {
        MostrarMensajeGenerico(2, "Debe seleccionar un grupo de la lista");
    }
}

function EliminaGrupoBAC() {
    var listaGruposAdicionados = document.getElementById('lstgruposAdicionados');
    for (var i = 0; i < listaGruposAdicionados.options.length; i++) {
        if (listaGruposAdicionados.options[i].selected)
            listaGruposAdicionados.remove(i);
    }
}

function AdicionaMenu() {
    var adicionado = false;
    var idMenuSeleccionado = $("#lstfuncAdicionar").val();
    var nombreMenuSeleccionado = $("#lstfuncAdicionar option:selected").text();
    if (idMenuSeleccionado != undefined) {
        var listaMenuAdicionados = document.getElementById('lstfunAdicionados');
        if (listaMenuAdicionados.options.length > 0) {

            for (var i = 0; i < listaMenuAdicionados.options.length; i++) {
                if (listaMenuAdicionados.options[i].value === idMenuSeleccionado) {
                    adicionado = true;
                    MostrarMensajeGenerico(2, 'La funcionalidad ya se adicionó a la lista.');
                    break;
                }

            }

            if (!adicionado) {
                listaMenuAdicionados.add(new Option(nombreMenuSeleccionado, idMenuSeleccionado, false));
            }
        }
        else
            listaMenuAdicionados.add(new Option(nombreMenuSeleccionado, idMenuSeleccionado, false));

    }
    else {
        MostrarMensajeGenerico(2, "Debe seleccionar una funcionalidad de la lista");
    }
}

function EliminaMenu() {
    var listaMenuAdicionados = document.getElementById('lstfunAdicionados');
    for (var i = 0; i < listaMenuAdicionados.options.length; i++) {
        if (listaMenuAdicionados.options[i].selected)
            listaMenuAdicionados.remove(i);
    }
}

function ExportarRolesExcel(roles) {
    var tab_text = "<table border='1px'>";
    tab_text = tab_text + "<tr><th>Nombre</th><th>Estado</th><th>Grupo BAC</th><th>Funcionalidad</th></tr>";
    var estado;

    for (var i = 0; i < roles.length; i++) {
        var cantidadGrupos = roles[i].GruposBAC.length;
        var cantidadFuns = roles[i].Menus.length;
        var rowspanRol;
        if (cantidadFuns > cantidadGrupos) {
            rowspanRol = cantidadFuns;
        }
        else {
            rowspanRol = cantidadGrupos;
        }

        tab_text = tab_text + "<tr>";
        tab_text = tab_text + "<td  rowspan='" + rowspanRol.toString() + "' valign='center' align='center'>" + roles[i].Nombre + "</td>";

        if (roles[i].Activo) {
            estado = 'ACTIVO';
        }
        else {
            estado = 'INACTIVO';
        }

        tab_text = tab_text + "<td rowspan='" + rowspanRol.toString() + "' valign='center' align='center'>" + estado + "</td>";

        if (cantidadGrupos > 0) {
            tab_text = tab_text + "<td>" + roles[i].GruposBAC[0].NombreGrupo + "</td>";
        }
        else {
            tab_text = tab_text + "<td></td>";
        }
        if (cantidadFuns > 0) {
            tab_text = tab_text + "<td>" + roles[i].Menus[0].Nombre + "</td>";
        }
        else {
            tab_text = tab_text + "<td></td>";
        }

        tab_text = tab_text + "</tr>";

        for (var j = 1; j < rowspanRol ; j++) {
            tab_text = tab_text + "<tr>";

            if (cantidadGrupos > j) {
                tab_text = tab_text + "<td>" + roles[i].GruposBAC[j].NombreGrupo + "</td>";
            }
            else {
                tab_text = tab_text + "<td></td>";
            }

            if (cantidadFuns > j) {
                tab_text = tab_text + "<td>" + roles[i].Menus[j].Nombre + "</td>";
            }
            else {
                tab_text = tab_text + "<td></td>";
            }

            tab_text = tab_text + "</tr>";
        }
    }

    tab_text = tab_text + "</table>";


    var ua = window.navigator.userAgent;
    var msie = ua.indexOf("MSIE ");
    DetenerPrecargaBancaSeguros();
    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // Internet Explorer
    {
        iframeExcel.document.open("txt/html", "replace");
        iframeExcel.document.write(tab_text);
        iframeExcel.document.close();
        iframeExcel.focus();
        sa = iframeExcel.document.execCommand("SaveAs", true, "Roles.xls");
    }
    else                 //other browser 
        sa = window.open('data:application/vnd.ms-excel,' + escape(tab_text));

    return (sa);
}

function ConsultarRolesExportacion() {
    IniciarPrecargaBancaSeguros();
    var nombreRol = '';
    var estado = '';
    var roles;
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "Roles.aspx/ObtenerRolesCompletos",
        data: "{nombre:'" + nombreRol + "',estado:'" + estado + "'}",
        dataType: "json",
        success: function (data) {
            roles = data.d;
        },
        complete: function (data) {
            if (roles.length > 0) {
                ExportarRolesExcel(roles);
            }
            else {
                MostrarMensajeGenerico(2, 'No existen roles registrados en el sistema.')
            }
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage)
            DetenerPrecargaBancaSeguros();
        }
    });
}