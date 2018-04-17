var _datosProducto;
var _datosTipos;

function eliminarProductoExitoso(resultado, e, elemento) {
    $("#eliminarProducto").modal("hide");
    if (resultado.Success) {
        $(e.currentTarget).closest('tr').remove();
        _datosProducto.remove(elemento);
        toastr.success("El producto'" + elemento.Nombre + " '   se ha eliminado satisfactoriamente");
    } else {
        toastr.error(resultado.Mensaje);
    }
}

function confirmarEliminarProducto(e, elemento) {
    var url = "/Producto/EliminarProducto";
    var tipo = 'GET';
    var datos = { pk: elemento.PkProducto };
    var tipoDatos = 'JSON';
    solicitudAjax(url, function (response) { eliminarProductoExitoso(response, e, elemento); }, datos, tipoDatos, tipo);
}

function mostrarModalEliminarProducto(e, elemento) {
    var modal = '#eliminarProducto';
    $(modal).find(".modal-title").html('Eliminar Producto');
    $(modal).find(".text-mensaje-modal").html('Esta seguro que desea eliminar el producto  '
        + "'" + elemento.Nombre + "'    ?");
    $(modal).find(".modal-body").css({ 'min-height': 100 + "px" });
    $(modal).modal({ backdrop: 'static', keyboard: false });
    $("#btnConfirmarEliminar").unbind('click').click(function () {
        confirmarEliminarProducto(e, elemento);
    });
}

function editarDatosProducto(elemento) {
    limpiarDatosProducto();
    $("#txtNombre").val(elemento.Nombre);
    $("#txtDescripcion").val(elemento.Descripcion);
    $("#txtPrecio").val(elemento.Precio);
    $("#txtStock").val(elemento.Stock);
    if (elemento.FechaVencimiento!=null)
        $("#txtFechaVenc").val(ponerFormatoFecha(elemento.FechaVencimiento));
    $("#cmbTipo").val(elemento.PkTipo);
    $("#btnGuardar").hide();
    $("#btnEditar").show();
}

function eventoActualizarProducto(input, elemento) {
    $(input).unbind('click').click(function () {
        var modal = '#agregarProducto';
        editarDatosProducto(elemento);
        $(modal).find(".modal-title").html('Editar Producto :   ' + "'" + elemento.Nombre + "'");
        $(modal).find(".modal-dialog").css({ 'width': 700 + "px" });
        $(modal).modal({ backdrop: 'static', keyboard: false });
        $("#btnEditar").unbind('click').click(function (event) {
            event.preventDefault();
            guardarProducto(elemento.PkProducto, elemento);
        });
    });
}

function guardarProductoExitoso(respuesta, elemento) {    
    if (respuesta.Success) {
        $("#agregarProducto").modal("hide");
        if (!elemento) {
            var producto = {
                PkProducto: parseInt(respuesta.Data),
                Nombre: $("#txtNombre").val(),
                Descripcion: $("#txtDescripcion").val(),
                Precio: $("#txtPrecio").val(),
                Stock: $("#txtStock").val(),
                FechaVencimiento: $("#txtFechaVenc").val(),
                PkTipo: $("#cmbTipo").val(),
                Tipo: $("#cmbTipo option:selected").html()
            };
            _datosProducto.push(producto);
        } else {
            elemento.Nombre = $("#txtNombre").val();
            elemento.Descripcion = $("#txtDescripcion").val();
            elemento.Precio = $("#txtPrecio").val();
            elemento.Stock = $("#txtStock").val();
            elemento.FechaVencimiento = $("#txtFechaVenc").val();
            elemento.PkTipo = $("#cmbTipo").val();
            elemento.Tipo = $("#cmbTipo option:selected").html();
        }
        mostrarDatosProductos();
        toastr.success("El Producto se ha guardado satisfactoriamente ");
    } else {
        toastr.error(respuesta.Mensaje);
    }
}

