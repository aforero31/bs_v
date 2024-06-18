var oTablePlanes;
var oTableProductosBancarios;
var oTableBeneficiarios;
var rdplanesclick = false;
var rdprobanclick = false;
var imgbeneditclick = false;
var imgbeneliclick = false;
var indexBenf;
var totalPorcentaje;
var aleatorio;
var DatosfilaPB;
var oConsecutivo = null;
var SregistrarVenta = null;

$(document).ready(function () {
    if (initSession()) {
        IniciarPrecargaBancaSeguros();
        Inicializar();
        CargarCatalogos();
        PresentacionSecciones(true);
        $('input[name=btnActBen]').hide();
        $('input[name=btnCanBen]').hide();
        DesactivaCamposBeneficiario();
        CargarDatosAsesorLogueado();
        SelecionarFilaPlanes();
        SelecionarFilaProductosBancarios();
        SelecionarFilaBeneficiarios();

        $('#txtFechaNacimientoClienteNuevo').daterangepicker({
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
    else {
        IniciarPrecargaBancaSeguros();
        MostrarModalConfirmar(3, "Usted no se encuentra logueado o con permisos para acceder a esa pagina", 'sessLogOut()', 'sessLogOut()');
    }
});

function Inicializar() {
    oTablePlanes = $('#gvPlanes').dataTable({
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
            { "data": "IdPlan", "visible": false, "searchable": false },
            { "data": "CodigoConvenio", "visible": false, "searchable": false },
            { "data": "CodigoPlan" },
            { "data": "NombrePlan" },
            { "data": "Periodicidad" },
            { "data": "ValorMoneda" },
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

    oTableProductosBancarios = $('#gvProductosBancarios').dataTable({
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
            { "data": "CodigoProducto", "visible": false, "searchable": false },
            { "data": "CodigoSubProducto", "visible": false, "searchable": false },
            { "data": "CodigoCategoria", "visible": false, "searchable": false },
            { "data": "NumeroCuenta" },
            { "data": "NombreProducto" },
            { "data": "SaldoFormatoMoneda" },
            { "data": "Descripcion" },
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

    oTableBeneficiarios = $('#GridBeneficiario').dataTable({
        "oLanguage": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "No hay registros de beneficiarios",
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
           { "data": "Indice", "visible": false },
           { "data": "idTipoDocumento", "visible": false },
           { "data": "TipoDocBen", "class": "tipo" },
           { "data": "NoIdentificacionBeneficiario", "class": "num" },
           { "data": "primerNombre" },
           { "data": "segundoNombre" },
           { "data": "primerApellido" },
           { "data": "segundoApellido" },
           { "data": "idTipoparentesco", "visible": false, "searchable": false },
           { "data": "parentesco" },
           { "data": "porcentaje", "class": "post" },
           { "data": "Options" }
        ],
        "aoColumnDefs": [
            {
                'bSortable': false,
                'aTargets': [3, 4, 5, 6, 7, 8, 9, 10, 11]
            } //disables sorting for column one
        ],
        'iDisplayLength': 12,
        "sPaginationType": "full_numbers",
        "dom": 'T<"clear">lfrtip',
    });
}

function SelecionarFilaPlanes() {
    var table = $('#gvPlanes').DataTable();
    $('#gvPlanes tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
        if (rdplanesclick) {
            rdplanesclick = false;
            var DatosFila = table.fnGetData(this);
            CargarProductos(DatosFila);
            LimpiarFormularioVariables();
        }
    });
}

function SelecionarFilaProductosBancarios() {
    var table = $('#gvProductosBancarios').DataTable();
    $('#gvProductosBancarios tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
        if (rdprobanclick) {
            rdprobanclick = false;
            var DatosFila = table.fnGetData(this);
            ValidacionDeParametros(DatosFila);
        }
    });
}

function SelecionarFilaBeneficiarios() {
    var table = $('#GridBeneficiario').DataTable();
    $('#GridBeneficiario tbody').on('click', 'tr', function () {
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
            indexBenf = DatosFila.Indice;//$(this).index();
            CargarBeneficiario(DatosFila);
        } else if (imgbeneliclick) {
            imgbeneliclick = false;
            var DatosFila = table.fnGetData(this);
            EliminarBeneficiario($(this).index());
        }
    });
}

function CargarCatalogos() {
    var DataCatalogo = ConsultarCatalogo("SEG_TipoIdentificacion");
    if (DataCatalogo != null && DataCatalogo != undefined) {
        window._TipoIdentificacion = Enumerable.From(DataCatalogo.ListTipoIdentificacion).Where(function (x) { return x.Activo == true }).Select().ToArray();
        LlenarListaDesplegable(window._TipoIdentificacion, 'ddlTipoIdentificacion', "IdTipoIdentificacion", "Nombre");
        LlenarListaDesplegable(window._TipoIdentificacion, 'ddlTipoIdentificacionConyuge', "IdTipoIdentificacion", "Nombre");
        LlenarListaDesplegable(window._TipoIdentificacion, 'ddlTipoIdentificacionClienteNuevo', "IdTipoIdentificacion", "Nombre");
        LlenarListaDesplegable(window._TipoIdentificacion, 'ddlTipoIdentificacionBeneficiario', "IdTipoIdentificacion", "Nombre");
    }

    DataCatalogo = ConsultarCatalogo("SEG_Parentesco");
    if (DataCatalogo != null && DataCatalogo != undefined)
        LlenarCombo(DataCatalogo.ListParentesco, 'ddlParentescoBeneficiario');

    DataCatalogo = ConsultarCatalogo("SEG_Genero");
    if (DataCatalogo != null && DataCatalogo != undefined) {
        window._Genero = Enumerable.From(DataCatalogo.ListGenero).Where(function (x) { return x.Activo == true }).Select().ToArray();
        LlenarCombo(window._Genero, 'ddlSexoClienteNuevo');
    }
}

function PresentacionSecciones(estado) {
    DeshabilitarDivYContenido("panelConsultarDatosCliente", estado);
    DeshabilitarDivYContenido("panelSeguro", estado);
    DeshabilitarDivYContenido("panelConsultarDatosConyuge", estado);
    OcultarPanel("panelPlanes", estado);
    OcultarPanel("panelPestanas", estado);
}

function BuscarCliente() {
    var datosCliente = {};
    oConsecutivo = null;
    datosCliente = LlenarEntidadCliente('BuscarCliente');
    ValidaDivRegistroVenta();
    var Resultado = $('#div-registroVenta').parsley().validate();
    var control = false;
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "RegistrarVenta.aspx/BuscarCliente",
            data: "{cliente:" + JSON.stringify(datosCliente) + "}",
            dataType: "json",
            success: function (data) {
                control = true;
            },
            complete: function (data) {
                if (control) {
                    $('#autoCompletSeguro').val('');
                    LimpiaCamposBeneficiario();
                    LimpiarConyuge();
                    LimpiarCreacionRapidaCliente();
                    PresentacionSecciones(true);

                    datosCliente = data.responseJSON.d
                    if (datosCliente != undefined) {
                        if (!datosCliente.Resultado.Error) {
                            CargarDatosClienteEnPantalla(datosCliente, 'Cliente');

                            $('#txtCodigoOficina').val()
                            if (EstaVacio($('#txtPrimerNombre').val()) ||
                               EstaVacio($('#txtPrimerApellido').val()) ||
                               EstaVacio($('#txtFechaNacimiento').val()) ||
                               EstaVacio($('#txtNacionalidad').val()) ||
                               EstaVacio($('#txtGenero').val()) ||
                               EstaVacio($('#txtDireccion').val()) ||
                               EstaVacio($('#txtCiudadResidencia').val()) ||
                               EstaVacio($('#txtCiudadNacimiento').val()) ||
                               EstaVacio($('#txtTelefono').val())) {
                                var mensaje = "Existen Datos que debe completar en COBIS para seguir con la venta que son obligatorios, son: <br>";

                                if (EstaVacio($('#txtPrimerNombre').val())) {
                                    mensaje += "*Primer Nombre <br>";
                                }

                                if (EstaVacio($('#txtPrimerApellido').val())) {
                                    mensaje += "*Primer Apellido <br>";
                                }

                                if (EstaVacio($('#txtFechaNacimiento').val())) {
                                    mensaje += "*Fecha de Nacimiento <br>";
                                }

                                if (EstaVacio($('#txtNacionalidad').val())) {
                                    mensaje += "*Nacionalidad <br>";
                                }

                                if (EstaVacio($('#txtGenero').val())) {
                                    mensaje += "*Genero <br>";
                                }

                                if (EstaVacio($('#txtDireccion').val())) {
                                    mensaje += "*Dirección <br>";
                                }

                                if (EstaVacio($('#txtCiudadResidencia').val())) {
                                    mensaje += "*Ciudad de Residencia <br>";
                                }

                                if (EstaVacio($('#txtCiudadNacimiento').val())) {
                                    mensaje += "*Ciudad de Nacimiento <br>";
                                }

                                if (EstaVacio($('#txtTelefono').val())) {
                                    mensaje += "*Telefono <br>";
                                }

                                MostrarMensajeGenerico(2, mensaje);
                            } else {
                                ConsultarLosSegurosAVender();
                            }
                        } else {
                            LimpiarCamposPagina();
                            MostrarMensajeGenerico(datosCliente.Resultado.IdTipoMensaje, datosCliente.Resultado.Mensaje);
                        }
                    } else {
                        LimpiarCamposPagina();
                        MostrarMensajeGenerico(2, 'No existe cliente actualice la información');
                    }
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

function CargarDatosClienteEnPantalla(datosCliente, TipoCliente) {
    if (TipoCliente === 'Cliente') {
        $('#txtPrimerNombre').val(datosCliente.PrimerNombre);
        $('#txtSegundoNombre').val(datosCliente.SegundoNombre);
        $('#txtPrimerApellido').val(datosCliente.PrimerApellido);
        $('#txtSegundoApellido').val(datosCliente.SegundoApellido);
        var fecha = new Date(parseInt(datosCliente.FechaNacimiento.substr(6), 0));
        $('#txtFechaNacimiento').val(ConvertJsonToDate(fecha));
        $('#txtNacionalidad').val(datosCliente.Nacionalidad);
        $('#txtGenero').val(datosCliente.Genero);
        $('#txtDireccion').val(datosCliente.Direccion);
        $('#txtCiudadResidencia').val(datosCliente.CiudadResidencia);
        $('#txtCiudadNacimiento').val(datosCliente.CiudadNacimiento);
        if (datosCliente.Telefono != null) {
            $('#divCelular').val('N');
            $('#txtTelefono').val(datosCliente.Telefono);
        }
        else {
            $('#divCelular').val('S');
            $('#txtTelefono').val(datosCliente.Celular);
        }
        $('#divCelularValor').val(datosCliente.Celular);
        $('#txtCorreoElectronico').val(datosCliente.CorreoElectronico);
        $('#divActividadEco').val(datosCliente.ActividadEconomica);
        $('#divDepartamentoResidencia').val(datosCliente.DepartamentoResidencia);
        $('#divCodigoDANE').val(datosCliente.CodigoDANE);
    } else {
        if (datosCliente.FechaNacimiento != null) {
            fecha = new Date(parseInt(datosCliente.FechaNacimiento.substr(6), 0));
            if (ValidarFechaConyuge(fecha)) {
                $('#txtFechaNacimientoConyuge').val(ConvertJsonToDate(fecha));
                $('#txtGeneroConyuge').val(datosCliente.Genero);
                $('#txtPrimerNombreConyuge').val(datosCliente.PrimerNombre);
                $('#txtSegundoNombreConyuge').val(datosCliente.SegundoNombre);
                $('#txtPrimerApellidoConyuge').val(datosCliente.PrimerApellido);
                $('#txtSegundoApellidoConyuge').val(datosCliente.SegundoApellido);
                document.getElementById("btnCreacion").disabled = true;
            }
        }
    }
}

function BuscarConyuge() {
    ValidaDivConyuge();
    var Resultado = $('#div-Conyuge').parsley().validate();
    if (Resultado) {
        IniciarPrecargaBancaSeguros();
        var datosCliente = {};
        datosCliente = LlenarEntidadCliente('BuscarConyuge');
        var control = false
        if (datosCliente != null) {
            IniciarPrecargaBancaSeguros();
            $.ajax({
                type: "POST",
                cache: false,
                async: true,
                contentType: "application/json; charset=utf-8",
                url: "RegistrarVenta.aspx/BuscarCliente",
                data: "{cliente:" + JSON.stringify(datosCliente) + "}",
                dataType: "json",
                success: function (data) {
                    control = true;
                },
                complete: function (data) {
                    if (control) {
                        datosCliente = data.responseJSON.d;
                        if (datosCliente != null && datosCliente != undefined) {
                            if (!datosCliente.Resultado.Error) {
                                if (EstaVacio(datosCliente.PrimerNombre) ||
                               EstaVacio(datosCliente.PrimerApellido) ||
                               EstaVacio(datosCliente.FechaNacimiento) ||
                               EstaVacio(datosCliente.Genero)) {
                                    var mensaje = "Existen Datos que debe completar en COBIS para seguir con la venta que son obligatorios, son: <br>";

                                    if (EstaVacio(datosCliente.PrimerNombre)) {
                                        mensaje += "*Primer Nombre <br>";
                                    }

                                    if (EstaVacio(datosCliente.PrimerApellido)) {
                                        mensaje += "*Primer Apellido <br>";
                                    }

                                    if (EstaVacio(datosCliente.FechaNacimiento)) {
                                        mensaje += "*Fecha de Nacimiento <br>";
                                    }

                                    if (EstaVacio(datosCliente.Genero)) {
                                        mensaje += "*Genero <br>";
                                    }

                                    MostrarMensajeGenerico(2, mensaje);
                                } else {
                                    CargarDatosClienteEnPantalla(datosCliente, 'Conyuge');
                                }
                            } else {
                                if (datosCliente.Resultado.Mensaje.indexOf("CB-CLI001") >= 0) {
                                    $('#txtPrimerNombreClienteNuevo').val('');
                                    $('#txtSegundoNombreClienteNuevo').val('');
                                    $('#txtPrimerApellidoClienteNuevo').val('');
                                    $('#txtSegundoApellidoClienteNuevo').val('');
                                    $('#ddlSexoClienteNuevo').val(1);
                                    $('#txtFechaNacimientoClienteNuevo').val('');
                                    $('#txtPrimerNombreConyuge').val('');
                                    $('#txtSegundoNombreConyuge').val('');
                                    $('#txtPrimerApellidoConyuge').val('');
                                    $('#txtSegundoApellidoConyuge').val('');
                                    $('#txtFechaNacimientoConyuge').val('');
                                    $('#txtGeneroConyuge').val('');
                                    MostrarMensajeGenerico(datosCliente.Resultado.IdTipoMensaje, datosCliente.Resultado.Mensaje);
                                }
                                else {
                                    $('#btnCreacion').removeAttr('disabled', 'disabled');
                                    $('#ddlTipoIdentificacionClienteNuevo').val($('#ddlTipoIdentificacionConyuge').val());
                                    $('#txtNoIdentificacionClienteNuevo').val($('#txtNoIdentificacionConyuge').val());
                                    $('#ddlTipoIdentificacionClienteNuevo').attr('disabled', 'disabled');
                                    $('#txtNoIdentificacionClienteNuevo').attr('disabled', 'disabled');
                                    $('#txtPrimerNombreClienteNuevo').val('');
                                    $('#txtSegundoNombreClienteNuevo').val('');
                                    $('#txtPrimerApellidoClienteNuevo').val('');
                                    $('#txtSegundoApellidoClienteNuevo').val('');
                                    $('#ddlSexoClienteNuevo').val(1);
                                    $('#txtFechaNacimientoClienteNuevo').val('');
                                    $('#txtPrimerNombreConyuge').val('');
                                    $('#txtSegundoNombreConyuge').val('');
                                    $('#txtPrimerApellidoConyuge').val('');
                                    $('#txtSegundoApellidoConyuge').val('');
                                    $('#txtFechaNacimientoConyuge').val('');
                                    $('#txtGeneroConyuge').val('');
                                    $('#ddlTipoIdentificacionConyuge').attr('disabled', 'disabled');
                                    $('#txtNoIdentificacionConyuge').attr('disabled', 'disabled');
                                    $('#btnBuscarConyuge').attr('disabled', 'disabled');
                                    MostrarMensajeGenerico(datosCliente.Resultado.IdTipoMensaje, datosCliente.Resultado.Mensaje);
                                }
                            }
                        }
                        else {
                            document.getElementById("btnCreacion").disabled = false;
                            MostrarMensajeGenerico(2, 'No existe cliente actualice la información o cree nuevamente el cónyuge');
                        }
                    } else {
                        document.getElementById("btnCreacion").disabled = false;
                    }

                    DetenerPrecargaBancaSeguros();
                },
                error: function (data) {
                    var errorMessage = data.responseText;
                    MostrarMensajeGenerico(3, errorMessage);
                    DetenerPrecargaBancaSeguros();
                }
            });
        } else {
            MostrarMensajeGenerico(2, 'El conyuge no puede ser igual al cliente');
            DetenerPrecargaBancaSeguros();
        }
    }
}

function LimpiarCliente() {
    $('#txtPrimerNombre').val('');
    $('#txtSegundoNombre').val('');
    $('#txtPrimerApellido').val('');
    $('#txtSegundoApellido').val('');
    $('#txtFechaNacimiento').val('');
    $('#txtCiudadNacimiento').val('');
    $('#txtNacionalidad').val('');
    $('#txtGenero').val('');
    $('#txtDireccion').val('');
    $('#txtCiudadResidencia').val('');
    $('#txtTelefono').val('');
    $('#txtCorreoElectronico').val('');
}

function LimpiarConyuge() {
    $('#txtPrimerNombreConyuge').val('');
    $('#txtSegundoNombreConyuge').val('');
    $('#txtPrimerApellidoConyuge').val('');
    $('#txtSegundoApellidoConyuge').val('');
    $('#txtFechaNacimientoConyuge').val('');
    $('#txtNoIdentificacionConyuge').val('');
    $('#ddlTipoIdentificacionConyuge').val(1);
    $('#txtGeneroConyuge').val('');
    $('#ddlTipoIdentificacionConyuge').removeAttr('disabled', 'disabled');
    $('#txtNoIdentificacionConyuge').removeAttr('disabled', 'disabled');
    $('#btnCreacion').attr('disabled', 'disabled');
    $('#btnBuscarConyuge').removeAttr('disabled', 'disabled');
    $('#ddlTipoIdentificacionClienteNuevo').val(1);
    $('#txtNoIdentificacionClienteNuevo').val('');
    $('#ddlTipoIdentificacionClienteNuevo').removeAttr('disabled', 'disabled');
    $('#txtNoIdentificacionClienteNuevo').removeAttr('disabled', 'disabled');

    LimpiarCreacionRapidaCliente();
}

function LimpiarCreacionRapidaCliente() {
    $('#txtPrimerNombreClienteNuevo').val('');
    $('#txtSegundoNombreClienteNuevo').val('');
    $('#txtPrimerApellidoClienteNuevo').val('');
    $('#txtSegundoApellidoClienteNuevo').val('');
    $('#ddlSexoClienteNuevo').val(1);
    $('#txtFechaNacimientoClienteNuevo').val('');
}

function GuardarConyuge() {
    ValidaDivCreacionRapidaClientes();
    var Resultado = $('#div-CreacionRapidaClientes').parsley().validate();
    if (Resultado) {
        var Cliente = {};
        Cliente = LlenarEntidadCliente('LlenarConyuge');
        var edad = CalcularEdad(Cliente.FechaNacimiento);
        if (window._SeguroSeleccionado != undefined && edad <= window._SeguroSeleccionado[0].EdadMaximaConyuge && edad >= window._SeguroSeleccionado[0].EdadMinimaConyuge) {
            var creado = CreacionRapidaCliente(Cliente);

            if (creado.Error) {
                MostrarMensajeGenerico(2, 'No se ha podido crear el cliente por: <br>' + creado.Mensaje);
            }
            else {
                LimpiarCreacionRapidaCliente();
                $('#CreacionRapidadClientes').modal('hide');
                MostrarMensajeGenerico(1, 'Cliente creado satisfactoriamente');
                $('#btnBuscarConyuge').removeAttr('disabled', 'disabled');
                $('#btnCreacion').attr('disabled', 'disabled');
                CargarDatosDelConyuge(Cliente);
            }
        }
        else {
            MostrarMensajeGenerico(2, "El conyuge no esta entre la edad parametrizada para el seguro(" + window._SeguroSeleccionado[0].EdadMinimaConyuge + " años a " + window._SeguroSeleccionado[0].EdadMaximaConyuge + " años" + "), no se puede crear")
        }
    }
}

function CreacionRapidaCliente(Cliente) {
    var creado = {};
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "RegistrarVenta.aspx/CreacionRapidaCliente",
        data: "{cliente:" + JSON.stringify(Cliente) + "}",
        dataType: "json",
        success: function (data) {
            creado = data.d;
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage);
            DetenerPrecargaBancaSeguros();
        }
    });

    return creado;
}

function ValidarFechaConyuge(fechaNacimiento) {
    var edad = CalcularEdad(fechaNacimiento);
    var edadMaxima = $('#hdnEdadMaximaConyugueSeguro').val();
    var edadMinima = $('#hdnEdadMinimaConyugueSeguro').val();

    if (edad >= parseInt(edadMinima, 0) && edad <= parseInt(edadMaxima, 0)) {
        return true;
    }
    MostrarMensajeGenerico(2, "El conyuge no esta entre la edad parametrizada para el seguro(" + window._SeguroSeleccionado[0].EdadMinimaConyuge + " años a " + window._SeguroSeleccionado[0].EdadMaximaConyuge + " años" + ")")
    return false;
}

function CargarDatosDelConyuge(datosCliente) {
    $('#txtPrimerNombreConyuge').val(datosCliente.PrimerNombre);
    $('#txtSegundoNombreConyuge').val(datosCliente.SegundoNombre);
    $('#txtPrimerApellidoConyuge').val(datosCliente.PrimerApellido);
    $('#txtSegundoApellidoConyuge').val(datosCliente.SegundoApellido);

    if (datosCliente.FechaNacimiento != null) {
        $('#txtFechaNacimientoConyuge').val(ConvertJsonToDate(datosCliente.FechaNacimiento));
        $('#txtGeneroConyuge').val(datosCliente.Genero);
        ValidarFechaConyuge(datosCliente.FechaNacimiento);
    }
}

function ConsultarLosSegurosAVender() {
    var idTipoDeIdentificacion = $('#ddlTipoIdentificacion').val();
    var fechaDeNacimientoCliente = moment($('#txtFechaNacimiento').val(), "DD/MM/YYYY");

    var genero = $.map(window._Genero, function (value, key) {
        if (value.Nombre.substring(0, 2) === ($('#txtGenero').val()).substr(0, 2)) {
            return value;
        }
    })[0];

    if (genero != undefined) {
        $.ajax({
            type: "POST",
            cache: false,
            async: false,
            contentType: "application/json; charset=utf-8",
            url: "RegistrarVenta.aspx/ConsultarLosSegurosAVender",
            data: "{'idTipoDeIdentificacion':'" + idTipoDeIdentificacion + "','fechaDeNacimientoCliente':'" + fechaDeNacimientoCliente.toJSON() + "','genero':'" + genero.IdGenero + "'}",
            dataType: "json",
            success: function (data) {
                window._SegurosCargados = data.d;
            },
            error: function (data) {
                var errorMessage = data.responseText;
                MostrarMensajeGenerico(3, errorMessage);
                DetenerPrecargaBancaSeguros();
            }
        });

        if (window._SegurosCargados != undefined) {
            if (window._SegurosCargados.length > 0) {
                CargarAutoComplet(window._SegurosCargados);
                DeshabilitarDivYContenido("panelSeguro", false);
            }
            else {
                MostrarMensajeGenerico(2, "El cliente no cumple con las condiciones de la póliza");
            }
        } else {
            MostrarMensajeGenerico(3, "Error cargando los Seguros")
        }
    } else {
        MostrarMensajeGenerico(3, "Error cargando los Seguros")
    }
}

function CargarAutoComplet(data) {
    SegurosAVender = data
    var array = [];

    for (var i = 0; i < data.length; i++) {
        array.push(data[i].Codigo + " - " + data[i].Nombre + " - " + data[i].Aseguradora.Nombre);
    }

    $("#autoCompletSeguro").autocomplete({
        source: array
    });
}

function ConsultarPlanes() {
    ValidaDivSeguro();
    var Resultado = $('#div-Seguro').parsley().validate();

    if (Resultado) {
        var SeguroSeleccionado = $('#autoCompletSeguro').val().split(' - ')[0];

        window._SeguroSeleccionado = Enumerable.From(window._SegurosCargados)
            .Where(function (x) { return x.Codigo == SeguroSeleccionado })
            .Select()
            .ToArray();

        if (_SeguroSeleccionado.length > 0) {
                $('#hdnEdadMaximaConyugueSeguro').val(window._SeguroSeleccionado[0].EdadMaximaConyuge);
                $('#hdnEdadMinimaConyugueSeguro').val(window._SeguroSeleccionado[0].EdadMinimaConyuge);
                var planes = ConsultarPlanesPorIdSeguro(window._SeguroSeleccionado[0].IdSeguro);
                    $.jStorage.set('maximosBeneficiarios', window._SeguroSeleccionado[0].MaximoBeneficiarios);
        }
    }
}
function ConsultarPlanesPorIdSeguro(idSeguro) {
    var planes;
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "RegistrarVenta.aspx/ConsultarPlanesPorIdSeguro",
        data: "{'idSeguro':'" + idSeguro + "'}",
        dataType: "json",
        success: function (data) {
            planes = data.d;
        },
        complete: function (data) {
            CargarGrillaPlanes(planes);
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage);
            DetenerPrecargaBancaSeguros();
        }
    });
}

