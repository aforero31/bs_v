$(document).ready(function () {
    if ($.jStorage.get("IdUsuario") != undefined) {
        IniciarPrecargaBancaSeguros();
        $.jStorage.set('urlLocationInicio', GetUrl());
        CargarMenu();
        CargarTodosLosCatalogos();
        $('#elemento-precarga-BancaSeguros').hide();
        CargarDatosUsuario();
        DetenerPrecargaBancaSeguros();

        $(document).on("contextmenu", function (e) {
            if (e.target.nodeName !== "INPUT" && e.target.nodeName !== "TEXTAREA")
                e.preventDefault();
        });
    }
});

function DesHabilitarTeclas() {
    switch (event.keyCode) {

        case 116: // 'F5'
            event.returnValue = false;
            event.keyCode = 0;
            break;

        case 27: // 'Esc'
            event.returnValue = false;
            event.keyCode = 0;
            break;
    }
}

function GetUrl() {
    if ($.jStorage.get('RutaBase') == null) {
        var pathNameArray = window.location.pathname.split("/");
        if (pathNameArray[pathNameArray.length - 1] === "Inicio.aspx") {
            var pathNameArray = window.location.pathname.split("/");
            var pathName = '';
            var replace = false;
            var url = window.location.protocol + "//" + window.location.host;

            for (var i = 0; i < pathNameArray.length - 1; i++) {
                if (pathNameArray[i].length > 0) {
                    pathName += '/' + pathNameArray[i];
                }
            }
            url += '/' + pathName;
            $.jStorage.set('RutaBase', url);
        }
    }
    return $.jStorage.get('RutaBase');
};

function logout() {
    window.location = '/Login.aspx';
}

function CargarDatosUsuario() {
    var Roles = $.jStorage.get('Roles');
    var divRol = document.getElementById('rol');
    var Usuario = $.jStorage.get('NombreUsuario');
    var RolesAMostrar = '';

    if (Roles == undefined || Roles == null) {
        RolesAMostrar = 'SIN ROL';
    } else {
        if (Roles.length > 0) {
            for (var i = 0; i < Roles.length; i++) {
                RolesAMostrar = RolesAMostrar + Roles[i].Nombre;
                if (i < (Roles.length - 1)) {
                    RolesAMostrar = RolesAMostrar + ' - ';
                }
            }
        }
    }

    divRol.innerHTML = RolesAMostrar;

    var UsuarioBancaImg = document.getElementById('UsuarioBancaImg');
    UsuarioBancaImg.innerHTML = Usuario;

    var UsuarioBanca = document.getElementById('UsuarioBanca');
    UsuarioBanca.innerHTML = Usuario
}

