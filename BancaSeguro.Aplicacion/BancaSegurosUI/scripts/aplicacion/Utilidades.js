var sess_pollInterval = 60000;
var sess_expirationMinutes = 60;
var sess_warningMinutes = 30;
var sess_intervalID;
var sess_lastActivity;
var EstaVacio = function (valor) {
    return (valor === null || valor.length === 0 || valor === '');
};

function CalcularEdad(fecha) {

var fechaActual = new Date()
var diaActual = fechaActual.getDate();
var mmActual = fechaActual.getMonth() + 1;
var yyyyActual = fechaActual.getFullYear();
var diaCumple = fecha.getDate();
var mmCumple = fecha.getMonth() + 1;
var yyyyCumple = fecha.getFullYear();
var edad = yyyyActual - yyyyCumple;
if ((mmActual < mmCumple) || (mmActual == mmCumple && diaActual < diaCumple)) {
    edad--;
}
return edad;
};

function ConsultarCatalogo(NombreTabla) {
    var DataCatalogo;
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: "~/../../venta/RegistrarVenta.aspx/ConsultarCatalogo",
        data: "{'NombreTabla':'" + NombreTabla + "'}",
        dataType: "json",
        success: function (data) {
        },
        complete: function (data) {
            DataCatalogo = data.responseJSON.d
            DetenerPrecargaBancaSeguros();
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage);
            DetenerPrecargaBancaSeguros();
        }
    });

    return DataCatalogo;
}

function OcultarPanel(panel, ocultar) {
    if (ocultar) {
        document.getElementById(panel).style.display = 'none';
    } else if (!ocultar) {
        document.getElementById(panel).style.display = '';
    }
}

function DeshabilitarDivYContenido(div, disponible) {
    var nodes = document.getElementById(div).getElementsByTagName('*');
    for (var i = 0; i < nodes.length; i++) {
        nodes[i].disabled = disponible;
    }
}

function IniciarPrecargaBancaSeguros() {
    $("#Cargando").introLoader({
        animation: {
            name: 'gifLoader',
            options: {
                ease: "easeInOutCirc",
                style: 'light',
                delayBefore: 100,
                stop: false
            }
        }
    });
}

function DetenerPrecargaBancaSeguros() {
    var loader = $('#Cargando').data('introLoader');
    loader.stop();
}

function ValidaDiv(divAValidar) {
    $.listen('parsley:field:validate', function () {
        validateFront();
    });
    var validateFront = function () {
        if ($('#' + divAValidar).parsley().isValid()) {
            $('.bs-callout-info').removeClass('hidden');
            $('.bs-callout-warning').addClass('hidden');
        } else {
            $('.bs-callout-info').addClass('hidden');
            $('.bs-callout-warning').removeClass('hidden');
        }
    };
}

function BuscarFila(grilla) {
    var fila;
    var arow = new Array();
    var oTable = $(grilla).dataTable();
    $(oTable.fnSettings().aoData).each(function () {
        $(this.nTr).removeClass('row_selected');
    });
    $(event.target.parentNode).addClass('row_selected');
    var aReturn = new Array();
    var aTrs = oTable.fnGetNodes();
    var control = false

    for (var i = 0 ; i < aTrs.length ; i++) {
        var celdas = aTrs[i].cells
        for (var j = 0; j < aTrs[i].cells.length; j++) {
            if ($(celdas[j]).hasClass('row_selected')) {
                aReturn.push(aTrs[i]);
                control = true;
                break;
            }
        }
        if (control) break;
    }
    return aReturn[0];
}

function DeseleccionarFila() {
    $("td.row_selected").removeClass('row_selected');
}

function LlenarListaDesplegable(data, dropDownList, DescripcionValor, DescripcionTexto) {
    for (var i = 0; i < data.length; i++) {
        $('#' + dropDownList).append($('<option>', { value: data[i][DescripcionValor], text: data[i][DescripcionTexto] }));
    }
    var optionA = $('#' + dropDownList).val();
}