function CargarGrillaPlanes(planes) {
    var result = planes;
    oSettings = oTablePlanes.fnSettings();
    oTablePlanes.fnClearTable(this);
    var auto;
    var est;
    for (var i = 0; i < result.length; i++) {
        FilaPlanes = {
            IdPlan: result[i].IdPlan,
            CodigoConvenio: result[i].CodigoConvenio,
            CodigoPlan: result[i].CodigoPlan,
            NombrePlan: result[i].NombrePlan,
            Periodicidad: result[i].NombrePeriodicidad,
            ValorMoneda: result[i].ValorMoneda,
            Acciones: '<input id="rbSeleccionPlan' + i + '" type="radio" name="rbSeleccionPlan" onclick="rdplanesclick=true"/>'
        }

        oTablePlanes.oApi._fnAddData(oSettings, FilaPlanes);
    }

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTablePlanes.fnDraw();
    OcultarPanel("panelPlanes", false);
}

function CargarProductos(DatosFilas) {
    IniciarPrecargaBancaSeguros();
    ConsultarProductosBancarios(DatosFilas);
}

function ConsultarProductosBancarios(DatosPlan) {
    var datosCliente = {};
    datosCliente = LlenarEntidadCliente('BuscarCliente');
    var productosBancarios;

    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "RegistrarVenta.aspx/ConsultarProductosBancarios",
        data: "{cliente:" + JSON.stringify(datosCliente) + "}",
        dataType: "json",
        success: function (data) {
            productosBancarios = data.d;
        },
        complete: function (data) {
            if (productosBancarios == null || productosBancarios == undefined) {
                MostrarMensajeGenerico(3, "No carga productos bancarios");
                DetenerPrecargaBancaSeguros();
            }
            else {
                if (productosBancarios.length > 0) {
                    if (window._SeguroSeleccionado != undefined) {
                        productosBancarios = ConsultarProductosNoPermitidosPorSeguro(window._SeguroSeleccionado[0].IdSeguro, productosBancarios);
                    }
                    var valor = parseFloat(DatosPlan.ValorMoneda.replace(/[. $]/g, ''));
                    for (var i = 0; i < productosBancarios.length; i++) {
                        if (valor > productosBancarios[i].Saldo) {
                            productosBancarios.splice(i, 1);
                            i = -1;
                        }
                    }

                    if (productosBancarios.length > 0) {
                        CargarGrillaProductosBancarios(productosBancarios);
                        OcultarPanel("panelPestanas", false);
                        ManejoDePestañas();
                        CargarVariablesProducto();
                    } else {
                        MostrarMensajeGenerico(1, "Ningun producto del cliente permitido para la venta")
                    }
                }
                else {
                    MostrarMensajeGenerico(1, "Cliente sin productos que cumplan  con las condiciones de venta. Valide los productos bancarios en COBIS");
                    DetenerPrecargaBancaSeguros();
                }
            }
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage);
            DetenerPrecargaBancaSeguros();
        }
    });
}

