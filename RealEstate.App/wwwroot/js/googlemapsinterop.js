function console_message(message) {
    console.log(message);
}

window.initGooglePlacesAutocomplete = function (inputElement) {
    var autocomplete = new google.maps.places.Autocomplete(inputElement, {
        componentRestrictions: { country: "ro" },
        disableFields: ['directions']
    });

    autocomplete.addListener("place_changed", function () {
        var place = autocomplete.getPlace();

        if (place.geometry) {
            // Handle the selected place data (e.g., place.name, place.formatted_address)
            console.log("Place selected:", place.name, place.formatted_address);
        }
    });
};