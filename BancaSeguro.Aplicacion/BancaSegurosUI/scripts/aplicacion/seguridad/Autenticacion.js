$(document).ready(function () {
    LimpiarSession();
    IniciarPrecargaBancaSeguros();
    CargarTodosLosCatalogos();
    DetenerPrecargaBancaSeguros();
    CargarPlaceHolderIE();
    $(document).on("contextmenu", function (e) {
        if (e.target.nodeName != "INPUT" && e.target.nodeName != "TEXTAREA")
            e.preventDefault();
    });
});

function LimpiarSession() {
    try {
        window['_TipoIdentificacion'] = undefined;
        window['_Genero'] = undefined;
        window['_SeguroSeleccionado'] = undefined;
        window['_SegurosCargados'] = undefined;
        $.jStorage.flush();
    } catch (e) { }
}

function CargarPlaceHolderIE() {
    if (navigator.appVersion.indexOf('IE 8') > -1) {
        $('input[type="text"][placeholder], input[type="password"][placeholder]').each(function () {
            var obj = $(this);

            if (obj.attr('placeholder') !== '') {
                obj.addClass('IePlaceHolder');

                if ($.trim(obj.val()) === '') {
                    obj.val(obj.attr('placeholder'));
                }
            }
        });

        $('.IePlaceHolder').focus(function () {
            var obj = $(this);
            if (obj.val() === obj.attr('placeholder')) {
                obj.val('');
            }
        });

        $('.IePlaceHolder').blur(function () {
            var obj = $(this);
            if ($.trim(obj.val()) === '') {
                obj.val(obj.attr('placeholder'));
            }
        });
    }
}

function AutenticarUsuario() {
    var AutenticarUsu = {};
    var Usuario = {};

    var user = $('#txtUsuario').val();
    var contrasena = $('#txtContrasena').val();

    ValidaDiv('login');
    var validacion = $('#login').parsley().validate();
    if (validacion) {
        IniciarPrecargaBancaSeguros();
        Usuario.Login = user;
        Usuario.Contrasena = contrasena;

        $.ajax({
            type: "POST",
            cache: false,
            async: true,
            contentType: "application/json; charset=utf-8",
            url: "Autenticacion.aspx/AutenticarUsuario",
            data: "{'usuario':" + JSON.stringify(Usuario) + "}",
            dataType: "json",
            success: function (data) {
                AutenticarUsu = data.d;
                CargarAutenticacion(AutenticarUsu);
            },
            complete: function (data) {
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

function CargarAutenticacion(AutenticarUsu) {
    if (AutenticarUsu.Autenticado && !AutenticarUsu.Resultado.Error) {
        $.jStorage.flush();
        $.jStorage.set('IdUsuario', AutenticarUsu.Usuario.Login);
        $.jStorage.set('NombreUsuario', AutenticarUsu.Usuario.Nombres);
        $.jStorage.set('IdentificacionUsuario', AutenticarUsu.Usuario.Identificacion);
        $.jStorage.set('CodigoOficina', AutenticarUsu.Usuario.Oficina.IdOficina);
        $.jStorage.set('NombreOficina', AutenticarUsu.Usuario.Oficina.Nombre);
        $.jStorage.set('Roles', AutenticarUsu.Usuario.Roles);

        window.location.assign("../Inicio.aspx");
    } else {

        if (AutenticarUsu.Resultado.Error) {
            MostrarMensajeGenerico(3, AutenticarUsu.Resultado.Mensaje);
        }
        else {
            MostrarMensajeGenerico(2, AutenticarUsu.Resultado.Mensaje);
        }
    }
}

function CargarTodosLosCatalogos() {
    var ListParametro = $.jStorage.get("ListaParametro");

    if (ListParametro == null || ListParametro == undefined) {

        var DataCatalogo = ConsultarCatalogoPorTabla("SEG_Parametro");

        if (DataCatalogo != null && DataCatalogo != undefined) {

            ListParametro = Enumerable.From(DataCatalogo.ListParametro).Select().ToArray();

            $.jStorage.set('ListaParametro', ListParametro);
        }
    }

    /*var version = Enumerable.From(ListParametro)
                 .Where(function (x) { return x.Descripcion.startsWith("Versi") })
                .Select()
                .ToArray()[0].Valor;*/

    var version = $.map(ListParametro, function (value, key) {
        if (value.Descripcion.toLowerCase().indexOf("versi") >= 0) {
            return value.Valor;
        }
    });

    var div = document.getElementById('version');
    div.innerHTML = div.innerHTML + 'Versión ' + version;
}

function ConsultarCatalogoPorTabla(NombreTabla) {

    var DataCatalogo;

    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "Autenticacion.aspx/ConsultarTodosCatalogo",
        data: "{'NombreTabla':'" + NombreTabla + "'}",
        dataType: "json",
        success: function (data) {
            DataCatalogo = data.d;
        },
        error: function (data) {
            var r = data.responseText;
            var errorMessage = r.Message;
            MostrarMensajeGenerico(3, errorMessage);
        }
    });

    return DataCatalogo;
}