function ConsultarProductosNoPermitidosPorSeguro(IdSeguro, productosBancarios) {
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "RegistrarVenta.aspx/ConsultarProductosNoPermitidosPorSeguro",
        data: "{idSeguro:" + IdSeguro + "}",
        dataType: "json",
        success: function (data) {
            var Productos = data.d;
            var numeroProductos = productosBancarios.length;
            var contador = 0;

            while (contador < numeroProductos) {
                for (var x = 0; x < Productos.length; x++) {
                    if (Productos[x].Producto.Codigo.toString() == productosBancarios[contador].CodigoProducto &&
                        Productos[x].SubProducto.Codigo.toString() == productosBancarios[contador].CodigoSubProducto &&
                        $.trim(Productos[x].Categoria.Codigo) == productosBancarios[contador].CodigoCategoria) {
                        productosBancarios.splice(contador, 1);
                        numeroProductos--;
                        contador--;
                        break;
                    }
                }

                contador++;
            }
        },
        complete: function (data) {
            DetenerPrecargaBancaSeguros();
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage);
            DetenerPrecargaBancaSeguros();
        }
    });

    return productosBancarios;
}

function CargarGrillaProductosBancarios(productosBancarios) {
    var result = productosBancarios;

    oSettings = oTableProductosBancarios.fnSettings();
    oTableProductosBancarios.fnClearTable(this);
    var auto;
    var est;
    for (var i = 0; i < result.length; i++) {
        AddressRegistry = {
            CodigoProducto: result[i].CodigoProducto,
            CodigoSubProducto: result[i].CodigoSubProducto,
            CodigoCategoria: result[i].CodigoCategoria,
            NumeroCuenta: result[i].NumeroCuenta,
            NombreProducto: result[i].NombreProducto,
            SaldoFormatoMoneda: result[i].SaldoFormatoMoneda,
            Descripcion: result[i].Descripcion,
            Acciones: '<input id="rbSeleccionProductoBan' + i + '" type="radio" name="rbSeleccionProductoBan" onclick="rdprobanclick=true"/>'
        }
        oTableProductosBancarios.oApi._fnAddData(oSettings, AddressRegistry);
    }

    oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
    oTableProductosBancarios.fnDraw();
}

function ValidacionDeParametros(DatosFila) {
    var Cliente = {};
    var ProductoBancario = {};

    Cliente = LlenarEntidadCliente('LlenarCliente');

    ProductoBancario.CodigoProducto = DatosFila.CodigoProducto;
    ProductoBancario.NumeroCuenta = DatosFila.NumeroCuenta;
    Cliente.ProductoBancario = ProductoBancario;
    Cliente.NumeroMaximoSegurosPorCliente = window._SeguroSeleccionado[0].NumeroMaximoSegurosPorCliente;
    Cliente.NumeroMaximoVentaSegurosPorCuentaCliente = window._SeguroSeleccionado[0].NumeroMaximoVentaSegurosPorCuentaCliente;
    Cliente.CodigoSeguro = $('#autoCompletSeguro').val().split(' - ')[0];
    ConsultarRestriccionVenta(Cliente);
}

