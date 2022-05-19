$(() => {

    $("#dateControl").on('change', (e) => getReservation(e.target.value));
    getReservation($("#dateControl").val());



});

function getReservation(newDate) {


    //Reservations by selected day
    $.get(`https://localhost:7271/api/reservations/any/${newDate}`, null, function (data) {

        $("#reservationsTBody").empty();

        if (data.length == 0) {

        }

        data.forEach((item) => {

            $("#reservationsTBody").append(

                `<tr>
                    <td>${formatTime(item.startTime)}</td>
                    <td>${item.resType}</td>
                    <td>${item.firstName} ${item.lastName}</td>
                    <td>${item.phoneNumber}</td>
                    <td>${item.noOfGuests}</td>
                    <td>${item.resStatus}</td>
                    <td>${item.customerNotes}</td>
                </tr>`
            );
        })

    });
}

function formatTime(dateString, addMins) {
    let date = new Date(dateString)
    if (addMins) {
        date.setMinutes(date.getMinutes() + addMins);
    }
    let hours = date.getHours() % 12 || 12;
    let mins = date.getMinutes();
    let ampm = date.getHours() < 12 ? "AM" : "PM";
    return `${hours}:${mins<=9?'0'+mins:mins} ${ampm}`;
}
