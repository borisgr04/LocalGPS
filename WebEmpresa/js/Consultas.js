function filtrar(cod) {
    alert(cod);
}

$(document).ready(function () {

    var circle;
    var radioBusqueda = 760;
    enviarGET();
    obtenerCategorias();
    function enviarGET() {
        $.ajax({
            url: "api/Empresa/",
            type: 'GET',
            dataType: 'json',
            contentType: "application/json;charset=utf-8",
            success: function (Empresas) {
                PosicionGPS.Obtener(function (Pos) {
                    PosicionMapa(Pos);
                    cargarMapa(Pos,Empresas);
                });
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(JSON.stringify(xhr) + '\n' + ajaxOptions + '\n' + thrownError);
            }
        });
    };
    
    function obtenerCategorias() {
        $.ajax({
            url: "api/categorias/",
            type: 'GET',
            dataType: 'json',
            contentType: "application/json;charset=utf-8",
            success: function (categorias) {
                $("#dvdCat").html('');
                alert(JSON.stringify(categorias));
                $.each(categorias, function (index, cat) {
                    $("#dvdCat").append('<a href="#" onclick="filtrar(' + cat.codigo + ')" class="list-group-item">' + cat.nombre + '</a>');
                });
                /*
                PosicionGPS.Obtener(function (Pos) {
                    PosicionMapa(Pos);
                    cargarMapa(Pos, Empresas);
                });
                */
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(JSON.stringify(xhr) + '\n' + ajaxOptions + '\n' + thrownError);
            }
        });
    };
    function PosicionMapa(Pos) {

        var latitud = Pos.Latitud;
        var longitud = Pos.Longitud;
        var latlon = new google.maps.LatLng(latitud, longitud);
        var myOptions = {
            zoom: 15,
            center: latlon, // Definimos la posicion del mapa con el punto
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        //Configuramos una serie de opciones como el zoom del mapa y el tipo.
        map = new google.maps.Map($("#map_canvas").get(0), myOptions); //Creamos el mapa y lo situamos en su capa
        var coorMarcador = new google.maps.LatLng(latitud, longitud); //Un nuevo punto con nuestras coordenadas para el marcador (flecha)
        function openInfoWindow(marker) {
            var markerLatLng = marker.getPosition();
            infoWindow.setContent([
                markerLatLng.lat(), ',', markerLatLng.lng()
            ].join(''));
            infoWindow.open(map, marker);
        }

        var infoWindow = new google.maps.InfoWindow();
        map.addListener('click', function (event) {
            alert(marcador.getPosition().lat() + ":" + marcador.getPosition().lng());
            map.setCenter(marcador.getPosition());
        });

        var coorMarcador = new google.maps.LatLng(latitud, longitud); //Un nuevo punto con nuestras coordenadas para el marcador (flecha)
        marcador = new google.maps.Marker({
            //Creamos un marcador
            position: coorMarcador, //Lo situamos en nuestro punto
            draggable: true,
            map: map, // Lo vinculamos a nuestro mapa
            title: "Dónde estoy?"
        });
        DibCirculo(latitud, longitud);
        function DibCirculo(Lat, Lng) {
            if (circle != null) {
                circle.setMap(null);
            }
            // Point where to search
            var searchArea = new google.maps.LatLng(Lat, Lng);
            // Draw a circle around the radius
            circle = new google.maps.Circle({
                center: searchArea,
                radius: radioBusqueda, //convert miles to meters
                strokeColor: "#0000FF",
                strokeOpacity: 0.8,
                strokeWeight: 2,
                fillColor: "#0000FF",
                fillOpacity: 0.4
            });
            circle.setMap(map);
            // Perform search over radius
            var request = {
                location: searchArea,
                radius: 1, //convert miles to meters
                keyword: "coffee"
            };
        }
    };

    function cargarMapa(PosActual, Empresas) {
        
        var gpsActual = new google.maps.LatLng(PosActual.Latitud, PosActual.Longitud);

        $.each(Empresas, function (index, Pos) {
            
            var latitud = Pos.latitud;
            var longitud = Pos.longitud;

            var gpsEmpresa = new google.maps.LatLng(latitud, longitud);

            var distancia = google.maps.geometry.spherical.computeDistanceBetween(gpsActual, gpsEmpresa);

            alert("Distancia:" + distancia);

            if (distancia < radioBusqueda) {
                var coorMarcador = new google.maps.LatLng(latitud, longitud); //Un nuevo punto con nuestras coordenadas para el marcador (flecha)
                marcador = new google.maps.Marker({
                    //Creamos un marcador
                    position: coorMarcador, //Lo situamos en nuestro punto
                    draggable: true,
                    map: map, // Lo vinculamos a nuestro mapa
                    title: "Dónde estoy?"
                });
            
                google.maps.event.addListener(marcador, 'click', function () {
                    openInfoWindow(marcador);
                });
                google.maps.event.addListener(marcador, 'drag', function (event) {
                    //$("#txtLtd").val(this.position.lat());
                    //$("#txtLng").val(this.position.lng());
                });
                google.maps.event.addListener(marcador, 'dragend', function (event) {
                    //$("#txtLtd").val(this.position.lat());
                    //$("#txtLng").val(this.position.lng());
                });
            }
        });
    }

});