function ConsultarRestriccionVenta(Cliente) {
    IniciarPrecargaBancaSeguros();
    var resultado;
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "RegistrarVenta.aspx/ConsultarVentasCuentasPorCliente",
        data: "{cliente:" + JSON.stringify(Cliente) + "}",
        dataType: "json",
        success: function (data) {
            resultado = data.d;
        },
        complete: function (data) {
            if (resultado != null) {
                if (resultado.Error) {
                    var oTable = $('#gvProductosBancarios').dataTable();
                    for (var i = 0; i < oTable.fnGetNodes().length; i++) {
                        var DatosFilas = oTable.fnGetData(i);
                        var inputRb = '#rbSeleccionProductoBan' + i;
                        if ($(inputRb).is(':checked')) {
                            $(inputRb).prop("checked", false);
                        }
                    }

                    MostrarMensajeGenerico(resultado.IdTipoMensaje, resultado.Mensaje);
                }
            } else {
                MostrarMensajeGenerico(3, errorMessage);
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

function ConsultarOficinaPorCodigo() {
    ValidaDivConsultaOficina();
    var resultado = $('#div-ConsultaOficina').parsley().validate();

    if (resultado) {
        var idOficina;

        if (EstaVacio($('#txtCodigoOficina').val())) {
            MostrarMensajeGenerico(2, "Es necesario el codigo de la oficina");
            $('#txtNombreOficina').val('');
            return null;
        }

        idOficina = $('#txtCodigoOficina').val();

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "RegistrarVenta.aspx/ConsultarOficinaPorCodigo",
            data: "{'idOficina':'" + idOficina + "'}",
            dataType: "json",
            success: function (data) {
                var Oficina = data.d;

                if (Oficina.IdOficina == 0) {
                    MostrarMensajeGenerico(2, 'La oficina no se encuentra registrada');
                    $('#txtNombreOficina').val('');
                }
                else {
                    $('#txtNombreOficina').val(Oficina.Nombre);
                }
            },
            error: function (data) {
                var errorMessage = data.responseText;
                MostrarMensajeGenerico(3, errorMessage);
                DetenerPrecargaBancaSeguros();
            }
        });
    }
}

function ObtenerDatosAsesor() {
    var datosAsesor = {};
    datosAsesor = LlenarDatosAsesor();
    if (datosAsesor != null) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "RegistrarVenta.aspx/ConsultarDatosAsesor",
            data: "{asesor:" + JSON.stringify(datosAsesor) + "}",
            dataType: "json",
            success: function (data) {
                if (EstaVacio(data.d.IdAsesor)) {
                    MostrarMensajeGenerico(2, 'El Asesor no se encuentra registrado')
                    $('#txtCodigoOficina').val('');
                    $('#txtNombreOficina').val('');
                    $('#txtUsuarioAsesor').val('');
                    $('#txtNoIdentificacionAsesor').val('');
                    $('#txtNombreAsesor').val('');
                }
                else {
                    $('#txtCodigoOficina').val(data.d.Oficina.IdOficina);
                    $('#txtNombreOficina').val(data.d.Oficina.Nombre);
                    $('#txtUsuarioAsesor').val(data.d.IdAsesor);
                    $('#txtNoIdentificacionAsesor').val(data.d.Identificacion);
                    $('#txtNombreAsesor').val(data.d.Nombre);
                }
            },
            error: function (data) {
                var errorMessage = data.responseText;
                MostrarMensajeGenerico(3, errorMessage);
                DetenerPrecargaBancaSeguros();
            }
        });
    }
}

function LlenarDatosAsesor() {
    var asesor = {};
    if (EstaVacio($.trim($('#txtUsuarioAsesor').val())) && EstaVacio($('#txtNoIdentificacionAsesor').val())) {
        MostrarMensajeGenerico(2, "El usuario o la identificación son requeridos");
        $('#txtCodigoOficina').val('');
        $('#txtNombreOficina').val('');
        $('#txtUsuarioAsesor').val('');
        $('#txtNoIdentificacionAsesor').val('');
        $('#txtNombreAsesor').val('');
        return null;
    }
    asesor.idAsesor = $.trim($('#txtUsuarioAsesor').val());
    asesor.idOficina = -1;
    if ($.isNumeric($('#txtNoIdentificacionAsesor').val())) {
        asesor.identificacion = $('#txtNoIdentificacionAsesor').val();
    }
    else {
        asesor.identificacion = -1;
    }

    asesor.nombre = '';
    asesor.Oficina = null;
    return asesor;
}

function CargarDatosAsesorLogueado() {
    var IdUsuario = $.jStorage.get('IdUsuario');
    var NombreUsuario = $.jStorage.get('NombreUsuario');
    var IdentificacionUsuario = $.jStorage.get('IdentificacionUsuario');
    var CodigoOficina = $.jStorage.get('CodigoOficina');
    var NombreOficina = $.jStorage.get('NombreOficina');

    $('#txtNoIdentificacionAsesor').val(IdentificacionUsuario);
    $('#txtUsuarioAsesor').val(IdUsuario);
    $('#txtNombreAsesor').val(NombreUsuario);

    if (CodigoOficina != undefined) {
        if (CodigoOficina !== 0) {
            $('#txtCodigoOficina').val(CodigoOficina);
            $('#txtNombreOficina').val(NombreOficina);
        }
    }
}
/*This comment has
more than one line*/
function RegistarVenta() {
    IniciarPrecargaBancaSeguros();
    var MensajesError = ValidaFormulario();
    if (MensajesError.length === 0) {
        var registrarVenta = {};
        registrarVenta = LlenarEntidadRegistrarVenta(registrarVenta);
        if (SregistrarVenta == null) {
            SregistrarVenta = registrarVenta;
            GenerarProcesoFinalDeLaVenta(registrarVenta);
        }
        else {
            if (oConsecutivo != null &&
                registrarVenta.IdPlan !== SregistrarVenta.IdPlan ||
                registrarVenta.Cliente.Identificacion !== SregistrarVenta.Cliente.Identificacion ||
                registrarVenta.Cliente.TipoIdentificacion.IdTipoIdentificacion !== SregistrarVenta.Cliente.TipoIdentificacion.IdTipoIdentificacion ||
                registrarVenta.ProductoBancario.CodigoCategoria !== SregistrarVenta.ProductoBancario.CodigoCategoria ||
                registrarVenta.ProductoBancario.CodigoProducto !== SregistrarVenta.ProductoBancario.CodigoProducto ||
                registrarVenta.ProductoBancario.CodigoSubProducto !== SregistrarVenta.ProductoBancario.CodigoSubProducto ||
                registrarVenta.ProductoBancario.NumeroCuenta !== SregistrarVenta.ProductoBancario.NumeroCuenta ||
                registrarVenta.CodigoConvenio !== SregistrarVenta.CodigoConvenio ||
                registrarVenta.Asesor.idAsesor !== SregistrarVenta.Asesor.idAsesor ||
                registrarVenta.Asesor.Oficina.IdOficina !== SregistrarVenta.Asesor.Oficina.IdOficina) {
                oConsecutivo = null;
                MostrarModalConfirmar(2, '¿Con los datos suministrados se intento realizar un recaudo que dio error en Cobis Desea Continuar?', 'GenerarProcesoFinalDeLaVenta()', 'DetenerPrecargaBancaSeguros()');
                //GenerarProcesoFinalDeLaVenta(registrarVenta);
            }           
        }
    }
    else {
        MostrarMensajeGenerico(2, MensajesError);
        DetenerPrecargaBancaSeguros();
    }
}

function GenerarProcesoFinalDeLaVenta(registrarVenta) {
    if (registrarVenta == undefined) {
        var registrarVenta = {};
        registrarVenta = LlenarEntidadRegistrarVenta(registrarVenta);
    }
    var control;
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "RegistrarVenta.aspx/GenerarProcesoFinalDeLaVenta",
        data: "{registrarVenta:" + JSON.stringify(registrarVenta) + "}",
        dataType: "json",
        success: function (data) {
            control = data.d.Resultado.Error;
        },
        complete: function (data) {
            if (!control) {
                ObtenerDocumentoPoliza(data.responseJSON.d.Consecutivo, window._SeguroSeleccionado[0].IdSeguro, data.responseJSON.d.Resultado.Mensaje);
                LimpiarCamposPagina();
            } else {
                oConsecutivo = data.responseJSON.d.Consecutivo;
                DetenerPrecargaBancaSeguros();
                MostrarMensajeGenerico(3, data.responseJSON.d.Resultado.Mensaje);
            }
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage);
            DetenerPrecargaBancaSeguros();
        }
    });
}

function ObtenerDocumentoPoliza(consecutivoPoliza, idseguro, mensaje) {
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "RegistrarVenta.aspx/ObtenerDocumentoVentaPoliza",
        data: "{consecutivoPoliza:" + consecutivoPoliza + ", idSeguro:" + idseguro + "}",
        dataType: "json",
        success: function (data) {
            if (data.d.Resultado.Error) {
                MostrarMensajeGenerico(3, data.d.Resultado.Mensaje);
            }
            else {
                $("#toptitle").text(mensaje);
                $("#iframePDF").attr('src', data.d.RutaArchivo);
                $('#modPdf').modal('show');
            }
        },
        complete: function (data) {
            DetenerPrecargaBancaSeguros();
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage);
            DetenerPrecargaBancaSeguros();
        }
    });
}

function ImprimirPoliza() {
    LimpiarCamposPagina();
    var PDF = document.getElementById("iframePdf");
    PDF.focus();
    PDF.contentWindow.print();
}

function LlenarEntidadRegistrarVenta(registrarVenta) {
    var oTable = $('#gvPlanes').dataTable();
    var IdPlan = 0;
    var CodigoConvenio = 0;
    for (var i = 0; i < oTable.fnGetNodes().length; i++) {
        var DatosFilas = oTable.fnGetData(i);
        var inputRb = '#rbSeleccionPlan' + i;
        if ($(inputRb).is(':checked')) {
            IdPlan = DatosFilas.IdPlan;
            CodigoConvenio = DatosFilas.CodigoConvenio;
        }
    }
    registrarVenta.IdPlan = IdPlan;
    registrarVenta.CodigoConvenio = CodigoConvenio;
    registrarVenta.Cliente = LlenarEntidadCliente('LlenarCliente');
    registrarVenta.Asesor = LlenarEntidadAsesor();
    registrarVenta.Conyuge = LlenarEntidadConyuge();
    registrarVenta.Beneficiario = LlenarEntidadArrayBeneficiario();
    registrarVenta.ProductoBancario = LlenarEntidadProductoBancario();
    registrarVenta.VariablesVenta = LlenarEntidadArrayVariableVenta();
    registrarVenta.Consecutivo = oConsecutivo;
    return registrarVenta;
}

