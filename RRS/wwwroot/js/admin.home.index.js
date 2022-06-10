$(() => {
    getWarnings();
});

function getWarnings() {
    $.get(`https://localhost:7271/api/Sittings/any-capacity-warnings`, null, function (data) {
        let warn = data;
        if (warn) {
            $('#capacity-warning').css('color', '#ff0000');
        }
        else {
            $('#capacity-warning').css('color', '#000000');
        }
    })
}