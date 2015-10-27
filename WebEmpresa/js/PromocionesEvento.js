$(document).ready(function () {

    $("#btnAgregar").click(function () {
        var promociones = {}
        promociones.nombre = $('#txtNombre').val();
        promociones.precio = $('#txtPrecio').val();
        promociones.empresa = $('1').val();
        promociones.fechaIncial = $('#dtpFechaInicial').val();
        promociones.fechaFincal = $('#dtpFechaFinal').val();
        promociones.imagen = $('#txtImagen').val();

        $.ajax({
            type: "POST",
            url: "api/empresa/",
            contentType: 'application/json; utf-8',
            data:  JSON.stringify(promociones) ,
            dataType: 'json',
            success: function (data) {

                alert("Registro Guardado");
            },
            error: function (resultado) { alert(JSON.stringify(resultado)); }
        });

    });
})