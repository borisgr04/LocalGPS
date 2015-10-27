$(document).ready(function () {
  
    $("#btnAgregar").click(function () {
        var empresa = {}
        empresa.nombre = $('#txtNombre').val();
        empresa.direccion = $('#txtDireccion').val();
        empresa.longitud = $('#txtLng').val();
        empresa.latitud = $('#txtLtd').val();
        empresa.correo = $('#txtCorreo').val();
        empresa.telefono = $('#txtTelefono').val();
        empresa.password = $('#txtPass').val();
        $.ajax({
            type: "POST",
            url: "api/empresa/",
            contentType: 'application/json; utf-8',
            data: JSON.stringify(empresa) ,
            dataType: 'json',
            success: function (data) {

                alert("Registro Guardado");
            },
            error: function (resultado) { alert(JSON.stringify(resultado)); }
        });

    });
})