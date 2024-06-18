$(document).ready(function () {
    $("body").prepend(ObtenerDivModalAlerta());
    $("body").prepend(ObtenerDivModalConfirmacion());    
});

function MostrarMensajeGenerico(enumTipoMensaje, mensaje) {
    if (enumTipoMensaje !== 1)
        DetenerPrecargaBancaSeguros();

    var tipoMensaje = ObtenerTituloMensaje(enumTipoMensaje);
    $('#imgTipoMensaje').attr('src', ObtenerImagenMensaje(enumTipoMensaje));
    $("#MensajeTitulo").empty();
    $("#MensajeTitulo").prepend(tipoMensaje);
    $("#spanMensajeMensaje").empty();
    $("#spanMensajeMensaje").prepend(mensaje);
    $('#modMensajeGenerico').modal('show');

    $("#btnCerrarMensaje").attr('onclick', null);
    $("#btnCerrarMensaje").attr("data-dismiss", "modal");
    $("#btnCerrarMensaje").attr("aria-hidden", "true");
}

function MostrarModalConfirmar(enumTipoMensaje, mensaje, metodoAceptar, metodoCancelar) {
    if (enumTipoMensaje !== 1)
        DetenerPrecargaBancaSeguros();
    var tipoMensaje = ObtenerTituloMensaje(enumTipoMensaje);
    $("#imgTipoMensajeConfirmacion").attr('src', ObtenerImagenMensaje(enumTipoMensaje));
    $("#MensajeTituloConfirmacion").empty();
    $("#MensajeTituloConfirmacion").prepend(tipoMensaje);
    $("#spanMensajeMensajeConfirmacion").empty();
    $("#spanMensajeMensajeConfirmacion").prepend(mensaje);
    $("#modConfirmacionGenerico").modal('show');
    $("#btnAceptarConfirmar").attr('onclick', metodoAceptar);
    $("#btnAceptarConfirmar").attr("data-dismiss", "modal");
    $("#btnAceptarConfirmar").attr("aria-hidden", "true");

    if (metodoCancelar == null) {
        $("#btnCancelarConfirmar").attr("data-dismiss","modal");
        $("#btnCancelarConfirmar").attr("aria-hidden", "true"); 
    }
    else {
        $("#btnCerrarConfirmacion").attr('onclick', metodoCancelar);
        $("#btnCerrarConfirmacion").attr("data-dismiss", "modal");
        $("#btnCerrarConfirmacion").attr("aria-hidden", "true");
        $("#btnCancelarConfirmar").attr('onclick', metodoCancelar);
        $("#btnCancelarConfirmar").attr("data-dismiss", "modal");
        $("#btnCancelarConfirmar").attr("aria-hidden", "true");
    }
}

function ObtenerTituloMensaje(enumTipoMensaje) {
    switch (enumTipoMensaje) {
        case 0:
            return "<b style='color: white;'></b>";
            break;
        case 1:
            return "<b style='color: green;'>¡Informativo!</b>";
            break;
        case 2:
            return "<b style='color: #FFBF00;'>¡Advertencia!</b>";
            break;
        case 3:
            return "<b style='color: red;'>¡Error!</b>";
            break;
    }
}

function ObtenerImagenMensaje(enumTipoMensaje) {
    var url = RutaSitio(3);
    switch (enumTipoMensaje) {
        case 0:
            return url + '/imagenes/alert-icon.png'
            break;
        case 1:
            return url+'/imagenes/Accept-icon.png'
            break;
        case 2:
            return url+'/imagenes/alert-icon.png'
            break;
        case 3:
            return url+'/imagenes/Close-icon.png'
            break;
    }
}

function ObtenerDivModalAlerta() {
    return "<div class='modal fade' id='modMensajeGenerico' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' style='z-index:1200'><div id='div-modMensajeGenerico' data-parsley-validate=''><div class='modal-dialog' style='width: 40%;'><div class='modal-content' style='width: 100%;'><div class='modal-header' style='width: 100%'><button type='button' class='close' data-dismiss='modal' aria-hidden='true'>&times;</button><h3 id='MensajeTitulo' class='modal-title' style='width: 100%'></h3></div><div class='modal-body' style='width: 100%'><table style='width: 100%'><thead><tr><th style='width: 20%'><img src='' id='imgTipoMensaje' width='50px' height='50px' /></th><th style='width: 80%'><h4 id='spanMensajeMensaje' style='text-align: left;'></h4></th></tr></thead><tr><td colspan='2' style='text-align: center'><input type='button' id='btnCerrarMensaje' class='btn btn-default submit' onclick='null' value='Cerrar' /></td></tr></table></div></div></div></div></div>";
}

function ObtenerDivModalConfirmacion() {
    return "<div class='modal fade' id='modConfirmacionGenerico' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'><div id='div-modConfirmacionGenerico' data-parsley-validate=''><div class='modal-dialog' style='width: 40%;'><div class='modal-content' style='width: 100%'><div class='modal-header' style='width: 100%'><button type='button' class='close' data-dismiss='modal' aria-hidden='true' id='btnCerrarConfirmacion'>&times;</button><h3 id='MensajeTituloConfirmacion' class='modal-title' style='width: 100%'></h3></div><div class='modal-body' style='width: 100%'><table style='width: 100%'><thead><tr><th style='width: 20%'><img src='' id='imgTipoMensajeConfirmacion' width='50px' height='50px' /></th><th style='width: 80%'><h4 id='spanMensajeMensajeConfirmacion' style='text-align: left;'></h4></th></tr></thead><tr><td colspan='2' style='text-align: center'><input type='button' id='btnAceptarConfirmar' value='Aceptar' /> <input type='button' id='btnCancelarConfirmar' value='Cancelar' /></td></tr></table></div></div></div></div></div>";
}