function async(your_function, callback) {
    setTimeout(function () {
        your_function();
        if (callback) { callback(); }
    }, 0);
}

function BuscarenArreglo(nameKey, myArray) {
    for (var i = 0; i < myArray.length; i++) {
        if (myArray[i].name === nameKey) {
            return myArray[i];
        }
    }
}

function ValidaCaracterNumerico(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode === 8) {
        return true;
    }
    else {
        var key = String.fromCharCode(charCode);
    }
    return ValidaNumerico(key);
}

function ValidaCaracterAlfaNumerico(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode === 8) {
        return true;
    }
    else {
        var key = String.fromCharCode(charCode);
        return ValidaAlfaNumerico(key);
    }
}

function ValidaNumerico(key) {
    var regexNumerico = /^[0-9]+$/;
    if (regexNumerico.test(key))
        return true;
    else
        return false;
}

function ValidaAlfaNumerico(key) {
    var regexAlfaNumerico = /^[a-zA-Z0-9\s]+$/;
    if (regexAlfaNumerico.test(key)) {
        return true;
    }
    else {
        return false;
    }
}

function ConvertJsonToDate(currentTime) {
    var month = pad(currentTime.getMonth() + 1);
    var day = pad(currentTime.getDate());
    var year = currentTime.getFullYear();
    var date = day + "/" + month + "/" + year;
    return date;
}

function pad(num) {
    num = "0" + num;
    return num.slice(-2);
}

function initSession() {
    if ($.jStorage.get("IdUsuario") != undefined) {
        sess_lastActivity = new Date();
        sessSetInterval();
        $(document).bind('keypress.session', function (ed, e) {
            sessKeyPressed(ed, e);
        });
        return true;
    }
    else {
        return false;
    }
}

function RutaSitio(nivel) {
    var _url = window.location.pathname;
    var url = window.location.protocol + "//" + window.location.host;
    var io = window.location.pathname.indexOf("Site");
    if (io > 0) {
        _url = _url.substr(0, io + 4);
        url = url + "/" + _url;
    }
    else
        url = window.location.protocol + "//" + window.location.host;
    return url;
}

function sessSetInterval() {
    sess_intervalID = setInterval('sessInterval()', sess_pollInterval);
}

function sessClearInterval() {
    clearInterval(sess_intervalID);

}

function sessKeyPressed(ed, e) {
    sess_lastActivity = new Date();
}

function sessLogOut() {
    window.location.href = RutaSitio(2) + '/Seguridad/Autenticacion.aspx';
}

function sessInterval() {
    var now = new Date();
    //get milliseconds of differneces
    var diff = now - sess_lastActivity;
    //get minutes between differences
    var diffMins = (diff / 1000 / 60);
    if (diffMins >= sess_warningMinutes) {
        //warn before expiring
        //stop the timer
        sessClearInterval();
        //prompt for attention
        var active = confirm('Su sesión expirará en ' +
        (sess_expirationMinutes - sess_warningMinutes) +
        ' minutos (a partir de ' + now.toTimeString() + '), pulse OK para permanecer conectado o pulse Cancelar para cerrar la sesión. \nSi se cierra la sesión todos los cambios se perderán .');
        if (active) {
            now = new Date();
            diff = now - sess_lastActivity;
            diffMins = (diff / 1000 / 60);
            if (diffMins > sess_expirationMinutes) {
                sessLogOut();
            }
            else {
                initSession();
                sessSetInterval();
                sess_lastActivity = new Date();
            }
        }
        else {
            sessLogOut();
        }
    }
}