function GrillaSeleccionada(grilla, radio) {
    var fueselecionado = 0;
    var oTable = $(grilla).dataTable();
    for (var i = 0; i < oTable.fnGetNodes().length; i++) {
        var DatosFilas = oTable.fnGetData(i);
        var inputRb = radio + i;
        if ($(inputRb).is(':checked'))
            fueselecionado = 1;
    }
    return fueselecionado
}

function LlenarEntidadProductoBancario() {
    var Producto = {};
    var prima = ObtenerPrimaSeguro();

    var oTable = $('#gvProductosBancarios').dataTable();
    for (var i = 0; i < oTable.fnGetNodes().length; i++) {
        var DatosFilas = oTable.fnGetData(i);
        var inputRb = '#rbSeleccionProductoBan' + i;
        if ($(inputRb).is(':checked')) {
            Producto.CodigoProducto = DatosFilas.CodigoProducto;
            Producto.CodigoSubProducto = DatosFilas.CodigoSubProducto;
            Producto.CodigoCategoria = DatosFilas.CodigoCategoria;
            Producto.NumeroCuenta = DatosFilas.NumeroCuenta;
            Producto.NombreProducto = DatosFilas.NombreProducto;
            Producto.Saldo = prima;
            Producto.Descripcion = DatosFilas.Descripcion;
        }
    }

    return Producto;
}

function ObtenerPrimaSeguro() {
    var oTable = $('#gvPlanes').dataTable();
    for (var i = 0; i < oTable.fnGetNodes().length; i++) {
        var DatosFilas = oTable.fnGetData(i);
        var inputRb = '#rbSeleccionPlan' + i;
        if ($(inputRb).is(':checked')) {
            return parseFloat(DatosFilas.ValorMoneda.replace(/[. $]/g, ''));
        }
    }
    return 0;
}

function ValidaFormulario() {
    var mensajeerror = '';
    var clienteTipoId = $('#ddlTipoIdentificacion').val();
    var clientenumId = $('#txtNoIdentificacion').val();
    var seguro = $('#autoCompletSeguro').val();
    var filaGrillaPlan = GrillaSeleccionada('#gvPlanes', '#rbSeleccionPlan');
    var filaGrillaProductoBancario = GrillaSeleccionada('#gvProductosBancarios', '#rbSeleccionProductoBan');

    if ((clienteTipoId === '') && (clientenumId === '')) {
        mensajeerror = mensajeerror + '* Debe haber un cliente para poder registrar venta <br>';
    }
    if (seguro === '') {
        mensajeerror = mensajeerror + '* Debe escoger un seguro para poder registrar venta <br>';
    }
    if ((filaGrillaPlan == undefined) || (filaGrillaPlan === 0)) {
        mensajeerror = mensajeerror + '* Debe escoger un plan para poder registrar venta <br>';
    }

    if (window._SeguroSeleccionado != undefined) {
        if ((window._SeguroSeleccionado[0].Beneficiario) && (window._SeguroSeleccionado[0].Conyuge)) {
            mensajeerror = mensajeerror + ValidaBeneficiarioForm();
            mensajeerror = mensajeerror + ValidaConyugeForm();
        }
        if ((window._SeguroSeleccionado[0].Beneficiario) && (!window._SeguroSeleccionado[0].Conyuge)) {
            mensajeerror = mensajeerror + ValidaBeneficiarioForm();
        }
        if ((!window._SeguroSeleccionado[0].Beneficiario) && (window._SeguroSeleccionado[0].Conyuge)) {
            mensajeerror = mensajeerror + ValidaConyugeForm();
        }
    }
    else {
        mensajeerror = mensajeerror + '* Debe escoger un seguro para poder registrar venta  <br>';
    }

    if ((filaGrillaProductoBancario === undefined) || (filaGrillaProductoBancario === 0)) {
        mensajeerror = mensajeerror + '* Debe escoger un producto bancario para poder registrar venta <br>';
    }

    mensajeerror = mensajeerror + ValidaAsesorForm();

    var mensajeRestriccion = ConsultarRestriccionVentaForm();
    if (mensajeRestriccion != "")
        mensajeerror = mensajeerror + "* " + mensajeRestriccion + "<br>";

    return mensajeerror;
}

function ConsultarRestriccionVentaForm() {
    var DatosFila
    var oTable = $('#gvProductosBancarios').dataTable();
    for (var i = 0; i < oTable.fnGetNodes().length; i++) {
        var inputRb = '#rbSeleccionProductoBan' + i;
        if ($(inputRb).is(':checked'))
            DatosFila = oTable.fnGetData(i);
    }
    var Cliente = {};
    var ProductoBancario = {};
    if (DatosFila != undefined) {
        Cliente = LlenarEntidadCliente('LlenarCliente');
        ProductoBancario.CodigoProducto = DatosFila.CodigoProducto;
        ProductoBancario.NumeroCuenta = DatosFila.NumeroCuenta;
        Cliente.ProductoBancario = ProductoBancario;
        Cliente.NumeroMaximoSegurosPorCliente = window._SeguroSeleccionado[0].NumeroMaximoSegurosPorCliente;
        Cliente.NumeroMaximoVentaSegurosPorCuentaCliente = window._SeguroSeleccionado[0].NumeroMaximoVentaSegurosPorCuentaCliente;
        Cliente.CodigoSeguro = $('#autoCompletSeguro').val().split(' - ')[0];
        var resultado;
        $.ajax({
            type: "POST",
            cache: false,
            async: false,
            contentType: "application/json; charset=utf-8",
            url: "RegistrarVenta.aspx/ConsultarVentasCuentasPorCliente",
            data: "{cliente:" + JSON.stringify(Cliente) + "}",
            dataType: "json",
            success: function (data) {
                resultado = data.d;
            },
            error: function (data) {
                var errorMessage = data.responseText;
                MostrarMensajeGenerico(3, errorMessage);
                DetenerPrecargaBancaSeguros();
            }
        });
        return resultado.Mensaje;
    }
    else
        return "";
}

function ValidaBeneficiarioForm() {
    var messageBeneficiario = '';
    if ($('#RegistroBeneficiarios').is(':checked')) {
        messageBeneficiario = '';
    }
    else {
        if (oTableBeneficiarios.fnSettings().aoData.length === 0)
            messageBeneficiario = '* Debe registrar un beneficiario para poder registrar venta <br>';
        var re; var valor = 0;
        $('#GridBeneficiario .post').each(function () {
            if ($(this).html() !== "Porcentaje %") {
                re = $(this).html();
                valor += parseFloat(re)
            }
        });
        if (valor != 100)
            messageBeneficiario = messageBeneficiario + '* El porcentaje asignado a los beneficiarios está errado, debe ser 100 <br>';
    }

    return messageBeneficiario
}

function ValidaConyugeForm() {
    var mensajeconyugue = ''

    if (EstaVacio($('#txtPrimerNombreConyuge').val()) ||
                               EstaVacio($('#txtPrimerApellidoConyuge').val()) ||
                               EstaVacio($('#txtFechaNacimientoConyuge').val()) ||
                               EstaVacio($('#txtGeneroConyuge').val())) {
        mensajeconyugue = "* Existen Datos del Conyuge que debe completar en COBIS para seguir con la venta que son obligatorios, son: <br>";

        if (EstaVacio($('#txtPrimerNombreConyuge').val())) {
            mensajeconyugue += "* Primer Nombre <br>";
        }

        if (EstaVacio($('#txtPrimerApellidoConyuge').val())) {
            mensajeconyugue += "* Primer Apellido <br>";
        }

        if (EstaVacio($('#txtFechaNacimientoConyuge').val())) {
            mensajeconyugue += "* Fecha de Nacimiento <br>";
        }

        if (EstaVacio($('#txtGeneroConyuge').val())) {
            mensajeconyugue += "* Genero <br>";
        }
    } else {
        if ($('#txtFechaNacimientoConyuge').val().length !== 0) {
            var fecha = new Date(parseInt($('#txtFechaNacimientoConyuge').val(), 0));
            if (!ValidarFechaConyuge(fecha)) {
                mensajeconyugue += '* La edad del conyuge no cumple con los requerimientos <br>';
            }
        }
    }
    return mensajeconyugue
}

function ValidaAsesorForm() {
    var mensajeconyugue = ''

    if (EstaVacio($('#txtUsuarioAsesor').val()) ||
                               EstaVacio($('#txtNoIdentificacionAsesor').val()) ||
                               EstaVacio($('#txtNombreAsesor').val()) ||
                               EstaVacio($('#txtCodigoOficina').val())) {
        mensajeconyugue = "* Debe agregar un Asesor faltan los siguientes datos: <br>";

        if (EstaVacio($('#txtUsuarioAsesor').val())) {
            mensajeconyugue += "* Usuario Asesor <br>";
        }

        if (EstaVacio($('#txtNoIdentificacionAsesor').val())) {
            mensajeconyugue += "* Identificación Asesor <br>";
        }

        if (EstaVacio($('#txtNombreAsesor').val())) {
            mensajeconyugue += "* Nombre Asesor <br>";
        }

        if (EstaVacio($('#txtCodigoOficina').val())) {
            mensajeconyugue += "* Codigo Oficina <br>";
        } else if (EstaVacio($('#txtNombreOficina').val())) {
            mensajeconyugue += "* Codigo Oficina no valido  no ha realizado la consulta <br>";
        }
    }

    return mensajeconyugue
}

function LeerDatosBeneficiario() {
    var table = $('#GridBeneficiario').DataTable()
    var Indice = $('#txtIndice').val();
    if (Indice === "")
        Indice = table.fnGetData().length == 0 ? 0 : table.fnGetData().length;

    var dataBenf = {
        "Indice": parseInt(Indice, 0)
, "idTipoDocumento": ddlTipoIdentificacionBeneficiario.options[ddlTipoIdentificacionBeneficiario.selectedIndex].value
, "TipoDocBen": ddlTipoIdentificacionBeneficiario.options[ddlTipoIdentificacionBeneficiario.selectedIndex].text
, "NoIdentificacionBeneficiario": $('#txtNoIdentificacionBeneficiario').val()
, "primerNombre": $('#txtPrimerNombreBeneficiario').val()
, "segundoNombre": $('#txtSegundoNombreBeneficiario').val()
, "primerApellido": $('#txtPrimerApellidoBeneficiario').val()
, "segundoApellido": $('#txtSegundoApellidoBeneficiario').val()
, "idTipoparentesco": ddlParentescoBeneficiario.options[ddlParentescoBeneficiario.selectedIndex].value
, "parentesco": ddlParentescoBeneficiario.options[ddlParentescoBeneficiario.selectedIndex].text
, "porcentaje": $('#txtPorcentajeBeneficiario').val()
, "Options": '<img src=../Imagenes/edit.jpg width=20px height=20px onclick="imgbeneditclick=true" title="Actualizar Beneficiario">' +
                   '<img src=../Imagenes/delete.png width=20px height=20px onclick="imgbeneliclick=true" title="Eliminar Beneficiario">'
    }
    return dataBenf;
}

