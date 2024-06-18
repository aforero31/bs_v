function CargarMenu() {
    $("#Cargando").removeClass("introLoading").addClass("");
    var urlLocationInicio = $.jStorage.get("urlLocationInicio");
    var StoredMenu = $.jStorage.get("GMenu");

    if (StoredMenu == null || StoredMenu == undefined) {
        CargarMenuPorRol(StoredMenu, urlLocationInicio);
    }
    else {
        PintarMenu(StoredMenu, urlLocationInicio)
    }
}

function CargarTodosLosMenu(StoredMenu, urlLocationInicio) {
    $.ajax({
        type: "POST",
        url: urlLocationInicio + "/Inicio.aspx/CargarMenu",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {                
            StoredMenu = msg.d;
        },
        complete: function(msg){
            $.jStorage.set('GMenu', StoredMenu);                
            PintarMenu(StoredMenu, urlLocationInicio)
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage);
        }
    });
}

function CargarMenuPorRol(StoredMenu, urlLocationInicio) {
    var Login = $.jStorage.get('IdUsuario');
    var Nombres = $.jStorage.get('NombreUsuario');
    var Identificacion = $.jStorage.get('IdentificacionUsuario');
    var CodigoOficina = $.jStorage.get('CodigoOficina');
    var NombreOficina = $.jStorage.get('NombreOficina');
    var Roles = $.jStorage.get('Roles');

    $.ajax({
        type: "POST",
        url: urlLocationInicio + "/Inicio.aspx/CargarMenuPorRol",
        contentType: "application/json; charset=utf-8",
        data: "{'roles':" + JSON.stringify(Roles) + "}",
        dataType: "json",
        success: function (msg) {
            StoredMenu = msg.d;
        },
        complete: function (msg) {
            $.jStorage.set('GMenu', StoredMenu);
            PintarMenu(StoredMenu, urlLocationInicio)
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage);
        }
    });

}

function CargarTodosLosCatalogos() {
    var ListTipoIdentificacion = $.jStorage.get("ListaTipoIdentificacion");

    if (ListTipoIdentificacion == null || ListTipoIdentificacion == undefined) {

        var DataCatalogo = ConsultarCatalogoPorTabla("SEG_TipoIdentificacion");

        if (DataCatalogo != null && DataCatalogo != undefined) {

            ListTipoIdentificacion = Enumerable.From(DataCatalogo.ListTipoIdentificacion).Where(function (x) { return x.Activo == true }).Select().ToArray();

            $.jStorage.set('ListaTipoIdentificacion', ListTipoIdentificacion);

        }
    }

    var ListParametro = $.jStorage.get("ListaParametro");

    if (ListParametro == null || ListParametro == undefined) {

        var DataCatalogo = ConsultarCatalogoPorTabla("SEG_Parametro");

        if (DataCatalogo != null && DataCatalogo != undefined) {

            ListParametro = Enumerable.From(DataCatalogo.ListParametro).Select().ToArray();

            $.jStorage.set('ListaParametro', ListParametro);

        }
    }
}

function ConsultarCatalogoPorTabla(NombreTabla) {

    var urlLocationInicio = $.jStorage.get("urlLocationInicio");
    var DataCatalogo;

    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: urlLocationInicio + "/Inicio.aspx/ConsultarTodosCatalogo",
        data: "{'NombreTabla':'" + NombreTabla + "'}",
        dataType: "json",
        success: function (data) {
            DataCatalogo = data.d;
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage);
        }
    });

    return DataCatalogo;
}

function PintarMenu(lsMenu, urlLocationInicio) {
    var _menu = lsMenu;
    var _hijo;
    var div = document.getElementById('nav');
    var listItems = [];
    var str = '';
    var str2 = '';
    if (lsMenu != null && lsMenu.length > 0) {
        for (var key in lsMenu) {
            if (lsMenu[key].IdMenu === lsMenu[key].IdPadre & lsMenu[key].IdMenu > 0) {
                _hijo = SubMenuVertical(_menu, lsMenu[key].IdMenu);
                if (_menu[key].Url.length > 0) {
                    str = '<li class="vn"><a ' + 'href="' + urlLocationInicio + "/" + _menu[key].Url + '"' + '><i class="fa fa-edit"></i>';
                    str = str + lsMenu[key].Nombre + ' ';
                    str = str + '<span class="fa fa-chevron-down">';
                    str = str + '</span></a>';
                }
                else {
                    str = '<li class="vn"><a><i class="fa fa-edit"></i>';
                    str = str + lsMenu[key].Nombre + ' ';
                    str = str + '<span class="fa fa-chevron-down">';
                    str = str + '</span></a>';
                }

                //CargarMenuVertical
                str = str + MenuVertical(_menu, lsMenu[key].IdMenu, _hijo, urlLocationInicio);

                str = str + '</li>';
                listItems.push(str);
            }
        }
        div.innerHTML = div.innerHTML + listItems.join('');
    }
    else {
        MostrarMensajeGenerico(2, "No hay elementos en el menu parametrizados");
    }
}

function MenuVertical(_menu, ID, MenVertical, urlLocationInicio) {
    var _str = '';
    if (MenVertical) { _str = _str + '<ul class="nav child_menu">'; } else { _str = _str + '<ul>'; }
    for (var key in _menu) {
        _MenuHo = false;
        if (_menu[key].IdMenu !== _menu[key].IdPadre & _menu[key].IdPadre === ID) {
            if (_menu[key].Url.length > 0) {
                _str = _str + '<li><a href="' + urlLocationInicio + "/" + _menu[key].Url + '"';
                _str = _str + " onClick = 'validNavigation = true;' ";
                _str = _str + '>' + _menu[key].Nombre + '</a>';
            }
            else {
                _str = _str + '<li>';
                _str = _str + _menu[key].Nombre + '';
            }

            //MenuHorizontal
            _str = _str + MenuHorizontal(_menu, _menu[key].IdMenu, urlLocationInicio);

            _str = _str + '</li>';
        }
    }
    _str = _str + '</ul>';
    return _str;
}

function MenuHorizontal(_menu, ID, urlLocationInicio) {
    var str_ = '';
    var sw = false;
    for (var key in _menu) {
        if (_menu[key].IdMenu !== _menu[key].IdPadre & _menu[key].IdPadre === ID) {
            if (!sw) { str_ = str_ + '<ul  class="nav child_menu">'; sw = true; }

            if (_menu[key].Url.length > 0) {
                str_ = str_ + '<li class="vn"><a href="' + urlLocationInicio + "/" + _menu[key].Url + '"';
                str_ = str_ + " onClick = 'validNavigation = true;' ";
                str_ = str_ + '>' + _menu[key].Nombre + '</a>';
            }
            else {
                str_ = str_ + '<li class="vn">';
                str_ = str_ + _menu[key].Nombre;
            }

            str_ = str_ + MenuHorizontal(_menu, _menu[key].IdMenu);

            str_ = str_ + '</li>';
        }
    }
    if (sw) { str_ = str_ + '</ul>'; sw = false; }
    return str_;
}

function SubMenuVertical(_menu, ID) {
    var sw = false;
    var str = '';
    for (var key in _menu) {
        if (_menu[key].IdMenu === _menu[key].IdPadre & sw === false) {
            for (var _key in _menu) {
                if (_menu[_key].IdMenu !== _menu[_key].IdPadre & _menu[_key].IdPadre === ID & !sw) {
                    sw = true;
                }
            }
        }
    }
    return sw;
}