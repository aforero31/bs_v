var validNavigation = false;

$(document).ready(function () {
    wireUpEvents();
});

function endSession() {
    try {
        window['_TipoIdentificacion'] = undefined;
        window['_Genero'] = undefined;
        window['_SeguroSeleccionado'] = undefined;
        window['_SegurosCargados'] = undefined;
        $.jStorage.flush();
    } catch (e) { }
}

function wireUpEvents() {
    window.onbeforeunload = function () {
        if (!validNavigation) {
            endSession();
        } else { validNavigation = false; }
    }
}