function DesactivaCamposBeneficiario() {
    LimpiaCamposBeneficiario();
    $('#ddlTipoIdentificacionBeneficiario').attr('disabled', 'disabled');
    $('#txtNoIdentificacionBeneficiario').attr('disabled', 'disabled');
    $('#txtPrimerNombreBeneficiario').attr('disabled', 'disabled');
    $('#txtSegundoNombreBeneficiario').attr('disabled', 'disabled');
    $('#txtPrimerApellidoBeneficiario').attr('disabled', 'disabled');
    $('#txtSegundoApellidoBeneficiario').attr('disabled', 'disabled');
    $('#ddlParentescoBeneficiario').attr('disabled', 'disabled');
    $('#txtPorcentajeBeneficiario').attr('disabled', 'disabled');
    $('input[name=btnAgrBen]').show();
    $('input[name=btnActBen]').hide();
    $('input[name=btnCanBen]').hide();
    $('input[name=btnAgrBen]').attr('disabled', 'disabled');
    $('li.parsley-required').hide();
    $('#txtPrimerNombreBeneficiario').removeClass('parsley-error');
    $('#txtPrimerApellidoBeneficiario').removeClass('parsley-error');
    $('#txtSegundoNombreBeneficiario').removeClass('parsley-error');
    $('#txtSegundoApellidoBeneficiario').removeClass('parsley-error');
    $('#ddlParentescoBeneficiario').removeClass('parsley-error');
    $('#txtPorcentajeBeneficiario').removeClass('parsley-error');
    $('#txtNoIdentificacionBeneficiario').removeClass('parsley-error');
    oTableBeneficiarios.fnClearTable(this);
}

function ActivaCamposBeneficiario() {
    if ($('#RegistroBeneficiarios').is(':checked')) {
        DesactivaCamposBeneficiario();
    }
    else {
        $("#ddlTipoIdentificacionBeneficiario").removeAttr('disabled');
        $("#txtNoIdentificacionBeneficiario").removeAttr('disabled');
        $('#txtPrimerNombreBeneficiario').removeAttr('disabled');
        $('#txtSegundoNombreBeneficiario').removeAttr('disabled');
        $('#txtPrimerApellidoBeneficiario').removeAttr('disabled');
        $('#txtSegundoApellidoBeneficiario').removeAttr('disabled');
        $('#ddlParentescoBeneficiario').removeAttr('disabled');
        $('#txtPorcentajeBeneficiario').removeAttr('disabled');
        $('input[name=btnAgrBen]').removeAttr('disabled');
    }
}

function AgregarBeneficiario() {
    ValidaDivRegistraBeneficiarios();
    var Resultado = $('#div-RegistraBeneficiarios').parsley().validate();
    if (Resultado) {
        var resultado = ValidaPorcentajeGrillaBeneficiario();
        var resultado2 = ValidaNumeroIdBeneficiario();
        var resultado3 = ValidaCantidadBeneficiario();
        if (resultado && resultado2 && resultado3) {
            oSettings = oTableBeneficiarios.fnSettings();
            oTableBeneficiarios.oApi._fnAddData(oSettings, LeerDatosBeneficiario());
            oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
            oTableBeneficiarios.fnDraw();
            LimpiaCamposBeneficiario();
        }
    }
    else {
        $('li.parsley-required').show();
    }
}

function ValidaPorcentajeGrillaBeneficiario() {
    var re;
    var valor = 0

    $('#GridBeneficiario .post').each(function () {
        if ($(this).html() !== "Porcentaje %") {
            re = $(this).html();
            valor += parseFloat(re)
        }
    });

    var Total = parseFloat($('#txtPorcentajeBeneficiario').val());
    var totalPorcentaje = Total + valor;
    if (totalPorcentaje > 100) {
        MostrarMensajeGenerico(2, 'El porcentaje no puede ser mayor a 100');
        return false;
    }
    else {
        return true;
    }
}

function ValidaNumeroIdBeneficiario() {
    var num;
    var tip;
    var valido = true;
    var numId = $('#txtNoIdentificacionBeneficiario').val();

    if (numId <= 0 && numId.trim() != "") {
        MostrarMensajeGenerico(2, 'El numero identificacion ' + numId + ' no es permitido');
        valido = false;
        return false;
    }

    var tipoId = ddlTipoIdentificacionBeneficiario.options[ddlTipoIdentificacionBeneficiario.selectedIndex].text
    if (numId === "") {
        numId = GenerarAleatorio();
        $('#txtNoIdentificacionBeneficiario').val(numId);
    }
    var Indice = $('#txtIndice').val()

    var oTable = $('#GridBeneficiario').dataTable();
    if (oTable.fnGetData().length > 0) {
        $.each(oTable.fnGetData(), function (i, row) {
            if (row.NoIdentificacionBeneficiario === numId &&
                row.TipoDocBen === tipoId &&
                row.Indice.toString() !== Indice) {
                MostrarMensajeGenerico(2, 'Ya existe un beneficiario con el mismo tipo y número de identificación');
                valido = false;
                return false;
            }
        });
    }
    if (valido) return true;
    else return false;
}

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function GenerarAleatorio() {
    var superior = 99;
    var inferior = 01;
    aleatorio = getRandomInt(inferior, superior);
    var oTable = $('#GridBeneficiario').dataTable();
    var control = false
    var contador = 0;
    var tipoId = ddlTipoIdentificacionBeneficiario.options[ddlTipoIdentificacionBeneficiario.selectedIndex].text
    while (!control) {
        if (oTable.fnGetData().length > 0) {
            $.each(oTable.fnGetData(), function (i, row) {
                if (row.NoIdentificacionBeneficiario == aleatorio &&
                    row.TipoDocBen === tipoId
                    ) {
                    GenerarAleatorio();
                }
            });
            control = true;
        }
        else
            control = true;
    }
    return aleatorio;
}

function ValidaCantidadBeneficiario() {
    var maximoBeneficiarios = $.jStorage.get('maximosBeneficiarios');
    var oTable = $('#GridBeneficiario').dataTable();
    var cantidadBeneficiarios = oTable.fnGetNodes().length;

    if (maximoBeneficiarios != undefined) {
        if (cantidadBeneficiarios > maximoBeneficiarios - 1) {
            MostrarMensajeGenerico(2, 'Excede el número máximo de beneficiarios permitidos ' + maximoBeneficiarios);
            return false;
        } else {
            return true;
        }
    } else {
        MostrarMensajeGenerico(3, 'No se puede leer el número máximo de beneficiarios');
    }
}

function CargarBeneficiario(DatosFilas) {
    $('input[name=btnAgrBen]').hide();
    $('input[name=btnActBen]').show();
    $('input[name=btnCanBen]').show();
    $('#txtNoIdentificacionBeneficiario').val(DatosFilas.NoIdentificacionBeneficiario);
    $('#txtPrimerNombreBeneficiario').val(DatosFilas.primerNombre);
    $('#txtSegundoNombreBeneficiario').val(DatosFilas.segundoNombre);
    $('#txtPrimerApellidoBeneficiario').val(DatosFilas.primerApellido);
    $('#txtSegundoApellidoBeneficiario').val(DatosFilas.segundoApellido);
    $('#txtPorcentajeBeneficiario').val(DatosFilas.porcentaje);
    $('#porcentajeAnterior').val(DatosFilas.porcentaje);
    $('#ddlTipoIdentificacionBeneficiario').val(DatosFilas.idTipoDocumento);
    $('#ddlParentescoBeneficiario').val(DatosFilas.idTipoparentesco);
    $('#txtIndice').val(DatosFilas.Indice);
}

function ActualizarBeneficiario() {
    ValidaDivRegistraBeneficiarios();
    var Resultado = $('#div-RegistraBeneficiarios').parsley().validate();
    if (Resultado) {
        var re;
        var valor = 0
        $('#GridBeneficiario .post').each(function () {
            if ($(this).html() != "Porcentaje %") {
                re = $(this).html();
                valor += parseFloat(re)
            }
        });
        var Total = parseFloat($('#txtPorcentajeBeneficiario').val());
        var totalGrilla = valor - parseFloat($('#porcentajeAnterior').val());
        totalPorcentaje = Total + totalGrilla;
        if (totalPorcentaje > 100) {
            MostrarMensajeGenerico(2, 'El porcentaje no puede ser mayor a 100');
        }
        else {
            var valida = ValidaNumeroIdBeneficiario();
            if (valida) {
                var oTable = $('#GridBeneficiario').dataTable();
                oTable.fnUpdate(LeerDatosBeneficiario(), indexBenf);
                $('input[name=btnAgrBen]').show();
                $('input[name=btnActBen]').hide();
                $('input[name=btnCanBen]').hide();
                LimpiaCamposBeneficiario();
            }
        }
    } else {
        $('li.parsley-required').show();
    }
}

function EliminarBeneficiario(index) {
    var oTable = $('#GridBeneficiario').dataTable();
    oTable.fnDeleteRow(index);

    var oTable = $('#GridBeneficiario').dataTable();
    if (oTable.fnGetData().length > 0) {
        $.each(oTable.fnGetData(), function (i, row) {
            row.Indice = i;
            oTable.fnUpdate(row, i);
        });
    }

    LimpiaCamposBeneficiario();
    $('input[name=btnAgrBen]').show();
    $('input[name=btnActBen]').hide();
    $('input[name=btnCanBen]').hide();
}

function LimpiaCamposBeneficiario() {
    $('#txtIndice').val('')
    $('#ddlTipoIdentificacionBeneficiario').val(1);
    $('#ddlParentescoBeneficiario').val(1);
    $('#txtNoIdentificacionBeneficiario').val('')
    $("#txtPrimerNombreBeneficiario").val('');
    $("#txtSegundoNombreBeneficiario").val('');
    $("#txtPrimerApellidoBeneficiario").val('');
    $("#txtSegundoApellidoBeneficiario").val('');
    $("#txtPorcentajeBeneficiario").val('');
    $('li.parsley-required').hide();
    $('#txtPrimerNombreBeneficiario').removeClass('parsley-error');
    $('#txtPrimerApellidoBeneficiario').removeClass('parsley-error');
    $('#txtSegundoNombreBeneficiario').removeClass('parsley-error');
    $('#txtSegundoApellidoBeneficiario').removeClass('parsley-error');
    $('#ddlParentescoBeneficiario').removeClass('parsley-error');
    $('#txtPorcentajeBeneficiario').removeClass('parsley-error');
    $('#txtNoIdentificacionBeneficiario').removeClass('parsley-error');
}

