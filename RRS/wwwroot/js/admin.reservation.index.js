$(() => {

    $("#dateControl").on('change', (e) => getReservation(e.target.value));
    getReservation($("#dateControl").val());



});

function getReservation(newDate) {


    //Reservations by selected day
    $.get(`https://localhost:7271/api/reservations/any/${newDate}`, null, function (data) {

        $("#reservationsTBody").empty();

        if (data.length == 0) {
            validateTable();
            return;
        }

        data.forEach((item) => {

            $("#reservationsTBody").append(

                `<tr>
                    <td>${formatTime(item.startTime)}</td>
                    <td>${item.resType}</td>
                    <td>${(item.firstName+' '+item.lastName).length < 25 ? item.firstName+' '+item.lastName : item.firstName.length < 25 ? item.firstName+'...' : shortenText(item.firstName)}</td>
                    <td>${item.phoneNumber}</td>
                    <td>${item.noOfGuests}</td>
                    <td>${item.resStatus}</td>
                    <td>${shortenText(item.customerNotes)}</td>
                    <td>
                        <a type="button" class="btn btn-primary" href="/Admin/Reservation/Edit/${item.referenceNo}"> Edit </a>
                        <a type="button" class="btn btn-success" href="/Admin/Reservation/Details/${item.referenceNo}">Details</a>
                    </td>
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

function validateTable() {
    let columnCount = $("#sittingsT th").length; // Validation msg spans entire table
    $("#sittingsTBody").append(
        `<tr>
            <td colspan="${columnCount}">No current reservations exist on this day...</td>
        </tr>`
    );
}

function shortenText(text) {
    let shortText = String(text);
    return shortText.length <= 25 ? shortText : `${shortText.slice(0,25).trim()}...`
}