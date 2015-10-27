var PosicionGPS = (function () {
    var Pos = {
        Longitud: null,
        Latitud: null
    };
    var iniciar;
    var marcador;
    function localizame() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(coordenadas, errores);
        } else {
            alert('Oops! Tu navegador no soporta geolocalización. Bájate Chrome, que es gratis!');
        }
    }
    function coordenadas(position) {
        Pos.Latitud = position.coords.latitude;
        Pos.Longitud = position.coords.longitude;
        Pos.Presicion = position.coords.accuracy;
        Pos.Velocidad = parseInt((position.coords.speed) * 3.6);
        iniciar(Pos);
    }
    function errores(err) {
        if (err.code == 0) {
            alert("Oops! Algo ha salido mal");
        }
        if (err.code == 1) {
            alert("Oops! No has aceptado compartir tu posición");
        }
        if (err.code == 2) {
            alert("Oops! No se puede obtener la posición actual");
        }
        if (err.code == 3) {
            alert("Oops! Hemos superado el tiempo de espera");
        }
    }
    return {
        Obtener: function (init) {
            iniciar = init;
            localizame(init);
        },
        DibCirculo: function (Lat, Lng) {
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
}());