function CancelarBeneficiario() {
    $('#ddlTipoIdentificacionBeneficiario').val(1);
    $('#ddlParentescoBeneficiario').val(1);
    $('#txtNoIdentificacionBeneficiario').val('')
    $("#txtPrimerNombreBeneficiario").val('');
    $("#txtSegundoNombreBeneficiario").val('');
    $("#txtPrimerApellidoBeneficiario").val('');
    $("#txtSegundoApellidoBeneficiario").val('');
    $("#txtPorcentajeBeneficiario").val('');

    $('input[name=btnActBen]').hide();
    $('input[name=btnCanBen]').hide();
    $('input[name=btnAgrBen]').show();

    $('li.parsley-required').hide();
    $('#txtPrimerNombreBeneficiario').removeClass('parsley-error');
    $('#txtPrimerApellidoBeneficiario').removeClass('parsley-error');
    $('#txtSegundoNombreBeneficiario').removeClass('parsley-error');
    $('#txtSegundoApellidoBeneficiario').removeClass('parsley-error');
    $('#ddlParentescoBeneficiario').removeClass('parsley-error');
    $('#txtPorcentajeBeneficiario').removeClass('parsley-error');
    $('#txtNoIdentificacionBeneficiario').removeClass('parsley-error');
}

function LlenarCombo(data, dropDownList) {
    //$('#' + dropDownList).append($('<option>', { value: "0", text: 'Seleccione una opción' }));
    for (var i = 0; i < data.length; i++) {
        switch (dropDownList) {
            case 'ddlTipoIdentificacion':
                $('#' + dropDownList).append($('<option>', { value: data[i]["IdTipoIdentificacion"], text: data[i]["Nombre"] }));
                break;
            case 'ddlTipoIdentificacionClienteNuevo':
                $('#' + dropDownList).append($('<option>', { value: data[i]["IdTipoIdentificacion"], text: data[i]["Nombre"] }));
                break;
            case 'ddlTipoIdentificacionConyuge':
                $('#' + dropDownList).append($('<option>', { value: data[i]["IdTipoIdentificacion"], text: data[i]["Nombre"] }));
                break;
            case 'ddlTipoIdentificacionBeneficiario':
                $('#' + dropDownList).append($('<option>', { value: data[i]["IdTipoIdentificacion"], text: data[i]["Nombre"] }));
                break;
            case 'ddlSexoClienteNuevo':
                $('#' + dropDownList).append($('<option>', { value: data[i]["IdGenero"], text: data[i]["Nombre"] }));
                break;
            case 'ddlParentescoBeneficiario':
                $('#' + dropDownList).append($('<option>', { value: data[i]["IdParentesco"], text: data[i]["Nombre"] }));
                break;
        }
    }

    var optionA = $('#' + dropDownList).val();
}

function LlenarEntidadCliente(TipoAccion) {
    var Cliente = {};
    var TipoIdentifacionSeleccionado = {};

    if (TipoAccion === 'BuscarConyuge') {
        if ($("#ddlTipoIdentificacion").val() === $("#ddlTipoIdentificacionConyuge").val() && $("#txtNoIdentificacion").val() === $("#txtNoIdentificacionConyuge").val()) {
            Cliente = null;
        } else {
            Cliente.TipoIdentificacion = {};
            Cliente.TipoIdentificacion.IdTipoIdentificacion = $("#ddlTipoIdentificacionConyuge").val();
            TipoIdentifacionSeleccionado = Enumerable.From(window._TipoIdentificacion)
                .Where(function (x) { return x.IdTipoIdentificacion == Cliente.TipoIdentificacion.IdTipoIdentificacion })
                .Select()
                .ToArray();
            Cliente.TipoIdentificacion.Abreviatura = TipoIdentifacionSeleccionado[0].Abreviatura;
            Cliente.Identificacion = $("#txtNoIdentificacionConyuge").val();
            Cliente.EsNovedad = false;
            Cliente.TipoCliente = 2;
        }
    } else if (TipoAccion === 'LlenarConyuge') {
        Cliente.TipoIdentificacion = {};
        Cliente.TipoIdentificacion.IdTipoIdentificacion = $("#ddlTipoIdentificacionClienteNuevo").val();
        TipoIdentifacionSeleccionado = Enumerable.From(window._TipoIdentificacion)
            .Where(function (x) { return x.IdTipoIdentificacion == Cliente.TipoIdentificacion.IdTipoIdentificacion })
            .Select()
            .ToArray();
        Cliente.TipoIdentificacion.Abreviatura = TipoIdentifacionSeleccionado[0].Abreviatura;

        Cliente.Identificacion = $.trim($("#txtNoIdentificacionClienteNuevo").val());
        Cliente.PrimerNombre = $.trim($('#txtPrimerNombreClienteNuevo').val());
        Cliente.SegundoNombre = $.trim($('#txtSegundoNombreClienteNuevo').val());
        Cliente.PrimerApellido = $.trim($('#txtPrimerApellidoClienteNuevo').val());
        Cliente.SegundoApellido = $.trim($('#txtSegundoApellidoClienteNuevo').val());

        var genero = $.map(window._Genero, function (value, key) {
            if (value.IdGenero == $('#ddlSexoClienteNuevo').val()) {
                return value;
            }
        })[0];

        Cliente.Genero = genero.Nombre;
        Cliente.IdGenero = genero.IdGenero;
        var dia = $.trim($('#txtFechaNacimientoClienteNuevo').val()).substr(0, 2);
        var mes = $.trim($('#txtFechaNacimientoClienteNuevo').val()).substr(3, 2) - 1;
        var ano = $.trim($('#txtFechaNacimientoClienteNuevo').val()).substr(6, 4);
        var fechaNacimiento = new Date(ano, mes, dia);
        Cliente.FechaNacimiento = fechaNacimiento;

        Cliente.EsNovedad = false;
    } else if (TipoAccion === 'LlenarCliente') {
        Cliente.TipoIdentificacion = {};
        Cliente.TipoIdentificacion.IdTipoIdentificacion = $("#ddlTipoIdentificacion").val();
        TipoIdentifacionSeleccionado = Enumerable.From(window._TipoIdentificacion)
            .Where(function (x) { return x.IdTipoIdentificacion == Cliente.TipoIdentificacion.IdTipoIdentificacion })
            .Select()
            .ToArray();
        Cliente.TipoIdentificacion.Abreviatura = TipoIdentifacionSeleccionado[0].Abreviatura;

        Cliente.Identificacion = $("#txtNoIdentificacion").val();
        Cliente.PrimerNombre = $('#txtPrimerNombre').val();
        Cliente.SegundoNombre = $('#txtSegundoNombre').val();
        Cliente.PrimerApellido = $('#txtPrimerApellido').val();
        Cliente.SegundoApellido = $('#txtSegundoApellido').val();
        var diaF = $.trim($('#txtFechaNacimiento').val()).substr(0, 2);
        var mesF = $.trim($('#txtFechaNacimiento').val()).substr(3, 2) - 1;
        var anoF = $.trim($('#txtFechaNacimiento').val()).substr(6, 4);
        var fechaNacimientoF = new Date(anoF, mesF, diaF);
        Cliente.FechaNacimiento = fechaNacimientoF;

        Cliente.CiudadNacimiento = $('#txtCiudadNacimiento').val();
        Cliente.Nacionalidad = $('#txtNacionalidad').val();
        Cliente.Genero = $('#txtGenero').val();
        Cliente.Direccion = $('#txtDireccion').val();
        Cliente.DepartamentoResidencia = $("#divDepartamentoResidencia").val(); 
        if ($('#divCelular').val() === 'N') {
            Cliente.Telefono = $('#txtTelefono').val();
        }
        Cliente.Celular = $("#divCelularValor").val();
        Cliente.CodigoDANE = $("#divCodigoDANE").val(); 
        Cliente.ActividadEconomica = $("#divActividadEco").val();  
        Cliente.Correo = $('#txtCorreoElectronico').val();
        Cliente.EsNovedad = true;
    } else if (TipoAccion === 'BuscarCliente') {
        Cliente.TipoIdentificacion = {};
        Cliente.TipoIdentificacion.IdTipoIdentificacion = $("#ddlTipoIdentificacion").val();
        TipoIdentifacionSeleccionado = Enumerable.From(window._TipoIdentificacion)
            .Where(function (x) { return x.IdTipoIdentificacion == Cliente.TipoIdentificacion.IdTipoIdentificacion })
            .Select()
            .ToArray();
        Cliente.TipoIdentificacion.Abreviatura = TipoIdentifacionSeleccionado[0].Abreviatura;
        Cliente.Identificacion = $("#txtNoIdentificacion").val();
        Cliente.EsNovedad = true;
        Cliente.TipoCliente = 1;
    }

    return Cliente;
}

function LlenarEntidadAsesor() {
    var Asesor = {};
    var Oficina = {};
    Asesor.idAsesor = $.trim($('#txtUsuarioAsesor').val());
    Asesor.Identificacion = $('#txtNoIdentificacionAsesor').val();
    Asesor.Nombre = $('#txtNombreAsesor').val();
    Oficina.IdOficina = $('#txtCodigoOficina').val();
    Asesor.Oficina = Oficina;
    return Asesor;
}

function LlenarEntidadConyuge() {
    if (window._SeguroSeleccionado != undefined) {
        if (window._SeguroSeleccionado[0].Conyuge) {
            var Conyuge = {};
            Conyuge.IdTipoIdentificacion = ddlTipoIdentificacionConyuge.options[ddlTipoIdentificacionConyuge.selectedIndex].value;
            Conyuge.Identificacion = $('#txtNoIdentificacionConyuge').val();
            Conyuge.PrimerNombre = $('#txtPrimerNombreConyuge').val();
            Conyuge.SegundoNombre = $('#txtSegundoNombreConyuge').val();
            Conyuge.PrimerApellido = $('#txtPrimerApellidoConyuge').val();
            Conyuge.SegundoApellido = $('#txtSegundoApellidoConyuge').val();
            var diaF = $.trim($('#txtFechaNacimientoConyuge').val()).substr(0, 2);
            var mesF = $.trim($('#txtFechaNacimientoConyuge').val()).substr(3, 2) - 1;
            var anoF = $.trim($('#txtFechaNacimientoConyuge').val()).substr(6, 4);
            var fechaNacimientoF = new Date(anoF, mesF, diaF);
            Conyuge.FechaNacimiento = fechaNacimientoF;
            Conyuge.Genero = $('#txtGeneroConyuge').val();
            return Conyuge;
        } else
            return null;
    }
    else
        return null;
}

