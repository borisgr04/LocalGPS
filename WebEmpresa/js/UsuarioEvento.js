var lstUsuarios = [];

function Editar(codigo) {
    $.each(lstUsuarios, function (index, user) {
        if (user.codigo == codigo) {
            alert(JSON.stringify(user));
            
            $('#txtNombre').val(user.nombre);
            $('#txtCorreo').val(user.correo);
            $('#txtPass').val(user.pass);
            $('#txtTelefono').val(user.telefono);
            return;
        }
    });
}

$(document).ready(function () {
    "use strict";
    

    $("#btnAgregar").click(function () {
        
        var usuarioDTO = {}
        usuarioDTO.nombre = $('#txtNombre').val();
        usuarioDTO.correo = $('#txtCorreo').val();
        usuarioDTO.pass = $('#txtPass').val();
        usuarioDTO.telefono = $('#txtTelefono').val();
        
        $.ajax({
            type: "POST",
            url: "api/usuario/",
            contentType: 'application/json; utf-8',
            data: JSON.stringify(usuarioDTO),
            dataType: 'json',
            success: function (data) {
                alert("Registro Guardado");
                enviarGET();
            },
            error: function (resultado) { alert(JSON.stringify(resultado)); }
        });

    });
   

    enviarGET();

    function enviarGET() {
        $.ajax({
            url: "api/usuario/",
            type: 'GET',
            dataType: 'json',
            contentType: "application/json;charset=utf-8",
            success: function (users) {
                //alert(JSON.stringify(users));
                $("#bodyTable").empty();
                

                $.each(users, function (index, user) {
                    lstUsuarios.push(user);
                    $("#bodyTable").append(
                            "<tr><td>" + user.codigo +
                            "</td><td> " + user.nombre +
                            "</td><td>" + user.correo +
                            "</td><td>" + user.telefono + "</td>" +
                             "<td><button onClick='Editar(" + user.codigo + ")'>Edit</button></td></tr>"
                            );
                   
                });
                
                
                //$('#table_id').dataTable();
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(JSON.stringify(xhr) + '\n' + ajaxOptions + '\n' + thrownError);
            }
        });
    }

})