function guardarProducto(pk, elemento) {
    var fechaJson
    if ($("#txtFechaVenc").val().trim() != "") {
        var fechaSplit = $("#txtFechaVenc").val().split("/");
        var fecha = new Date(Number(fechaSplit[2]), Number(fechaSplit[1]) - 1,
            Number(fechaSplit[0]), 0, 0, 0);
        fechaJson = "/Date(" + fecha.getTime() + ")/";
    }
    var producto = {
        PkProducto: pk,
        Nombre: $("#txtNombre").val(),
        Descripcion: $("#txtDescripcion").val(),
        Precio: $("#txtPrecio").val(),
        Stock: $("#txtStock").val(),
        FechaVencimiento: $("#txtFechaVenc").val().trim() == "" ? null : fechaJson,
        PkTipo: $("#cmbTipo").val(),
        Tipo: $("#cmbTipo option:selected").html()
    };
    var productoDto = JSON.stringify(producto);
    var url = "/Producto/GuardarProducto";
    var tipo = 'GET';
    var datos = { producto: productoDto };
    var tipoDatos = 'JSON';
    solicitudAjax(url, function (response) { guardarProductoExitoso(response, elemento); }
        , datos, tipoDatos, tipo);
}

$("#btnGuardar").click(function () {
    guardarProducto(0);
});

function limpiarDatosProducto() {
    $("#txtNombre").val("");
    $("#txtDescripcion").val("");
    $("#txtPrecio").val("");
    $("#txtStock").val("");
    $("#txtFechaVenc").val("");
    $("#btnEditar").hide();
    $("#btnGuardar").show();
    $("#btnGuardar").prop('disabled', true);
}

$("#btnAdicionarProducto").click(function () {
    var modal = '#agregarProducto';
    limpiarDatosProducto();
    $(modal).find(".modal-title").html('Adicionar Producto');
    $(modal).find(".modal-dialog").css({ 'width': 700 + "px" });
    $(modal).find(".modal-body").css({ 'min-height': 150 + "px" });
    $(modal).modal({ backdrop: 'static', keyboard: false });
});

function mostrarDatosProductos() {
    limpiarTabla('tblProductos');
    $.each(_datosProducto, function (index, elemento) {
        var fila = $('<tr>').attr('id', elemento.PkProducto);
        var input = crearSpan("lblEditProducto" + index, "spanHyperLink", elemento.Nombre);
        eventoActualizarProducto(input, elemento);
        fila.append(col(input));
        fila.append(col(elemento.Precio).addClass("alinearDerecha"));
        fila.append(col(elemento.Stock).addClass("alinearDerecha"));
        fila.append(col(elemento.Tipo).addClass("alinearIzquierda"));
        fila.append(col(AccionColumna(function (e) { mostrarModalEliminarProducto(e, elemento) }
            , 'trash', 'Eliminar')).addClass("alinearCentro"));
        $('#tblProductos tbody').append(fila);
    });
}

function cargarComboTipo() {
    var prop = { id: 'PkTipo', value: 'Nombre' };
    adicionarOpcionesCombo($("#cmbTipo"), _datosTipos, '', prop, false);
}

function obtenerProductosExitoso(resultado) {
    if (resultado.Success) {
        _datosProducto = resultado.Data.Productos;
        _datosTipos = resultado.Data.Tipos;
        mostrarDatosProductos();
        cargarComboTipo();
    } else {
        toastr.error(resultado.Mensaje);
    }
}

function init() {
    var url = "/Producto/ObtenerProductos";
    var tipo = 'GET';
    var datos = {};
    var tipoDatos = 'JSON';
    solicitudAjax(url, obtenerProductosExitoso, datos, tipoDatos, tipo);
}

$(document).ready(function () {
    init();
    $("#txtPrecio").soloNumerosDecimal();
    $("#txtStock").soloNumeros();
    crearControlFecha("#txtFechaVenc", true);
});

$(".abmProducto").on("change input", function () {
    habilitarBotonGuardar(".abmProducto", "#btnGuardar");
});