function LlenarEntidadArrayBeneficiario() {
    var ArrayBeneficiarios = [];
    if (window._SeguroSeleccionado != undefined) {
        if (window._SeguroSeleccionado[0].Beneficiario) {
            var oTable = $('#GridBeneficiario').dataTable();
            for (var i = 0; i < oTable.fnGetNodes().length; i++) {
                var DatosFilas = oTable.fnGetData(i);
                var Beneficiarios = {};
                Beneficiarios.IdTipoIdentificacion = DatosFilas.idTipoDocumento;
                Beneficiarios.Identificacion = DatosFilas.NoIdentificacionBeneficiario;
                Beneficiarios.Nombres = DatosFilas.primerNombre + ' ' + DatosFilas.segundoNombre;
                Beneficiarios.Apellidos = DatosFilas.primerApellido + ' ' + DatosFilas.segundoApellido;
                Beneficiarios.IdParentesco = DatosFilas.idTipoparentesco;
                Beneficiarios.Porcentaje = DatosFilas.porcentaje;
                ArrayBeneficiarios.push(Beneficiarios);
            }
            return ArrayBeneficiarios;
        } else
            return null;
    }
    return null;
}

function LimpiarCamposPagina() {
    $("#ddlTipoIdentificacion").val(1);
    $("#ddlTipoIdentificacion").val(1);
    $('#RegistroBeneficiarios').prop("checked", true);
    $('#txtNoIdentificacion').val('');
    $('#txtPrimerNombre').val('');
    $('#txtSegundoNombre').val('');
    $('#txtPrimerApellido').val('');
    $('#txtSegundoApellido').val('');
    $('#txtFechaNacimiento').val('');
    $('#txtCiudadNacimiento').val('');
    $('#txtNacionalidad').val('');
    $('#txtGenero').val('');
    $('#txtDireccion').val('');
    $('#txtCiudadResidencia').val('');
    $('#txtTelefono').val('');
    $('#txtCorreoElectronico').val('');
    $('#autoCompletSeguro').val('');
    $('#txtCodigoOficina').val('');
    $('#txtNombreOficina').val('');
    PresentacionSecciones(true);
    CargarDatosAsesorLogueado();
    LimpiaCamposBeneficiario();
    DesactivaCamposBeneficiario();
    oTableBeneficiarios.fnClearTable(this);
    oTablePlanes.fnClearTable(this);
    oTableProductosBancarios.fnClearTable(this);
    LimpiarConyuge();
    LimpiarCreacionRapidaCliente();
    oConsecutivo = null;
    SregistrarVenta = null;
}

function SalirPagina() {
    MostrarModalConfirmar(2, '¿Esta seguro que desea salir de la venta?', 'Inicio()', null);
}

function Inicio() {
    validNavigation = true;
    window.location.assign("../Inicio.aspx");
}

function ManejoDePestañas() {
    OcultarPanel("registrarBeneficiarios", !window._SeguroSeleccionado[0].Beneficiario);
    OcultarPanel("registrarInformaciónCónyuge", !window._SeguroSeleccionado[0].Conyuge);
    OcultarPanel("nombrePestañaBeneficiario", !window._SeguroSeleccionado[0].Beneficiario);
    OcultarPanel("nombrePestañaConyuge", !window._SeguroSeleccionado[0].Conyuge);
}

function ValidaDivRegistroVenta() {
    $.listen('parsley:field:validate', function () {
        validateFront();
    });
    var validateFront = function () {
        if ($('#div-registroVenta').parsley().isValid()) {
            $('.bs-callout-info').removeClass('hidden');
            $('.bs-callout-warning').addClass('hidden');
        } else {
            $('.bs-callout-info').addClass('hidden');
            $('.bs-callout-warning').removeClass('hidden');
        }
    };
}

function ValidaDivConsultaOficina() {
    $.listen('parsley:field:validate', function () {
        validateFront();
    });
    var validateFront = function () {
        if ($('#div-ConsultaOficina').parsley().isValid()) {
            $('.bs-callout-info').removeClass('hidden');
            $('.bs-callout-warning').addClass('hidden');
        } else {
            $('.bs-callout-info').addClass('hidden');
            $('.bs-callout-warning').removeClass('hidden');
        }
    };
}

function ValidaDivSeguro() {
    $.listen('parsley:field:validate', function () {
        validateFront();
    });
    var validateFront = function () {
        if ($('#div-Seguro').parsley().isValid()) {
            $('.bs-callout-info').removeClass('hidden');
            $('.bs-callout-warning').addClass('hidden');
        } else {
            $('.bs-callout-info').addClass('hidden');
            $('.bs-callout-warning').removeClass('hidden');
        }
    };
}

function ValidaDivConyuge() {
    $.listen('parsley:field:validate', function () {
        validateFront();
    });
    var validateFront = function () {
        if ($('#div-Conyuge').parsley().isValid()) {
            $('.bs-callout-info').removeClass('hidden');
            $('.bs-callout-warning').addClass('hidden');
        } else {
            $('.bs-callout-info').addClass('hidden');
            $('.bs-callout-warning').removeClass('hidden');
        }
    };
}

function ValidaDivCreacionRapidaClientes() {
    $.listen('parsley:field:validate', function () {
        validateFront();
    });
    var validateFront = function () {
        if ($('#div-CreacionRapidaClientes').parsley().isValid()) {
            $('.bs-callout-info').removeClass('hidden');
            $('.bs-callout-warning').addClass('hidden');
        } else {
            $('.bs-callout-info').addClass('hidden');
            $('.bs-callout-warning').removeClass('hidden');
        }
    };
}

function ValidaDivRegistraBeneficiarios() {
    $.listen('parsley:field:validate', function () {
        validateFront();
    });
    var validateFront = function () {
        if ($('#div-RegistraBeneficiarios').parsley().isValid()) {
            $('.bs-callout-info').removeClass('hidden');
            $('.bs-callout-warning').addClass('hidden');
        } else {
            $('.bs-callout-info').addClass('hidden');
            $('.bs-callout-warning').removeClass('hidden');
        }
    };
}

function getCurrencyConfiguration() {
    return { digits: 0, radixPoint: ",", allowMinus: false, allowPlus: false, placeholder: "0", groupSeparator: "." };
}

function initInputMasks() {
    $(".dateMask").inputmask(getDateMask());
    $(".periodMask").inputmask(getPeriodMask());
    $(".moneyMask").inputmask("currency", getCurrencyConfiguration());
}

function getTextFormattedMoney(text) {
    var configMask = getCurrencyConfiguration();
    configMask.alias = "currency";
    return $.inputmask.format(text, configMask);
}

function CargarVariablesProducto() {
    IniciarPrecargaBancaSeguros();
    var idSeguro = window._SeguroSeleccionado[0].IdSeguro;
    var variables;
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "RegistrarVenta.aspx/ConsultarVariablesActivasProducto",
        data: "{idSeguro:" + idSeguro + "}",
        dataType: "json",
        success: function (data) {
            variables = data.d;
        },
        complete: function (data) {
            if (variables.length > 0) {
                $.jStorage.set('VariablesProducto', variables);
                CargarCamposVariables(variables);
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

function LimpiarFormularioVariables() {
    var table = document.getElementById("tblVariablesProducto");
    while (table.rows.length > 0) {
        table.deleteRow(table.rows.length - 1);
    }
}

function CargarCamposVariables(variables) {
    var table = document.getElementById("tblVariablesProducto");

    for (var i = 0; i < variables.length; i++) {
        var row = table.insertRow(table.rows.length);
        var cell1 = row.insertCell(0);
        var cell2 = row.insertCell(1);
        var cell3 = row.insertCell(2);
        cell1.style.padding = "10px";
        cell2.style.padding = "10px";
        cell3.style.padding = "10px";

        cell1.innerHTML = "<label>" + variables[i].NombreCampo + "</label>";
        switch (variables[i].IdTipoDato) {
            case 1:
                cell2.innerHTML = '<input type="text" id="vv_' + variables[i].Orden + '" maxlength="' + variables[i].Longitud + '"  onkeypress="return ValidaCaracterNumerico(event);" class="form-control"/>';
                break;

            case 2:
                cell2.innerHTML = '<textarea rows="4" id="vv_' + variables[i].Orden + '" maxlength="' + variables[i].Longitud + '"  onkeypress="return ValidaCaracterAlfaNumerico(event);" style="width: 400px"  />';
                break;

            case 3:
                cell2.innerHTML = '<input type="text" id="vv_' + variables[i].Orden + '" maxlength="' + variables[i].Longitud + '"  onkeypress="return ValidaCaracterAlfaNumerico(event);" class="form-control"/>';
                break;

            case 4:
                cell2.innerHTML = '<input type="checkbox" id="vv_' + variables[i].Orden + '" />';
                break;

            case 5:
                cell2.innerHTML = '<input type="text" id="vv_' + variables[i].Orden + '" class="fecha form-control" /><input type="button" value="Limpiar" onclick="LimpiarControl(\'vv_' + variables[i].Orden + '\');" />';
                break;

            case 6:
                cell2.innerHTML = CrearComboMaestra(variables[i]);
                break;
        }

        cell3.innerHTML = '<input type="hidden" id="hvv_' + variables[i].Orden + '" value ="' + variables[i].IdVariableProducto + '"  />';
    }
}

function CrearComboMaestra(variable) {
    var controlhtml = '<select type="text" id="vv_' + variable.Orden + '" class="selectpicker form-control"><option value="">-- Seleccione --</option>';
    if (variable.ItemsMaestra != null) {
        for (var i = 0; i < variable.ItemsMaestra.length; i++) {
            controlhtml += '<option value="' + variable.ItemsMaestra[i].Codigo + '">' + variable.ItemsMaestra[i].Valor + '</option>';
        }
    }
    controlhtml += '</select>'
    return controlhtml;
}

function LlenarEntidadArrayVariableVenta() {
    var ArrayVariableVenta = [];
    if (window._SeguroSeleccionado != undefined) {
        var variablesProducto = $.jStorage.get('VariablesProducto');

        if (variablesProducto != undefined) {
            for (var i = 0; i < variablesProducto.length; i++) {
                var idcontrolValor = '#vv_' + variablesProducto[i].Orden;
                var idcontrolIdVariable = '#hvv_' + variablesProducto[i].Orden;

                var controlValor = $(idcontrolValor);
                var controlVariable = $(idcontrolIdVariable);

                if (controlValor != undefined && controlVariable != undefined && controlValor.val() != undefined) {
                    var VariableVenta = {};
                    VariableVenta.IdSeguro = window._SeguroSeleccionado[0].IdSeguro;
                    VariableVenta.IdVariableProducto = parseInt(controlVariable.val(), 0);
                    if (controlValor.attr('type') === "checkbox") {
                        if (controlValor.is(':checked')) {
                            VariableVenta.Valor = "SI";
                        }
                        else {
                            VariableVenta.Valor = "NO";
                        }
                    }
                    else {
                        VariableVenta.Valor = controlValor.val().toString();
                    }
                    ArrayVariableVenta.push(VariableVenta);
                }
            }
        }

        return ArrayVariableVenta;
    }

    return null;
}

function LimpiarControl(idControl) {
    $('#' + idControl).val("");
}