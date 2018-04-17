var _datosTipo;

function eliminarTipoExitoso(resultado, e, elemento) {
    $("#eliminarTipo").modal("hide");
    if (resultado.Success) {
        $(e.currentTarget).closest('tr').remove();
        _datosTipo.remove(elemento);
        toastr.success("El tipo'" + elemento.Nombre + " '   se ha eliminado satisfactoriamente");
    } else {
        toastr.error(resultado.Mensaje);
    }
}

function confirmarEliminarTipo(e, elemento) {
    var url = "/Tipo/EliminarTipo";
    var tipo = 'GET';
    var datos = { pk: elemento.PkTipo };
    var tipoDatos = 'JSON';
    solicitudAjax(url, function (response) { eliminarTipoExitoso(response, e, elemento); }, datos, tipoDatos, tipo);
}

function mostrarModalEliminarTipo(e, elemento) {
    var modal = '#eliminarTipo';
    $(modal).find(".modal-title").html('Eliminar tipo');
    $(modal).find(".text-mensaje-modal").html('Esta seguro que desea eliminar el tipo  '
        + "'" + elemento.Nombre + "'    ?");
    $(modal).find(".modal-body").css({ 'min-height': 100 + "px" });
    $(modal).modal({ backdrop: 'static', keyboard: false });
    $("#btnConfirmarEliminarTipo").unbind('click').click(function () {
        confirmarEliminarTipo(e, elemento);
    });
}

function editarDatosTipo(elemento) {
    $("#txtNombreTipo").val(elemento.Nombre);
    $("#txtDescripcionTipo").val(elemento.Descripcion);
    $("#btnAbmGuardarTipo").hide();
    $("#btnAbmEditarTipo").show();
}

function eventoActualizarTipo(input, elemento) {
    $(input).unbind('click').click(function () {
        var modal = '#agregarAbmTipo';
        editarDatosTipo(elemento);
        $(modal).find(".modal-title").html('Editar Tipo :   ' + "'" + elemento.Nombre + "'");
        $(modal).find(".modal-dialog").css({ 'width': 700 + "px" });
        $(modal).modal({ backdrop: 'static', keyboard: false });
        $("#btnAbmEditarTipo").unbind('click').click(function (event) {
            event.preventDefault();
            guardarTipo(elemento.PkTipo, elemento);
        });
    });
}

function guardarTipoExitoso(respuesta, elemento) {
    $("#agregarAbmTipo").modal("hide");
    if (respuesta.Success) {
        if (!elemento) {
            var tipo = {
                PkTipo: parseInt(respuesta.Data),
                Nombre: $("#txtNombreTipo").val(),
                Descripcion: $("#txtDescripcionTipo").val()
            };
            _datosTipo.push(tipo);
        } else {
            elemento.Nombre = $("#txtNombreTipo").val();
            elemento.Descripcion = $("#txtDescripcionTipo").val();
        }
        mostrarDatosTipos();
        toastr.success("El Tipo se ha guardado satisfactoriamente ");
    } else {
        toastr.error(respuesta.Mensaje);
    }
}

function guardarTipo(pk, elemento) {
    var url = "/Tipo/GuardarTipo";
    var tipo = 'GET';
    var datos = {
        pk: pk, nombre: $("#txtNombreTipo").val(), descripcion:
            $("#txtDescripcionTipo").val()
    };
    var tipoDatos = 'JSON';
    solicitudAjax(url, function (response) { guardarTipoExitoso(response, elemento); }
        , datos, tipoDatos, tipo);
}

$("#btnAbmGuardarTipo").click(function () {
    guardarTipo(0);
});

function limpiarDatosTipo() {
    $("#txtNombreTipo").val("");
    $("#txtDescripcionTipo").val("");
    $("#btnAbmEditarTipo").hide();
    $("#btnAbmGuardarTipo").show();
}

$("#btnAdicionarTipo").click(function () {
    var modal = '#agregarAbmTipo';
    limpiarDatosTipo();
    $(modal).find(".modal-title").html('Adicionar Tipo');
    $(modal).find(".modal-dialog").css({ 'width': 700 + "px" });
    $(modal).find(".modal-body").css({ 'min-height': 150 + "px" });
    $(modal).modal({ backdrop: 'static', keyboard: false });
});

function mostrarDatosTipos() {
    limpiarTabla('tblAbmTipo');
    $.each(_datosTipo, function (index, elemento) {
        var fila = $('<tr>').attr('id', elemento.PkTipo);
        var input = crearSpan("lblEditTipo" + index, "spanHyperLink", elemento.Nombre);
        eventoActualizarTipo(input, elemento);
        fila.append(col(input));
        fila.append(col(elemento.Descripcion).addClass("alinearIzquierda"));
        fila.append(col(AccionColumna(function (e) { mostrarModalEliminarTipo(e, elemento) }
            , 'trash', 'Eliminar')).addClass("alinearCentro"));
        $('#tblAbmTipo tbody').append(fila);
    });
}

function obtenerTipoExitoso(resultado) {
    if (resultado.Success) {
        _datosTipo = resultado.Data;
        mostrarDatosTipos();
    } else {
        toastr.error(resultado.Mensaje);
    }
}

function init() {
    var url = "/Tipo/ObtenerTipos";
    var tipo = 'GET';
    var datos = {};
    var tipoDatos = 'JSON';
    solicitudAjax(url, obtenerTipoExitoso, datos, tipoDatos, tipo);
}

$(document).ready(function () {
    init();
});