function ValidarControlDual() {
    IniciarPrecargaBancaSeguros();
    var Roles = $.jStorage.get('Roles');
    var Menu = $.jStorage.get('GMenu');

    var NombrePagina = window.location.pathname.split("/").slice(-1).toString();
    var idMenu;
    for (var j = 0; j < Menu.length; j++) {
        if (Menu[j]["Url"].split("/").slice(-1).toString() === NombrePagina) {
            idMenu = parseInt(Menu[j]["IdMenu"], 0);
            break;
        }
    }
    var datosControlDual = {};
    datosControlDual.IdMenu = idMenu;
    datosControlDual.requiereAutorizacion = false;
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "~/../../seguridad/AprobarControlDual.aspx/RequiereAutorizacionDual",
        data: "{rolesUsuario:" + JSON.stringify(Roles) + ",idMenu:" + idMenu + "}",
        dataType: "json",
        success: function (data) {
            requiereAutorizacion = data.d;
        },
        complete: function (data) {
            datosControlDual.requiereAutorizacion = requiereAutorizacion;
            $.jStorage.set('RegistroAutorizaDual', datosControlDual);
            DetenerPrecargaBancaSeguros();
        },
        error: function (data) {
            var errorMessage = data.responseText;
            $.jStorage.set('RegistroAutorizaDual', datosControlDual);
            MostrarMensajeGenerico(3, errorMessage)
            DetenerPrecargaBancaSeguros();
        }
    });
}

function AlmacenarRegistroTemporalControlDual(idMenu, accion, nombreObjeto, datosObjeto, popupCerrar) {
    IniciarPrecargaBancaSeguros();
    var datosAprobacion = {};
    datosAprobacion.IdMenu = idMenu;
    datosAprobacion.Estado = "P";
    datosAprobacion.Accion = accion;

    datosAprobacion.NombreObjeto = nombreObjeto;
    datosAprobacion.DatosObjeto = datosObjeto;

    var resultado;
    $.ajax({
        type: "POST",
        cache: false,
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "~/../../seguridad/AprobarControlDual.aspx/InsertarAprobacionDual",
        data: "{aprobacion:" + JSON.stringify(datosAprobacion) + "}",
        dataType: "json",
        success: function (data) {
            resultado = data.d;
        },
        complete: function (data) {
            if (!resultado.Error) {
                MostrarMensajeGenerico(1, resultado.Mensaje)
                if (popupCerrar !== '') {
                    $(popupCerrar).modal('hide');
                }
                DetenerPrecargaBancaSeguros();
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

function ConsultarMensajeDB(evento, llave) {
    var urlLocationInicio = $.jStorage.get("urlLocationInicio");
    var Resultado;
    $.ajax({
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        url: urlLocationInicio + "/Inicio.aspx/ConsultarMensajeDB",
        data: "{evento:" + evento + ",llave:'" + llave + "'}",
        dataType: "json",
        success: function (data) {
        },
        complete: function (data) {
            MostrarMensajeGenerico(data.responseJSON.d.IdTipoMensaje, data.responseJSON.d.Mensaje)
        },
        error: function (data) {
            var errorMessage = data.responseText;
            MostrarMensajeGenerico(3, errorMessage);
            DetenerPrecargaBancaSeguros();
        }
    });
}

function FormatearNumeros(numero, decimales, separador_decimal, separador_miles) {
    numero = parseFloat(numero.replace(',', '.'));
    if (isNaN(numero)) {
        return "";
    }

    if (decimales !== undefined) {
        // Redondeamos
        numero = numero.toFixed(decimales);
    }

    // Convertimos el punto en separador_decimal
    numero = numero.toString().replace(".", separador_decimal !== undefined ? separador_decimal : ",");

    if (separador_miles) {
        // Añadimos los separadores de miles
        var miles = new RegExp("(-?[0-9]+)([0-9]{3})");
        while (miles.test(numero)) {
            numero = numero.replace(miles, "$1" + separador_miles + "$2");
        }
    }

    return numero;
}

function isLeapYear(year) {
    return (((year % 4 === 0) && (year % 100 !== 0)) || (year % 400 === 0));
}

function getDaysInMonth(year, month) {
    return [31, (isLeapYear(year) ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31][month];
}

function addMonths(date, value) {
    var d = new Date(date),
        n = date.getDate();
    d.setDate(1);
    d.setMonth(d.getMonth() + value);
    d.setDate(Math.min(n, getDaysInMonth(d.getFullYear(), d.getMonth())));
    return d;
}