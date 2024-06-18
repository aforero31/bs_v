var oTableReporte;
var verDetalle = false;
var aprobar = false;
var rechazar = false;

$(document).ready(function () {
    if (initSession()) {
        IniciarPrecargaBancaSeguros();
        
        $(document).on('focus', ".fecha", function () {
            $(this).daterangepicker({
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
            })
        });

        InicializarGrilla();
        CargarSecciones(true);
        SelecionarFila();
        

        var roles = $.jStorage.get('Roles');
        DetenerPrecargaBancaSeguros();
        ValidarAutorizadorDual(roles);
    }
    else {
        IniciarPrecargaBancaSeguros();
        MostrarModalConfirmar(3, "Usted no se encuentra logueado o con permisos para acceder a esa pagina", 'sessLogOut()', 'sessLogOut()');
    }
});

function CargarComboFuncionesAprobador(roles) {
    IniciarPrecargaBancaSeguros();
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "AprobarControlDual.aspx/ConsultarMenusAprobacionDual",
        data: "{roles:" + JSON.stringify(roles) + "}",
        dataType: "json",
        success: function (data) {
            menus = data.d;
        },
        complete: function (data) {
            if (menus.length > 0) {
                LlenarListaDesplegable(menus, 'ddlFuncion', "IdMenu", "Nombre");
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

function CargarComboFuncionesRequiereControl(roles) {
    IniciarPrecargaBancaSeguros();
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "AprobarControlDual.aspx/ConsultarMenusRequiereAprobacionDual",
        data: "{roles:" + JSON.stringify(roles) + "}",
        dataType: "json",
        success: function (data) {
            menus = data.d;
        },
        complete: function (data) {
            if (menus.length > 0) {
                LlenarListaDesplegable(menus, 'ddlFuncion', "IdMenu", "Nombre");
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
    else if ($('#txtFechaInicial').val() !== '' && $('#txtFechaFinal').val() === '')
    {
        valido = false;
        MostrarMensajeGenerico(2, 'Se debe selecciona una fecha final.');
    }
    else if ($('#txtFechaInicial').val() === '' && $('#txtFechaFinal').val() !== '') {
        valido = false;
        MostrarMensajeGenerico(2, 'Se debe selecciona una fecha inicial.');
    }
    else
    {
        valido = true;
    }

    return valido;
}

function ValidarFiltrosBusqueda()
{
    var valido = true;
    var filtrosSeleccionados = 0;
    if ($('#ddlFuncion').val() !== "")
    {
        filtrosSeleccionados ++;
    }
    if ($('#ddlEstado').val() !== "")
    {
        filtrosSeleccionados++;
    }

    if ($('#txtFechaInicial').val() !== '' && $('#txtFechaFinal').val() !== '')
    {
        filtrosSeleccionados++;
    }

    if (filtrosSeleccionados < 2)
    {
        valido = false;
        MostrarMensajeGenerico(2, 'Debe selecciona al menos dos filtros de busqueda.');
    }

    return valido;
}

function InicializarGrilla() {
    oTableReporte = $('#gvAprobaciones').dataTable({
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
            { "data": "IdAprobacionDual", "visible": false, "searchable": false },
            { "data": "IdMenu", "visible": false, "searchable": false },
            { "data": "Funcion" },
            { "data": "Estado" },
            { "data": "Accion" },
            { "data": "UsuarioEnvia" },
            { "data": "UsuarioAprueba" },
            { "data": "FechaSolicitud" },
            { "data": "FechaAprobacion" },
            { "data": "Detalle" },
            { "data": "Proceso"}
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

function SelecionarFila() {
    var table = $('#gvAprobaciones').DataTable();
    $('#gvAprobaciones tbody').on('click', 'tr', function () {
        rowgvReporte = $(this).index();
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }

        if (verDetalle) {
            verDetalle = false;
            var DatosFila = table.fnGetData(this);
            CargarDetalleAprobacion(DatosFila.IdAprobacionDual);
        }

        if (aprobar) {
            aprobar = false;
            var DatosFila = table.fnGetData(this);
            CargarModalAprobacion(DatosFila.IdAprobacionDual, DatosFila.Accion);
        }

        if (rechazar) {
            rechazar = false;
            var DatosFila = table.fnGetData(this);
            CargarModalRechazo(DatosFila.IdAprobacionDual, DatosFila.Accion);
        }
    });
}

function LimpiarControles() {
    $('#ddlFuncion').val("");
    $('#ddlEstado').val("");
    $('#txtFechaInicial').val("");
    $('#txtFechaFinal').val("");
}

function CargarSecciones(estado) {
    DeshabilitarDivYContenido('panelGrillaReporte', estado);
}

function ConsultarAprobaciones() {
    ValidaDiv('panelConsultar');
    var Resultado = $('#panelConsultar').parsley().validate();
    if (Resultado)
    {
        Resultado = ValidarFiltrosBusqueda();
        if (Resultado && ValidarRangoFechas()) {
            IniciarPrecargaBancaSeguros();
            var datosAprobacion = {};
            datosAprobacion = LlenarEntidadAprobacionBusqueda();
            var aprobaciones;
            $.ajax({
                type: "POST",
                cache: false,
                async: true,
                contentType: "application/json; charset=utf-8",
                url: "AprobarControlDual.aspx/ConsultarAprobacionesControlDual",
                data: "{aprobacion:" + JSON.stringify(datosAprobacion) + "}",
                dataType: "json",
                success: function (data) {
                    aprobaciones = data.d;
                },
                complete: function (data) {
                    if (aprobaciones.length > 0) {
                        CargarSecciones(false);
                        CargarGrillaAprobaciones(aprobaciones);
                    }
                    else {
                        MostrarMensajeGenerico(2, 'No existen registros en el sistema con el filtro seleccionado.');
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
}

function ConsultarAprobacionesPorId(idAprobacion) {
        IniciarPrecargaBancaSeguros();
        var datosAprobacion = {};
        datosAprobacion.IdAprobacionDual = idAprobacion;
        var aprobaciones;
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "AprobarControlDual.aspx/ConsultarAprobacionesControlDual",
            data: "{aprobacion:" + JSON.stringify(datosAprobacion) + "}",
            dataType: "json",
            success: function (data) {
                aprobaciones = data.d;
            },
            complete: function (data) {
                if (aprobaciones.length > 0) {
                    CargarSecciones(false);
                    CargarGrillaAprobaciones(aprobaciones);
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

function LlenarEntidadAprobacionBusqueda()
{
    var AprobacionDual = {};
    if ($('#ddlFuncion').val() !== "") {
        AprobacionDual.IdMenu = parseInt($('#ddlFuncion').val(), 0);
    }
    AprobacionDual.Estado = $('#ddlEstado').val();
    if ($('#txtFechaInicial').val() !== '') {
        var dia = $.trim($('#txtFechaInicial').val()).substr(0, 2);
        var mes = $.trim($('#txtFechaInicial').val()).substr(3, 2) - 1;
        var anio = $.trim($('#txtFechaInicial').val()).substr(6, 4);
        var fechaInicial = new Date(anio, mes, dia);
        AprobacionDual.FechaSolicitudInicial = fechaInicial;
    }

    if ($('#txtFechaFinal').val() !== '') {
        var diaf = $.trim($('#txtFechaFinal').val()).substr(0, 2);
        var mesf = $.trim($('#txtFechaFinal').val()).substr(3, 2) - 1;
        var aniof = $.trim($('#txtFechaFinal').val()).substr(6, 4);
        var fechafinal = new Date(aniof, mesf, diaf);
        AprobacionDual.FechaSolicitudFinal = fechafinal;
    }

    return AprobacionDual;
}

function CargarGrillaAprobaciones(aprobaciones)
{
    var result = aprobaciones;
    oSettings = oTableReporte.fnSettings();
    oTableReporte.fnClearTable(this);

    var estado;
    var proceso = "";

    for (var i = 0; i < result.length; i++) {

        switch(result[i].Estado)
        {
            case "P":
                {
                    estado = "Por Aprobar";
                    var autorizadorDual = $.jStorage.get('AutorizadorDual');
                    if (autorizadorDual) {
                        proceso = '<input type="button" id="btnAprobar' + i + '" value="Aprobar" onclick="aprobar=true" style="width:70px;" /><input type="button" id="btnRechazar' + i + '" value="Rechazar" onclick="rechazar=true" style="width:70px;margin-left:5px"/>'
                    }
                }
                break;
            case "A":
                    estado = "Aprobada";
                break;
            case "R":
                estado = "Rechazada"
                break;
        }

        if (ConvertJsonToDate(new Date(parseInt(result[i].FechaSolicitud.substr(6), 0))) === "01/01/1") {
            result[i].FechaSolicitud = '';
        } else {
            result[i].FechaSolicitud = ConvertJsonToDate(new Date(parseInt(result[i].FechaSolicitud.substr(6), 0)));
        }

        if (ConvertJsonToDate(new Date(parseInt(result[i].FechaAprobacion.substr(6), 0))) === "01/01/1") {
            result[i].FechaAprobacion = '';
        } else {
            result[i].FechaAprobacion = ConvertJsonToDate(new Date(parseInt(result[i].FechaAprobacion.substr(6), 0)));
        }


        FilaAprobacion = {
            IdAprobacionDual: result[i].IdAprobacionDual,
            IdMenu: result[i].IdMenu,
            Funcion: result[i].NombreMenu,
            Estado: estado,
            Accion: result[i].Accion,
            UsuarioEnvia: result[i].UsuarioEnvia,
            UsuarioAprueba: result[i].UsuarioAprueba,
            FechaSolicitud: result[i].FechaSolicitud,
            FechaAprobacion: result[i].FechaAprobacion,
            Detalle: '<input type="button" id="btnAprobar' + i + '" value="Ver Detalle" onclick="verDetalle=true"/>',
            Proceso: proceso
        }

        oTableReporte.oApi._fnAddData(oSettings, FilaAprobacion);
    }

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTableReporte.fnDraw();
}

function CargarDetalleAprobacion(idAprobacionDual)
{
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "AprobarControlDual.aspx/ConsultarAprobacionesControlDualPorId",
        data: "{idAprobacionDual:" + idAprobacionDual + "}",
        dataType: "json",
        success: function (data) {
            aprobacion = data.d;
        },
        complete: function (data) {
            if (aprobacion != undefined) {
                CargarPopupDetalleAprobacion(aprobacion);
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

function CargarPopupDetalleAprobacion(aprobacion)
{
    $('#divNombreRegistro').html(aprobacion.NombreObjeto);

    var table = document.getElementById("tblEntidad");
    while (table.rows.length > 1) {
        table.deleteRow(table.rows.length - 1);
    }
    
    var datos = JSON.parse(aprobacion.DatosObjeto);
    var datosAntes = JSON.parse(aprobacion.DatosObjetoActual);
    
    if (aprobacion.Estado !== "P")
    {
        $('#divDescripcion').html('Descripción: ' + aprobacion.Descripcion);
    }
    else
    {
        $('#divDescripcion').html('');
    }

    var cellTituloAntes = document.getElementById("tdValorAntes");
    cellTituloAntes.style.visibility = "collapse";
    cellTituloAntes.style.display = "none";

    if (aprobacion.Accion === "Actualizar")
    {
        if (datosAntes != null) {
            cellTituloAntes.style.visibility = "visible";
            cellTituloAntes.style.display = "table-cell";
        }
        else
        {
            cellTituloAntes.style.visibility = "collapse";
            cellTituloAntes.style.display = "none";
        }
    }
    
    MostrarCampos(datos, "", false, "tblEntidad", datosAntes);
    if (aprobacion.NombreObjeto === "Rol")
    {
        MostrarCamposEliminados(datosAntes, "", false, "tblEntidad", datos);
    }
    $('#modalDetalle').modal('show');
}

function CargarModalAprobacion(idAprobacionDual, accion)
{
    $('#spantituloAutoriza').html("Aprobación");
    $('#divIdAprobacionDual').html(idAprobacionDual);
    $('#divAccionAprobacionDual').html(accion);
    $('#btnRechazar').hide();
    $('#btnAprobar').show();
    $('#txtDescripcion').val('');
    $('#modalAutorizacion').parsley().destroy();
    $('#modalAutorizacion').modal('show');
}

function CargarModalRechazo(idAprobacionDual,accion) {
    $('#spantituloAutoriza').html("Rechazo");
    $('#divIdAprobacionDual').html(idAprobacionDual);
    $('#divAccionAprobacionDual').html(accion);
    $('#btnRechazar').show();
    $('#btnAprobar').hide();
    $('#txtDescripcion').val('');
    $('#modalAutorizacion').parsley().destroy();
    $('#modalAutorizacion').modal('show');
}

function CancelarCambio()
{
    $('#divIdAprobacionDual').html('');
    $('#txtDescripcion').val('');
    $('#modalAutorizacion').modal('hide');
}

function MostrarCampos(campo, campoPadre, campoPadreArray,nombreTabla,campoAntes)
{
    for (i in campo) {
        if (typeof campo[i] === 'object')
        {
            var nombreCampo;
            if (campoPadre !== "") {
                if (campoPadreArray)
                {
                    nombreCampo = campoPadre + "[" + i + "]";
                }
                else
                {
                    nombreCampo = campoPadre + "." + i;
                }
            }
            else
            {
                nombreCampo = i;
            }
           
            var padreArray = false;
            if ($.isArray(campo[i]))
            {
                padreArray = true;
            }

            if (campoAntes != null) {
                var datoActual = campoAntes[i];
                if (datoActual != undefined) {
                }
                else
                {
                    datoActual = null;
                }
            }

            MostrarCampos(campo[i], nombreCampo, padreArray, nombreTabla, datoActual);
        }
        else if (typeof campo[i] !== 'function')
        {
            var table = document.getElementById(nombreTabla);
            var row = table.insertRow(table.rows.length);

            var cell1 = row.insertCell(0);
            var cell2 = row.insertCell(1);
            var cell3 = row.insertCell(2);
            cell1.style.wordWrap = "break-word";
            cell2.style.wordWrap = "break-word";
            cell3.style.wordWrap = "break-word";
            
            
            var nombreCampo;
            if (campoPadre !== "")
            {
                nombreCampo = campoPadre + "." + i;
            }
            else
            {
                nombreCampo = i;
            }
            cell1.innerHTML = nombreCampo;

            var valorAntes = null;
            if (campoAntes != null) {
                var datoActual = campoAntes[i];
                if (datoActual != undefined) 
                {
                    if (campo[i] !== campoAntes[i]) {
                        valorAntes = campoAntes[i];
                    }
                    else {
                        valorAntes = null;
                    }
                }
            }

            if (nombreCampo !== "Plantilla") 
            {
                cell2.innerHTML = campo[i];
                if (valorAntes != null)
                {
                    cell3.innerHTML = valorAntes;
                    cell3.style.visibility = "visible";
                }
                else
                {
                    cell3.style.visibility = "collapse";
                    cell3.style.display = "none";
                }
            }
            else
            {
                cell2.innerHTML = campo[i].length;
                if (valorAntes != null)
                {
                    cell3.innerHTML = valorAntes.length;
                    cell3.style.visibility = "visible";
                }
                else
                {
                    cell3.style.visibility = "collapse";
                    cell3.style.display = "none";
                }
            }
        }
    }
}

function MostrarCamposEliminados(campo, campoPadre, campoPadreArray, nombreTabla, campoAntes) {
    for (i in campo)
    {
        if (typeof campo[i] === 'object')
        {
            var nombreCampo;
            if (campoPadre !== "")
            {
                if (campoPadreArray)
                {
                    nombreCampo = campoPadre + "[" + i + "]";
                }
                else
                {
                    nombreCampo = campoPadre + "." + i;
                }
            }
            else
            {
                nombreCampo = i;
            }

            var padreArray = false;
            if ($.isArray(campo[i]))
            {
                padreArray = true;
            }

            if (campoAntes[i] == undefined)
            {
                var valorCampo = campo[i];
                CargarRegistroEliminado(nombreTabla, nombreCampo, valorCampo, padreArray);
            }
            else
            {
                MostrarCamposEliminados(campo[i], nombreCampo, padreArray, nombreTabla, campoAntes[i]);
            }

        }
        else if (typeof campo[i] !== 'function')
        {
            if (campoAntes[i] == undefined)
            {
                var nombreCampo;
                if (campoPadre !== "")
                {
                    nombreCampo = campoPadre + "." + i;
                }
                else
                {
                    nombreCampo = i;
                }

                var valorCampo = campo[i];
                var table = document.getElementById(nombreTabla);
                var row = table.insertRow(table.rows.length);

                var cell1 = row.insertCell(0);
                var cell2 = row.insertCell(1);
                var cell3 = row.insertCell(2);
                cell1.style.wordWrap = "break-word";
                cell2.style.wordWrap = "break-word";
                cell3.style.wordWrap = "break-word";
                cell2.style.visibility = "collapse";
                cell2.style.display = "none";
                cell3.style.visibility = "visible";
                cell1.innerHTML = nombreCampo;
                cell3.innerHTML = valorCampo;
            }   
        }
    }
}

function CargarRegistroEliminado(nombreTabla, campoPadre, campo, padreArray)
{
    for (i in campo)
    {
        if (campo === 'object')
        {
            var nombreCampo;
            if (campoPadre !== "") {
                if (campoPadreArray) {
                    nombreCampo = campoPadre + "[" + i + "]";
                }
                else {
                    nombreCampo = campoPadre + "." + i;
                }
            }
            else {
                nombreCampo = i;
            }

            var padreArray = false;
            if ($.isArray(campo[i])) {
                padreArray = true;
            }

            CargarRegistroEliminado(nombreTabla, nombreCampo, campo[i], padreArray)
        }
        else
        {
            var nombreCampo;
            if (campoPadre !== "") {
                nombreCampo = campoPadre + "." + i;
            }
            else
            {
                nombreCampo = i;
            }

            var table = document.getElementById(nombreTabla);
            var row = table.insertRow(table.rows.length);

            var cell1 = row.insertCell(0);
            var cell2 = row.insertCell(1);
            var cell3 = row.insertCell(2);
            cell1.style.wordWrap = "break-word";
            cell2.style.wordWrap = "break-word";
            cell3.style.wordWrap = "break-word";
            cell2.style.visibility = "collapse";
            cell2.style.display = "none";
            cell3.style.visibility = "visible";
            cell1.innerHTML = nombreCampo;
            cell3.innerHTML = campo[i];
        }
    }
}

function AutorizarCambio()
{
    ValidaDiv('modalAutorizacion');
    var Resultado = $('#modalAutorizacion').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        var datosAprobacion = {};
        datosAprobacion = LlenarEntidadAprobacion(true);
        var resultado;
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "AprobarControlDual.aspx/ActualizarAprobacionDual",
            data: "{aprobacion:" + JSON.stringify(datosAprobacion) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (!resultado.Error) {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje)
                    $('#modalAutorizacion').modal('hide');
                    DetenerPrecargaBancaSeguros();
                    ConsultarAprobacionesPorId(datosAprobacion.IdAprobacionDual);
                }
                else {
                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);                    
                    DetenerPrecargaBancaSeguros();
                }
            },
            error: function (data) {
                MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.d.Mensaje);
                DetenerPrecargaBancaSeguros();
            }
        });
    }
}

function RechazarCambio() {
    ValidaDiv('modalAutorizacion');
    var Resultado = $('#modalAutorizacion').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        var datosAprobacion = {};
        datosAprobacion = LlenarEntidadAprobacion(false);
        var resultado;
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "AprobarControlDual.aspx/ActualizarAprobacionDual",
            data: "{aprobacion:" + JSON.stringify(datosAprobacion) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            complete: function (data) {
                if (!resultado.Error) {
                    MostrarMensajeGenerico(1, "Se realizo el rechazo exitosamente.");
                    $('#modalAutorizacion').modal('hide');
                    DetenerPrecargaBancaSeguros();
                    ConsultarAprobacionesPorId(datosAprobacion.IdAprobacionDual);
                }
                else {
                    MostrarMensajeGenerico(2, resultado.Mensaje)
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
}

function LlenarEntidadAprobacion(autoriza) {
    var AprobacionDual = {};
    AprobacionDual.IdAprobacionDual = parseInt($('#divIdAprobacionDual').html(), 0);
    AprobacionDual.Accion = $('#divAccionAprobacionDual').html();
    if (autoriza) {
        AprobacionDual.Estado = "A";
    }
    else
    {
        AprobacionDual.Estado = "R";
    }
    AprobacionDual.Descripcion = $('#txtDescripcion').val();

    return AprobacionDual;
}

function ValidarAutorizadorDual(roles)
{
    IniciarPrecargaBancaSeguros();
    var resultado = false;
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "AprobarControlDual.aspx/ValidarAutorizadorDual",
        data: "{rolesUsuario:" + JSON.stringify(roles) + "}",
        dataType: "json",
        success: function (data) {
            resultado = data.d;
        },
        complete: function (data) {
            $.jStorage.set('AutorizadorDual', resultado);
            DetenerPrecargaBancaSeguros();
            if (!resultado)
            {
                CargarComboFuncionesRequiereControl(roles);
            }
            else
            {
                CargarComboFuncionesAprobador(roles);
            }
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage)
            DetenerPrecargaBancaSeguros();
        }
    });
}

function RedireccionaInicio()
{
    validNavigation = true;
    window.location.assign(RutaSitio(2) + '/Inicio.aspx');
}