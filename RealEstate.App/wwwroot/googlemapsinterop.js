document.addEventListener('DOMContentLoaded', function () {
    window.initMap = function () {
        var map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: -34.397, lng: 150.644 },
            zoom: 8
        });

        // You can customize the map further here
    };
});